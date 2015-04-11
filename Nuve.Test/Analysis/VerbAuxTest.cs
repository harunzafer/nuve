using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    internal class VerbAuxTest
    {
        [TestCase("yayayım", "ya/UNLEM yA/IC_HAL_YONELME_(y)A yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("yayasın", "ya/UNLEM yA/IC_HAL_YONELME_(y)A sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("yayadır", "ya/UNLEM yA/IC_HAL_YONELME_(y)A DUr/EKFIIL_TANIMLAMA_DUr")]
        [TestCase("yayayız", "ya/UNLEM yA/IC_HAL_YONELME_(y)A yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("yayasınız", "ya/UNLEM yA/IC_HAL_YONELME_(y)A sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("yayadırlar", "ya/UNLEM yA/IC_HAL_YONELME_(y)A DUr/EKFIIL_TANIMLAMA_DUr lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void EkFiilGenisZamanTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yayaydım", "ya/UNLEM yA/IC_HAL_YONELME_(y)A yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("yayaydın", "ya/UNLEM yA/IC_HAL_YONELME_(y)A yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("yayaydı", "ya/UNLEM yA/IC_HAL_YONELME_(y)A yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("yayaydık", "ya/UNLEM yA/IC_HAL_YONELME_(y)A yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("yayaydınız", "ya/UNLEM yA/IC_HAL_YONELME_(y)A yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("yayaydılar", "ya/UNLEM yA/IC_HAL_YONELME_(y)A yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void EkFiilGecmisDiTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("yayaymışım", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")
        ]
        [TestCase("yayaymışsın", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("yayaymış", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("yayaymışız", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")
        ]
        [TestCase("yayaymışsınız",
            "ya/UNLEM yA/IC_HAL_YONELME_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("yayaymışlar", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr"
            )]
        public void EkFiilGecmisMisTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yayaysam", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("yayaysan", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("yayaysa", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ysA/EKFIIL_SART_(y)sA")]
        [TestCase("yayaysak", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("yayaysanız", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("yayaysalar", "ya/UNLEM yA/IC_HAL_YONELME_(y)A ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void EkFiilSartTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arayış", "ara/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("ödeyiş", "öde/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("yiyiş", "ye/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("deyiş", "de/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("acıyış", "acı/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("eriyiş", "eri/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("okuyuş", "oku/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("üşüyüş", "üşü/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("ediş", "et/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("atış", "at/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("kılış", "kıl/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("biliş", "bil/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("buluş", "bul/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("yüzüş", "yüz/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("oluş", "ol/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("ölüş", "öl/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("kalış", "kal/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("geliş", "gel/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        [TestCase("yapış", "yap/FIIL yUş/FIILIMSI_ISIM_(y)Uş")]
        public void FiilimsiIsimUşTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arama", "ara/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("ödeme", "öde/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("yeme", "ye/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("deme", "de/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("acıma", "acı/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("erime", "eri/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("okuma", "oku/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("üşüme", "üşü/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("etme", "et/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("atma", "at/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("kılma", "kıl/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("bilme", "bil/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("bulma", "bul/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("yüzme", "yüz/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("olma", "ol/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("ölme", "öl/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("kalma", "kal/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("gelme", "gel/FIIL mA/FIILIMSI_ISIM_mA")]
        [TestCase("yapma", "yap/FIIL mA/FIILIMSI_ISIM_mA")]
        public void FiilimsiIsimMaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("aramak", "ara/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("ödemek", "öde/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("yemek", "ye/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("demek", "de/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("acımak", "acı/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("erimek", "eri/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("okumak", "oku/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("üşümek", "üşü/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("etmek", "et/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("atmak", "at/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("kılmak", "kıl/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("bilmek", "bil/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("bulmak", "bul/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("yüzmek", "yüz/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("olmak", "ol/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("ölmek", "öl/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("kalmak", "kal/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("gelmek", "gel/FIIL mAk/FIILIMSI_ISIM_mAk")]
        [TestCase("yapmak", "yap/FIIL mAk/FIILIMSI_ISIM_mAk")]
        public void FiilimsiIsimMakTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arayan", "ara/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("ödeyen", "öde/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("yiyen", "ye/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("diyen", "de/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("acıyan", "acı/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("eriyen", "eri/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("okuyan", "oku/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("üşüyen", "üşü/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("eden", "et/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("atan", "at/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("kılan", "kıl/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("bilen", "bil/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("bulan", "bul/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("yüzen", "yüz/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("olan", "ol/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("ölen", "öl/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("kalan", "kal/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("gelen", "gel/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        [TestCase("yapan", "yap/FIIL yAn/FIILIMSI_SIFAT_(y)An")]
        public void FiilimsiSıfatAnTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arayası", "ara/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("ödeyesi", "öde/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("yiyesi", "ye/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("diyesi", "de/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("acıyası", "acı/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("eriyesi", "eri/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("okuyası", "oku/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("üşüyesi", "üşü/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("edesi", "et/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("atası", "at/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("kılası", "kıl/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("bilesi", "bil/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("bulası", "bul/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("yüzesi", "yüz/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("olası", "ol/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("ölesi", "öl/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("kalası", "kal/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("gelesi", "gel/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("yapası", "yap/FIIL yAsI/FIILIMSI_SIFAT_(y)AsI")]
        public void FiilimsiSıfatAsıTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("arayasıca", "ara/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("ödeyesice", "öde/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("yiyesice", "ye/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("diyesice", "de/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("acıyasıca", "acı/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("eriyesice", "eri/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("okuyasıca", "oku/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("üşüyesice", "üşü/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("edesice", "et/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("atasıca", "at/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("kılasıca", "kıl/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("bilesice", "bil/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("bulasıca", "bul/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("yüzesice", "yüz/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("olasıca", "ol/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("ölesice", "öl/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("kalasıca", "kal/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("gelesice", "gel/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("yapasıca", "yap/FIIL yAsIcA/FIILIMSI_SIFAT_(y)AsIcA")]
        public void FiilimsiSıfatAsıcaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("aradığım", "ara/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("ödediğim", "öde/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("yediğim", "ye/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("dediğim", "de/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("acıdığım", "acı/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("eridiğim", "eri/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("okuduğum", "oku/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("üşüdüğüm", "üşü/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("ettiğim", "et/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("attığım", "at/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("kıldığım", "kıl/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("bildiğim", "bil/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("bulduğum", "bul/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("yüzdüğüm", "yüz/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("olduğum", "ol/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("öldüğüm", "öl/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("kaldığım", "kal/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("geldiğim", "gel/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("yaptığım", "yap/FIIL DUk/FIILIMSI_SIFAT_DUK Um/IC_SAHIPLIK_BEN_(U)m")]
        public void FiilimsiSıfatDukTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("aramaz", "ara/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("ödemez", "öde/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("yemez", "ye/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("demez", "de/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("acımaz", "acı/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("erimez", "eri/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("okumaz", "oku/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("üşümez", "üşü/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("etmez", "et/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("atmaz", "at/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("kılmaz", "kıl/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("bilmez", "bil/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("bulmaz", "bul/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("yüzmez", "yüz/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("olmaz", "ol/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("ölmez", "öl/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("kalmaz", "kal/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("gelmez", "gel/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        [TestCase("yapmaz", "yap/FIIL mAz/FIILIMSI_SIFAT_mAz")]
        public void FiilimsiSıfatMazTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("aramış", "ara/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("ödemiş", "öde/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("yemiş", "ye/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("demiş", "de/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("acımış", "acı/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("erimiş", "eri/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("okumuş", "oku/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("üşümüş", "üşü/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("etmiş", "et/FIIL mUş/FIILIMSI_SIFAT_mUş")]
        [TestCase("atmış", "at/FIIL mUş/FIILIMSI_SIFAT_mUş")]
        [TestCase("kılmış", "kıl/FIIL mUş/FIILIMSI_SIFAT_mUş")]
        [TestCase("bilmiş", "bil/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("bulmuş", "bul/FIIL mUş/FIILIMSI_SIFAT_mUş")]
        [TestCase("yüzmüş", "yüz/FIIL mUş/FIILIMSI_SIFAT_mUş")]
        [TestCase("olmuş", "ol/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("ölmüş", "öl/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("kalmış", "kal/FIIL mUş/FIILIMSI_SIFAT_mUş")]
        [TestCase("gelmiş", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("yapmış", "yap/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        public void FiilimsiSıfatMusTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("araya", new[] {"ara/FIIL yA/FIILIMSI_ZARF_(y)A"})]
        [TestCase("ödeye", new[] {"öde/FIIL yA/FIILIMSI_ZARF_(y)A"})]
        [TestCase("yiye", new[] {"ye/FIIL yA/FIILIMSI_ZARF_(y)A"})]
        [TestCase("diye", new[] {"de/FIIL yA/FIILIMSI_ZARF_(y)A"})]
        [TestCase("ola", new[] {"ol/FIIL yA/FIILIMSI_ZARF_(y)A"})]
        [TestCase("öle", new[] {"öl/FIIL yA/FIILIMSI_ZARF_(y)A"})]
        public void FiilimsiZarfATest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }

        [TestCase("arayalı", "ara/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("ödeyeli", "öde/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("yiyeli", "ye/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("diyeli", "de/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("acıyalı", "acı/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("eriyeli", "eri/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("okuyalı", "oku/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("üşüyeli", "üşü/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("edeli", "et/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("atalı", "at/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("kılalı", "kıl/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("bileli", "bil/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("bulalı", "bul/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("yüzeli", "yüz/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("olalı", "ol/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("öleli", "öl/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("kalalı", "kal/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("geleli", "gel/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        [TestCase("yapalı", "yap/FIIL yAlI/FIILIMSI_ZARF_(y)AlI")]
        public void FiilimsiZarfAlıTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arayarak", "ara/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("ödeyerek", "öde/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("yiyerek", "ye/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("diyerek", "de/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("acıyarak", "acı/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("eriyerek", "eri/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("okuyarak", "oku/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("üşüyerek", "üşü/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("ederek", "et/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("atarak", "at/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("kılarak", "kıl/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("bilerek", "bil/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("bularak", "bul/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("yüzerek", "yüz/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("olarak", "ol/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("ölerek", "öl/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("kalarak", "kal/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("gelerek", "gel/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("yaparak", "yap/FIIL yArAk/FIILIMSI_ZARF_(y)ArAk")]
        public void FiilimsiZarfArakTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arayasıya", "ara/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("ödeyesiye", "öde/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("yiyesiye", "ye/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("diyesiye", "de/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("acıyasıya", "acı/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("eriyesiye", "eri/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("okuyasıya", "oku/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("üşüyesiye", "üşü/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("edesiye", "et/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("atasıya", "at/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("kılasıya", "kıl/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("bilesiye", "bil/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("bulasıya", "bul/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("yüzesiye", "yüz/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("olasıya", "ol/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("ölesiye", "öl/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("kalasıya", "kal/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("gelesiye", "gel/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("yapasıya", "yap/FIIL yAsIyA/FIILIMSI_ZARF_(y)AsIyA")]
        public void FiilimsiZarfAsıyaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("arayıp", "ara/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("ödeyip", "öde/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("yiyip", "ye/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("deyip", "de/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("acıyıp", "acı/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("eriyip", "eri/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("okuyup", "oku/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("üşüyüp", "üşü/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("edip", "et/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("atıp", "at/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("kılıp", "kıl/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("bilip", "bil/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("bulup", "bul/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("yüzüp", "yüz/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("olup", "ol/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("ölüp", "öl/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("kalıp", "kal/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("gelip", "gel/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        [TestCase("yapıp", "yap/FIIL yUp/FIILIMSI_ZARF_(y)Up")]
        public void FiilimsiZarfUpTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("ararcasına", "ara/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("ödercesine", "öde/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("yercesine", "ye/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("dercesine", "de/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("acırcasına", "acı/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("erircesine", "eri/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("okurcasına", "oku/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("üşürcesine", "üşü/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("edercesine", "et/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("atarcasına", "at/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("kılarcasına", "kıl/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("bilircesine", "bil/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("bulurcasına", "bul/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("yüzercesine", "yüz/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("olurcasına", "ol/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("ölürcesine", "öl/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("kalırcasına", "kal/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("gelircesine", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        [TestCase("yaparcasına", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r CAsInA/FIILIMSI_ZARF_CAsInA")]
        public void FiilimsiZarfCasınaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("aradıkça", "ara/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("ödedikçe", "öde/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("yedikçe", "ye/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("dedikçe", "de/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("acıdıkça", "acı/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("eridikçe", "eri/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("okudukça", "oku/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("üşüdükçe", "üşü/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("ettikçe", "et/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("attıkça", "at/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("kıldıkça", "kıl/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("bildikçe", "bil/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("buldukça", "bul/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("yüzdükçe", "yüz/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("oldukça", "ol/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("öldükçe", "öl/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("kaldıkça", "kal/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("geldikçe", "gel/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        [TestCase("yaptıkça", "yap/FIIL DUkçA/FIILIMSI_ZARF_DUkçA")]
        public void FiilimsiZarfDıkcaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("aramadan", "ara/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("ödemeden", "öde/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("yemeden", "ye/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("demeden", "de/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("acımadan", "acı/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("erimeden", "eri/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("okumadan", "oku/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("üşümeden", "üşü/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("etmeden", "et/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("atmadan", "at/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("kılmadan", "kıl/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("bilmeden", "bil/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("bulmadan", "bul/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("yüzmeden", "yüz/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("olmadan", "ol/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("ölmeden", "öl/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("kalmadan", "kal/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("gelmeden", "gel/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        [TestCase("yapmadan", "yap/FIIL mAdAn/FIILIMSI_ZARF_mAdAn")]
        public void FiilimsiZarfMadanTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("aramaksızın", "ara/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("ödemeksizin", "öde/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("yemeksizin", "ye/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("demeksizin", "de/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("acımaksızın", "acı/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("erimeksizin", "eri/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("okumaksızın", "oku/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("üşümeksizin", "üşü/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("etmeksizin", "et/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("atmaksızın", "at/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("kılmaksızın", "kıl/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("bilmeksizin", "bil/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("bulmaksızın", "bul/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("yüzmeksizin", "yüz/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("olmaksızın", "ol/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("ölmeksizin", "öl/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("kalmaksızın", "kal/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("gelmeksizin", "gel/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        [TestCase("yapmaksızın", "yap/FIIL mAk/FIILIMSI_ISIM_mAk sIzIn/FIILIMSI_ZARF_sIzIn")]
        public void FiilimsiZarfMaksızınTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("geledur", "gel/FIIL yAdur/FC_YF_SUREKLILIK_(y)Adur")]
        [TestCase("geledursun", "gel/FIIL yAdur/FC_YF_SUREKLILIK_(y)Adur sUn/FC_KIP_EMIR_sUn")]
        [TestCase("geledurdum", "gel/FIIL yAdur/FC_YF_SUREKLILIK_(y)Adur DU/FC_ZAMAN_GECMIS_DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("geledurmuşsun",
            "gel/FIIL yAdur/FC_YF_SUREKLILIK_(y)Adur mUş/FC_ZAMAN_GECMIS_mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("geledursaydı", "gel/FIIL yAdur/FC_YF_SUREKLILIK_(y)Adur sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("geledurmalıydık",
            "gel/FIIL yAdur/FC_YF_SUREKLILIK_(y)Adur mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("geledururmuşlar",
            "gel/FIIL yAdur/FC_YF_SUREKLILIK_(y)Adur Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("geleduracaktım",
            "gel/FIIL yAdur/FC_YF_SUREKLILIK_(y)Adur yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("geleduruyorsanız",
            "gel/FIIL yAdur/FC_YF_SUREKLILIK_(y)Adur Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıAdurTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("olagel", "ol/FIIL yAgel/FC_YF_SUREKLILIK_(y)Agel")]
        [TestCase("olagelseydiniz",
            "ol/FIIL yAgel/FC_YF_SUREKLILIK_(y)Agel sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("olagelmiştir",
            "ol/FIIL yAgel/FC_YF_SUREKLILIK_(y)Agel mUş/FC_ZAMAN_GECMIS_mUş DUr/EKFIIL_TANIMLAMA_DUr")]
        [TestCase("olagelecekmişsiniz",
            "ol/FIIL yAgel/FC_YF_SUREKLILIK_(y)Agel yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("olagelseydi", "ol/FIIL yAgel/FC_YF_SUREKLILIK_(y)Agel sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("olagelmeliydik",
            "ol/FIIL yAgel/FC_YF_SUREKLILIK_(y)Agel mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("olagelirmişler",
            "ol/FIIL yAgel/FC_YF_SUREKLILIK_(y)Agel Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("olagelecektim",
            "ol/FIIL yAgel/FC_YF_SUREKLILIK_(y)Agel yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("olageliyorsanız",
            "ol/FIIL yAgel/FC_YF_SUREKLILIK_(y)Agel Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıAgelTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("olagör", "ol/FIIL yAgör/FC_YF_SUREKLILIK_(y)Agör")]
        [TestCase("olagörseydiniz",
            "ol/FIIL yAgör/FC_YF_SUREKLILIK_(y)Agör sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("olagörmüştür",
            "ol/FIIL yAgör/FC_YF_SUREKLILIK_(y)Agör mUş/FC_ZAMAN_GECMIS_mUş DUr/EKFIIL_TANIMLAMA_DUr")]
        [TestCase("olagörecekmişsiniz",
            "ol/FIIL yAgör/FC_YF_SUREKLILIK_(y)Agör yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("olagörseydi", "ol/FIIL yAgör/FC_YF_SUREKLILIK_(y)Agör sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("olagörmeliydik",
            "ol/FIIL yAgör/FC_YF_SUREKLILIK_(y)Agör mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("olagörürmüşler",
            "ol/FIIL yAgör/FC_YF_SUREKLILIK_(y)Agör Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("olagörecektim",
            "ol/FIIL yAgör/FC_YF_SUREKLILIK_(y)Agör yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("olagörüyorsanız",
            "ol/FIIL yAgör/FC_YF_SUREKLILIK_(y)Agör Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıAgörTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("olakal", "ol/FIIL yAkal/FC_YF_SUREKLILIK_(y)Akal")]
        [TestCase("olakalsaydınız",
            "ol/FIIL yAkal/FC_YF_SUREKLILIK_(y)Akal sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("olakalmıştır",
            "ol/FIIL yAkal/FC_YF_SUREKLILIK_(y)Akal mUş/FC_ZAMAN_GECMIS_mUş DUr/EKFIIL_TANIMLAMA_DUr")]
        [TestCase("olakalacakmışsınız",
            "ol/FIIL yAkal/FC_YF_SUREKLILIK_(y)Akal yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("olakalsaydı", "ol/FIIL yAkal/FC_YF_SUREKLILIK_(y)Akal sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("olakalmalıydık",
            "ol/FIIL yAkal/FC_YF_SUREKLILIK_(y)Akal mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("olakalırmışlar",
            "ol/FIIL yAkal/FC_YF_SUREKLILIK_(y)Akal Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("olakalacaktım",
            "ol/FIIL yAkal/FC_YF_SUREKLILIK_(y)Akal yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("olakalıyorsanız",
            "ol/FIIL yAkal/FC_YF_SUREKLILIK_(y)Akal Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıAkalTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapıver", "yap/FIIL yUver/FC_YF_TEZLIK_(y)Uver")]
        [TestCase("yapıverseydiniz",
            "yap/FIIL yUver/FC_YF_TEZLIK_(y)Uver sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("yapıvermiştir",
            "yap/FIIL yUver/FC_YF_TEZLIK_(y)Uver mUş/FC_ZAMAN_GECMIS_mUş DUr/EKFIIL_TANIMLAMA_DUr")]
        [TestCase("yapıverecekmişsiniz",
            "yap/FIIL yUver/FC_YF_TEZLIK_(y)Uver yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("yapıverseydi", "yap/FIIL yUver/FC_YF_TEZLIK_(y)Uver sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("yapıvermeliydik",
            "yap/FIIL yUver/FC_YF_TEZLIK_(y)Uver mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("yapıverirmişler",
            "yap/FIIL yUver/FC_YF_TEZLIK_(y)Uver Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("yapıverecektim",
            "yap/FIIL yUver/FC_YF_TEZLIK_(y)Uver yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("yapıveriyorsanız",
            "yap/FIIL yUver/FC_YF_TEZLIK_(y)Uver Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıUverTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapayaz", "yap/FIIL yAyaz/FC_YF_YAKLASMA_(y)Ayaz")]
        [TestCase("yapayazsaydınız",
            "yap/FIIL yAyaz/FC_YF_YAKLASMA_(y)Ayaz sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")
        ]
        [TestCase("yapayazmıştır",
            "yap/FIIL yAyaz/FC_YF_YAKLASMA_(y)Ayaz mUş/FC_ZAMAN_GECMIS_mUş DUr/EKFIIL_TANIMLAMA_DUr")]
        [TestCase("yapayazacakmışsınız",
            "yap/FIIL yAyaz/FC_YF_YAKLASMA_(y)Ayaz yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("yapayazsaydı", "yap/FIIL yAyaz/FC_YF_YAKLASMA_(y)Ayaz sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("yapayazmalıydık",
            "yap/FIIL yAyaz/FC_YF_YAKLASMA_(y)Ayaz mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("yapayazarmışlar",
            "yap/FIIL yAyaz/FC_YF_YAKLASMA_(y)Ayaz Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("yapayazacaktım",
            "yap/FIIL yAyaz/FC_YF_YAKLASMA_(y)Ayaz yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("yapayazıyorsanız",
            "yap/FIIL yAyaz/FC_YF_YAKLASMA_(y)Ayaz Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıAyazTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapabil", "yap/FIIL yAbil/FC_YF_YETERLILIK_(y)Abil")]
        [TestCase("yapabilseydiniz",
            "yap/FIIL yAbil/FC_YF_YETERLILIK_(y)Abil sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("yapabilmiştir",
            "yap/FIIL yAbil/FC_YF_YETERLILIK_(y)Abil mUş/FC_ZAMAN_GECMIS_mUş DUr/EKFIIL_TANIMLAMA_DUr")]
        [TestCase("yapabilecekmişsiniz",
            "yap/FIIL yAbil/FC_YF_YETERLILIK_(y)Abil yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("yapabilseydi", "yap/FIIL yAbil/FC_YF_YETERLILIK_(y)Abil sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("yapabilmeliydik",
            "yap/FIIL yAbil/FC_YF_YETERLILIK_(y)Abil mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("yapabilirmişler",
            "yap/FIIL yAbil/FC_YF_YETERLILIK_(y)Abil Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("yapabilecektim",
            "yap/FIIL yAbil/FC_YF_YETERLILIK_(y)Abil yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("yapabiliyorsanız",
            "yap/FIIL yAbil/FC_YF_YETERLILIK_(y)Abil Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıYeterlilikTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapama", "yap/FIIL yAmA/FC_YF_YETERSIZLIK_(y)AmA")]
        [TestCase("yapamasaydınız",
            "yap/FIIL yAmA/FC_YF_YETERSIZLIK_(y)AmA sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("yapamamıştır",
            "yap/FIIL yAmA/FC_YF_YETERSIZLIK_(y)AmA mUş/FC_ZAMAN_GECMIS_mUş DUr/EKFIIL_TANIMLAMA_DUr")]
        [TestCase("yapamayacakmışsınız",
            "yap/FIIL yAmA/FC_YF_YETERSIZLIK_(y)AmA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("yapamasaydı", "yap/FIIL yAmA/FC_YF_YETERSIZLIK_(y)AmA sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("yapamamalıydık",
            "yap/FIIL yAmA/FC_YF_YETERSIZLIK_(y)AmA mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("yapamazmışlar",
            "yap/FIIL yAmA/FC_YF_YETERSIZLIK_(y)AmA Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("yapamayacaktım",
            "yap/FIIL yAmA/FC_YF_YETERSIZLIK_(y)AmA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("yapamıyorsanız",
            "yap/FIIL yAmA/FC_YF_YETERSIZLIK_(y)AmA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("yapamaz", "yap/FIIL yAmA/FC_YF_YETERSIZLIK_(y)AmA Ur/FC_ZAMAN_GENIS_(U)r")]
        public void FiilYardımcıYetersizlikTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }
    }
}