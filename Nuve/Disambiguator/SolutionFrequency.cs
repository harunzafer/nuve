using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nuve.Morphologic.Structure;
using Nuve.Properties;

namespace Nuve.Disambiguator
{
    class SolutionFrequency
    { 
        // ReSharper disable once MemberCanBePrivate.Global
        public Word Word { get; private set; }
        // ReSharper disable once MemberCanBePrivate.Global
        public int Frequency { get; private set; }

        public double Probability { get; private set; }

        public SolutionFrequency(Word word)
        {
            Word = word;
            Frequency = 0;
            Probability = 0;
        }

        public void IncrementFrequency()
        {
            Frequency++;
        }

        public void SetProbability(double p)
        {
            if (p < 0 || p > 1)
            {
                throw new ArgumentOutOfRangeException("p", Resources.SolutionFrequency_SetProbability_ExceptionMessage);
            }
        }
        

    }
}
