using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.Tokenizers
{
    interface ITokenizer
    {
        IList<string> Tokenize(string text);
    }
}
