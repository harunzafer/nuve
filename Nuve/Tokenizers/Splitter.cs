using System.Collections.Generic;

namespace Nuve.Tokenizers
{
    public abstract class Splitter
    {
        public abstract IList<string> Split(string input);
    }
}
