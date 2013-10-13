using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CKCompiler.Core.ObjectDefs
{
    public class LocalObjectDef : ObjectDef
    {
        protected static List<LocalObjectDef> Locals;

        public int Number;
        public string Name;
        public bool IsArray;

        protected LocalObjectDef(Type type, int number, string name = "", bool isArray = false)
            : base(type)
        {
            Name = name;
            Number = number;
            IsArray = isArray;
        }

        public override enmObjectScope Scope
        {
            get
            {
                return enmObjectScope.Local;
            }
        }

        protected List<LocalObjectDef> DuplicatedLocals = new List<LocalObjectDef>();

        public static LocalObjectDef AllocateLocal(Type type, string name = "", bool isArray = false)
        {
            var duplicatedLocals = new List<LocalObjectDef>();
            int number = 0;
            int i;
            for (i = 0; i < Locals.Count; i++)
                if (Locals[i].Scope == enmObjectScope.Local && Locals[i].Name == name && name != "")
                {
                    duplicatedLocals.Add(Locals[i]);
                    Locals[i].IsUsed = false;
                }

            for (i = 0; i < Locals.Count; i++)
                if (Locals[i].Type.Name == type.Name && !Locals[i].IsUsed)
                {
                    number = i;
                    Locals[i] = new LocalObjectDef(type, number, name, isArray);
                    break;
                }
            if (i == Locals.Count)
            {
                if (isArray)
                {
                    Generator.Emit(OpCodes.Newarr, type);
                }
                var localVar = Generator.DeclareLocal(type);
                number = localVar.LocalIndex;
                Locals.Add(new LocalObjectDef(type, number, name, isArray));
            }
            EmitSaveToLocal(number);
            return Locals[number];
        }

        public override void Load()
        {
            EmitLoadFromLocal(Number);
        }

        public override void Remove()
        {
            if (Name == "") IsUsed = false;
        }

        public override void Free()
        {
            foreach (var t in DuplicatedLocals)
            {
                Locals[t.Number] = t;
                Locals[t.Number].IsUsed = true;
            }
            IsUsed = false;
        }

        public static void InitGenerator(ILGenerator generator)
        {
            Generator = generator;
            Locals = new List<LocalObjectDef>();
        }

        public static LocalObjectDef GetLocalObjectDef(string name)
        {
            return Locals.FirstOrDefault(t => t.IsUsed && t.Name == name);
        }
    }
}
