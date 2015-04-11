using System.Collections.Generic;
using NUnit.Framework;
using Nuve.Tokenizers;

namespace Nuve.Test.Tokenizers
{
    [TestFixture]
    internal class ClassicTokenizerTest
    {
        [TestCase("Please, email john.doe@foo.com by 03-09, re: m37-xq.",
            Result =
                new object[]
                {
                    "Please", "email", "john.doe@foo.com", "by", "03-09", "re", "m37-xq"
                })]
        public IList<string> TestClassicTokenizerReturnDelimiterFalse(string text)
        {
            var tokenizer = new ClassicTokenizer(false);
            IList<string> tokens = tokenizer.Tokenize(text);
            return tokens;
        }

        [TestCase("Please, email john.doe@foo.com by 03-09, re: m37-xq.",
            Result =
                new object[]
                {
                    "Please", ",", " ", "email", " ",
                    "john.doe@foo.com", " ", "by", " ",
                    "03-09", ",", " ", "re", ":", " ", "m37-xq", "."
                })]
        public IList<string> TestClassicTokenizerReturnDelimiterTrue(string text)
        {
            var tokenizer = new ClassicTokenizer(true);
            IList<string> tokens = tokenizer.Tokenize(text);
            return tokens;
        }
    }
}