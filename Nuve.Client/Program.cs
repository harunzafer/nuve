using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuve.Client.Benchmark;
using Nuve.Lang;

namespace Nuve.Client
{
    public class Program
    {
        private static readonly Language Turkish = LanguageFactory.Create(LanguageType.Turkish);

        static void Main(string[] args)
        {
            //Benchmarker.TestWithAMillionTokens(Turkish.Analyze);
            //Benchmarker.TestWithAMillionWords(Turkish.Analyze);
            GitHubReadmeExamples();
        }   

        static void GitHubReadmeExamples()
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
            string analysis = "kitap/ISIM IC_COGUL_lAr IC_SAHIPLIK_BEN_(U)m";
            var word2 = tr.GetWord(analysis);

            Console.WriteLine(word1.GetSurface());
            Console.WriteLine(word2.GetSurface());
        }
    }
}
