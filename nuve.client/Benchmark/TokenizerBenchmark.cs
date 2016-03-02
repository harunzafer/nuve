using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Nuve.Tokenizers;

namespace Nuve.Client.Benchmark
{
    internal class TokenizerBenchmark
    {
        private const string path = @"C:\Users\hrzafer\Dropbox\nuve\veri\tcNormalized.txt";

        public static void TestWithAMillionWords(ITokenizer tokenizer)
        {
            string text = File.ReadAllText(path, Encoding.UTF8);
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                tokenizer.Tokenize(text);
            }
            sw.Stop();
            Console.WriteLine("Time taken to tokenizer 85 MB text: {0}ms", sw.Elapsed.TotalMilliseconds);
            GC.Collect();
        }
    }
}