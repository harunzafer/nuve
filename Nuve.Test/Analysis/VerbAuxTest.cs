using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    internal class VerbAuxTest
    {
        [TestCase("yayayım", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("yayasın", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("yayadır", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_TANIMLAMA_DUr")]
        [TestCase("yayayız", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("yayasınız", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("yayadırlar", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_TANIMLAMA_DUr EKFIIL_SAHIS_ONLAR_lAr")]
        public void EkFiilGenisZamanTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yayaydım", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BEN_m")]
        [TestCase("yayaydın", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_SEN_n")]
        [TestCase("yayaydı", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_HIKAYE_(y)DU")]
        [TestCase("yayaydık", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k")]
        [TestCase("yayaydınız", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("yayaydılar", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_ONLAR_lAr")]
        public void EkFiilGecmisDiTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("yayaymışım", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_BEN_(y)Um")
        ]
        [TestCase("yayaymışsın", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("yayaymış", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("yayaymışız", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_BIZ_(y)Uz")
        ]
        [TestCase("yayaymışsınız",
            "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("yayaymışlar", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_ONLAR_lAr"
            )]
        public void EkFiilGecmisMisTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yayaysam", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_SART_(y)sA EKFIIL_SAHIS_BEN_m")]
        [TestCase("yayaysan", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_SART_(y)sA EKFIIL_SAHIS_SEN_n")]
        [TestCase("yayaysa", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_SART_(y)sA")]
        [TestCase("yayaysak", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_SART_(y)sA EKFIIL_SAHIS_BIZ_k")]
        [TestCase("yayaysanız", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_SART_(y)sA EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("yayaysalar", "ya/UNLEM IC_HAL_YONELME_(y)A EKFIIL_SART_(y)sA EKFIIL_SAHIS_ONLAR_lAr")]
        public void EkFiilSartTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arayış", "ara/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("ödeyiş", "öde/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("yiyiş", "ye/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("deyiş", "de/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("acıyış", "acı/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("eriyiş", "eri/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("okuyuş", "oku/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("üşüyüş", "üşü/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("ediş", "et/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("atış", "at/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("kılış", "kıl/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("biliş", "bil/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("buluş", "bul/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("yüzüş", "yüz/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("oluş", "ol/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("ölüş", "öl/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("kalış", "kal/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("geliş", "gel/FIIL FIILIMSI_ISIM_(y)Uş")]
        [TestCase("yapış", "yap/FIIL FIILIMSI_ISIM_(y)Uş")]
        public void FiilimsiIsimUşTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arama", "ara/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("ödeme", "öde/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("yeme", "ye/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("deme", "de/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("acıma", "acı/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("erime", "eri/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("okuma", "oku/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("üşüme", "üşü/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("etme", "et/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("atma", "at/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("kılma", "kıl/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("bilme", "bil/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("bulma", "bul/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("yüzme", "yüz/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("olma", "ol/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("ölme", "öl/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("kalma", "kal/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("gelme", "gel/FIIL FIILIMSI_ISIM_mA")]
        [TestCase("yapma", "yap/FIIL FIILIMSI_ISIM_mA")]
        public void FiilimsiIsimMaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("aramak", "ara/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("ödemek", "öde/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("yemek", "ye/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("demek", "de/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("acımak", "acı/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("erimek", "eri/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("okumak", "oku/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("üşümek", "üşü/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("etmek", "et/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("atmak", "at/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("kılmak", "kıl/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("bilmek", "bil/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("bulmak", "bul/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("yüzmek", "yüz/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("olmak", "ol/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("ölmek", "öl/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("kalmak", "kal/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("gelmek", "gel/FIIL FIILIMSI_ISIM_mAk")]
        [TestCase("yapmak", "yap/FIIL FIILIMSI_ISIM_mAk")]
        public void FiilimsiIsimMakTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arayan", "ara/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("ödeyen", "öde/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("yiyen", "ye/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("diyen", "de/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("acıyan", "acı/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("eriyen", "eri/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("okuyan", "oku/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("üşüyen", "üşü/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("eden", "et/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("atan", "at/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("kılan", "kıl/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("bilen", "bil/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("bulan", "bul/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("yüzen", "yüz/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("olan", "ol/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("ölen", "öl/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("kalan", "kal/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("gelen", "gel/FIIL FIILIMSI_SIFAT_(y)An")]
        [TestCase("yapan", "yap/FIIL FIILIMSI_SIFAT_(y)An")]
        public void FiilimsiSıfatAnTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arayası", "ara/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("ödeyesi", "öde/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("yiyesi", "ye/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("diyesi", "de/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("acıyası", "acı/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("eriyesi", "eri/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("okuyası", "oku/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("üşüyesi", "üşü/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("edesi", "et/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("atası", "at/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("kılası", "kıl/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("bilesi", "bil/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("bulası", "bul/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("yüzesi", "yüz/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("olası", "ol/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("ölesi", "öl/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("kalası", "kal/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("gelesi", "gel/FIIL FIILIMSI_SIFAT_(y)AsI")]
        [TestCase("yapası", "yap/FIIL FIILIMSI_SIFAT_(y)AsI")]
        public void FiilimsiSıfatAsıTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("arayasıca", "ara/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("ödeyesice", "öde/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("yiyesice", "ye/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("diyesice", "de/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("acıyasıca", "acı/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("eriyesice", "eri/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("okuyasıca", "oku/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("üşüyesice", "üşü/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("edesice", "et/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("atasıca", "at/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("kılasıca", "kıl/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("bilesice", "bil/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("bulasıca", "bul/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("yüzesice", "yüz/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("olasıca", "ol/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("ölesice", "öl/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("kalasıca", "kal/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("gelesice", "gel/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        [TestCase("yapasıca", "yap/FIIL FIILIMSI_SIFAT_(y)AsIcA")]
        public void FiilimsiSıfatAsıcaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("aradığım", "ara/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("ödediğim", "öde/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("yediğim", "ye/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("dediğim", "de/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("acıdığım", "acı/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("eridiğim", "eri/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("okuduğum", "oku/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("üşüdüğüm", "üşü/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("ettiğim", "et/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("attığım", "at/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("kıldığım", "kıl/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("bildiğim", "bil/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("bulduğum", "bul/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("yüzdüğüm", "yüz/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("olduğum", "ol/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("öldüğüm", "öl/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("kaldığım", "kal/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("geldiğim", "gel/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        [TestCase("yaptığım", "yap/FIIL FIILIMSI_SIFAT_DUK IC_SAHIPLIK_BEN_(U)m")]
        public void FiilimsiSıfatDukTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("aramaz", "ara/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("ödemez", "öde/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("yemez", "ye/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("demez", "de/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("acımaz", "acı/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("erimez", "eri/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("okumaz", "oku/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("üşümez", "üşü/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("etmez", "et/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("atmaz", "at/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("kılmaz", "kıl/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("bilmez", "bil/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("bulmaz", "bul/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("yüzmez", "yüz/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("olmaz", "ol/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("ölmez", "öl/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("kalmaz", "kal/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("gelmez", "gel/FIIL FIILIMSI_SIFAT_mAz")]
        [TestCase("yapmaz", "yap/FIIL FIILIMSI_SIFAT_mAz")]
        public void FiilimsiSıfatMazTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("aramış", "ara/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("ödemiş", "öde/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("yemiş", "ye/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("demiş", "de/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("acımış", "acı/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("erimiş", "eri/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("okumuş", "oku/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("üşümüş", "üşü/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("etmiş", "et/FIIL FIILIMSI_SIFAT_mUş")]
        [TestCase("atmış", "at/FIIL FIILIMSI_SIFAT_mUş")]
        [TestCase("kılmış", "kıl/FIIL FIILIMSI_SIFAT_mUş")]
        [TestCase("bilmiş", "bil/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("bulmuş", "bul/FIIL FIILIMSI_SIFAT_mUş")]
        [TestCase("yüzmüş", "yüz/FIIL FIILIMSI_SIFAT_mUş")]
        [TestCase("olmuş", "ol/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("ölmüş", "öl/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("kalmış", "kal/FIIL FIILIMSI_SIFAT_mUş")]
        [TestCase("gelmiş", "gel/FIIL FC_ZAMAN_GECMIS_mUş")]
        [TestCase("yapmış", "yap/FIIL FC_ZAMAN_GECMIS_mUş")]
        public void FiilimsiSıfatMusTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("araya", new[] {"ara/FIIL FIILIMSI_ZARF_(y)A"})]
        [TestCase("ödeye", new[] {"öde/FIIL FIILIMSI_ZARF_(y)A"})]
        [TestCase("yiye", new[] {"ye/FIIL FIILIMSI_ZARF_(y)A"})]
        [TestCase("diye", new[] {"de/FIIL FIILIMSI_ZARF_(y)A"})]
        [TestCase("ola", new[] {"ol/FIIL FIILIMSI_ZARF_(y)A"})]
        [TestCase("öle", new[] {"öl/FIIL FIILIMSI_ZARF_(y)A"})]
        public void FiilimsiZarfATest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }

        [TestCase("arayalı", "ara/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("ödeyeli", "öde/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("yiyeli", "ye/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("diyeli", "de/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("acıyalı", "acı/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("eriyeli", "eri/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("okuyalı", "oku/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("üşüyeli", "üşü/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("edeli", "et/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("atalı", "at/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("kılalı", "kıl/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("bileli", "bil/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("bulalı", "bul/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("yüzeli", "yüz/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("olalı", "ol/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("öleli", "öl/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("kalalı", "kal/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("geleli", "gel/FIIL FIILIMSI_ZARF_(y)AlI")]
        [TestCase("yapalı", "yap/FIIL FIILIMSI_ZARF_(y)AlI")]
        public void FiilimsiZarfAlıTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arayarak", "ara/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("ödeyerek", "öde/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("yiyerek", "ye/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("diyerek", "de/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("acıyarak", "acı/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("eriyerek", "eri/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("okuyarak", "oku/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("üşüyerek", "üşü/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("ederek", "et/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("atarak", "at/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("kılarak", "kıl/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("bilerek", "bil/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("bularak", "bul/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("yüzerek", "yüz/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("olarak", "ol/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("ölerek", "öl/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("kalarak", "kal/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("gelerek", "gel/FIIL FIILIMSI_ZARF_(y)ArAk")]
        [TestCase("yaparak", "yap/FIIL FIILIMSI_ZARF_(y)ArAk")]
        public void FiilimsiZarfArakTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("arayasıya", "ara/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("ödeyesiye", "öde/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("yiyesiye", "ye/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("diyesiye", "de/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("acıyasıya", "acı/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("eriyesiye", "eri/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("okuyasıya", "oku/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("üşüyesiye", "üşü/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("edesiye", "et/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("atasıya", "at/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("kılasıya", "kıl/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("bilesiye", "bil/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("bulasıya", "bul/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("yüzesiye", "yüz/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("olasıya", "ol/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("ölesiye", "öl/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("kalasıya", "kal/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("gelesiye", "gel/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        [TestCase("yapasıya", "yap/FIIL FIILIMSI_ZARF_(y)AsIyA")]
        public void FiilimsiZarfAsıyaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("arayıp", "ara/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("ödeyip", "öde/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("yiyip", "ye/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("deyip", "de/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("acıyıp", "acı/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("eriyip", "eri/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("okuyup", "oku/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("üşüyüp", "üşü/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("edip", "et/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("atıp", "at/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("kılıp", "kıl/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("bilip", "bil/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("bulup", "bul/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("yüzüp", "yüz/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("olup", "ol/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("ölüp", "öl/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("kalıp", "kal/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("gelip", "gel/FIIL FIILIMSI_ZARF_(y)Up")]
        [TestCase("yapıp", "yap/FIIL FIILIMSI_ZARF_(y)Up")]
        public void FiilimsiZarfUpTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("ararcasına", "ara/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("ödercesine", "öde/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("yercesine", "ye/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("dercesine", "de/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("acırcasına", "acı/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("erircesine", "eri/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("okurcasına", "oku/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("üşürcesine", "üşü/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("edercesine", "et/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("atarcasına", "at/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("kılarcasına", "kıl/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("bilircesine", "bil/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("bulurcasına", "bul/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("yüzercesine", "yüz/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("olurcasına", "ol/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("ölürcesine", "öl/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("kalırcasına", "kal/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("gelircesine", "gel/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        [TestCase("yaparcasına", "yap/FIIL FC_ZAMAN_GENIS_(U)r FIILIMSI_ZARF_CAsInA")]
        public void FiilimsiZarfCasınaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("aradıkça", "ara/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("ödedikçe", "öde/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("yedikçe", "ye/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("dedikçe", "de/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("acıdıkça", "acı/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("eridikçe", "eri/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("okudukça", "oku/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("üşüdükçe", "üşü/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("ettikçe", "et/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("attıkça", "at/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("kıldıkça", "kıl/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("bildikçe", "bil/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("buldukça", "bul/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("yüzdükçe", "yüz/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("oldukça", "ol/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("öldükçe", "öl/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("kaldıkça", "kal/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("geldikçe", "gel/FIIL FIILIMSI_ZARF_DUkçA")]
        [TestCase("yaptıkça", "yap/FIIL FIILIMSI_ZARF_DUkçA")]
        public void FiilimsiZarfDıkcaTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("aramadan", "ara/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("ödemeden", "öde/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("yemeden", "ye/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("demeden", "de/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("acımadan", "acı/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("erimeden", "eri/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("okumadan", "oku/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("üşümeden", "üşü/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("etmeden", "et/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("atmadan", "at/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("kılmadan", "kıl/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("bilmeden", "bil/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("bulmadan", "bul/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("yüzmeden", "yüz/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("olmadan", "ol/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("ölmeden", "öl/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("kalmadan", "kal/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("gelmeden", "gel/FIIL FIILIMSI_ZARF_mAdAn")]
        [TestCase("yapmadan", "yap/FIIL FIILIMSI_ZARF_mAdAn")]
        public void FiilimsiZarfMadanTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("aramaksızın", "ara/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("ödemeksizin", "öde/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("yemeksizin", "ye/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("demeksizin", "de/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("acımaksızın", "acı/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("erimeksizin", "eri/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("okumaksızın", "oku/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("üşümeksizin", "üşü/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("etmeksizin", "et/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("atmaksızın", "at/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("kılmaksızın", "kıl/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("bilmeksizin", "bil/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("bulmaksızın", "bul/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("yüzmeksizin", "yüz/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("olmaksızın", "ol/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("ölmeksizin", "öl/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("kalmaksızın", "kal/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("gelmeksizin", "gel/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        [TestCase("yapmaksızın", "yap/FIIL FIILIMSI_ISIM_mAk FIILIMSI_ZARF_sIzIn")]
        public void FiilimsiZarfMaksızınTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("geledur", "gel/FIIL FC_YF_SUREKLILIK_(y)Adur")]
        [TestCase("geledursun", "gel/FIIL FC_YF_SUREKLILIK_(y)Adur FC_KIP_EMIR_sUn")]
        [TestCase("geledurdum", "gel/FIIL FC_YF_SUREKLILIK_(y)Adur FC_ZAMAN_GECMIS_DU EKFIIL_SAHIS_BEN_m")]
        [TestCase("geledurmuşsun",
            "gel/FIIL FC_YF_SUREKLILIK_(y)Adur FC_ZAMAN_GECMIS_mUş EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("geledursaydı", "gel/FIIL FC_YF_SUREKLILIK_(y)Adur FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU")]
        [TestCase("geledurmalıydık",
            "gel/FIIL FC_YF_SUREKLILIK_(y)Adur FC_KIP_GEREKLILIK_mAlI EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("geledururmuşlar",
            "gel/FIIL FC_YF_SUREKLILIK_(y)Adur FC_ZAMAN_GENIS_(U)r EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("geleduracaktım",
            "gel/FIIL FC_YF_SUREKLILIK_(y)Adur FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("geleduruyorsanız",
            "gel/FIIL FC_YF_SUREKLILIK_(y)Adur FC_ZAMAN_SIMDIKI_(U)yor EKFIIL_SART_(y)sA EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıAdurTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("olagel", "ol/FIIL FC_YF_SUREKLILIK_(y)Agel")]
        [TestCase("olagelseydiniz",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agel FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("olagelmiştir",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agel FC_ZAMAN_GECMIS_mUş EKFIIL_TANIMLAMA_DUr")]
        [TestCase("olagelecekmişsiniz",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agel FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("olagelseydi", "ol/FIIL FC_YF_SUREKLILIK_(y)Agel FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU")]
        [TestCase("olagelmeliydik",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agel FC_KIP_GEREKLILIK_mAlI EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("olagelirmişler",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agel FC_ZAMAN_GENIS_(U)r EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("olagelecektim",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agel FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("olageliyorsanız",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agel FC_ZAMAN_SIMDIKI_(U)yor EKFIIL_SART_(y)sA EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıAgelTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("olagör", "ol/FIIL FC_YF_SUREKLILIK_(y)Agör")]
        [TestCase("olagörseydiniz",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agör FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("olagörmüştür",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agör FC_ZAMAN_GECMIS_mUş EKFIIL_TANIMLAMA_DUr")]
        [TestCase("olagörecekmişsiniz",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agör FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("olagörseydi", "ol/FIIL FC_YF_SUREKLILIK_(y)Agör FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU")]
        [TestCase("olagörmeliydik",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agör FC_KIP_GEREKLILIK_mAlI EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("olagörürmüşler",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agör FC_ZAMAN_GENIS_(U)r EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("olagörecektim",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agör FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("olagörüyorsanız",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Agör FC_ZAMAN_SIMDIKI_(U)yor EKFIIL_SART_(y)sA EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıAgörTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("olakal", "ol/FIIL FC_YF_SUREKLILIK_(y)Akal")]
        [TestCase("olakalsaydınız",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Akal FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("olakalmıştır",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Akal FC_ZAMAN_GECMIS_mUş EKFIIL_TANIMLAMA_DUr")]
        [TestCase("olakalacakmışsınız",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Akal FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("olakalsaydı", "ol/FIIL FC_YF_SUREKLILIK_(y)Akal FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU")]
        [TestCase("olakalmalıydık",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Akal FC_KIP_GEREKLILIK_mAlI EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("olakalırmışlar",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Akal FC_ZAMAN_GENIS_(U)r EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("olakalacaktım",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Akal FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("olakalıyorsanız",
            "ol/FIIL FC_YF_SUREKLILIK_(y)Akal FC_ZAMAN_SIMDIKI_(U)yor EKFIIL_SART_(y)sA EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıAkalTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapıver", "yap/FIIL FC_YF_TEZLIK_(y)Uver")]
        [TestCase("yapıverseydiniz",
            "yap/FIIL FC_YF_TEZLIK_(y)Uver FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("yapıvermiştir",
            "yap/FIIL FC_YF_TEZLIK_(y)Uver FC_ZAMAN_GECMIS_mUş EKFIIL_TANIMLAMA_DUr")]
        [TestCase("yapıverecekmişsiniz",
            "yap/FIIL FC_YF_TEZLIK_(y)Uver FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("yapıverseydi", "yap/FIIL FC_YF_TEZLIK_(y)Uver FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU")]
        [TestCase("yapıvermeliydik",
            "yap/FIIL FC_YF_TEZLIK_(y)Uver FC_KIP_GEREKLILIK_mAlI EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("yapıverirmişler",
            "yap/FIIL FC_YF_TEZLIK_(y)Uver FC_ZAMAN_GENIS_(U)r EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("yapıverecektim",
            "yap/FIIL FC_YF_TEZLIK_(y)Uver FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("yapıveriyorsanız",
            "yap/FIIL FC_YF_TEZLIK_(y)Uver FC_ZAMAN_SIMDIKI_(U)yor EKFIIL_SART_(y)sA EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıUverTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapayaz", "yap/FIIL FC_YF_YAKLASMA_(y)Ayaz")]
        [TestCase("yapayazsaydınız",
            "yap/FIIL FC_YF_YAKLASMA_(y)Ayaz FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_SIZ_nUz")
        ]
        [TestCase("yapayazmıştır",
            "yap/FIIL FC_YF_YAKLASMA_(y)Ayaz FC_ZAMAN_GECMIS_mUş EKFIIL_TANIMLAMA_DUr")]
        [TestCase("yapayazacakmışsınız",
            "yap/FIIL FC_YF_YAKLASMA_(y)Ayaz FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("yapayazsaydı", "yap/FIIL FC_YF_YAKLASMA_(y)Ayaz FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU")]
        [TestCase("yapayazmalıydık",
            "yap/FIIL FC_YF_YAKLASMA_(y)Ayaz FC_KIP_GEREKLILIK_mAlI EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("yapayazarmışlar",
            "yap/FIIL FC_YF_YAKLASMA_(y)Ayaz FC_ZAMAN_GENIS_(U)r EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("yapayazacaktım",
            "yap/FIIL FC_YF_YAKLASMA_(y)Ayaz FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("yapayazıyorsanız",
            "yap/FIIL FC_YF_YAKLASMA_(y)Ayaz FC_ZAMAN_SIMDIKI_(U)yor EKFIIL_SART_(y)sA EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıAyazTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapabil", "yap/FIIL FC_YF_YETERLILIK_(y)Abil")]
        [TestCase("yapabilseydiniz",
            "yap/FIIL FC_YF_YETERLILIK_(y)Abil FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("yapabilmiştir",
            "yap/FIIL FC_YF_YETERLILIK_(y)Abil FC_ZAMAN_GECMIS_mUş EKFIIL_TANIMLAMA_DUr")]
        [TestCase("yapabilecekmişsiniz",
            "yap/FIIL FC_YF_YETERLILIK_(y)Abil FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("yapabilseydi", "yap/FIIL FC_YF_YETERLILIK_(y)Abil FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU")]
        [TestCase("yapabilmeliydik",
            "yap/FIIL FC_YF_YETERLILIK_(y)Abil FC_KIP_GEREKLILIK_mAlI EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("yapabilirmişler",
            "yap/FIIL FC_YF_YETERLILIK_(y)Abil FC_ZAMAN_GENIS_(U)r EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("yapabilecektim",
            "yap/FIIL FC_YF_YETERLILIK_(y)Abil FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("yapabiliyorsanız",
            "yap/FIIL FC_YF_YETERLILIK_(y)Abil FC_ZAMAN_SIMDIKI_(U)yor EKFIIL_SART_(y)sA EKFIIL_SAHIS_SIZ_nUz"
            )]
        public void FiilYardımcıYeterlilikTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapama", "yap/FIIL FC_YF_YETERSIZLIK_(y)AmA")]
        [TestCase("yapamasaydınız",
            "yap/FIIL FC_YF_YETERSIZLIK_(y)AmA FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("yapamamıştır",
            "yap/FIIL FC_YF_YETERSIZLIK_(y)AmA FC_ZAMAN_GECMIS_mUş EKFIIL_TANIMLAMA_DUr")]
        [TestCase("yapamayacakmışsınız",
            "yap/FIIL FC_YF_YETERSIZLIK_(y)AmA FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_SIZ_sUnUz"
            )]
        [TestCase("yapamasaydı", "yap/FIIL FC_YF_YETERSIZLIK_(y)AmA FC_KIP_DILEK_sA EKFIIL_HIKAYE_(y)DU")]
        [TestCase("yapamamalıydık",
            "yap/FIIL FC_YF_YETERSIZLIK_(y)AmA FC_KIP_GEREKLILIK_mAlI EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k"
            )]
        [TestCase("yapamazmışlar",
            "yap/FIIL FC_YF_YETERSIZLIK_(y)AmA FC_ZAMAN_GENIS_(U)r EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_ONLAR_lAr"
            )]
        [TestCase("yapamayacaktım",
            "yap/FIIL FC_YF_YETERSIZLIK_(y)AmA FC_ZAMAN_GELECEK_(y)AcAK EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BEN_m"
            )]
        [TestCase("yapamıyorsanız",
            "yap/FIIL FC_YF_YETERSIZLIK_(y)AmA FC_ZAMAN_SIMDIKI_(U)yor EKFIIL_SART_(y)sA EKFIIL_SAHIS_SIZ_nUz"
            )]
        [TestCase("yapamaz", "yap/FIIL FC_YF_YETERSIZLIK_(y)AmA FC_ZAMAN_GENIS_(U)r")]
        public void FiilYardımcıYetersizlikTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }
    }
}