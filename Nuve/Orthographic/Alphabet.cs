namespace Nuve.Orthographic
{
    public class Alphabet
    {
        //public static readonly Alphabet Turkish = new Alphabet(CharSet.TurkishConsonants, CharSet.TurkishVowels);
        public readonly string Consonants;
        public readonly string Vowels;

        public Alphabet(string consonants, string vowels)
        {
            Consonants = consonants;
            Vowels = vowels;
        }

        public override string ToString()
        {
            return string.Format("Vowels: {0}, Consonants: {1}", Vowels, Consonants);
        }
    }
}