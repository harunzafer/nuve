using Nuve.Condition;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    class DoubleLastLetter : BaseAction
    {
        public DoubleLastLetter(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag) { }

        public override void Do(Allomorph allomorph, Position position)
        {
            char last = allomorph.Surface[allomorph.Surface.Length - 1];
            allomorph.Surface += last;
        }
    }
}
