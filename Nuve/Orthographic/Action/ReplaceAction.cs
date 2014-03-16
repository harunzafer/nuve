using Nuve.Condition;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    internal class ReplaceAction : BaseAction
    {
        public ReplaceAction(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag) { }

        public override void Do(Allomorph allomorph, Position position)
        {
            Allomorph operand;
            if (TryGetOperandMorpheme(allomorph, out operand, position))
            {
                operand.Surface = Replace(operand.Surface);            
            }
        }

        protected string Replace(string str)
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

