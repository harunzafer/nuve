using System.Collections.Generic;

namespace Nuve.Tokenizers
{
    internal interface ITokenizer
    {
        IList<string> Tokenize(string text);
    }
}