using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Nuve.Lang;
using Nuve.Sentence;

namespace Nuve.Gui
{
    internal static class Program
    {
        private const string TaggedInput = @"C:\Users\hrzafer\Dropbox\nuve\corpus\tcSentencedNormalized.txt";
        private const string UntaggedInput = @"C:\Users\hrzafer\Dropbox\nuve\corpus\tcNormalized.txt";
        private static readonly Language Turkish = LanguageFactory.Create(LanguageType.Turkish);

        [Conditional("TRACE")]
        public static void Msg(string msg)
        {
            Console.WriteLine(msg);
        }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var tr = LanguageFactory.Create(LanguageType.Turkish);
            var solutions = tr.Analyze("yolsuzu");

            //Benchmarker.TestWithAMillionTokens(Analyzer);
            //Benchmarker.TestWithAMillionWords(Analyzer);

            foreach (var solution in solutions)
            {
                Console.WriteLine("\t{0}", solution);
                Console.WriteLine("\toriginal:{0} stem:{1} root:{2}\n",
                    solution.GetSurface(),
                    solution.GetStem().GetSurface(),
                    solution.Root); //Stemming
            }

            //Method 1: Specify the ids of the morphemes that constitute the word
            var word1 = tr.Generate("kitap/ISIM", "IC_COGUL_lAr", "IC_SAHIPLIK_BEN_(U)m",
                "IC_HAL_BULUNMA_DA","IC_AITLIK_ki", "IC_COGUL_lAr", "IC_HAL_AYRILMA_DAn");

            //Method 2: Specify the string representation of the analysis of the word.
            string analysis = "kitap/ISIM IC_COGUL_lAr IC_SAHIPLIK_BEN_(U)m";
            var word2 = tr.GetWord(analysis);

            Console.WriteLine(word1.GetSurface());
            Console.WriteLine(word2.GetSurface());


            //Test();
        }

        public static void Test()
        {
            string[] testStrings =
            {
                "gel", "gitmem", "a", "demem"
            };

            AnalysisHelper.Analyze(Turkish, testStrings);

            //string test = TestGenerator.GenerateContainsAnalysisTest(SpecialCase.Şapkalı, "Şapkalı");
            //string test = TestGenerator.GenerateContainsAnalysesTest(VerbAux.FiilimsiZarfArak, "FiilimsiZarfArak", "FIILIMSI_ZARF_(y)ArAk");
            //Console.WriteLine(test);
        }

        public static string Split(string str)
        {
            var sb = new StringBuilder(str);
            Console.WriteLine(sb.Capacity);
            Console.WriteLine(sb.MaxCapacity);
            for (var i = 1; i < sb.Length; i += 2)
            {
                if (sb[i] == '\n' || sb[i] == '\r')
                {
                    continue;
                }

                if (char.IsWhiteSpace(sb[i]))
                {
                    sb[i] = '_';
                }

                sb.Insert(i, ' ');

                Console.WriteLine(i);
                Console.WriteLine(sb.Length);
            }

            return sb.ToString();
        }


        public static void ToSortedFile(IDictionary<string, int> map, string path)
        {
            var list = map.ToList();
            list.Sort((first, next) => next.Value.CompareTo(first.Value));
            var text = list.Select(x => x.Key + "\t" + x.Value);
            File.WriteAllLines(path, text);
        }

        public static void EvaluateSbd(SentenceSegmenter segmenter)
        {
            var taggedParagraphs = File.ReadAllLines(TaggedInput);
            var evaluations = segmenter.Evaluate(taggedParagraphs);
            SentenceSegmenterEvaluator.GetTotalReport(evaluations, printFalseAlarms: true);
        }

        public static void PrintSentences(SentenceSegmenter segmenter, IEnumerable<string> paragraphs)
        {
            foreach (var paragraph in paragraphs)
            {
                PrintSentences(segmenter, paragraph);
            }
        }

        public static void PrintSentences(SentenceSegmenter segmenter, string paragraph)
        {
            var sentences = segmenter.GetSentences(paragraph);
            foreach (var sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }


        private static void StemFirst500()
        {
            var words =
                File.ReadAllLines(@"C:\Users\hrzafer\Desktop\workspace\Damla\code\suggestion\unigrams.txt")
                    //.Select(x => x.Split(null)[0])
                    .Where(x => x.StartsWith("kale"))
                    .ToArray();
            //var lines = new List<string>();


            //for (int i = 0; i < 1500; i++)
            //{
            //    var solutions = Analyzer.Analyze(words[i]);
            //    if (solutions.Count > 1)
            //    {
            //        var sb = new StringBuilder(words[i]).Append("\n");

            //        foreach (var sol in solutions)
            //        {
            //            sb.Append("\t").Append(sol.GetStem()).Append("\n");
            //        }
            //        lines.Add(sb.ToString());
            //    }
            //}

            File.WriteAllLines(@"C:\Users\hrzafer\Desktop\workspace\Damla\code\suggestion\kalem_stems.txt", words);
        }
    }
}