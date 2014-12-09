using System.Collections.Generic;
using System.Linq;
using Nuve.Lang;
using Nuve.Morphologic.Structure;

namespace Nuve.Stemming
{
    internal class RuleBasedStemmer : IStemmer
    {
        private readonly WordAnalyzer analyzer;

        public RuleBasedStemmer(WordAnalyzer analyzer)
        {
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

            solutions = solutions.Reverse().ToList();

            if (solutions[0].HasSuffixAt("IY_FIIL_lA", 1) && 
                solutions[1].HasSuffixAt("FY_EDILGEN_Ul_(U)n", 1))
            {
                return solutions[1].GetStem().GetSurface();
            }

            if (solutions[0].LastSuffixEquals("FIILIMSI_SIFAT_(y)AcAK") &&
                solutions[1].LastSuffixEquals("FC_ZAMAN_GELECEK_(y)AcAK"))
            {
                return solutions[1].GetStem().GetSurface();
            }

            
            if (solutions[0].LastSuffixEquals("IY_FIIL_lA") &&
                solutions[1].LastSuffixEquals("IC_HAL_VASITA_(y)lA"))
            {
                return solutions[1].GetStem().GetSurface();
            }


            


            return solutions[0].GetStem().GetSurface();
        }

        //common ambiguities
        
        //yap/FIIL Ul/FY_EDILGEN_Ul_(U)n Uyor/FC_ZAMAN_SIMDIKI_(U)yor
	    //yapı/ISIM lA/IY_FIIL_lA Uyor/FC_ZAMAN_SIMDIKI_(U)yor


        private static readonly string[] ProblematicDerivationals =
        {
            "IY_FIIL_lA",
            "IY_SIFAT_sU",
            "FIILIMSI_SIFAT_(y)AcAK",
            //"FIILIMSI_SIFAT_DUK",
            "FIILIMSI_SIFAT_mAz",
            "FIILIMSI_SIFAT_mUş",
            "FIILIMSI_ISIM_mAk",
            "FY_ETTIRGEN_DUr_(U)t"
        };

        private Word SelectBestSolution(IEnumerable<Word> solutions)
        {
            //Get stems from solutions
            var stems = solutions.Select(s => s.GetStem()).ToArray();

            ////Remove problematic derivational stems, if they exist at the last
            //foreach (var stem in stems)
            //{
            //    foreach (var derivational in ProblematicDerivationals)
            //    {
            //        if (stem.LastSuffixEquals(derivational))
            //        {
            //            stem.RemoveLastSuffix();
            //            break;
            //        }    
            //    }                
            //}

            //return the longest stem
            return stems.OrderByDescending(x => x.GetSurface().Length).First();
        }
    }
}