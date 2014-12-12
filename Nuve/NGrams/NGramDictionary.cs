using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.NGrams
{
    /// <summary>
    ///     A mapping from n-grams to their frequencies. <br />
    ///     Mostly used to estimate probabilities of an n-gram language model.
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

        private NGramDictionary(NGramExtractor extractor, IDictionary<NGram, int> nGrams)
        {
            this.extractor = extractor;
            this.nGrams = nGrams;
        }

        public void AddSequence(IEnumerable<string> tokens)
        {
            IDictionary<NGram, int> newNGrams = extractor.ExtractAsDictionary(tokens);
            nGrams.Merge(newNGrams);
        }

        /// <summary>
        /// returns frequency of the n-gram which consists of nGramTokens
        /// </summary>
        /// <param name="nGramTokens">Tokens of the n-gram</param>
        /// <returns></returns>
        public int GetFrequency(params string[] nGramTokens)
        {
            Validate(nGramTokens);
            var nGram = new NGram(nGramTokens);
            return GetFrequency(nGram);
        }

        /// <summary>
        /// returns requency of the n-gram
        /// </summary>
        /// <param name="nGram"></param>
        /// <returns></returns>
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

        /// <summary>
        /// String representation of this object. <br />
        /// It is used to serialize the object.<br />
        /// This string returned by this method is used as parameter of DeserializeFrom method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder().
                Append(extractor.MinNGramSize).
                Append("\t").
                Append(extractor.MaxNGramSize).
                Append("\n");

            foreach (var pair in nGrams)
            {
                sb.Append(pair.Key).Append("\t").Append(pair.Value).Append("\n");
            }
            return sb.ToString().TrimEnd();
        }

        /// <summary>
        /// Creates and returns a new NGramDictionary from a string.<br/>
        /// This string must be produced by the ToString() method of a NGramDictionary object.
        /// </summary>
        /// <param name="str">A string produced by the ToString() method of a NGramDictionary object.</param>
        /// <returns>A new NGramDictionary object</returns>
        public static NGramDictionary DeserializeFrom(string str)
        {
            string[] lines = str.Split('\n');
            int minNGram = Int32.Parse(lines[0].Split('\t')[0]);
            int maxNGram = Int32.Parse(lines[0].Split('\t')[1]);

            IDictionary<NGram, int> nGrams = new Dictionary<NGram, int>();
            var extractor = new NGramExtractor(minNGram, maxNGram);

            foreach (string line in lines.Skip(1))
            {
                string[] row = line.Split('\t');

                var nGram = new NGram(row[0].Split(null));

                int freq = Int32.Parse(row[1]);

                if (!nGrams.ContainsKey(nGram))
                {
                    nGrams.Add(nGram, freq);
                }
            }

            return new NGramDictionary(extractor, nGrams);
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