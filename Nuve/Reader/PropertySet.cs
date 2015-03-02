using System;
using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Reader
{
    internal class PropertySet
    {
        private static readonly IDictionary<string, string> Map =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                {
                    {"isim", "F1"},
                    {"fiil", "F2"},
                    {"sıfat", "F3"},
                    {"zamir", "F4"},
                    {"sayı", "F5"},
                    {"yansıma", "F6"},
                    {"geçişli", "F7"},
                    {"akrabalık", "F8"},
                    {"çoğul", "F9"},
                    {"bağlaç", "F9"},
                    {"edat", "F9"},
                    {"zarf", "F9"},
                    {"harf", "F9"},
                    {"kısaltma", "F9"},
                    {"özel", "F9"},
                    {"alıntı", "F9"},
                    {"ünlem", "F9"},
                    {"şapkalı", "F9"},
                    {"şapkasız", "F9"},
                    {"ikileme", "F9"},
                    {"edilgen", "F9"},
                    {"dönüşlü", "F9"},
                    {"soru", "F9"},
                    {"ekfiil", "F9"},
                    {"genis_Ar", "F12"},
                    {"zaman", "F13"},
                    {"ekfiil_alır", "F14"},
                    {"azlık", "F15"},
                    {"ad", "F16"},
                    {"birim", "F17"},
                    {"kök_değil", "F18"},
                    {"ettirgen_dur", "F19"},
                    {"ettirgen_ut", "F20"},
                    {"ettirgen_t", "F21"},
                    {"ettirtgen_t", "F22"},
                };


        public static MorphemeFlags GetProperty(string propertyName)
        {
            MorphemeFlags property;

            if (!Enum.TryParse(Map[propertyName], out property))
            {
                throw new ArgumentException("Invalid Root Property " + propertyName);
            }
            return property;
        }

        public static MorphemeFlags GetPropertyFlags(IEnumerable<string> propertyNames)
        {
            var property = MorphemeFlags.None;
            foreach (string name in propertyNames)
            {
                property = property | GetProperty(name);
            }
            return property;
        }
    }
}