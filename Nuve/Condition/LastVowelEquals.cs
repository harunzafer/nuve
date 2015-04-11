using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    internal class LastVowelEquals : ConditionBase
    {
        public LastVowelEquals(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            string neighbourSurface = allomorph.GetSurface(Position);
            char? lastVowel = neighbourSurface.LastOccurrenceOfAny(Alphabet.Vowels);
            return lastVowel.HasValue && Operand.IndexOf((char) lastVowel) != -1;
        }
    }
}