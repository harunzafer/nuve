using System.Linq;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    class LastLetterEquals : ConditionBase
    {
        public LastLetterEquals(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet) { }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            string neighbourSurface = allomorph.GetSurface(Position);
            return neighbourSurface.LastCharEqualsAny(Operand.ToList());
        }
    }
}
