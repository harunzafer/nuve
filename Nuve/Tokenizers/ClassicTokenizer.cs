using System.Collections.Generic;
using System.Linq;

namespace Nuve.Tokenizers
{
    /// <summary>
    ///     This tokenizer splits the text field into tokens, treating whitespace and punctuation as delimiters.
    ///     If
    ///     <param name="returnDelims"></param>
    ///     is false delimiter characters are discarded
    /// </summary>
    internal class ClassicTokenizer : RegexTokenizerBase
    {
        private const string Pattern = "("
                                       + RegexPattern.WhiteSpace + RegexPattern.Or
                                       + RegexPattern.URL + RegexPattern.Or
                                       + RegexPattern.Email + RegexPattern.Or
                                       + @"\w*\d+-[\w\d]+" + RegexPattern.Or
                                       + @"[\w\d]+-\w*\d+" + RegexPattern.Or
                                       + RegexPattern.WordAphostrope + RegexPattern.Or
                                       + RegexPattern.Word + RegexPattern.Or
                                       + RegexPattern.Integer + RegexPattern.Or
                                       + RegexPattern.LetterNotWhitespaceDigitWord
                                       + ")+";


        public ClassicTokenizer(bool returnDelims = false) : base(Pattern, returnDelims)
        {
        }

        protected override IList<string> RemoveDelimiters(IEnumerable<string> tokens)
        {
            return tokens.Where(x => char.IsLetterOrDigit(x[0])).ToArray();
        }
    }
}