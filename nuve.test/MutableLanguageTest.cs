using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuve.Lang;
using NUnit.Framework;

namespace Nuve.Test
{
    [TestFixture]
    class MutableLanguageTest
    {
        [Test]
        public void Test()
        {
            var tr = LanguageFactory.Create(LanguageType.Turkish);
            var newTr = MutableLanguage.CopyFrom(tr);

            var entry = new RootEntry(
                lex: "başa gel",
                pos: "FIIL",
                surfaces: new[] {"başa gel"},
                labels: new[] {"cverb"},
                rules: Enumerable.Empty<string>());

            Assert.True(newTr.TryAdd(entry));

            var solutions = tr.Analyze("başa gelen");

            Assert.AreEqual(0, solutions.Count);

            var solutionsExtendedTr = newTr.Analyze("başa gelen");

            Assert.AreEqual(1, solutionsExtendedTr.Count);

            Assert.AreEqual("başa gel/FIIL FIILIMSI_SIFAT_(y)An", solutionsExtendedTr[0].Analysis);
        }
    }
}