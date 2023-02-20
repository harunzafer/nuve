using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    internal class Replace : BaseAction
    {
        public Replace(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag)
        {
        }

        protected override void Do(Allomorph allomorph)
        {
            allomorph.Surface = _Replace(allomorph.Surface);
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