using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    internal class HasNotLabel : HasLabel
    {
        public HasNotLabel(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            return !base.IsTrueFor(allomorph);
        }
    }
}