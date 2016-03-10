using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.Orthographic.SearchReplace
{
    class SearchReplaceRule
    {
        public string Old { get; }
        public string New { get; }

        public SearchReplaceRule(string old, string @new)
        {
            Old = old;
            New = @new;
        }

        public string Replace(string token)
        {
            return token.Replace(Old, New);
        }
    }
}
