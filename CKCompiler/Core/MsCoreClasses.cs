using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using CKCompiler.Core.ObjectDefs;

namespace CKCompiler.Core
{
    public class MsCoreClasses
    {
        private readonly Dictionary<string, TypeBuilder> _classBuilders;
        private readonly ModuleBuilder _moduleBuilder;
        private readonly Dictionary<string, ConstructorBuilder> _constructors;
        private readonly Dictionary<string, Dictionary<string, MethodDef>> _functions;

        protected MethodInfo WriteStringLineMethod,
            WriteIntLineMethod,
            WriteStringMethod,
            WriteIntMethod,
            ReadMethod,
            IntParseMethod;

        public MsCoreClasses(Dictionary<string, TypeBuilder> classBuilders, ModuleBuilder moduleBuilder,
            Dictionary<string, ConstructorBuilder> constructors,
            Dictionary<string, Dictionary<string, MethodDef>> functions)
        {
            _classBuilders = classBuilders;
            _moduleBuilder = moduleBuilder;
            _constructors = constructors;
            _functions = functions;


            WriteStringLineMethod = typeof(Console).GetMethod("WriteLine", BindingFlags.Public | BindingFlags.Static,
                null, new[] { CodeGen.StringType }, null);
            WriteIntLineMethod = typeof(Console).GetMethod("WriteLine", BindingFlags.Public | BindingFlags.Static, null,
                new[] { CodeGen.IntegerType }, null);
            WriteStringMethod = typeof(Console).GetMethod("Write", BindingFlags.Public | BindingFlags.Static, null,
                new[] { CodeGen.StringType }, null);
            WriteIntMethod = typeof(Console).GetMethod("Write", BindingFlags.Public | BindingFlags.Static, null,
                new[] { CodeGen.IntegerType }, null);
            ReadMethod = typeof(Console).GetMethod("ReadLine", BindingFlags.Public | BindingFlags.Static, null,
                new Type[] { }, null);
            IntParseMethod = CodeGen.IntegerType.GetMethod("Parse", BindingFlags.Public | BindingFlags.Static, null,
                new[] { CodeGen.StringType }, null);
        }

        public void DefineDefaultClasses()
        {
            var functionList = new Dictionary<string, MethodDef>();

            _classBuilders.Add("IO", _moduleBuilder.DefineType("IO", TypeAttributes.Public, typeof(object)));
            var classBuilder = _classBuilders["IO"];

            var outStringBuilder = classBuilder.DefineMethod("WriteString", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new[] { CodeGen.StringType });
            var ilGenerator = outStringBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteStringMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("WriteString", new MethodDef("WriteString",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(CodeGen.StringType, 1, "x") }
				}, outStringBuilder));

            var outStringLineBuilder = classBuilder.DefineMethod("WriteLineString", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new[] { CodeGen.StringType });
            ilGenerator = outStringLineBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteStringLineMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("WriteLineString", new MethodDef("WriteLineString",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(CodeGen.StringType, 1, "x") }
				}, outStringLineBuilder));

            var outIntBuilder = classBuilder.DefineMethod("WriteInt", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new[] { CodeGen.IntegerType });
            ilGenerator = outIntBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteIntMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("WriteInt", new MethodDef("WriteInt",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(CodeGen.IntegerType, 1, "x") }
				}, outIntBuilder));

            var outIneLineBuilder = classBuilder.DefineMethod("WriteLineInt", MethodAttributes.Public, CallingConventions.Standard,
                classBuilder, new[] { CodeGen.IntegerType });
            ilGenerator = outIneLineBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Call, WriteIntLineMethod);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("WriteLineInt", new MethodDef("WriteLineInt",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }, 
					{ "x", new ArgObjectDef(CodeGen.IntegerType, 1, "x") }
				}, outIneLineBuilder));

            var inStringBuilder = classBuilder.DefineMethod("ReadString", MethodAttributes.Public, CallingConventions.Standard,
                CodeGen.StringType, Type.EmptyTypes);
            ilGenerator = inStringBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Call, ReadMethod);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("ReadString", new MethodDef("ReadString",
                new Dictionary<string, ArgObjectDef>() 
				{
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }
				}, inStringBuilder));

            var inIntBuilder = classBuilder.DefineMethod("ReadInt", MethodAttributes.Public, CallingConventions.Standard,
                CodeGen.IntegerType, Type.EmptyTypes);
            ilGenerator = inIntBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Call, ReadMethod);
            ilGenerator.Emit(OpCodes.Call, IntParseMethod);
            ilGenerator.Emit(OpCodes.Ret);
            functionList.Add("ReadInt", new MethodDef("ReadInt",
                new Dictionary<string, ArgObjectDef>
                {
					{ "this", new ArgObjectDef(classBuilder, 0, "this") }
				}, inIntBuilder));

            var constructorBuilder = classBuilder.DefineDefaultConstructor(MethodAttributes.Public);
            _constructors.Add("IO", constructorBuilder);

            _functions.Add("IO", functionList);
        }
    }
}
