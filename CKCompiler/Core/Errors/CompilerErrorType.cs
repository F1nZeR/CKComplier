namespace CKCompiler.Core.Errors
{
    public enum CompilerErrorType
    {
        EarleyExitLexer,
        MismatchedSetLexer,
        NoViableAltLexer,

        EarleyExitParser,
        MismatchedSetParser,
        NoViableAltParser,
        RecognitionParser,
        RewriteEarlyExitParser,
        UnexpectedToken,

        IncompatibleTypes,
        InvalidReturnType,
        ComparsionOperator,
        ArithmeticOperator,
        NegOperator,
        NotOperator,
        IsVoidChecking,
        IfOperator,
        WhileOperator,
        FunctionArguments,
        EntryPoint,
        UndefinedId,
        UndefinedFunction,
        UndefinedClass,

        Common,
        CommonLexer,
        CommonParser,
        FileInUse
    }
}