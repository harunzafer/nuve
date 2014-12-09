using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.NGrams
{
    /// <summary>
    /// A mapping from n-grams to their frequencies. <br/>
    /// Mostly used to estimate probabilities of an n-gram language model.
    /// </summary>
    public class NGramDictionary
    {
        private readonly NGramExtractor extractor;

        private readonly IDictionary<NGram, int> nGrams;

        public NGramDictionary(NGramExtractor extractor)
        {
            this.extractor = extractor;
            nGrams = new Dictionary<NGram, int>();
        }

        public void AddSequence(IEnumerable<string> tokens)
        {
            var newNGrams = extractor.ExtractAsDictionary(tokens);
            nGrams.Merge(newNGrams);
        }

        public void Add(NGram nGram, int freq)
        {
            if (!nGrams.ContainsKey(nGram))
            {
                nGrams.Add(nGram, freq);
            }
        }

        public int GetFrequency(params string[] nGramTokens)
        {
            Validate(nGramTokens);
            var nGram = new NGram(nGramTokens);
            return GetFrequency(nGram);
        }

        public int GetFrequency(NGram nGram)
        {
            if (nGrams.ContainsKey(nGram))
            {
                return nGrams[nGram];
            }
            return 0;
        }

        private void Validate(string[] nGramTokens)
        {
            if (nGramTokens.Length > extractor.MaxNGramSize || nGramTokens.Length < extractor.MinNGramSize)
            {
                throw new ArgumentException(
                    string.Format(
                        @"Length of nGramTokens ({0}) must not be greater than maxNGramSize or less than minNGramSize",
                        nGramTokens.Length));
            }
        }

        public override string ToString()
        {
            var entries = nGrams.Select(d => string.Format("{0}\t{1}", d.Key, d.Value));
            return  string.Join("\n", entries) ;
        }
    }


    internal static class Extensions
    {
        public static void Merge(this IDictionary<NGram, int> first, IEnumerable<KeyValuePair<NGram, int>> second)
        {
            foreach (var nGram in second)
            {
                if (first.ContainsKey(nGram.Key))
                {
                    first[nGram.Key] += nGram.Value;
                }
                else
                {
                    first.Add(nGram);
                }
            }
        }
    }
}