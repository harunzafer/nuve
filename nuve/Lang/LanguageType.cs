using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.Lang
{
    public sealed class LanguageType
    {

        public LanguageType(string code, string countryCode)
        {
            Code = code;
            CountryCode = countryCode;
        }

        /// <summary>
        /// ISO 639-1 two-letter lowercase language code
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// ISO 3166 two-letter uppercase country code
        /// </summary>
        public string CountryCode { get; }

        /// <summary>
        /// Combination of ISO 639-1 two-letter lowercase language code and ISO 3166 two-letter uppercase country code separated with a hyphen.
        /// See: http://timtrott.co.uk/culture-codes/
        /// </summary>
        public string CultureCode => Code + "-" + CountryCode;

        internal string ResourcePath => Code + "_" + CountryCode;

        public static readonly LanguageType Turkish = new LanguageType("tr", "TR");

    }
}
