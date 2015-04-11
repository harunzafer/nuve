using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    internal class MorphemeEquals : ConditionBase
    {
        public MorphemeEquals(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            Allomorph operand;
            if (TryGetOperandMorpheme(allomorph, out operand))
            {
                return Operand == operand.Morpheme.Id;
            }

            return false;
        }
    }
}