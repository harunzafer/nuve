using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Gui
{
    internal class ConjugationReader
    {
        private class ConjugationLine
        {
            public string Verb;
            public string Solution;
            public string FirstTense;
            public string SecondTense;
            public string Person;
        }

        private static WordAnalyzer ANALYZER;

        public static List<Conjugation> Read(string filename, string sheetname, WordAnalyzer analyzer)
        {
            ANALYZER = analyzer;
            var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; " +
                                                 "Extended Properties=Excel 12.0;", filename);

            var adapter = new OleDbDataAdapter("SELECT * FROM [" + sheetname + "$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "roots");
            var data = ds.Tables["roots"].AsEnumerable();
            EnumerableRowCollection<ConjugationLine> entries
                = data.Select(x =>
                              new ConjugationLine
                                  {
                                      Verb = x.Field<string>("verb"),
                                      Solution =
                                          x.Field<string>("solution"),
                                      FirstTense =
                                          x.Field<string>("FirstTense"),
                                      SecondTense =
                                          x.Field<string>("SecondTense") ?? "",
                                      Person = x.Field<string>("Person"),
                                  });

            var conjugations = new List<Conjugation>();
            foreach (var entry in entries)
            {
                Conjugation conjugation = GetConjugation(entry);
                conjugations.Add(conjugation);
            }

            return conjugations;
        }

        private static Conjugation GetConjugation(ConjugationLine entry)
        {
            Word verb = GetSolution(entry);
            FirstTense firstTense = GetFirstTense(entry.FirstTense);
            SecondTense secondTense = GetSecondTense(entry.SecondTense);
            Person person = GetPerson(entry.Person);
            return new Conjugation(verb, firstTense, secondTense, person);
        }

        private static FirstTense GetFirstTense(string tenseName)
        {
            FirstTense tense;
            if (!Enum.TryParse(tenseName, out tense))
            {
                throw new ArgumentException("Invalid FirsTense name: " + tenseName);
            }
            return tense;
        }

        private static SecondTense GetSecondTense(string tenseName)
        {
            SecondTense tense;
            if (!Enum.TryParse(tenseName, out tense))
            {
                throw new ArgumentException("Invalid SecondTense name: " + tenseName);
            }
            return tense;
        }

        private static Person GetPerson(string personName)
        {
            Person person;
            if (!Enum.TryParse(personName, out person))
            {
                throw new ArgumentException("Invalid Person Type: " + personName);
            }
            return person;
        }


        private static Word GetSolution(ConjugationLine entry)
        {
            foreach (Word solution in ANALYZER.Analyze(entry.Verb))
            {
                if (((Object) solution).ToString() == entry.Solution)
                {
                    return solution;
                }
            }

            throw new Exception("Çekimli Fiil için çözüm bulunamadı");
        }
    }
}