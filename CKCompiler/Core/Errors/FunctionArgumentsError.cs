using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace CKCompiler.Core.Errors
{
    public class FunctionArgumentsError : CompilerError
    {
        public FunctionArgumentsError(IToken funcToken, List<Type> types)
        {
            var result = new StringBuilder("Неверные аргументы в вызове функции ");
            result.Append(funcToken.Text + "(");
            for (int i = 1; i < types.Count; i++)
                result.Append(types[i].Name + ", ");
            result.Remove(result.Length - 2, 2);
            result.Append(")");
            Message = result.ToString();

            OffendingToken = funcToken;
            FillDataFromToken();
        }
    }
}
