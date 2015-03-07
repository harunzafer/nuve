using System;
using System.Collections.Generic;
using System.Linq;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Gui
{

    class RootReplacer
    {
        public static String[] ReplaceRoots(string root, string[] words)
        {
            var turkish = Language.Turkish;
            var analyzer = new WordAnalyzer(turkish);
            var replacedWords = new List<string>();
            foreach (string word in words)
            {
                IEnumerable<Word> solutions = analyzer.Analyze(word, true, true);
                foreach (var solution in solutions)
                {
                    string output = solution.GetSurface();
                    solution.Root = turkish.GetRoots(root).First();
                    output += "\t" + solution.GetSurface();
                    replacedWords.Add(output);
                }
            }
            return replacedWords.ToArray();
        }
    }
}
