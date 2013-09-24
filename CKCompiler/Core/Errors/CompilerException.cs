using System;

namespace CKCompiler.Core.Errors
{
    public class CompilerException : Exception
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public new string Message { get; set; }

        public CompilerException(string message, int line, int column)
        {
            Message = message;
            Line = line;
            Column = column;
        }
    }
}
