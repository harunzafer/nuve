using System.Linq;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    class FirstLetterEquals : ConditionBase
    {
        public FirstLetterEquals(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet) { }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            string neighbourSurface = allomorph.GetSurface(Position);
            return neighbourSurface.FirstCharEqualsAny(Operand.ToList());
        }
    }
}
