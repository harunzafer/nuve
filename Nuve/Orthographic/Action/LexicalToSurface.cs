using Nuve.Condition;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    internal class LexicalToSurface : BaseAction
    {
        public LexicalToSurface(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag)
        {
        }

        public override void Do(Allomorph allomorph, Position position)
        {
            allomorph.Surface = ((Root) allomorph.Morpheme).Surface;
        }
    }
}