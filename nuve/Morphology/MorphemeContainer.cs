using System.Collections.Generic;
using System.Linq;
using Nuve.Lang;
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

        internal static MorphemeContainer<T> CopyOf(MorphemeContainer<T> container)
        {
            var byId = new Dictionary<string, T>(container.ById);

            var bySurface = MorphemeSurfaceDictionary<T>.CopyOf(container.BySurface);

            return new MorphemeContainer<T>(byId, bySurface);
        }
    }
}