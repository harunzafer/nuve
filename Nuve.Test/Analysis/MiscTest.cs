using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    internal class MiscTest
    {
        [TestCase("birinci", "bir/SAYI UncU/SAYI_SIRA_(U)ncU")]
        [TestCase("ikinci", "iki/SAYI UncU/SAYI_SIRA_(U)ncU")]
        [TestCase("üçüncü", "üç/SAYI UncU/SAYI_SIRA_(U)ncU")]
        [TestCase("dördüncü", "dört/SAYI UncU/SAYI_SIRA_(U)ncU")]
        [TestCase("beşinci", "beş/SAYI UncU/SAYI_SIRA_(U)ncU")]
        [TestCase("altıncı", "altı/SAYI UncU/SAYI_SIRA_(U)ncU")]
        [TestCase("yedinci", "yedi/SAYI UncU/SAYI_SIRA_(U)ncU")]
        [TestCase("sekizinci", "sekiz/SAYI UncU/SAYI_SIRA_(U)ncU")]
        [TestCase("dokuzuncu", "dokuz/SAYI UncU/SAYI_SIRA_(U)ncU")]
        [TestCase("onuncu", "on/SAYI UncU/SAYI_SIRA_(U)ncU")]
        [TestCase("birerli", "bir/SAYI şAr/SAYI_ULESTIRME_(ş)Ar lU/IY_SIFAT_lU")]
        [TestCase("ikişerli", "iki/SAYI şAr/SAYI_ULESTIRME_(ş)Ar lU/IY_SIFAT_lU")]
        [TestCase("üçlü", "üç/SAYI lU/IY_SIFAT_lU")]
        [TestCase("dörtlük", "dört/SAYI lUk/IY_ISIM_lUK")]
        [TestCase("beşte", "beş/SAYI DA/IC_HAL_BULUNMA_DA")]
        [TestCase("altıya", "altı/SAYI yA/IC_HAL_YONELME_(y)A")]
        [TestCase("yediden", "yedi/SAYI DAn/IC_HAL_AYRILMA_DAn")]
        [TestCase("sekizle", "sekiz/SAYI ylA/IC_HAL_VASITA_(y)lA")]
        [TestCase("dokuzum", "dokuz/SAYI Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("ondu", "on/SAYI yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("milyonduk", "milyon/SAYI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("milyondur", "milyon/SAYI DUr/EKFIIL_TANIMLAMA_DUr")]
        [TestCase("milyarlardır", "milyar/SAYI lAr/IC_COGUL_lAr DUr/EKFIIL_TANIMLAMA_DUr")]
        [TestCase("trilyonluk", "trilyon/SAYI lUk/IY_ISIM_lUK")]
        public void SayıTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("alçacık", "alçak/SIFAT CUk/IY_ISIM_KUCULTME_CUK")]
        [TestCase("azcık", "az/SIFAT CUk/IY_ISIM_KUCULTME_CUK")]
        [TestCase("birazcık", "biraz/SIFAT CUk/IY_ISIM_KUCULTME_CUK")]
        [TestCase("sıcacık", "sıcak/SIFAT CUk/IY_ISIM_KUCULTME_CUK")]
        [TestCase("ufacık", "ufak/SIFAT CUk/IY_ISIM_KUCULTME_CUK")]
        [TestCase("kısacık", "kısa/SIFAT CUk/IY_ISIM_KUCULTME_CUK")]
        [TestCase("minicik", "minik/SIFAT CUk/IY_ISIM_KUCULTME_CUK")]
        [TestCase("incecik", "ince/SIFAT CUk/IY_ISIM_KUCULTME_CUK")]
        [TestCase("küçücük", "küçük/SIFAT CUk/IY_ISIM_KUCULTME_CUK")]
        public void SıfatKucultmeTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("sen de", "sen/ZAMIR_SAHIS_SEN _dA/BAGLAC_dA")]
        [TestCase("ben de", "ben/ZAMIR_SAHIS_BEN _dA/BAGLAC_dA")]
        [TestCase("o da", "o/ZAMIR_SAHIS_O _dA/BAGLAC_dA")]
        [TestCase("kalem de", "kale/ISIM Um/IC_SAHIPLIK_BEN_(U)m _dA/BAGLAC_dA")]
        [TestCase("kitap da", "kitap/ISIM _dA/BAGLAC_dA")]
        [TestCase("orada da", "ora/ZAMIR_ISARET_YER DA/IC_HAL_BULUNMA_DA _dA/BAGLAC_dA")]
        [TestCase("evde de", "ev/ISIM DA/IC_HAL_BULUNMA_DA _dA/BAGLAC_dA")]
        [TestCase("gelsen de", "gel/FIIL sA/FC_KIP_DILEK_sA n/EKFIIL_SAHIS_SEN_n _dA/BAGLAC_dA")]
        [TestCase("kalsam da", "kal/ISIM ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _dA/BAGLAC_dA")]
        public void BaglacDeDaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }
    }
}