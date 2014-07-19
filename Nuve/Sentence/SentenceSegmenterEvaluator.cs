using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuve.Sentence
{
    /// <summary>
    /// Evaluates the accuracy of a SentenceSegmenter on a paragraph.
    /// </summary>
   internal static class SentenceSegmenterEvaluator
    {
        internal class Result
        {
            public int Missed { set; get; }
            public int FalseAlarm { set; get; }

            protected bool Equals(Result other)
            {
                return Missed == other.Missed && FalseAlarm == other.FalseAlarm;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Result) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Missed*397) ^ FalseAlarm;
                }
            }
        }


        public static IEnumerable<DetailedEvaluation> Evaluate(this SentenceSegmenter segmenter,
            IEnumerable<string> taggedParagraphs,
            string tag = "#")
        {
            var evaluations = new List<DetailedEvaluation>();
            foreach (string taggedParagraph in taggedParagraphs)
            {
                evaluations.Add(Evaluate(segmenter, taggedParagraph)); 
            }
            return evaluations;
        }

        public static DetailedEvaluation Evaluate(this SentenceSegmenter segmenter, string taggedParagraph, string tag = "#")
        {
            IEnumerable<int> realIndices = GetBoundaryIndices(taggedParagraph, tag);
            string untaggedParagraph = taggedParagraph.Replace(tag, "");
            return Evaluate(segmenter, untaggedParagraph, realIndices);
        }

        public static DetailedEvaluation Evaluate(this SentenceSegmenter segmenter, string paragraph, IEnumerable<int> realBoundaryIndices)
        {
            IEnumerable<int> predictedIndices = segmenter.GetBoundaryIndices(paragraph);
            
            // ReSharper disable PossibleMultipleEnumeration
            var misses = realBoundaryIndices.Except(predictedIndices);
            var falseAlarms = predictedIndices.Except(realBoundaryIndices);
            var hits = realBoundaryIndices.Intersect(predictedIndices);
            // ReSharper restore PossibleMultipleEnumeration

            int eosCandidateCount = GetEosCharCount(segmenter.EosCandidates, paragraph);

            return new DetailedEvaluation(hits, misses, falseAlarms, eosCandidateCount, paragraph);
        }

        private static int GetEosCharCount(IEnumerable<char> eosCandidates, string paragraph )
        {
            int count = paragraph.Count(c => eosCandidates.Contains(c));
            return count == 0 ? 1 : count;
        }

        public static IEnumerable<int> GetBoundaryIndices(string paragraph, string tag)
        {
            int index = -1;
            int sharpCount = 0;
            var boundaries = new List<int>();
            while (true)
            {
                index = paragraph.IndexOf(tag, index + 1, StringComparison.Ordinal);
                if (index != -1)
                {
                    sharpCount++;
                    boundaries.Add(index - sharpCount);
                }
                else
                {
                    break;    
                }
            }
            return boundaries;
        }

        public static void GetTotalReport(IEnumerable<DetailedEvaluation> evaluations, bool printHits=false, bool printMisses=false, bool printFalseAlarms=false )
        {
            int totalEos = 0;
            int totalMisses = 0;
            int totalHits = 0;
            int totalFalseAlarms = 0;
            foreach (var evaluation in evaluations)
            {
                totalEos += evaluation.EosCount;
                totalHits += evaluation.Hit;
                totalMisses += evaluation.Missed;
                totalFalseAlarms += evaluation.FalseAlarm;

                if (printHits)
                {
                    evaluation.PrintFalseAlarms();     
                }

                if (printMisses)
                {
                    evaluation.PrintMisses();
                }
                if (printFalseAlarms)
                {
                    evaluation.PrintFalseAlarms();
                }
            }
            var totalEval = new SimpleEvaluation(totalHits, totalMisses, totalFalseAlarms, totalEos);
            Console.WriteLine(totalEval);
        }

    }
}