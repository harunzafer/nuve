using System;
using System.Collections.Generic;

namespace Nuve.Sentence
{
    internal abstract class MockSentenceSegmenter : SentenceSegmenter
    {
        protected static Dictionary<string, IEnumerable<int>> Map;

        protected static int keyLength = 21;


        public override IEnumerable<int> GetBoundaryIndices(string paragraph)
        {
            int end = 0;
            if (paragraph.Length > keyLength)
            {
                end = keyLength;
            }
            else
            {
                end = paragraph.Length - 1;
            }
            IEnumerable<int> indices;
            if (!Map.TryGetValue(paragraph.Substring(0, end), out indices))
            {
                Console.WriteLine(paragraph.Substring(0, end));
                return null;
            }

            return indices;
        }
    }
}