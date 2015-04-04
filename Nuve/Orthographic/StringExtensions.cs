using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic
{
    public static class StringExtensions
    {

        internal static void ThrowIfNullOrEmpty(this string str)
        {
            // Handle null argument.
            if (str == null)
            {
                throw new ArgumentNullException("str");
            }
            // Handle invalid argument.
            if (str.Length == 0)
            {
                throw new ArgumentException("Zero-length string invalid", "str");
            }
        }

        internal static string MakeEmptyIfNull(this string str)
        {
            // Handle null argument.
            if (str == null)
            {
                return "";
            }

            return str;
        }

        //internal static bool IsNullOrEmpty(this string str)
        //{
        //    return string.IsNullOrEmpty(str);
        //}

        public static bool FirstCharEqualsAny(this string str, string letters)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            
            char first = str[0];

            return letters.IndexOf(first) > -1;

           
        }

        public static bool LastCharEqualsAny(this string str, string letters)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            char last = str[str.Length - 1];

            return letters.IndexOf(last) > -1;

            
        }

        public static char? FirstOccurrenceOfAny(this string str, string letters)
        {
            int index = str.IndexOfAny(letters.ToArray());

            if (index == -1)
            {
                return null;
            }

            return str[index];
        }

        public static char? LastOccurrenceOfAny(this string str, string letters)
        {
            int index = str.LastIndexOfAny(letters.ToArray());

            if (index == -1)
            {
                return null;
            }

            return str[index];
        }
        
        //Sondan bir önceki
        public static char? PenultimateOccurrenceOfAny(this string str, string letters)
        {
            int index = str.LastIndexOfAny(letters.ToArray());
            if (index == -1)
            {
                return null;
            }

            index = str.Substring(0, index).LastIndexOfAny(letters.ToArray());

            if (index == -1)
            {
                return null;
            }

            return str[index];
        }

        public static string DeleteFirstOccurrenceOfAny(this string str, string letters)
        {
            str.ThrowIfNullOrEmpty();
            
            int index = str.IndexOfAny(letters.ToArray());

            if (index == -1)
            {
                return str;
            }

            return str.Remove(index, 1);
        }

        public static string DeleteLastOccurrenceOfAny(this string str, string letters)
        {
            str.ThrowIfNullOrEmpty();

            int index = str.LastIndexOfAny(letters.ToArray());

            if (index == -1)
            {
                return str;
            }

            return str.Remove(index,1);
        }

        public static string DeleteFirstChar(this string str)
        {
            str.ThrowIfNullOrEmpty();
            return str.Substring(1, str.Length - 1);
        }

        public static string DeleteLastChar(this string str)
        {
            str.ThrowIfNullOrEmpty();   
            return str.Remove(str.Length - 1);
        }

        public static string ReplaceFirstOccurrence(this string str, string oldPattern, string newPattern)
        {
            int index = str.IndexOf(oldPattern, StringComparison.Ordinal);
            if (index == -1)
            {
                return str;
            }
            string result = str.Remove(index, oldPattern.Length).Insert(index, newPattern);
            return result;
        }

        public static string ReplaceLastOccurrence(this string str, string oldPattern, string newPattern)
        {
            int index = str.LastIndexOf(oldPattern, StringComparison.Ordinal);
            if (index == -1)
            {
                return str;
            }
            string result = str.Remove(index, oldPattern.Length).Insert(index, newPattern);
            return result;
        }

        public static string RemoveParentheses(this string str)
        {           
            var rgx = new Regex(@"(\(|\))");
            return rgx.Replace(str, "");
        }

        public static bool IsAnyNullOrEmpty(params string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                if (String.IsNullOrEmpty(strings[i]))
                {
                    return true;
                }
            }

            return false;
        }


        public static string UppercaseFirst(this string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return String.Empty;
            }

            char[] a = str.ToCharArray();
            a[0] = Char.ToUpper(a[0], new CultureInfo("tr-TR"));
            return new string(a);
        }

        public static string SubstringJava(this string s, int start, int end)
        {
            return s.Substring(start, end - start);
        }

        public static IList<string> ToAnalyses(this IEnumerable<Word> words)
        {
            //IList<string> analyses = new List<string>();
            //foreach (Word word in words)
            //{
            //    analyses.AddSequence(word.Analysis);
            //}
            //return analyses;
            return words.Select(word => word.Analysis).ToList();
        }

        private const string DoubleQuote = "\"";
        private const string SingleQuote = "'";

        public static readonly IDictionary<string, string> DefaultNormalizationMap = new Dictionary<string, string>
        {
                
            {"''", DoubleQuote}, 
            {"”",  DoubleQuote},
            {"“",  DoubleQuote},
            {"»",  DoubleQuote},
            {"«",  DoubleQuote},
            {"’",  SingleQuote},
            {"‘",  SingleQuote},
            {"…",  "..."},
                
        };

        /// <summary>
        /// Replaces each key of the map with corresponding value
        /// </summary>
        /// <param name="s"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static string Normalize(this string s, IDictionary<string, string> map)
        {
            foreach (string key in map.Keys)
            {
                s = s.Replace(key, map[key]);
            }
            return s;
        }

        public static int RomanNumeralToArabic(this string number)
        {
            if (number == string.Empty) return 0;
            if (number.StartsWith("M")) return 1000 + RomanNumeralToArabic(number.Remove(0, 1));
            if (number.StartsWith("CM")) return 900 + RomanNumeralToArabic(number.Remove(0, 2));
            if (number.StartsWith("D")) return 500 + RomanNumeralToArabic(number.Remove(0, 1));
            if (number.StartsWith("CD")) return 400 + RomanNumeralToArabic(number.Remove(0, 2));
            if (number.StartsWith("C")) return 100 + RomanNumeralToArabic(number.Remove(0, 1));
            if (number.StartsWith("XC")) return 90 + RomanNumeralToArabic(number.Remove(0, 2));
            if (number.StartsWith("L")) return 50 + RomanNumeralToArabic(number.Remove(0, 1));
            if (number.StartsWith("XL")) return 40 + RomanNumeralToArabic(number.Remove(0, 2));
            if (number.StartsWith("X")) return 10 + RomanNumeralToArabic(number.Remove(0, 1));
            if (number.StartsWith("IX")) return 9 + RomanNumeralToArabic(number.Remove(0, 2));
            if (number.StartsWith("V")) return 5 + RomanNumeralToArabic(number.Remove(0, 1));
            if (number.StartsWith("IV")) return 4 + RomanNumeralToArabic(number.Remove(0, 2));
            if (number.StartsWith("I")) return 1 + RomanNumeralToArabic(number.Remove(0, 1));
            return -1; // Not a valid roman number
        }
    }
}