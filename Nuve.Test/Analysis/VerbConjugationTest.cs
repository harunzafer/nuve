using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    [TestFixture]
    internal class VerbConjugationTest
    {
      
        [TestCase("geldim", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("geldin", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("geldi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU")]
        [TestCase("geldik", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("geldiniz", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("geldiler", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GecmisDiOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmedim", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmedin", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmedi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU")]
        [TestCase("gelmedik", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmediniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmediler", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]      
        public void GecmisDiOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geldim_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("geldin_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("geldi_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU")]
        [TestCase("geldik_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("geldiniz_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("geldiler_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GecmisDiSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmedim_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelmedin_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelmedi_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU")]
        [TestCase("gelmedik_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelmediniz_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelmediler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GecmisDiSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmişim", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmişsin", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmiş", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("gelmişiz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmişsiniz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmişler", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GecmisMisOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmemişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmemiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş")]
        [TestCase("gelmemişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmemişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmemişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GecmisMisOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiş_miyim", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmiş_misin", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmiş_mi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU")]
        [TestCase("gelmiş_miyiz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmiş_misiniz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmişler_mi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GecmisMisSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemiş_miyim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmemiş_misin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmemiş_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU")]
        [TestCase("gelmemiş_miyiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmemiş_misiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmemişler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GecmisMisSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geliyorum", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("geliyorsun", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("geliyor", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("geliyoruz", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("geliyorsunuz", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("geliyorlar", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void SimdikiZamanOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiyorum", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmiyorsun", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmiyor", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("gelmiyoruz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmiyorsunuz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmiyorlar", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void SimdikiZamanOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geliyor_muyum", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("geliyor_musun", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("geliyor_mu", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU")]
        [TestCase("geliyor_muyuz", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("geliyor_musunuz", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("geliyorlar_mı", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void SimdikiZamanSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiyor_muyum", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmiyor_musun", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmiyor_mu", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU")]
        [TestCase("gelmiyor_muyuz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmiyor_musunuz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmiyorlar_mı", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void SimdikiZamanSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("arıyor", "ara/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("ödüyor", "öde/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("yiyor", "ye/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("diyor", "de/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("acıyor", "acı/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("eriyor", "er/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("okuyor", "oku/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("üşüyor", "üşü/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("ediyor", "et/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("atıyor", "at/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("kılıyor", "kıl/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("biliyor", "bil/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("buluyor", "bul/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("yüzüyor", "yüz/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("oluyor", "ol/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("ölüyor", "öl/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("kalıyor", "kal/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("geliyor", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("yapıyor", "yap/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("gözlüyor", "göz/ISIM lA/IY_FIIL_lA Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        [TestCase("kolluyor", "kol/ISIM lA/IY_FIIL_lA Uyor/FC_ZAMAN_SIMDIKI_(U)yor")]
        public void SimdikiZamanOrtografiTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("geleceğim", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("geleceksin", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelecek", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK")]
        [TestCase("geleceğiz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("geleceksiniz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelecekler", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GelecekOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyeceğim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeyeceksin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeyecek", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK")]
        [TestCase("gelmeyeceğiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmeyeceksiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeyecekler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GelecekOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelecek_miyim", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelecek_misin", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelecek_mi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU")]
        [TestCase("gelecek_miyiz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelecek_misiniz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelecekler_mi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GelecekSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyecek_miyim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU " +
                                      "yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeyecek_misin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU " +
                                      "sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeyecek_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU")]
        [TestCase("gelmeyecek_miyiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU " +
                                      "yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmeyecek_misiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU " +
                                        "sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeyecekler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK " +
                                      "lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GelecekSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yaparım", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("yaparsın", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("yapar", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("yaparız", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("yaparsınız", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("yaparlar", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GenisOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapmam", "yap/FIIL mA/FY_OLUMSUZLUK_mA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("yapmazsın", "yap/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("yapmaz", "yap/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("yapmayız", "yap/FIIL mA/FY_OLUMSUZLUK_mA yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("yapmazsınız", "yap/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("yapmazlar", "yap/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GenisOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapar_mıyım", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("yapar_mısın", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("yapar_mı", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU")]
        [TestCase("yapar_mıyız", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("yapar_mısınız", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("yaparlar_mı", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GenisSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("yapmaz_mıyım", "yap/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("yapmaz_mısın", "yap/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("yapmaz_mı", "yap/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU")]
        [TestCase("yapmaz_mıyız", "yap/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("yapmaz_mısınız", "yap/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("yapmazlar_mı", "yap/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GenisSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("arar", "ara/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("öder", "öde/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("yer", "ye/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("der", "de/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("acır", "acı/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("erir", "eri/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("okur", "oku/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("üşür", "üşü/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("eder", "et/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("atar", "at/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("kılar", "kıl/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("bilir", "bil/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("bulur", "bul/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("yüzer", "yüz/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("olur", "ol/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("ölür", "öl/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("kalır", "kal/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("gelir", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("yapar", "yap/FIIL Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("gözler", "göz/ISIM lA/IY_FIIL_lA Ur/FC_ZAMAN_GENIS_(U)r")]
        [TestCase("kollar", "kol/ISIM lA/IY_FIIL_lA Ur/FC_ZAMAN_GENIS_(U)r")]
        public void GenisOrtografiTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }


        [TestCase("gelmeliyim", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmelisin", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeli", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI")]
        [TestCase("gelmeliyiz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmelisiniz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeliler", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GereklilikOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemeliyim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmemelisin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmemeli", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI")]
        [TestCase("gelmemeliyiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmemelisiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmemeliler", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GereklilikOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeli_miyim", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeli_misin", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeli_mi", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU")]
        [TestCase("gelmeli_miyiz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmeli_misiniz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeliler_mi", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GereklilikSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemeli_miyim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmemeli_misin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmemeli_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU")]
        [TestCase("gelmemeli_miyiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmemeli_misiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmemeliler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GereklilikSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelsem", "gel/FIIL sA/FC_KIP_DILEK_sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelsen", "gel/FIIL sA/FC_KIP_DILEK_sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelse", "gel/FIIL sA/FC_KIP_DILEK_sA")]
        [TestCase("gelsek", "gel/FIIL sA/FC_KIP_DILEK_sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelseniz", "gel/FIIL sA/FC_KIP_DILEK_sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelseler", "gel/FIIL sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void DilekOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmesem", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmesen", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmese", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA")]
        [TestCase("gelmesek", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeseniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmeseler", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void DilekOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelsem_mi", "gel/FIIL sA/FC_KIP_DILEK_sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelsen_mi", "gel/FIIL sA/FC_KIP_DILEK_sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelse_mi", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU")]
        [TestCase("gelsek_mi", "gel/FIIL sA/FC_KIP_DILEK_sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelseniz_mi", "gel/FIIL sA/FC_KIP_DILEK_sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelseler_mi", "gel/FIIL sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void DilekSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmesem_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelmesen_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelmese_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU")]
        [TestCase("gelmesek_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelmeseniz_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelmeseler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void DilekSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geleyim", "gel/FIIL yA/FC_KIP_ISTEK_(y)A yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelesin", "gel/FIIL yA/FC_KIP_ISTEK_(y)A sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gele", "gel/FIIL yA/FC_KIP_ISTEK_(y)A")]
        [TestCase("gelelim", "gel/FIIL yA/FC_KIP_ISTEK_(y)A k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelesiniz", "gel/FIIL yA/FC_KIP_ISTEK_(y)A sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("geleler", "gel/FIIL yA/FC_KIP_ISTEK_(y)A lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelsene", "gel/FIIL sAnA/FC_KIP_ISTEK_sAnA")]
        [TestCase("gelsenize", "gel/FIIL sAnIzA/FC_KIP_ISTEK_sAnIzA")]
        public void IstekOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyeyim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeyesin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeye", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A")]
        [TestCase("gelmeyelim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeyesiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeyeler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmesene", "gel/FIIL mA/FY_OLUMSUZLUK_mA sAnA/FC_KIP_ISTEK_sAnA")]
        [TestCase("gelmesenize", "gel/FIIL mA/FY_OLUMSUZLUK_mA sAnIzA/FC_KIP_ISTEK_sAnIzA")]
        public void IstekOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geleyim_mi", "gel/FIIL yA/FC_KIP_ISTEK_(y)A yUm/EKFIIL_SAHIS_BEN_(y)Um _mU/SORU_mU")]
        [TestCase("gelelim_mi", "gel/FIIL yA/FC_KIP_ISTEK_(y)A k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        public void IstekSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyeyim_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A yUm/EKFIIL_SAHIS_BEN_(y)Um _mU/SORU_mU")]
        [TestCase("gelmeyelim_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        public void IstekSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gel", "gel/FIIL")]
        [TestCase("gelsin", "gel/FIIL sUn/FC_KIP_EMIR_sUn")]
        [TestCase("gelin", "gel/FIIL yUn/FC_KIP_EMIR_(y)Un")]
        [TestCase("geliniz", "gel/FIIL yUnUz/FC_KIP_EMIR_(y)UnUz")]
        [TestCase("gelsinler", "gel/FIIL sUnlAr/FC_KIP_EMIR_sUnlAr")]
        public void EmirOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelme", "gel/FIIL mA/FY_OLUMSUZLUK_mA")]
        [TestCase("gelmeyin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yUn/FC_KIP_EMIR_(y)Un")]
        [TestCase("gelmesin", "gel/FIIL mA/FY_OLUMSUZLUK_mA sUn/FC_KIP_EMIR_sUn")]
        [TestCase("gelmeyiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yUnUz/FC_KIP_EMIR_(y)UnUz")]
        [TestCase("gelmesinler", "gel/FIIL mA/FY_OLUMSUZLUK_mA sUnlAr/FC_KIP_EMIR_sUnlAr")]
        public void EmirOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelsin_mi", "gel/FIIL sUn/FC_KIP_EMIR_sUn _mU/SORU_mU")]
        [TestCase("gelsinler_mi", "gel/FIIL sUnlAr/FC_KIP_EMIR_sUnlAr _mU/SORU_mU")]
        public void EmirSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmesin_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sUn/FC_KIP_EMIR_sUn _mU/SORU_mU")]
        [TestCase("gelmesinler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sUnlAr/FC_KIP_EMIR_sUnlAr _mU/SORU_mU")]
        public void EmirOlumsuzSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geldiydim", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("geldiydin", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("geldiydi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("geldiydik", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("geldiydiniz", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("geldiydiler", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GecmisDiHikayeOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmediydim", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmediydin", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmediydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmediydik", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmediydiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmediydiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GecmisDiHikayeOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geldi_miydim", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("geldi_miydin", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("geldi_miydi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("geldi_miydik", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("geldi_miydiniz", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("geldi_miydiler", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("geldiler_miydi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GecmisDiHikayeSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmedi_miydim", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmedi_miydin", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmedi_miydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmedi_miydik", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmedi_miydiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmedi_miydiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmediler_miydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GecmisDiHikayeSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiştim", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmiştin", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmişti", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmiştik", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmiştiniz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmiştiler", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmişlerdi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GecmisMisHikayeOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemiştim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmemiştin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmemişti", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmemiştik", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmemiştiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmemiştiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmemişlerdi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GecmisMisHikayeOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiş_miydim", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmiş_miydin", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmiş_miydi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmiş_miydik", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmiş_miydiniz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmişler_miydi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GecmisMisHikayeSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geliyordum", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("geliyordun", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("geliyordu", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("geliyorduk", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("geliyordunuz", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("geliyordular", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("geliyorlardı", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr yDU/EKFIIL_HIKAYE_(y)DU")]
        public void SimdikiHikayeOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiyordum", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmiyordun", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmiyordu", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmiyorduk", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmiyordunuz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmiyordular", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmiyorlardı", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr yDU/EKFIIL_HIKAYE_(y)DU")]
        public void SimdikiHikayeOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geliyor_muydum", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("geliyor_muydun", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("geliyor_muydu", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("geliyor_muyduk", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("geliyor_muydunuz", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("geliyor_muydular", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("geliyorlar_mıydı", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void SimdikiHikayeSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiyor_muydum", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmiyor_muydun", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmiyor_muydu", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmiyor_muyduk", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmiyor_muydunuz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("geliyor_muydular", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmiyorlar_mıydı", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void SimdikiHikayeSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelecektim", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelecektin", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelecekti", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelecektik", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelecektiniz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelecektiler", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("geleceklerdi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GelecekHikayeOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyecektim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmeyecektin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmeyecekti", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmeyecektik", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeyecektiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmeyecektiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmeyeceklerdi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GelecekHikayeOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelecek_miydim", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelecek_miydin", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelecek_miydi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelecek_miydik", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelecek_miydiniz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelecek_miydiler", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelecekler_miydi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GelecekHikayeSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyecek_miydim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmeyecek_miydin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmeyecek_miydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmeyecek_miydik", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeyecek_miydiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmeyecek_miydiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmeyecekler_miydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GelecekHikayeSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gezerdim", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gezerdin", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gezerdi", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gezerdik", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gezerdiniz", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gezerdiler", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gezerlerdi", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GenisHikayeOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gezmezdim", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gezmezdin", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gezmezdi", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gezmezdik", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gezmezdiniz", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gezmezdiler", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gezmezlerdi", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GenisHikayeOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gezer_miydim", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gezer_miydin", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gezer_miydi", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gezer_miydik", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gezer_miydiniz", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gezer_miydiler", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gezerler_miydi", "gez/FIIL Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GenisHikayeSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gezmez_miydim", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gezmez_miydin", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gezmez_miydi", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gezmez_miydik", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gezmez_miydiniz", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gezmez_miydiler", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gezmezler_miydi", "gez/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void GenisHikayeSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeliydim", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmeliydin", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmeliydi", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmeliydik", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeliydiniz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmeliydiler", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GereklilikHikayeOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemeliydim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmemeliydin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmemeliydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmemeliydik", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmemeliydiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmemeliydiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GereklilikHikayeOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeli_miydim", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmeli_miydin", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmeli_miydi", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmeli_miydik", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeli_miydiniz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmeli_miydiler", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GereklilikHikayeSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemeli_miydim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmemeli_miydin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmemeli_miydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmemeli_miydik", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmemeli_miydiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmemeli_miydiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GereklilikHikayeSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelseydim", "gel/FIIL sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelseydin", "gel/FIIL sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelseydi", "gel/FIIL sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelseydik", "gel/FIIL sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelseydiniz", "gel/FIIL sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelseydiler", "gel/FIIL sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelselerdi", "gel/FIIL sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr yDU/EKFIIL_HIKAYE_(y)DU")]
        public void DilekHikayeOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeseydim", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmeseydin", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmeseydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmeseydik", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeseydiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmeseydiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmeselerdi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr yDU/EKFIIL_HIKAYE_(y)DU")]
        public void DilekHikayeOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelse_miydim", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelse_miydin", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelse_miydi", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelse_miydik", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelse_miydiniz", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelse_miydiler", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelseler_miydi", "gel/FIIL sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void DilekHikayeSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmese_miydim", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmese_miydin", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmese_miydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmese_miydik", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmese_miydiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmese_miydiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmeseler_miydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        public void DilekHikayeSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geleydim", "gel/FIIL yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("geleydin", "gel/FIIL yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("geleydi", "gel/FIIL yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("geleydik", "gel/FIIL yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("geleydiniz", "gel/FIIL yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("geleydiler", "gel/FIIL yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void IstekHikayeOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyeydim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmeyeydin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmeyeydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmeyeydik", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeyeydiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmeyeydiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void IstekHikayeOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gele_miydim", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gele_miydin", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gele_miydi", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gele_miydik", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gele_miydiniz", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gele_miydiler", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void IstekHikayeSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeye_miydim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmeye_miydin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmeye_miydi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU")]
        [TestCase("gelmeye_miydik", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeye_miydiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmeye_miydiler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU yDU/EKFIIL_HIKAYE_(y)DU lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void IstekHikayeSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmişmişim", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmişmişsin", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmişmiş", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmişmişiz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmişmişsiniz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmişmişler", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmişlermiş", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GecmisMisRivayetOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemişmişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmemişmişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmemişmiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmemişmişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmemişmişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmemişmişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmemişlermiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GecmisMisRivayetOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiş_miymişim", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmiş_miymişsin", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmiş_miymiş", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmiş_miymişiz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmiş_miymişsiniz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmişler_miymiş", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GecmisMisRivayetSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemiş_miymişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmemiş_miymişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmemiş_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmemiş_miymişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmemiş_miymişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmemişler_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GecmisMisRivayetSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geliyormuşum", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("geliyormuşsun", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("geliyormuş", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("geliyormuşuz", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("geliyormuşsunuz", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("geliyormuşlar", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("geliyorlarmış", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void SimdikiRivayetOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiyormuşum", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmiyormuşsun", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmiyormuş", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmiyormuşuz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmiyormuşsunuz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmiyormuşlar", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmiyorlarmış", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void SimdikiRivayetOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geliyor_muymuşum", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("geliyor_muymuşsun", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("geliyor_muymuş", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("geliyor_muymuşuz", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("geliyor_muymuşsunuz", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("geliyor_muymuşlar", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("geliyorlar_mıymış", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void SimdikiRivayetSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiyor_muymuşum", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmiyor_muymuşsun", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmiyor_muymuş", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmiyor_muymuşuz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmiyor_muymuşsunuz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmiyor_muymuşlar", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmiyorlar_mıymış", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void SimdikiRivayetSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelecekmişim", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelecekmişsin", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelecekmiş", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelecekmişiz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelecekmişsiniz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelecekmişler", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("geleceklermiş", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GelecekRivayetOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyecekmişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeyecekmişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeyecekmiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmeyecekmişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmeyecekmişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeyecekmişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmeyeceklermiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GelecekRivayetOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelecek_miymişim", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelecek_miymişsin", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelecek_miymiş", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelecek_miymişiz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelecek_miymişsiniz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelecek_miymişler", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelecekler_miymiş", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GelecekRivayetSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyecek_miymişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeyecek_miymişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeyecek_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmeyecek_miymişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmeyecek_miymişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeyecek_miymişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmeyecekler_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GelecekRivayetSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelirmişim", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelirmişsin", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelirmiş", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelirmişiz", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelirmişsiniz", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelirmişler", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelirlermiş", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GenisRivayetOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmezmişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmezmişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmezmiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmezmişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmezmişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmezmişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmezlermiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GenisRivayetOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelir_miymişim", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelir_miymişsin", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelir_miymiş", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelir_miymişiz", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelir_miymişsiniz", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelir_miymişler", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelirler_miymiş", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GenisRivayetSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmez_miymişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmez_miymişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmez_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmez_miymişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmez_miymişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmez_miymişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmezler_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GenisRivayetSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeliymişim", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeliymişsin", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeliymiş", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmeliymişiz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmeliymişsiniz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeliymişler", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmelilermiş", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GereklilikRivayetOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemeliymişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmemeliymişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmemeliymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmemeliymişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmemeliymişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmemeliymişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmemelilermiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GereklilikRivayetOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeli_miymişim", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeli_miymişsin", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeli_miymiş", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmeli_miymişiz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmeli_miymişsiniz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeli_miymişler", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmeliler_miymiş", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GereklilikRivayetSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemeli_miymişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmemeli_miymişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmemeli_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmemeli_miymişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmemeli_miymişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmemeli_miymişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmemeliler_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void GereklilikRivayetSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelseymişim", "gel/FIIL sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelseymişsin", "gel/FIIL sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelseymiş", "gel/FIIL sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelseymişiz", "gel/FIIL sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelseymişsiniz", "gel/FIIL sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelseymişler", "gel/FIIL sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelselermiş", "gel/FIIL sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void DilekRivayetOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeseymişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeseymişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeseymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmeseymişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmeseymişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeseymişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmeselermiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void DilekRivayetOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelse_miymişim", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelse_miymişsin", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelse_miymiş", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelse_miymişiz", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelse_miymişsiniz", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelse_miymişler", "gel/FIIL sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelseler_miymiş", "gel/FIIL sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void DilekRivayetSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmese_miymişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmese_miymişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmese_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmese_miymişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmese_miymişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmese_miymişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmeseler_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA sA/FC_KIP_DILEK_sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        public void DilekRivayetSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geleymişim", "gel/FIIL yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("geleymişsin", "gel/FIIL yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("geleymiş", "gel/FIIL yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("geleymişiz", "gel/FIIL yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("geleymişsiniz", "gel/FIIL yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("geleymişler", "gel/FIIL yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void IstekRivayetOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyeymişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeyeymişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeyeymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmeyeymişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmeyeymişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeyeymişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void IstekRivayetOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gele_miymişim", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gele_miymişsin", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gele_miymiş", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gele_miymişiz", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gele_miymişsiniz", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gele_miymişler", "gel/FIIL yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void IstekRivayetSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeye_miymişim", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("gelmeye_miymişsin", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("gelmeye_miymiş", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş")]
        [TestCase("gelmeye_miymişiz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("gelmeye_miymişsiniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("gelmeye_miymişler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yA/FC_KIP_ISTEK_(y)A _mU/SORU_mU ymUş/EKFIIL_RIVAYET_(y)mUş lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void IstekRivayetSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geldiysem", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("geldiysen", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("geldiyse", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA")]
        [TestCase("geldiysek", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("geldiyseniz", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("geldiyseler", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("geldilerse", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA")]
        public void GecmisDiSartOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmediysem", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmediysen", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmediyse", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA")]
        [TestCase("gelmediysek", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmediyseniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmediyseler", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmedilerse", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA")]
        public void GecmisDiSartOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geldiysem_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("geldiysen_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("geldiyse_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("geldiysek_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("geldiyseniz_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("geldiyseler_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        [TestCase("geldilerse_mi", "gel/FIIL DU/FC_ZAMAN_GECMIS_DU lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        public void GecmisDiSartSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmediysem_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelmediysen_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelmediyse_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("gelmediysek_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelmediyseniz_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelmediyseler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        [TestCase("gelmedilerse_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA DU/FC_ZAMAN_GECMIS_DU lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        public void GecmisDiSartSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmişsem", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmişsen", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmişse", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA")]
        [TestCase("gelmişsek", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmişseniz", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmişseler", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmişlerse", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA")]
        public void GecmisMisSartOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemişsem", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmemişsen", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmemişse", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA")]
        [TestCase("gelmemişsek", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmemişseniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmemişseler", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmemişlerse", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA")]
        public void GecmisMisSartOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmişsem_mi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelmişsen_mi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelmişse_mi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("gelmişsek_mi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelmişseniz_mi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelmişseler_mi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        [TestCase("gelmişlerse_mi", "gel/FIIL mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        public void GecmisMisSartSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemişsem_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelmemişsen_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelmemişse_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("gelmemişsek_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelmemişseniz_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelmemişseler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        [TestCase("gelmemişlerse_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mUş/FC_ZAMAN_GECMIS_mUş lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        public void GecmisMisSartSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geliyorsam", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("geliyorsan", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("geliyorsa", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA")]
        [TestCase("geliyorsak", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("geliyorsanız", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("geliyorsalar", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("geliyorlarsa", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA")]
        public void SimdikiSartOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiyorsam", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmiyorsan", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmiyorsa", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA")]
        [TestCase("gelmiyorsak", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmiyorsanız", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmiyorsalar", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmiyorlarsa", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA")]
        public void SimdikiSartOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geliyorsam_mı", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("geliyorsan_mı", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("geliyorsa_mı", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("geliyorsak_mı", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("geliyorsanız_mı", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("geliyorsalar_mı", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        [TestCase("geliyorlarsa_mı", "gel/FIIL Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        public void SimdikiSartSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmiyorsam_mı", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelmiyorsan_mı", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelmiyorsa_mı", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("gelmiyorsak_mı", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelmiyorsanız_mı", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelmiyorsalar_mı", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        [TestCase("gelmiyorlarsa_mı", "gel/FIIL mA/FY_OLUMSUZLUK_mA Uyor/FC_ZAMAN_SIMDIKI_(U)yor lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        public void SimdikiSartSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geleceksem", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("geleceksen", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelecekse", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA")]
        [TestCase("gelecekseniz", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("geleceksek", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelecekseler", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("geleceklerse", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA")]
        public void GelecekSartOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyeceksem", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmeyeceksen", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmeyecekse", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA")]
        [TestCase("gelmeyecekseniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmeyeceksek", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeyecekseler", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmeyeceklerse", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA")]
        public void GelecekSartOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geleceksem_mi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("geleceksen_mi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelecekse_mi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("gelecekseniz_mi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("geleceksek_mi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelecekseler_mi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        [TestCase("geleceklerse_mi", "gel/FIIL yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        public void GelecekSartSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeyeceksem_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelmeyeceksen_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelmeyecekse_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("gelmeyecekseniz_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelmeyeceksek_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelmeyecekseler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        [TestCase("gelmeyeceklerse_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA yAcAk/FC_ZAMAN_GELECEK_(y)AcAK lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        public void GelecekSartSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelirsem", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelirsen", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelirse", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA")]
        [TestCase("gelirsek", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelirseniz", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelirseler", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelirlerse", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA")]
        public void GenisSartOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmezsem", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmezsen", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmezse", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA")]
        [TestCase("gelmezsek", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmezseniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmezseler", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        [TestCase("gelmezlerse", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA")]
        public void GenisSartOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelirsem_mi", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelirsen_mi", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelirse_mi", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("gelirsek_mi", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelirseniz_mi", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelirseler_mi", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        [TestCase("gelirlerse_mi", "gel/FIIL Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        public void GenisSartSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmezsem_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelmezsen_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelmezse_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("gelmezsek_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelmezseniz_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelmezseler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        [TestCase("gelmezlerse_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA Ur/FC_ZAMAN_GENIS_(U)r lAr/EKFIIL_SAHIS_ONLAR_lAr ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        public void GenisSartSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeliysem", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmeliysen", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmeliyse", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA")]
        [TestCase("gelmeliysek", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmeliyseniz", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmeliyseler", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GereklilikSartOlumluTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemeliysem", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m")]
        [TestCase("gelmemeliysen", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n")]
        [TestCase("gelmemeliyse", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA")]
        [TestCase("gelmemeliysek", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k")]
        [TestCase("gelmemeliyseniz", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz")]
        [TestCase("gelmemeliyseler", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr")]
        public void GereklilikSartOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmeliysem_mi", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelmeliysen_mi", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelmeliyse_mi", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("gelmeliysek_mi", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelmeliyseniz_mi", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelmeliyseler_mi", "gel/FIIL mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GereklilikSartSoruTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("gelmemeliysem_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA m/EKFIIL_SAHIS_BEN_m _mU/SORU_mU")]
        [TestCase("gelmemeliysen_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA n/EKFIIL_SAHIS_SEN_n _mU/SORU_mU")]
        [TestCase("gelmemeliyse_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA _mU/SORU_mU")]
        [TestCase("gelmemeliysek_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA k/EKFIIL_SAHIS_BIZ_k _mU/SORU_mU")]
        [TestCase("gelmemeliyseniz_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA nUz/EKFIIL_SAHIS_SIZ_nUz _mU/SORU_mU")]
        [TestCase("gelmemeliyseler_mi", "gel/FIIL mA/FY_OLUMSUZLUK_mA mAlI/FC_KIP_GEREKLILIK_mAlI ysA/EKFIIL_SART_(y)sA lAr/EKFIIL_SAHIS_ONLAR_lAr _mU/SORU_mU")]
        public void GereklilikSartSoruOlumsuzTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

        [TestCase("geldiymişim")]
        [TestCase("geldiymişsin")]
        [TestCase("geldiymiş")]
        [TestCase("geldiymişiz")]
        [TestCase("geldiymişsiniz")]
        [TestCase("geldiymişler")]
        [TestCase("geldilermiş")]
        public void GecersizGecmisDiRivayetTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gelseysem")]
        [TestCase("gelseysen")]
        [TestCase("gelseyse")]
        [TestCase("gelseysek")]
        [TestCase("gelseyseniz")]
        [TestCase("gelseyseler")]
        [TestCase("gelselerse")]
        public void GecersizDilekSartTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("geleysem")]
        [TestCase("geleysen")]
        [TestCase("geleyse")]
        [TestCase("geleysek")]
        [TestCase("geleyseniz")]
        [TestCase("geleyseler")]
        [TestCase("gelelerse")]
        public void GecersizIstekSartTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gelsindi")]
        [TestCase("gelinizdi")]
        [TestCase("gelsinlerdi")]
        [TestCase("gelsinmiş")]
        [TestCase("gelinizmiş")]
        [TestCase("gelsinlermiş")]
        [TestCase("gelsinse")]
        [TestCase("gelinizse")]
        [TestCase("gelsinlerse")]
        public void GecersizEmirHikayeRivayetSartTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("geldi_miyim")]
        [TestCase("geldi_misin")]
        [TestCase("geldi_miyiz")]
        [TestCase("geldi_misiniz")]
        [TestCase("geldi_miler")]
        public void GecersizZamanDiSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gelmişsin_mi")]
        [TestCase("gelmişiz_mi")]
        [TestCase("gel_miymiş")]
        [TestCase("gelmişsiniz_mi")]
        [TestCase("gelmiş_miler")]
        public void GecersizGecmisMisSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("geliyorum_mu")]
        [TestCase("geliyorsun_mu")]
        [TestCase("geliyoruz_mu")]
        [TestCase("geliyorsunuz_mu")]
        [TestCase("geliyor_mular")]
        public void GecersizSimdikiSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("yaparım_mı")]
        [TestCase("yaparsın_mı")]
        [TestCase("yaparız_mı")]
        [TestCase("yaparsınız_mı")]
        [TestCase("yapar_mılar")]
        public void GecersizGenisSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gelmeliyim_mi")]
        [TestCase("gelmelisin_mi")]
        [TestCase("gelmeliyiz_mi")]
        [TestCase("gelmelisiniz_mi")]
        [TestCase("gelmeli_miler")]
        public void GecersizGereklilikSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gelse_miyim")]
        [TestCase("gelse_misin")]
        [TestCase("gelse_miyiz")]
        [TestCase("gelse_misiniz")]
        [TestCase("gelse_miler")]
        public void GecersizDilekSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gele_miyim")]
        [TestCase("gele_misin")]
        [TestCase("gele_miyiz")]
        [TestCase("gele_misiniz")]
        [TestCase("gele_miler")]
        public void GecersizIstekSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("geldiydim_mi")]
        [TestCase("geldiydin_mi")]
        [TestCase("geldiydi_mi")]
        [TestCase("geldiydik_mi")]
        [TestCase("geldiydiniz_mi")]
        [TestCase("geldiydiler_mi")]
        public void GecersizGecmisDiHikayeSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gelmiştim_mi")]
        [TestCase("gelmiştin_mi")]
        [TestCase("gelmişti_mi")]
        [TestCase("gelmiştik_mi")]
        [TestCase("gelmiştiniz_mi")]
        [TestCase("gelmiştiler_mi")]
        [TestCase("gelmişlerdi_mi")]
        public void GecersizGecmisMisHikayeSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("geliyordum_mu")]
        [TestCase("geliyordun_mu")]
        [TestCase("geliyordu_mu")]
        [TestCase("geliyorduk_mu")]
        [TestCase("geliyordunuz_mu")]
        [TestCase("geliyorlardı_mı")]
        [TestCase("geliyordular_mı")]
        public void GecersizSimdikiHikayeSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gelecektim_mi")]
        [TestCase("gelecektin_mi")]
        [TestCase("gelecekti_mi")]
        [TestCase("gelecektik_mi")]
        [TestCase("gelecektiniz_mi")]
        [TestCase("gelecektiler_mi")]
        [TestCase("geleceklerdi_mi")]
        public void GecersizGelecekHikayeSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gezerdim_mi")]
        [TestCase("gezerdin_mi")]
        [TestCase("gezerdi_mi")]
        [TestCase("gezerdik_mi")]
        [TestCase("gezerdiniz_mi")]
        [TestCase("gezerdiler_mi")]
        [TestCase("gezerlerdi_mi")]
        public void GecersizGenisHikayeSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gelmeliydim_mi")]
        [TestCase("gelmeliydin_mi")]
        [TestCase("gelmeliydi_mi")]
        [TestCase("gelmeliydik_mi")]
        [TestCase("gelmeliydiniz_mi")]
        [TestCase("gelmeliydiler_mi")]
        public void GecersizGereklilikHikayeSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gelseydim_mi")]
        [TestCase("gelseydin_mi")]
        [TestCase("gelseydi_mi")]
        [TestCase("gelseydik_mi")]
        [TestCase("gelseydiniz_mi")]
        [TestCase("gelseydiler_mi")]
        [TestCase("gelselerdi_mi")]
        public void GecersizDilekHikayeSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("geleydim_mi")]
        [TestCase("geleydin_mi")]
        [TestCase("geleydi_mi")]
        [TestCase("geleydik_mi")]
        [TestCase("geleydiniz_mi")]
        [TestCase("geleydiler_mi")]
        public void GecersizIstekHikayeSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("geldi_miysem")]
        [TestCase("geldi_miysen")]
        [TestCase("geldi_miyse")]
        [TestCase("geldi_miysek")]
        [TestCase("geldi_miyseniz")]
        [TestCase("geldi_miyseler")]
        [TestCase("geldi_milerse")]
        [TestCase("geldiyse_miyim")]
        [TestCase("geldiyse_misin")]
        [TestCase("geldiyse_miyiz")]
        [TestCase("geldiyse_misiniz")]
        [TestCase("geldiyse_miler")]
        public void GecersizGecmisDiSartSoruTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }

        [TestCase("gelmese_milermiş")]
        [TestCase("geliyor_mular")]
        [TestCase("geliyormuştu")]
        [TestCase("gelmiştiler_mi")]
        [TestCase("gelmiyor_muysalar")]
        [TestCase("gelelerdi")]
        public void GecersizCekimCesitliTest(string token)
        {
            Tester.HasNoAnalysis(token);
        }
    }
}