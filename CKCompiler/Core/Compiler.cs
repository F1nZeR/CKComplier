using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CKCompiler.Analyzers;
using CKCompiler.Tokens;
using CKCompiler.Utils;

namespace CKCompiler.Core
{
    public class Compiler
    {
        public List<Token> Tokens { get; private set; }
        public IParseTree ProgramContext { get; private set; }
        public List<CompilerError> Errors { get; private set; }
        public bool HasErrors { get { return Errors.Any(); }}

        public void Compile(string filename, string source)
        {
            var inputStream = new AntlrInputStream(source);
            var ckLexer = new CKLexer(inputStream);
            
            var commonTokenStream = new CommonTokenStream(ckLexer);
            var ckParser = new CKParser(commonTokenStream);
            ckParser.RemoveErrorListeners();
            var myErrorListener = new ErrorListener();
            ckParser.AddErrorListener(myErrorListener);
            ProgramContext = ckParser.program();
            

            HandleTokens(commonTokenStream);
            Errors = myErrorListener.Errors;
        }

        private void HandleTokens(BufferedTokenStream commonTokenStream)
        {
            Tokens = new List<Token>();

            foreach (var token in commonTokenStream.GetTokens())
            {
                Tokens.Add(new Token
                           {
                               Column = token.Column,
                               Line = token.Line,
                               Name = LangTokens.TokenDictionary[token.Type],
                               Value = token.Text
                           });
            }
        }

        public void GenerateCode()
        {
            if (ProgramContext == null || HasErrors) return;

            var codegen = new CodeGen(ProgramContext, "lalka");
            codegen.Generate();
        }
    }
}
