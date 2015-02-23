using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.Tokenizers
{
    public class RegexPattern
    {
        /// <summary>
        /// One or more consequent whitespace character;
        /// </summary>
        public const string WhiteSpace = @"\s+";

        /// <summary>
        /// Regex pattern to capture Ellipsis
        /// </summary>
        public const string Ellipsis = @"(?<=[^.])(\.\.\.)(?=\s)";

        /// <summary>
        /// Regex pattern to capture URLs
        /// </summary>
        public const string URL = @"https?://[-a-z0-9]+(\.[-a-z0-9]+)*\.[a-z]{2,4}(/[-a-z0-9R:@&#?=+,.!/~+'%$]+)?";

        /// <summary>
        /// Regex pattern to capture email addresses
        /// </summary>
        public const string Email = @"\w+(\.\w+)*@\w+\.\w+(\.\w+)*";

        /// <summary>
        /// Regex pattern to capture time
        /// </summary>
        public const string Time = @"(0|[12])?[0-9][.:][0-5][0-9]('[a-zçığöşü]+)";

        /// <summary>
        /// Regex pattern to capture words having aphostrope somewhere after the first and before the last letter
        /// </summary>
        public const string WordAphostrope = @"\w+(['.]\w+)+(-[ıiuü])?";

        /// <summary>
        /// Regex pattern to capture numbers decimal numbers having fractional part separated with comma 
        /// </summary>
        public const string TurkishDouble = @"\d+([,]\d+)?";


        /// <summary>
        /// Regex pattern to capture integers
        /// </summary>
        public const string Integer = @"\d+";

        /// <summary>
        /// Regex pattern to capture words
        /// </summary>
        public const string Word = @"\w+(-[ıiuü])?";

        /// <summary>
        /// Regex pattern to capture Turkish words starting with e- such as e-devlet, e-ticaret, e-posta etc.
        /// </summary>
        public const string TurkishEWords = @"e-\w+";

        /// <summary>
        /// Regex to capture any letter other than whitespace, digit, and word letters
        /// </summary>
        public const string LetterNotWhitespaceDigitWord = @"[^\s\d\w]";

        /// <summary>
        /// The character which means OR in a regex pattern.
        /// </summary>
        public const string Or = @"|";

        /// <summary>
        /// Regex pattern to capture new line in Unix or Windows environments
        /// </summary>
        public const string NewLine = @"(\n|\r|\r\n)";

    }
}
