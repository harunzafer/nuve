using System;
using System.Linq;
using NUnit.Framework;
using Nuve.NGrams;

namespace Nuve.Test.NGrams
{
    [TestFixture]
    internal class NGramDictionaryTest
    {
        private const string Text1 = "I am Sam";
        private const string Text2 = "Sam I am";
        private const string Text3 = "I do not like green eggs and ham";
        private const int Unigram = 1;
        private const int Bigram = 2;
        private const int Trigram = 3;

        [Test]
        public void TestUnigrams()
        {
            var unigrams = new NGramDictionary(new NGramExtractor(Unigram));
            unigrams.AddSequence(Text1.Split(null).ToList());
            unigrams.AddSequence(Text2.Split(null).ToList());
            unigrams.AddSequence(Text3.Split(null).ToList());

            var ex = Assert.Throws<ArgumentException>(() => unigrams.GetFrequency());
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (0) must not be greater than maxNGramSize or less than minNGramSize"));

            ex = Assert.Throws<ArgumentException>(() => unigrams.GetFrequency("I", "am"));
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (2) must not be greater than maxNGramSize or less than minNGramSize"));

            int freq = unigrams.GetFrequency("I");
            Assert.AreEqual(3, freq);

            freq = unigrams.GetFrequency("am");
            Assert.AreEqual(2, freq);

            freq = unigrams.GetFrequency("not");
            Assert.AreEqual(1, freq);

            freq = unigrams.GetFrequency("the");
            Assert.AreEqual(0, freq);
        }

        [Test]
        public void TestBigrams()
        {
            var bigrams = new NGramDictionary(new NGramExtractor(Bigram));
            bigrams.AddSequence(Text1.Split(null).ToList());
            bigrams.AddSequence(Text2.Split(null).ToList());
            bigrams.AddSequence(Text3.Split(null).ToList());

            var ex = Assert.Throws<ArgumentException>(() => bigrams.GetFrequency());
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (0) must not be greater than maxNGramSize or less than minNGramSize"));

            ex = Assert.Throws<ArgumentException>(() => bigrams.GetFrequency("I"));
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (1) must not be greater than maxNGramSize or less than minNGramSize"));

            ex = Assert.Throws<ArgumentException>(() => bigrams.GetFrequency("I", "am", "sam"));
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (3) must not be greater than maxNGramSize or less than minNGramSize"));

            int freq = bigrams.GetFrequency("I", "am");
            Assert.AreEqual(2, freq);

            freq = bigrams.GetFrequency("Sam", "I");
            Assert.AreEqual(1, freq);

            freq = bigrams.GetFrequency("am", "I");
            Assert.AreEqual(0, freq);
        }

        [Test]
        public void TestTrigrams()
        {
            var trigams = new NGramDictionary(new NGramExtractor(Trigram));
            trigams.AddSequence(Text1.Split(null).ToList());
            trigams.AddSequence(Text2.Split(null).ToList());
            trigams.AddSequence(Text3.Split(null).ToList());

            var ex = Assert.Throws<ArgumentException>(() => trigams.GetFrequency());
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (0) must not be greater than maxNGramSize or less than minNGramSize"));

            ex = Assert.Throws<ArgumentException>(() => trigams.GetFrequency("I"));
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (1) must not be greater than maxNGramSize or less than minNGramSize"));

            ex = Assert.Throws<ArgumentException>(() => trigams.GetFrequency("I", "am"));
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (2) must not be greater than maxNGramSize or less than minNGramSize"));

            int freq = trigams.GetFrequency("I", "am", "Sam");
            Assert.AreEqual(1, freq);

            freq = trigams.GetFrequency("Sam", "I", "am");
            Assert.AreEqual(1, freq);

            freq = trigams.GetFrequency("not", "like", "green");
            Assert.AreEqual(1, freq);
        }


        [Test]
        public void TestUnigramsBigrams()
        {
            var corpus = new NGramDictionary(new NGramExtractor(Unigram, Bigram));
            corpus.AddSequence(Text1.Split(null).ToList());
            corpus.AddSequence(Text2.Split(null).ToList());
            corpus.AddSequence(Text3.Split(null).ToList());

            var ex = Assert.Throws<ArgumentException>(() => corpus.GetFrequency());
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (0) must not be greater than maxNGramSize or less than minNGramSize"));

            int freq = corpus.GetFrequency("I");
            Assert.AreEqual(3, freq);

            freq = corpus.GetFrequency("am");
            Assert.AreEqual(2, freq);

            freq = corpus.GetFrequency("not");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("the");
            Assert.AreEqual(0, freq);

            freq = corpus.GetFrequency("I", "am");
            Assert.AreEqual(2, freq);

            freq = corpus.GetFrequency("Sam", "I");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("am", "I");
            Assert.AreEqual(0, freq);
        }


        [Test]
        public void TestUnigramsBigramsTrigrams()
        {
            var corpus = new NGramDictionary(new NGramExtractor(Unigram, Trigram));
            corpus.AddSequence(Text1.Split(null).ToList());
            corpus.AddSequence(Text2.Split(null).ToList());
            corpus.AddSequence(Text3.Split(null).ToList());

            var ex = Assert.Throws<ArgumentException>(() => corpus.GetFrequency());
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (0) must not be greater than maxNGramSize or less than minNGramSize"));

            int freq = corpus.GetFrequency("I");
            Assert.AreEqual(3, freq);

            freq = corpus.GetFrequency("am");
            Assert.AreEqual(2, freq);

            freq = corpus.GetFrequency("not");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("the");
            Assert.AreEqual(0, freq);

            freq = corpus.GetFrequency("I", "am");
            Assert.AreEqual(2, freq);

            freq = corpus.GetFrequency("Sam", "I");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("am", "I");
            Assert.AreEqual(0, freq);

            freq = corpus.GetFrequency("I", "am", "Sam");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("Sam", "I", "am");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("not", "like", "green");
            Assert.AreEqual(1, freq);
        }

        [Test]
        public void TestUnigramsBigramsTrigramsWithStartStopSymbols()
        {
            const string text1 = "<s> <s> I am Sam </s>";
            const string text2 = "<s> <s> Sam I am </s>";
            const string text3 = "<s> <s> I do not like green eggs and ham </s>";

            var corpus = new NGramDictionary(new NGramExtractor(Unigram, Trigram));

            corpus.AddSequence(text1.Split(null).ToList());
            corpus.AddSequence(text2.Split(null).ToList());
            corpus.AddSequence(text3.Split(null).ToList());

            var ex = Assert.Throws<ArgumentException>(() => corpus.GetFrequency());
            Assert.That(ex.Message,
                Is.EqualTo(@"Length of nGramTokens (0) must not be greater than maxNGramSize or less than minNGramSize"));

            int freq = corpus.GetFrequency("<s>");
            Assert.AreEqual(6, freq);

            freq = corpus.GetFrequency("</s>");
            Assert.AreEqual(3, freq);

            freq = corpus.GetFrequency("<s>", "<s>");
            Assert.AreEqual(3, freq);

            freq = corpus.GetFrequency("am");
            Assert.AreEqual(2, freq);

            freq = corpus.GetFrequency("not");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("the");
            Assert.AreEqual(0, freq);

            freq = corpus.GetFrequency("<s>", "I", "am");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("<s>", "<s>", "I");
            Assert.AreEqual(2, freq);

            freq = corpus.GetFrequency("<s>", "<s>", "Sam");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("<s>", "Sam", "I");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("am", "I");
            Assert.AreEqual(0, freq);

            freq = corpus.GetFrequency("I", "am", "</s>");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("am", "</s>");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("I", "am", "Sam");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("Sam", "I", "am");
            Assert.AreEqual(1, freq);

            freq = corpus.GetFrequency("not", "like", "green");
            Assert.AreEqual(1, freq);
        }
    }
}