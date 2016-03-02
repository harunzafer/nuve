using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    internal class DoubleLastLetter : BaseAction
    {
        public DoubleLastLetter(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag)
        {
        }

        protected override void Do(Allomorph allomorph)
        {
            var last = allomorph.Surface[allomorph.Surface.Length - 1];
            allomorph.Surface += last;
        }
    }
}