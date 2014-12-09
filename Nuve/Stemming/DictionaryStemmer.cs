using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuve.Lang;

namespace Nuve.Stemming
{
    internal class DictionaryStemmer : IStemmer
    {
        //singleton yapmak gerekiyor!
        private readonly IDictionary<string, string> dictionary;

        private const string DictionaryPath =
            @"C:\Users\hrzafer\Desktop\workspace\Prizma\code\prizma\src\main\resources\stemDict\nuve_stems2.dict";

        public DictionaryStemmer()
        {
            dictionary = Read();
            AddManuals();
        }

        public string GetStem(string word)
        {
            if (dictionary.ContainsKey(word))
            {
                return dictionary[word];
            }

            return word;
        }

        private void AddManuals()
        {
            dictionary.Remove("ana");
            dictionary.Remove("aba");
            dictionary.Remove("neden");
            dictionary["yana"] = "yan";
            dictionary["yanı"] = "yan";
            dictionary["gele"] = "gel";
            dictionary["gele"] = "gel";
            dictionary["gide"] = "git";
            dictionary["yapa"] = "yap";
            dictionary["ede"] = "et";
        }

        private IDictionary<string, string> Read()
        {
            return File.ReadAllLines(DictionaryPath).
                Where(x => x != "" && !x.StartsWith("#")).
                Select(x => x.Split('\t')).
                ToDictionary(row => row[0], row => row[1]);
        }
    }
}