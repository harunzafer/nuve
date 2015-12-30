using System;
using System.Collections.Generic;
using System.Linq;
using Nuve.Lang;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Test.Mock;
using NUnit.Framework;

namespace Nuve.Test.Generation
{
    [TestFixture]
    internal class NounGenerationTest
    {
        private static readonly Language Tr = Language.Turkish;

        [TestCase(null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", ExpectedException = typeof (ArgumentException))]
        [TestCase("undefined/ISIM IC_SAHIPLIK_BEN_(U)m", ExpectedException = typeof (NullReferenceException))]
        [TestCase("kalem/ISIM undefined", ExpectedException = typeof (NullReferenceException))]
        [TestCase(
            "kitap/ISIM IC_COGUL_lAr IC_SAHIPLIK_BEN_(U)m IC_HAL_BULUNMA_DA IC_AITLIK_ki IC_COGUL_lAr IC_HAL_AYRILMA_DAn",
            Result = "kitaplarımdakilerden")]
        [TestCase(
            "kalem/ISIM IC_COGUL_lAr IC_SAHIPLIK_BEN_(U)m IC_HAL_BULUNMA_DA IC_AITLIK_ki IC_COGUL_lAr IC_HAL_AYRILMA_DAn",
            Result = "kalemlerimdekilerden")]
        public static string TestFromStringGeneration(string str)
        {
            return Tr.GetWord(str).GetSurface();
        }

        [TestCase("kitap/ISIM", "IC_COGUL_lAr", "IC_SAHIPLIK_BEN_(U)m", "IC_HAL_BULUNMA_DA", "IC_AITLIK_ki",
            "IC_COGUL_lAr", "IC_HAL_AYRILMA_DAn",
            Result = "kitaplarımdakilerden")]
        public string TestGenerate(params string[] morphemes)
        {
            return Tr.Generate(morphemes).GetSurface();
        }


        [TestCase("kitap", Result = "kitaplarımdakilerden")]
        [TestCase("kalem", Result = "kalemlerimdekilerden")]
        public string TestGeneration(string rootWord)
        {
            var root = Tr.GetRootsHavingSurface(rootWord).First();

            var word = new Word(root);
            word.AddSuffix(Tr.GetSuffix("IC_COGUL_lAr"));
            word.AddSuffix(Tr.GetSuffix("IC_SAHIPLIK_BEN_(U)m"));
            word.AddSuffix(Tr.GetSuffix("IC_HAL_BULUNMA_DA"));
            word.AddSuffix(Tr.GetSuffix("IC_AITLIK_ki"));
            word.AddSuffix(Tr.GetSuffix("IC_COGUL_lAr"));
            word.AddSuffix(Tr.GetSuffix("IC_HAL_AYRILMA_DAn"));

            return word.GetSurface();
        }


        [TestCase("kitap", "IC_COGUL_lAr", Result = true)]
        [TestCase("gel", "IC_COGUL_lAr", Result = false)]
        public bool TestStrictGeneration(string rootWord, string suffixId)
        {
            var root = Tr.GetRootsHavingSurface(rootWord).First();
            var word = new Word(root);

            var suffix = Tr.GetSuffix(suffixId);
            return word.AddSuffix(suffix, Tr);
        }

        [Test]
        public static void LanguageGetRootTest()
        {
            //public Root GetRoot(string rootId)
            Assert.Throws<ArgumentException>(() => Tr.GetRoot("undefined"));
            Assert.Throws<ArgumentException>(() => Tr.GetRoot(""));
            Assert.Throws<ArgumentNullException>(() => Tr.GetRoot(null));
            Assert.Null(Tr.GetRoot("undefined/ISIM"));
            Assert.AreEqual(Tr.GetRoot("kitap/ISIM"), new MockRoot("ISIM", "kitap"));

            //public Root GetRoot(string lex, string pos)
            Assert.Null(Tr.GetRoot(null, "ISIM"));
            Assert.Null(Tr.GetRoot("kitap", null));
            Assert.Null(Tr.GetRoot(null, null));
            Assert.Null(Tr.GetRoot("", ""));
            Assert.Null(Tr.GetRoot("undefined", "ISIM"));
            Assert.Null(Tr.GetRoot("kitap", "undefined"));
            Assert.AreEqual(Tr.GetRoot("kitap", "ISIM"), new MockRoot("ISIM", "kitap"));
        }

        [Test]
        public void TestCopyOf()
        {
            var root = Tr.GetRootsHavingSurface("kitap").First();
            var word = new Word(root);
            word.AddSuffix(Tr.GetSuffix("IC_COGUL_lAr"));
            word.AddSuffix(Tr.GetSuffix("IC_SAHIPLIK_BEN_(U)m"));
            word.AddSuffix(Tr.GetSuffix("IC_HAL_BULUNMA_DA"));
            word.AddSuffix(Tr.GetSuffix("IC_AITLIK_ki"));
            word.AddSuffix(Tr.GetSuffix("IC_COGUL_lAr"));
            word.AddSuffix(Tr.GetSuffix("IC_HAL_AYRILMA_DAn"));

            var copy = Word.CopyOf(word);

            Assert.True(word.Equals(word));
            Assert.False(word.Equals(null));

            Assert.AreNotSame(word, copy);
            Assert.AreEqual(word.GetSurface(), copy.GetSurface());
            Assert.True(word.Equals(copy));
        }

        [Test]
        public void TestStrictGeneration2()
        {
            var root = Tr.GetRootsHavingSurface("gel").First();
            var word = new Word(root);
            var copy = Word.CopyOf(word);

            word.AddSuffix(Tr.GetSuffix("IC_COGUL_lAr"), Tr);

            Assert.True(copy.Equals(word));
            Assert.True(word.Equals(copy));
        }
    }
}