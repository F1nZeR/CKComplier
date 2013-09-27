using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;

namespace CKCompiler.Analyzers
{
    public partial class CKLexer
    {
        private readonly List<Exception> _exceptions = new List<Exception>(); 
        public List<Exception> Exceptions { get { return _exceptions; }}

        public void DebugRecognitionException(Exception ex)
        {
            if (!_exceptions.Contains(ex)) _exceptions.Add(ex);
        }
    }

    public partial class CKParser
    {
        private readonly List<Exception> _exceptions = new List<Exception>();
        public List<Exception> Exceptions { get { return _exceptions; } }

        public void DebugRecognitionException(Exception ex)
        {
            if (!_exceptions.Contains(ex)) _exceptions.Add(ex);
        }

        protected override object RecoverFromMismatchedToken(IIntStream input, int ttype, BitSet follow)
        {
            var mte = new MismatchedTokenException(ttype, input);
            throw mte;
        }

        public override void Recover(IIntStream input, RecognitionException re)
        {
            throw new Exception();
        }

        public override void ReportError(RecognitionException e)
        {
            throw new Exception();
        }

        public RecognizerSharedState State;
    }
}
