using System.Linq;
using NUnit.Framework;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Test.Orthographic
{
    [TestFixture]
    internal class NounGenerationTest
    {
        [SetUp]
        public void Init()
        {
            tr = Language.Turkish;
        }

        private Language tr;
        private Word word;

        [TestCase("kitap", Result = "kitaplarımdakilerden")]
        [TestCase("kalem", Result = "kalemlerimdekilerden")]
        public string LerimdekilerdenTest(string rootWord)
        {
            Root root = tr.GetRootsHavingSurface(rootWord).First();
            word = new Word(root);
            word.AddSuffix(tr.GetSuffix("IC_COGUL_lAr"));
            word.AddSuffix(tr.GetSuffix("IC_SAHIPLIK_BEN_(U)m"));
            word.AddSuffix(tr.GetSuffix("IC_HAL_BULUNMA_DA"));
            word.AddSuffix(tr.GetSuffix("IC_AITLIK_ki"));
            word.AddSuffix(tr.GetSuffix("IC_COGUL_lAr"));
            word.AddSuffix(tr.GetSuffix("IC_HAL_AYRILMA_DAn"));

            return word.GetSurface();
        }
    }
}