namespace CKCompiler.Core.Errors
{
    public class CommonParserError : CompilerError
    {
        private readonly string _msg;

        public CommonParserError(string message, int number, int? line, int? columnStart, int? columnStop = null)
			: base(number, line, columnStart, columnStop)
        {
            _msg = message;
        }

        public override string Description
        {
            get { return _msg; }
        }

        public override CompilerErrorStage Stage
        {
            get { return CompilerErrorStage.Syntax; }
        }

        public override CompilerErrorType Type
        {
            get { return CompilerErrorType.CommonParser; }
        }
    }
}
