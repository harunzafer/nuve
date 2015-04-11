using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Gui
{
    internal class AnalysisHelper
    {
        public static void Analyze(WordAnalyzer analyzer, IEnumerable<string> words)
        {
            foreach (string test in words)
            {
                IList<Word> solutions = analyzer.Analyze(test);
                Console.WriteLine("\n{0} için {1} çözüm bulundu:", test, solutions.Count);
                foreach (Word solution in solutions)
                {
                    Console.WriteLine("\t{0}\n", solution);
                }
            }
        }

        public static void AnalyzeTokensToFile(WordAnalyzer analyzer, IEnumerable<string> words,
            string undefinedOutputFilename)
        {
            IList<string> lines = new List<string>();
            foreach (string word in words)
            {
                string line = word;
                IList<Word> solutions = analyzer.Analyze(word);
                foreach (Word solution in solutions)
                {
                    line += "\t" + solution;
                }
                lines.Add(line);
            }
            File.WriteAllLines(undefinedOutputFilename, lines);
        }

        public static void Analyze(WordAnalyzer analyzer, string inputFilename, string undefinedOutputFilename)
        {
            IList<string> undefined = new List<string>();
            string[] lines = File.ReadAllLines(inputFilename, Encoding.UTF8);
            foreach (string line in lines)
            {
                IList<Word> solutions = analyzer.Analyze(line);
                if (!solutions.Any())
                {
                    undefined.Add(line);
                }
            }
            File.WriteAllLines(undefinedOutputFilename, undefined);
        }

        public static string[] Tokenize(string filename)
        {
            string text = File.ReadAllText(filename, Encoding.UTF8);
            string[] tokens = Regex.Split(text, @"\W+");
            return tokens;
        }
    }
}