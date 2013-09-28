using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using CKCompiler.Core;

namespace CKCompiler.Analyzers
{
    public class ErrorListener : IAntlrErrorListener<IToken>
    {
        public List<CompilerError> Errors { get; private set; }

        public ErrorListener()
        {
            Errors = new List<CompilerError>();
        }

        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            Errors.Add(new CompilerError
                       {
                           Column = charPositionInLine,
                           Line = line,
                           Message = msg.Trim(),
                           OffendingToken = offendingSymbol,
                           RecognitionException = e,
                           Recognizer = recognizer
                       });
        }
    }
}
