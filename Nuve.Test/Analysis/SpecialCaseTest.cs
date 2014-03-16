using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    class SpecialCaseTest
    {
        [TestCase("de", "de/FIIL")]
        [TestCase("ye", "ye/FIIL")]
        [TestCase("deyiş", "de/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("yiyiş", "ye/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("deme", "de/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("yeme", "ye/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("demek", "de/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("yemek", "ye/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("diyecek", "de/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK")]
        [TestCase("yiyecek", "ye/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK")]
        [TestCase("diyen", "de/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("yiyen", "ye/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("diyesi", "de/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("yiyesi", "ye/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("diyesice", "de/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("yiyesice", "ye/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("dedik", "de/FIIL DU/FC_ZAMAN_GECMIS_DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("yedik", "ye/FIIL DU/FC_ZAMAN_GECMIS_DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("demez", "de/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("yemez", "ye/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("demiş", "de/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("yemiş", "ye/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("diye", "de/FIIL yA/FC_KIP_ISTEK_(y)A")]
        [TestCase("yiye", "ye/FIIL yA/FC_KIP_ISTEK_(y)A")]
        [TestCase("diyeli", "de/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("yiyeli", "ye/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("diyerek", "de/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("yiyerek", "ye/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("diyesiye", "de/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("yiyesiye", "ye/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("deyip", "de/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("yiyip", "ye/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("deyince", "de/FIIL yUncA/FIILIMSI_ZARF_(y)UncA")]
        [TestCase("yiyince", "ye/FIIL yUncA/FIILIMSI_ZARF_(y)UncA")]
        [TestCase("dedikçe", "de/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("yedikçe", "ye/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("demeden", "de/FIIL mA/FIILIMSI_ISIM_mA DAn/IC_HAL_AYRILMA_DAn")]
        [TestCase("yemeden", "ye/FIIL mA/FIILIMSI_ISIM_mA DAn/IC_HAL_AYRILMA_DAn")]
        [TestCase("yedir", "ye/FIIL DUr/FY_ETTIRGEN_DUr_(U)t")]
        [TestCase("dedir", "de/FIIL DUr/FY_ETTIRGEN_DUr_(U)t")]
        [TestCase("yedirt", "ye/FIIL DUr/FY_ETTIRGEN_DUr_(U)t t/FY_ETTIRTGEN_t_DUr")]
        [TestCase("dedirt", "de/FIIL DUr/FY_ETTIRGEN_DUr_(U)t t/FY_ETTIRTGEN_t_DUr")]
        [TestCase("yedirtiyor", "ye/FIIL DUr/FY_ETTIRGEN_DUr_(U)t t/FY_ETTIRTGEN_t_DUr Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("dedirtiyor", "de/FIIL DUr/FY_ETTIRGEN_DUr_(U)t t/FY_ETTIRTGEN_t_DUr Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("deyiver", "de/FIIL yUver/FC_YF_TEZLIK_(y)Uver")]
        [TestCase("yiyiver", "ye/FIIL yUver/FC_YF_TEZLIK_(y)Uver")]
        public void FiilDemekYemekTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("di")]
        [TestCase("yi")]
        [TestCase("diyiş")]
        [TestCase("yeyiş")]
        [TestCase("deyecek")]
        [TestCase("yeyecek")]
        [TestCase("deyen")]
        [TestCase("yeyen")]
        [TestCase("deyesi")]
        [TestCase("yeyesi")]
        [TestCase("deye")]
        [TestCase("yeye")]
        [TestCase("deyerek")]
        [TestCase("diyip")]
        [TestCase("yeyip")]
        [TestCase("diyince")]
        [TestCase("diyiver")]
        [TestCase("yeyiver")]
        public void GecersizFiilDemekYemekTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("su", new[] { "su/ISIM", })]
        [TestCase("suyu", new[] { "su/ISIM sU/IC_SAHIPLIK_O_(s)U", "su/ISIM yU/IC_HAL_BELIRTME_(y)U", })]
        [TestCase("sulu", new[] { "su/ISIM lU/IY_SIFAT_lU", })]
        [TestCase("suya", new[] { "su/ISIM yA/IC_HAL_YONELME_(y)A", })]
        [TestCase("suda", new[] { "su/ISIM DA/IC_HAL_BULUNMA_DA", })]
        [TestCase("sudan", new[] { "su/ISIM DAn/IC_HAL_AYRILMA_DAn", })]
        [TestCase("suyun", new[] { "su/ISIM Un/IC_SAHIPLIK_SEN_(U)n", "su/ISIM nUn/IC_HAL_ILGI_(n)Un", })]
        [TestCase("suyla", new[] { "su/ISIM ylA/IC_HAL_VASITA_(y)lA", })]
        [TestCase("sular", new[] { "su/ISIM lA/IY_FIIL_lA Ur/FC_ZAMAN_GENIS_(U)r", "su/ISIM lAr/IC_COGUL_lAr", "su/ISIM lAr/EKFIIL_SAHIS_ONLAR_lAr", })]
        [TestCase("suyum", new[] { "su/ISIM Um/IC_SAHIPLIK_BEN_(U)m", "su/ISIM yUm/EKFIIL_SAHIS_BEN_(y)Um", })]
        [TestCase("suyumuz", new[] { "su/ISIM UmUz/IC_SAHIPLIK_BIZ_(U)mUz", })]
        [TestCase("suyumsu", new[] { "su/ISIM UmsU/IY_SIFAT_(U)msU", })]
        [TestCase("suymuş", new[] { "su/ISIM ymUş/EKFIIL_RIVAYET_(y)mUş", })]
        [TestCase("suydu", new[] { "su/ISIM yDU/EKFIIL_HIKAYE_(y)DU", })]
        [TestCase("suysa", new[] { "su/ISIM ysA/EKFIIL_SART_(y)sA", })]
        [TestCase("suyken", new[] { "su/ISIM yken/EKFIIL_ZAMAN_(y)ken", })]
        public void IsimSuTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }

        [TestCase("suysuz")]
        [TestCase("susu")]
        [TestCase("suylu")]
        [TestCase("suylar")]
        public void GecersizIsimSuTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("saate", "saát/ISIM yA/IC_HAL_YONELME_(y)A")]
        [TestCase("gole", "gól/ISIM yA/IC_HAL_YONELME_(y)A")]
        [TestCase("alkolü", "alkól/ISIM sU/IC_SAHIPLIK_O_(s)U")]
        [TestCase("ampulde", "ampúl/ISIM DA/IC_HAL_BULUNMA_DA")]
        [TestCase("kabulden", "kabúl/ISIM DAn/IC_HAL_AYRILMA_DAn")]
        public void UnluIncelmesiTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("saata")]
        [TestCase("gola")]
        [TestCase("alkolu")]
        [TestCase("ampulda")]
        [TestCase("kabuldan")]
        public void GecersizUnluIncelmesiTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("cenkle", "cenk/ISIM ylA/IC_HAL_VASITA_(y)lA")]
        [TestCase("cenge", "cenk/ISIM yA/IC_HAL_YONELME_(y)A")]
        [TestCase("çelengine", "çelenk/ISIM sU/IC_SAHIPLIK_O_(s)U yA/IC_HAL_YONELME_(y)A")]
        [TestCase("psikologla", "psikolog/ISIM ylA/IC_HAL_VASITA_(y)lA")]
        [TestCase("psikoloğa", "psikolog/ISIM yA/IC_HAL_YONELME_(y)A")]
        public void Yumuşama_K_G_ĞTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

    }
}
