using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Reader;

namespace Nuve.Condition
{
    internal class HasLabel : ConditionBase
    {
        private readonly string _label;

        public HasLabel(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
            _label = operand;
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            Allomorph operand;
            if (TryGetOperandMorpheme(allomorph, out operand))
            {
                return operand.Morpheme.HasLabel(_label);
            }

            return false;
        }
    }
}