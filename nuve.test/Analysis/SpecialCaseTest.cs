using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    internal class SpecialCaseTest
    {
        [TestCase("de", "de/FIIL")]
        [TestCase("ye", "ye/FIIL")]
        [TestCase("deyiş", "de/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("yiyiş", "ye/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("deme", "de/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("yeme", "ye/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("demek", "de/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("yemek", "ye/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("diyecek", "de/FIIL FC_ZAMAN_GELECEK_(y)AcAK")]
        [TestCase("yiyecek", "ye/FIIL FC_ZAMAN_GELECEK_(y)AcAK")]
        [TestCase("diyen", "de/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("yiyen", "ye/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("diyesi", "de/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("yiyesi", "ye/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("diyesice", "de/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("yiyesice", "ye/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("dedik", "de/FIIL FC_ZAMAN_GECMIS_DU EKFIIL_SAHIS_BIZ_k")]
        [TestCase("yedik", "ye/FIIL FC_ZAMAN_GECMIS_DU EKFIIL_SAHIS_BIZ_k")]
        [TestCase("demez", "de/FIIL FY_OLUMSUZLUK_mA FC_ZAMAN_GENIS_(U)r")]
        [TestCase("yemez", "ye/FIIL FY_OLUMSUZLUK_mA FC_ZAMAN_GENIS_(U)r")]
        [TestCase("demiş", "de/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("yemiş", "ye/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("diye", "de/FIIL FC_KIP_ISTEK_(y)A")]
        [TestCase("yiye", "ye/FIIL FC_KIP_ISTEK_(y)A")]
        [TestCase("diyeli", "de/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("yiyeli", "ye/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("diyerek", "de/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("yiyerek", "ye/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("diyesiye", "de/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("yiyesiye", "ye/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("deyip", "de/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("yiyip", "ye/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("deyince", "de/FIIL FIILIMSI_ZARF_(y)UncA")]
        [TestCase("yiyince", "ye/FIIL FIILIMSI_ZARF_(y)UncA")]
        [TestCase("dedikçe", "de/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("yedikçe", "ye/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("demeden", "de/FIIL FIILIMSI_ISIM_mA IC_HAL_AYRILMA_DAn")]
        [TestCase("yemeden", "ye/FIIL FIILIMSI_ISIM_mA IC_HAL_AYRILMA_DAn")]
        [TestCase("yedir", "ye/FIIL FY_ETTIRGEN_DUr_(U)t")]
        [TestCase("dedir", "de/FIIL FY_ETTIRGEN_DUr_(U)t")]
        [TestCase("yedirt", "ye/FIIL FY_ETTIRGEN_DUr_(U)t FY_ETTIRTGEN_t_DUr")]
        [TestCase("dedirt", "de/FIIL FY_ETTIRGEN_DUr_(U)t FY_ETTIRTGEN_t_DUr")]
        [TestCase("yedirtiyor", "ye/FIIL FY_ETTIRGEN_DUr_(U)t FY_ETTIRTGEN_t_DUr FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("dedirtiyor", "de/FIIL FY_ETTIRGEN_DUr_(U)t FY_ETTIRTGEN_t_DUr FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("deyiver", "de/FIIL FC_YF_TEZLIK_(y)Uver")]
        [TestCase("yiyiver", "ye/FIIL FC_YF_TEZLIK_(y)Uver")]
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

        [TestCase("su", new[] {"su/ISIM"})]
        [TestCase("suyu", new[] {"su/ISIM IC_SAHIPLIK_O_(s)U", "su/ISIM IC_HAL_BELIRTME_(y)U"})]
        [TestCase("sulu", new[] {"su/ISIM IY_SIFAT_lU"})]
        [TestCase("suya", new[] {"su/ISIM IC_HAL_YONELME_(y)A"})]
        [TestCase("suda", new[] {"su/ISIM IC_HAL_BULUNMA_DA"})]
        [TestCase("sudan", new[] {"su/ISIM IC_HAL_AYRILMA_DAn"})]
        [TestCase("suyun", new[] {"su/ISIM IC_SAHIPLIK_SEN_(U)n", "su/ISIM IC_HAL_ILGI_(n)Un"})]
        [TestCase("suyla", new[] {"su/ISIM IC_HAL_VASITA_(y)lA"})]
        [TestCase("sular",
            new[]
            {
                "su/ISIM IY_FIIL_lA FC_ZAMAN_GENIS_(U)r", "su/ISIM IC_COGUL_lAr",
                "su/ISIM EKFIIL_SAHIS_ONLAR_lAr"
            })]
        [TestCase("suyum", new[] {"su/ISIM IC_SAHIPLIK_BEN_(U)m", "su/ISIM EKFIIL_SAHIS_BEN_(y)Um"})]
        [TestCase("suyumuz", new[] {"su/ISIM IC_SAHIPLIK_BIZ_(U)mUz"})]
        [TestCase("suyumsu", new[] {"su/ISIM IY_SIFAT_(U)msU"})]
        [TestCase("suymuş", new[] {"su/ISIM EKFIIL_RIVAYET_(y)mUş"})]
        [TestCase("suydu", new[] {"su/ISIM EKFIIL_HIKAYE_(y)DU"})]
        [TestCase("suysa", new[] {"su/ISIM EKFIIL_SART_(y)sA"})]
        [TestCase("suyken", new[] {"su/ISIM EKFIIL_ZAMAN_(y)ken"})]
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

        [TestCase("saate", "saát/ISIM IC_HAL_YONELME_(y)A")]
        [TestCase("gole", "gól/ISIM IC_HAL_YONELME_(y)A")]
        [TestCase("alkolü", "alkól/ISIM IC_SAHIPLIK_O_(s)U")]
        [TestCase("ampulde", "ampúl/ISIM IC_HAL_BULUNMA_DA")]
        [TestCase("kabulden", "kabúl/ISIM IC_HAL_AYRILMA_DAn")]
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

        [TestCase("cenkle", "cenk/ISIM IC_HAL_VASITA_(y)lA")]
        [TestCase("cenge", "cenk/ISIM IC_HAL_YONELME_(y)A")]
        [TestCase("çelengine", "çelenk/ISIM IC_SAHIPLIK_O_(s)U IC_HAL_YONELME_(y)A")]
        [TestCase("psikologla", "psikolog/ISIM IC_HAL_VASITA_(y)lA")]
        [TestCase("psikoloğa", "psikolog/ISIM IC_HAL_YONELME_(y)A")]
        public void Yumuşama_K_G_ĞTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }
    }
}