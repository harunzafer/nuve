using System;
using System.Linq;
using Nuve.Lang;
using Nuve.NGrams;

namespace Nuve.Stemming
{
    class StatisticalStemmer : IStemmer
    {
        private readonly NGramModel model;
        private readonly WordAnalyzer analyzer;

        public StatisticalStemmer(NGramModel model, WordAnalyzer analyzer)
        {
            this.model = model;
            this.analyzer = analyzer;
        }
        
        public string GetStem(string word)
        {
            
            var solutions = analyzer.Analyze(word);

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
                var p = model.GetSentenceProbability(solutions[i].GetMorphemeIds());
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
