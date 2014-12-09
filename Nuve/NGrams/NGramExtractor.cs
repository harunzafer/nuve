using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace Nuve.NGrams
{
    /// <summary>
    /// Represents an object to extract n-grams from a sequence of tokens.<br/>
    /// See <see cref="ExtractAsSet"/>, <see cref="ExtractAsList"/>, and <see cref="ExtractAsDictionary"/> for more detail.
    /// </summary>
    public class NGramExtractor
    {
        private readonly int minNGramSize;
        private readonly int maxNGramSize;

        public int MinNGramSize { get { return minNGramSize; } }
        
        public int MaxNGramSize { get { return maxNGramSize; } }

        /// <summary>
        /// minNGramSize must be less than or equal to maxNGramSize<br/>
        /// </summary>
        /// <param name="minNGramSize">must be in range [1-9] </param>
        /// <param name="maxNGramSize">must be in range [1-9]</param>
        public NGramExtractor(int minNGramSize, int maxNGramSize)
        {
            Validate(minNGramSize);
            Validate(maxNGramSize);
            
            if (minNGramSize > maxNGramSize)
            {
                throw new ArgumentException("min n-gram size must not be greater than max n-gram size");
            }

            this.minNGramSize = minNGramSize;
            this.maxNGramSize = maxNGramSize;
        }

        public NGramExtractor(int nGramSize): this(nGramSize, nGramSize) { }

        private void Validate(int nGramSize)
        {
            if (!IsValid(nGramSize))
            {
                throw new ArgumentException("n-gram size values must be in range [1-9]");
            }
        }

        private bool IsValid(int nGramSize)
        {
            return nGramSize > 0  || nGramSize < 10;
        }

        /// <summary>
        /// Extracts all n-grams as a set which contains a unique element for each n-gram.<br/>
        /// For the text "one two three two three four" (after tokenizing by white space) <br/>
        /// Expected unigrams are: {"one", "two", "three", "four"} <br/>
        /// Expected bigrams are: {"one two", "two three", "three two", "three four"} <br/>
        /// </summary>
        /// <param name="tokens">a sequence of tokens</param>
        /// <returns>an n-gram set</returns>
        public ISet<NGram> ExtractAsSet(IEnumerable<string> tokens)
        {
            var nGrams = ExtractAsList(tokens);
            return new HashSet<NGram>(nGrams);
        }


        /// <summary>
        /// Extracts all n-grams as a map from unique ngrams to their frequencies.<br/>
        /// For the text "one two three two three four" (after tokenizing by white space) <br/>
        /// Expected unigrams are: {"one"=1, "two"=2, "three"=2, "four"=1} <br/>
        /// Expected bigrams are: {"one two"=1, "two three"=2, "three two"=1, "three four"=1} <br/>
        /// </summary>
        /// <param name="tokens">a sequence of tokens</param>
        /// <returns>a map from n-grams to their frequencies</returns>
        public IDictionary<NGram, int> ExtractAsDictionary(IEnumerable<string> tokens)
        {
            var dictionary = new Dictionary<NGram, int>();
            var nGrams = ExtractAsList(tokens);

            foreach (var nGram in nGrams)
            {
                if (dictionary.ContainsKey(nGram))
                {
                    dictionary[nGram]++;
                }
                else
                {
                    dictionary.Add(nGram, 1);
                }
            }

            return dictionary;
        }

        /// <summary>
        /// Extracts all n-grams as a list which can contain same n-grams more than one.<br/>
        /// For the text "one two three two three four" (after tokenizing by white space) <br/>
        /// Expected unigrams are: {"one", "two", "three", "two", "three", "four"} <br/>
        /// Expected bigrams are: {"one two", "two three", "three two", "two three", "three four"} <br/>
        /// </summary>
        /// <param name="tokens"> a sequence of tokens </param>
        /// <returns>an n-gram list</returns>
        public IList<NGram> ExtractAsList(IEnumerable<string> tokens)
        {
            var nGrams = new List<NGram>();
            var tokenList = tokens.ToList();
            for (int i = 0; i <= tokens.Count() - minNGramSize; i++)
            {
                nGrams.AddRange(GetNGrams(tokenList, i));
            }
            return nGrams;
        }

        private IEnumerable<NGram> GetNGrams(IList<string> tokens, int index)
        {
            var nGrams = new List<NGram>();
            var maxWindowSize = Math.Min(tokens.Count() - index, maxNGramSize);
            for (int windowSize = minNGramSize; windowSize <= maxWindowSize ; windowSize++)
            {
                var nGram = GetNGram(tokens, index, windowSize);
                nGrams.Add(nGram); 
            }
            return nGrams;
        }

        private NGram GetNGram(IList<string> tokens, int index, int windowSize)
        {
            var nGram = new List<string>();
            for (int i = 0; i < windowSize; i++)
            {
                nGram.Add(tokens[index + i]);
            }
            return new NGram(nGram);
        }
    }
}