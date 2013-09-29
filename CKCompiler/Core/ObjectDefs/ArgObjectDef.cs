using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CKCompiler.Core.ObjectDefs
{
    public class ArgObjectDef : ObjectDef
    {
        public int Number;
        public string Name;

        public ArgObjectDef(Type type, int number, string name)
            : base(type)
        {
            Number = number;
            Name = name;
        }

        public override enmObjectScope Scope
        {
            get
            {
                return enmObjectScope.Argument;
            }
        }

        public override void Load()
        {
            switch (Number)
            {
                case 0:
                    Generator.Emit(OpCodes.Ldarg_0);
                    break;
                case 1:
                    Generator.Emit(OpCodes.Ldarg_1);
                    break;
                case 2:
                    Generator.Emit(OpCodes.Ldarg_2);
                    break;
                case 3:
                    Generator.Emit(OpCodes.Ldarg_3);
                    break;
                default:
                    Generator.Emit(Number < 256 ? OpCodes.Ldarg_S : OpCodes.Ldarg, Number);
                    break;
            }
        }

        public override void Remove()
        {
        }

        public override void Free()
        {
        }
    }
}
