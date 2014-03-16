using System;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    class MorphemeExists : ConditionBase
    {
        public MorphemeExists(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet) { }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            Allomorph operand;
            if (TryGetOperandMorpheme(allomorph, out operand))
            {
                return Exists(operand);
            }

            return false;
        }

        private bool Exists(Allomorph operand)
        {
            if (Position == Position.BeforeSource)
            {
                while (operand.HasPrevious)
                {
                    if (operand.Morpheme.Id == Operand)
                    {
                        return true;
                    }
                    operand = operand.Previous;
                }

            }

            if (Position == Position.AfterTarget)
            {
                if (operand.Morpheme.Id == Operand)
                {
                    return true;
                }
                while (operand.HasNext)
                {
                    operand = operand.Next;
                    if (operand.Morpheme.Id == Operand)
                    {
                        return true;
                    }
                }
            }
            throw new ArgumentException("Invalid position for MorphemeExists: " + Position);
        }
    }
}
