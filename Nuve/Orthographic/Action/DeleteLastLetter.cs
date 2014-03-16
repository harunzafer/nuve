using Nuve.Condition;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    class DeleteLastLetter : BaseAction
    {
        public DeleteLastLetter(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag) { }

        public override void Do(Allomorph allomorph, Position position)
        {
            Allomorph neighbour = allomorph;
            switch (position)
            {
                case Position.Next:
                    neighbour = allomorph.Next;
                    break;
                    
                case Position.Previous:
                    neighbour = allomorph.Previous;
                    break;
            }

            neighbour.Surface = neighbour.Surface.DeleteLastChar();
        }
    }
}
