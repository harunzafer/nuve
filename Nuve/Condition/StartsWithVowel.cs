using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    internal class StartsWithVowel : ConditionBase
    {
        public StartsWithVowel(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            string neighbourSurface = allomorph.GetSurface(Position);
            return neighbourSurface.FirstCharEqualsAny(Alphabet.Vowels);
        }
    }
}