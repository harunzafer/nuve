using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nuve.Lang;
using Nuve.Morphologic.Structure;
using Nuve.NGrams;
using Nuve.Reader;
using Nuve.Sentence;
using Nuve.Stemming;

namespace Nuve.Gui
{
    internal static class Program
    {
        private const string TaggedInput = @"C:\Users\hrzafer\Dropbox\nuve\corpus\tcSentencedNormalized.txt";
        private const string UntaggedInput = @"C:\Users\hrzafer\Dropbox\nuve\corpus\tcNormalized.txt";
        private static readonly WordAnalyzer Analyzer = new WordAnalyzer(Language.Turkish);

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Benchmarker.TestWithAMillionWords(Analyzer);
            //Benchmarker.TestWithAMillionTokens(Analyzer);

            //Language tr = Language.Turkish;

            ////Analysis
            //var analyzer = new WordAnalyzer(tr);

            ////Morphologic Analysis and stemming
            //IList<Word> solutions = analyzer.Analyze("deneme");

            //foreach (var solution in solutions)
            //{
            //    Console.WriteLine("\t{0}", solution);
            //    Console.WriteLine("\toriginal:{0} stem:{1}\n",
            //    solution.GetSurface(),
            //    solution.GetStem().GetSurface()); //Stemming
            //}

            ////Morphologic Generation
            //Root root = tr.GetRootsHavingSurface("kitap").First();

            //var word = new Word(root);
            //word.AddSuffix(tr.GetSuffix("IC_COGUL_lAr"));
            //word.AddSuffix(tr.GetSuffix("IC_SAHIPLIK_BEN_(U)m"));
            //word.AddSuffix(tr.GetSuffix("IC_HAL_BULUNMA_DA"));
            //word.AddSuffix(tr.GetSuffix("IC_AITLIK_ki"));
            //word.AddSuffix(tr.GetSuffix("IC_COGUL_lAr"));
            //word.AddSuffix(tr.GetSuffix("IC_HAL_AYRILMA_DAn"));

            //Console.WriteLine(word.GetSurface());
            
            
            //Test();
        
        }

        public static void AnaylzeWithCache(int cacheSize)
        {
            var lines = File.ReadAllLines(@"C:\Users\hrzafer\Desktop\workspace\hunspell-tr\data\archive\unigrams.txt",
                Encoding.UTF8);
            var tokens = lines.Select(x => x.Split('\t')[0]).ToArray();

            foreach (var token in tokens)
            {
                var sol = Analyzer.Analyze(token);
                if (sol.Count > 0)
                {
                    Cache.Add(token, sol);
                }
                else
                {
                    continue;
                }

                if (Cache.GetSize()%1000 == 0)
                {
                    Benchmarker.TestWithAMillionTokens(Analyzer);
                }

                if (Cache.GetSize() > 100000)
                {
                    break;
                }
            }
        }

        public static void GetProbabilities(string word)
        {
            var model = CreateModel();

            var solutions = Analyzer.Analyze(word);
            foreach (var solution in solutions)
            {
                //var ids = VARIABLE.GetMorphemeIds();
                var p1 = model.GetSentenceProbability(solution.GetMorphemeIds());
                Console.WriteLine(solution);
                Console.WriteLine("p1:{0}", p1);
            }
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

        public static void Test()
        {
            string[] testStrings =
            {
                "sanatkaranedir","kitaplaştıramadıklarımızdanmışçasına"                                
            };
            //string[] testStrings = SoruTest.Soru;
           AnalysisHelper.Analyze(Analyzer, testStrings);

                //string test = TestGenerator.GenerateContainsAnalysisTest(SpecialCase.Şapkalı, "Şapkalı");
                //string test = TestGenerator.GenerateContainsAnalysesTest(VerbAux.FiilimsiZarfArak, "FiilimsiZarfArak", "FIILIMSI_ZARF_(y)ArAk");
                //Console.WriteLine(test);

                //Benchmarker.TestWithAMillionTokens(analyzer);
                //Benchmarker.TestWithAMillionWords(analyzer);
                //Benchmarker.TestMillionTimesWithSingleWord("kitabımdakin", analyzer);    
          
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

        private static NGramModel CreateBetterModel(IStemmer stemmer)
        {
            var lines = File.ReadAllLines(@"C:\Users\hrzafer\Desktop\workspace\Damla\code\suggestion\unigrams.txt")
                .Select(x => x.Split(null));
            var nGramModel = new NGramModel(2);

            var counter = 0;

            foreach (var line in lines)
            {
                counter++;
                var solutions = Analyzer.Analyze(line[0]);
                foreach (var solution in solutions)
                {
                    if (solutions.Count == 1 || stemmer.GetStem(line[0]) == solution.GetStem().GetSurface())
                    {
                        var morphemeIds = solution.GetMorphemeIds();
                        var times = Math.Round((Int32.Parse(line[1]) + 99)/(double) 100);
                        for (var i = 0; i < times; i++)
                        {
                            nGramModel.AddSentence(morphemeIds);
                        }
                    }
                }

                if (counter%100 == 0)
                {
                    Console.WriteLine(counter);
                }
            }

            nGramModel.Deserialize(
                @"C:\Users\hrzafer\Desktop\workspace\Prizma\code\prizma\src\main\resources\stemDict\model_uni_bi.json");

            return nGramModel;
        }

        private static NGramModel CreateModel()
        {
            var lines = File.ReadAllLines(@"C:\Users\hrzafer\Desktop\workspace\Damla\code\suggestion\unigrams.txt")
                .Select(x => x.Split(null));
            var nGramModel = new NGramModel(2);

            var counter = 0;

            foreach (var line in lines)
            {
                counter++;
                var solutions = Analyzer.Analyze(line[0]);
                foreach (var solution in solutions)
                {
                    var morphemeIds = solution.GetMorphemeIds();
                    var times = Math.Round((Int32.Parse(line[1]) + 99)/(double) 100);
                    for (var i = 0; i < times; i++)
                    {
                        nGramModel.AddSentence(morphemeIds);
                    }
                }

                if (counter%100 == 0)
                {
                    Console.WriteLine(counter);
                }
            }

            nGramModel.Deserialize(
                @"C:\Users\hrzafer\Desktop\workspace\Prizma\code\prizma\src\main\resources\stemDict\model_uni_bi.json");

            return nGramModel;
        }

        private static IList<string> ReadWords(string filename)
        {
            var tokens = File.ReadAllText(filename, Encoding.UTF8).Split(null);
            return tokens.ToList();
        }
    }
}