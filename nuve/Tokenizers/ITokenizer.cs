using System.Collections.Generic;

namespace Nuve.Tokenizers
{
    public interface ITokenizer
    {
        IList<string> Tokenize(string text);
    }
}