using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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
            Generator.Emit(OpCodes.Ldelem_I4); // токо для int32
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
            Generator.Emit(OpCodes.Stelem_I4); // токо для int32
        }
    }
}
