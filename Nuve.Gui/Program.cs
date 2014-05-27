using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Gui
{
    static class Program
    {
        private static WordAnalyzer _analyzer = new WordAnalyzer(Language.Turkish);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        private static void Main()
        {
            //test();           
            IList<string> tokens = ReadWords("../../../../data/303.txt");
            AnalysisHelper.AnalyzeTokensToFile(_analyzer, tokens, "../../../../data/deneme.txt");
        }

        public static void test()
        {
            string[] testStrings = { "bakarım", "gitmem", "baharlık" };
            //string[] testStrings = SpecialCase.Şapkalı;
            Console.WriteLine(@"mısınız");

            try
            {
                AnalysisHelper.Analyze(_analyzer, testStrings);

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
            Stopwatch stopwatch = new Stopwatch();

            List<string> lines = File.ReadAllLines(@"C:\Users\hrzafer\Desktop\workspace\Damla\damla-solr-plugin\unigrams.txt").ToList();
            IList<string> stops = File.ReadAllLines(@"C:\Users\hrzafer\Desktop\workspace\Damla\damla-solr-plugin\stopwords.txt").ToList();

            stopwatch.Start();

            for (int i = lines.Count - 1; i > -1; i--)
            {
                string word = lines[i].Split('\t')[0];
                if (stops.Contains(word))
                {
                    lines.RemoveAt(i);
                    continue;
                }


                IList<Word> soluions = _analyzer.Analyze(word);
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
            Console.WriteLine(@"Time:" + stopwatch.ElapsedMilliseconds / 1000);
            lines.Sort();

            File.WriteAllLines(@"C:\Users\hrzafer\Desktop\workspace\Damla\damla-solr-plugin\nlpt_stemmer_cache_sorted.dict", lines);
        }
    }
}
