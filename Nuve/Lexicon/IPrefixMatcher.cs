using System;
using System.Collections.Generic;

namespace Nuve.Lexicon
{
       public interface IPrefixMatcher<V> where V : class
    {
        /// <summary>
        /// Get the prefix entered so far.
        /// </summary>
        /// <returns>The prefix.</returns>
        String GetPrefix();

        /// <summary>
        /// Clear the currently entered prefix.
        /// </summary>
        void ResetMatch();

        /// <summary>
        /// Remove the last character of the currently entered prefix.
        /// </summary>
        void BackMatch();

        /// <summary>
        /// Get the last character of the currently entered prefix.
        /// </summary>
        /// <returns></returns>
        char LastMatch();

        /// <summary>
        /// AddSequence another character to the end of the prefix if new prefix is actually a prefix to some strings in the trie.
        /// If no strings have a matching prefix, character will not be added.
        /// </summary>
        /// <param name="next">Next character in the prefix.</param>
        /// <returns>True if the new prefix was a prefix to some strings in the trie, false otherwise.</returns>
        bool NextMatch(char next);

        /// <summary>
        /// Get all the corresponding values of the keys which have a prefix corresponding to the currently entered prefix.
        /// </summary>
        /// <returns>List of values.</returns>
        List<V> GetPrefixMatches();

        /// <summary>
        /// Check if the currently entered prefix is an existing string in the trie.
        /// </summary>
        /// <returns>True if the currently entered prefix is an existing string, false otherwise.</returns>
        bool IsExactMatch();

        /// <summary>
        /// Get the value mapped by the currently entered prefix.
        /// </summary>
        /// <returns>The value mapped by the currently entered prefix or null if current prefix does not map to any value.</returns>
        V GetExactMatch();
    }
}
