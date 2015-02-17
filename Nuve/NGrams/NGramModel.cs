using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;

namespace Nuve.NGrams
{
    /// <summary>
    /// This class is in experimental state. Use at your own risk.
    /// </summary>
    class NGramModel
    {
        private readonly NGramDictionary nGramDictionary;
        private readonly NGramExtractor extractor;
        private int tokenCount;
        private const string Start = "<s>";
        private const string Stop = "</s>";
        private readonly int maxNGramSize ;

        public NGramModel(int nGramSize)
        {
            maxNGramSize = nGramSize;
            extractor = new NGramExtractor(1, maxNGramSize);
            nGramDictionary = new NGramDictionary(extractor);
        }

        public NGramModel(int nGramSize, string modelFilepath)
        {
            nGramDictionary = new NGramDictionary(extractor);
            maxNGramSize = nGramSize;
            extractor = new NGramExtractor(1, maxNGramSize);
            var lines = File.ReadAllLines(modelFilepath);
            //AddAll(lines);
        }

        
        public void AddSentence(IEnumerable<string> tokens)
        {
            var tokenList = tokens.ToList();
            tokenCount += tokenList.Count;
            AddStartStopSymbols(tokenList);
            nGramDictionary.AddSequence(tokenList);
        }

        public void AddStartStopSymbols(IList<string> tokens)
        {
            if (extractor.MaxNGramSize <= 1) return;

            for (int i = 0; i < extractor.MaxNGramSize - 1; i++)
            {
                var index = (i).ToString();
                tokens.Insert(0, Start.Insert(2, index));
            }

            tokens.Add(Stop);
        }

        public double GetSentenceProbability(params string[] tokens)
        {
            return GetSentenceProbability(tokens.ToList());
        }

        public double GetSentenceProbability(IList<string> tokens)
        {
            if (maxNGramSize == 1)
            {
                return GetSentenceProbabilityForUnigrams(tokens);
            }

            var tokenList = tokens.ToList();
            AddStartStopSymbols(tokenList);

            var ext = new NGramExtractor(maxNGramSize - 1, maxNGramSize);
            var nGrams = ext.ExtractAsList(tokenList);
            nGrams.RemoveAt(nGrams.Count - 1);

            double logP = 0;
            for (int i = 0; i < nGrams.Count; i += 2)
            {
                var p = GetMLE(nGrams[i], nGrams[i + 1]);

                logP += Math.Log10(p);

                var x = nGrams[i];

                //Console.WriteLine(nGrams[i + 1] + "/" + nGrams[i] + ":" + Math.Log10(p));
                //Console.WriteLine(nGrams[i] + ":" + Math.Log10(GetUnigramMLE(nGrams[i])));
            }

            //double p = 1;
            //for (int i = 0; i < nGrams.Count; i += 2)
            //{
            //    p *= GetMLE(nGrams[i], nGrams[i + 1]);
            //}

            //return p;

            return logP;
        }

        public double GetMLE(NGram denominatorNGram, NGram nominatorNGram)
        {
            var nom = nGramDictionary.GetFrequency(nominatorNGram);
            var denom = nGramDictionary.GetFrequency(denominatorNGram);
            
            if (denom == 0)
            {
                return 0;
            }

            return nom / (double) denom;
        }

        public double GetSentenceProbabilityForUnigrams(IEnumerable<string> tokens)
        {
            var nGrams = extractor.ExtractAsList(tokens);
            
            double p = 1;
            foreach (var nGram in nGrams)
            {
                p *= GetUnigramMLE(nGram);
            }

            return p;
        }   

        public double GetUnigramMLE(NGram nGram)
        {
            return nGramDictionary.GetFrequency(nGram) / (double)tokenCount;
        }

        public void Deserialize(string filepath)
        {
            var json = nGramDictionary.ToString();
            File.WriteAllText(filepath, json);
        }


    }
}
