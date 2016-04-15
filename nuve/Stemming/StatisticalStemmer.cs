using System.Collections.Generic;
using Nuve.Lang;
using Nuve.Morphologic.Structure;
using Nuve.NGrams;

namespace Nuve.Stemming
{
    internal class StatisticalStemmer : IStemmer
    {
        private readonly WordAnalyzer analyzer;
        private readonly NGramModel model;

        public StatisticalStemmer(NGramModel model, WordAnalyzer analyzer)
        {
            this.model = model;
            this.analyzer = analyzer;
        }

        public string GetStem(string word)
        {
            IList<Word> solutions = analyzer.Analyze(word);

            if (solutions.Count == 0)
            {
                return word;
            }

            if (solutions.Count == 1)
            {
                return solutions[0].GetStem().GetSurface();
            }

            double max = double.NegativeInfinity;
            int maxIndex = 0;

            for (int i = 0; i < solutions.Count; i++)
            {
                double p = model.GetSentenceProbability(solutions[i].GetSequenceIds());
                //Console.WriteLine(solutions[i] + "\t" + p);

                if (p > max)
                {
                    max = p;
                    maxIndex = i;
                }
            }

            return solutions[maxIndex].GetStem().GetSurface();
        }
    }
}