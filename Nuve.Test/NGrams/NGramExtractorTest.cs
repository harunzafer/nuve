using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Nuve.NGrams;

namespace Nuve.Test.NGrams
{
    [TestFixture]
    internal class NGramExtractorTest
    {
        private const string Text = "one two three four five one two three four";
        private static readonly IList<string> Tokens = Text.Split(null);
        private const int Unigram = 1;
        private const int Bigram = 2;
        private const int Trigram = 3;

// ReSharper disable InconsistentNaming        

        //Unigrams
        private static readonly NGram one = new NGram("one");
        private static readonly NGram two = new NGram("two");
        private static readonly NGram three = new NGram("three");
        private static readonly NGram four = new NGram("four");
        private static readonly NGram five = new NGram("five");

        //Bigrams
        private static readonly NGram one_two = new NGram("one", "two");
        private static readonly NGram two_three = new NGram("two", "three");
        private static readonly NGram three_four = new NGram("three", "four");
        private static readonly NGram four_five = new NGram("four", "five");
        private static readonly NGram five_one = new NGram("five", "one");

        //Trigrams
        private static readonly NGram one_two_three = new NGram("one", "two", "three");
        private static readonly NGram two_three_four = new NGram("two", "three", "four");
        private static readonly NGram three_four_five = new NGram("three", "four", "five");
        private static readonly NGram four_five_one = new NGram("four", "five", "one");
        private static readonly NGram five_one_two = new NGram("five", "one", "two");

        

// ReSharper restore InconsistentNaming

        [Test]
        public void TestExtractAsList()
        {
            var extractor = new NGramExtractor(Unigram);
            
            
            var actual = extractor.ExtractAsList(Tokens);
            var expected = new[] {one, two, three, four, five, one, two, three, four};
            CollectionAssert.AreEqual(expected, actual);

            extractor = new NGramExtractor(Bigram);
            actual = extractor.ExtractAsList(Tokens);
            expected = new[] {one_two, two_three, three_four, four_five, five_one, one_two, two_three, three_four};
            CollectionAssert.AreEqual(expected, actual);

            extractor = new NGramExtractor(Trigram);
            actual = extractor.ExtractAsList(Tokens);
            expected = new[]
            {one_two_three, two_three_four, three_four_five, four_five_one, five_one_two, one_two_three, two_three_four};
            CollectionAssert.AreEqual(expected, actual);

            extractor = new NGramExtractor(Unigram, Bigram);
            actual = extractor.ExtractAsList(Tokens);
            expected = new[]
            {
                one, one_two, two, two_three, three, three_four, four, four_five, five, five_one, one, one_two, two,
                two_three, three, three_four, four
            };
            CollectionAssert.AreEqual(expected, actual);

            extractor = new NGramExtractor(Bigram, Trigram);
            actual = extractor.ExtractAsList(Tokens);
            expected = new[]
            {
                one_two, one_two_three, two_three, two_three_four, three_four,
                three_four_five, four_five, four_five_one, five_one, five_one_two, one_two, one_two_three, two_three,
                two_three_four, three_four
            };
            CollectionAssert.AreEqual(expected, actual);

            extractor = new NGramExtractor(Unigram, Trigram);
            actual = extractor.ExtractAsList(Tokens);
            expected = new[]
            {
                one, one_two, one_two_three, 
                two, two_three, two_three_four, 
                three, three_four, three_four_five, 
                four, four_five, four_five_one, 
                five, five_one, five_one_two, 
                one, one_two, one_two_three, 
                two, two_three, two_three_four, 
                three, three_four, 
                four
            };
            CollectionAssert.AreEqual(expected, actual);

            
            
        }

        [Test]
        public void TestExtractAsSet()
        {
            var extractor = new NGramExtractor(Unigram);
            var actual = extractor.ExtractAsSet(Tokens);
            var expected = new[] {one, two, three, four, five};
            CollectionAssert.AreEquivalent(expected, actual);

            extractor = new NGramExtractor(Bigram);
            actual = extractor.ExtractAsSet(Tokens);
            expected = new[] {one_two, two_three, three_four, four_five, five_one};
            CollectionAssert.AreEquivalent(expected, actual);

            extractor = new NGramExtractor(Trigram);
            actual = extractor.ExtractAsSet(Tokens);
            expected = new[] {one_two_three, two_three_four, three_four_five, four_five_one, five_one_two};
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void TestExtractAsDictionary()
        {
            var extractor = new NGramExtractor(Unigram);
            var actual = extractor.ExtractAsDictionary(Tokens);
            var expected = new Dictionary<NGram, int>
            {
                {one, 2},
                {two, 2},
                {three, 2},
                {four, 2},
                {five, 1}
            };
            CollectionAssert.AreEquivalent(expected, actual);

            extractor = new NGramExtractor(Bigram);
            actual = extractor.ExtractAsDictionary(Tokens);
            expected = new Dictionary<NGram, int>
            {
                {one_two, 2},
                {two_three, 2},
                {three_four, 2},
                {four_five, 1},
                {five_one, 1}
            };
            CollectionAssert.AreEquivalent(expected, actual);

            extractor = new NGramExtractor(Trigram);
            actual = extractor.ExtractAsDictionary(Tokens);
            expected = new Dictionary<NGram, int>
            {
                {one_two_three, 2},
                {two_three_four, 2},
                {four_five_one, 1},
                {three_four_five, 1},
                {five_one_two, 1},
            };
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void TestExtractLetterNGramsAsList()
        {
            var extractor = new NGramExtractor(Bigram, Trigram);
            var tokens = "beşiktaş".ToCharArray().Select(x => x.ToString());
            var actual = extractor.ExtractAsList(tokens);


            
        }
    }
}