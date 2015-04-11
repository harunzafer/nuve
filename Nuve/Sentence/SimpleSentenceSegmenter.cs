using System.Collections.Generic;
using System.Linq;

namespace Nuve.Sentence
{
    internal class SimpleSentenceSegmenter : SentenceSegmenter
    {
        public SimpleSentenceSegmenter(char[] eosCandidates) : base(eosCandidates)
        {
        }

        public SimpleSentenceSegmenter()
        {
        }

        public override IEnumerable<int> GetBoundaryIndices(string paragraph)
        {
            IList<int> indices = new List<int>();
            for (int i = 0; i < paragraph.Length; i++)
            {
                if (EosCandidates.Contains(paragraph[i]))
                {
                    indices.Add(i);
                }
            }

            AddLastIndexAsSentenceBoundary(indices, paragraph.Length - 1);

            return indices;
        }
    }
}