using System;
using System.Collections.Generic;

namespace Nuve.Lexicon
{
    /// <summary>
    /// Search through a trie for all the strings which have a given prefix which will be entered character by character.
    /// </summary>
    /// <typeparam name="V">Order of the value stored in the trie.</typeparam>
    class PrefixMatcher<V> : IPrefixMatcher<V> where V : class
    {

        private TrieNode<V> root;

        private TrieNode<V> currMatch;

        private string prefixMatched;

        /// <summary>
        /// Create a matcher, associating it to the trie to search in.
        /// </summary>
        /// <param name="root">Root node of the trie which the matcher will search in.</param>
        public PrefixMatcher(TrieNode<V> root)
        {
            this.root = root;
            this.currMatch = root;
        }

        /// <inheritdoc/>
        public String GetPrefix()
        {
            return prefixMatched;
        }

        /// <inheritdoc/>
        public void ResetMatch()
        {
            currMatch = root;
            prefixMatched = "";
        }

        /// <inheritdoc/>
        public void BackMatch()
        {
            if (currMatch != root)
            {
                currMatch = currMatch.Parent;
                prefixMatched = prefixMatched.Substring(0, prefixMatched.Length - 1);
            }
        }

        /// <inheritdoc/>
        public char LastMatch()
        {
            return currMatch.Key;
        }

        /// <inheritdoc/>
        public bool NextMatch(char next)
        {
            if (currMatch.ContainsKey(next))
            {
                currMatch = currMatch.GetChild(next);
                prefixMatched += next;
                return true;
            }
            return false;
        }

        /// <inheritdoc/>
        public List<V> GetPrefixMatches()
        {
            return currMatch.PrefixMatches();
        }

        /// <inheritdoc/>
        public bool IsExactMatch()
        {
            return currMatch.IsTerminater();
        }

        /// <inheritdoc/>
        public V GetExactMatch()
        {
            return IsExactMatch() ? currMatch.Value : null;
        }

    }
}