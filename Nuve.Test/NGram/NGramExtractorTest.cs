using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Nuve.NGram;

namespace Nuve.Test.NGram
{
    [TestFixture]
    internal class NGramExtractorTest
    {
        private const string Text = "one two three four five one two three four";
        private static readonly IList<string> Tokens = Text.Split(null);

        [Test]
        public void TestExtractAsList()
        {
            var extractor = new NGramExtractor(NGramSize.Unigram);
            var actual = extractor.ExtractAsList(Tokens);
            var expected = new[] {"one", "two", "three", "four", "five", "one", "two", "three", "four"};
            CollectionAssert.AreEqual(expected, actual);

            extractor = new NGramExtractor(NGramSize.Bigram);
            actual = extractor.ExtractAsList(Tokens);
            expected = new[] {"one two", "two three", "three four", "four five", "five one", "one two", "two three", "three four"};
            CollectionAssert.AreEqual(expected, actual);

            extractor = new NGramExtractor(NGramSize.Trigram);
            actual = extractor.ExtractAsList(Tokens);
            expected = new[]
            {"one two three", "two three four", "three four five", "four five one", "five one two", "one two three", "two three four"};
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestExtractAsSet()
        {
            var extractor = new NGramExtractor(NGramSize.Unigram);
            var actual = extractor.ExtractAsSet(Tokens);
            var expected = new[] {"one", "two", "three", "four", "five"};
            CollectionAssert.AreEquivalent(expected, actual);

            extractor = new NGramExtractor(NGramSize.Bigram);
            actual = extractor.ExtractAsSet(Tokens);
            expected = new[] {"one two", "two three", "three four", "four five", "five one"};
            CollectionAssert.AreEquivalent(expected, actual);

            extractor = new NGramExtractor(NGramSize.Trigram);
            actual = extractor.ExtractAsSet(Tokens);
            expected = new[] {"one two three", "two three four", "three four five", "four five one", "five one two"};
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void TestExtractAsDictionary()
        {
            var extractor = new NGramExtractor(NGramSize.Unigram);
            var actual = extractor.ExtractAsDictionary(Tokens);
            var expected = new Dictionary<string, int>
            {
                {"one", 2},
                {"two", 2},
                {"three", 2},
                {"four", 2},
                {"five", 1}
            };
            CollectionAssert.AreEquivalent(expected, actual);

            extractor = new NGramExtractor(NGramSize.Bigram);
            actual = extractor.ExtractAsDictionary(Tokens);
            expected = new Dictionary<string, int>
            {
                {"one two", 2},
                {"two three", 2},
                {"three four", 2},
                {"four five", 1},
                {"five one", 1}
            };
            CollectionAssert.AreEquivalent(expected, actual);

            extractor = new NGramExtractor(NGramSize.Trigram);
            actual = extractor.ExtractAsDictionary(Tokens);
            expected = new Dictionary<string, int>
            {
                {"one two three", 2},
                {"two three four", 2},
                {"four five one", 1},
                {"three four five", 1},
                {"five one two", 1},
            };
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}