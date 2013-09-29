using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CKCompiler.Core.ObjectDefs
{
    public abstract class ObjectDef
    {
        protected static ILGenerator Generator;

        public bool IsUsed
        {
            get;
            set;
        }

        public Type Type
        {
            get;
            protected set;
        }

        public abstract enmObjectScope Scope
        {
            get;
        }

        protected ObjectDef(Type type)
        {
            Type = type;
            IsUsed = true;
        }

        public abstract void Load();

        public abstract void Remove();

        public abstract void Free();

        protected static void EmitSaveToLocal(int localVarNumber)
        {
            switch (localVarNumber)
            {
                case 0:
                    Generator.Emit(OpCodes.Stloc_0);
                    break;
                case 1:
                    Generator.Emit(OpCodes.Stloc_1);
                    break;
                case 2:
                    Generator.Emit(OpCodes.Stloc_2);
                    break;
                case 3:
                    Generator.Emit(OpCodes.Stloc_3);
                    break;
                default:
                    if (localVarNumber < 256)
                        Generator.Emit(OpCodes.Stloc_S, localVarNumber);
                    else
                        Generator.Emit(OpCodes.Stloc, localVarNumber);
                    break;
            }
        }

        protected static void EmitLoadFromLocal(int localVarNumber)
        {
            switch (localVarNumber)
            {
                case 0:
                    Generator.Emit(OpCodes.Ldloc_0);
                    break;
                case 1:
                    Generator.Emit(OpCodes.Ldloc_1);
                    break;
                case 2:
                    Generator.Emit(OpCodes.Ldloc_2);
                    break;
                case 3:
                    Generator.Emit(OpCodes.Ldloc_3);
                    break;
                default:
                    if (localVarNumber < 256)
                        Generator.Emit(OpCodes.Ldloc_S, localVarNumber);
                    else
                        Generator.Emit(OpCodes.Ldloc, localVarNumber);
                    break;
            }
        }

        protected static void EmitInteger(int value)
        {
            switch (value)
            {
                case -1:
                    Generator.Emit(OpCodes.Ldc_I4_M1);
                    break;
                case 0:
                    Generator.Emit(OpCodes.Ldc_I4_0);
                    break;
                case 1:
                    Generator.Emit(OpCodes.Ldc_I4_1);
                    break;
                case 2:
                    Generator.Emit(OpCodes.Ldc_I4_2);
                    break;
                case 3:
                    Generator.Emit(OpCodes.Ldc_I4_3);
                    break;
                case 4:
                    Generator.Emit(OpCodes.Ldc_I4_4);
                    break;
                case 5:
                    Generator.Emit(OpCodes.Ldc_I4_5);
                    break;
                case 6:
                    Generator.Emit(OpCodes.Ldc_I4_6);
                    break;
                case 7:
                    Generator.Emit(OpCodes.Ldc_I4_7);
                    break;
                case 8:
                    Generator.Emit(OpCodes.Ldc_I4_8);
                    break;
                default:
                    if (value >= -128 && value <= 127)
                        Generator.Emit(OpCodes.Ldc_I4_S, (sbyte)value);
                    else
                        Generator.Emit(OpCodes.Ldc_I4, value);
                    break;
            }
        }
    }
}
