using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Nuve.Lang;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Sentence;
using Nuve.Tokenizers;
using Splitter = Nuve.Tokenizers.Splitter;

namespace Nuve.Gui
{
    internal static class Program
    {
        //private static readonly WordAnalyzer Analyzer = new WordAnalyzer(Language.Turkish);
        const string TaggedInput = @"C:\Users\hrzafer\Dropbox\nuve\corpus\tcSentencedNormalized.txt";
        const string UntaggedInput = @"C:\Users\hrzafer\Dropbox\nuve\corpus\tcNormalized.txt";


        private static readonly WordAnalyzer Analyzer = null;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {

            Language tr = Language.Turkish;

            //Analysis
            var analyzer = new WordAnalyzer(tr);

            IList<Word> solutions = analyzer.Analyze("deneme");

            foreach (var solution in solutions)
            {
                Console.WriteLine("\t{0}\n", solution);
                Console.WriteLine("\toriginal:{0} stem:{1}\n", solution.GetSurface(), solution.GetStem().GetSurface());
            }

            //Splitter splitter = new RegexSplitter(RegexSplitter.ClassicPattern);
            //var segmenter = new TokenBasedSentenceSegmenter(splitter);
            //EvaluateSbd(segmenter);
            //var untaggedParagraphs = File.ReadAllLines(UntaggedInput);
            //PrintSentences(segmenter, "alıntı kelimelerdir.[7] Türk yazı dilleri için");
            //PrintSentences(segmenter, "yola devam edeceğim\" dedi. Tecrübeli hocanın");

        }

        public static void EvaluateSbd(SentenceSegmenter segmenter)
        {            
            var taggedParagraphs = File.ReadAllLines(TaggedInput);
            var evaluations = segmenter.Evaluate(taggedParagraphs);
            SentenceSegmenterEvaluator.GetTotalReport(evaluations,printFalseAlarms:true);
        }

        public static void PrintSentences(SentenceSegmenter segmenter, IEnumerable<string> paragraphs)
        {
            foreach (string paragraph in paragraphs)
            {
                PrintSentences(segmenter, paragraph);
            }
        }

        public static void PrintSentences(SentenceSegmenter segmenter, string paragraph)
        {
            var sentences = segmenter.GetSentences(paragraph);
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }


        public static void test()
        {
            string[] testStrings = {"bakarım", "gitmem", "baharlık"};
            //string[] testStrings = SpecialCase.Şapkalı;
            Console.WriteLine(@"mısınız");

            try
            {
                AnalysisHelper.Analyze(Analyzer, testStrings);

                //string test = TestGenerator.GenerateContainsAnalysisTest(SpecialCase.Şapkalı, "Şapkalı");
                //string test = TestGenerator.GenerateContainsAnalysesTest(VerbAux.FiilimsiZarfArak, "FiilimsiZarfArak", "FIILIMSI_ZARF_(y)ArAk");
                //Console.WriteLine(test);

                //Benchmarker.TestWithAMillionTokens(analyzer);
                //Benchmarker.TestWithAMillionWords(analyzer);
                //Benchmarker.TestMillionTimesWithSingleWord("kitabımdakin", analyzer);    
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.InnerException.ToString());
            }
        }

        private static IList<string> ReadWords(string filename)
        {
            string[] tokens = File.ReadAllText(filename, Encoding.UTF8).Split(null);
            return tokens.ToList();
        }

        public static void createStemDict()
        {
            var stopwatch = new Stopwatch();

            List<string> lines =
                File.ReadAllLines(@"C:\Users\hrzafer\Desktop\workspace\Damla\damla-solr-plugin\unigrams.txt").ToList();
            IList<string> stops =
                File.ReadAllLines(@"C:\Users\hrzafer\Desktop\workspace\Damla\damla-solr-plugin\stopwords.txt").ToList();

            stopwatch.Start();

            for (int i = lines.Count - 1; i > -1; i--)
            {
                string word = lines[i].Split('\t')[0];
                if (stops.Contains(word))
                {
                    lines.RemoveAt(i);
                    continue;
                }


                IList<Word> soluions = Analyzer.Analyze(word);
                if (soluions.Count == 0)
                {
                    lines.RemoveAt(i);
                    continue;
                }

                int index = 0;
                for (int j = 0; j < soluions.Count; j++)
                {
                    if (soluions[j].HasSuffix("IC_COGUL_lAr"))
                    {
                        index = j;
                        break;
                    }
                }

                if (soluions[index].GetStem().GetSurface() == word)
                {
                    lines.RemoveAt(i);
                    continue;
                }

                lines[i] = word + "\t" + soluions[index].GetStem().GetSurface();
            }

            stopwatch.Stop();
            Console.WriteLine(@"Time:" + stopwatch.ElapsedMilliseconds/1000);
            lines.Sort();

            File.WriteAllLines(
                @"C:\Users\hrzafer\Desktop\workspace\Damla\damla-solr-plugin\nlpt_stemmer_cache_sorted.dict", lines);
        }
    }
}