using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic
{
    class Suffixes
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
