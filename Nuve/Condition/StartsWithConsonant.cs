using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    internal class StartsWithConsonant : ConditionBase
    {
        public StartsWithConsonant(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            string neighbourSurface = allomorph.GetSurface(Position);
            return neighbourSurface.FirstCharEqualsAny(Alphabet.Consonants);
        }
    }
}