using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using CKCompiler.Analyzers;
using CKCompiler.Core.Errors;
using CKCompiler.Tokens;
using CKCompiler.Utils;

namespace CKCompiler.Core
{
    public class Compiler
    {
        public List<Token> Tokens { get; private set; }
        public AstParserRuleReturnScope<CommonTree, CommonToken> Tree { get; private set; }
        public List<CompilerError> Errors { get; private set; }
        public List<CompilerError> LexerErrors { get; private set; }
        public List<CompilerError> ParserErrors { get; private set; }
        public bool HasErrors { get { return Errors.Any(); }}

        public void Compile(string filename, string source)
        {
            // при обновлении lexer/parser надо дописывать под метод partial и комментить throw'ы, ну и добавлять break

            Tokens = new List<Token>();
            LexerErrors = new List<CompilerError>();
            ParserErrors = new List<CompilerError>();
            Errors = new List<CompilerError>();

            CKLexer lexer = null;

            // получаем токены
            try
            {
                var stream = new ANTLRStringStream(source);
                lexer = new CKLexer(stream, new RecognizerSharedState {errorRecovery = true});

                var token = lexer.NextToken();
                while (token.Type != CKLexer.EOF)
                {
                    Tokens.Add(new Token
                               {
                                   Name = LangTokens.TokenDictionary[token.Type],
                                   Value = StringUtils.ToLiteral(token.Text),
                                   Line = token.Line,
                                   Column = token.CharPositionInLine
                               });

                    token = lexer.NextToken();
                }

                lexer.Reset();
                lexer.Line = 0;
                lexer.CharPositionInLine = 0;

                HandleLexerErrors(lexer);
            }
            catch (Exception ex)
            {
                var error = new CommonLexerError(ex.Message, Errors.Count(), null, null);
                LexerErrors.Add(error);
                Errors.Add(error);
            }

            // мутим деревце
            try
            {
                var tokenStream = new CommonTokenStream(lexer);
                var parser = new CKParser(tokenStream);
                Tree = parser.program();

                HandleParserErrors(parser);
            }
            catch (Exception exception)
            {
                var error = new CommonParserError(exception.Message, Errors.Count(), null, null);
                Errors.Add(error);
                ParserErrors.Add(error);
            }

            //for (int i = 0; i < Tree.Tree.ChildCount; i++)
            //{
            //    var classNode = Tree.Tree.GetChild(i);
            //}
        }

        private void HandleLexerErrors(CKLexer lexer)
        {
            var exceptions = lexer.Exceptions;

            foreach (var curException in exceptions)
            {
                if (curException.GetType() == typeof (EarlyExitException))
                {
                    var exception = (EarlyExitException) curException;
                    var error = new EarlyExitErrorLexer(exception.Message,
                        Errors.Count(), exception.Line, exception.CharPositionInLine);
                    LexerErrors.Add(error);
                    Errors.Add(error);
                    continue;
                }

                if (curException.GetType() == typeof(MismatchedSetException))
                {
                    var exception = (MismatchedSetException)curException;
                    var error = new MismatchedSetErrorLexer(exception.Message,
                        Errors.Count(), exception.Line, exception.CharPositionInLine);
                    LexerErrors.Add(error);
                    Errors.Add(error);
                    continue;
                }

                if (curException.GetType() == typeof(NoViableAltException))
                {
                    var exception = (NoViableAltException)curException;

                    var error = new NoViableAltErrorLexer(exception.GrammarDecisionDescription, Errors.Count(),
                        exception.Line, exception.CharPositionInLine);
                    LexerErrors.Add(error);
                    Errors.Add(error);
                    continue;
                }

                if (curException.GetType() == typeof(CompilerException))
                {
                    var exception = (CompilerException)curException;
                    var error = new CommonLexerError(exception.Message, Errors.Count(), exception.Line, exception.Column);
                    LexerErrors.Add(error);
                    Errors.Add(error);
                    continue;
                }
            }
        }

        private void HandleParserErrors(CKParser parser)
        {
            var exceptions = parser.Exceptions;

            foreach (var curException in exceptions)
            {
                if (curException.GetType() == typeof (EarlyExitException))
                {
                    var exception = (EarlyExitException) curException;
                    var error = new EarlyExitErrorParser("Отсутствуют лексемы для построения синтаксического дерева",
                        Errors.Count(), exception.Line, exception.CharPositionInLine);
                    LexerErrors.Add(error);
                    Errors.Add(error);
                    continue;
                }

                if (curException.GetType() == typeof(MismatchedSetException))
                {
                    var exception = (MismatchedSetException)curException;
                    var tokenType = exception.Token.Type == CKParser.EOF
                        ? exception.Token.Text
                        : string.Format("{0} ({1})", exception.Token.Text,
                            LangTokens.TokenDictionary[exception.Token.Type]);

                    var error = new MismatchedSetErrorParser(
                        string.Format("Получен неверный токен: {0} - ожидался другой", tokenType), Errors.Count(),
                        exception.Line, exception.CharPositionInLine);
                    LexerErrors.Add(error);
                    Errors.Add(error);
                    continue;
                }

                if (curException.GetType() == typeof(NoViableAltException))
                {
                    var exception = (NoViableAltException)curException;
                    var tokenType = exception.Token.Type == CKParser.EOF
                        ? exception.Token.Text
                        : string.Format("{0} ({1})", exception.Token.Text,
                            LangTokens.TokenDictionary[exception.Token.Type]);

                    var error = new NoViableAltErrorParser(
                        string.Format("Получен неверный токен: {0} - ожидался другой", tokenType), Errors.Count(),
                        exception.Line, exception.CharPositionInLine);
                    LexerErrors.Add(error);
                    Errors.Add(error);
                    continue;
                }

                if (curException.GetType() == typeof(RecognitionException) || curException.GetType() == typeof(MismatchedTokenException))
                {
                    var exception = (RecognitionException)curException;
                    var tokenType = exception.Token.Type == CKParser.EOF
                        ? exception.Token.Text
                        : string.Format("{0} ({1})", exception.Token.Text,
                            LangTokens.TokenDictionary[exception.Token.Type]);

                    var error =
                        new RecognitionError(string.Format("Получен неверный токен: {0} - ожидался: {1}", tokenType,
                            LangTokens.TokenDictionary[((MismatchedTokenException) exception).Expecting]),
                            Errors.Count(), exception.Line, exception.CharPositionInLine);
                    LexerErrors.Add(error);
                    Errors.Add(error);
                    continue;
                }

                if (curException.GetType() == typeof(RewriteEarlyExitException))
                {
                    var exception = (RewriteEarlyExitException)curException;
                    var error = new RewriteEarlyExitError(exception.Message, Errors.Count());
                    LexerErrors.Add(error);
                    Errors.Add(error);
                    continue;
                }

                if (curException.GetType() == typeof(CompilerException))
                {
                    var exception = (CompilerException)curException;
                    var error = new CommonParserError(exception.Message, Errors.Count(), exception.Line,
                        exception.Column);
                    LexerErrors.Add(error);
                    Errors.Add(error);
                    continue;
                }
            }
        }
    }
}
