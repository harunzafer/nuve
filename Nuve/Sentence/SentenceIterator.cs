using System.Collections;
using System.Collections.Generic;
using Nuve.Orthographic;

namespace Nuve.Sentence
{
    class SentenceIterator: IEnumerable<string>
    {
        private readonly string _paragraph;
        private readonly SentenceSegmenter _segmenter;
        
        public SentenceIterator(SentenceSegmenter segmenter, string paragraph)
        {
            _paragraph = paragraph;
            _segmenter = segmenter;
        }

        public IEnumerator<string> GetEnumerator()
        {
            IEnumerable<int> indexes = _segmenter.GetBoundaryIndices(_paragraph);
            int prevIndex = 0;
            foreach (int index in indexes)
            {
                yield return _paragraph.SubstringJava(prevIndex, index + 1).Trim();
                prevIndex = index + 1;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
