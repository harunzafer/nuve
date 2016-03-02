using System;
using System.IO;
using System.Linq;

namespace Nuve.Stemming
{
    internal static class StemmerEvaluator
    {
        private const string TestStems = "";

        public static void Evaluate(IStemmer stemmer, string testFile)
        {
            string[][] lines = File.ReadAllLines(testFile).Select(x => x.Split(null)).ToArray();
            int error = 0;
            foreach (var line in lines)
            {
                string stem = stemmer.GetStem(line[0]);

                if (stem != line[1])
                {
                    error++;
                    Console.WriteLine("[{3}] word:{0} expected:{1} actual:{2}", line[0], line[1], stem, error);
                }
            }

            double totalError = Math.Round(error/(double) lines.Length, 2);

            Console.WriteLine("Error:" + totalError);
        }
    }
}