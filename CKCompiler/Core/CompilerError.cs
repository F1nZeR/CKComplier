using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;

namespace CKCompiler.Core
{
    public class CompilerError
    {
        public int Column { get; set; }
        public int Line { get; set; }
        public string Message { get; set; }
        public RecognitionException RecognitionException { get; set; }
        public IToken OffendingToken { get; set; }
        public IRecognizer Recognizer { get; set; }
    }
}
