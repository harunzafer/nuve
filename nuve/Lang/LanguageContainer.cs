using System;
using System.Collections.Generic;
using Nuve.Reader;

namespace Nuve.Lang
{
    public class LanguageContainer
    {
        private static readonly IDictionary<LanguageType, Language> Container = new Dictionary<LanguageType, Language>();


        private static Language Create(LanguageType type)
        {
            switch (type)
            {
                case LanguageType.Turkish:
                    return new LanguageReader("Tr", false).Read();
                default:
                    throw new ArgumentException($"Language is not supported: {type}");
            }
        }

        public static Language Get(LanguageType type)
        {
            if (!Container.ContainsKey(type))
            {
                var lang = Create(type);
                Container.Add(type, lang);
            }

            return Container[type];
        }
    }
}