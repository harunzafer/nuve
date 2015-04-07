using Nuve.Condition;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    internal class Replace : BaseAction
    {
        public Replace(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag) { }

        public override void Do(Allomorph allomorph, Position position)
        {
            Allomorph operand;
            if (TryGetOperandMorpheme(allomorph, out operand, position))
            {
                operand.Surface = _Replace(operand.Surface);            
            }
        }

        private string _Replace(string str)
        {
            if (Flag == "last")
            {
                return str.ReplaceLastOccurrence(OperandOne, OperandTwo);
            }

            if (Flag == "first")
            {
                return str.ReplaceFirstOccurrence(OperandOne, OperandTwo);
            }

            return str.Replace(OperandOne, OperandTwo);
        }
    }
}

