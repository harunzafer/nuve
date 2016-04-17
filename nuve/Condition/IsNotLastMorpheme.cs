using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    public class IsNotLastMorpheme : IsLastMorpheme
    {
        public IsNotLastMorpheme(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            return !base.IsTrueFor(allomorph);
        }
    }
}