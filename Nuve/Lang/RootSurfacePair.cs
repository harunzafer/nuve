using Nuve.Morphologic.Structure;

namespace Nuve.Lang
{
    class RootSurfacePair
    {
        public Root Root { get { return root; } }
        private readonly Root root;

        public string Surface { get { return surface; } }
        private readonly string surface;

        public RootSurfacePair(Root root, string surface) {
            this.root = root;
            this.surface = surface;
        }
    }
}
