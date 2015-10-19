using System.Linq;
using Nuve.Lang;
using Nuve.Morphologic.Structure;
using NUnit.Framework;

namespace Nuve.Test.Generation
{
    [TestFixture]
    internal class NounGenerationTest
    {
        private static readonly Language Tr = Language.Turkish;

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
        public void TestStrictGeneration2()
        {
            var root = Tr.GetRootsHavingSurface("gel").First();
            var word = new Word(root);
            var copy = Word.CopyOf(word);

            word.AddSuffix(Tr.GetSuffix("IC_COGUL_lAr"), Tr);
            
            Assert.True(copy.Equals(word));
            Assert.True(word.Equals(copy));

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

    }
}