using System;

namespace Nuve.Distance
{
    /// <summary>
    /// Edit distance
    /// Yalnızca insert, delete, substitute işlemlerine izin verilen ve her işlemin maliteyi 1 olan edit 
    /// distance türüne Levenshtein uzaklığı denir.
    /// 
    /// </summary>
    class LevenshteinDistance : IDistance
    {
        private readonly bool _normalized;

        public LevenshteinDistance(bool normalized)
        {
            _normalized = normalized;
        }

        public LevenshteinDistance()
        {
            _normalized = false;
        }

        private int GetDistance(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length;
            int[,] d = new int[n + 1, m + 1];

            if (s1 == s2)
            {
                return 0;
            }

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++) { }

            for (int j = 0; j <= m; d[0, j] = j++) { }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (s2[j - 1] == s1[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
        public double Measure(string s1, string s2)
        {
            int distance = GetDistance(s1, s2);
            if (_normalized)
            {
                return normalize(s1.Length ,s2.Length, distance);
            }
            return distance;
        }

        public double normalize(int l1, int l2, int distance)
        {
            int max = Math.Max(l1, l2);
            return Math.Abs(distance - max)/(double) max;
        } 
    }
}
