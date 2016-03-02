using System.Collections.Generic;
using System.Linq;

namespace Nuve.Tokenizers
{
    public class NuveTokenizer : RegexTokenizerBase
    {
        private const string Pattern = "("
                                       + RegexPattern.WhiteSpace + RegexPattern.Or
                                       + RegexPattern.Ellipsis + RegexPattern.Or
                                       + RegexPattern.URL + RegexPattern.Or
                                       + RegexPattern.Email + RegexPattern.Or
                                       + RegexPattern.TurkishEWords + RegexPattern.Or
                                       + RegexPattern.Time + RegexPattern.Or
                                       + RegexPattern.WordAphostrope + RegexPattern.Or
                                       + RegexPattern.TurkishDouble + RegexPattern.Or
                                       + RegexPattern.Integer + RegexPattern.Or
                                       + RegexPattern.Word + RegexPattern.Or
                                       + RegexPattern.LetterNotWhitespaceDigitWord
                                       + ")+";

        public NuveTokenizer(bool returnDelims = false) : base(Pattern, returnDelims)
        {
        }


        protected override IList<string> RemoveDelimiters(IEnumerable<string> tokens)
        {
            return tokens.Where(x => char.IsLetterOrDigit(x[0])).ToList();
        }
    }
}