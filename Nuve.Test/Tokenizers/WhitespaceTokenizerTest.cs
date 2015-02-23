using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Nuve.Tokenizers;

namespace Nuve.Test.Tokenizers
{
    [TestFixture]
    internal class WhitespaceTokenizerTest
    {
        [TestCase("bu bir,  iki veya 3", 
            Result = new object[] { "bu", "bir,", "iki", "veya", "3" })]
        [TestCase("birden\n\nfazla\t \twhitespace bile olsa sorun değil", 
            Result = new object[] { "birden", "fazla", "whitespace", "bile", "olsa","sorun","değil" })]
        public IList<string> TestWhitespaceTokenizerReturnDelimiterFalse(string text)
        {
            var tokenizer = new WhitespaceTokenizer(false);
            return tokenizer.Tokenize(text);
        }

        [TestCase("bu bir,  iki veya 3", 
            Result = new object[] { "bu", " ", "bir,", "  ", "iki", " ", "veya", " ","3" })]
        [TestCase("birden\n\nfazla\t \twhitespace bile olsa sorun değil",
            Result = new object[] { "birden", "\n\n", "fazla", "\t \t", "whitespace", " " ,"bile", " ", "olsa", " ", "sorun", " ", "değil" })]
        public IList<string> TestWhitespaceTokenizerReturnDelimiterTrue(string text)
        {
            var tokenizer = new WhitespaceTokenizer(true);
            return tokenizer.Tokenize(text);
        }

    }
}
