using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    class IsLastMorpheme : ConditionBase
    {
        public IsLastMorpheme(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet) { }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            Allomorph operand;
            if (TryGetOperandMorpheme(allomorph, out operand))
            {
                return !operand.HasNext;
            }
            return false;

            //allomorph = allomorph.Next;
        }
    }
}
