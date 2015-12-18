using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
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

            var language = new LanguageReader(@"C:\Users\harun_000\Dropbox\nuve\nuve-studio\lang\tr").Read();
            var analyzer = new WordAnalyzer(language);
            AnalysisHelper.Analyze(analyzer, new []{"bugünkü"});


            //Benchmarker.TestWithAMillionTokens(Analyzer);
            //Benchmarker.TestWithAMillionWords(Analyzer);

            //var keys = new[] {"keymey1", "keymey2", "keymey3", };

            //List<string> list = new List<string>(keys);
            //HashSet<string> set = new HashSet<string>(keys);

            //int times = 1000000;


            //Stopwatch sw = Stopwatch.StartNew();
            //for(int i=0; i<times; i++)
            //{
            //    list.Contains("keymey6");
            //}

            //sw.Stop();

            //Console.WriteLine("list: " + sw.ElapsedMilliseconds);

            //sw.Restart();

            //for (int i = 0; i < times; i++)
            //{
            //    set.Contains("keymey6");
            //}

            //sw.Stop();

            //Console.WriteLine("set: " + sw.ElapsedMilliseconds);


            //var lines = File.ReadAllLines(@"C:\Users\harun_000\Desktop\workspace\corpus\unigrams.txt",
            //    Encoding.UTF8);

            //List<string> resolved = new List<string>();
            //List<string> unresolved = new List<string>();

            //foreach (var line in lines)
            //{
            //    var token = line.Split(null)[0];
            //    var solutions = Analyzer.Analyze(token);
            //    if (solutions.Count == 0)
            //    {
            //        unresolved.Add(line);
            //    }
            //    else
            //    {
            //        resolved.Add(line);
            //    }
            //}


            //File.WriteAllLines(@"C:\Users\harun_000\Desktop\workspace\nuve_resolved", resolved, Encoding.UTF8);
            //File.WriteAllLines(@"C:\Users\harun_000\Desktop\workspace\nuve_unresolved", unresolved, Encoding.UTF8);


            //var nuve_resolved = File.ReadAllLines(@"C:\Users\harun_000\Desktop\workspace\nuve_resolved", Encoding.UTF8);
            //var zemberek_resolved = File.ReadAllLines(@"C:\Users\harun_000\Desktop\workspace\zemberek_resolved",
            //    Encoding.UTF8);


            //var onlyZemberek = zemberek_resolved.Except(nuve_resolved);
            //var onlyNuve = nuve_resolved.Except(zemberek_resolved);

            //File.WriteAllLines(@"C:\Users\harun_000\Desktop\workspace\onlyZemberek", onlyZemberek, Encoding.UTF8);
            //File.WriteAllLines(@"C:\Users\harun_000\Desktop\workspace\onlyNuve", onlyNuve, Encoding.UTF8);


            //File.WriteAllText(@"C:\Users\harun_000\Desktop\vboxshare\tokenized-paragraphs-with-punctuation.txt", Split(text), Encoding.UTF8);

            //File.WriteAllLines(@"C:\Users\harun_000\Desktop\vboxshare\sentences-no-punctuation-remove-empty-lines.txt", paragraphs.Select(p => Regex.Replace(p, "[^\\p{L}\\p{Nd}' ]", "")), Encoding.UTF8);


            //Benchmarker.TestWithAMillionWords(Analyzer);
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


            //var tr = Language.Turkish;
            //var root = tr.GetRootsHavingSurface("gel").First();
            //Word word = new Word(root);

            //if(!word.AddSuffix(tr.GetSuffix("IC_COGUL_lAr"), tr))
            //{
            //    Console.WriteLine("Adding the suffix IC_COGUL_lAr after a verb is not valid!");
            //    Console.WriteLine(word.GetSurface()); //prints just gel "gel"
            //}


            //Console.WriteLine(root);
            //Console.WriteLine(word);
            //Console.WriteLine(word.GetSurface());


            //Test();
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

        public static void AnaylzeWithCache(int cacheSize)
        {
            var lines =
                File.ReadAllLines(@"C:\Users\hrzafer\Desktop\workspace\hunspell-tr\data\archive\unigrams.txt",
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
               "bugünkü", "ben de", "o da", "kalem de", "kitap da", "orada da", "evde de",  "gelsen de",  "kalsam da",
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
            var lines = File.ReadAllLines(
                @"C:\Users\hrzafer\Desktop\workspace\Damla\code\suggestion\unigrams.txt")
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
                        var times = Math.Round((int.Parse(line[1]) + 99)/(double) 100);
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
            var lines = File.ReadAllLines(
                @"C:\Users\hrzafer\Desktop\workspace\Damla\code\suggestion\unigrams.txt")
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
                    var times = Math.Round((int.Parse(line[1]) + 99)/(double) 100);
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

        private class Unigram
        {
            public Unigram(string token, int freq)
            {
                Token = token;
                Freq = freq;
            }

            public int Freq { get; private set; }
            public string Token { get; private set; }

            public override string ToString()
            {
                return Token + '\t' + Freq;
            }
        }
    }
}