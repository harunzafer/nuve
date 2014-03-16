using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Reader;

namespace Nuve.Condition
{
    class HasLabel : ConditionBase
    {
        private readonly int _label;
        public HasLabel(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
            _label = LabelSet.ConvertLabelNameToIndex(operand);
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
