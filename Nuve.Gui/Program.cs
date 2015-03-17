using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nuve.Lang;
using Nuve.NGrams;
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
            //var lines = File.ReadAllLines(@"C:\Users\hrzafer\Dropbox\nuve\corpus\tcExtra.txt");
            //var splitter = new RegexTokenizerBase(RegexTokenizerBase.Pattern);

            //var tokens = new List<string>();
            //foreach (var line in lines)
            //{
            //    tokens.AddRange(splitter.Split(line));
            //}


            //var sb = new StringBuilder();
            //foreach (var token in tokens)
            //{
            //    if (token == " " || token=="")
            //    {
            //        continue;
            //    }
            //    var solutions = Analyzer.Analyze(token).ToList();
            //    if (token != token.ToLower())
            //    {
            //        solutions.AddRange(Analyzer.Analyze(token.ToLower()));
            //    }

            //    sb.Append(token).Append('\n');
            //    foreach (var solution in solutions)
            //    {
            //        sb.Append('\t').Append(solution).Append('\n');
            //    }
            //    sb.Append('\n');

            //}

            //File.WriteAllText(@"C:\Users\hrzafer\Dropbox\nuve\corpus\tcExtraTagged.txt", sb.ToString());

            //Benchmarker.TestWithAMillionWords(Analyzer);

            //File.WriteAllLines(@"C:\Users\hrzafer\Dropbox\nuve\corpus\tcNormalizedTokenized.txt", tokens);
            //var test = TestGenerator.GenerateContainsAnalysisTest(SpecialCase.ZamirSoruNe, "ZamirSoruNeTest");
            //Console.WriteLine(test);
            //Test();

            //Benchmarker.TestWithAMillionWords(Analyzer);
            //Benchmarker.TestWithAMillionTokens(Analyzer);

            //AnaylzeWithCache(0);


            //TokenizerBenchmark.TestWithAMillionWords(new WhitespaceTokenizer(false));

            //var splitter = new RegexTokenizerBase(RegexTokenizerBase.Pattern);
            //splitter.Split("bu bir, denemedir harun@gmail.com! !");

            //string pattern = @"(\s+)|(\d+)|(\w+)";
            //string input = "He said that 123 was 321 the 123abc answer.";
            //var matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);
            //foreach (Match match in matches)
            //{
            //    Console.WriteLine("Group-0: '{0}' group-1: '{1}' group-2 '{2}'",
            //                      match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
            //    Console.WriteLine(match.Groups);


            //}


            Test();
            //var solutions = Analyzer.Analyze("bunu");
            //foreach (var solution in solutions)
            //{
            //    Console.WriteLine(solution.GetHashCode());
            //}


            //var deserializedProduct = JsonConvert.DeserializeObject<NGramDictionary>(output);

            ////var model = CreateModel();

            //var model = new NGramModel(2, @"C:\Users\hrzafer\Desktop\workspace\Prizma\code\prizma\src\main\resources\stemDict\model_uni_bi.json");

            //IStemmer stemmer = new DictionaryStemmer();
            ////var betterModel = CreateBetterModel(stemmer);
            //var betterModel = new NGramModel(2, @"C:\Users\hrzafer\Desktop\workspace\Prizma\code\prizma\src\main\resources\stemDict\model_uni_bi.json");

            //IStemmer betterStemmer = new StatisticalStemmer(betterModel, Analyzer);

            ////Console.WriteLine(stemmer.GetStem("araştırmalardı"));
            ////Console.WriteLine(stemmer.GetStem("annesiydi"));

            //StemmerEvaluator.Evaluate(stemmer, @"C:\Users\hrzafer\Dropbox\nuve\data\expected_stems.txt");

            //StemmerEvaluator.Evaluate(betterStemmer, @"C:\Users\hrzafer\Dropbox\nuve\data\expected_stems.txt");


            //var words = File.ReadAllLines(@"C:\Users\hrzafer\Desktop\workspace\Damla\code\suggestion\unigrams.txt")
            //    .Select(x => x.Split(null)[0]);
            //var output = @"C:\Users\hrzafer\Desktop\workspace\Prizma\code\prizma\src\main\resources\stemDict\nuve_stems2.dict";

            //StemDictionaryGenerator.Generate(words, betterStemmer, output);

            //StemFirst500();

            //GetProbabilities("kitaplar");

            //var extractor = new NGramExtractor(NGramSize.Trigram);
            //var tokens = File.ReadAllText(@"C:\Users\hrzafer\Dropbox\nuve\corpus\tcNormalized.txt").Split(null).ToList();
            //tokens.RemoveAll(x => x.Length == 0);
            //var map = extractor.ExtractAsDictionary(tokens);
            //ToSortedFile(map, @"C:\Users\hrzafer\Dropbox\nuve\corpus\bigrams.txt");
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
                "sanatkaranedir"                                
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