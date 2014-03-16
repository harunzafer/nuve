using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Nuve.Lang;

namespace Nuve.Gui
{
    class Benchmarker
    {
        const int Million = 1000000;

        public const string AMillionTokens = "../../Resources/aMillionTokens.txt";
        public const string AMillionWords = "../../Resources/aMillionWords.txt";


        

        public static void TestWithAMillionWords(WordAnalyzer analyzer)
        {
            string[] lines = File.ReadAllLines(AMillionWords, Encoding.UTF8);
            Stopwatch sw = Stopwatch.StartNew();
            Process(lines, analyzer);
            sw.Stop();
            Console.WriteLine("Time taken for a million different words: {0}ms", sw.Elapsed.TotalMilliseconds);
            GC.Collect();
        }

        public static void TestWithAMillionTokens(WordAnalyzer analyzer)
        {            
            string[] lines = File.ReadAllLines(AMillionTokens, Encoding.UTF8);
            Stopwatch sw = Stopwatch.StartNew();
            Process(lines, analyzer);
            sw.Stop();
            Console.WriteLine("Time taken for a million tokens: {0}ms", sw.Elapsed.TotalMilliseconds);
            GC.Collect();
        }

        private static void Process(string[] tokens, WordAnalyzer analyzer)
        {
            foreach (string token in tokens)
            {
                analyzer.Analyze(token);
            }
        }

        public static void TestMillionTimesWithSingleWord(string word, WordAnalyzer analyzer)
        {
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < Million; i++)
            {
                analyzer.Analyze(word);
            }
            sw.Stop();
            Console.WriteLine("Time taken for the word \"{0} \" is {1}ms", word, sw.Elapsed.TotalMilliseconds);
            GC.Collect();
        }       

      
     
    }
}
