using System;
using System.Collections.Generic;
using NUnit.Framework;
using Nuve.Orthographic;

namespace Nuve.Test.Orthographic
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [TestCase(null, "", ExpectedException = typeof(ArgumentNullException))]
        [TestCase(null, "test", ExpectedException = typeof(ArgumentNullException))]
        [TestCase("", "", ExpectedException = typeof(ArgumentException))]
        [TestCase("", "aeıioöuü", ExpectedException = typeof(ArgumentException))]
        [TestCase("test", "", Result = false)]
        [TestCase("a", "aeıioöuü", Result = true)]
        [TestCase("b", "aeıioöuü", Result = false)]
        [TestCase("ba", "aeıioöuü", Result = false)]
        [TestCase("ab", "aeıioöuü", Result = true)]
        public bool FirstLetterEqualsAnyTest(String str, String letters)
        {
            IList<char> charList = new List<char>(letters.ToCharArray());
            return str.FirstCharEqualsAny(charList);
        }

        [TestCase(null, "", ExpectedException = typeof(ArgumentNullException))]
        [TestCase(null, "test", ExpectedException = typeof(ArgumentNullException))]
        [TestCase("", "", ExpectedException = typeof(ArgumentException))]
        [TestCase("", "aeıioöuü", ExpectedException = typeof(ArgumentException))]
        [TestCase("test", "", Result = false)]
        [TestCase("a", "aeıioöuü", Result = true)]
        [TestCase("b", "aeıioöuü", Result = false)]
        [TestCase("ba", "aeıioöuü", Result = true)]
        [TestCase("ab", "aeıioöuü", Result = false)]
        public bool LastLetterEqualsAnyTest(String str, String letters)
        {            
            IList<char> charList = new List<char>(letters.ToCharArray());
            return str.LastCharEqualsAny(charList);
        }

        [TestCase("deneme", "aeıioöuü", Result = 'e')]
        [TestCase("pçtk", "aeıioöuü", Result = null)]
        [TestCase("bbböb", "aeıioöuü", Result = 'ö')]
        [TestCase("bbbbbü", "aeıioöuü", Result = 'ü')]
        public char? FirstOccurrenceOfAnyTest(String str, String letters)
        {
            IList<char> charList = new List<char>(letters.ToCharArray());
            return str.FirstOccurrenceOfAny(charList);
        }
           
        [TestCase("a", "aeıioöuü", Result = 'a')]
        [TestCase("b", "aeıioöuü", Result = null)]
        [TestCase("ba", "aeıioöuü", Result = 'a')]
        [TestCase("ab", "aeıioöuü", Result = 'a')]
        [TestCase("babalü", "aeıioöuü", Result = 'ü')]
        public char? LastOccurrenceOfAnyTest(String str, String letters)
        {
            IList<char> charList = new List<char>(letters.ToCharArray());
            return str.LastOccurrenceOfAny(charList);
        }


        [TestCase("babeli", "aeıioöuü", Result = 'e')]
        [TestCase("babo", "aeıioöuü", Result = 'a')]
        [TestCase("boba", "aeıioöuü", Result = 'o')]
        [TestCase("ba", "aeıioöuü", Result = null)]
        [TestCase("ae", "aeıioöuü", Result = 'a')]
        public char? PenultimateOccurrenceOfAnyTest(String str, String letters)
        {
            IList<char> charList = new List<char>(letters.ToCharArray());
            return str.PenultimateOccurrenceOfAny(charList);
        }

        [TestCase("babeli", "aeıioöuü", Result = "bbeli")]
        [TestCase("bab", "aeıioöuü", Result = "bb")]
        [TestCase("bbba", "aeıioöuü", Result = "bbb")]
        [TestCase("bbb", "aeıioöuü", Result = "bbb")]
        public string DeleteFirstOccurrenceOfAnyTest(String str, String letters)
        {            
            return str.DeleteFirstOccurrenceOfAny(letters.ToCharArray());
        }

        [TestCase("babeli", "aeıioöuü", Result = "babel")]
        [TestCase("bab", "aeıioöuü", Result = "bb")]
        [TestCase("bbba", "aeıioöuü", Result = "bbb")]
        [TestCase("bbb", "aeıioöuü", Result = "bbb")]
        public string DeleteLastOccurrenceOfAnyTest(String str, String letters)
        {
            return str.DeleteLastOccurrenceOfAny(letters.ToCharArray());
        }
       
        [TestCase("a", Result = "")]
        [TestCase("ab", Result = "b")]
        [TestCase("abc", Result = "bc")]
        [TestCase("abcd", Result = "bcd")]
        public string DeleteFirstCharTest(String str)
        {            
            return str.DeleteFirstChar();
        }

        [TestCase("a", Result = "")]
        [TestCase("ab", Result = "a")]
        [TestCase("abc", Result = "ab")]
        [TestCase("abcd", Result = "abc")]
        public string DeleteLastCharTest(String str)
        {
            return str.DeleteLastChar();
        }


        [TestCase("babalı", "ba", "ara", Result = "arabalı")]
        [TestCase("babalı", "a", "e", Result = "bebalı")]
        [TestCase("babalı", "lı", "cık", Result = "babacık")]
        [TestCase("babalı", "da", "ara", Result = "babalı")]                
        public string ReplaceFirstOccurrenceTest(string str, string oldPattern, string newPattern )
        {
            return str.ReplaceFirstOccurrence(oldPattern, newPattern);
        }

        [TestCase("babalı", "ba", "ara", Result = "baaralı")]
        [TestCase("babalı", "a", "e", Result = "babelı")]
        [TestCase("babalı", "lı", "cık", Result = "babacık")]
        [TestCase("babalı", "da", "ara", Result = "babalı")]
        public string ReplaceLastOccurrenceTest(string str, string oldPattern, string newPattern)
        {
            return str.ReplaceLastOccurrence(oldPattern, newPattern);
        }

        [TestCase("", Result = "")]
        [TestCase("(", Result = "")]
        [TestCase("()", Result = "")]
        [TestCase("()()(())", Result = "")]
        [TestCase("((a)(b)(cd))", Result = "abcd")]
        public string RemoveParenthesesTest(String str)
        {
            return str.RemoveParentheses();
        }

        [Test]
        public void IsAnyNullOrEmptyTest()
        {
            string nullStr = null;
            string emptyStr = string.Empty;
            string notEmptyStr = "something";
            Assert.IsTrue(StringExtensions.IsAnyNullOrEmpty(nullStr));
            Assert.IsTrue(StringExtensions.IsAnyNullOrEmpty(nullStr, nullStr));
            Assert.IsTrue(StringExtensions.IsAnyNullOrEmpty(emptyStr, nullStr));
            Assert.IsTrue(StringExtensions.IsAnyNullOrEmpty(emptyStr, emptyStr));
            Assert.IsTrue(StringExtensions.IsAnyNullOrEmpty(notEmptyStr, emptyStr));
            Assert.IsTrue(StringExtensions.IsAnyNullOrEmpty(notEmptyStr, nullStr));
            Assert.IsTrue(StringExtensions.IsAnyNullOrEmpty(notEmptyStr, notEmptyStr, notEmptyStr, nullStr));
            Assert.IsTrue(StringExtensions.IsAnyNullOrEmpty(notEmptyStr, notEmptyStr, notEmptyStr, emptyStr));
            
            Assert.IsFalse(StringExtensions.IsAnyNullOrEmpty(notEmptyStr));
            Assert.IsFalse(StringExtensions.IsAnyNullOrEmpty(notEmptyStr, notEmptyStr));
            Assert.IsFalse(StringExtensions.IsAnyNullOrEmpty(notEmptyStr, notEmptyStr, notEmptyStr));
            Assert.IsFalse(StringExtensions.IsAnyNullOrEmpty(notEmptyStr, notEmptyStr, notEmptyStr, notEmptyStr));
            //Assert.IsTrue(StrUtil.IsNullOrEmpty("v")); 
        }

        [TestCase("babali", 0, 3, Result = "bab")]
        [TestCase("babali", 0, 0, Result = "")]
        [TestCase("babali", 0, 6, Result = "babali")]
        [TestCase("babali", 0, 7, ExpectedException = typeof(ArgumentOutOfRangeException))]
        public string SubstringJavaTest(string str, int start, int end)
        {
            return str.SubstringJava(start, end);
        }

        [TestCase("''abc''" , Result = "\"abc\"")]
        [TestCase("“abc”"   , Result = "\"abc\"")]
        [TestCase("«abc»"   , Result = "\"abc\"")]
        [TestCase("‘abc’"   , Result = "\'abc\'")]
        public string Normalize(string str)
        {
            const string doubleQuote = "\"";
            const string singleQuote = "'";
            var map = new Dictionary<string, string>
            {
                
                {"''", doubleQuote}, 
                {"”",  doubleQuote},
                {"“",  doubleQuote},
                {"»",  doubleQuote},
                {"«",  doubleQuote},
                {"’",  singleQuote},
                {"‘",  singleQuote},
                
            };
            return str.Normalize(map);
        }
      

    }
}
