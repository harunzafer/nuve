using NUnit.Framework;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Test.Orthographic
{
    [TestFixture]
    class NounGenerationTest
    {
        private Language tr;
        private Word word;

        [SetUp]
        public void Init()
        {
            tr = Language.Turkish;
        }

        [TestCase("kitap", Result = "kitaplarımdakilerden")]
        [TestCase("kalem", Result = "kalemlerimdekilerden")]
        public string LerimdekilerdenTest(string rootWord)
        {
            Root root = tr.Lexicon.Roots.Get(rootWord)[0];
            word = new Word(root);
            word.AddSuffix(tr.Lexicon.GetSuffix("IC_COGUL_lAr"));
            word.AddSuffix(tr.Lexicon.GetSuffix("IC_SAHIPLIK_BEN_(U)m"));
            word.AddSuffix(tr.Lexicon.GetSuffix("IC_HAL_BULUNMA_DA"));
            word.AddSuffix(tr.Lexicon.GetSuffix("IC_AITLIK_ki"));
            word.AddSuffix(tr.Lexicon.GetSuffix("IC_COGUL_lAr"));
            word.AddSuffix(tr.Lexicon.GetSuffix("IC_HAL_AYRILMA_DAn"));
            
            return word.GetSurface();
        }
    }
}
