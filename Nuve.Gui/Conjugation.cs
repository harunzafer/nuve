using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Gui
{
    enum FirstTense { GecmisDi, GecmisMis, Simdiki, Gelecek, Genis, Gereklilik, Dilek, Istek, Emir  };

    internal enum SecondTense { Hikaye, Rivayet, Sart, None};

    internal enum Person { SingularFirst, SingularSecond, SingularThird, PluralFirst, PluralSecond, PluralThird };

    class Conjugation
    {
        private readonly Word verb;
        public FirstTense FirstTense { get; private set; }
        public SecondTense SecondTense { get; private set; }
        public Person Person { get; private set; }

        private static readonly Suffix Negative = Language.Turkish.Suffixes.GetSuffix("FY_OLUMSUZLUK_mA");
        private static Suffix SORU = Language.Turkish.Suffixes.GetSuffix("SORU_mU");


        public Conjugation(Word verb, FirstTense firstTense, SecondTense secondTense, Person person)
        {
            this.verb = verb;
            this.FirstTense = firstTense;
            this.SecondTense = secondTense;
            this.Person = person;
        }

        public override string ToString()
        {
            return verb.GetSurface();
        }

        public string Conjugate(Root verbRoot)
        {
            var copy = new Word(verb) {Root = verbRoot};
            return copy.GetSurface();
        }

        public string Conjugate(Root verbRoot, bool negative, bool question)
        {
            var copy = new Word(verb) { Root = verbRoot };
            if (negative)
            {
                copy.AddSuffixAfterRoot(Negative);
            }
            if (question)
            {
                
            }

            return copy.GetSurface();
        }

    }
}
