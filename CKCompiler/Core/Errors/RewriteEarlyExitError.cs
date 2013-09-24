namespace CKCompiler.Core.Errors
{
    public class RewriteEarlyExitError : CompilerError
    {
        private readonly string _msg;

        public RewriteEarlyExitError(string message, int number)
			: base(number, null, null, null)
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
            get { return CompilerErrorType.RewriteEarlyExitParser; }
        }
    }
}
