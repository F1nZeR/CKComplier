namespace CKCompiler.Tokens
{
    public class Token
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }
}
