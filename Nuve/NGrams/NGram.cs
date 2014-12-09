using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuve.NGrams
{
    /// <summary>
    /// Represents an n-gram object which consists of n tokens.
    /// </summary>
    public class NGram
    {
        private readonly IList<string> tokens;

        public NGram(IList<string> tokens)
        {
            this.tokens = tokens;
        }

        public NGram(params string[] tokens)
        {
            this.tokens = tokens;
        }        

        public IEnumerable<string> Tokens
        {
            get { return tokens; }
        }

        private bool Equals(NGram other)
        {
            return Tokens.SequenceEqual(other.Tokens);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NGram) obj);
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int hash = 19;
            foreach (var token in tokens)
            {
                hash += hash * prime + token.GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            string str = "";
            string prefix = "";
            foreach (var token in Tokens)
            {
                str += prefix + token;
                prefix = " ";
            }
            return str;
        }
    }
}
