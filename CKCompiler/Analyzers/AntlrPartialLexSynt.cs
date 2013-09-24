using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKCompiler.Analyzers
{
    public partial class CKLexer
    {
        private readonly List<Exception> _exceptions = new List<Exception>(); 
        public List<Exception> Exceptions { get { return _exceptions; }}

        public void DebugRecognitionException(Exception ex)
        {
            _exceptions.Add(ex);
        }
    }

    public partial class CKParser
    {
        private readonly List<Exception> _exceptions = new List<Exception>();
        public List<Exception> Exceptions { get { return _exceptions; } }

        public void DebugRecognitionException(Exception ex)
        {
            _exceptions.Add(ex);
        }
    }
}
