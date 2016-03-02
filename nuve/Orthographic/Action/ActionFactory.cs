using System;

namespace Nuve.Orthographic.Action
{
    internal static class ActionFactory
    {
        public static BaseAction Create(string name, Alphabet alphabet,
            string operandOne, string operandTwo, string flag)
        {
            switch (name)
            {
                case "Append":
                    return new Append(alphabet, operandOne, operandTwo, flag);
                case "Prepend":
                    return new Prepend(alphabet, operandOne, operandTwo, flag);
                case "DeleteSurface":
                    return new DeleteSurface(alphabet, operandOne, operandTwo, flag);
                case "DeleteFirstLetter":
                    return new DeleteFirstLetter(alphabet, operandOne, operandTwo, flag);
                case "DeleteFirstVowel":
                    return new DeleteFirstVowel(alphabet, operandOne, operandTwo, flag);
                case "DeleteLastLetter":
                    return new DeleteLastLetter(alphabet, operandOne, operandTwo, flag);
                case "DeleteLastVowel":
                    return new DeleteLastVowel(alphabet, operandOne, operandTwo, flag);
                case "DoubleLastLetter":
                    return new DoubleLastLetter(alphabet, operandOne, operandTwo, flag);
                case "Replace":
                    return new Replace(alphabet, operandOne, operandTwo, flag);
                case "LexicalToSurface":
                    return new LexicalToSurface(alphabet, operandOne, operandTwo, flag);
                default:
                    throw new ArgumentException($"Invalid action type: {name}");
            }
        }
    }
}