using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
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
                var classBody = rootNode.GetChild(i).GetChild(2);
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
                ? classBuilder.DefineField(fieldName, fieldType, FieldAttributes.Family)
                : classBuilder.DefineField(fieldName, fieldType, FieldAttributes.Family | FieldAttributes.Static);

            fieldList.Add(fieldName, new FieldObjectDef(fieldType, fieldName, fieldBuilder));
        }

        private void DefineFunction(IParseTree treeNode, TypeBuilder classBuilder, IDictionary<string, MethodDef> functionList)
        {
            var functionName = treeNode.GetChild(0).GetText();
            var functionReturnType = GetType(treeNode.GetChild(1).GetText());

            Type[] inputTypes;
            var args = new Dictionary<string, ArgObjectDef>();
            args.Add("this", new ArgObjectDef(_currentTypeBuilder, 0, "this"));
            if (treeNode.GetChild(2).GetType() == typeof(CKParser.FuncArgsContext))
            {
                var functionListNode = treeNode.GetChild(2);
                inputTypes = new Type[functionListNode.ChildCount];
                for (int k = 0; k < functionListNode.ChildCount; k++)
                {
                    inputTypes[k] = GetType(functionListNode.GetChild(k).GetChild(2).GetChild(0).GetText());
                    var argName = functionListNode.GetChild(k).GetChild(0).GetText();
                    args.Add(argName, new ArgObjectDef(inputTypes[k], k + 1, argName));
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
            _currentIlGenerator = _constructors[_currentTypeBuilder.Name].GetILGenerator();
            LocalObjectDef.InitGenerator(_currentIlGenerator);

            var field = fieldNode.GetChild(1).GetChild(0);
            ObjectDef returnObjectDef;
            //if (fieldNode.ChildCount == 3)
            //    returnObjectDef = EmitExpression(fieldNode.GetChild(2));
            //else
                returnObjectDef = EmitDefaultValue(GetType(field.GetChild(2).GetChild(0).GetText()));


            if (!_constructors[_currentTypeBuilder.Name].IsStatic)
            {
                _currentIlGenerator.Emit(OpCodes.Ldarg_0);
                returnObjectDef.Load();
                _currentIlGenerator.Emit(OpCodes.Stfld,
                    _fields[_currentTypeBuilder.Name][field.GetChild(0).GetText()].FieldInfo);
            }
            else
            {
                returnObjectDef.Load();
                _currentIlGenerator.Emit(OpCodes.Stsfld,
                    _fields[_currentTypeBuilder.Name][field.GetChild(0).GetText()].FieldInfo);
            }
            returnObjectDef.Remove();
        }

        private void EmitFunction(IParseTree functionNode)
        {
            var functionName = functionNode.GetChild(0).GetText();
            var functionReturnType = GetType(functionNode.GetChild(functionNode.ChildCount-2).GetChild(0).GetText());

            _currentArgs = _functions[_currentTypeBuilder.Name][functionName].Args;
            _currentIlGenerator = _functions[_currentTypeBuilder.Name][functionName].MethodBuilder.GetILGenerator();
            LocalObjectDef.InitGenerator(_currentIlGenerator);

            //var returnObjectDef = EmitExpression(functionNode.GetChild(2));
            //returnObjectDef.Load();

            //if (!functionReturnType.IsAssignableFrom(returnObjectDef.Type))
            //    //if (!returnObjectDef.Type.IsAssignableFrom(functionReturnType))
            //    CompilerErrors.Add(new InvalidReturnTypeError(
            //        Functions_[CurrentTypeBuilder_.Name][functionName].MethodBuilder,
            //        returnObjectDef.Type,
            //        CompilerErrors.Count, functionNode.GetChild(2).Line, functionNode.GetChild(2).CharPositionInLine));

            // BUG: должен быть POP, но ему не нужен?!
            //if (_functions[_currentTypeBuilder.Name][functionName].MethodBuilder.ReturnType == typeof(void))
            //    _currentIlGenerator.Emit(OpCodes.Pop);
            _currentIlGenerator.Emit(OpCodes.Ret);

            //returnObjectDef.Remove();
        }

        private void DefineDefaultClasses()
        {
            var functionList = new Dictionary<string, MethodDef>();
            
            _classBuilders.Add("IO", _moduleBuilder.DefineType("IO", TypeAttributes.Public, typeof(object)));
            var classBuilder = _classBuilders["IO"];


            var outStringBuilder = classBuilder.DefineMethod("out_string", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new Type[] { StringType });
            var ilGenerator = outStringBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteStringMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("out_string", new MethodDef("out_string",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(StringType, 1, "x") }
				}, outStringBuilder));


            var outStringLineBuilder = classBuilder.DefineMethod("out_string_line", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new Type[] { StringType });
            ilGenerator = outStringLineBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteStringLineMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("out_string_line", new MethodDef("out_string_line",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(StringType, 1, "x") }
				}, outStringLineBuilder));


            var outIntBuilder = classBuilder.DefineMethod("out_int", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new Type[] { IntegerType });
            ilGenerator = outIntBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteIntMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("out_int", new MethodDef("out_int",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(IntegerType, 1, "x") }
				}, outIntBuilder));


            var outIneLineBuilder = classBuilder.DefineMethod("out_int_line", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new Type[] { IntegerType });
            ilGenerator = outIneLineBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteIntLineMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("out_int_line", new MethodDef("out_int_line",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(IntegerType, 1, "x") }
				}, outIneLineBuilder));


            var inStringBuilder = classBuilder.DefineMethod("in_string", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, Type.EmptyTypes);
            ilGenerator = inStringBuilder.GetILGenerator();
            //ilGenerator.Emit(OpCodes.Nop);
            ilGenerator.Emit(OpCodes.Call, ReadMethod);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("in_string", new MethodDef("in_string",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }
				}, inStringBuilder));




            var inIntBuilder = classBuilder.DefineMethod("in_int", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, Type.EmptyTypes);
            ilGenerator = inIntBuilder.GetILGenerator();
            //ilGenerator.Emit(OpCodes.Nop);
            ilGenerator.Emit(OpCodes.Call, ReadMethod);
            ilGenerator.Emit(OpCodes.Call, IntParseMethod);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("in_int", new MethodDef("in_int",
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
            Type result;
            switch (typeName)
            {
                case "int":
                    result = IntegerType;
                    break;
                case "bool":
                    result = BoolType;
                    break;
                case "string":
                    result = StringType;
                    break;
                case "object":
                    result = typeof(object);
                    break;
                default:
                    result = _moduleBuilder.GetType(typeName);
                    break;
            }
            return result;
        }

        private static ValueObjectDef EmitDefaultValue(Type type)
        {
            object value;
            if (type == BoolType)
                value = false;
            else if (type == IntegerType)
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
