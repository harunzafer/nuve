using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    internal class PronounConjugationTest
    {
        [TestCase("ben", new[] {"ben/ZAMIR_SAHIS_BEN"})]
        [TestCase("benim",
            new[] {"ben/ZAMIR_SAHIS_BEN IC_HAL_ILGI_(n)Un", "ben/ZAMIR_SAHIS_BEN EKFIIL_SAHIS_BEN_(y)Um"})]
        [TestCase("benimdir",
            new[]
            {
                "ben/ZAMIR_SAHIS_BEN IC_HAL_ILGI_(n)Un EKFIIL_TANIMLAMA_DUr",
                "ben/ZAMIR_SAHIS_BEN EKFIIL_SAHIS_BEN_(y)Um EKFIIL_TANIMLAMA_DUr"
            })]
        [TestCase("benimki", new[] {"ben/ZAMIR_SAHIS_BEN IC_HAL_ILGI_(n)Un IC_AITLIK_ki"})]
        [TestCase("beni", new[] {"ben/ZAMIR_SAHIS_BEN IC_HAL_BELIRTME_(y)U"})]
        [TestCase("bana", new[] {"ben/ZAMIR_SAHIS_BEN IC_HAL_YONELME_(y)A"})]
        [TestCase("bende", new[] {"ben/ZAMIR_SAHIS_BEN IC_HAL_BULUNMA_DA"})]
        [TestCase("benden", new[] {"ben/ZAMIR_SAHIS_BEN IC_HAL_AYRILMA_DAn"})]
        [TestCase("benimle", new[] {"ben/ZAMIR_SAHIS_BEN IC_HAL_ILGI_(n)Un IC_HAL_VASITA_(y)lA"})]
        [TestCase("bence", new[] {"ben/ZAMIR_SAHIS_BEN IY_ZARF_CA"})]
        [TestCase("bensiz", new[] {"ben/ZAMIR_SAHIS_BEN IY_SIFAT_sUz"})]
        [TestCase("benli", new[] {"ben/ZAMIR_SAHIS_BEN IY_SIFAT_lU"})]
        [TestCase("bense", new[] {"ben/ZAMIR_SAHIS_BEN EKFIIL_SART_(y)sA"})]
        [TestCase("benmişim", new[] {"ben/ZAMIR_SAHIS_BEN EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_BEN_(y)Um"})]
        [TestCase("bendim", new[] {"ben/ZAMIR_SAHIS_BEN EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BEN_m"})]
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
        [TestCase("senin", new[] {"sen/ZAMIR_SAHIS_SEN IC_HAL_ILGI_(n)Un"})]
        [TestCase("sensin", new[] {"sen/ZAMIR_SAHIS_SEN EKFIIL_SAHIS_SEN_sUn"})]
        [TestCase("senindir", new[] {"sen/ZAMIR_SAHIS_SEN IC_HAL_ILGI_(n)Un EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("sensindir", new[] {"sen/ZAMIR_SAHIS_SEN EKFIIL_SAHIS_SEN_sUn EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("seninki", new[] {"sen/ZAMIR_SAHIS_SEN IC_HAL_ILGI_(n)Un IC_AITLIK_ki"})]
        [TestCase("seni", new[] {"sen/ZAMIR_SAHIS_SEN IC_HAL_BELIRTME_(y)U"})]
        [TestCase("sana", new[] {"sen/ZAMIR_SAHIS_SEN IC_HAL_YONELME_(y)A"})]
        [TestCase("sende", new[] {"sen/ZAMIR_SAHIS_SEN IC_HAL_BULUNMA_DA"})]
        [TestCase("senden", new[] {"sen/ZAMIR_SAHIS_SEN IC_HAL_AYRILMA_DAn"})]
        [TestCase("seninle", new[] {"sen/ZAMIR_SAHIS_SEN IC_HAL_ILGI_(n)Un IC_HAL_VASITA_(y)lA"})]
        [TestCase("sence", new[] {"sen/ZAMIR_SAHIS_SEN IY_ZARF_CA"})]
        [TestCase("sensiz", new[] {"sen/ZAMIR_SAHIS_SEN IY_SIFAT_sUz"})]
        [TestCase("senmişsin", new[] {"sen/ZAMIR_SAHIS_SEN EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_SEN_sUn"})]
        [TestCase("sendin", new[] {"sen/ZAMIR_SAHIS_SEN EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_SEN_n"})]
        public void ZamirSenTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }

        [TestCase("o", new[] {"o/ZAMIR_SAHIS_O"})]
        [TestCase("onu", new[] {"o/ZAMIR_SAHIS_O IC_HAL_BELIRTME_(y)U"})]
        [TestCase("ona", new[] {"o/ZAMIR_SAHIS_O IC_HAL_YONELME_(y)A"})]
        [TestCase("onda", new[] {"o/ZAMIR_SAHIS_O IC_HAL_BULUNMA_DA"})]
        [TestCase("ondan", new[] {"o/ZAMIR_SAHIS_O IC_HAL_AYRILMA_DAn"})]
        [TestCase("onun", new[] {"o/ZAMIR_SAHIS_O IC_HAL_ILGI_(n)Un"})]
        [TestCase("onunla", new[] {"o/ZAMIR_SAHIS_O IC_HAL_ILGI_(n)Un IC_HAL_VASITA_(y)lA"})]
        [TestCase("onca", new[] {"o/ZAMIR_SAHIS_O IY_ZARF_CA"})]
        [TestCase("onsuz", new[] {"o/ZAMIR_SAHIS_O IY_SIFAT_sUz"})]
        [TestCase("onlu", new[] {"o/ZAMIR_SAHIS_O IY_SIFAT_lU"})]
        [TestCase("onluk", new[] {"o/ZAMIR_SAHIS_O IY_ISIM_lUK"})]
        [TestCase("odur", new[] {"o/ZAMIR_SAHIS_O EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("onundur", new[] {"o/ZAMIR_SAHIS_O IC_HAL_ILGI_(n)Un EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("onunki", new[] {"o/ZAMIR_SAHIS_O IC_HAL_ILGI_(n)Un IC_AITLIK_ki"})]
        [TestCase("oydu", new[] {"o/ZAMIR_SAHIS_O EKFIIL_HIKAYE_(y)DU"})]
        [TestCase("oymuş", new[] {"o/ZAMIR_SAHIS_O EKFIIL_RIVAYET_(y)mUş"})]
        [TestCase("oysa", new[] {"o/ZAMIR_SAHIS_O EKFIIL_SART_(y)sA"})]
        [TestCase("oyken", new[] {"o/ZAMIR_SAHIS_O EKFIIL_ZAMAN_(y)ken"})]
        [TestCase("oncağız", new[] {"o/ZAMIR_SAHIS_O IY_ISIM_cAğIz"})]
        public void ZamirOTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }

        [TestCase("biz", new[] {"biz/ZAMIR_SAHIS_BIZ"})]
        [TestCase("bizim", new[] {"biz/ZAMIR_SAHIS_BIZ IC_HAL_ILGI_(n)Un"})]
        [TestCase("biziz", new[] {"biz/ZAMIR_SAHIS_BIZ EKFIIL_SAHIS_BIZ_(y)Uz"})]
        [TestCase("bizimdir", new[] {"biz/ZAMIR_SAHIS_BIZ IC_HAL_ILGI_(n)Un EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bizimki", new[] {"biz/ZAMIR_SAHIS_BIZ IC_HAL_ILGI_(n)Un IC_AITLIK_ki"})]
        [TestCase("bizi", new[] {"biz/ZAMIR_SAHIS_BIZ IC_HAL_BELIRTME_(y)U"})]
        [TestCase("bize", new[] {"biz/ZAMIR_SAHIS_BIZ IC_HAL_YONELME_(y)A"})]
        [TestCase("bizde", new[] {"biz/ZAMIR_SAHIS_BIZ IC_HAL_BULUNMA_DA"})]
        [TestCase("bizden", new[] {"biz/ZAMIR_SAHIS_BIZ IC_HAL_AYRILMA_DAn"})]
        [TestCase("bizimle", new[] {"biz/ZAMIR_SAHIS_BIZ IC_HAL_ILGI_(n)Un IC_HAL_VASITA_(y)lA"})]
        [TestCase("bizce", new[] {"biz/ZAMIR_SAHIS_BIZ IY_ZARF_CA"})]
        [TestCase("bizsiz", new[] {"biz/ZAMIR_SAHIS_BIZ IY_SIFAT_sUz"})]
        [TestCase("bizli", new[] {"biz/ZAMIR_SAHIS_BIZ IY_SIFAT_lU"})]
        [TestCase("bizse", new[] {"biz/ZAMIR_SAHIS_BIZ EKFIIL_SART_(y)sA"})]
        [TestCase("bizmişiz", new[] {"biz/ZAMIR_SAHIS_BIZ EKFIIL_RIVAYET_(y)mUş EKFIIL_SAHIS_BIZ_(y)Uz"})]
        [TestCase("bizdik", new[] {"biz/ZAMIR_SAHIS_BIZ EKFIIL_HIKAYE_(y)DU EKFIIL_SAHIS_BIZ_k"})]
        public void ZamirBizTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }


        [TestCase("bizler", new[] {"biz/ZAMIR_SAHIS_BIZ ZAMIR_COGUL_lAr"})]
        [TestCase("bizlere", new[] {"biz/ZAMIR_SAHIS_BIZ ZAMIR_COGUL_lAr IC_HAL_YONELME_(y)A"})]
        [TestCase("bizlerin", new[] {"biz/ZAMIR_SAHIS_BIZ ZAMIR_COGUL_lAr IC_HAL_ILGI_(n)Un"})]
        [TestCase("bizlerle", new[] {"biz/ZAMIR_SAHIS_BIZ ZAMIR_COGUL_lAr IC_HAL_VASITA_(y)lA"})]
        [TestCase("bizlerce", new[] {"biz/ZAMIR_SAHIS_BIZ ZAMIR_COGUL_lAr IY_ZARF_CA"})]
        [TestCase("bizlerdir", new[] {"biz/ZAMIR_SAHIS_BIZ ZAMIR_COGUL_lAr EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bizleriz", new[] {"biz/ZAMIR_SAHIS_BIZ ZAMIR_COGUL_lAr EKFIIL_SAHIS_BIZ_(y)Uz"})]
        [TestCase("bizlerizdir",
            new[] {"biz/ZAMIR_SAHIS_BIZ ZAMIR_COGUL_lAr EKFIIL_SAHIS_BIZ_(y)Uz EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("sizler", new[] {"siz/ZAMIR_SAHIS_SIZ ZAMIR_COGUL_lAr"})]
        [TestCase("sizlerce", new[] {"siz/ZAMIR_SAHIS_SIZ ZAMIR_COGUL_lAr IY_ZARF_CA"})]
        [TestCase("sizlerdir", new[] {"siz/ZAMIR_SAHIS_SIZ ZAMIR_COGUL_lAr EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("sizlere", new[] {"siz/ZAMIR_SAHIS_SIZ ZAMIR_COGUL_lAr IC_HAL_YONELME_(y)A"})]
        [TestCase("sizlerin", new[] {"siz/ZAMIR_SAHIS_SIZ ZAMIR_COGUL_lAr IC_HAL_ILGI_(n)Un"})]
        [TestCase("sizlerle", new[] {"siz/ZAMIR_SAHIS_SIZ ZAMIR_COGUL_lAr IC_HAL_VASITA_(y)lA"})]
        [TestCase("sizlersiniz", new[] {"siz/ZAMIR_SAHIS_SIZ ZAMIR_COGUL_lAr EKFIIL_SAHIS_SIZ_sUnUz"})]
        [TestCase("sizlersinizdir",
            new[] {"siz/ZAMIR_SAHIS_SIZ ZAMIR_COGUL_lAr EKFIIL_SAHIS_SIZ_sUnUz EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("sizsinizdir", new[] {"siz/ZAMIR_SAHIS_SIZ EKFIIL_SAHIS_SIZ_sUnUz EKFIIL_TANIMLAMA_DUr"})]
        public void ZamirBizlerSizlerTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }


        [TestCase("onlar", new[] {"onlar/ZAMIR_SAHIS_ONLAR"})]
        [TestCase("onların", new[] {"onlar/ZAMIR_SAHIS_ONLAR IC_HAL_ILGI_(n)Un"})]
        [TestCase("onlarındır", new[] {"onlar/ZAMIR_SAHIS_ONLAR IC_HAL_ILGI_(n)Un EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("onlarınki", new[] {"onlar/ZAMIR_SAHIS_ONLAR IC_HAL_ILGI_(n)Un IC_AITLIK_ki"})]
        [TestCase("onları", new[] {"onlar/ZAMIR_SAHIS_ONLAR IC_HAL_BELIRTME_(y)U"})]
        [TestCase("onlara", new[] {"onlar/ZAMIR_SAHIS_ONLAR IC_HAL_YONELME_(y)A"})]
        [TestCase("onlarda", new[] {"onlar/ZAMIR_SAHIS_ONLAR IC_HAL_BULUNMA_DA"})]
        [TestCase("onlardan", new[] {"onlar/ZAMIR_SAHIS_ONLAR IC_HAL_AYRILMA_DAn"})]
        [TestCase("onlarla", new[] {"onlar/ZAMIR_SAHIS_ONLAR IC_HAL_VASITA_(y)lA"})]
        [TestCase("onlarca", new[] {"onlar/ZAMIR_SAHIS_ONLAR IY_ZARF_CA"})]
        [TestCase("onlarsız", new[] {"onlar/ZAMIR_SAHIS_ONLAR IY_SIFAT_sUz"})]
        [TestCase("onlardır", new[] {"onlar/ZAMIR_SAHIS_ONLAR EKFIIL_TANIMLAMA_DUr"})]
        public void ZamirOnlarTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }


        [TestCase("bu", new[] {"bu/ZAMIR_ISARET"})]
        [TestCase("bunu", new[] {"bu/ZAMIR_ISARET IC_HAL_BELIRTME_(y)U"})]
        [TestCase("buna", new[] {"bu/ZAMIR_ISARET IC_HAL_YONELME_(y)A"})]
        [TestCase("bunda", new[] {"bu/ZAMIR_ISARET IC_HAL_BULUNMA_DA"})]
        [TestCase("bundan", new[] {"bu/ZAMIR_ISARET IC_HAL_AYRILMA_DAn"})]
        [TestCase("bunun", new[] {"bu/ZAMIR_ISARET IC_HAL_ILGI_(n)Un"})]
        [TestCase("bununla", new[] {"bu/ZAMIR_ISARET IC_HAL_ILGI_(n)Un IC_HAL_VASITA_(y)lA"})]
        [TestCase("bunca", new[] {"bu/ZAMIR_ISARET IY_ZARF_CA"})]
        [TestCase("bunsuz", new[] {"bu/ZAMIR_ISARET IY_SIFAT_sUz"})]
        [TestCase("budur", new[] {"bu/ZAMIR_ISARET EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bunundur", new[] {"bu/ZAMIR_ISARET IC_HAL_ILGI_(n)Un EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bununki", new[] {"bu/ZAMIR_ISARET IC_HAL_ILGI_(n)Un IC_AITLIK_ki"})]
        [TestCase("buyum", new[] {"bu/ZAMIR_ISARET EKFIIL_SAHIS_BEN_(y)Um"})]
        [TestCase("busun", new[] {"bu/ZAMIR_ISARET EKFIIL_SAHIS_SEN_sUn"})]
        [TestCase("buyuz", new[] {"bu/ZAMIR_ISARET EKFIIL_SAHIS_BIZ_(y)Uz"})]
        [TestCase("busunuz", new[] {"bu/ZAMIR_ISARET EKFIIL_SAHIS_SIZ_sUnUz"})]
        [TestCase("bunlar", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr"})]
        [TestCase("bunların", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr IC_HAL_ILGI_(n)Un"})]
        [TestCase("bunlarındır",
            new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr IC_HAL_ILGI_(n)Un EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bunlarınki", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr IC_HAL_ILGI_(n)Un IC_AITLIK_ki"})]
        [TestCase("bunları", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr IC_HAL_BELIRTME_(y)U"})]
        [TestCase("bunlara", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr IC_HAL_YONELME_(y)A"})]
        [TestCase("bunlarda", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr IC_HAL_BULUNMA_DA"})]
        [TestCase("bunlardan", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr IC_HAL_AYRILMA_DAn"})]
        [TestCase("bunlarla", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr IC_HAL_VASITA_(y)lA"})]
        [TestCase("bunlarca", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr IY_ZARF_CA"})]
        [TestCase("bunlarsız", new[] {"eksik"}, Ignore = true)]
        [TestCase("şunlarsız", new[] {"eksik"}, Ignore = true)]
        [TestCase("bunlardır", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("bunlarız", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr EKFIIL_SAHIS_BIZ_(y)Uz"})]
        [TestCase("bunlarsınız", new[] {"bu/ZAMIR_ISARET ZAMIR_COGUL_lAr EKFIIL_SAHIS_SIZ_sUnUz"})]
        public void ZamirBuBunlarTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }


        [TestCase("kendi", new[] {"kendi/ZAMIR_DONUSLULUK"})]
        [TestCase("kendim", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BEN_(U)m"})]
        [TestCase("kendin", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n"})]
        [TestCase("kendisi", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_O_(s)U"})]
        [TestCase("kendimiz", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BIZ_(U)mUz"})]
        [TestCase("kendiniz",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n EKFIIL_SAHIS_BIZ_(y)Uz",
                "kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SIZ_(U)nUz"
            })]
        [TestCase("kendileri", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_ONLAR_lArI"})]
        [TestCase("kendimi", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BEN_(U)m IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kendini",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n IC_HAL_BELIRTME_(y)U",
                "kendi/ZAMIR_DONUSLULUK IC_HAL_BELIRTME_(y)U"
            })]
        [TestCase("kendisini", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_O_(s)U IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kendimizi", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kendinizi", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kendilerini", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_ONLAR_lArI IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kendimin", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BEN_(U)m IC_HAL_ILGI_(n)Un"})]
        [TestCase("kendinin",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n IC_HAL_ILGI_(n)Un",
                "kendi/ZAMIR_DONUSLULUK IC_HAL_ILGI_(n)Un"
            })]
        [TestCase("kendisinin", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_O_(s)U IC_HAL_ILGI_(n)Un"})]
        [TestCase("kendimizin", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_ILGI_(n)Un"})]
        [TestCase("kendinizin", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_ILGI_(n)Un"})]
        [TestCase("kendilerinin", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_ONLAR_lArI IC_HAL_ILGI_(n)Un"})]
        [TestCase("kendime", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BEN_(U)m IC_HAL_YONELME_(y)A"})]
        [TestCase("kendine",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n IC_HAL_YONELME_(y)A",
                "kendi/ZAMIR_DONUSLULUK IC_HAL_YONELME_(y)A"
            })]
        [TestCase("kendisine", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_O_(s)U IC_HAL_YONELME_(y)A"})]
        [TestCase("kendimize", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_YONELME_(y)A"})]
        [TestCase("kendinize", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_YONELME_(y)A"})]
        [TestCase("kendilerine", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_ONLAR_lArI IC_HAL_YONELME_(y)A"})]
        [TestCase("kendimde", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BEN_(U)m IC_HAL_BULUNMA_DA"})]
        [TestCase("kendinde",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n IC_HAL_BULUNMA_DA",
                "kendi/ZAMIR_DONUSLULUK IC_HAL_BULUNMA_DA"
            })]
        [TestCase("kendisinde", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_O_(s)U IC_HAL_BULUNMA_DA"})]
        [TestCase("kendimizde", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_BULUNMA_DA"})]
        [TestCase("kendinizde", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_BULUNMA_DA"})]
        [TestCase("kendilerinde", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_ONLAR_lArI IC_HAL_BULUNMA_DA"})]
        [TestCase("kendimden", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BEN_(U)m IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendinden",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n IC_HAL_AYRILMA_DAn",
                "kendi/ZAMIR_DONUSLULUK IC_HAL_AYRILMA_DAn"
            })]
        [TestCase("kendisinden", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_O_(s)U IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendimizden", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendinizden", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendilerinden", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_ONLAR_lArI IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendimce", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BEN_(U)m IY_ZARF_CA"})]
        [TestCase("kendince",
            new[]
            {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n IY_ZARF_CA", "kendi/ZAMIR_DONUSLULUK IY_ZARF_CA"})]
        [TestCase("kendisince", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_O_(s)U IY_ZARF_CA"})]
        [TestCase("kendimizce", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BIZ_(U)mUz IY_ZARF_CA"})]
        [TestCase("kendinizce", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SIZ_(U)nUz IY_ZARF_CA"})]
        [TestCase("kendilerince", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_ONLAR_lArI IY_ZARF_CA"})]
        [TestCase("kendimle", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BEN_(U)m IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendinle", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendisiyle", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_O_(s)U IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendimizle", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendinizle", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendileriyle", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_ONLAR_lArI IC_HAL_VASITA_(y)lA"})]
        [TestCase("kendidir", new[] {"kendi/ZAMIR_DONUSLULUK EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("kendimdir", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BEN_(U)m EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("kendindir", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("kendimizdir", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_BIZ_(U)mUz EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("kendinizdir",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SEN_(U)n EKFIIL_SAHIS_BIZ_(y)Uz EKFIIL_TANIMLAMA_DUr",
                "kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_SIZ_(U)nUz EKFIIL_TANIMLAMA_DUr"
            })]
        [TestCase("kendileridir", new[] {"kendi/ZAMIR_DONUSLULUK IC_SAHIPLIK_ONLAR_lArI EKFIIL_TANIMLAMA_DUr"})
        ]
        [TestCase("kendiliğimden",
            new[] {"kendi/ZAMIR_DONUSLULUK IY_ISIM_lUK IC_SAHIPLIK_BEN_(U)m IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendiliğinden",
            new[]
            {
                "kendi/ZAMIR_DONUSLULUK IY_ISIM_lUK IC_SAHIPLIK_O_(s)U IC_HAL_AYRILMA_DAn",
                "kendi/ZAMIR_DONUSLULUK IY_ISIM_lUK IC_SAHIPLIK_SEN_(U)n IC_HAL_AYRILMA_DAn"
            })]
        [TestCase("kendiliğimizden",
            new[] {"kendi/ZAMIR_DONUSLULUK IY_ISIM_lUK IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendiliğinizden",
            new[] {"kendi/ZAMIR_DONUSLULUK IY_ISIM_lUK IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_AYRILMA_DAn"})]
        [TestCase("kendiliklerinden",
            new[] {"kendi/ZAMIR_DONUSLULUK IY_ISIM_lUK IC_SAHIPLIK_ONLAR_lArI IC_HAL_AYRILMA_DAn"})]
        public void ZamirKendiTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }


        [TestCase("kim", new[] {"kim/ZAMIR_SORU"})]
        [TestCase("kimler", new[] {"kim/ZAMIR_SORU IC_COGUL_lAr", "kim/ZAMIR_SORU EKFIIL_SAHIS_ONLAR_lAr"})]
        [TestCase("kimi", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_O_(s)U", "kim/ZAMIR_SORU IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kimleri",
            new[]
            {
                "kim/ZAMIR_SORU IC_COGUL_lAr IC_SAHIPLIK_O_(s)U",
                "kim/ZAMIR_SORU IC_COGUL_lAr IC_HAL_BELIRTME_(y)U", "kim/ZAMIR_SORU IC_SAHIPLIK_ONLAR_lArI"
            }
            )]
        [TestCase("kimin", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_SEN_(U)n", "kim/ZAMIR_SORU IC_HAL_ILGI_(n)Un"})]
        [TestCase("kimlerin",
            new[]
            {
                "kim/ZAMIR_SORU IC_COGUL_lAr IC_SAHIPLIK_SEN_(U)n",
                "kim/ZAMIR_SORU IC_COGUL_lAr IC_HAL_ILGI_(n)Un"
            })]
        [TestCase("kime", new[] {"kim/ZAMIR_SORU IC_HAL_YONELME_(y)A"})]
        [TestCase("kimlere", new[] {"kim/ZAMIR_SORU IC_COGUL_lAr IC_HAL_YONELME_(y)A"})]
        [TestCase("kimde", new[] {"kim/ZAMIR_SORU IC_HAL_BULUNMA_DA"})]
        [TestCase("kimlerde", new[] {"kim/ZAMIR_SORU IC_COGUL_lAr IC_HAL_BULUNMA_DA"})]
        [TestCase("kimden", new[] {"kim/ZAMIR_SORU IC_HAL_AYRILMA_DAn"})]
        [TestCase("kimlerden", new[] {"kim/ZAMIR_SORU IC_COGUL_lAr IC_HAL_AYRILMA_DAn"})]
        [TestCase("kimim", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BEN_(U)m", "kim/ZAMIR_SORU EKFIIL_SAHIS_BEN_(y)Um"}
            )]
        [TestCase("kimin", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_SEN_(U)n", "kim/ZAMIR_SORU IC_HAL_ILGI_(n)Un"})]
        [TestCase("kimimiz", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BIZ_(U)mUz"})]
        [TestCase("kiminiz",
            new[]
            {
                "kim/ZAMIR_SORU IC_SAHIPLIK_SEN_(U)n EKFIIL_SAHIS_BIZ_(y)Uz",
                "kim/ZAMIR_SORU IC_SAHIPLIK_SIZ_(U)nUz"
            })]
        [TestCase("kimimi", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BEN_(U)m IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kimini",
            new[]
            {
                "kim/ZAMIR_SORU IC_SAHIPLIK_O_(s)U IC_HAL_BELIRTME_(y)U",
                "kim/ZAMIR_SORU IC_SAHIPLIK_SEN_(U)n IC_HAL_BELIRTME_(y)U"
            })]
        [TestCase("kimimizi", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kiminizi", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kimimin", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BEN_(U)m IC_HAL_ILGI_(n)Un"})]
        [TestCase("kiminin",
            new[]
            {
                "kim/ZAMIR_SORU IC_SAHIPLIK_O_(s)U IC_HAL_ILGI_(n)Un",
                "kim/ZAMIR_SORU IC_SAHIPLIK_SEN_(U)n IC_HAL_ILGI_(n)Un"
            })]
        [TestCase("kimimizin", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_ILGI_(n)Un"})]
        [TestCase("kiminizin", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_ILGI_(n)Un"})]
        [TestCase("kimime", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BEN_(U)m IC_HAL_YONELME_(y)A"})]
        [TestCase("kimine",
            new[]
            {
                "kim/ZAMIR_SORU IC_SAHIPLIK_O_(s)U IC_HAL_YONELME_(y)A",
                "kim/ZAMIR_SORU IC_SAHIPLIK_SEN_(U)n IC_HAL_YONELME_(y)A"
            })]
        [TestCase("kimimize", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_YONELME_(y)A"})]
        [TestCase("kiminize", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_YONELME_(y)A"})]
        [TestCase("kimimde", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BEN_(U)m IC_HAL_BULUNMA_DA"})]
        [TestCase("kiminde",
            new[]
            {
                "kim/ZAMIR_SORU IC_SAHIPLIK_O_(s)U IC_HAL_BULUNMA_DA",
                "kim/ZAMIR_SORU IC_SAHIPLIK_SEN_(U)n IC_HAL_BULUNMA_DA"
            })]
        [TestCase("kimimizde", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_BULUNMA_DA"})]
        [TestCase("kiminizde", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_BULUNMA_DA"})]
        [TestCase("kimimden", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BEN_(U)m IC_HAL_AYRILMA_DAn"})]
        [TestCase("kiminden",
            new[]
            {
                "kim/ZAMIR_SORU IC_SAHIPLIK_O_(s)U IC_HAL_AYRILMA_DAn",
                "kim/ZAMIR_SORU IC_SAHIPLIK_SEN_(U)n IC_HAL_AYRILMA_DAn"
            })]
        [TestCase("kimimizden", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_AYRILMA_DAn"})]
        [TestCase("kimimle", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BEN_(U)m IC_HAL_VASITA_(y)lA"})]
        [TestCase("kiminle",
            new[]
            {
                "kim/ZAMIR_SORU IC_SAHIPLIK_SEN_(U)n IC_HAL_VASITA_(y)lA",
                "kim/ZAMIR_SORU IC_HAL_ILGI_(n)Un IC_HAL_VASITA_(y)lA"
            })]
        [TestCase("kimiyle", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_O_(s)U IC_HAL_VASITA_(y)lA"})]
        [TestCase("kimimizle", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_BIZ_(U)mUz IC_HAL_VASITA_(y)lA"})]
        [TestCase("kiminizle", new[] {"kim/ZAMIR_SORU IC_SAHIPLIK_SIZ_(U)nUz IC_HAL_VASITA_(y)lA"})]
        public void ZamirKimTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }

        [TestCase("kimisi", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_O_(s)U"})]
        [TestCase("kimisince", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_O_(s)U IY_ZARF_CA"})]
        [TestCase("kimisine", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_O_(s)U IC_HAL_YONELME_(y)A"})]
        [TestCase("kimisini", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_O_(s)U IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kimisinde", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_O_(s)U IC_HAL_BULUNMA_DA"})]
        [TestCase("kimisinden", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_O_(s)U IC_HAL_AYRILMA_DAn"})]
        [TestCase("kimisiyle", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_O_(s)U IC_HAL_VASITA_(y)lA"})]
        [TestCase("kimisinin", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_O_(s)U IC_HAL_ILGI_(n)Un"})]
        [TestCase("kimisininki",
            new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_O_(s)U IC_HAL_ILGI_(n)Un IC_AITLIK_ki"})]
        [TestCase("kimisinindir",
            new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_O_(s)U IC_HAL_ILGI_(n)Un EKFIIL_TANIMLAMA_DUr"})]
        [TestCase("kimileri", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_ONLAR_lArI"})]
        [TestCase("kimilerince", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_ONLAR_lArI IY_ZARF_CA"})]
        [TestCase("kimilerine", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_ONLAR_lArI IC_HAL_YONELME_(y)A"})]
        [TestCase("kimilerini", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_ONLAR_lArI IC_HAL_BELIRTME_(y)U"})]
        [TestCase("kimilerinde", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_ONLAR_lArI IC_HAL_BULUNMA_DA"})]
        [TestCase("kimilerinden", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_ONLAR_lArI IC_HAL_AYRILMA_DAn"})]
        [TestCase("kimileriyle", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_ONLAR_lArI IC_HAL_VASITA_(y)lA"})]
        [TestCase("kimilerinin", new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_ONLAR_lArI IC_HAL_ILGI_(n)Un"})]
        [TestCase("kimilerininki",
            new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_ONLAR_lArI IC_HAL_ILGI_(n)Un IC_AITLIK_ki"})]
        [TestCase("kimilerinindir",
            new[] {"kimi/ZAMIR_BELIRSIZLIK IC_SAHIPLIK_ONLAR_lArI IC_HAL_ILGI_(n)Un EKFIIL_TANIMLAMA_DUr"})
        ]
        public void ZamirKimiTest(string token, string[] analyses)
        {
            Tester.ContainsAnalyses(token, analyses);
        }
    }
}