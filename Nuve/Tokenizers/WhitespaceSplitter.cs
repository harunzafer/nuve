using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.Tokenizers
{
    /// <summary>
    /// This Split uses white spaces to tokenize the input text. Adjacent sequences of non-Whitespace characters form tokens. 
    /// </summary>
    class WhitespaceSplitter : RegexSplitter
    {
        public WhitespaceSplitter() : base(@"[^\p{L}]*\p{Z}[^\p{L}]*")
        {

        }

     
    }
}
