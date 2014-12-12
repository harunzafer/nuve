using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using Newtonsoft.Json;

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

        private NGramDictionary(NGramExtractor extractor, IDictionary<NGram, int> nGrams)
        {
            this.extractor = extractor;
            this.nGrams = nGrams;
        }

        public static NGramDictionary DeserializeFrom(string str)
        {
            var lines = str.Split('\n');
            var minNGram = Int32.Parse(lines[0].Split('\t')[0]);
            var maxNGram = Int32.Parse(lines[0].Split('\t')[1]);

            IDictionary<NGram, int> nGrams = new Dictionary<NGram, int>();
            var extractor = new NGramExtractor(minNGram, maxNGram);

            foreach (var line in lines.Skip(1))
            {
                var row = line.Split('\t');

                var nGram = new NGram(row[0].Split(null));

                int freq = Int32.Parse(row[1]);

                if (!nGrams.ContainsKey(nGram))
                {
                    nGrams.Add(nGram, freq);
                }
            }

            return new NGramDictionary(extractor, nGrams);
        }

        public void AddSequence(IEnumerable<string> tokens)
        {
            var newNGrams = extractor.ExtractAsDictionary(tokens);
            nGrams.Merge(newNGrams);
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
            var sb = new StringBuilder().
                Append(extractor.MinNGramSize).
                Append("\t").
                Append(extractor.MaxNGramSize).
                Append("\n");

            foreach (KeyValuePair<NGram, int> pair in nGrams)
            {
                sb.Append(pair.Key).Append("\t").Append(pair.Value).Append("\n");
            }
            return sb.ToString().TrimEnd();            
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