using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nuve.Tokenizers
{
    /// <summary>
    /// Simple tokenizer that splits the text on whitespace and returns sequences of non-whitespace characters as tokens. 
    /// Note that any punctuation will be included in the tokenization. 
    /// White-space characters are defined by the Unicode standard and return true if they are passed to the Char.IsWhiteSpace method.
    /// </summary>
    public class WhitespaceTokenizer : ITokenizer
    {
        private readonly bool returnDelims;

        public WhitespaceTokenizer(bool returnDelims)
        {
            this.returnDelims = returnDelims;
        }

        public IList<string> Tokenize(string text)
        {
            if (!returnDelims)
            {
                return text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            }

            return Regex.Split(text, @"(\s+)");
        }
    }
}
