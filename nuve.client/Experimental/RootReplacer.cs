using System.Collections.Generic;
using System.Linq;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Client.Experimental
{
    internal class RootReplacer
    {
        public static string[] ReplaceRoots(string root, string[] words)
        {
            Language turkish = LanguageFactory.Create(LanguageType.Turkish);
            
            var replacedWords = new List<string>();
            foreach (string word in words)
            {
                IEnumerable<Word> solutions = turkish.Analyze(word);
                foreach (Word solution in solutions)
                {
                    string output = solution.GetSurface();
                    solution.Root = turkish.GetRootsHavingSurface(root).First();
                    output += "\t" + solution.GetSurface();
                    replacedWords.Add(output);
                }
            }
            return replacedWords.ToArray();
        }
    }
}