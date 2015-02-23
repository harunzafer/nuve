using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.Lexers
{
    interface ILexer
    {
        IList<Token> Lex(String input);
    }
}
