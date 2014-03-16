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
    class AnalysisHelper
    {

        public static void Analyze(WordAnalyzer analyzer, string[] words)
        {
            foreach (var test in words)
            {
                IList<Word> solutions = analyzer.Analyze(test);
                Console.WriteLine("\n{0} için {1} çözüm bulundu:", test, solutions.Count);
                foreach (var solution in solutions)
                {
                    Console.WriteLine("\t{0}\n", solution);
                }
            }
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
