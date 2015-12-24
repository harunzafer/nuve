using System;
using System.Collections.Generic;
using Nuve.Orthographic;
using NUnit.Framework;

namespace Nuve.Test.Generation
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [TestCase(null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("")]
        public void ThrowIfNullTest(string str)
        {
            str.ThrowIfNull();
        }

        [TestCase("", ExpectedException = typeof (ArgumentException))]
        [TestCase("a")]
        public void ThrowIfEmpty(string str)
        {
            str.ThrowIfEmpty();
        }

        [TestCase(null, "", "", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", null, "", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", "")]
        public void ThrowIfNullAnyTest(params string[] strings)
        {
            StringExtensions.ThrowIfNullAny(strings);
        }

        [TestCase(null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", Result = true)]
        [TestCase("a", Result = false)]
        public bool IsEmptyTest(string str)
        {
            return str.IsEmpty();
        }

        [TestCase(null, "abc", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("abc", null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase(null, null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", Result = false)]
        [TestCase("", "aeıioöuü", Result = false)]
        [TestCase("test", "", Result = false)]
        [TestCase("a", "aeıioöuü", Result = true)]
        [TestCase("b", "aeıioöuü", Result = false)]
        [TestCase("ba", "aeıioöuü", Result = false)]
        [TestCase("ab", "aeıioöuü", Result = true)]
        public bool FirstLetterEqualsAnyTest(string str, string letters)
        {
            return str.FirstCharEqualsAny(letters);
        }

        [TestCase(null, "abc", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("abc", null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase(null, null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", Result = false)]
        [TestCase("", "aeıioöuü", Result = false)]
        [TestCase("test", "", Result = false)]
        [TestCase("a", "aeıioöuü", Result = true)]
        [TestCase("b", "aeıioöuü", Result = false)]
        [TestCase("ba", "aeıioöuü", Result = true)]
        [TestCase("ab", "aeıioöuü", Result = false)]
        public bool LastLetterEqualsAnyTest(string str, string letters)
        {
            return str.LastCharEqualsAny(letters);
        }

        [TestCase(null, "abc", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("abc", null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase(null, null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", Result = null)]
        [TestCase("abc", "", Result = null)]
        [TestCase("", "abc", Result = null)]
        [TestCase("deneme", "aeıioöuü", Result = 'e')]
        [TestCase("pçtk", "aeıioöuü", Result = null)]
        [TestCase("bbböb", "aeıioöuü", Result = 'ö')]
        [TestCase("bbbbbü", "aeıioöuü", Result = 'ü')]
        public char? FirstOccurrenceOfAnyTest(string str, string letters)
        {
            return str.FirstOccurrenceOfAny(letters);
        }

        [TestCase(null, "abc", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("abc", null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase(null, null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", Result = null)]
        [TestCase("abc", "", Result = null)]
        [TestCase("", "abc", Result = null)]
        [TestCase("a", "aeıioöuü", Result = 'a')]
        [TestCase("b", "aeıioöuü", Result = null)]
        [TestCase("ba", "aeıioöuü", Result = 'a')]
        [TestCase("ab", "aeıioöuü", Result = 'a')]
        [TestCase("babalü", "aeıioöuü", Result = 'ü')]
        public char? LastOccurrenceOfAnyTest(string str, string letters)
        {
            return str.LastOccurrenceOfAny(letters);
        }

        [TestCase(null, "abc", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("abc", null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase(null, null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", Result = null)]
        [TestCase("abc", "", Result = null)]
        [TestCase("", "abc", Result = null)]
        [TestCase("babeli", "aeıioöuü", Result = 'e')]
        [TestCase("babo", "aeıioöuü", Result = 'a')]
        [TestCase("boba", "aeıioöuü", Result = 'o')]
        [TestCase("ba", "aeıioöuü", Result = null)]
        [TestCase("ae", "aeıioöuü", Result = 'a')]
        public char? PenultimateOccurrenceOfAnyTest(string str, string letters)
        {
            return str.PenultimateOccurrenceOfAny(letters);
        }

        [TestCase(null, "abc", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("abc", null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase(null, null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", Result = "")]
        [TestCase("abc", "", Result = "abc")]
        [TestCase("", "abc", Result = "")]
        [TestCase("babeli", "aeıioöuü", Result = "bbeli")]
        [TestCase("bab", "aeıioöuü", Result = "bb")]
        [TestCase("bbba", "aeıioöuü", Result = "bbb")]
        [TestCase("bbb", "aeıioöuü", Result = "bbb")]
        public string DeleteFirstOccurrenceOfAnyTest(string str, string letters)
        {
            return str.DeleteFirstOccurrenceOfAny(letters);
        }

        [TestCase(null, "abc", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("abc", null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase(null, null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", Result = "")]
        [TestCase("abc", "", Result = "abc")]
        [TestCase("", "abc", Result = "")]
        [TestCase("babeli", "aeıioöuü", Result = "babel")]
        [TestCase("bab", "aeıioöuü", Result = "bb")]
        [TestCase("bbba", "aeıioöuü", Result = "bbb")]
        [TestCase("bbb", "aeıioöuü", Result = "bbb")]
        public string DeleteLastOccurrenceOfAnyTest(string str, string letters)
        {
            return str.DeleteLastOccurrenceOfAny(letters);
        }

        [TestCase(null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", ExpectedException = typeof (ArgumentException))]
        [TestCase("a", Result = "")]
        [TestCase("ab", Result = "b")]
        [TestCase("abc", Result = "bc")]
        [TestCase("abcd", Result = "bcd")]
        public string DeleteFirstCharTest(string str)
        {
            return str.DeleteFirstChar();
        }

        [TestCase(null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", ExpectedException = typeof (ArgumentException))]
        [TestCase("a", Result = "")]
        [TestCase("ab", Result = "a")]
        [TestCase("abc", Result = "ab")]
        [TestCase("abcd", Result = "abc")]
        public string DeleteLastCharTest(string str)
        {
            return str.DeleteLastChar();
        }

        [TestCase(null, "", "", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", null, "", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "abc", "def", Result = "")]
        [TestCase("abcdef", "", "def", ExpectedException = typeof (ArgumentException))]
        [TestCase("balıba", "ba", "", Result = "lıba")]
        [TestCase("babalı", "ba", "ara", Result = "arabalı")]
        [TestCase("babalı", "a", "e", Result = "bebalı")]
        [TestCase("balıba", "ba", "da", Result = "dalıba")]
        [TestCase("balıba", "ba", "ca", Result = "calıba")]
        public string ReplaceFirstOccurrenceTest(string str, string oldPattern, string newPattern)
        {
            return str.ReplaceFirstOccurrence(oldPattern, newPattern);
        }

        [TestCase(null, "", "", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", null, "", ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "", null, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", "abc", "def", Result = "")]
        [TestCase("abcdef", "", "def", ExpectedException = typeof (ArgumentException))]
        [TestCase("balıba", "ba", "", Result = "balı")]
        [TestCase("babalı", "ba", "ara", Result = "baaralı")]
        [TestCase("babalı", "a", "e", Result = "babelı")]
        [TestCase("balıba", "ba", "da", Result = "balıda")]
        [TestCase("balıba", "ba", "ca", Result = "balıca")]
        public string ReplaceLastOccurrenceTest(string str, string oldPattern, string newPattern)
        {
            return str.ReplaceLastOccurrence(oldPattern, newPattern);
        }

        [TestCase(null, 0, 3, ExpectedException = typeof (ArgumentNullException))]
        [TestCase("", 0, 0, Result = "")]
        [TestCase("babali", 0, 3, Result = "bab")]
        [TestCase("babali", 0, 0, Result = "")]
        [TestCase("babali", 0, 6, Result = "babali")]
        [TestCase("babali", 0, 7, ExpectedException = typeof (ArgumentOutOfRangeException))]
        public string SubstringJavaTest(string str, int start, int end)
        {
            return str.SubstringJava(start, end);
        }

        [TestCase("", Result = "")]
        [TestCase("(", Result = "")]
        [TestCase(")", Result = "")]
        [TestCase("()", Result = "")]
        [TestCase("()()(())", Result = "")]
        [TestCase("((a)(b)(cd))", Result = "abcd")]
        public string RemoveParenthesesTest(string str)
        {
            return str.RemoveParentheses();
        }

        [TestCase("''abc''", Result = "\"abc\"")]
        [TestCase("“abc”", Result = "\"abc\"")]
        [TestCase("«abc»", Result = "\"abc\"")]
        [TestCase("‘abc’", Result = "\'abc\'")]
        public string NormalizeTest(string str)
        {
            const string doubleQuote = "\"";
            const string singleQuote = "'";
            var map = new Dictionary<string, string>
            {
                {"''", doubleQuote},
                {"”", doubleQuote},
                {"“", doubleQuote},
                {"»", doubleQuote},
                {"«", doubleQuote},
                {"’", singleQuote},
                {"‘", singleQuote}
            };
            return str.Normalize(map);
        }
    }
}