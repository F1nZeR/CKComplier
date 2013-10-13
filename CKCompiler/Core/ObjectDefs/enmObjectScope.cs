using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKCompiler.Core.ObjectDefs
{
    public enum enmObjectScope
    {
        Value,
        Local,
        Argument,
        Field,
        ArrayElem
    }
}
