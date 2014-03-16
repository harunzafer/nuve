using System;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    class ConditionFactory
    {
        public static ConditionBase Create(string name, string morphemeLocation, string operand, Alphabet alphabet)
        {
            switch (name)
            {
                case "EndsWithConsonant": return new EndsWithConsonant(morphemeLocation, operand, alphabet);
                case "EndsWithVowel": return new EndsWithVowel(morphemeLocation, operand, alphabet);
                case "FirstLetterEquals": return new FirstLetterEquals(morphemeLocation, operand, alphabet);
                case "LastLetterEquals": return new LastLetterEquals(morphemeLocation, operand, alphabet);
                case "LastVowelEquals": return new LastVowelEquals(morphemeLocation, operand, alphabet);
                case "MorphemeEquals": return new MorphemeEquals(morphemeLocation, operand, alphabet);
                case "MorphemeExists": return new MorphemeExists(morphemeLocation, operand, alphabet);
                case "MorphemeNotEquals": return new MorphemeNotEquals(morphemeLocation, operand, alphabet);
                case "MorphemeSequenceEquals": return new MorphemeSequenceEquals(morphemeLocation, operand, alphabet);
                case "PenultVowelEquals": return new PenultVowelEquals(morphemeLocation, operand, alphabet);
                case "StartsWithConsonant": return new StartsWithConsonant(morphemeLocation, operand, alphabet);
                case "StartsWithVowel": return new StartsWithVowel(morphemeLocation, operand, alphabet);
                case "HasFlags": return new HasLabel(morphemeLocation, operand, alphabet);
                case "HasNotFlags": return new HasNotLabel(morphemeLocation, operand, alphabet);
                case "IsLastMorpheme": return new IsLastMorpheme(morphemeLocation, operand, alphabet);
                default: throw new ArgumentException("What the hack is that action: " + name);
            }

        }
    }
}
