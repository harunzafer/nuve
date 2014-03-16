using Nuve.Condition;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic.Action
{
    class AppendTamlamaSuffix : BaseAction
    {
        public AppendTamlamaSuffix(Alphabet alphabet, string operandOne, string operandTwo, string flag)
            : base(alphabet, operandOne, operandTwo, flag) { }

        public override void Do(Allomorph allomorph, Position position)
        {
            string suffix = "";


            
            if (allomorph.Surface.LastCharEqualsAny(Alphabet.Vowels))
            {
                suffix += "s";
            }

            char? lastVowel = allomorph.Surface.LastOccurrenceOfAny(Alphabet.Vowels);

            switch (lastVowel)
            {
                case 'a': suffix += "ı"; break;
                case 'ı': suffix += "ı"; break;
                case 'e': suffix += "i"; break;
                case 'i': suffix += "i"; break;
                case 'o': suffix += "u"; break;
                case 'u': suffix += "u"; break;
                case 'ö': suffix += "ü"; break;
                case 'ü': suffix += "ü"; break;                   
            }

            allomorph.Surface += suffix;

        }
    }
}
