using System.Collections.Generic;

namespace Nuve.Tokenizers
{
    abstract class Splitter
    {
        public abstract IList<string> Split(string input);
    }
}
