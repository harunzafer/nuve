using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Nuve.Sentence;

namespace Nuve.Test.Segmentation
{
    [TestFixture]
    internal class SentenceSegmentationTest
    {
        private const string RawParagraph = "Mahkemeye sevk edilen 8 kisinin Sisli 2. Asliye Ceza Mahkemesi'nde tekrar ifadeleri alındı. " +
                                            "Prof. Dr. Ahmet Bey ile görüsecegiz. " +
                                            "Daha sonra Ars. Gör. Özlem hanım da katılacak bize. " +
                                            "Dr. Ahmet bey de gelecek. " +
                                            "As. İz. Mehmet gelemeyecekmis. " +
                                            "1.6 oranında artıs var.";

        private const string CorrectSegmentation =
            "Mahkemeye sevk edilen 8 kisinin Sisli 2. Asliye Ceza Mahkemesi'nde tekrar ifadeleri alındı.# " +
            "Prof. Dr. Ahmet Bey ile görüsecegiz.# " +
            "Daha sonra Ars. Gör. Özlem hanım da katılacak bize.# " +
            "Dr. Ahmet bey de gelecek.# " +
            "As. İz. Mehmet gelemeyecekmis.# " +
            "1.6 oranında artıs var.#";

        private const string PredictedSegmentation1 =
            "Mahkemeye sevk edilen 8 kisinin Sisli 2.# "+
            "Asliye Ceza Mahkemesi'nde tekrar ifadeleri alındı.# "+
            "Prof. Dr. Ahmet Bey ile görüsecegiz.# "+
            "Daha sonra Ars.# "+
            "Gör.# "+
            "Özlem hanım da katılacak bize.# "+
            "Dr.# "+
            "Ahmet bey de gelecek.# "+
            "As.# "+
            "İz.# "+
            "Mehmet gelemeyecekmis.# "+
            "1.#"+
            "6 oranında artıs var.#";

        //private static int[] misses = { }

        //private static readonly DetailedEvaluation ExpectedResult = new DetailedEvaluation(missed: 0, falseAlarm: 7, eosCharCount:15);

        //[Test]
        //public void SenteneSegmentationResultTest()
        //{
        //    var actual = SentenceSegmenterEvaluator.Evaluate(CorrectSegmentation, PredictedSegmentation1);
        //    Assert.AreEqual(ExpectedResult, actual);
        //}

        //[TestCase("#", new[] {-1})]
        //[TestCase(".#", new[] { 0 })]
        //[TestCase(".# !# ?#", new[] { 0, 2, 4 })]
        //[TestCase("##", new[] {-1, -1})]
        //[TestCase("#ab#cd#", new[] { -1, 1, 3 })]
        //[TestCase("ab.#cd.#", new[] { 2, 5 })]
        //[TestCase("abc", new int[] {})]
        //public void GetBoundaryIndexesTest(string text, IEnumerable<int> boundaries)
        //{
        //    var actual = SentenceSegmenterEvaluator.GetBoundaryIndices(text);
        //    CollectionAssert.AreEqual(actual, boundaries);
        //}

        //[TestCase(new[] { 5, 10, 15},  new[] { 5, 12 }, 2, 1)]
        //[TestCase(new[] { 5, 10, 15 }, new[] { 5, 10, 15 }, 0, 0)]
        //[TestCase(new[] { 5, 10, 15 }, new[] { 6, 11, 16 }, 3, 3)]
        //[TestCase(new int[] { }, new[] { 5, 12 }, 0, 2)]
        //[TestCase(new int[] { }, new int[] {}, 0, 0)]
        //[TestCase(new [] { 5, 9}, new int[] {}, 2, 0)]
        //public void EvaluateIndexesTest(IEnumerable<int> set1, IEnumerable<int> set2, int missed, int falseAlarm)
        //{
        //    var actual = SentenceSegmenterEvaluator.Evaluate(set1, set2);
        //    var expected = new SentenceSegmenterEvaluator.Result{Missed = missed, FalseAlarm = falseAlarm};
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestCase("a. b! c?", new[] { 1, 4, 7 })]
        //[TestCase("a. b! c? d", new[] { 1, 4, 7, 9 })]
        //[TestCase("a. b! c? d", new[] { 1, 4, 7, 9 })]
        //[TestCase("abc", new[] { 2 })]
        //[TestCase(RawParagraph, new[] { 39, 90, 96, 100, 127, 143, 148, 179, 183, 205, 209, 213, 236, 239, 260 })]
        //public void BaseLineSentenceTokenizerTest(string paragraph, IEnumerable<int> expectedIndexes)
        //{
        //    SentenceSegmenter segmenter = new SimpleSentenceSegmenter(new char[] { '.', '!', '?' });
        //    var actual = segmenter.GetBoundaryIndices(paragraph);
        //    CollectionAssert.AreEqual(actual, expectedIndexes);
        //}

       
    }
}