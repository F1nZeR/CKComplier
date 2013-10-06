using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CKCompiler.Core.Errors
{
    public class UndefinedIdError : CompilerError
    {
        public UndefinedIdError(IToken idToken)
        {
            Message = string.Format("Неизвестный идентификатор '{0}'.", idToken.Text);
            OffendingToken = idToken;
            FillDataFromToken();
        }
    }
}
