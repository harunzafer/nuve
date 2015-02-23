using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Nuve.Tokenizers
{
    /// <summary>
    /// This Split splits the text field into tokens, treating whitespace and punctuation as delimiters. Delimiter characters are discarded, with the following exceptions:
    /// Periods (dots) that are not followed by whitespace are kept as part of the token, including Internet domain names.
    /// The "@" character is among the set of token-splitting punctuation, so email addresses are not preserved as single tokens.
    /// </summary>
    /// Whitespace, punct, letter,digit, other than that
    internal class StandartSplitter 
    {
        public IList<string> Split(string input)
        {
            IList<string> tokens = new List<string>();
            string token = "";
            
            for (int i = 0; i < input.Length; i ++)
            {
                if ((Char.IsWhiteSpace(input[i]) || i == input.Length-1) && token!="")
                {
                    tokens.Add(token);
                    token = "";
                }
                else if (!Char.IsWhiteSpace(input[i]))
                {
                    token += input[i];
                }
            }
            return tokens;
        }
    }
}