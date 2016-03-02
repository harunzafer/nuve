using System;
using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Client.Experimental
{
    internal class Conjugator
    {
        private const string Filename = @"C:\Users\hrzafer\Dropbox\aNewHope\conjugationData.xlsx";
        //private static readonly WordAnalyzer Analyzer = new WordAnalyzer(Language.Turkish);

        private static readonly List<Conjugation> Conjugations = ConjugationReader.Read(Filename, "Sheet1", Conjugation.Turkish);

        public static List<string> Conjugate(string verbRoot, bool negative, bool question)
        {
            var conjugations = new List<string>();
            Root root = GetVerbRoot(verbRoot);
            foreach (Conjugation conjugation in Conjugations)
            {
                string conj = conjugation.Conjugate(root, negative, question);
                conjugations.Add(conj);
            }
            return conjugations;
        }

        private static Root GetVerbRoot(string verbRoot)
        {
            IEnumerable<Root> roots = Conjugation.Turkish.GetRootsHavingSurface(verbRoot);
            foreach (Root root in roots)
            {
                if (root.Pos == "FIIL")
                {
                    return root;
                }
            }
            throw new Exception("Kök bulunamadı: " + verbRoot);
        }
    }
}