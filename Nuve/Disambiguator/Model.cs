using System.Collections.Generic;
using Nuve.Morphologic.Structure;

namespace Nuve.Disambiguator
{
    internal class Model
    {
        private readonly IDictionary<Word, int> _model;

        public Model(IDictionary<Word, int> model)
        {
            _model = model;
        }

        //public Disambiguate(IList<Word> solutions)
        //{
        //    IList<SolutionFrequency> 
        //    foreach (var solution in solutions)
        //    {
        //        int f =_model[solution];

        //    }

        //}
    }
}