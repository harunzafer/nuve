using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    internal class EndsWithVowel : ConditionBase
    {
        public EndsWithVowel(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            string neighbourSurface = allomorph.GetSurface(Position);
            return neighbourSurface.LastCharEqualsAny(Alphabet.Vowels);
        }
    }
}