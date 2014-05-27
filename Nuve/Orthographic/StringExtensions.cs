using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Nuve.Morphologic.Structure;

namespace Nuve.Orthographic
{
    internal static class StringExtensions
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

        public static bool FirstCharEqualsAny(this string str, IList<char> letters)
        {
            str.ThrowIfNullOrEmpty();
            char first = str[0];

            foreach (char letter in letters)
            {
                if (first == letter)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool LastCharEqualsAny(this string str, IList<char> letters)
        {
            str.ThrowIfNullOrEmpty();
            char last = str[str.Length - 1];
            foreach (char letter in letters)
            {
                if (last == letter)
                {
                    return true;
                }
            }

            return false;
        }

        public static char? FirstOccurrenceOfAny(this string str, IList<char> letters)
        {
            int index = str.IndexOfAny(letters.ToArray());

            if (index == -1)
            {
                return null;
            }

            return str[index];
        }

        public static char? LastOccurrenceOfAny(this string str, IList<char> letters)
        {
            int index = str.LastIndexOfAny(letters.ToArray());

            if (index == -1)
            {
                return null;
            }

            return str[index];
        }
        
        //Sondan bir önceki
        public static char? PenultimateOccurrenceOfAny(this string str, IList<char> letters)
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

        public static string DeleteFirstOccurrenceOfAny(this string str, IList<char> letters)
        {
            str.ThrowIfNullOrEmpty();
            
            int index = str.IndexOfAny(letters.ToArray());

            if (index == -1)
            {
                return str;
            }

            return str.Remove(index, 1);
        }

        public static string DeleteLastOccurrenceOfAny(this string str, IList<char> letters)
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

        public static IList<string> ToAnalyses(this IEnumerable<Word> words)
        {
            //IList<string> analyses = new List<string>();
            //foreach (Word word in words)
            //{
            //    analyses.Add(word.Analysis);
            //}
            //return analyses;
            return words.Select(word => word.Analysis).ToList();
        }
    }
}