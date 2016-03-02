using System.Collections.Generic;

namespace Nuve.Sentence
{
    internal interface ISentenceBoundaryDetector
    {
        IEnumerable<int> GetBoundaryIndexes(string paragraph);
    }
}