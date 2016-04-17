using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    public class IsFirstMorpheme : ConditionBase
    {
        public IsFirstMorpheme(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            Allomorph operand;
            if (TryGetOperandMorpheme(allomorph, out operand))
            {
                return !operand.HasPrevious;
            }

            return false;
        }
    }
}