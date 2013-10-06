using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CKCompiler.Core.Errors
{
    public class UndefinedClassError : CompilerError
    {
        public UndefinedClassError(IToken classToken)
        {
            Message = string.Format("Класс '{0}' не определён.", classToken.Text);
            OffendingToken = classToken;
            FillDataFromToken();
        }
    }
}
