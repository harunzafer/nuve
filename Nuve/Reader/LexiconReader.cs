using System;
using System.Data;
using Nuve.Dictionary;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Reader
{
    internal class LexiconReader
    {
        private readonly Orthography orthography;

        public LexiconReader(Orthography orthography)
        {
            this.orthography = orthography;
        }

        public Lexicon Read(string[] rootFileNames, string suffixFileName)
        {
            var rootReader = new RootLexiconReader(orthography);
            var suffixReader = new SuffixLexiconReader(orthography);

            var roots = rootReader.Read(rootFileNames);
            System.Collections.Generic.Dictionary<string, Suffix> suffixesById;
            MorphemeLexicon<Suffix> suffixes;
            suffixReader.Read(suffixFileName, out suffixesById, out suffixes);

            return new Lexicon(roots, suffixes, suffixesById);
        }


    }
}