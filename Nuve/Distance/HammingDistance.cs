using System;

namespace Nuve.Distance
{
    /// <summary>
    /// Manhattan distance ile aynı şey bu bağlamda
    /// Zira farklı her iki harf arasındaki uzaklığı aynı kabul ediyoruz.
    /// </summary>
    class HammingDistance : IDistance
    {
        public double Measure(string s1, string s2)
        {
            int diff = Math.Abs(s1.Length - s2.Length);

            for (int i = 0; i < s1.Length && i< s2.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    diff++;
                }
            }
            return diff;
        }
    }
}
