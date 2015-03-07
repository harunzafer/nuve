using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Nuve.Lang;
using Nuve.Morphologic.Structure;
using Nuve.Reader;

namespace Nuve.Test.Analysis
{
    internal class Tester
    {
        //private const string DirPath = @"C:\Users\hrzafer\Desktop\tr";
        //static readonly Language Language = LanguageReader.ReadExternal(DirPath);
        //static readonly WordAnalyzer Analyzer = new WordAnalyzer(Language);
        static readonly WordAnalyzer Analyzer = new WordAnalyzer(Language.Turkish);

        /// <summary>
        /// Bir kelimenin çözümleri içerisinde aranan çözümün bir ve yalnız bir adet
        /// bulunup bulunmadığını kontrol eder. 
        /// </summary>
        /// <param name="token">kelime</param>
        /// <param name="expectedAnalysis">aranan çözüm</param>
        public static void ContainsAnalysis(string token, string expectedAnalysis)
        {
           ContainsAnalyses(token, new string[] { expectedAnalysis } );
        }

        /// <summary>
        /// Aranan çözümlerin hepsinin kelimenin çözümleri içerisinde bir ve yalnız bir adet mevcut olup olmadığına
        /// bakar. Mesela aranan çözümler {a,b}, kelimenin çözümleri {a,b,c} olsun test başarılıdır.
        /// aranan çözümler {a,b}, kelimenin çözümleri {a,c,d} olsun test başarısızdır.
        /// Aranan çözümler {a,b}, kelimenin çözümleri {a,a,b} ise test başarısızdır.
        /// Aranan çözüm tek ise {a} ContainsAnalysis metodu ile aynı çıktıyı üretir.
        /// Aranan çözümlerin hangi sırada verildiği önemli değildir.
        /// </summary>
        /// <param name="token">kelime</param>
        /// <param name="expectedAnalyses">aranan çözümler</param>
        public static void ContainsAnalyses(string token, string[] expectedAnalyses)
        {            
            IList<Word> words = Analyzer.Analyze(token);
            foreach (string expectedAnalysis in expectedAnalyses)
            {
                int matchingAnalysisCount = words.Count(w => w.Analysis == expectedAnalysis);
                Assert.AreEqual(1, matchingAnalysisCount);
            }
        }

        /// <summary>
        /// Bir kelimenin çözümleri ile aranan çözümlerin aynı sayıda ve bire bir aynı
        /// olup olmadığını kontrol eder. Aranan çözümlerin hangi sırada verildiği önemli değildir.
        /// </summary>
        /// <param name="token">kelime</param>
        /// <param name="expectedAnalyses">aranan ve olması gereken çözümlerin tamamı</param>
        public static void AllAnalysesEqual(string token, IList<string> expectedAnalyses)
        {            
            IList<Word> words = Analyzer.Analyze(token);
            IList<string> actualAnalyses = words.Select(word => word.Analysis).ToList();
            bool equalIgnoreOrder = actualAnalyses.OrderBy(t => t).SequenceEqual(expectedAnalyses.OrderBy(t => t));
            Assert.True(equalIgnoreOrder);
        }

        /// <summary>
        /// Bir kelimenin hiç çözümünün olmamasını test eder. 
        /// Çözümlenememesi gereken kelimeler için kullanılır.
        /// </summary>
        /// <param name="token">kelime</param>
        public static void HasNoAnalysis(string token)
        {
            IList<Word> solutions = Analyzer.Analyze(token);
            Assert.AreEqual(0, solutions.Count);
        }


        /// <summary>
        /// Bir kelimeye ait çözümler içerisinde belirli bir çözümün olmadığını test eder.
        /// Mesela "benin" kelimesinin "ben/ZAMIR_SAHIS_BEN nUn/IC_HAL_ILGI_(n)Un" gibi bir çözümü olmamalı.
        /// Ancak "ben/ISIM nUn/IC_HAL_ILGI_(n)Un" çözümü vardır. Metodun rootOfAnalysis parametresi "ben/ZAMIR_SAHIS_BEN"
        /// değeri alırsa bu kelimenin "ben" zamir kökü ile başlayan her hangi bir çözümünün olmadığı test edilir.
        /// </summary>
        /// <param name="token">kelime</param>
        /// <param name="rootOfAnalysis">Olmaması gereken çözümün kökü</param>
        //[Test]
        public static void AnalysisNotExist(string token, string rootOfAnalysis)
        {

            IList<Word> words = Analyzer.Analyze(token);

            int matchingAnalysisCount = words.Count(w => w.Analysis.StartsWith(rootOfAnalysis) );

            Assert.AreEqual(0, matchingAnalysisCount);
        }

        // Bu metod yakında kaldırılacak
        public static void TestAnalyses(string token, int count, string[] analyses, bool fullAnalysis = false)
        {

            IList<Word> solutions = Analyzer.Analyze(token, true, true);
            if (fullAnalysis)
            {
                Assert.AreEqual(count, solutions.Count);
                for (int i = 0; i < solutions.Count; i++)
                {
                    Assert.AreEqual(analyses[i], solutions[i].GetLexicalForm());
                }
            }
            else
            {
                if (count == 0)
                {
                    Assert.IsTrue(solutions.Count == count);
                }
                else
                {
                    Assert.IsTrue(solutions.Count > 0);
                }
            }
        }

    }
}