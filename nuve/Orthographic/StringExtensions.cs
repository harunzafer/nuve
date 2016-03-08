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
        /// <summary>
        ///     Throws an ArgumentNullException if this string is null
        /// </summary>
        public static void ThrowIfNull(this string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
        }

        /// <summary>
        ///     Throws an ArgumentException if this string is empty
        /// </summary>
        internal static void ThrowIfEmpty(this string str)
        {
            if (str.Length == 0)
            {
                throw new ArgumentException(@"Input string can not be empty", nameof(str));
            }
        }

        /// <summary>
        ///     Throws an ArgumentNullException if any of the objects in the specified array is null
        /// </summary>
        public static void ThrowIfNullAny(params object[] objects)
        {
            foreach (var o in objects)
            {
                if (o == null)
                {
                    throw new ArgumentNullException(nameof(o));
                }
            }
        }

        /// <summary>
        ///     Indicates whether this string is empty.
        ///     Throws an ArgumentNullException if this string is null.
        /// </summary>
        public static bool IsEmpty(this string str)
        {
            str.ThrowIfNull();
            return str.Length == 0;
        }

        /// <summary>
        ///     Indicates whether the first character of this string is equal to any character in the specified string.
        /// </summary>
        public static bool FirstCharEqualsAny(this string str, string letters)
        {
            ThrowIfNullAny(str, letters);

            if (str.Length == 0)
            {
                return false;
            }

            var first = str[0];

            return letters.IndexOf(first) > -1;
        }

        /// <summary>
        ///     Indicates whether the last character of this string is equal to any character in the specified string.
        /// </summary>
        public static bool LastCharEqualsAny(this string str, string letters)
        {
            ThrowIfNullAny(str, letters);

            if (str.Length == 0)
            {
                return false;
            }

            var last = str[str.Length - 1];

            return letters.IndexOf(last) > -1;
        }


        /// <summary>
        ///     Returns the character in the specified string that occurres first in this string.
        ///     Returns null if no character in the specified string is found this string.
        /// </summary>
        public static char? FirstOccurrenceOfAny(this string str, string letters)
        {
            ThrowIfNullAny(str, letters);

            var index = str.IndexOfAny(letters.ToCharArray());

            if (index == -1)
            {
                return null;
            }

            return str[index];
        }

        /// <summary>
        ///     Returns the character in the specified string that occurres last in this string.
        ///     Returns null if no character in the specified string is found this string.
        /// </summary>
        public static char? LastOccurrenceOfAny(this string str, string letters)
        {
            ThrowIfNullAny(str, letters);

            var index = str.LastIndexOfAny(letters.ToCharArray());

            if (index == -1)
            {
                return null;
            }

            return str[index];
        }

        /// <summary>
        ///     Returns the character in the specified string that occurres next to last in this string.
        ///     Returns null if no such character is found.
        /// </summary>
        public static char? PenultimateOccurrenceOfAny(this string str, string letters)
        {
            ThrowIfNullAny(str, letters);

            var index = str.LastIndexOfAny(letters.ToCharArray());
            if (index == -1)
            {
                return null;
            }

            index = str.Substring(0, index).LastIndexOfAny(letters.ToCharArray());

            if (index == -1)
            {
                return null;
            }

            return str[index];
        }

        /// <summary>
        /// </summary>
        public static string DeleteFirstOccurrenceOfAny(this string str, string letters)
        {
            ThrowIfNullAny(str, letters);

            var index = str.IndexOfAny(letters.ToCharArray());

            if (index == -1)
            {
                return str;
            }

            return str.Remove(index, 1);
        }

        public static string DeleteLastOccurrenceOfAny(this string str, string letters)
        {
            ThrowIfNullAny(str, letters);

            var index = str.LastIndexOfAny(letters.ToCharArray());

            if (index == -1)
            {
                return str;
            }

            return str.Remove(index, 1);
        }


        public static string DeleteFirstChar(this string str)
        {
            str.ThrowIfNull();

            str.ThrowIfEmpty();

            return str.Substring(1, str.Length - 1);
        }


        public static string DeleteLastChar(this string str)
        {
            str.ThrowIfNull();

            str.ThrowIfEmpty();

            return str.Remove(str.Length - 1);
        }

        public static string ReplaceFirstOccurrence(this string str, string oldPattern, string newPattern)
        {
            ThrowIfNullAny(str, oldPattern, newPattern);
            oldPattern.ThrowIfEmpty();

            var index = str.IndexOf(oldPattern, StringComparison.Ordinal);
            if (index == -1)
            {
                return str;
            }
            var result = str.Remove(index, oldPattern.Length).Insert(index, newPattern);
            return result;
        }

        public static string ReplaceLastOccurrence(this string str, string oldPattern, string newPattern)
        {
            ThrowIfNullAny(str, oldPattern, newPattern);
            oldPattern.ThrowIfEmpty();

            var index = str.LastIndexOf(oldPattern, StringComparison.Ordinal);
            if (index == -1)
            {
                return str;
            }
            var result = str.Remove(index, oldPattern.Length).Insert(index, newPattern);
            return result;
        }

        /// <summary>
        /// Provides the same functionality with the substring method of Java
        /// </summary>
        public static string SubstringJava(this string s, int start, int end)
        {
            s.ThrowIfNull();
            return s.Substring(start, end - start);
        }

        /// <summary>
        ///     Removes all the '(' and ')' characters in this string.
        /// </summary>
        internal static string RemoveParentheses(this string str)
        {
            str.ThrowIfNull();
            var rgx = new Regex(@"(\(|\))");
            return rgx.Replace(str, "");
        }

        /// <summary>
        /// String'in ilk harfini Turkish culture'a göre büyük harf yapar
        /// </summary>
        internal static string UppercaseFirst(this string str)
        {
            str.ThrowIfNull();
            str.ThrowIfEmpty();

            var a = str.ToCharArray();
            a[0] = char.ToUpper(a[0], new CultureInfo("tr-TR"));
            return new string(a);
        }
        
        /// <summary>
        ///     Replaces each key of the map with corresponding value
        /// </summary>
        internal static string Normalize(this string s, IDictionary<string, string> map)
        {
            foreach (var key in map.Keys)
            {
                s = s.Replace(key, map[key]);
            }
            return s;
        }

        /// <summary>
        ///  Converts  number from Roman form to Arabic form
        /// </summary>
        internal static int RomanNumeralToArabic(this string number)
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

            return -1;

            //throw new ArgumentException($"Not a valid Roman numeral: {number}");
        }
    }
}