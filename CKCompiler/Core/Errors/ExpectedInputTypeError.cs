using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CKCompiler.Core.Errors
{
    public class ExpectedInputTypeError : CompilerError
    {
        public ExpectedInputTypeError(IToken tokenExpr, Type expectedType)
        {
            Message = string.Format("Операция '{0}' имеет неверный тип (ожидался: '{1}')", tokenExpr.Text, expectedType.Name);
            OffendingToken = tokenExpr;
            FillDataFromToken();
        }
    }
}
