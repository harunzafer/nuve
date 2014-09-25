using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable ReturnTypeCanBeEnumerable.Global

namespace Nuve.NGram
{
    public enum NGramSize
    {
        Unigram = 1,
        Bigram = 2,
        Trigram = 3
    }

    internal class NGramExtractor
    {
        private readonly int _windowSize;

        public NGramExtractor(NGramSize size)
        {
            _windowSize = (int) size;
        }

        /// <summary>
        /// Extracts all n-grams as a list which can contain same n-grams more than one.<br/>
        /// For the text "bir iki üç iki üç dört" (after tokenizing by white space) <br/>
        /// Expected unigrams are: {"bir", "iki", "üç", "iki", "üç", "dört"} <br/>
        /// Expected bigrams are: {"bir iki", "iki üç", "üç iki", "iki üç", "üç dört"} <br/>
        /// </summary>
        /// <param name="tokens"> a sequence of tokens </param>
        /// <returns>an n-gram list</returns>
        public IList<String> ExtractAsList(IList<String> tokens)
        {
            var terms = new List<string>();
            for (int i = 0; i <= tokens.Count - _windowSize; i++)
            {
                terms.Add(GetNGram(tokens, i, _windowSize));
            }
            return terms;
        }

        /// <summary>
        /// Extracts all n-grams as a set which contains a unique element for each n-gram.<br/>
        /// For the text "bir iki üç iki üç dört" (after tokenizing by white space) <br/>
        /// Expected unigrams are: {"bir", "iki", "üç", "dört"} <br/>
        /// Expected bigrams are: {"bir iki", "iki üç", "üç iki", "üç dört"} <br/>
        /// </summary>
        /// <param name="tokens">a sequence of tokens</param>
        /// <returns>an n-gram set</returns>
        public ISet<String> ExtractAsSet(IList<String> tokens)

        {
            if (_windowSize == (int) NGramSize.Unigram)
            {
                return new HashSet<string>(tokens);
            }

            var terms = new HashSet<string>();
            for (int i = 0; i <= tokens.Count - _windowSize; i++)
            {
                String term = GetNGram(tokens, i, _windowSize);
                terms.Add(term);
            }
            return terms;
        }
// ReSharper restore ReturnTypeCanBeEnumerable.Global

        /// <summary>
        /// Extracts all n-grams as a map from unique ngrams to their frequencies.<br/>
        /// For the text "bir iki üç iki üç dört" (after tokenizing by white space) <br/>
        /// Expected unigrams are: {"bir"=1, "iki"=2, "üç"=2, "dört"=1} <br/>
        /// Expected bigrams are: {"bir iki"=1, "iki üç"=2, "üç iki"=1, "üç dört"=1} <br/>
        /// </summary>
        /// <param name="tokens">a sequence of tokens</param>
        /// <returns>a map from n-grams to their frequencies</returns>
        public IDictionary<String, int> ExtractAsDictionary(IList<String> tokens)
        {
            var terms = new Dictionary<string, int>();
            for (int i = 0; i <= tokens.Count - _windowSize; i++)
            {
                String term = GetNGram(tokens, i, _windowSize);
                if (terms.ContainsKey(term))
                {
                    terms[term]++;
                }
                else
                {
                    terms.Add(term, 1);
                }
            }            
            return terms;
        }



        private String GetNGram(IList<string> tokens, int index, int windowSize)
        {
            string prefix = "";
            var shingle = new StringBuilder();
            for (int i = 0; i < windowSize; i++)
            {
                shingle.Append(prefix);
                prefix = " ";
                shingle.Append(tokens[index + i]);
            }
            return shingle.ToString();
        }
    }
}