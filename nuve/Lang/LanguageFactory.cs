using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuve.Orthographic.Action;
using Nuve.Reader;

namespace Nuve.Lang
{
    public class LanguageFactory
    {
        private static readonly IDictionary<LanguageType, Language> Container = new Dictionary<LanguageType, Language>();

        private static Language CreateInstance(LanguageType type)
        {
            switch (type)
            {
                case LanguageType.Turkish:
                    return new LanguageReader("Tr", false).Read();
                default:
                    throw new ArgumentException($"Language is not supported: {type}");
            }
        }

        public static Language Create(LanguageType type)
        {
            if (!Container.ContainsKey(type))
            {
                var lang = CreateInstance(type);
                Container.Add(type, lang);
            }

            return Container[type];
        }
    }
}
