using System.Collections.Generic;

namespace Nuve.Sentence
{
    interface ISentenceBoundaryDetector
    {
        IEnumerable<int> GetBoundaryIndexes(string paragraph);
    }
}
