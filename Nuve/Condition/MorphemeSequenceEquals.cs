using System;
using Nuve.Morphologic.Structure;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    internal class MorphemeSequenceEquals : ConditionBase
    {
        private readonly string[] _sequence;

        public MorphemeSequenceEquals(string position, string operand, Alphabet alphabet)
            : base(position, operand, alphabet)
        {
            _sequence = Operand.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
        }

        public override bool IsTrueFor(Allomorph allomorph)
        {
            Allomorph neighbour;
            if (TryGetOperandMorpheme(allomorph, out neighbour))
            {
                return IterateSequence(neighbour);
            }

            return false;
        }

        private bool IterateSequence(Allomorph neighbour)
        {
            if (Position == Position.BeforeSource)
            {
                for (int i = _sequence.Length - 1; i >= 0; i--)
                {
                    if (_sequence[i] != neighbour.Morpheme.Id)
                        return false;

                    if (neighbour.HasPrevious)
                    {
                        neighbour = neighbour.Previous;
                    }
                }

                return true;
            }

            if (Position == Position.AfterTarget)
            {
                for (int i = 0; i < _sequence.Length; i++)
                {
                    if (_sequence[i] != neighbour.Morpheme.Id)
                        return false;

                    if (neighbour.HasNext)
                    {
                        neighbour = neighbour.Next;
                    }
                }
                return true;
            }

            throw new ArgumentException("Invalid Morpheme Position for MorphemeSequenceEquals: " + Position);
        }
    }
}