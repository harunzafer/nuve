using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    [TestFixture]
    class AnalysisNounTest
    {

        
        [TestCase("ağız", 1, new string[] { "ağız" })]
        [TestCase("ağzı", 2, new string[] { "ağız sU", "ağız yU" })]
        [TestCase("ağızı", 0, new string[] { "wrong" })]
        [TestCase("burnuna", 2, new string[] { "burun sU nA", "burun Un yA" })]
        [TestCase("nakde", 1, new string[] { "nakit yA" })]
        [TestCase("nakdine", 2, new string[] { "nakit sU nA", "nakit Un yA" })]
        [TestCase("lütuflar", 2, new string[] { "lütuf lAr", "lütuf lAr"})]
        [TestCase("lütfuna", 2, new string[] { "lütuf sU nA", "lütuf Un yA" })]
        public void SonUnluDusmeTest(string token, int count, string[] analyses)
        {
            Tester.TestAnalyses(token, count, analyses);
        }

        /// <summary>
        /// todo çift durum meselesini nasıl çözeceğiz? Yukarıdakilerde çift durum var mıydı?
        /// </summary>
        [TestCase("avuç", 1, new string[] { "avuç" })]
        [TestCase("avc", 0, new string[] { "negative" })]
        [TestCase("avuc", 0, new string[] { "negative" })]
        [TestCase("avcuna", 0, new string[] { "negative" })]
        [TestCase("avucuna", 2, new string[] { "avuç sU nA", "avuç Un yA" })]
        public void Avuç_Çift_Durum_Test(string token, int count, string[] analyses)
        {
            Tester.TestAnalyses(token, count, analyses);
        }


        [TestCase("ret", 1, new string[] { "ret" })]
        [TestCase("reddi", 2, new string[] { "ret sU", "ret yU" })]
        [TestCase("hattı", 3, new string[] { "hat yDU", "hat sU", "hat yU" })]
        [TestCase("hatta", 2, new string[] { "hat DA", "hat yA" })]
        [TestCase("hatına", 0, new string[] { "wrong" })]
        [TestCase("retine", 0, new string[] { "wrong" })]
        public void Son_Unsuz_Ciftlesme_Test(string token, int count, string[] analyses)
        {
            Tester.TestAnalyses(token, count, analyses);
        }
        
        [TestCase("övünç", 1, new string[] { "övünç" })]
        [TestCase("övüncü", 2, new string[] { "övünç sU", "övünç yU"})]
        [TestCase("övünce", 1, new string[] { "övünç yA"})]
        [TestCase("övünçle", 1, new string[] { "övünç ylA"})]
        [TestCase("övünçsüz", 1, new string[] { "övünç sUz" })]
// ReSharper disable InconsistentNaming
        public void R_YUMUSAMA_ç_Test(string token, int count, string[] analyses)
// ReSharper restore InconsistentNaming
        {
            Tester.TestAnalyses(token, count, analyses);
        }

       

        

        [TestCase("inkar", 1, new string[] { "inkâr" })]
        [TestCase("inkardır", 1, new string[] { "inkâr DUr" })]
        [TestCase("inkâr", 1, new string[] { "inkâr" })]
        [TestCase("inkârdır", 1, new string[] { "âlim" })]
        [TestCase("yar", 3, new string[] { "yar", "yar", "yár" })]
        [TestCase("yâr", 1, new string[] { "yár" })]
        [TestCase("yarim", 2, new string[] { "yár Um", "yár yUm" })]
        [TestCase("yârim", 2, new string[] { "yár Um", "yár yUm" })]
        [TestCase("yârım", 0, new string[] { "negative" })]
        [TestCase("yarım", 2, new string[] { "yar Um", "yar yUm" })]
        public void Şapkalı_Test(string token, int count, string[] analyses)
        {
            Tester.TestAnalyses(token, count, analyses);
        }

      
        [TestCase("akşamki", 1, new[] { "akşam ki", })]
        [TestCase("sabahkinden", 1, new[] { "sabah ki ndAn", })]
        [TestCase("günküler", 1, new[] { "gün ki lAr", })]
        [TestCase("dünküleri", 2, new[] { "dün ki lAr sU", "dün ki lAr yU", })]
        [TestCase("bugünkünü", 1, new[] { "bugün ki nU", })]
        [TestCase("zamanki", 1, new[] { "zaman ki", })]
        [TestCase("defaki", 1, new[] { "defa ki", })]
        [TestCase("seferki", 1, new[] { "sefer ki", })]
        [TestCase("yılki", 1, new[] { "yıl ki", })]
        [TestCase("anki", 1, new[] { "an ki", })]
        public void ZamanKiTest(string token, int count, string[] analyses)
        {
            Tester.TestAnalyses(token, count, analyses);
        }

    }
}

