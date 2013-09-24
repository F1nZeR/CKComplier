namespace CKCompiler.Core.Errors
{
    public abstract class CompilerError
    {
        protected CompilerError(int number, int? line, int? columnStart, int? columnStop = null)
        {
            Number = number;
            Line = line;
            ColumnStart = columnStart;
            ColumnStop = !columnStop.HasValue ? columnStart : columnStop;
        }

        public int Number { get; protected set; }

        public int? Line { get; protected set; }

        public int? ColumnStart { get; protected set; }

        public int? ColumnStop { get; protected set; }

        public abstract string Description { get; }

        public abstract CompilerErrorStage Stage { get; }

        public abstract CompilerErrorType Type { get; }
    }
}
