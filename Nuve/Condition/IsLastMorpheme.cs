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
            allomorph = allomorph.Next;
            return !allomorph.HasNext;
        }
    }
}
