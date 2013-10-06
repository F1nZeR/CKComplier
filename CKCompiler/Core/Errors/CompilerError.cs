using Antlr4.Runtime;

namespace CKCompiler.Core.Errors
{
    public class CompilerError
    {
        public int Column { get; set; }
        public int Line { get; set; }
        public string Message { get; set; }
        public RecognitionException RecognitionException { get; set; }
        public IToken OffendingToken { get; set; }
        public IRecognizer Recognizer { get; set; }

        public CompilerError()
        {
        }

        protected void FillDataFromToken()
        {
            if (OffendingToken == null) return;
            Line = OffendingToken.Line;
            Column = OffendingToken.Column;
        }

        public CompilerError(string message, int? fromPos = null, int? toPos = null)
        {
            Message = message;
            
            if (fromPos.HasValue && toPos.HasValue)
            {
                OffendingToken = new CommonToken(null, 0, 0, fromPos.Value, toPos.Value);
            }
        }

        public CompilerError(string message, object token)
        {
            Message = message;
            OffendingToken = (IToken) token;
            FillDataFromToken();
        }
    }
}
