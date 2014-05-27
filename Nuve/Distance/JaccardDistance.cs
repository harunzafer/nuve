using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NLPT.Distance
{
    /// <summary>
    /// Önce Jaccard benzerliğini bulup 1'den çıkararak uzaklığı elde ediyoruz.
    /// </summary>
    class JaccardDistance : IDistance
    {
        public double Measure(string s1, string s2)
        {
            if (s1 == "" || s2 =="")
            {
                return 0.0;
            }

            char[] u1 = s1.Distinct().ToArray();
            char[] u2 = s2.Distinct().ToArray();
            char[] intersect = u1.Intersect(u2).ToArray();
            char[] union = u1.Union(u2).ToArray();
            double similarity = intersect.Length / (double) union.Length;
            Debug.WriteLine(1-similarity);
            return 1 - similarity;
        }
    }
}
