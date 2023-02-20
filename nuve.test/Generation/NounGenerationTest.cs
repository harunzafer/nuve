using System;
using System.Collections.Generic;
using System.Linq;
using Nuve.Lang;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Test.Mock;


namespace Nuve.Test.Generation
{
    public class NounGenerationTest
    {
        private static readonly Language Tr = LanguageFactory.Create(LanguageType.Turkish);

        [Theory]
        [InlineData(
            "kitap/ISIM IC_COGUL_lAr IC_SAHIPLIK_BEN_(U)m IC_HAL_BULUNMA_DA IC_AITLIK_ki IC_COGUL_lAr IC_HAL_AYRILMA_DAn",
            "kitaplarımdakilerden")]
        [InlineData(
            "kalem/ISIM IC_COGUL_lAr IC_SAHIPLIK_BEN_(U)m IC_HAL_BULUNMA_DA IC_AITLIK_ki IC_COGUL_lAr IC_HAL_AYRILMA_DAn",
            "kalemlerimdekilerden")]
        public void TestFromStringGeneration(string str, string expected)
        {
            Assert.Equal(expected, Tr.GetWord(str).GetSurface());
        }

        [Theory]
        [InlineData(null, typeof (ArgumentNullException))]
        [InlineData("", typeof (ArgumentException))]
        [InlineData("undefined/ISIM IC_SAHIPLIK_BEN_(U)m", typeof (NullReferenceException))]
        [InlineData("kalem/ISIM undefined", typeof (NullReferenceException))]
        public void TestFromStringGeneration_ThrowsException(string str, Type expectedExceptionType){
                Assert.Throws(expectedExceptionType, ()=> Tr.GetWord(str).GetSurface());
        }

        [Theory]
        [InlineData( new string[] { "kitap/ISIM", "IC_COGUL_lAr", "IC_SAHIPLIK_BEN_(U)m", "IC_HAL_BULUNMA_DA", "IC_AITLIK_ki",
            "IC_COGUL_lAr", "IC_HAL_AYRILMA_DAn" }, "kitaplarımdakilerden")]
        public void TestGenerate(string[] morphemes, string expected)
        {
            Assert.Equal(expected, Tr.Generate(morphemes).GetSurface());
        }

        [Theory]
        [InlineData("kitap", "kitaplarımdakilerden")]
        [InlineData("kalem", "kalemlerimdekilerden")]
        public void TestGeneration(string rootWord, string expected)
        {
            var root = Tr.GetRootsHavingSurface(rootWord).First();
            var word = new Word(root);
            word.AddSuffix(Tr.GetSuffix("IC_COGUL_lAr"));
            word.AddSuffix(Tr.GetSuffix("IC_SAHIPLIK_BEN_(U)m"));
            word.AddSuffix(Tr.GetSuffix("IC_HAL_BULUNMA_DA"));
            word.AddSuffix(Tr.GetSuffix("IC_AITLIK_ki"));
            word.AddSuffix(Tr.GetSuffix("IC_COGUL_lAr"));
            word.AddSuffix(Tr.GetSuffix("IC_HAL_AYRILMA_DAn"));

            Assert.Equal(expected, word.GetSurface());
        }

        [Theory]
        [InlineData("kitap", "IC_COGUL_lAr", true)]
        [InlineData("gel", "IC_COGUL_lAr", false)]
        public void TestStrictGeneration(string rootWord, string suffixId, bool expected)
        {
            var root = Tr.GetRootsHavingSurface(rootWord).First();
            var word = new Word(root);
            var suffix = Tr.GetSuffix(suffixId);
            Assert.Equal(expected, word.AddSuffix(suffix, Tr));
        }

        [Fact]
        public static void LanguageGetRootTest()
        {
            //public Root GetRoot(string rootId)
            Assert.Throws<ArgumentException>(() => Tr.GetRoot("undefined"));
            Assert.Throws<ArgumentException>(() => Tr.GetRoot(""));
            Assert.Throws<ArgumentNullException>(() => Tr.GetRoot(null));
            Assert.Null(Tr.GetRoot("undefined/ISIM"));
            Assert.Equal(Tr.GetRoot("kitap/ISIM"), new MockRoot("ISIM", "kitap"));

            //public Root GetRoot(string lex, string pos)
            Assert.Null(Tr.GetRoot(null, "ISIM"));
            Assert.Null(Tr.GetRoot("kitap", null));
            Assert.Null(Tr.GetRoot(null, null));
            Assert.Null(Tr.GetRoot("", ""));
            Assert.Null(Tr.GetRoot("undefined", "ISIM"));
            Assert.Null(Tr.GetRoot("kitap", "undefined"));
            Assert.Equal(Tr.GetRoot("kitap", "ISIM"), new MockRoot("ISIM", "kitap"));
        }

        [Fact]
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

            Assert.NotSame(word, copy);
            Assert.Equal(word.GetSurface(), copy.GetSurface());
            Assert.True(word.Equals(copy));
        }

        [Fact]
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