using System;
using System.Linq;
using Nuve.Lang;
using Nuve.Reader;
using Nuve.Sentence;
using Nuve.Tokenizers;

namespace Nuve.Client
{
    public class Program
    {
        private static readonly Language Turkish = LanguageFactory.Create(LanguageType.Turkish);

        private static void Main(string[] args)
        {
            //Benchmarker.TestWithAMillionTokens(Turkish.Analyze);
            //Benchmarker.TestWithAMillionWords(Turkish.Analyze);

            //GitHubReadmeExamples();

            AnalysisHelper.Analyze(Turkish, new[] { "su", "eşkâli" });

            //Generation();

            //AnalysisAndStemming();

            //SentenceSegmentation();

            //ExternalLanguageReading();
        }


        private static void GitHubReadmeExamples()
        {
            var tr = LanguageFactory.Create(LanguageType.Turkish);
            var solutions = tr.Analyze("yolsuzu");

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
                "IC_HAL_BULUNMA_DA", "IC_AITLIK_ki", "IC_COGUL_lAr", "IC_HAL_AYRILMA_DAn");

            //Method 2: Specify the string representation of the analysis of the word.
            var analysis = "kitap/ISIM IC_COGUL_lAr IC_SAHIPLIK_BEN_(U)m";
            var word2 = tr.GetWord(analysis);

            Console.WriteLine(word1.GetSurface());
            Console.WriteLine(word2.GetSurface());
        }

        private static void AnalysisAndStemming()
        {
            var tr = LanguageFactory.Create(LanguageType.Turkish);
            var stems = tr.Analyze("ehemmiyetsiz").Select(s=> s.Root.LexicalForm).ToList();

            foreach (var stem in stems)
            {
                Console.WriteLine("\t{0}", stem);
            }

        }

        private static void Generation()
        {
            var tr = LanguageFactory.Create(LanguageType.Turkish);
            var solutions = tr.Analyze("suyu");       
            var surfaces = solutions[0].GetSurfacesAfterEachPhase();
            foreach(var surface in surfaces)
            {
                Console.WriteLine(surface);
            }
        }

        private static void ExternalLanguageReading()
        {
            var tr = new LanguageReader(@"C:\Users\harun_000\Dropbox\nuve\nuve-studio\lang\tr-TR").Read();
            var solutions = tr.Analyze("yolsuzu");
            Console.WriteLine(tr.Type.CultureCode);

            foreach (var solution in solutions)
            {
                Console.WriteLine("\t{0}", solution);
                Console.WriteLine("\toriginal:{0} stem:{1} root:{2}\n",
                    solution.GetSurface(),
                    solution.GetStem().GetSurface(),
                    solution.Root); //Stemming
            }
        }

        private static void SentenceSegmentation()
        {
            var paragraph = "Prof. Dr. Ahmet Bey 1.6 oranında artış var dedi 2. kez. E-posta adresi ahmet.bilir@prof.dr imiş! Doğru mu?";
            ITokenizer tokenizer = new ClassicTokenizer(true);
            SentenceSegmenter segmenter = new TokenBasedSentenceSegmenter(tokenizer);
            var sentences = segmenter.GetSentences(paragraph);
            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }
        }
    }
}