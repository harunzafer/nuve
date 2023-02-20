namespace Nuve.Orthographic
{
    public class Alphabet
    {
        public readonly string Consonants;
        public readonly string Vowels;

        public Alphabet(string consonants, string vowels)
        {
            Consonants = consonants;
            Vowels = vowels;
        }

        public override string ToString()
        {
            return $"Vowels: {Vowels}, Consonants: {Consonants}";
        }
    }
}