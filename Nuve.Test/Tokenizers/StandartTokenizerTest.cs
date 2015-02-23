using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Nuve.Tokenizers;

namespace Nuve.Test.Tokenizers
{
    [TestFixture]
    internal class StandartTokenizerTest
    {
        [TestCase("bu bir,  iki veya 3", 
            Result = new object[] { "bu", "bir", "iki", "veya", "3" })]
        public IList<string> TestStandartTokenizerReturnDelimiterFalse(string text)
        {
            var tokenizer = new StandartTokenizer(false);
            return tokenizer.Tokenize(text);
        }

        [TestCase("bu bir,  iki veya 3",
            Result = new object[] { "bu", " ", "bir", ",  ", "iki", " ","veya", " ","3" })]
        public IList<string> TestStandartTokenizerReturnDelimiterTrue(string text)
        {
            var tokenizer = new StandartTokenizer(true);
            return tokenizer.Tokenize(text);
        }

    }
}
