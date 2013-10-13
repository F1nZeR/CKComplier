using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CKCompiler.Core.Errors;
using CKCompiler.Core.ObjectDefs;

namespace CKCompiler.Core
{
    public class CodeGen
    {
        private readonly IParseTree _programContext;
        private readonly string _programName;
        private AssemblyName _assemblyName;
        private AssemblyBuilder _assemblyBuilder;
        private ModuleBuilder _moduleBuilder;
        private readonly OptimizationGen _optimizationGen;

        private TypeBuilder _currentTypeBuilder;
        private ILGenerator _currentIlGenerator;

        private Dictionary<string, TypeBuilder> _classBuilders;
        private Dictionary<string, Dictionary<string, FieldObjectDef>> _fields;
        private Dictionary<string, Dictionary<string, MethodDef>> _functions;
        private Dictionary<string, ConstructorBuilder> _constructors;

        private Dictionary<string, ArgObjectDef> _currentArgs;
        private MethodBuilder _entryPoint, _currentFunction;

        public List<CompilerError> Errors { get; set; }
        private bool _skipBlockAfterReturn;

        public static Type BoolType = typeof(bool),
            IntegerType = typeof(int),
            FloatType = typeof(float),
            StringType = typeof(string),
            VoidType = typeof(void),
            CharType = typeof(char);

        public CodeGen(IParseTree programContext, string programName)
        {
            _programContext = programContext;
            _programName = programName;

            Errors = new List<CompilerError>();
            _optimizationGen = new OptimizationGen();
        }


        public void Generate(bool createFile)
        {
            GenerateAssemblyAndModuleBuilders();
            DefineClasses(_programContext);
            DefineAllFieldsAndFunctions(_programContext);
            EmitProgram(_programContext);
            _classBuilders["IO"].CreateType();

            if (createFile == false) return;

            if (File.Exists(_programName + ".exe"))
            {
                try
                {
                    using (new FileStream(_programName + ".exe", FileMode.Create)) { }
                    File.Delete(_programName + ".exe");
                }
                catch
                {
                    Errors.Add(
                        new CompilerError(string.Format("Файл: '{0}.exe' открыт в другой программе", _programName)));
                }
            }

            if (Errors.Count == 0) _assemblyBuilder.Save(_programName + ".exe");
        }

        private void DefineAllFieldsAndFunctions(IParseTree rootNode)
        {
            for (int i = 0; i < rootNode.ChildCount; i++)
            {
                var className = rootNode.GetChild(i).GetChild(1).GetText();
                var classDef = rootNode.GetChild(i);
                var classBody = classDef.GetChild(classDef.ChildCount - 1);
                var fieldList = new Dictionary<string, FieldObjectDef>();
                var functionList = new Dictionary<string, MethodDef>();
                _currentTypeBuilder = _classBuilders[className];

                for (int j = 0; j < classBody.ChildCount; j++)
                {
                    var child = classBody.GetChild(j);
                    if (child.GetType() == typeof(CKParser.ClassBodyItemContext))
                    {
                        for (int k = 0; k < child.ChildCount; k++)
                        {
                            var curChild = child.GetChild(k);
                            if (curChild.GetType() == typeof(CKParser.FuncDefContext))
                            {
                                DefineFunction(curChild, _classBuilders[className], functionList);
                            }
                            else if (curChild.GetType() == typeof(CKParser.VarDefContext))
                            {
                                DefineField(curChild, _classBuilders[className], fieldList);
                            }
                        }
                    }
                }

                var baseType = _classBuilders[className].BaseType;
                if (baseType != null)
                {
                    var baseTypeName = baseType.Name;
                    if (_classBuilders.ContainsKey(baseTypeName))
                    {
                        foreach (var field in _fields[baseTypeName])
                            if (!fieldList.ContainsKey(field.Value.Name))
                                fieldList.Add(field.Value.Name, field.Value);

                        foreach (var function in _functions[baseTypeName])
                            if (!functionList.ContainsKey(function.Value.Name))
                                functionList.Add(function.Value.Name, function.Value);
                    }
                }
                _fields.Add(className, fieldList);
                _functions.Add(className, functionList);
            }

            if (_entryPoint == null)
                Errors.Add(new CompilerError("Отсутствует точка входа (класс Program с методом Main)"));
        }

        private void DefineField(IParseTree treeNode, TypeBuilder classBuilder, IDictionary<string, FieldObjectDef> fieldList)
        {
            var defBody = treeNode.GetChild(1); // TODO от 1 до > (если через запятую делать)
            var defType = defBody.GetChild(0);

            var fieldName = defType.GetChild(0).GetText();
            var fieldType = GetType(defType.GetChild(2).GetChild(0).GetText());

            var fieldBuilder = _currentTypeBuilder.Name != "Program"
                ? classBuilder.DefineField(fieldName, fieldType, FieldAttributes.Public)
                : classBuilder.DefineField(fieldName, fieldType, FieldAttributes.Public | FieldAttributes.Static);

            fieldList.Add(fieldName, new FieldObjectDef(fieldType, fieldName, fieldBuilder));
        }

        private void DefineFunction(IParseTree treeNode, TypeBuilder classBuilder, IDictionary<string, MethodDef> functionList)
        {
            var functionName = treeNode.GetChild(0).GetText();
            var functionReturnType = GetType(treeNode.GetChild(treeNode.ChildCount - 2).GetText());

            Type[] inputTypes;
            var args = new Dictionary<string, ArgObjectDef>();
            args.Add("this", new ArgObjectDef(_currentTypeBuilder, 0, "this"));
            if (treeNode.GetChild(2).GetType() == typeof(CKParser.FuncArgsContext))
            {
                var functionListNode = treeNode.GetChild(2);
                inputTypes = new Type[functionListNode.ChildCount / 2 + 1];
                for (int k = 0, curIndex = 0; k < functionListNode.ChildCount; k++)
                {
                    if (functionListNode.GetChild(k).GetType() != typeof(CKParser.VarDefTypeContext)) continue;
                    inputTypes[curIndex] = GetType(functionListNode.GetChild(k).GetChild(2).GetChild(0).GetText());
                    var argName = functionListNode.GetChild(k).GetChild(0).GetText();
                    args.Add(argName, new ArgObjectDef(inputTypes[curIndex], curIndex + 1, argName));
                    curIndex++;
                }
            }
            else
                inputTypes = Type.EmptyTypes;

            MethodBuilder methodBuilder;

            // точка входа
            if (functionName == "Main" && classBuilder.Name == "Program")
            {
                methodBuilder = classBuilder.DefineMethod(functionName,
                    MethodAttributes.Private | MethodAttributes.Static | MethodAttributes.HideBySig, typeof(void), Type.EmptyTypes);
                methodBuilder.SetCustomAttribute(new CustomAttributeBuilder(
                    typeof(STAThreadAttribute).GetConstructor(Type.EmptyTypes), new object[] { }));
                _assemblyBuilder.SetEntryPoint(methodBuilder);
                _entryPoint = methodBuilder;
            }
            else
                methodBuilder = classBuilder.DefineMethod(functionName, MethodAttributes.Public | MethodAttributes.HideBySig, functionReturnType, inputTypes);


            functionList.Add(functionName, new MethodDef(functionName, args, methodBuilder));
        }

        private void DefineClasses(IParseTree rootNode)
        {
            _fields = new Dictionary<string, Dictionary<string, FieldObjectDef>>();
            _functions = new Dictionary<string, Dictionary<string, MethodDef>>();
            _classBuilders = new Dictionary<string, TypeBuilder>();
            _constructors = new Dictionary<string, ConstructorBuilder>();

            for (int i = 0; i < rootNode.ChildCount; i++)
            {
                var classNode = rootNode.GetChild(i);

                // есть ли наследование
                var parentType = classNode.ChildCount == 3
                    ? typeof(object)
                    : _moduleBuilder.GetType(classNode.GetChild(3).GetText());

                var className = classNode.GetChild(1).GetText();

                // объявление класса
                var classBuilder = className != "Program"
                    ? _moduleBuilder.DefineType(className, TypeAttributes.Public | TypeAttributes.BeforeFieldInit,
                        parentType)
                    : _moduleBuilder.DefineType(className, TypeAttributes.NotPublic | TypeAttributes.BeforeFieldInit,
                        parentType);

                ConstructorBuilder constructorBuilder;
                if (className != "Program")
                    constructorBuilder =
                        classBuilder.DefineConstructor(MethodAttributes.Public | MethodAttributes.HideBySig,
                            CallingConventions.Standard, Type.EmptyTypes);
                else
                {
                    classBuilder.DefineDefaultConstructor(MethodAttributes.Public);
                    constructorBuilder = classBuilder.DefineConstructor(
                        MethodAttributes.Static | MethodAttributes.Private | MethodAttributes.HideBySig,
                        CallingConventions.Standard, Type.EmptyTypes);
                }
                _constructors.Add(className, constructorBuilder);

                _classBuilders.Add(className, classBuilder);
            }

            // генерим стандартные классы
            var defClasses = new MsCoreClasses(_classBuilders, _moduleBuilder, _constructors, _functions);
            defClasses.DefineDefaultClasses();
        }

        private void EmitProgram(IParseTree rootNode)
        {
            EmitClasses(rootNode);
        }

        private void EmitClasses(IParseTree rootNode)
        {
            for (int i = 0; i < rootNode.ChildCount; i++)
            {
                EmitClass(rootNode.GetChild(i));
            }
        }

        private void EmitClass(IParseTree classDefNode)
        {
            _currentTypeBuilder = _classBuilders[classDefNode.GetChild(1).GetText()];

            var parentType = classDefNode.ChildCount == 3
                ? typeof(object)
                : _moduleBuilder.GetType(classDefNode.GetChild(3).GetText());

            var constructorInfo = parentType.GetConstructor(Type.EmptyTypes);

            // генерить поля и функции
            var contentBody = classDefNode.GetChild(classDefNode.ChildCount - 1);
            EmitFieldsAndFunction(contentBody);

            _currentIlGenerator = _constructors[classDefNode.GetChild(1).GetText()].GetILGenerator();
            if (!_constructors[classDefNode.GetChild(1).GetText()].IsStatic)
            {
                _currentIlGenerator.Emit(OpCodes.Ldarg_0);
                _currentIlGenerator.Emit(OpCodes.Call, constructorInfo); // вызов родительского конструктора;
            }
            _currentIlGenerator.Emit(OpCodes.Ret);

            _currentTypeBuilder.CreateType();
        }

        private void EmitFieldsAndFunction(IParseTree bodyNode)
        {
            for (int i = 0; i < bodyNode.ChildCount; i++)
            {
                var child = bodyNode.GetChild(i);
                if (child.GetType() == typeof(CKParser.ClassBodyItemContext))
                {
                    for (int j = 0; j < child.ChildCount; j++)
                    {
                        var itemChild = child.GetChild(j);
                        if (itemChild.GetType() == typeof(CKParser.VarDefContext))
                        {
                            EmitField(itemChild);
                        }
                    }

                    for (int j = 0; j < child.ChildCount; j++)
                    {
                        var itemChild = child.GetChild(j);
                        if (itemChild.GetType() == typeof(CKParser.FuncDefContext))
                        {
                            EmitFunction(itemChild);
                        }
                    }
                }
            }
        }

        private void EmitField(IParseTree fieldNode)
        {
            _currentIlGenerator = _constructors[_currentTypeBuilder.Name].GetILGenerator();
            LocalObjectDef.InitGenerator(_currentIlGenerator);

            var field = fieldNode.GetChild(1);
            var fieldName = field.GetChild(0).GetChild(0).GetText();
            var returnObjectDef = field.ChildCount == 3
                ? EmitExpression(field.GetChild(2))
                : EmitDefaultValue(GetType(field.GetChild(0).GetChild(2).GetChild(0).GetText()));

            if (_fields[_currentTypeBuilder.Name][fieldName].Type != returnObjectDef.Type)
                Errors.Add(new OperationTypeError((IToken)field.GetChild(1).Payload, _fields[_currentTypeBuilder.Name][fieldName].Type,
                    returnObjectDef.Type));
            returnObjectDef.Load();
            _currentIlGenerator.Emit(OpCodes.Stsfld, _fields[_currentTypeBuilder.Name][fieldName].FieldInfo);
            returnObjectDef.Remove();
        }

        private void EmitFunction(IParseTree functionNode)
        {
            var functionName = functionNode.GetChild(0).GetText();

            _currentArgs = _functions[_currentTypeBuilder.Name][functionName].Args;
            _currentIlGenerator = _functions[_currentTypeBuilder.Name][functionName].MethodBuilder.GetILGenerator();
            LocalObjectDef.InitGenerator(_currentIlGenerator);

            _currentFunction = _functions[_currentTypeBuilder.Name][functionName].MethodBuilder;

            EmitExpression(functionNode.GetChild(functionNode.ChildCount - 1).GetChild(0));
            _currentIlGenerator.Emit(OpCodes.Ret); // на всякий случай
        }

        #region EmitExpr
        private ObjectDef EmitExpression(IParseTree expressionNode)
        {
            var nodeType = expressionNode.GetType();
            if (nodeType == typeof(CKParser.BlockContext))
            {
                var usedObjs = new List<ObjectDef>();
                for (int i = 1; i < expressionNode.ChildCount - 1; i++)
                {
                    var blockStatementNode = expressionNode.GetChild(i);
                    for (int j = 0; j < blockStatementNode.ChildCount; j++)
                    {
                        var objectDef = EmitExpression(blockStatementNode.GetChild(j));
                        if (objectDef != null) usedObjs.Add(objectDef);

                        if (_skipBlockAfterReturn) break;
                    }

                    if (!_skipBlockAfterReturn) continue;
                    _skipBlockAfterReturn = false;
                    break;
                }

                foreach (var objectDef in usedObjs)
                {
                    objectDef.Remove();
                    objectDef.Free();
                }
                return null;
            }

            if (nodeType == typeof(CKParser.VarDefContext))
            {
                return EmitVarOperation(expressionNode);
            }

            if (nodeType == typeof(CKParser.ExprContext))
            {
                return EmitExprOperation(expressionNode);
            }

            if (nodeType == typeof(CKParser.ActionContext))
            {
                EmitActionOperation(expressionNode);
            }

            return null; // не нужно ничего возвращать тут
        }

        private void EmitActionOperation(IParseTree actionNode)
        {
            switch (actionNode.ChildCount)
            {
                case 1: // block
                    EmitExpression(actionNode.GetChild(0));
                    return;

                case 2:
                    var twChild = actionNode.GetChild(0);
                    if (twChild.GetType() == typeof(CKParser.StatementExprContext))
                    {
                        var objectDef = EmitExpression(twChild.GetChild(0));
                        if (objectDef != null) objectDef.Remove();
                    }
                    else if (twChild.Payload is IToken && ((IToken)twChild.Payload).Type == CKParser.RETURN)
                    {
                        EmitReturnAction(twChild);
                    }
                    return;

                case 3:
                    var typeBlock = (IToken)actionNode.GetChild(0).Payload;
                    switch (typeBlock.Type)
                    {
                        case CKParser.RETURN:
                            EmitReturnAction(actionNode);
                            break;

                        case CKParser.WHILE:
                            EmitWhileLoop(actionNode);
                            break;

                        case CKParser.IF:
                            EmitIfCondition(actionNode.GetChild(1), actionNode.GetChild(2), null);
                            break;
                    }
                    return;

                case 5:
                    EmitIfCondition(actionNode.GetChild(1), actionNode.GetChild(2), actionNode.GetChild(4));
                    break;

                default:
                    throw new Exception(); // нереализованная конструкция
            }
        }

        private void EmitReturnAction(IParseTree returnNode)
        {
            _skipBlockAfterReturn = true;
            if (returnNode.ChildCount != 3)
            {
                if (_currentFunction.ReturnType != VoidType)
                {
                    Errors.Add(new ExpectedInputTypeError((IToken)returnNode.GetChild(0).Payload,
                        _currentFunction.ReturnType));
                }
                _currentIlGenerator.Emit(OpCodes.Ret);
                return;
            }

            var returnRes = EmitExpression(returnNode.GetChild(1));
            if (returnRes == null || returnRes.Type != _currentFunction.ReturnType)
            {
                Errors.Add(new ExpectedInputTypeError((IToken)returnNode.GetChild(0).Payload,
                        _currentFunction.ReturnType));
            }
            else
            {
                returnRes.Load();
                returnRes.Remove();
            }
            _currentIlGenerator.Emit(OpCodes.Ret);
        }

        private void EmitIfCondition(IParseTree conditionNode, IParseTree actionNode, IParseTree elseNode)
        {
            var checkObjectDef = EmitExpression(conditionNode);

            // оптимизация с константой
            if (checkObjectDef.GetType() == typeof(ValueObjectDef) && checkObjectDef.Type == BoolType)
            {
                var checkValue = (bool)((ValueObjectDef)checkObjectDef).GetValue();
                if (checkValue)
                {
                    // генерим только тело
                    EmitExpression(actionNode);
                }
                else if (elseNode != null)
                {
                    EmitExpression(elseNode);
                }
                return;
            }

            checkObjectDef.Load();
            checkObjectDef.Remove();

            if (checkObjectDef.Type != BoolType)
                Errors.Add(new ExpectedInputTypeError((IToken)conditionNode.Parent.GetChild(0).Payload, BoolType));

            var exitLabel = _currentIlGenerator.DefineLabel();
            var elseLabel = _currentIlGenerator.DefineLabel();

            _currentIlGenerator.Emit(OpCodes.Brfalse, elseNode != null ? elseLabel : exitLabel);

            EmitExpression(actionNode);
            _currentIlGenerator.Emit(OpCodes.Br, exitLabel);

            if (elseNode != null)
            {
                _currentIlGenerator.MarkLabel(elseLabel);
                EmitExpression(elseNode);
            }

            _currentIlGenerator.MarkLabel(exitLabel);
        }

        private void EmitWhileLoop(IParseTree whileNode)
        {
            var checkLabel = _currentIlGenerator.DefineLabel();
            _currentIlGenerator.MarkLabel(checkLabel);

            var checkObjectDef = EmitExpression(whileNode.GetChild(1));
            checkObjectDef.Load();
            checkObjectDef.Remove();

            // Оптимизация с константой (true - бесконечный цикл, но надеемся, что разработчик сам там return воткнёт
            // и просто сгенерим цикл. Иначе, если false, то цикл не генерим)
            if (checkObjectDef.GetType() == typeof(ValueObjectDef) && checkObjectDef.Type == BoolType)
            {
                var checkValue = (bool)((ValueObjectDef)checkObjectDef).GetValue();
                if (!checkValue)
                {
                    return;
                }
            }

            if (checkObjectDef.Type != BoolType)
                Errors.Add(new ExpectedInputTypeError((IToken)whileNode.GetChild(0).Payload, BoolType));

            var exitLabel = _currentIlGenerator.DefineLabel();
            _currentIlGenerator.Emit(OpCodes.Brfalse, exitLabel);

            var bodyObjectDef = EmitExpression(whileNode.GetChild(2));
            _currentIlGenerator.Emit(OpCodes.Br, checkLabel);

            _currentIlGenerator.MarkLabel(exitLabel);
            if (bodyObjectDef != null) bodyObjectDef.Remove();
        }

        /// <summary>
        /// Вызов функции
        /// </summary>
        /// <param name="functionNode"></param>
        /// <param name="argsExprNode"></param>
        /// <returns></returns>
        private ObjectDef EmitInvoke(IParseTree functionNode, IParseTree argsExprNode)
        {
            var functionName = functionNode.GetChild(2).GetText();
            var invokeObjectDef = EmitExpression(functionNode.GetChild(0));
            var invokeObjectName = invokeObjectDef.Type.Name;

            ObjectDef result;
            if (!_functions.ContainsKey(invokeObjectName) || !_functions[invokeObjectName].ContainsKey(functionName))
            {
                Errors.Add(new UndefinedFunctionError((IToken)functionNode.GetChild(2).Payload));
                result = LocalObjectDef.AllocateLocal(typeof(object));
            }
            else
            {
                var methodBuilder = _functions[invokeObjectName][functionName].MethodBuilder;
                var args = new List<ObjectDef> { invokeObjectDef };

                // грузим аргументы
                if (argsExprNode != null)
                {
                    for (int i = 0; i < argsExprNode.ChildCount; i++)
                    {
                        var objectDef = EmitExpression(argsExprNode.GetChild(i));
                        if (objectDef != null) args.Add(objectDef);
                    }

                    var args2 = _functions[invokeObjectDef.Type.Name][functionName].Args.Select(arg => arg.Value).ToList();
                    if (!CheckTypes(args, args2))
                    {
                        var args2Types = args2.Select(arg => arg.Type).ToList();
                        Errors.Add(new FunctionArgumentsError((IToken)functionNode.GetChild(2).Payload, args2Types));
                    }
                }

                foreach (var arg in args)
                    arg.Load();

                _currentIlGenerator.Emit(OpCodes.Call, methodBuilder);

                foreach (var arg in args)
                    arg.Remove();
                invokeObjectDef.Remove();

                // если возвращает VOID
                if (_functions[invokeObjectDef.Type.Name][functionName].MethodBuilder.ReturnType == typeof(void))
                {
                    _currentIlGenerator.Emit(OpCodes.Pop);
                    result = new ValueObjectDef(_functions[invokeObjectDef.Type.Name][functionName].MethodBuilder.ReturnType, null);
                }
                else
                    result = LocalObjectDef.AllocateLocal(_functions[invokeObjectDef.Type.Name][functionName].MethodBuilder.ReturnType);
            }

            return result;
        }

        /// <summary>
        /// Обработка выражений
        /// </summary>
        /// <param name="expressionNode"></param>
        /// <returns></returns>
        private ObjectDef EmitExprOperation(IParseTree expressionNode)
        {
            switch (expressionNode.ChildCount)
            {
                case 1:
                    return EmitPrimaryContext(expressionNode.GetChild(0));
                case 2:
                    return EmitObjectCreation(expressionNode.GetChild(1));
                case 3:
                    var operand = (IToken)expressionNode.GetChild(1).Payload;
                    switch (operand.Type)
                    {
                        case CKParser.MULT:
                        case CKParser.DIV:
                        case CKParser.PLUS:
                        case CKParser.MINUS:
                            return EmitArithmeticOperation(expressionNode);

                        case CKParser.LT:
                        case CKParser.GT:
                        case CKParser.GE:
                        case CKParser.LE:
                            return EmitComparsionOperation(expressionNode);

                        case CKParser.EQUAL:
                        case CKParser.NOTEQUAL:
                            return EmitEqualOperation(expressionNode, operand);

                        case CKParser.ASSIGN:
                            return EmitAssignOperation(expressionNode);

                        case CKParser.LPAREN: // func call
                            return EmitInvoke(expressionNode.GetChild(0), null);

                        case CKParser.DOT: // property
                            return EmitProperty(expressionNode.GetChild(0), expressionNode.GetChild(2));

                        default:
                            throw new MissingMethodException();
                    }
                case 4: // func call with args
                    operand = (IToken)expressionNode.GetChild(1).Payload;
                    switch (operand.Type)
                    {
                        case CKParser.LBRACK:
                            return EmitArrayElement(expressionNode);

                        case CKParser.LPAREN:
                            return EmitInvoke(expressionNode.GetChild(0), expressionNode.GetChild(2));
                    }
                    break;
            }

            throw new MissingMethodException();
        }

        private ObjectDef EmitArrayElement(IParseTree expressionNode)
        {
            var arrayObj = EmitExpression(expressionNode.GetChild(0));
            var index = EmitExpression(expressionNode.GetChild(2));

            return new ArrayElemObjDef((LocalObjectDef)arrayObj, index);
        }

        private ObjectDef EmitComparsionOperation(IParseTree compNode)
        {
            var returnObject1 = EmitExpression(compNode.GetChild(0));
            var returnObject2 = EmitExpression(compNode.GetChild(2));

            if (returnObject1.Type != IntegerType && returnObject1.Type != FloatType ||
                returnObject2.Type != IntegerType && returnObject2.Type != FloatType)
                Errors.Add(new OperationTypeError((IToken)compNode.GetChild(1).Payload, returnObject1.Type,
                    returnObject2.Type));
            else
            {
                var compOperator = (IToken)compNode.GetChild(1).Payload;

                // оптимизация: если и левый кусок и правый - константы
                if (returnObject1.GetType() == returnObject2.GetType() &&
                    returnObject1.GetType() == typeof(ValueObjectDef))
                {
                    var newValue = _optimizationGen.GetComparasionConstValue(returnObject1, returnObject2, compOperator);
                    return newValue;
                }

                returnObject1.Load();
                returnObject2.Load();

                switch (compOperator.Type)
                {
                    case CKParser.LT:
                        _currentIlGenerator.Emit(OpCodes.Clt);
                        break;

                    case CKParser.LE:
                        _currentIlGenerator.Emit(OpCodes.Cgt);
                        _currentIlGenerator.Emit(OpCodes.Ldc_I4_0);
                        _currentIlGenerator.Emit(OpCodes.Ceq);
                        break;

                    case CKParser.GT:
                        _currentIlGenerator.Emit(OpCodes.Cgt);
                        break;

                    case CKParser.GE:
                        _currentIlGenerator.Emit(OpCodes.Clt);
                        _currentIlGenerator.Emit(OpCodes.Ldc_I4_0);
                        _currentIlGenerator.Emit(OpCodes.Ceq);
                        break;
                }

                returnObject1.Remove();
                returnObject2.Remove();
            }

            return LocalObjectDef.AllocateLocal(BoolType);
        }

        /// <summary>
        /// Эмит операции равенства/неравенства
        /// </summary>
        /// <param name="equalNode"></param>
        /// <param name="operand">операция</param>
        /// <returns></returns>
        private ObjectDef EmitEqualOperation(IParseTree equalNode, IToken operand)
        {
            var returnObject1 = EmitExpression(equalNode.GetChild(0));
            var returnObject2 = EmitExpression(equalNode.GetChild(2));

            if ((returnObject1.Type != IntegerType && returnObject1.Type != FloatType ||
                returnObject2.Type != IntegerType && returnObject2.Type != FloatType) &&
                returnObject1.Type != returnObject2.Type)
                Errors.Add(new OperationTypeError(operand, returnObject1.Type,
                    returnObject2.Type));
            else
            {
                // оптимизация: если и левый кусок и правый - константы
                if (returnObject1.GetType() == returnObject2.GetType() &&
                    returnObject1.GetType() == typeof(ValueObjectDef))
                {
                    var newValue = _optimizationGen.GetEqualityConstValue(returnObject1, returnObject2);
                    return newValue;
                }

                returnObject1.Load();
                returnObject2.Load();

                if (returnObject1.Type != StringType)
                {
                    _currentIlGenerator.Emit(OpCodes.Ceq);
                }
                else // случай со строками
                {
                    var method = typeof(String).GetMethod("op_Equality", BindingFlags.Public | BindingFlags.Static,
                        null, new[] { StringType, StringType }, null);
                    _currentIlGenerator.EmitCall(OpCodes.Call, method, null);
                    _currentIlGenerator.Emit(OpCodes.Ldc_I4_1);
                    _currentIlGenerator.Emit(OpCodes.Ceq);
                }

                // случай NotEqual
                if (operand.Type == CKParser.NOTEQUAL)
                {
                    _currentIlGenerator.Emit(OpCodes.Ldc_I4_0);
                    _currentIlGenerator.Emit(OpCodes.Ceq);
                }

                returnObject1.Remove();
                returnObject2.Remove();
            }

            return LocalObjectDef.AllocateLocal(BoolType);
        }

        private ObjectDef EmitAssignOperation(IParseTree assignNode)
        {
            var returnObjectDef = EmitExpression(assignNode.GetChild(2));
            var id = EmitExpression(assignNode.GetChild(0));

            if (id.Type != returnObjectDef.Type)
                Errors.Add(new OperationTypeError((IToken)assignNode.GetChild(1).Payload, id.Type,
                    returnObjectDef.Type));

            if (id is ArrayElemObjDef)
            {
                var curId = (ArrayElemObjDef) id;
                curId.SetArrayElem(returnObjectDef);
                return null;
            }

            returnObjectDef.Load();
            if (id is FieldObjectDef)
            {
                var idName = (FieldObjectDef)id;
                _currentIlGenerator.Emit(OpCodes.Stsfld, idName.FieldInfo);
                return null;
            }

            // здесь обработается случай с field'ами и localObjDef'ами
            LocalObjectDef.AllocateLocal(id.Type, assignNode.GetChild(0).GetText());
            return null;
        }

        /// <summary>
        /// Получение свойства класса из объекта
        /// </summary>
        /// <param name="objNode"></param>
        /// <param name="propNode"></param>
        /// <returns></returns>
        private ObjectDef EmitProperty(IParseTree objNode, IParseTree propNode)
        {
            var obj = EmitExpression(objNode);
            var idValue = propNode.GetText();
            if (_fields[obj.Type.Name].ContainsKey(idValue))
            {
                return _fields[obj.Type.Name][idValue];
            }
            return new ValueObjectDef(typeof(object), null);
        }

        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="classNewNode"></param>
        /// <returns></returns>
        private ObjectDef EmitObjectCreation(IParseTree classNewNode)
        {
            ObjectDef result;

            // если инициализация массива
            if (classNewNode.ChildCount == 4)
            {
                // возвращаем количество
                var count = EmitExpression(classNewNode.GetChild(2));
                if (count.Type != IntegerType)
                {
                    Errors.Add(new CompilerError("Размер массива должен быть целочисленным",
                        classNewNode.GetChild(1).Payload));
                    return new ValueObjectDef(IntegerType, 0);
                }
                return count;
            }

            var objectName = classNewNode.GetText();
            if (!_classBuilders.ContainsKey(objectName))
            {
                Errors.Add(new UndefinedClassError((IToken)classNewNode.Payload));
                result = new ValueObjectDef(typeof(object), null);
            }
            else
            {
                var returnType = _classBuilders[objectName];
                result = new ValueObjectDef(returnType, null, _constructors[objectName]);
            }

            return result;
        }

        /// <summary>
        /// Обработка выражений с операциями
        /// </summary>
        /// <param name="expressionNode"></param>
        /// <returns></returns>
        private ObjectDef EmitArithmeticOperation(IParseTree expressionNode)
        {
            var returnObject1 = EmitExpression(expressionNode.GetChild(0));
            var returnObject2 = EmitExpression(expressionNode.GetChild(2));
            var exprOperandToken = (IToken)expressionNode.GetChild(1).Payload;

            if (returnObject1.Type != returnObject2.Type &&
                ((returnObject1.Type != FloatType && returnObject2.Type != IntegerType) ||
                (returnObject1.Type != IntegerType && returnObject2.Type != FloatType) ||
                returnObject1.Type == StringType && returnObject2.Type == StringType && exprOperandToken.Type != CKParser.PLUS))
                Errors.Add(new OperationTypeError((IToken)expressionNode.GetChild(1).Payload, returnObject1.Type,
                    returnObject2.Type));
            else
            {
                // оптимизация: если и левый кусок и правый - константы
                if (returnObject1.GetType() == returnObject2.GetType() &&
                    returnObject1.GetType() == typeof(ValueObjectDef))
                {
                    var retValue = _optimizationGen.GetArithmeticConstValue(returnObject1, returnObject2,
                        exprOperandToken);
                    return retValue;
                }

                returnObject1.Load();
                returnObject2.Load();

                switch (exprOperandToken.Type)
                {
                    case CKParser.PLUS:
                        if (returnObject1.Type == returnObject2.Type && returnObject1.Type == StringType)
                        {
                            var method = typeof(String).GetMethod("Concat",
                                BindingFlags.Public | BindingFlags.Static,
                                null, new[] { StringType, StringType }, null);
                            _currentIlGenerator.EmitCall(OpCodes.Call, method, null);
                        }
                        else _currentIlGenerator.Emit(OpCodes.Add);
                        break;
                    case CKParser.MINUS:
                        _currentIlGenerator.Emit(OpCodes.Sub);
                        break;
                    case CKParser.MULT:
                        _currentIlGenerator.Emit(OpCodes.Mul);
                        break;
                    case CKParser.DIV:
                        _currentIlGenerator.Emit(OpCodes.Div);
                        break;
                }

                returnObject1.Remove();
                returnObject2.Remove();
            }

            return LocalObjectDef.AllocateLocal(returnObject1.Type);
        }

        private ObjectDef EmitPrimaryContext(IParseTree primaryNode)
        {
            switch (primaryNode.ChildCount)
            {
                case 1:
                    var childNode = primaryNode.GetChild(0);
                    return childNode.GetType() == typeof(CKParser.LiteralContext)
                        ? EmitLiteral(childNode.GetChild(0))
                        : EmitIdentificator(childNode);

                case 3:
                    return EmitExpression(primaryNode.GetChild(1));
            }
            throw new Exception();
        }

        /// <summary>
        /// Получение идентификатора
        /// </summary>
        /// <param name="idNode"></param>
        /// <returns></returns>
        private ObjectDef EmitIdentificator(IParseTree idNode)
        {
            var idValue = idNode.GetText();
            LocalObjectDef localObjectDef;
            if ((localObjectDef = LocalObjectDef.GetLocalObjectDef(idValue)) != null)
                return localObjectDef;
            if (_currentArgs.ContainsKey(idValue))
                return _currentArgs[idValue];
            if (_fields[_currentTypeBuilder.Name].ContainsKey(idValue))
                return _fields[_currentTypeBuilder.Name][idValue];


            Errors.Add(new UndefinedIdError((IToken)idNode.Payload));
            return new ValueObjectDef(typeof(object), null);
        }

        private ObjectDef EmitLiteral(IParseTree literalNode)
        {
            var token = (IToken)literalNode.Payload;
            switch (token.Type)
            {
                case CKParser.INTEGER:
                    return EmitInteger(token);
                case CKParser.FLOAT:
                    return EmitFloat(token);
                case CKParser.STRING:
                    return EmitString(token);
                case CKParser.CHAR:
                    return EmitChar(token);
                case CKParser.TRUE:
                case CKParser.FALSE:
                    return EmitBoolean(token);
                default:
                    throw new Exception(); // не реализовано
            }
        }

        private ObjectDef EmitChar(IToken charToken)
        {
            var result = new ValueObjectDef(CharType, char.Parse(charToken.Text.Replace("\'", "")));
            return result;
        }

        private ObjectDef EmitString(IToken strToken)
        {
            var result = new ValueObjectDef(StringType, strToken.Text.Replace("\"", ""));
            return result;
        }

        private ObjectDef EmitFloat(IToken floatToken)
        {
            var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            var result = new ValueObjectDef(FloatType, float.Parse(floatToken.Text, NumberStyles.Any, ci));
            return result;
        }

        private ObjectDef EmitBoolean(IToken boolToken)
        {
            var result = new ValueObjectDef(BoolType, bool.Parse(boolToken.Text));
            return result;
        }

        private ObjectDef EmitInteger(IToken intToken)
        {
            var result = new ValueObjectDef(IntegerType, int.Parse(intToken.Text));
            return result;
        }

        /// <summary>
        /// Объявление переменных внутри функции
        /// </summary>
        /// <param name="expressionNode"></param>
        /// <returns></returns>
        private ObjectDef EmitVarOperation(IParseTree expressionNode)
        {
            var localObjectDefs = new List<ObjectDef>();

            var varDefBody = expressionNode.GetChild(1);
            var localOrFieldInitNode = varDefBody.GetChild(0);
            var type = GetType(localOrFieldInitNode.GetChild(2).GetChild(0).GetText());

            var isArray = false;
            if (localOrFieldInitNode.ChildCount == 5)
            {
                // массивы
                isArray = true;
                var size = EmitExpression(varDefBody.GetChild(2));
                size.Load();
                size.Remove();
            }
            else
            {
                var localReturnObjectDef = varDefBody.ChildCount == 3
                ? EmitExpression(varDefBody.GetChild(2))
                : EmitDefaultValue(type);

                if (type != localReturnObjectDef.Type)
                    Errors.Add(new OperationTypeError((IToken)varDefBody.GetChild(1).Payload, type,
                        localReturnObjectDef.Type));

                localReturnObjectDef.Load();
                localReturnObjectDef.Remove();
            }

            var localObjectDef = LocalObjectDef.AllocateLocal(type, localOrFieldInitNode.GetChild(0).GetText(), isArray);
            localObjectDefs.Add(localObjectDef);

            // todo: var переменные через запятую
            //for (int i = 0; i < expressionNode.GetChild(0).ChildCount; i++)
            //{
            //    var localOrFieldInitNode = expressionNode.GetChild(0).GetChild(i);
            //    var type = GetType(localOrFieldInitNode.GetChild(1).GetText());

            //    ObjectDef localReturnObjectDef;
            //    if (localOrFieldInitNode.ChildCount == 3)
            //        localReturnObjectDef = EmitExpression(localOrFieldInitNode.GetChild(2));
            //    else
            //        localReturnObjectDef = EmitDefaultValue(type);
            //    localReturnObjectDef.Load();
            //    //localReturnObjectDef.Remove();
            //    var localObjectDef = LocalObjectDef.AllocateLocal(type, localOrFieldInitNode.GetChild(0).GetText());
            //    localObjectDefs.Add(localObjectDef);
            //}

            return localObjectDef;
        }

        #endregion


        private void GenerateAssemblyAndModuleBuilders()
        {
            _assemblyName = new AssemblyName { Name = _programName };
            _assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(_assemblyName, AssemblyBuilderAccess.Save);
            _moduleBuilder = _assemblyBuilder.DefineDynamicModule(_programName, _programName + ".exe", false);
        }

        private Type GetType(string typeName)
        {
            switch (typeName)
            {
                case "int":
                    return IntegerType;
                case "bool":
                    return BoolType;
                case "char":
                    return CharType;
                case "string":
                    return StringType;
                case "float":
                    return FloatType;
                case "void":
                    return VoidType;
                default:
                    return _moduleBuilder.GetType(typeName);
            }
        }

        private static ValueObjectDef EmitDefaultValue(Type type)
        {
            object value;
            if (type == BoolType)
                value = false;
            else if (type == IntegerType || type == FloatType)
                value = 0;
            else if (type == StringType)
                value = "";
            else
                value = null;

            var result = new ValueObjectDef(type, value);
            return result;
        }

        private bool CheckTypes(List<ObjectDef> args1, List<ArgObjectDef> args2)
        {
            if (args1.Count != args2.Count)
                return false;

            for (int i = 0; i < args1.Count; i++)
            {
                var tempType = args1[i].Type;
                if (tempType.IsAssignableFrom(args2[i].Type)) continue;
                if (tempType.BaseType == null) return false;
                if (tempType.BaseType.Name != args2[i].Type.Name) return false;
            }
            return true;
        }
    }
}
