using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Client.Experimental
{
    internal class ConjugationReader
    {
        public static List<Conjugation> Read(string filename, string sheetname, Language language)
        {
            string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; " +
                                                    "Extended Properties=Excel 12.0;", filename);

            var adapter = new OleDbDataAdapter("SELECT * FROM [" + sheetname + "$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "roots");
            EnumerableRowCollection<DataRow> data = ds.Tables["roots"].AsEnumerable();
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
            foreach (ConjugationLine entry in entries)
            {
                Conjugation conjugation = GetConjugation(entry, language);
                conjugations.Add(conjugation);
            }

            return conjugations;
        }

        private static Conjugation GetConjugation(ConjugationLine entry, Language language)
        {
            Word verb = GetSolution(entry, language);
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


        private static Word GetSolution(ConjugationLine entry, Language language)
        {
            foreach (Word solution in language.Analyze(entry.Verb))
            {
                if (solution.ToString() == entry.Solution)
                {
                    return solution;
                }
            }

            throw new Exception("Çekimli Fiil için çözüm bulunamadı");
        }

        private class ConjugationLine
        {
            public string FirstTense;
            public string Person;
            public string SecondTense;
            public string Solution;
            public string Verb;
        }
    }
}