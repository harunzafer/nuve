using Nuve.Lang;
using Nuve.Morphologic;
using Nuve.Orthographic;
using Nuve.Properties;

namespace Nuve.Reader
{
    public static class LanguageReader
    {
        public static Language ReadInternal(string langCode)
        {
            var orthograpy = ReadInternalOrthography(langCode);
            var morphotactics = ReadInternalMorphotactics(langCode, orthograpy.Alphabet);
            var lexicon = ReadInternalLexicon(langCode, orthograpy);

            return new Language(orthograpy, morphotactics, lexicon);
        }

        private static Morphotactics ReadInternalMorphotactics(string lang, Alphabet alphabet)
        {
            var path = lang + "." + Resources.Morphotactics;
            var xml = EmbeddedResourceReader.Read(path);
            return MorphotacticsReader.Read(xml, alphabet);
        }

        private static Orthography ReadInternalOrthography(string lang)
        {
            var path = lang + "." + Resources.Orthography;
            var xml = EmbeddedResourceReader.ReadXml(path);
            return OrthographyReader.Read(xml);
        }

        private static Lexicon ReadInternalLexicon(string lang, Orthography orthography)
        {
            var suffixesPath = lang + "." + Resources.Suffixes;
            var rootsPath = lang + "." + Resources.Roots;
            var namesPath = lang + "." + Resources.Names;
            var abbreviationPath = lang + "." + Resources.Abbreviations;

            string[] filenames = {rootsPath, namesPath, abbreviationPath};

            var reader = new LexiconReader(orthography);
            var lexicon = reader.Read(filenames, suffixesPath);
            return lexicon;
        }

        //Excel olayı burada halledilmeli, EmbeddedResourceReader ve TextToDataset sınıfları yalnızca buradan
        //çağrılmalı
        public static Language ReadExternal(string path)
        {
            return null;
        }
    }
}