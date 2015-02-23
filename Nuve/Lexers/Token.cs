using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.Lexers
{
    class Token
    {
        public readonly string Type;
        public readonly string Value;

        public Token(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
