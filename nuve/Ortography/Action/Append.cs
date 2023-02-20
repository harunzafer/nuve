using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    internal class Append : BaseAction
    {
        public Append(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag)
        {
        }

        protected override void Do(Allomorph allomorph)
        {
            allomorph.Surface += OperandOne;
        }
    }
}