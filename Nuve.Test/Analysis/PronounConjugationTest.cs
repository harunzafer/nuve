using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    internal class PronounConjugationTest
    {
        [TestCase("ben", new[] {"ben/ZAMIR_SAHIS_BEN"})]
        [TestCase("benim",
            new[] {"ben/ZAMIR_SAHIS_BEN nUn/IC_HAL_ILGI_(n)Un", "ben/ZAMIR_SAHIS_BEN yUm/EKFIIL_SAHIS_BEN_(y)Um"})]
        [TestCase("benimdir",
            new[]
            {
                "ben/ZAMIR_SAHIS_BEN nUn/IC_HAL_ILGI_(n)Un DUr/EKFIIL_TANIMLAMA_DUr",
                "ben/ZAMIR_SAHIS_BEN yUm/EKFIIL_SAHIS_BEN_(y)Um DUr/EKFIIL_TANIMLAMA_DUr"
            })]
        [TestCase("benimki", new[] {"ben/ZAMIR_SAHIS_BEN nUn/IC_HAL_ILGI_(n)Un ki/IC_AITLIK_ki"})]
        [TestCase("beni", new[] {"ben/ZAMIR_SAHIS_BEN yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("bana", new[] {"ben/ZAMIR_SAHIS_BEN yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("bende", new[] {"ben/ZAMIR_SAHIS_BEN DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("benden", new[] {"ben/ZAMIR_SAHIS_BEN DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("benimle", new[] {"ben/ZAMIR_SAHIS_BEN nUn/IC_HAL_ILGI_(n)Un ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("bence", new[] {"ben/ZAMIR_SAHIS_BEN CA/IY_ZARF_CA"})]
        [TestCase("bensiz", new[] {"ben/ZAMIR_SAHIS_BEN sUz/IY_SIFAT_sUz"})]
        [TestCase("benli", new[] {"ben/ZAMIR_SAHIS_BEN lU/IY_SIFAT_lU"})]
        [TestCase("bense", new[] {"ben/ZAMIR_SAHIS_BEN ysA/EKFIIL_SART_(y)sA"})]
        [TestCase("benmişim", new[] {"ben/ZAMIR_SAHIS_BEN ymUş/EKFIIL_RIVAYET_(y)mUş yUm/EKFIIL_SAHIS_BEN_(y)Um"})]
        [TestCase("bendim", new[] {"ben/ZAMIR_SAHIS_BEN yDU/EKFIIL_HIKAYE_(y)DU m/EKFIIL_SAHIS_BEN_m"})]
        public void BenTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }

        [TestCase("benin", "ben/ZAMIR_SAHIS_BEN")]
        [TestCase("benle", "ben/ZAMIR_SAHIS_BEN")]
        [TestCase("benler", "ben/ZAMIR_SAHIS_BEN")]
        [TestCase("bene", "ben/ZAMIR_SAHIS_BEN")]
        public void BenGecersizTest(string token, string rootOfAnalysis)
        {
            Tester.AnalysisNotExist(token, rootOfAnalysis);
        }

        [TestCase("sen", new[] {"sen/ZAMIR_SAHIS_SEN"})]
        [TestCase("senin", new[] {"sen/ZAMIR_SAHIS_SEN nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("sensin", new[] {"sen/ZAMIR_SAHIS_SEN sUn/EKFIIL_SAHIS_SEN_sUn"})]
        [TestCase("senindir", new[] {"sen/ZAMIR_SAHIS_SEN nUn/IC_HAL_ILGI_(n)Un DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("sensindir", new[] {"sen/ZAMIR_SAHIS_SEN sUn/EKFIIL_SAHIS_SEN_sUn DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("seninki", new[] {"sen/ZAMIR_SAHIS_SEN nUn/IC_HAL_ILGI_(n)Un ki/IC_AITLIK_ki"})]
        [TestCase("seni", new[] {"sen/ZAMIR_SAHIS_SEN yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("sana", new[] {"sen/ZAMIR_SAHIS_SEN yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("sende", new[] {"sen/ZAMIR_SAHIS_SEN DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("senden", new[] {"sen/ZAMIR_SAHIS_SEN DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("seninle", new[] {"sen/ZAMIR_SAHIS_SEN nUn/IC_HAL_ILGI_(n)Un ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("sence", new[] {"sen/ZAMIR_SAHIS_SEN CA/IY_ZARF_CA"})]
        [TestCase("sensiz", new[] {"sen/ZAMIR_SAHIS_SEN sUz/IY_SIFAT_sUz"})]
        [TestCase("senmişsin", new[] {"sen/ZAMIR_SAHIS_SEN ymUş/EKFIIL_RIVAYET_(y)mUş sUn/EKFIIL_SAHIS_SEN_sUn"})]
        [TestCase("sendin", new[] {"sen/ZAMIR_SAHIS_SEN yDU/EKFIIL_HIKAYE_(y)DU n/EKFIIL_SAHIS_SEN_n"})]
        public void ZamirSenTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }

        [TestCase("o", new[] {"o/ZAMIR_SAHIS_O"})]
        [TestCase("onu", new[] {"o/ZAMIR_SAHIS_O yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("ona", new[] {"o/ZAMIR_SAHIS_O yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("onda", new[] {"o/ZAMIR_SAHIS_O DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("ondan", new[] {"o/ZAMIR_SAHIS_O DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("onun", new[] {"o/ZAMIR_SAHIS_O nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("onunla", new[] {"o/ZAMIR_SAHIS_O nUn/IC_HAL_ILGI_(n)Un ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("onca", new[] {"o/ZAMIR_SAHIS_O CA/IY_ZARF_CA"})]
        [TestCase("onsuz", new[] {"o/ZAMIR_SAHIS_O sUz/IY_SIFAT_sUz"})]
        [TestCase("onlu", new[] {"o/ZAMIR_SAHIS_O lU/IY_SIFAT_lU"})]
        [TestCase("onluk", new[] {"o/ZAMIR_SAHIS_O lUk/IY_ISIM_lUK"})]
        [TestCase("odur", new[] {"o/ZAMIR_SAHIS_O DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("onundur", new[] {"o/ZAMIR_SAHIS_O nUn/IC_HAL_ILGI_(n)Un DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("onunki", new[] {"o/ZAMIR_SAHIS_O nUn/IC_HAL_ILGI_(n)Un ki/IC_AITLIK_ki"})]
        [TestCase("oydu", new[] {"o/ZAMIR_SAHIS_O yDU/EKFIIL_HIKAYE_(y)DU"})]
        [TestCase("oymuş", new[] {"o/ZAMIR_SAHIS_O ymUş/EKFIIL_RIVAYET_(y)mUş"})]
        [TestCase("oysa", new[] {"o/ZAMIR_SAHIS_O ysA/EKFIIL_SART_(y)sA"})]
        [TestCase("oyken", new[] {"o/ZAMIR_SAHIS_O yken/EKFIIL_ZAMAN_(y)ken"})]
        [TestCase("oncağız", new[] {"o/ZAMIR_SAHIS_O cAğIz/IY_ISIM_cAğIz"})]
        public void ZamirOTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }

        [TestCase("biz", new[] {"biz/ZAMIR_SAHIS_BIZ"})]
        [TestCase("bizim", new[] {"biz/ZAMIR_SAHIS_BIZ nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("biziz", new[] {"biz/ZAMIR_SAHIS_BIZ yUz/EKFIIL_SAHIS_BIZ_(y)Uz"})]
        [TestCase("bizimdir", new[] {"biz/ZAMIR_SAHIS_BIZ nUn/IC_HAL_ILGI_(n)Un DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bizimki", new[] {"biz/ZAMIR_SAHIS_BIZ nUn/IC_HAL_ILGI_(n)Un ki/IC_AITLIK_ki"})]
        [TestCase("bizi", new[] {"biz/ZAMIR_SAHIS_BIZ yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("bize", new[] {"biz/ZAMIR_SAHIS_BIZ yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("bizde", new[] {"biz/ZAMIR_SAHIS_BIZ DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("bizden", new[] {"biz/ZAMIR_SAHIS_BIZ DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("bizimle", new[] {"biz/ZAMIR_SAHIS_BIZ nUn/IC_HAL_ILGI_(n)Un ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("bizce", new[] {"biz/ZAMIR_SAHIS_BIZ CA/IY_ZARF_CA"})]
        [TestCase("bizsiz", new[] {"biz/ZAMIR_SAHIS_BIZ sUz/IY_SIFAT_sUz"})]
        [TestCase("bizli", new[] {"biz/ZAMIR_SAHIS_BIZ lU/IY_SIFAT_lU"})]
        [TestCase("bizse", new[] {"biz/ZAMIR_SAHIS_BIZ ysA/EKFIIL_SART_(y)sA"})]
        [TestCase("bizmişiz", new[] {"biz/ZAMIR_SAHIS_BIZ ymUş/EKFIIL_RIVAYET_(y)mUş yUz/EKFIIL_SAHIS_BIZ_(y)Uz"})]
        [TestCase("bizdik", new[] {"biz/ZAMIR_SAHIS_BIZ yDU/EKFIIL_HIKAYE_(y)DU k/EKFIIL_SAHIS_BIZ_k"})]
        public void ZamirBizTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }


        [TestCase("bizler", new[] {"biz/ZAMIR_SAHIS_BIZ lAr/ZAMIR_COGUL_lAr"})]
        [TestCase("bizlere", new[] {"biz/ZAMIR_SAHIS_BIZ lAr/ZAMIR_COGUL_lAr yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("bizlerin", new[] {"biz/ZAMIR_SAHIS_BIZ lAr/ZAMIR_COGUL_lAr nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("bizlerle", new[] {"biz/ZAMIR_SAHIS_BIZ lAr/ZAMIR_COGUL_lAr ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("bizlerce", new[] {"biz/ZAMIR_SAHIS_BIZ lAr/ZAMIR_COGUL_lAr CA/IY_ZARF_CA"})]
        [TestCase("bizlerdir", new[] {"biz/ZAMIR_SAHIS_BIZ lAr/ZAMIR_COGUL_lAr DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bizleriz", new[] {"biz/ZAMIR_SAHIS_BIZ lAr/ZAMIR_COGUL_lAr yUz/EKFIIL_SAHIS_BIZ_(y)Uz"})]
        [TestCase("bizlerizdir",
            new[] {"biz/ZAMIR_SAHIS_BIZ lAr/ZAMIR_COGUL_lAr yUz/EKFIIL_SAHIS_BIZ_(y)Uz DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("sizler", new[] {"siz/ZAMIR_SAHIS_SIZ lAr/ZAMIR_COGUL_lAr"})]
        [TestCase("sizlerce", new[] {"siz/ZAMIR_SAHIS_SIZ lAr/ZAMIR_COGUL_lAr CA/IY_ZARF_CA"})]
        [TestCase("sizlerdir", new[] {"siz/ZAMIR_SAHIS_SIZ lAr/ZAMIR_COGUL_lAr DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("sizlere", new[] {"siz/ZAMIR_SAHIS_SIZ lAr/ZAMIR_COGUL_lAr yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("sizlerin", new[] {"siz/ZAMIR_SAHIS_SIZ lAr/ZAMIR_COGUL_lAr nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("sizlerle", new[] {"siz/ZAMIR_SAHIS_SIZ lAr/ZAMIR_COGUL_lAr ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("sizlersiniz", new[] {"siz/ZAMIR_SAHIS_SIZ lAr/ZAMIR_COGUL_lAr sUnUz/EKFIIL_SAHIS_SIZ_sUnUz"})]
        [TestCase("sizlersinizdir",
            new[] {"siz/ZAMIR_SAHIS_SIZ lAr/ZAMIR_COGUL_lAr sUnUz/EKFIIL_SAHIS_SIZ_sUnUz DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("sizsinizdir", new[] {"siz/ZAMIR_SAHIS_SIZ sUnUz/EKFIIL_SAHIS_SIZ_sUnUz DUr/EKFIIL_TANIMLAMA_DUr"})]
        public void ZamirBizlerSizlerTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }


        [TestCase("onlar", new[] {"onlar/ZAMIR_SAHIS_ONLAR"})]
        [TestCase("onların", new[] {"onlar/ZAMIR_SAHIS_ONLAR nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("onlarındır", new[] {"onlar/ZAMIR_SAHIS_ONLAR nUn/IC_HAL_ILGI_(n)Un DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("onlarınki", new[] {"onlar/ZAMIR_SAHIS_ONLAR nUn/IC_HAL_ILGI_(n)Un ki/IC_AITLIK_ki"})]
        [TestCase("onları", new[] {"onlar/ZAMIR_SAHIS_ONLAR yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("onlara", new[] {"onlar/ZAMIR_SAHIS_ONLAR yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("onlarda", new[] {"onlar/ZAMIR_SAHIS_ONLAR DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("onlardan", new[] {"onlar/ZAMIR_SAHIS_ONLAR DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("onlarla", new[] {"onlar/ZAMIR_SAHIS_ONLAR ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("onlarca", new[] {"onlar/ZAMIR_SAHIS_ONLAR CA/IY_ZARF_CA"})]
        [TestCase("onlarsız", new[] {"onlar/ZAMIR_SAHIS_ONLAR sUz/IY_SIFAT_sUz"})]
        [TestCase("onlardır", new[] {"onlar/ZAMIR_SAHIS_ONLAR DUr/EKFIIL_TANIMLAMA_DUr"})]
        public void ZamirOnlarTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }


        [TestCase("bu", new[] {"bu/ZAMIR_ISARET"})]
        [TestCase("bunu", new[] {"bu/ZAMIR_ISARET yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("buna", new[] {"bu/ZAMIR_ISARET yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("bunda", new[] {"bu/ZAMIR_ISARET DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("bundan", new[] {"bu/ZAMIR_ISARET DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("bunun", new[] {"bu/ZAMIR_ISARET nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("bununla", new[] {"bu/ZAMIR_ISARET nUn/IC_HAL_ILGI_(n)Un ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("bunca", new[] {"bu/ZAMIR_ISARET CA/IY_ZARF_CA"})]
        [TestCase("bunsuz", new[] {"bu/ZAMIR_ISARET sUz/IY_SIFAT_sUz"})]
        [TestCase("budur", new[] {"bu/ZAMIR_ISARET DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bunundur", new[] {"bu/ZAMIR_ISARET nUn/IC_HAL_ILGI_(n)Un DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bununki", new[] {"bu/ZAMIR_ISARET nUn/IC_HAL_ILGI_(n)Un ki/IC_AITLIK_ki"})]
        [TestCase("buyum", new[] {"bu/ZAMIR_ISARET yUm/EKFIIL_SAHIS_BEN_(y)Um"})]
        [TestCase("busun", new[] {"bu/ZAMIR_ISARET sUn/EKFIIL_SAHIS_SEN_sUn"})]
        [TestCase("buyuz", new[] {"bu/ZAMIR_ISARET yUz/EKFIIL_SAHIS_BIZ_(y)Uz"})]
        [TestCase("busunuz", new[] {"bu/ZAMIR_ISARET sUnUz/EKFIIL_SAHIS_SIZ_sUnUz"})]
        [TestCase("bunlar", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr"})]
        [TestCase("bunların", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("bunlarındır",
            new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr nUn/IC_HAL_ILGI_(n)Un DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bunlarınki", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr nUn/IC_HAL_ILGI_(n)Un ki/IC_AITLIK_ki"})]
        [TestCase("bunları", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("bunlara", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("bunlarda", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("bunlardan", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("bunlarla", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("bunlarca", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr CA/IY_ZARF_CA"})]
        [TestCase("bunlarsız", new[] {"eksik"}, Ignore = true)]
        [TestCase("şunlarsız", new[] {"eksik"}, Ignore = true)]
        [TestCase("bunlardır", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bunlarız", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr yUz/EKFIIL_SAHIS_BIZ_(y)Uz"})]
        [TestCase("bunlarsınız", new[] {"bu/ZAMIR_ISARET lAr/ZAMIR_COGUL_lAr sUnUz/EKFIIL_SAHIS_SIZ_sUnUz"})]
        public void ZamirBuBunlarTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }


        [TestCase("kendi", new[] {"kendi/ZAMIR_DONUSLULUK"})]
        [TestCase("kendim", new[] {"kendi/ZAMIR_DONUSLULUK Um/IC_SAHIPLIK_BEN_(U)m"})]
        [TestCase("kendin", new[] {"kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n"})]
        [TestCase("kendisi", new[] {"kendi/ZAMIR_DONUSLULUK sU/IC_SAHIPLIK_O_(s)U"})]
        [TestCase("kendimiz", new[] {"kendi/ZAMIR_DONUSLULUK UmUz/IC_SAHIPLIK_BIZ_(U)mUz"})]
        [TestCase("kendiniz",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n yUz/EKFIIL_SAHIS_BIZ_(y)Uz",
                "kendi/ZAMIR_DONUSLULUK UnUz/IC_SAHIPLIK_SIZ_(U)nUz"
            })]
        [TestCase("kendileri", new[] {"kendi/ZAMIR_DONUSLULUK lArI/IC_SAHIPLIK_ONLAR_lArI"})]
        [TestCase("kendimi", new[] {"kendi/ZAMIR_DONUSLULUK Um/IC_SAHIPLIK_BEN_(U)m yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kendini",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n yU/IC_HAL_BELIRTME_(y)U",
                "kendi/ZAMIR_DONUSLULUK yU/IC_HAL_BELIRTME_(y)U"
            })]
        [TestCase("kendisini", new[] {"kendi/ZAMIR_DONUSLULUK sU/IC_SAHIPLIK_O_(s)U yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kendimizi", new[] {"kendi/ZAMIR_DONUSLULUK UmUz/IC_SAHIPLIK_BIZ_(U)mUz yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kendinizi", new[] {"kendi/ZAMIR_DONUSLULUK UnUz/IC_SAHIPLIK_SIZ_(U)nUz yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kendilerini", new[] {"kendi/ZAMIR_DONUSLULUK lArI/IC_SAHIPLIK_ONLAR_lArI yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kendimin", new[] {"kendi/ZAMIR_DONUSLULUK Um/IC_SAHIPLIK_BEN_(U)m nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kendinin",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n nUn/IC_HAL_ILGI_(n)Un",
                "kendi/ZAMIR_DONUSLULUK nUn/IC_HAL_ILGI_(n)Un"
            })]
        [TestCase("kendisinin", new[] {"kendi/ZAMIR_DONUSLULUK sU/IC_SAHIPLIK_O_(s)U nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kendimizin", new[] {"kendi/ZAMIR_DONUSLULUK UmUz/IC_SAHIPLIK_BIZ_(U)mUz nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kendinizin", new[] {"kendi/ZAMIR_DONUSLULUK UnUz/IC_SAHIPLIK_SIZ_(U)nUz nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kendilerinin", new[] {"kendi/ZAMIR_DONUSLULUK lArI/IC_SAHIPLIK_ONLAR_lArI nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kendime", new[] {"kendi/ZAMIR_DONUSLULUK Um/IC_SAHIPLIK_BEN_(U)m yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kendine",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n yA/IC_HAL_YONELME_(y)A",
                "kendi/ZAMIR_DONUSLULUK yA/IC_HAL_YONELME_(y)A"
            })]
        [TestCase("kendisine", new[] {"kendi/ZAMIR_DONUSLULUK sU/IC_SAHIPLIK_O_(s)U yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kendimize", new[] {"kendi/ZAMIR_DONUSLULUK UmUz/IC_SAHIPLIK_BIZ_(U)mUz yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kendinize", new[] {"kendi/ZAMIR_DONUSLULUK UnUz/IC_SAHIPLIK_SIZ_(U)nUz yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kendilerine", new[] {"kendi/ZAMIR_DONUSLULUK lArI/IC_SAHIPLIK_ONLAR_lArI yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kendimde", new[] {"kendi/ZAMIR_DONUSLULUK Um/IC_SAHIPLIK_BEN_(U)m DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kendinde",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n DA/IC_HAL_BULUNMA_DA",
                "kendi/ZAMIR_DONUSLULUK DA/IC_HAL_BULUNMA_DA"
            })]
        [TestCase("kendisinde", new[] {"kendi/ZAMIR_DONUSLULUK sU/IC_SAHIPLIK_O_(s)U DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kendimizde", new[] {"kendi/ZAMIR_DONUSLULUK UmUz/IC_SAHIPLIK_BIZ_(U)mUz DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kendinizde", new[] {"kendi/ZAMIR_DONUSLULUK UnUz/IC_SAHIPLIK_SIZ_(U)nUz DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kendilerinde", new[] {"kendi/ZAMIR_DONUSLULUK lArI/IC_SAHIPLIK_ONLAR_lArI DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kendimden", new[] {"kendi/ZAMIR_DONUSLULUK Um/IC_SAHIPLIK_BEN_(U)m DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendinden",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n DAn/IC_HAL_AYRILMA_DAn",
                "kendi/ZAMIR_DONUSLULUK DAn/IC_HAL_AYRILMA_DAn"
            })]
        [TestCase("kendisinden", new[] {"kendi/ZAMIR_DONUSLULUK sU/IC_SAHIPLIK_O_(s)U DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendimizden", new[] {"kendi/ZAMIR_DONUSLULUK UmUz/IC_SAHIPLIK_BIZ_(U)mUz DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendinizden", new[] {"kendi/ZAMIR_DONUSLULUK UnUz/IC_SAHIPLIK_SIZ_(U)nUz DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendilerinden", new[] {"kendi/ZAMIR_DONUSLULUK lArI/IC_SAHIPLIK_ONLAR_lArI DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendimce", new[] {"kendi/ZAMIR_DONUSLULUK Um/IC_SAHIPLIK_BEN_(U)m CA/IY_ZARF_CA"})]
        [TestCase("kendince",
            new[]
            {"kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n CA/IY_ZARF_CA", "kendi/ZAMIR_DONUSLULUK CA/IY_ZARF_CA"})]
        [TestCase("kendisince", new[] {"kendi/ZAMIR_DONUSLULUK sU/IC_SAHIPLIK_O_(s)U CA/IY_ZARF_CA"})]
        [TestCase("kendimizce", new[] {"kendi/ZAMIR_DONUSLULUK UmUz/IC_SAHIPLIK_BIZ_(U)mUz CA/IY_ZARF_CA"})]
        [TestCase("kendinizce", new[] {"kendi/ZAMIR_DONUSLULUK UnUz/IC_SAHIPLIK_SIZ_(U)nUz CA/IY_ZARF_CA"})]
        [TestCase("kendilerince", new[] {"kendi/ZAMIR_DONUSLULUK lArI/IC_SAHIPLIK_ONLAR_lArI CA/IY_ZARF_CA"})]
        [TestCase("kendimle", new[] {"kendi/ZAMIR_DONUSLULUK Um/IC_SAHIPLIK_BEN_(U)m ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendinle", new[] {"kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendisiyle", new[] {"kendi/ZAMIR_DONUSLULUK sU/IC_SAHIPLIK_O_(s)U ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendimizle", new[] {"kendi/ZAMIR_DONUSLULUK UmUz/IC_SAHIPLIK_BIZ_(U)mUz ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendinizle", new[] {"kendi/ZAMIR_DONUSLULUK UnUz/IC_SAHIPLIK_SIZ_(U)nUz ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendileriyle", new[] {"kendi/ZAMIR_DONUSLULUK lArI/IC_SAHIPLIK_ONLAR_lArI ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendidir", new[] {"kendi/ZAMIR_DONUSLULUK DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("kendimdir", new[] {"kendi/ZAMIR_DONUSLULUK Um/IC_SAHIPLIK_BEN_(U)m DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("kendindir", new[] {"kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("kendimizdir", new[] {"kendi/ZAMIR_DONUSLULUK UmUz/IC_SAHIPLIK_BIZ_(U)mUz DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("kendinizdir",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK Un/IC_SAHIPLIK_SEN_(U)n yUz/EKFIIL_SAHIS_BIZ_(y)Uz DUr/EKFIIL_TANIMLAMA_DUr",
                "kendi/ZAMIR_DONUSLULUK UnUz/IC_SAHIPLIK_SIZ_(U)nUz DUr/EKFIIL_TANIMLAMA_DUr"
            })]
        [TestCase("kendileridir", new[] {"kendi/ZAMIR_DONUSLULUK lArI/IC_SAHIPLIK_ONLAR_lArI DUr/EKFIIL_TANIMLAMA_DUr"})
        ]
        [TestCase("kendiliğimden",
            new[] {"kendi/ZAMIR_DONUSLULUK lUk/IY_ISIM_lUK Um/IC_SAHIPLIK_BEN_(U)m DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendiliğinden",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK lUk/IY_ISIM_lUK sU/IC_SAHIPLIK_O_(s)U DAn/IC_HAL_AYRILMA_DAn",
                "kendi/ZAMIR_DONUSLULUK lUk/IY_ISIM_lUK Un/IC_SAHIPLIK_SEN_(U)n DAn/IC_HAL_AYRILMA_DAn"
            })]
        [TestCase("kendiliğimizden",
            new[] {"kendi/ZAMIR_DONUSLULUK lUk/IY_ISIM_lUK UmUz/IC_SAHIPLIK_BIZ_(U)mUz DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendiliğinizden",
            new[] {"kendi/ZAMIR_DONUSLULUK lUk/IY_ISIM_lUK UnUz/IC_SAHIPLIK_SIZ_(U)nUz DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendiliklerinden",
            new[] {"kendi/ZAMIR_DONUSLULUK lUk/IY_ISIM_lUK lArI/IC_SAHIPLIK_ONLAR_lArI DAn/IC_HAL_AYRILMA_DAn"})]
        public void ZamirKendiTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }


        [TestCase("kim", new[] {"kim/ZAMIR_SORU"})]
        [TestCase("kimler", new[] {"kim/ZAMIR_SORU lAr/IC_COGUL_lAr", "kim/ZAMIR_SORU lAr/EKFIIL_SAHIS_ONLAR_lAr"})]
        [TestCase("kimi", new[] {"kim/ZAMIR_SORU sU/IC_SAHIPLIK_O_(s)U", "kim/ZAMIR_SORU yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kimleri",
            new[]
            {
                "kim/ZAMIR_SORU lAr/IC_COGUL_lAr sU/IC_SAHIPLIK_O_(s)U",
                "kim/ZAMIR_SORU lAr/IC_COGUL_lAr yU/IC_HAL_BELIRTME_(y)U", "kim/ZAMIR_SORU lArI/IC_SAHIPLIK_ONLAR_lArI"
            }
            )]
        [TestCase("kimin", new[] {"kim/ZAMIR_SORU Un/IC_SAHIPLIK_SEN_(U)n", "kim/ZAMIR_SORU nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kimlerin",
            new[]
            {
                "kim/ZAMIR_SORU lAr/IC_COGUL_lAr Un/IC_SAHIPLIK_SEN_(U)n",
                "kim/ZAMIR_SORU lAr/IC_COGUL_lAr nUn/IC_HAL_ILGI_(n)Un"
            })]
        [TestCase("kime", new[] {"kim/ZAMIR_SORU yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kimlere", new[] {"kim/ZAMIR_SORU lAr/IC_COGUL_lAr yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kimde", new[] {"kim/ZAMIR_SORU DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kimlerde", new[] {"kim/ZAMIR_SORU lAr/IC_COGUL_lAr DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kimden", new[] {"kim/ZAMIR_SORU DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kimlerden", new[] {"kim/ZAMIR_SORU lAr/IC_COGUL_lAr DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kimim", new[] {"kim/ZAMIR_SORU Um/IC_SAHIPLIK_BEN_(U)m", "kim/ZAMIR_SORU yUm/EKFIIL_SAHIS_BEN_(y)Um"}
            )]
        [TestCase("kimin", new[] {"kim/ZAMIR_SORU Un/IC_SAHIPLIK_SEN_(U)n", "kim/ZAMIR_SORU nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kimimiz", new[] {"kim/ZAMIR_SORU UmUz/IC_SAHIPLIK_BIZ_(U)mUz"})]
        [TestCase("kiminiz",
            new[]
            {
                "kim/ZAMIR_SORU Un/IC_SAHIPLIK_SEN_(U)n yUz/EKFIIL_SAHIS_BIZ_(y)Uz",
                "kim/ZAMIR_SORU UnUz/IC_SAHIPLIK_SIZ_(U)nUz"
            })]
        [TestCase("kimimi", new[] {"kim/ZAMIR_SORU Um/IC_SAHIPLIK_BEN_(U)m yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kimini",
            new[]
            {
                "kim/ZAMIR_SORU sU/IC_SAHIPLIK_O_(s)U yU/IC_HAL_BELIRTME_(y)U",
                "kim/ZAMIR_SORU Un/IC_SAHIPLIK_SEN_(U)n yU/IC_HAL_BELIRTME_(y)U"
            })]
        [TestCase("kimimizi", new[] {"kim/ZAMIR_SORU UmUz/IC_SAHIPLIK_BIZ_(U)mUz yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kiminizi", new[] {"kim/ZAMIR_SORU UnUz/IC_SAHIPLIK_SIZ_(U)nUz yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kimimin", new[] {"kim/ZAMIR_SORU Um/IC_SAHIPLIK_BEN_(U)m nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kiminin",
            new[]
            {
                "kim/ZAMIR_SORU sU/IC_SAHIPLIK_O_(s)U nUn/IC_HAL_ILGI_(n)Un",
                "kim/ZAMIR_SORU Un/IC_SAHIPLIK_SEN_(U)n nUn/IC_HAL_ILGI_(n)Un"
            })]
        [TestCase("kimimizin", new[] {"kim/ZAMIR_SORU UmUz/IC_SAHIPLIK_BIZ_(U)mUz nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kiminizin", new[] {"kim/ZAMIR_SORU UnUz/IC_SAHIPLIK_SIZ_(U)nUz nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kimime", new[] {"kim/ZAMIR_SORU Um/IC_SAHIPLIK_BEN_(U)m yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kimine",
            new[]
            {
                "kim/ZAMIR_SORU sU/IC_SAHIPLIK_O_(s)U yA/IC_HAL_YONELME_(y)A",
                "kim/ZAMIR_SORU Un/IC_SAHIPLIK_SEN_(U)n yA/IC_HAL_YONELME_(y)A"
            })]
        [TestCase("kimimize", new[] {"kim/ZAMIR_SORU UmUz/IC_SAHIPLIK_BIZ_(U)mUz yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kiminize", new[] {"kim/ZAMIR_SORU UnUz/IC_SAHIPLIK_SIZ_(U)nUz yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kimimde", new[] {"kim/ZAMIR_SORU Um/IC_SAHIPLIK_BEN_(U)m DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kiminde",
            new[]
            {
                "kim/ZAMIR_SORU sU/IC_SAHIPLIK_O_(s)U DA/IC_HAL_BULUNMA_DA",
                "kim/ZAMIR_SORU Un/IC_SAHIPLIK_SEN_(U)n DA/IC_HAL_BULUNMA_DA"
            })]
        [TestCase("kimimizde", new[] {"kim/ZAMIR_SORU UmUz/IC_SAHIPLIK_BIZ_(U)mUz DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kiminizde", new[] {"kim/ZAMIR_SORU UnUz/IC_SAHIPLIK_SIZ_(U)nUz DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kimimden", new[] {"kim/ZAMIR_SORU Um/IC_SAHIPLIK_BEN_(U)m DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kiminden",
            new[]
            {
                "kim/ZAMIR_SORU sU/IC_SAHIPLIK_O_(s)U DAn/IC_HAL_AYRILMA_DAn",
                "kim/ZAMIR_SORU Un/IC_SAHIPLIK_SEN_(U)n DAn/IC_HAL_AYRILMA_DAn"
            })]
        [TestCase("kimimizden", new[] {"kim/ZAMIR_SORU UmUz/IC_SAHIPLIK_BIZ_(U)mUz DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kimimle", new[] {"kim/ZAMIR_SORU Um/IC_SAHIPLIK_BEN_(U)m ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kiminle",
            new[]
            {
                "kim/ZAMIR_SORU Un/IC_SAHIPLIK_SEN_(U)n ylA/IC_HAL_VASITA_(y)lA",
                "kim/ZAMIR_SORU nUn/IC_HAL_ILGI_(n)Un ylA/IC_HAL_VASITA_(y)lA"
            })]
        [TestCase("kimiyle", new[] {"kim/ZAMIR_SORU sU/IC_SAHIPLIK_O_(s)U ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kimimizle", new[] {"kim/ZAMIR_SORU UmUz/IC_SAHIPLIK_BIZ_(U)mUz ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kiminizle", new[] {"kim/ZAMIR_SORU UnUz/IC_SAHIPLIK_SIZ_(U)nUz ylA/IC_HAL_VASITA_(y)lA"})]
        public void ZamirKimTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }

        [TestCase("kimisi", new[] {"kimi/ZAMIR_BELIRSIZLIK sU/IC_SAHIPLIK_O_(s)U"})]
        [TestCase("kimisince", new[] {"kimi/ZAMIR_BELIRSIZLIK sU/IC_SAHIPLIK_O_(s)U CA/IY_ZARF_CA"})]
        [TestCase("kimisine", new[] {"kimi/ZAMIR_BELIRSIZLIK sU/IC_SAHIPLIK_O_(s)U yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kimisini", new[] {"kimi/ZAMIR_BELIRSIZLIK sU/IC_SAHIPLIK_O_(s)U yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kimisinde", new[] {"kimi/ZAMIR_BELIRSIZLIK sU/IC_SAHIPLIK_O_(s)U DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kimisinden", new[] {"kimi/ZAMIR_BELIRSIZLIK sU/IC_SAHIPLIK_O_(s)U DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kimisiyle", new[] {"kimi/ZAMIR_BELIRSIZLIK sU/IC_SAHIPLIK_O_(s)U ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kimisinin", new[] {"kimi/ZAMIR_BELIRSIZLIK sU/IC_SAHIPLIK_O_(s)U nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kimisininki",
            new[] {"kimi/ZAMIR_BELIRSIZLIK sU/IC_SAHIPLIK_O_(s)U nUn/IC_HAL_ILGI_(n)Un ki/IC_AITLIK_ki"})]
        [TestCase("kimisinindir",
            new[] {"kimi/ZAMIR_BELIRSIZLIK sU/IC_SAHIPLIK_O_(s)U nUn/IC_HAL_ILGI_(n)Un DUr/EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("kimileri", new[] {"kimi/ZAMIR_BELIRSIZLIK lArI/IC_SAHIPLIK_ONLAR_lArI"})]
        [TestCase("kimilerince", new[] {"kimi/ZAMIR_BELIRSIZLIK lArI/IC_SAHIPLIK_ONLAR_lArI CA/IY_ZARF_CA"})]
        [TestCase("kimilerine", new[] {"kimi/ZAMIR_BELIRSIZLIK lArI/IC_SAHIPLIK_ONLAR_lArI yA/IC_HAL_YONELME_(y)A"})]
        [TestCase("kimilerini", new[] {"kimi/ZAMIR_BELIRSIZLIK lArI/IC_SAHIPLIK_ONLAR_lArI yU/IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kimilerinde", new[] {"kimi/ZAMIR_BELIRSIZLIK lArI/IC_SAHIPLIK_ONLAR_lArI DA/IC_HAL_BULUNMA_DA"})]
        [TestCase("kimilerinden", new[] {"kimi/ZAMIR_BELIRSIZLIK lArI/IC_SAHIPLIK_ONLAR_lArI DAn/IC_HAL_AYRILMA_DAn"})]
        [TestCase("kimileriyle", new[] {"kimi/ZAMIR_BELIRSIZLIK lArI/IC_SAHIPLIK_ONLAR_lArI ylA/IC_HAL_VASITA_(y)lA"})]
        [TestCase("kimilerinin", new[] {"kimi/ZAMIR_BELIRSIZLIK lArI/IC_SAHIPLIK_ONLAR_lArI nUn/IC_HAL_ILGI_(n)Un"})]
        [TestCase("kimilerininki",
            new[] {"kimi/ZAMIR_BELIRSIZLIK lArI/IC_SAHIPLIK_ONLAR_lArI nUn/IC_HAL_ILGI_(n)Un ki/IC_AITLIK_ki"})]
        [TestCase("kimilerinindir",
            new[] {"kimi/ZAMIR_BELIRSIZLIK lArI/IC_SAHIPLIK_ONLAR_lArI nUn/IC_HAL_ILGI_(n)Un DUr/EKFIIL_TANIMLAMA_DUr"})
        ]
        public void ZamirKimiTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }
    }
}