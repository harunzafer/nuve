using System;
using Nuve.Condition;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    public abstract class BaseAction
    {
        protected readonly Alphabet Alphabet;
        protected readonly string Flag;
        protected readonly string OperandOne;
        protected readonly string OperandTwo;

        protected BaseAction(Alphabet alphabet, string operandOne, string operandTwo, string flag)
        {
            Alphabet = alphabet;
            OperandOne = operandOne;
            OperandTwo = operandTwo;
            Flag = flag;
        }

        public abstract void Do(Allomorph allomorph, Position position);

        protected bool TryGetOperandMorpheme(Allomorph allomorph, out Allomorph operand, Position position)
            // out parameter for result
        {
            switch (position)
            {
                case Position.This:
                    operand = allomorph;
                    return true;

                case Position.Next:
                    operand = allomorph.Next;
                    return allomorph.HasNext;

                case Position.Previous:
                    operand = allomorph.Previous;
                    return allomorph.HasPrevious;

                default:
                    throw new ArgumentException("Invalid Position for Action : " + position);
            }
        }
    }
}