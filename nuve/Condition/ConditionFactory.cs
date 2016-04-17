using System;
using Nuve.Orthographic;

namespace Nuve.Condition
{
    internal static class ConditionFactory
    {
        public static ConditionBase Create(string name, string morphemePosition, string operand, Alphabet alphabet)
        {
            switch (name)
            {
                case "EndsWithConsonant":
                    return new EndsWithConsonant(morphemePosition, operand, alphabet);
                case "EndsWithVowel":
                    return new EndsWithVowel(morphemePosition, operand, alphabet);
                case "FirstLetterEquals":
                    return new FirstLetterEquals(morphemePosition, operand, alphabet);
                case "LastLetterEquals":
                    return new LastLetterEquals(morphemePosition, operand, alphabet);
                case "LastVowelEquals":
                    return new LastVowelEquals(morphemePosition, operand, alphabet);
                case "MorphemeEquals":
                    return new MorphemeEquals(morphemePosition, operand, alphabet);
                case "MorphemeExists":
                    return new MorphemeExists(morphemePosition, operand, alphabet);
                case "MorphemeNotEquals":
                    return new MorphemeNotEquals(morphemePosition, operand, alphabet);
                case "MorphemeSequenceEquals":
                    return new MorphemeSequenceEquals(morphemePosition, operand, alphabet);
                case "PenultVowelEquals":
                    return new PenultVowelEquals(morphemePosition, operand, alphabet);
                case "StartsWithConsonant":
                    return new StartsWithConsonant(morphemePosition, operand, alphabet);
                case "StartsWithVowel":
                    return new StartsWithVowel(morphemePosition, operand, alphabet);
                case "HasFlags":
                    return new HasLabel(morphemePosition, operand, alphabet);
                case "HasNotFlags":
                    return new HasNotLabel(morphemePosition, operand, alphabet);
                case "IsLastMorpheme":
                    return new IsLastMorpheme(morphemePosition, operand, alphabet);
                case "IsFirstMorpheme":
                    return new IsFirstMorpheme(morphemePosition, operand, alphabet);
                default:
                    throw new ArgumentException("Invalid Condition: " + name);
            }
        }
    }
}