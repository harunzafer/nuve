using System;
using System.Collections.Generic;

namespace Nuve.Lexers
{
    internal interface ILexer
    {
        IList<Token> Lex(String input);
    }
}