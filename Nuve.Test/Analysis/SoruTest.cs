using NUnit.Framework;

namespace Nuve.Test.Analysis
{
    public class SoruTest
    {
        public static string[] Soru =
        {
            "mı",
            "mi",
            "mu",
            "mü",
            "mısın",
            "misin",
            "musun",
            "müsün",
            "mıyım",
            "miyim",
            "muyum",
            "müyüm",
            "mısınız",
            "misiniz",
            "musunuz",
            "müsünüz",
            "mıyız",
            "miyiz",
            "muyuz",
            "müyüz",

        };

        [TestCase("mı", "mı/SORU")]
        [TestCase("mi", "mi/SORU")]
        [TestCase("mu", "mu/SORU")]
        [TestCase("mü", "mü/SORU")]
        [TestCase("mısın", "mı/SORU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("misin", "mi/SORU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("musun", "mu/SORU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("müsün", "mü/SORU sUn/EKFIIL_SAHIS_SEN_sUn")]
        [TestCase("mıyım", "mı/SORU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("miyim", "mi/SORU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("muyum", "mu/SORU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("müyüm", "mü/SORU yUm/EKFIIL_SAHIS_BEN_(y)Um")]
        [TestCase("mısınız", "mı/SORU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("misiniz", "mi/SORU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("musunuz", "mu/SORU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("müsünüz", "mü/SORU sUnUz/EKFIIL_SAHIS_SIZ_sUnUz")]
        [TestCase("mıyız", "mı/SORU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("miyiz", "mi/SORU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("muyuz", "mu/SORU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        [TestCase("müyüz", "mü/SORU yUz/EKFIIL_SAHIS_BIZ_(y)Uz")]
        public void SoruMuTest(string token, string analysis)
        {
            Tester.ContainsAnalysis(token, analysis);
        }

    }
}