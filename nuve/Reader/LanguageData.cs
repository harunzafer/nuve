using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuve.Lang;

namespace Nuve.Reader
{
    public class LanguageData
    {
        public LanguageData(LanguageType type)
        {
            Type = type;
        }

        public LanguageType Type { get; }

        public string OrthographyXml { get; set; }
        public string MorphotacticsXml { get; set; }
        public string RootTxt { get; set; }
        public string SuffixTxt { get; set; }
    }
}