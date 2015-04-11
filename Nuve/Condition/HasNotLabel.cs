using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Reader;

namespace Nuve.Condition
{
    internal class HasNotLabel : HasLabel
    {
        private readonly int _label;

        public HasNotLabel(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
            _label = LabelSet.ConvertLabelNameToIndex(operand);
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            return !base.IsTrueFor(allomorph);
        }
    }
}