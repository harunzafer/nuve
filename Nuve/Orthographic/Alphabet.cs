using System;
using System.Collections.Generic;
using System.Text;

namespace Nuve.Orthographic
{
    public class Alphabet
    {
        private readonly IList<char> consonants;
        private readonly IList<char> vowels;

        public IList<char> Consonants { get { return consonants; } }
        public IList<char> Vowels { get { return vowels; } }

        public Alphabet(IList<char> consonants, IList<char> vowels)
        {
            this.consonants = consonants;
            this.vowels = vowels;
        }

        public static readonly Alphabet Turkish = new Alphabet(CharSet.TurkishConsonants, CharSet.TurkishVowels);

        private bool Contains(char ch)
        {
            return consonants.Contains(ch) || vowels.Contains(ch);
        }

        public bool ContainsAll(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("string str is either empty or null");
            }

            foreach (char c in str)
            {
                if(Contains(c) == false)
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (char vowel in Vowels)
            {
                sb.Append("Vowels: " +vowel + ", ");
            }
            foreach (char consonant in Consonants)
            {
                sb.Append("Consonants: " + consonant + ", ");
            }

            return sb.ToString();
        }
    }
}