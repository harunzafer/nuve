using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuve.Lang;
using Nuve.Morphologic.Structure;
using Nuve.Reader;
using Nuve.Test.Properties;
using NUnit.Framework;

namespace Nuve.Test.Reader
{
    [TestFixture]
    public class LanguageReaderParseTest
    {
        [Test]
        public void Test()
        {
            var data = new LanguageData(new LanguageType("tr", "test"))
            {
                OrthographyXml = Resources.orthography,
                MorphotacticsXml = Resources.morphotactics,
                RootTxt = Resources.root,
                SuffixTxt = Resources.suffix
            };

            var reader = new LanguageReader("");
            var lang = reader.Parse(data);

            var solutions = lang.Analyze("kitaplarım");

            Assert.AreEqual(1, solutions.Count);

            var analysis = "kitap/ISIM IC_COGUL_lAr IC_SAHIPLIK_BEN_(U)m";

            var surface = lang.GetWord(analysis).GetSurface();

            Assert.AreEqual("kitaplarım", surface);

            Assert.AreEqual(analysis, solutions.First().ToString());

        }
    }
}
