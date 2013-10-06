using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CKCompiler.Core.Errors
{
    public class OperationTypeError : CompilerError
    {
        public OperationTypeError(IToken compareToken, Type lefType, Type rightType)
        {
            Message = string.Format("Невозможно применить операцию '{0}' над '{1}' и '{2}'", compareToken.Text, lefType.Name, rightType.Name);
            OffendingToken = compareToken;
            FillDataFromToken();
        }
    }
}
