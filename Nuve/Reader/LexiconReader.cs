using System.Collections.Generic;
using Nuve.Morphologic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class LexiconReader
    {
        private readonly Orthography _orthography;

        public LexiconReader(Orthography orthography)
        {
            _orthography = orthography;
        }

        public Lexicon Read(string[] rootFileNames, string suffixFileName)
        {
            var rootReader = new RootLexiconReader(_orthography);
            var suffixReader = new SuffixLexiconReader(_orthography);

            var roots = rootReader.Read(rootFileNames);
            Dictionary<string, Suffix> suffixesById;
            MorphemeLexicon<Suffix> suffixes;
            suffixReader.Read(suffixFileName, out suffixesById, out suffixes);

            return new Lexicon(roots, suffixes, suffixesById);
        }
    }
}