using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CKCompiler.Core.ObjectDefs;
using CKCompiler.Tokens;

namespace CKCompiler.Core
{
    public class CodeGen
    {
        private readonly IParseTree _programContext;
        private readonly string _programName;
        private AssemblyName _assemblyName;
        private AssemblyBuilder _assemblyBuilder;
        private ModuleBuilder _moduleBuilder;

        private TypeBuilder _currentTypeBuilder;
        private ILGenerator _currentIlGenerator;

        protected MethodInfo WriteStringLineMethod;
        protected MethodInfo WriteIntLineMethod;
        protected MethodInfo WriteStringMethod;
        protected MethodInfo WriteIntMethod;
        protected MethodInfo ReadMethod;
        protected MethodInfo IntParseMethod;

        private Dictionary<string, TypeBuilder> _classBuilders;
        private Dictionary<string, Dictionary<string, FieldObjectDef>> _fields;
        private Dictionary<string, Dictionary<string, MethodDef>> _functions;
        private Dictionary<string, ConstructorBuilder> _constructors;

        private Dictionary<string, ArgObjectDef> _currentArgs;
        private MethodBuilder _entryPoint;

        public static Type BoolType = typeof(bool);
        public static Type IntegerType = typeof(int);
        public static Type FloatType = typeof(float);
        public static Type StringType = typeof(string);
        
        public CodeGen(IParseTree programContext, string programName)
        {
            _programContext = programContext;
            _programName = programName;

            WriteStringLineMethod = typeof (Console).GetMethod("WriteLine", BindingFlags.Public | BindingFlags.Static,
                null, new[] {StringType}, null);
            WriteIntLineMethod = typeof (Console).GetMethod("WriteLine", BindingFlags.Public | BindingFlags.Static, null,
                new[] {IntegerType}, null);
            WriteStringMethod = typeof (Console).GetMethod("Write", BindingFlags.Public | BindingFlags.Static, null,
                new[] {StringType}, null);
            WriteIntMethod = typeof (Console).GetMethod("Write", BindingFlags.Public | BindingFlags.Static, null,
                new[] {IntegerType}, null);
            ReadMethod = typeof (Console).GetMethod("ReadLine", BindingFlags.Public | BindingFlags.Static, null,
                new Type[] {}, null);
            IntParseMethod = IntegerType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, null,
                new[] {StringType}, null);
        }


        public void Generate()
        {
            GenerateAssemblyAndModuleBuilders();
            DefineClasses(_programContext);
            DefineAllFieldsAndFunctions(_programContext);
            EmitProgram(_programContext);
            _classBuilders["IO"].CreateType();

            var fileSaveError = false;
            if (File.Exists(_programName + ".exe"))
            {
                try
                {
                    using (new FileStream(_programName + ".exe", FileMode.Create)) {}
                    File.Delete(_programName + ".exe");
                }
                catch
                {
                    fileSaveError = true;
                    //CompileErrors.Add(new FileInUseError(ProgramName_, CompilerErrors.Count, null, null));
                }
            }

            //if (!fileSaveError && CompilerErrors.Count == 0)
            //    AssemblyBuilder_.Save(ProgramName_ + ".exe");

            if (!fileSaveError)
            {
                _assemblyBuilder.Save(_programName + ".exe");
            }
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
                    if (child.GetType() == typeof (CKParser.ClassBodyItemContext))
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
                inputTypes = new Type[functionListNode.ChildCount/2 + 1];
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
            DefineDefaultClasses();
        }

        private void EmitProgram(IParseTree rootNode)
        {
            EmitClasses(rootNode);
        }

        private void EmitClasses(IParseTree rootNode)
        {
            for (int i = 0; i < rootNode.ChildCount; i++)
            {
                if (rootNode.GetChild(i).GetType() == typeof(CKParser.ClassDefContext))
                    EmitClass(rootNode.GetChild(i));
                //else
                //    CompilerErrors.Add(new UnexpectedTokenError(CoolGrammarLexer.Class, treeNode.Type, CompilerErrors.Count,
                //        rootNode.GetChild(i).Line, treeNode.GetChild(i).CharPositionInLine));
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
                if (child.GetType() == typeof (CKParser.ClassBodyItemContext))
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
            _returnResult = null; // обнулим return
            _currentIlGenerator = _constructors[_currentTypeBuilder.Name].GetILGenerator();
            LocalObjectDef.InitGenerator(_currentIlGenerator);

            var field = fieldNode.GetChild(1);
            var returnObjectDef = field.ChildCount == 3
                ? EmitExpression(field.GetChild(2))
                : EmitDefaultValue(GetType(field.GetChild(0).GetChild(2).GetChild(0).GetText()));


            //if (!_constructors[_currentTypeBuilder.Name].IsStatic)
            //{
            //    _currentIlGenerator.Emit(OpCodes.Ldarg_0);
            //    returnObjectDef.Load();
            //    _currentIlGenerator.Emit(OpCodes.Stfld,
            //        _fields[_currentTypeBuilder.Name][field.GetChild(0).GetText()].FieldInfo);
            //}
            //else
            //{
                returnObjectDef.Load();
                _currentIlGenerator.Emit(OpCodes.Stsfld,
                    _fields[_currentTypeBuilder.Name][field.GetChild(0).GetChild(0).GetText()].FieldInfo);
            //}
            returnObjectDef.Remove();
        }

        private void EmitFunction(IParseTree functionNode)
        {
            _returnResult = null; // обнулим return
            var functionName = functionNode.GetChild(0).GetText();
            var functionReturnType = GetType(functionNode.GetChild(functionNode.ChildCount-2).GetChild(0).GetText());

            _currentArgs = _functions[_currentTypeBuilder.Name][functionName].Args;
            _currentIlGenerator = _functions[_currentTypeBuilder.Name][functionName].MethodBuilder.GetILGenerator();
            LocalObjectDef.InitGenerator(_currentIlGenerator);

            var returnObjectDef = EmitExpression(functionNode.GetChild(functionNode.ChildCount-1).GetChild(0));
            // если тело ничего не вернуло, но функция должна была что-то вернуть, то ошибка
            if (returnObjectDef == null && _functions[_currentTypeBuilder.Name][functionName].MethodBuilder.ReturnType != typeof(void))
            {
                throw new Exception(); // todo: ошибка, мол: функция ничего не возвращает, хотя должна
            }

            if (returnObjectDef != null) returnObjectDef.Load(); // загрузим на return значение


            //if (!functionReturnType.IsAssignableFrom(returnObjectDef.Type))
            //    //if (!returnObjectDef.Type.IsAssignableFrom(functionReturnType))
            //    CompilerErrors.Add(new InvalidReturnTypeError(
            //        Functions_[CurrentTypeBuilder_.Name][functionName].MethodBuilder,
            //        returnObjectDef.Type,
            //        CompilerErrors.Count, functionNode.GetChild(2).Line, functionNode.GetChild(2).CharPositionInLine));

            // случай, когда возвращает что-то, хотя не должен
            if (returnObjectDef != null && _functions[_currentTypeBuilder.Name][functionName].MethodBuilder.ReturnType == typeof(void))
                _currentIlGenerator.Emit(OpCodes.Pop);
            _currentIlGenerator.Emit(OpCodes.Ret);
            if (returnObjectDef != null) returnObjectDef.Remove();
        }

        #region EmitExpr
        private ObjectDef _returnResult;
        private ObjectDef EmitExpression(IParseTree expressionNode)
        {
            if (_returnResult != null) return _returnResult; // нет смысла продолжать

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
                    }
                }

                foreach (var objectDef in usedObjs)
                {
                    objectDef.Remove();
                    objectDef.Free();
                }
                return _returnResult;
            }

            if (nodeType == typeof(CKParser.VarDefContext))
            {
                return EmitVarOperation(expressionNode);
            }

            if (nodeType == typeof(CKParser.ExprContext))
            {
                return EmitExprOperation(expressionNode);
            }

            if (nodeType == typeof (CKParser.ActionContext))
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
                    return;

                case 3: // return EXPR
                    var typeBlock = (IToken) actionNode.GetChild(0).Payload;
                    switch (typeBlock.Type)
                    {
                        case CKParser.RETURN:
                            _returnResult = EmitExpression(actionNode.GetChild(1));
                            break;

                        case CKParser.WHILE:
                            EmitWhileLoop(actionNode);
                            break;
                    }
                    return;

                default:
                    throw new Exception();
            }
        }

        private void EmitWhileLoop(IParseTree whileNode)
        {
            var checkLabel = _currentIlGenerator.DefineLabel();
            _currentIlGenerator.MarkLabel(checkLabel);

            var checkObjectDef = EmitExpression(whileNode.GetChild(1));
            checkObjectDef.Load();

            //if (checkObjectDef.Type != BoolType)
            //    CompilerErrors.Add(new WhileOperatorError(checkObjectDef.Type, CompilerErrors.Count,
            //        expressionNode.GetChild(0).Line, expressionNode.GetChild(0).CharPositionInLine));

            var exitLabel = _currentIlGenerator.DefineLabel();
            _currentIlGenerator.Emit(OpCodes.Brfalse, exitLabel);

            var bodyObjectDef = EmitExpression(whileNode.GetChild(2));
            _currentIlGenerator.Emit(OpCodes.Br, checkLabel);

            _currentIlGenerator.MarkLabel(exitLabel);

            checkObjectDef.Remove();
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
                //CompilerErrors.Add(new UndefinedFunctionError(functionName, invokeObjectName,
                //    CompilerErrors.Count, functionNode.Line, functionNode.CharPositionInLine));
                result = LocalObjectDef.AllocateLocal(typeof(object));
            }
            else
            {
                var methodBuilder = _functions[invokeObjectName][functionName].MethodBuilder;
                var args = new List<ObjectDef> {invokeObjectDef};

                // грузим аргументы
                if (argsExprNode != null)
                {
                    for (int i = 0; i < argsExprNode.ChildCount; i++)
                    {
                        var objectDef = EmitExpression(argsExprNode.GetChild(i));
                        if (objectDef != null) args.Add(objectDef);
                    }

                    var args2 = _functions[invokeObjectDef.Type.Name][functionName].Args.Select(arg => arg.Value).ToList();
                    //if (!CheckTypes(args, args2))
                    //{
                    //    var args2types = new List<Type>();
                    //    foreach (var arg in args2)
                    //        args2types.Add(arg.Type);
                    //    //CompilerErrors.Add(new FunctionArgumentsError(functionName, args2types,
                    //    //    CompilerErrors.Count, functionNode.Line, functionNode.CharPositionInLine));
                    //    throw new Exception();
                    //}
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
                    var operand = (IToken) expressionNode.GetChild(1).Payload;
                    switch (operand.Type)
                    {
                        case CKParser.MULT:
                        case CKParser.DIV:
                        case CKParser.PLUS:
                        case CKParser.MINUS:
                            return EmitArithmeticOperation(expressionNode);

                        case CKParser.LT:
                        case CKParser.GT:
                            return EmitComparsionOperation(expressionNode);

                        case CKParser.EQUAL:
                            return EmitEqualOperation(expressionNode);

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
                    return EmitInvoke(expressionNode.GetChild(0), expressionNode.GetChild(2));
            }

            throw new MissingMethodException();
        }

        private ObjectDef EmitComparsionOperation(IParseTree compNode)
        {
            var returnObject2 = EmitExpression(compNode.GetChild(2));
            var returnObject1 = EmitExpression(compNode.GetChild(0));

            //if (returnObject1.Type != IntegerType || returnObject1.Type != returnObject2.Type)
            //    CompilerErrors.Add(new ComparsionOperatorError(returnObject1.Type, returnObject2.Type,
            //        CompilerErrors.Count, expressionNode.Line, expressionNode.GetChild(0).CharPositionInLine,
            //        expressionNode.GetChild(1).CharPositionInLine));
            //else
            {
                returnObject1.Load();
                returnObject2.Load();

                var compOperator = (IToken) compNode.GetChild(1).Payload;
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

                    default:
                        return null;
                }

                returnObject1.Remove();
                returnObject2.Remove();
            }

            return LocalObjectDef.AllocateLocal(BoolType);
        }

        private ObjectDef EmitEqualOperation(IParseTree equalNode)
        {
            var returnObject1 = EmitExpression(equalNode.GetChild(0));
            var returnObject2 = EmitExpression(equalNode.GetChild(2));

            //if (returnObject1.Type != returnObject2.Type)
            //    CompilerErrors.Add(new ComparsionOperatorError(returnObject1.Type, returnObject2.Type,
            //        CompilerErrors.Count, expressionNode.Line, expressionNode.GetChild(0).CharPositionInLine,
            //        expressionNode.GetChild(1).CharPositionInLine));
            //else
            {
                returnObject1.Load();
                returnObject2.Load();

                _currentIlGenerator.Emit(OpCodes.Ceq);

                returnObject1.Remove();
                returnObject2.Remove();
            }

            return LocalObjectDef.AllocateLocal(BoolType);
        }

        private ObjectDef EmitAssignOperation(IParseTree assignNode)
        {
            var returnObjectDef = EmitExpression(assignNode.GetChild(2));
            var id = EmitExpression(assignNode.GetChild(0));

            returnObjectDef.Load();
            if (id is LocalObjectDef || id is ArgObjectDef)
            {
                LocalObjectDef.AllocateLocal(id.Type, assignNode.GetChild(0).GetText());
            }
            else if (id is FieldObjectDef)
            {
                var idName = (FieldObjectDef) id;
                _currentIlGenerator.Emit(OpCodes.Stsfld, idName.FieldInfo);
            }

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

            var objectName = classNewNode.GetText();
            if (!_classBuilders.ContainsKey(objectName))
            {
                //CompilerErrors.Add(new UndefinedClassError(objectName, CompilerErrors.Count, expressionNode.Line,
                //    expressionNode.CharPositionInLine));
                throw new Exception();
                result = new ValueObjectDef(typeof(object), null);
            }
            else
            {
                var returnType = _classBuilders[objectName];

                //_currentIlGenerator.Emit(OpCodes.Newobj, _constructors[objectName]);
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

            if (returnObject1.Type != IntegerType && returnObject1.Type != FloatType || returnObject2.Type != IntegerType && returnObject2.Type != FloatType)
                //CompilerErrors.Add(new ArithmeticOperatorError(
                //    returnObject1.Type, returnObject2.Type,
                //    CompilerErrors.Count, expressionNode.Line,
                //    expressionNode.GetChild(1).CharPositionInLine,
                //    expressionNode.GetChild(0).CharPositionInLine));
                throw new InvalidOperationException();
            else
            {
                returnObject1.Load();
                returnObject2.Load();

                var exprOperandToken = (IToken) expressionNode.GetChild(1).Payload;
                if (exprOperandToken.Type == CKParser.PLUS)
                    _currentIlGenerator.Emit(OpCodes.Add);
                else if (exprOperandToken.Type == CKParser.MINUS)
                    _currentIlGenerator.Emit(OpCodes.Sub);
                else if (exprOperandToken.Type == CKParser.MULT)
                    _currentIlGenerator.Emit(OpCodes.Mul);
                else if (exprOperandToken.Type == CKParser.DIV)
                    _currentIlGenerator.Emit(OpCodes.Div);

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
                    return childNode.GetType() == typeof (CKParser.LiteralContext)
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
            
            
            //CompilerErrors.Add(new UndefinedIdError(idValue, CompilerErrors.Count,
            //    expressionNode.Line, expressionNode.CharPositionInLine));
            throw new Exception();
            return new ValueObjectDef(typeof(object), null);
        }

        private ObjectDef EmitLiteral(IParseTree literalNode)
        {
            var token = (IToken) literalNode.Payload;
            switch (token.Type)
            {
                case CKParser.INTEGER:
                    return EmitInteger(token);
                case CKParser.FLOAT:
                    return EmitFloat(token);
                case CKParser.STRING:
                    return EmitString(token);
                case CKParser.TRUE:
                case CKParser.FALSE:
                    return EmitBoolean(token);
                default:
                    throw new Exception();
            }
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

            ObjectDef localReturnObjectDef;
            if (varDefBody.ChildCount == 3)
                localReturnObjectDef = EmitExpression(varDefBody.GetChild(2));
            else
                localReturnObjectDef = EmitDefaultValue(type);
            localReturnObjectDef.Load();
            localReturnObjectDef.Remove();

            var localObjectDef = LocalObjectDef.AllocateLocal(type, localOrFieldInitNode.GetChild(0).GetText());
            localObjectDefs.Add(localObjectDef);
            
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

            //var returnObjectDef = EmitExpression(expressionNode.GetChild(1));

            // bug с видимостью переменных
            //foreach (var localObjectDefine in localObjectDefs)
            //    localObjectDefine.Free();

            //return returnObjectDef;
            return localObjectDef;
        }
        
        #endregion

        private void DefineDefaultClasses()
        {
            var functionList = new Dictionary<string, MethodDef>();
            
            _classBuilders.Add("IO", _moduleBuilder.DefineType("IO", TypeAttributes.Public, typeof(object)));
            var classBuilder = _classBuilders["IO"];

            var outStringBuilder = classBuilder.DefineMethod("WriteString", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new Type[] { StringType });
            var ilGenerator = outStringBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteStringMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("WriteString", new MethodDef("WriteString",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(StringType, 1, "x") }
				}, outStringBuilder));

            var outStringLineBuilder = classBuilder.DefineMethod("WriteLineString", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new Type[] { StringType });
            ilGenerator = outStringLineBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteStringLineMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("WriteLineString", new MethodDef("WriteLineString",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(StringType, 1, "x") }
				}, outStringLineBuilder));

            var outIntBuilder = classBuilder.DefineMethod("WriteInt", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new Type[] { IntegerType });
            ilGenerator = outIntBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteIntMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("WriteInt", new MethodDef("WriteInt",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(IntegerType, 1, "x") }
				}, outIntBuilder));

            var outIneLineBuilder = classBuilder.DefineMethod("WriteLineInt", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new Type[] { IntegerType });
            ilGenerator = outIneLineBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteIntLineMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("WriteLineInt", new MethodDef("WriteLineInt",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(IntegerType, 1, "x") }
				}, outIneLineBuilder));

            var inStringBuilder = classBuilder.DefineMethod("ReadString", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, Type.EmptyTypes);
            ilGenerator = inStringBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Call, ReadMethod);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("ReadString", new MethodDef("ReadString",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }
				}, inStringBuilder));

            var inIntBuilder = classBuilder.DefineMethod("ReadInt", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, Type.EmptyTypes);
            ilGenerator = inIntBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Call, ReadMethod);
            ilGenerator.Emit(OpCodes.Call, IntParseMethod);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("ReadInt", new MethodDef("ReadInt",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }
				}, inIntBuilder));

            var constructorBuilder = classBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            _constructors.Add("IO", constructorBuilder);

            _functions.Add("IO", functionList);
        }


        private void GenerateAssemblyAndModuleBuilders()
        {
            _assemblyName = new AssemblyName {Name = _programName};
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
                case "string":
                    return StringType;
                case "float":
                    return FloatType;
                case "object":
                    return typeof(object);
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
    }
}
