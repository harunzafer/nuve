using System;
using System.Collections.Generic;
using Nuve.Orthographic;

namespace Nuve.Test.Generation
{
    public class StringExtensionsTest
    {
        [Fact]
        public void ThrowIfNull_ThrowsWhenNull()
        {
            string str = null;
            Assert.Throws<ArgumentNullException>(() => StringExtensions.ThrowIfNull(str));
        }

        [Fact]
        public void ThrowIfNull_NotThrowsWhenNotNull()
        {
            string str = "";
            str.ThrowIfNull();
        }

        [Fact]
        public void ThrowIfEmpty_ThrowsWhenEmpty()
        {
            string str = "";
            Assert.Throws<ArgumentException>(() => StringExtensions.ThrowIfEmpty(str) );
        }

        [Fact]
        public void ThrowIfNull_NotThrowsWhenNotEmpty()
        {
            string str = "a";
            str.ThrowIfEmpty();
        }


        // [InlineData(null, "", "", typeof (ArgumentNullException))]
        // [InlineData("", null, "", typeof (ArgumentNullException))]
        // [InlineData("", "", null, typeof (ArgumentNullException))]
        // [InlineData("", "", "")]
        // public void ThrowIfNullAnyTest(params string[] strings)
        // {
        //     StringExtensions.ThrowIfNullAny(strings);
        // }

        // [InlineData("abc", "def", "", Result = -1)]
        // [InlineData("abc ", "def", "", Result = 0)]
        // [InlineData("abc", "de\nf", "", Result = 1)]
        // [InlineData("abc", "def", "\t", Result = 2)]
        // public int ContainsWhitespaceAnyTest(params string[] strings)
        // {
        //     return StringExtensions.ContainsWhitespaceAny(strings);
        // }

        // [InlineData(null, typeof (ArgumentNullException))]
        // [InlineData("", Result = true)]
        // [InlineData("a", Result = false)]
        // public bool IsEmptyTest(string str)
        // {
        //     return str.IsEmpty();
        // }

        // [InlineData(null, "abc", typeof (ArgumentNullException))]
        // [InlineData("abc", null, typeof (ArgumentNullException))]
        // [InlineData(null, null, typeof (ArgumentNullException))]
        // [InlineData("", "", Result = false)]
        // [InlineData("", "aeıioöuü", Result = false)]
        // [InlineData("test", "", Result = false)]
        // [InlineData("a", "aeıioöuü", Result = true)]
        // [InlineData("b", "aeıioöuü", Result = false)]
        // [InlineData("ba", "aeıioöuü", Result = false)]
        // [InlineData("ab", "aeıioöuü", Result = true)]
        // public bool FirstLetterEqualsAnyTest(string str, string letters)
        // {
        //     return str.FirstCharEqualsAny(letters);
        // }

        // [InlineData(null, "abc", typeof (ArgumentNullException))]
        // [InlineData("abc", null, typeof (ArgumentNullException))]
        // [InlineData(null, null, typeof (ArgumentNullException))]
        // [InlineData("", "", Result = false)]
        // [InlineData("", "aeıioöuü", Result = false)]
        // [InlineData("test", "", Result = false)]
        // [InlineData("a", "aeıioöuü", Result = true)]
        // [InlineData("b", "aeıioöuü", Result = false)]
        // [InlineData("ba", "aeıioöuü", Result = true)]
        // [InlineData("ab", "aeıioöuü", Result = false)]
        // public bool LastLetterEqualsAnyTest(string str, string letters)
        // {
        //     return str.LastCharEqualsAny(letters);
        // }

        // [InlineData(null, "abc", typeof (ArgumentNullException))]
        // [InlineData("abc", null, typeof (ArgumentNullException))]
        // [InlineData(null, null, typeof (ArgumentNullException))]
        // [InlineData("", "", Result = null)]
        // [InlineData("abc", "", Result = null)]
        // [InlineData("", "abc", Result = null)]
        // [InlineData("deneme", "aeıioöuü", Result = 'e')]
        // [InlineData("pçtk", "aeıioöuü", Result = null)]
        // [InlineData("bbböb", "aeıioöuü", Result = 'ö')]
        // [InlineData("bbbbbü", "aeıioöuü", Result = 'ü')]
        // public char? FirstOccurrenceOfAnyTest(string str, string letters)
        // {
        //     return str.FirstOccurrenceOfAny(letters);
        // }

        // [InlineData(null, "abc", typeof (ArgumentNullException))]
        // [InlineData("abc", null, typeof (ArgumentNullException))]
        // [InlineData(null, null, typeof (ArgumentNullException))]
        // [InlineData("", "", Result = null)]
        // [InlineData("abc", "", Result = null)]
        // [InlineData("", "abc", Result = null)]
        // [InlineData("a", "aeıioöuü", Result = 'a')]
        // [InlineData("b", "aeıioöuü", Result = null)]
        // [InlineData("ba", "aeıioöuü", Result = 'a')]
        // [InlineData("ab", "aeıioöuü", Result = 'a')]
        // [InlineData("babalü", "aeıioöuü", Result = 'ü')]
        // public char? LastOccurrenceOfAnyTest(string str, string letters)
        // {
        //     return str.LastOccurrenceOfAny(letters);
        // }

        // [InlineData(null, "abc", typeof (ArgumentNullException))]
        // [InlineData("abc", null, typeof (ArgumentNullException))]
        // [InlineData(null, null, typeof (ArgumentNullException))]
        // [InlineData("", "", Result = null)]
        // [InlineData("abc", "", Result = null)]
        // [InlineData("", "abc", Result = null)]
        // [InlineData("babeli", "aeıioöuü", Result = 'e')]
        // [InlineData("babo", "aeıioöuü", Result = 'a')]
        // [InlineData("boba", "aeıioöuü", Result = 'o')]
        // [InlineData("ba", "aeıioöuü", Result = null)]
        // [InlineData("ae", "aeıioöuü", Result = 'a')]
        // public char? PenultimateOccurrenceOfAnyTest(string str, string letters)
        // {
        //     return str.PenultimateOccurrenceOfAny(letters);
        // }

        // [InlineData(null, "abc", typeof (ArgumentNullException))]
        // [InlineData("abc", null, typeof (ArgumentNullException))]
        // [InlineData(null, null, typeof (ArgumentNullException))]
        // [InlineData("", "", Result = "")]
        // [InlineData("abc", "", Result = "abc")]
        // [InlineData("", "abc", Result = "")]
        // [InlineData("babeli", "aeıioöuü", Result = "bbeli")]
        // [InlineData("bab", "aeıioöuü", Result = "bb")]
        // [InlineData("bbba", "aeıioöuü", Result = "bbb")]
        // [InlineData("bbb", "aeıioöuü", Result = "bbb")]
        // public string DeleteFirstOccurrenceOfAnyTest(string str, string letters)
        // {
        //     return str.DeleteFirstOccurrenceOfAny(letters);
        // }

        // [InlineData(null, "abc", typeof (ArgumentNullException))]
        // [InlineData("abc", null, typeof (ArgumentNullException))]
        // [InlineData(null, null, typeof (ArgumentNullException))]
        // [InlineData("", "", Result = "")]
        // [InlineData("abc", "", Result = "abc")]
        // [InlineData("", "abc", Result = "")]
        // [InlineData("babeli", "aeıioöuü", Result = "babel")]
        // [InlineData("bab", "aeıioöuü", Result = "bb")]
        // [InlineData("bbba", "aeıioöuü", Result = "bbb")]
        // [InlineData("bbb", "aeıioöuü", Result = "bbb")]
        // public string DeleteLastOccurrenceOfAnyTest(string str, string letters)
        // {
        //     return str.DeleteLastOccurrenceOfAny(letters);
        // }

        // [InlineData(null, typeof (ArgumentNullException))]
        // [InlineData("", typeof (ArgumentException))]
        // [InlineData("a", Result = "")]
        // [InlineData("ab", Result = "b")]
        // [InlineData("abc", Result = "bc")]
        // [InlineData("abcd", Result = "bcd")]
        // public string DeleteFirstCharTest(string str)
        // {
        //     return str.DeleteFirstChar();
        // }

        // [InlineData(null, typeof (ArgumentNullException))]
        // [InlineData("", typeof (ArgumentException))]
        // [InlineData("a", Result = "")]
        // [InlineData("ab", Result = "a")]
        // [InlineData("abc", Result = "ab")]
        // [InlineData("abcd", Result = "abc")]
        // public string DeleteLastCharTest(string str)
        // {
        //     return str.DeleteLastChar();
        // }

        // [InlineData(null, "", "", typeof (ArgumentNullException))]
        // [InlineData("", null, "", typeof (ArgumentNullException))]
        // [InlineData("", "", null, typeof (ArgumentNullException))]
        // [InlineData("", "abc", "def", Result = "")]
        // [InlineData("abcdef", "", "def", typeof (ArgumentException))]
        // [InlineData("balıba", "ba", "", Result = "lıba")]
        // [InlineData("babalı", "ba", "ara", Result = "arabalı")]
        // [InlineData("babalı", "a", "e", Result = "bebalı")]
        // [InlineData("balıba", "ba", "da", Result = "dalıba")]
        // [InlineData("balıba", "ba", "ca", Result = "calıba")]
        // public string ReplaceFirstOccurrenceTest(string str, string oldPattern, string newPattern)
        // {
        //     return str.ReplaceFirstOccurrence(oldPattern, newPattern);
        // }

        // [InlineData(null, "", "", typeof (ArgumentNullException))]
        // [InlineData("", null, "", typeof (ArgumentNullException))]
        // [InlineData("", "", null, typeof (ArgumentNullException))]
        // [InlineData("", "abc", "def", Result = "")]
        // [InlineData("abcdef", "", "def", typeof (ArgumentException))]
        // [InlineData("balıba", "ba", "", Result = "balı")]
        // [InlineData("babalı", "ba", "ara", Result = "baaralı")]
        // [InlineData("babalı", "a", "e", Result = "babelı")]
        // [InlineData("balıba", "ba", "da", Result = "balıda")]
        // [InlineData("balıba", "ba", "ca", Result = "balıca")]
        // public string ReplaceLastOccurrenceTest(string str, string oldPattern, string newPattern)
        // {
        //     return str.ReplaceLastOccurrence(oldPattern, newPattern);
        // }

        // [InlineData(null, 0, 3, typeof (ArgumentNullException))]
        // [InlineData("", 0, 0, Result = "")]
        // [InlineData("babali", 0, 3, Result = "bab")]
        // [InlineData("babali", 0, 0, Result = "")]
        // [InlineData("babali", 0, 6, Result = "babali")]
        // [InlineData("babali", 0, 7, typeof (ArgumentOutOfRangeException))]
        // public string SubstringJavaTest(string str, int start, int end)
        // {
        //     return str.SubstringJava(start, end);
        // }

        // [InlineData("", Result = "")]
        // [InlineData("(", Result = "")]
        // [InlineData(")", Result = "")]
        // [InlineData("()", Result = "")]
        // [InlineData("()()(())", Result = "")]
        // [InlineData("((a)(b)(cd))", Result = "abcd")]
        // public string RemoveParenthesesTest(string str)
        // {
        //     return str.RemoveParentheses();
        // }

        // [InlineData("''abc''", Result = "\"abc\"")]
        // [InlineData("“abc”", Result = "\"abc\"")]
        // [InlineData("«abc»", Result = "\"abc\"")]
        // [InlineData("‘abc’", Result = "\'abc\'")]
        // public string NormalizeTest(string str)
        // {
        //     const string doubleQuote = "\"";
        //     const string singleQuote = "'";
        //     var map = new Dictionary<string, string>
        //     {
        //         {"''", doubleQuote},
        //         {"”", doubleQuote},
        //         {"“", doubleQuote},
        //         {"»", doubleQuote},
        //         {"«", doubleQuote},
        //         {"’", singleQuote},
        //         {"‘", singleQuote}
        //     };
        //     return str.Normalize(map);
        // }
    }
}