using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Morphologic
{
    class MorphemeContainer<T> where T : Morpheme
    {
        public readonly Dictionary<string, T> ById;
        public readonly MorphemeSurfaceDictionary<T> BySurface;

        public MorphemeContainer(
            Dictionary<string, T> morphemesById,
            MorphemeSurfaceDictionary<T> morphemesBySurface)
        {
            ById = morphemesById;
            BySurface = morphemesBySurface;
        }
    }
}