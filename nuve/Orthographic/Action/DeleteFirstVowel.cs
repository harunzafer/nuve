using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    internal class DeleteFirstVowel : BaseAction
    {
        public DeleteFirstVowel(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag)
        {
        }

        protected override void Do(Allomorph allomorph)
        {
            allomorph.Surface = allomorph.Surface.DeleteFirstOccurrenceOfAny(Alphabet.Vowels);
        }
    }
}