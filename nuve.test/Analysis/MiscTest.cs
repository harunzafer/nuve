using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    internal class MiscTest
    {
        [TestCase("birinci", "bir/SAYI SAYI_SIRA_(U)ncU")]
        [TestCase("ikinci", "iki/SAYI SAYI_SIRA_(U)ncU")]
        [TestCase("üçüncü", "üç/SAYI SAYI_SIRA_(U)ncU")]
        [TestCase("dördüncü", "dört/SAYI SAYI_SIRA_(U)ncU")]
        [TestCase("beşinci", "beş/SAYI SAYI_SIRA_(U)ncU")]
        [TestCase("altıncı", "altı/SAYI SAYI_SIRA_(U)ncU")]
        [TestCase("yedinci", "yedi/SAYI SAYI_SIRA_(U)ncU")]
        [TestCase("sekizinci", "sekiz/SAYI SAYI_SIRA_(U)ncU")]
        [TestCase("dokuzuncu", "dokuz/SAYI SAYI_SIRA_(U)ncU")]
        [TestCase("onuncu", "on/SAYI SAYI_SIRA_(U)ncU")]
        [TestCase("birerli", "bir/SAYI SAYI_ULESTIRME_(ş)Ar IY_SIFAT_lU")]
        [TestCase("ikişerli", "iki/SAYI SAYI_ULESTIRME_(ş)Ar IY_SIFAT_lU")]
        [TestCase("üçlü", "üç/SAYI IY_SIFAT_lU")]
        [TestCase("dörtlük", "dört/SAYI IY_ISIM_lUK")]
        [TestCase("beşte", "beş/SAYI IC_HAL_BULUNMA_DA")]
        [TestCase("altıya", "altı/SAYI IC_HAL_YONELME_(y)A")]
        [TestCase("yediden", "yedi/SAYI IC_HAL_AYRILMA_DAn")]
        [TestCase("sekizle", "sekiz/SAYI IC_HAL_VASITA_(y)lA")]
        [TestCase("dokuzum", "dokuz/SAYI IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("ondu", "on/SAYI EKFIIL_HIKAYE_(y)DU")]
        [TestCase("milyonduk", "milyon/SAYI EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k")]
        [TestCase("milyondur", "milyon/SAYI EKFIIL_TANIMLAMA_DUr")]
        [TestCase("milyarlardır", "milyar/SAYI IC_COGUL_lAr EKFIIL_TANIMLAMA_DUr")]
        [TestCase("trilyonluk", "trilyon/SAYI IY_ISIM_lUK")]
        public void SayıTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("alçacık", "alçak/SIFAT IY_ISIM_KUCULTME_CUK")]
        [TestCase("azcık", "az/SIFAT IY_ISIM_KUCULTME_CUK")]
        [TestCase("birazcık", "biraz/SIFAT IY_ISIM_KUCULTME_CUK")]
        [TestCase("sıcacık", "sıcak/SIFAT IY_ISIM_KUCULTME_CUK")]
        [TestCase("ufacık", "ufak/SIFAT IY_ISIM_KUCULTME_CUK")]
        [TestCase("kısacık", "kısa/SIFAT IY_ISIM_KUCULTME_CUK")]
        [TestCase("minicik", "minik/SIFAT IY_ISIM_KUCULTME_CUK")]
        [TestCase("incecik", "ince/SIFAT IY_ISIM_KUCULTME_CUK")]
        [TestCase("küçücük", "küçük/SIFAT IY_ISIM_KUCULTME_CUK")]
        public void SıfatKucultmeTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("sen de", "sen/ZAMIR_SAHIS_SEN BAGLAC_dA")]
        [TestCase("ben de", "ben/ZAMIR_SAHIS_BEN BAGLAC_dA")]
        [TestCase("o da", "o/ZAMIR_SAHIS_O BAGLAC_dA")]
        [TestCase("kalem de", "kale/ISIM IC_SAHIPLIK_BEN_(U)m BAGLAC_dA")]
        [TestCase("kitap da", "kitap/ISIM BAGLAC_dA")]
        [TestCase("orada da", "ora/ZAMIR_ISARET_YER IC_HAL_BULUNMA_DA BAGLAC_dA")]
        [TestCase("evde de", "ev/ISIM IC_HAL_BULUNMA_DA BAGLAC_dA")]
        [TestCase("gelsen de", "gel/FIIL FC_KIP_DILEK_sA EKFIIL_SAHIS_SEN_n BAGLAC_dA")]
        [TestCase("kalsam da", "kal/ISIM EKFIIL_SART_(y)sA EKFIIL_SAHIS_BEN_m BAGLAC_dA")]
        public void BaglacDeDaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }
    }
}