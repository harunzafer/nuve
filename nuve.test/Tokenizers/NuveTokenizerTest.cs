using System;
using System.Collections.Generic;
using NUnit.Framework;
using Nuve.Tokenizers;

namespace Nuve.Test.Tokenizers
{
    [TestFixture]
    internal class NuveTokenizerTest
    {
        [TestCase("", Result = new object[] {})]
        [TestCase("a\nb", Result = new object[] {"a", "b"})]
        [TestCase("a\r\nb", Result = new object[] {"a", "b"})]
        [TestCase("a\rb", Result = new object[] {"a", "b"})]
        [TestCase("aa33bb", Result = new object[] {"aa33bb"})]
        [TestCase("30cm", Result = new[] {"30", "cm"})]
        [TestCase("Ankara'ya", Result = new object[] {"Ankara'ya"})]
        [TestCase("'Ankara ve Ankara'", Result = new object[] {"Ankara", "ve", "Ankara"})]
        [TestCase("iyi-kötü", Result = new object[] {"iyi", "kötü"})]
        [TestCase("abc def", Result = new object[] {"abc", "def"})]
        [TestCase("a,b", Result = new object[] {"a", "b"})]
        [TestCase("(a)", Result = new[] {"a"})]
        [TestCase("Prof. Dr.", Result = new object[] {"Prof", "Dr"})]
        [TestCase("harun.zafer@tubitak.gov.tr", Result = new object[] {"harun.zafer@tubitak.gov.tr"})]
        [TestCase("Kur'an-ı Kerim", Result = new object[] {"Kur'an-ı", "Kerim"})]
        [TestCase("Kur'an'ı okumak", Result = new object[] {"Kur'an'ı", "okumak"})]
        [TestCase("Kuran-ı Kerim", Result = new object[] {"Kuran-ı", "Kerim"})]
        [TestCase("TL-WA854RE'nin", Result = new object[] {"TL", "WA854RE'nin"})]
        [TestCase("www.blog.hrzafer.com", Result = new object[] {"www.blog.hrzafer.com"})]
        [TestCase("33,05", Result = new object[] {"33,05"})]
        [TestCase("33.05", Result = new object[] {"33.05"})]
        [TestCase("komik :)", Result = new object[] {"komik"})]
        [TestCase("No:11/A", Result = new object[] {"No", "11", "A"})]
        [TestCase("2006'dan 2007'ye", Result = new object[] {"2006'dan", "2007'ye"})]
        [TestCase("öyledir.[7]", Result = new object[] {"öyledir", "7"})]
        [TestCase("öyledir. [7]", Result = new object[] {"öyledir", "7"})]
        [TestCase("\"Buraya gel\" dedi.", Result = new object[] {"Buraya", "gel", "dedi"})]
        [TestCase("Hemen \"bitti\" demeyin!",
            Result = new object[] {"Hemen", "bitti", "demeyin"})]
        [TestCase("Hemen \"bitti!\" demeyin.",
            Result = new object[] {"Hemen", "bitti", "demeyin"})]
        [TestCase("2 No.lu", Result = new object[] {"2", "No.lu"})]
        [TestCase("1. değil 2. oldum", Result = new object[] {"1", "değil", "2", "oldum"})]
        [TestCase("kaç m²(metrekare)", Result = new object[] {"kaç", "m", "metrekare"})]
        [TestCase("postalarım e-postalarımın e-postalarınızdaki",
            Result = new object[] {"postalarım", "e-postalarımın", "e-postalarınızdaki"})]
        [TestCase("Please, email john.doe@foo.com by 03-09, re: m37-xq.",
            Result =
                new object[]
                {
                    "Please", "email", "john.doe@foo.com", "by", "03", "09", "re", "m37", "xq"
                })]
        public IList<string> TestNuveTokenizerReturnDelimsFalse(string text)
        {
            var tokenizer = new NuveTokenizer();
            IList<string> tokens = tokenizer.Tokenize(text);
            return tokens;
        }

        [TestCase("", Result = new object[] {})]
        [TestCase("a\nb", Result = new object[] {"a", "\n", "b"})]
        [TestCase("a\r\nb", Result = new object[] {"a", "\r\n", "b"})]
        [TestCase("a\rb", Result = new object[] {"a", "\r", "b"})]
        [TestCase("aa33bb", Result = new object[] {"aa33bb"})]
        [TestCase("30cm", Result = new[] {"30", "cm"})]
        [TestCase("Ankara'ya", Result = new object[] {"Ankara'ya"})]
        [TestCase("'Ankara ve Ankara'", Result = new object[] {"'", "Ankara", " ", "ve", " ", "Ankara", "'"})]
        [TestCase("iyi-kötü", Result = new object[] {"iyi", "-", "kötü"})]
        [TestCase("abc def", Result = new object[] {"abc", " ", "def"})]
        [TestCase("a,b", Result = new object[] {"a", ",", "b"})]
        [TestCase("(a)", Result = new[] {"(", "a", ")"})]
        [TestCase("Prof. Dr.", Result = new object[] {"Prof", ".", " ", "Dr", "."})]
        [TestCase("harun.zafer@tubitak.gov.tr", Result = new object[] {"harun.zafer@tubitak.gov.tr"})]
        [TestCase("Kur'an-ı Kerim", Result = new object[] {"Kur'an-ı", " ", "Kerim"})]
        [TestCase("Kur'an'ı okumak", Result = new object[] {"Kur'an'ı", " ", "okumak"})]
        [TestCase("Kuran-ı Kerim", Result = new object[] {"Kuran-ı", " ", "Kerim"})]
        [TestCase("TL-WA854RE'nin", Result = new object[] {"TL", "-", "WA854RE'nin"})]
        [TestCase("www.blog.hrzafer.com", Result = new object[] {"www.blog.hrzafer.com"})]
        [TestCase("33,05", Result = new object[] {"33,05"})]
        [TestCase("33.05", Result = new object[] {"33.05"})]
        [TestCase("komik :)", Result = new object[] {"komik", " ", ":", ")"})]
        [TestCase("No:11/A", Result = new object[] {"No", ":", "11", "/", "A"})]
        [TestCase("2006'dan 2007'ye", Result = new object[] {"2006'dan", " ", "2007'ye"})]
        [TestCase("öyledir.[7]", Result = new object[] {"öyledir", ".", "[", "7", "]"})]
        [TestCase("öyledir. [7]", Result = new object[] {"öyledir", ".", " ", "[", "7", "]"})]
        [TestCase("\"Buraya gel\" dedi.", Result = new object[] {"\"", "Buraya", " ", "gel", "\"", " ", "dedi", "."})]
        [TestCase("Hemen \"bitti\" demeyin!",
            Result = new object[] {"Hemen", " ", "\"", "bitti", "\"", " ", "demeyin", "!"})]
        [TestCase("Hemen \"bitti!\" demeyin.",
            Result = new object[] {"Hemen", " ", "\"", "bitti", "!", "\"", " ", "demeyin", "."})]
        [TestCase("2 No.lu", Result = new object[] {"2", " ", "No.lu"})]
        [TestCase("1. değil 2. oldum", Result = new object[] {"1", ".", " ", "değil", " ", "2", ".", " ", "oldum"})]
        [TestCase("kaç m²(metrekare)", Result = new object[] {"kaç", " ", "m", "²", "(", "metrekare", ")"})]
        [TestCase("postalarım e-postalarımın e-postalarınızdaki",
            Result = new object[] {"postalarım", " ", "e-postalarımın", " ", "e-postalarınızdaki"})]
        [TestCase("Please, email john.doe@foo.com by 03-09, re: m37-xq.",
            Result =
                new object[]
                {
                    "Please", ",", " ", "email", " ", "john.doe@foo.com", " ", "by", " ", "03", "-", "09", ",", " ",
                    "re",
                    ":", " ",
                    "m37", "-", "xq", "."
                })]
        public IList<string> TestNuveTokenizerReturnDelimsTrue(string text)
        {
            var tokenizer = new NuveTokenizer(true);
            IList<string> tokens = tokenizer.Tokenize(text);
            int length = String.Join("", tokens).Length;
            Assert.AreEqual(length, text.Length);
            return tokens;
        }
    }
}