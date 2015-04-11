using System;
using System.Collections.Generic;

namespace Nuve.Reader
{
    internal static class LabelSet
    {
        private static readonly IDictionary<string, int> map =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"isim", 1},
                {"fiil", 2},
                {"sıfat", 3},
                {"zamir", 4},
                {"sayı", 5},
                {"yansıma", 6},
                {"geçişli", 7},
                {"akrabalık", 8},
                {"çoğul", 9},
                {"bağlaç", 10},
                {"edat", 11},
                {"zarf", 12},
                {"harf", 13},
                {"kısaltma", 14},
                {"özel", 15},
                {"alıntı", 16},
                {"ünlem", 17},
                {"şapkalı", 18},
                {"şapkasız", 19},
                {"ikileme", 20},
                {"edilgen", 21},
                {"dönüşlü", 22},
                {"soru", 23},
                {"ekfiil", 24},
                {"genis_Ar", 25},
                {"zaman", 26},
                {"ekfiil_alır", 27},
                {"azlık", 28},
                {"ad", 29},
                {"birim", 30},
                {"kök_değil", 31},
                {"ettirgen_dur", 32},
                {"ettirgen_ut", 33},
                {"ettirgen_t", 34},
                {"ettirtgen_t", 35},
                {"isteş", 36},
            };

        public static int ConvertLabelNameToIndex(string label)
        {
            return map[label];
        }

        public static List<int> ConvertLabelNamesToIndexes(IEnumerable<string> propertyNames)
        {
            var labels = new List<int>();
            foreach (string name in propertyNames)
            {
                labels.Add(map[name]);
            }
            return labels;
        }
    }
}