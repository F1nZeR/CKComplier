using System.Reflection.Emit;

namespace CKCompiler.Core.ObjectDefs
{
    public class ArrayElemObjDef : ObjectDef
    {
        public LocalObjectDef Array { get; set; }
        public ObjectDef Index { get; set; }

        public ArrayElemObjDef(LocalObjectDef array, ObjectDef index) : base(array.Type)
        {
            Array = array;
            Index = index;
        }

        public override enmObjectScope Scope
        {
            get { return enmObjectScope.ArrayElem; }
        }

        public override void Load()
        {
            Array.Load();
            Index.Load();

            if (Array.Type == CodeGen.IntegerType)
            {
                Generator.Emit(OpCodes.Ldelem_I4);
            }
            else if (Array.Type == CodeGen.FloatType)
            {
                Generator.Emit(OpCodes.Ldelem_R4);
            }
            else if (Array.Type == CodeGen.CharType || Array.Type == CodeGen.BoolType)
            {
                Generator.Emit(OpCodes.Ldelem_I1);
            }
            else
            {
                // ссылочные типы
                Generator.Emit(OpCodes.Ldelem_Ref);
            }
        }

        public override void Remove()
        {
        }

        public override void Free()
        {
        }

        public void SetArrayElem(ObjectDef value)
        {
            Array.Load();
            Index.Load();
            value.Load();

            if (Array.Type == CodeGen.IntegerType)
            {
                Generator.Emit(OpCodes.Stelem_I4);
            }
            else if (Array.Type == CodeGen.FloatType)
            {
                Generator.Emit(OpCodes.Stelem_R4);
            }
            else if (Array.Type == CodeGen.CharType || Array.Type == CodeGen.BoolType)
            {
                Generator.Emit(OpCodes.Stelem_I1);
            }
            else
            {
                // ссылочные типы
                Generator.Emit(OpCodes.Stelem_Ref);
            }
        }
    }
}
