using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Nuve.NGrams;

namespace Nuve.Test.NGrams
{
    [Ignore]
    [TestFixture]
    internal class NGramModelTest
    {
        private const int Unigram = 1;
        private const int Bigram = 2;
        private const int Trigram = 3;

        [Test]
        public void AddStartStopSymbolsTest()
        {
            var tokens = new[] { "this", "is", "a", "test" };
            var actual = tokens.ToList();
            var expected = tokens.ToList();
            var model = new NGramModel(Unigram);
            model.AddStartStopSymbols(actual);
            CollectionAssert.AreEqual(expected, actual);

            model = new NGramModel(Bigram);
            actual = tokens.ToList();
            expected = new[] { "<s0>", "this", "is", "a", "test", "</s>" }.ToList();
            model.AddStartStopSymbols(actual);
            CollectionAssert.AreEqual(expected, actual);

            model = new NGramModel(Trigram);
            actual = tokens.ToList();
            expected = new[] { "<s1>", "<s0>", "this", "is", "a", "test", "</s>" }.ToList();
            model.AddStartStopSymbols(actual);
            CollectionAssert.AreEqual(expected, actual);

            model = new NGramModel(4);
            actual = tokens.ToList();
            expected = new[] { "<s2>", "<s1>", "<s0>", "this", "is", "a", "test", "</s>" }.ToList();
            model.AddStartStopSymbols(actual);
            CollectionAssert.AreEqual(expected, actual);
        }

        private const string Text1 = "I am Sam";
        private const string Text2 = "Sam I am";
        private const string Text3 = "I do not like green eggs and ham";

        [Test]
        public void TestGetSequenceProbabilityForUnigramModel()
        {
            var model = new NGramModel(Unigram);
            
            model.AddSentence(Text1.Split(null).ToList());
            model.AddSentence(Text2.Split(null).ToList());
            model.AddSentence(Text3.Split(null).ToList());
            
            var actual = model.GetSentenceProbability("I");
            var expected = 0.21;
            Assert.AreEqual(expected, Math.Round(actual, 2));

            actual = model.GetSentenceProbability("Sam");
            expected = 0.14;
            Assert.AreEqual(expected, Math.Round(actual, 2));

            actual = model.GetSentenceProbability("am");
            expected = 0.14;
            Assert.AreEqual(expected, Math.Round(actual, 2));

            actual = model.GetSentenceProbability("the");
            expected = 0.00;
            Assert.AreEqual(expected, Math.Round(actual, 2));

            //p(I) * p(am)
            actual = model.GetSentenceProbability("I", "am");
            expected = 0.0306;
            Assert.AreEqual(expected, Math.Round(actual, 4));

            //p(I) * p(do)
            actual = model.GetSentenceProbability("I", "do");
            expected = 0.015;
            Assert.AreEqual(expected, Math.Round(actual, 3));

            //p(Sam) * p(I)
            actual = model.GetSentenceProbability("Sam", "I");
            expected = 0.0306;
            Assert.AreEqual(expected, Math.Round(actual, 4));

            //p(I) * p(am) * p(Sam)
            actual = model.GetSentenceProbability("I", "am", "Sam");
            expected = 0.0044;
            Assert.AreEqual(expected, Math.Round(actual, 4));

            //p(Sam) * p(I) * p(am)
            actual = model.GetSentenceProbability("Sam", "I", "am");
            expected = 0.0044;
            Assert.AreEqual(expected, Math.Round(actual, 4));
        }


        [Test]
        public void TestGetSequenceProbabilityForBigramModel()
        {
            var model = new NGramModel(Bigram);

            model.AddSentence(Text1.Split(null).ToList());
            model.AddSentence(Text2.Split(null).ToList());
            model.AddSentence(Text3.Split(null).ToList());

            var actual = model.GetSentenceProbability("I" ,"am", "Sam");
            var expected = .111;
            Assert.AreEqual(expected, Math.Round(actual, 3));

            actual = model.GetSentenceProbability("Sam", "I", "am");
            expected = .056;
            Assert.AreEqual(expected, Math.Round(actual, 3));

            actual = model.GetSentenceProbability("I", "do", "not", "like", "green", "eggs", "and", "ham");
            expected = .222;
            Assert.AreEqual(expected, Math.Round(actual, 3));

            actual = model.GetSentenceProbability("I", "am", "Sam", "I", "am");
            expected = .037;
            Assert.AreEqual(expected, Math.Round(actual, 3));

            actual = model.GetSentenceProbability("I", "am");
            expected = .222;
            Assert.AreEqual(expected, Math.Round(actual, 3));

            actual = model.GetSentenceProbability("I", "am", "the");
            expected = .0;
            Assert.AreEqual(expected, actual);
            
        }

        [Test]
        public void TestGetSequenceProbabilityForTrigramModel()
        {
            var model = new NGramModel(Trigram);

            model.AddSentence(Text1.Split(null).ToList());
            model.AddSentence(Text2.Split(null).ToList());
            model.AddSentence(Text3.Split(null).ToList());

            var actual = model.GetSentenceProbability("I", "am", "Sam");
            var expected = .167;
            Assert.AreEqual(expected, Math.Round(actual, 3));

            actual = model.GetSentenceProbability("Sam", "I", "am");
            expected = .167;
            Assert.AreEqual(expected, Math.Round(actual, 3));

            actual = model.GetSentenceProbability("I", "do", "not", "like", "green", "eggs", "and", "ham");
            expected = .333;
            Assert.AreEqual(expected, Math.Round(actual, 3));

            actual = model.GetSentenceProbability("I", "am", "Sam", "I", "am");
            expected = .000;
            Assert.AreEqual(expected, Math.Round(actual, 3));

            actual = model.GetSentenceProbability("I", "am");
            expected = .167;
            Assert.AreEqual(expected, Math.Round(actual, 3));
        }

        //[Test]
        //public void TestTrigramModel()
        //{

        //    // P( am | <s>, I) = 1 / 2 = .5
        //    var actual = Math.Round(corpus.EstimateMaximumLikelihood("<s>", "I", "am"), 2);
        //    //diğerinin ismi ne?
        //    //ngram prob. sentence prob. sequence prob.
        //    Assert.AreEqual(0.5, actual);

        //    // P( am | <s>, I) = 1 / 2 = .5
        //    actual = Math.Round(corpus.EstimateMaximumLikelihood("<s>", "the", "am"), 2);
        //    Assert.AreEqual(0.5, actual);
        //}

        //[Test]
        //public void TestLanguageModel()
        //{

        //    // P( I | <s> ) = 2 / 3 = .67
        //    var actual = Math.Round(corpus.EstimateMaximumLikelihood("<s>", "I"), 2); 
        //    Assert.AreEqual(0.67, actual);

        //    // P( Sam | <s> ) = 1 / 3 = .33
        //    actual = Math.Round(corpus.EstimateMaximumLikelihood("<s>", "Sam"), 2);
        //    Assert.AreEqual(0.33, actual);

        //    // P( am | I ) = 2 / 3 = .67
        //    actual = Math.Round(corpus.EstimateMaximumLikelihood("I", "am"), 2);
        //    Assert.AreEqual(0.67, actual);

        //    // P( </s> | Sam ) = 1 / 2 = .5
        //    actual = Math.Round(corpus.EstimateMaximumLikelihood("Sam", "</s>"), 2);
        //    Assert.AreEqual(0.5, actual);

        //    // P( Sam | am ) = 1 / 2 = .5
        //    actual = Math.Round(corpus.EstimateMaximumLikelihood("am", "Sam"), 2);
        //    Assert.AreEqual(0.5, actual);

        //    // P( do | I ) = 1 / 3 = .33
        //    actual = Math.Round(corpus.EstimateMaximumLikelihood("I", "do"), 2);
        //    Assert.AreEqual(0.33, actual);

        //    // P( not | do ) = 1 / 1 = 1
        //    actual = Math.Round(corpus.EstimateMaximumLikelihood("do", "not"), 2);
        //    Assert.AreEqual(1, actual);

        //    // P( like | do ) = 0 / 1 = 0
        //    actual = Math.Round(corpus.EstimateMaximumLikelihood("do", "like"), 2);
        //    Assert.AreEqual(0, actual);

        //}

        //[Test]
        //public void TestUnigramModel()
        //{
        //    // P( I ) = 3 / 20 = .15
        //    var actual = Math.Round(corpus.EstimateMaximumLikelihood("I"), 2);
        //    Assert.AreEqual(0.15, actual);

        //    // P( Sam ) = 2 / 20 = .1
        //    actual = Math.Round(corpus.EstimateMaximumLikelihood("Sam"), 2);
        //    Assert.AreEqual(0.1, actual);

        //    // P( the ) = 0 / 20 = 0
        //    actual = Math.Round(corpus.EstimateMaximumLikelihood("the"), 2);
        //    Assert.AreEqual(0, actual);

        //}

    //    var trigams = new NGramDictionary(Trigram, isStartStopSymbolsUsed: true);

        //    trigams.AddSequence(Text1.Split(null).ToList());
        //    trigams.AddSequence(Text2.Split(null).ToList());
        //    trigams.AddSequence(Text3.Split(null).ToList());

        //    var start = trigams.StartSymbol;
        //    var stop = trigams.StopSymbol;

        //    int freq = trigams.GetFrequency(start, start, "I");
        //    Assert.AreEqual(2, freq);

        //    freq = trigams.GetFrequency(start, start, "Sam");
        //    Assert.AreEqual(1, freq);

        //    freq = trigams.GetFrequency(start, "I", "am");
        //    Assert.AreEqual(1, freq);

        //    freq = trigams.GetFrequency("I", "am", "Sam");
        //    Assert.AreEqual(1, freq);

        //    freq = trigams.GetFrequency("am", "Sam", stop);
        //    Assert.AreEqual(1, freq);
        //}

        //[Test]
        //public void TestUnigramsBigramsWithStartStopSymbols()
        //{
        //    var corpus = new NGramDictionary(Unigram, Bigram, true);
        //    corpus.AddSequence(Text1.Split(null).ToList());
        //    corpus.AddSequence(Text2.Split(null).ToList());
        //    corpus.AddSequence(Text3.Split(null).ToList());

        //    var ex = Assert.Throws<ArgumentException>(() => corpus.GetFrequency());
        //    Assert.That(ex.Message, Is.EqualTo(@"Length of nGramTokens (0) must not be greater than maxNGramSize or less than minNGramSize"));

        //    int freq = corpus.GetFrequency("I");
        //    Assert.AreEqual(3, freq);

        //    freq = corpus.GetFrequency("am");
        //    Assert.AreEqual(2, freq);

        //    freq = corpus.GetFrequency("not");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency("the");
        //    Assert.AreEqual(0, freq);

        //    freq = corpus.GetFrequency("I", "am");
        //    Assert.AreEqual(2, freq);

        //    freq = corpus.GetFrequency("Sam", "I");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency("am", "I");
        //    Assert.AreEqual(0, freq);

        //    var start = corpus.StartSymbol;
        //    var stop = corpus.StopSymbol;

        //    freq = corpus.GetFrequency(start);
        //    Assert.AreEqual(3, freq);

        //    freq = corpus.GetFrequency(stop);
        //    Assert.AreEqual(3, freq);

        //    freq = corpus.GetFrequency(start, "I");
        //    Assert.AreEqual(2, freq);

        //    freq = corpus.GetFrequency(start, "Sam");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency("am", stop);
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency(start, "am");
        //    Assert.AreEqual(0, freq);
        //}

        //[Test]
        //public void TestUnigramsBigramsTrigramsWithStartStopSymbols()
        //{
        //    var corpus = new NGramDictionary(Unigram, Trigram, true);
        //    corpus.AddSequence(Text1.Split(null).ToList());
        //    corpus.AddSequence(Text2.Split(null).ToList());
        //    corpus.AddSequence(Text3.Split(null).ToList());

        //    var ex = Assert.Throws<ArgumentException>(() => corpus.GetFrequency());
        //    Assert.That(ex.Message, Is.EqualTo(@"Length of nGramTokens (0) must not be greater than maxNGramSize or less than minNGramSize"));

        //    int freq = corpus.GetFrequency("I");
        //    Assert.AreEqual(3, freq);

        //    freq = corpus.GetFrequency("am");
        //    Assert.AreEqual(2, freq);

        //    freq = corpus.GetFrequency("not");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency("the");
        //    Assert.AreEqual(0, freq);

        //    freq = corpus.GetFrequency("I", "am");
        //    Assert.AreEqual(2, freq);

        //    freq = corpus.GetFrequency("Sam", "I");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency("am", "I");
        //    Assert.AreEqual(0, freq);

        //    freq = corpus.GetFrequency("I", "am", "Sam");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency("Sam", "I", "am");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency("not", "like", "green");
        //    Assert.AreEqual(1, freq);

        //    var start = corpus.StartSymbol;
        //    var stop = corpus.StopSymbol;

        //    freq = corpus.GetFrequency(start);
        //    Assert.AreEqual(3, freq);

        //    freq = corpus.GetFrequency(stop);
        //    Assert.AreEqual(3, freq);

        //    freq = corpus.GetFrequency(start, start);
        //    Assert.AreEqual(3, freq);

        //    freq = corpus.GetFrequency(start, "I");
        //    Assert.AreEqual(2, freq);

        //    freq = corpus.GetFrequency(start, "Sam");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency("am", stop);
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency(start, "am");
        //    Assert.AreEqual(0, freq);

        //    freq = corpus.GetFrequency(start, start, "I");
        //    Assert.AreEqual(2, freq);

        //    freq = corpus.GetFrequency(start, start, "Sam");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency(start, "I", "am");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency("I", "am", "Sam");
        //    Assert.AreEqual(1, freq);

        //    freq = corpus.GetFrequency("am", "Sam", stop);
        //    Assert.AreEqual(1, freq);
        //}

        
    }
}
