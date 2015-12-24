using Nuve.Condition;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    internal class Prepend : BaseAction
    {
        public Prepend(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag)
        {
        }


        public override void Do(Allomorph allomorph, Position position)
        {
            allomorph.Surface = OperandOne + allomorph.Surface;
        }
    }
}