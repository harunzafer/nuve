using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Nuve.Tokenizers
{
    public abstract class RegexTokenizerBase : ITokenizer
    {
        private readonly Regex regex;

        private readonly bool returnDelims;

        protected RegexTokenizerBase(string regex, bool returnDelims = false)
        {
            this.regex = new Regex(regex);
            this.returnDelims = returnDelims;
        }

        public IList<string> Tokenize(string text)
        {
            var tokens = new List<string>();

            if (regex.IsMatch(text))
            {
                Match match = regex.Match(text);

                foreach (Capture capture in match.Groups[1].Captures)
                {
                    tokens.Add(capture.Value);
                }
            }

            if (!returnDelims)
            {
                return RemoveDelimiters(tokens);
            }

            return tokens;
        }

        protected abstract IList<string> RemoveDelimiters(IEnumerable<string> tokens);
    }
}