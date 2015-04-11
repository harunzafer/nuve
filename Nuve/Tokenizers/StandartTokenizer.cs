using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Nuve.Tokenizers
{
    /// <summary>
    ///     This tokenizer splits the text field into tokens, treating whitespace and punctuation as delimiters.
    ///     Delimiter characters are discarded
    ///     <para name="returnDelims" />
    ///     is not true
    /// </summary>
    public class StandartTokenizer : ITokenizer
    {
        private readonly string pattern;

        public StandartTokenizer(bool returnDelims)
        {
            pattern = returnDelims ? @"([\s\p{P}]+)" : @"[\s\p{P}]+";
        }

        public IList<string> Tokenize(string text)
        {
            return Regex.Split(text, pattern);
        }
    }
}