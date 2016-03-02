using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    [TestFixture]
    internal class TamlamaTest
    {
        //Yalın tekil ve çoğul
        [TestCase("zeytinyağı", new[] {"zeytinyağ/TAMLAMA IC_SAHIPLIK_O_(s)U"})]
        [TestCase("zeytinyağları", new[]
        {
            "zeytinyağ/TAMLAMA IC_COGUL_lAr IC_SAHIPLIK_O_(s)U",
            "zeytinyağ/TAMLAMA IC_SAHIPLIK_ONLAR_lArI"
        })]

        //iyelik ekleri (doğrudan eklenir)
        [TestCase("zeytinyağım", new[] {"zeytinyağ/TAMLAMA IC_SAHIPLIK_BEN_(U)m"})]
        [TestCase("zeytinyağımız", new[] {"zeytinyağ/TAMLAMA IC_SAHIPLIK_BIZ_(U)mUz"})]

        //Yapım ekleri (doğrudan eklenir)
        [TestCase("zeytinyağsız", new[] {"zeytinyağ/TAMLAMA IY_SIFAT_sUz"})]
        [TestCase("zeytinyağlı", new[] {"zeytinyağ/TAMLAMA IY_SIFAT_lU"})]
        [TestCase("zeytinyağcı", new[] {"zeytinyağ/TAMLAMA IY_ISIM_CU"})]
        [TestCase("zeytinyağlamak", new[] {"zeytinyağ/TAMLAMA IY_FIIL_lA FIILIMSI_ISIM_mAk"})]

        //Hal ekleri (iyelik ekinden sonra eklenir)
        [TestCase("zeytinyağında", new[]
        {
            "zeytinyağ/TAMLAMA IC_SAHIPLIK_O_(s)U IC_HAL_BULUNMA_DA",
            "zeytinyağ/TAMLAMA IC_SAHIPLIK_SEN_(U)n IC_HAL_BULUNMA_DA"
        })]
        [TestCase("zeytinyağımızı", new[]
        {
            "zeytinyağ/TAMLAMA IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_BELIRTME_(y)U"
        })]

        //Ek Fiil (iyelik ekinden sonra eklenir)
        [TestCase("zeytinyağıydı", new[]
        {
            "zeytinyağ/TAMLAMA IC_SAHIPLIK_O_(s)U EKFIIL_HIKAYE_(y)DU"
        })]
        [TestCase("zeytinyağınızmış", new[]
        {
            "zeytinyağ/TAMLAMA IC_SAHIPLIK_SIZ_(U)nUz EKFIIL_RIVAYET_(y)mUş"
        })]
        public void Tamlama_Test(string token, string[] analyses)
        {
            Tester.AllAnalysesEqual(token, analyses);
        }


        [TestCase("zeytinyağ")]
        [TestCase("zeytinyağmış")]
        [TestCase("zeytinyağdı")]
        [TestCase("zeytinyağımlar")]
        [TestCase("zeytinyağda")]
        [TestCase("zeytinyağısı")]
        [TestCase("zeytinyağıyı")]
        [TestCase("zeytinyağısız")]
        public void Tamlama_False_Test(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        //zeytinyağlar için TAMLAMA IY_FIIL_lA FC_ZAMAN_GENIS_(U)r şeklinde bir çözüm mevcut
        public void Tamlama_Other()
        {
            Tester.AnalysisNotExist("zeytinyağlar", "zeytinyağ/TAMLAMA IC_COGUL_lAr");
        }
    }
}