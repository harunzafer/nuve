using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    class MorphemeNotEquals : MorphemeEquals
    {
        public MorphemeNotEquals(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet) { }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            return !base.IsTrueFor(allomorph);
        }
    }
}
