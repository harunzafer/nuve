using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic
{
    internal class Suffixes
    {
        public readonly Dictionary<string, Suffix> SuffixesById;
        public readonly MorphemeSurfaceDictionary<Suffix> SuffixesBySurface;

        public Suffixes(
            Dictionary<string, Suffix> suffixesById,
            MorphemeSurfaceDictionary<Suffix> suffixesBySurface)
        {
            SuffixesById = suffixesById;
            SuffixesBySurface = suffixesBySurface;
        }
    }
}