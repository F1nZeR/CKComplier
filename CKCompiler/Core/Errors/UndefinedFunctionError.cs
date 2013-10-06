using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CKCompiler.Core.Errors
{
    public class UndefinedFunctionError : CompilerError
    {
        public UndefinedFunctionError(IToken funcToken)
        {
            Message = string.Format("Функция '{0}' не объявлена.", funcToken.Text);
            OffendingToken = funcToken;
            FillDataFromToken();
        }
    }
}
