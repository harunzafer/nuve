using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nuve.Tokenizers
{
    class RegexSplitter : Splitter
    {
        private readonly string _pattern;

        public const string ClassicPattern = "(" + @"\s+|" + //space
                                      @"(?<=[^.])(\.\.\.)(?=\s)|" + //space
                                      @"https?://[-a-z0-9]+(\.[-a-z0-9]+)*\.[a-z]{2,4}(/[-a-z0-9R:@&#?=+,.!/~+'%$]+)?|" + //URL
                                      @"\w+(\.\w+)*@\w+\.\w+(\.\w+)*|" + // Email
                                      @"e-\w{4,10}|" + // e-devlet, e-posta
                                      @"(0|[12])?[0-9][.:][0-5][0-9]('[a-zçığöşü]+)|" + //saat
                                      @"\w+(['.]\w+)+(-[ıiuü])?|" + //tek tırnak
                                      @"\d+([,]\d+)?|" + //virgül ile ayrılmış rakamlar
                                      @"\d+|" + //digit
                                      @"\w+(-[ıiuü])?|" + //word
                                      @"[^\s\d\w]" + //Any character other than a space, digit or word letter
                                      ")+";

        public RegexSplitter(string pattern)
        {
            _pattern = pattern;
        }

        public override IList<string> Split(string input)
        {
            var words = new List<string>();

            var regex = new Regex(_pattern);

            if (regex.IsMatch(input))
            {
                Match match = regex.Match(input);

                foreach (Capture capture in match.Groups[1].Captures)
                {
                    words.Add(capture.Value);
                }

            }

            return words;
        }
    }
}
