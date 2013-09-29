using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CKCompiler.Core.ObjectDefs
{
    public class MethodDef
    {
        public string Name;
        public MethodBuilder MethodBuilder;
        public Dictionary<string, ArgObjectDef> Args;

        public MethodDef(string name, Dictionary<string, ArgObjectDef> args, MethodBuilder methodBuilder)
        {
            Name = name;
            Args = args;
            MethodBuilder = methodBuilder;
        }
    }
}
