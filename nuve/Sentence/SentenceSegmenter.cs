using System.Collections.Generic;
using System.Linq;
using Nuve.Orthographic;

namespace Nuve.Sentence
{
    public abstract class SentenceSegmenter
    {
        public static readonly char[] DefaultEosCandidates = {'.', '!', '?'};

        public SentenceSegmenter(char[] eosCandidates)
        {
            EosCandidates = eosCandidates;
        }

        public SentenceSegmenter()
        {
            EosCandidates = DefaultEosCandidates;
        }

        public char[] EosCandidates { private set; get; }

        protected void AddLastIndexAsSentenceBoundary(IList<int> indices, int lastIndex)
        {
            if (indices.Count != 0 && indices.Last() != lastIndex)
            {
                indices.Add(lastIndex);
            }
        }

        public IEnumerable<string> GetSentences(string paragraph)
        {
            IEnumerable<int> indexes = GetBoundaryIndices(paragraph);
            IList<string> sentences = new List<string>();
            int prevIndex = 0;
            foreach (int index in indexes)
            {
                string sentence = paragraph.SubstringJava(prevIndex, index + 1).Trim();
                sentences.Add(sentence);
                prevIndex = index + 1;
            }
            sentences.Add(paragraph.Substring(prevIndex).Trim());
            return sentences;
        }

        public abstract IEnumerable<int> GetBoundaryIndices(string paragraph);
    }
}