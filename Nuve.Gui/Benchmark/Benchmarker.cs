using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Gui
{
    internal class Benchmarker
    {
        private const int Million = 1000000;

        public const string AMillionTokens = "../../Resources/aMillionTokens.txt";
        public const string AMillionWords = "../../Resources/aMillionWords.txt";


        /// <summary>
        ///     Test the speed with a million different word types
        /// </summary>
        /// <param name="analyzer"></param>
        public static void TestWithAMillionWords(WordAnalyzer analyzer)
        {
            string[] lines = File.ReadAllLines(AMillionWords, Encoding.UTF8);
            Stopwatch sw = Stopwatch.StartNew();
            Process(lines, analyzer);
            sw.Stop();
            Console.WriteLine("Time taken for a million different words: {0} s", sw.Elapsed.TotalSeconds);
            GC.Collect();
        }

        /// <summary>
        ///     Test the speed with a million word corpus which includes same words many times
        /// </summary>
        /// <param name="analyzer"></param>
        public static void TestWithAMillionTokens(WordAnalyzer analyzer)
        {
            string[] lines = File.ReadAllLines(AMillionTokens, Encoding.UTF8);
            Stopwatch sw = Stopwatch.StartNew();
            Process(lines, analyzer);
            sw.Stop();
            Console.WriteLine("For a million tokens\tcache: {0}\ttime: {1} s\tmemory: {2}", Cache.GetSize(),
                sw.Elapsed.TotalSeconds, GC.GetTotalMemory(false)/1024);
            GC.Collect();
        }


        private static void Process(IEnumerable<string> tokens, WordAnalyzer analyzer)
        {
            foreach (string token in tokens)
            {
                IList<Word> sol;
                if (!Cache.TryAnalyze(token, out sol))
                {
                    analyzer.Analyze(token);
                }
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