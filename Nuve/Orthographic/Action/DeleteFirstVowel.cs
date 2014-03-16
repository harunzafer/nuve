using Nuve.Condition;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    class DeleteFirstVowel : BaseAction
    {
        public DeleteFirstVowel(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag) { }

        public override void Do(Allomorph allomorph, Position position)
        {
            allomorph.Surface = allomorph.Surface.DeleteFirstOccurrenceOfAny(Alphabet.Vowels);
        }
    }
}
