using System.Collections.Generic;
using System.IO;

namespace CKCompiler.Tokens
{
    public class LangTokens
    {
        public static Dictionary<int, string> TokenDictionary { get; set; }

        public static void Load(string filename)
        {
            var lines = File.ReadAllLines(filename);
            TokenDictionary = new Dictionary<int, string>(lines.Length);

            foreach (var line in lines)
            {
                var spl = line.Split('=');
                if (!TokenDictionary.ContainsKey(int.Parse(spl[1])))
                {
                    TokenDictionary.Add(int.Parse(spl[1]), spl[0].Trim());
                }
            }
        }
    }
}
