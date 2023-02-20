using Nuve.Reader;

namespace Nuve.Lang
{
    public class LanguageFactory
    {
        private static readonly IDictionary<LanguageType, Language> Container = new Dictionary<LanguageType, Language>();

        private static Language CreateInstance(LanguageType type)
        {
            if (type.CultureCode == LanguageType.Turkish.CultureCode)
            {
                return new LanguageReader(type).Read();
            }

            throw new ArgumentException($"Language is not supported: {type}");
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