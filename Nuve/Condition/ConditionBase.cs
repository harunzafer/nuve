using System;
using System.Collections.Generic;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;
using Nuve.Reader;

namespace Nuve.Condition
{
    public enum Position
    {
        First,
        Previous,
        Next,
        This,
        Source,
        Target,
        BeforeTarget,
        AfterTarget,
        BeforeSource,
        Last
    };

    public abstract class ConditionBase
    {
        protected readonly Alphabet Alphabet;
        protected readonly string Operand;
        protected readonly Position Position;

        protected ConditionBase(string position, string operand, Alphabet alphabet)
        {
            if (!Enum.TryParse(position, out Position))
            {
                throw new ArgumentException("Invalid Morpheme Location: " + position);
            }
            Operand = operand;
            Alphabet = alphabet;
        }

        protected bool TryGetOperandMorpheme(Allomorph allomorph, out Allomorph operand) // out parameter for result
        {
            switch (Position)
            {
                case Position.Next:
                case Position.Target:
                    operand = allomorph.Next;
                    return allomorph.HasNext;

                case Position.Previous:
                case Position.BeforeSource:
                    operand = allomorph.Previous;
                    return allomorph.HasPrevious;

                case Position.This:
                case Position.Source:
                    operand = allomorph;
                    return true;

                case Position.First:
                    operand = allomorph.First;
                    return true;

                case Position.AfterTarget:
                    if (allomorph.HasNext)
                    {
                        operand = allomorph.Next.Next;
                        return allomorph.Next.HasNext;
                    }
                    operand = null;
                    return false;

                default:
                    throw new ArgumentException("Invalid Argument : " + Position);
            }
        }

        public abstract bool IsTrueFor(Allomorph allomorph);

        protected HashSet<string> ParseLabels(string operand)
        {
            string[] labels = operand.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            return new HashSet<string>(labels);
        }

        public override string ToString()
        {
            return "operand: " + Operand;
        }
    }
}