using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Client.Experimental
{
    internal enum FirstTense
    {
        GecmisDi,
        GecmisMis,
        Simdiki,
        Gelecek,
        Genis,
        Gereklilik,
        Dilek,
        Istek,
        Emir
    };

    internal enum SecondTense
    {
        Hikaye,
        Rivayet,
        Sart,
        None
    };

    internal enum Person
    {
        SingularFirst,
        SingularSecond,
        SingularThird,
        PluralFirst,
        PluralSecond,
        PluralThird
    };

    internal class Conjugation
    {
        public static readonly Language Turkish = LanguageFactory.Create(LanguageType.Turkish);

        private static readonly Suffix Negative = Turkish.GetSuffix("FY_OLUMSUZLUK_mA");
        private static Suffix SORU = Turkish.GetSuffix("SORU_mU");
        private readonly Word verb;

        public Conjugation(Word verb, FirstTense firstTense, SecondTense secondTense, Person person)
        {
            this.verb = verb;
            FirstTense = firstTense;
            SecondTense = secondTense;
            Person = person;
        }

        public FirstTense FirstTense { get; private set; }
        public SecondTense SecondTense { get; private set; }
        public Person Person { get; private set; }

        public override string ToString()
        {
            return verb.GetSurface();
        }

        public string Conjugate(Root verbRoot)
        {
            var copy = Word.CopyOf(verb);
            copy.Root = verbRoot;
            return copy.GetSurface();
        }

        public string Conjugate(Root verbRoot, bool negative, bool question)
        {
            var copy = Word.CopyOf(verb);
            copy.Root = verbRoot;
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