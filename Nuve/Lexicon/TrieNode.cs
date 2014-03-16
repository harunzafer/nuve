using System;
using System.Collections.Generic;

namespace Nuve.Lexicon
{
    /// <summary>
    /// Node of the trie.
    /// Stores a link to multiple children of Order TrieNode each associated with a key of Order Char.
    /// If the node terminates a string then it must also store a non-null value of Order V.
    /// </summary>
    /// <typeparam name="V">Value associated with a character.</typeparam>
    class TrieNode<V> where V : class
    {

        /// <summary>
        /// The value stored by this node. If not null then the node terminates a string.
        /// </summary>
        public V Value { get; set; }

        /// <summary>
        /// Get the key which was associated with this node.
        /// </summary>
        public Char Key { get; private set; }

        /// <summary>
        /// Get the parent of this node.
        /// </summary>
        public TrieNode<V> Parent { get; private set; }

        private Dictionary<Char, TrieNode<V>> children;

        /// <summary>
        /// Create an empty node with no children and null value.
        /// </summary>
        /// <param name="parent">Parent node of this node.</param>
        public TrieNode(TrieNode<V> parent, Char key)
        {
            this.Key = key;
            this.Value = null;
            this.Parent = parent;
            this.children = new Dictionary<Char, TrieNode<V>>();
        }

        /// <summary>
        /// Get a child of this node which is associated with a key.
        /// </summary>
        /// <param name="key">Key associated with the child of interest.</param>
        /// <returns>The child or null if no child is associated with the given key.</returns>
        public TrieNode<V> GetChild(char key)
        {
            if (children.ContainsKey(key))
            {
                return children[key];
            }
            return null;
        }

        /// <summary>
        /// Check whether or not this node terminates a string and stores a value.
        /// </summary>
        /// <returns>Whether node stores a value.</returns>
        public bool IsTerminater()
        {
            return Value != null;
        }

        /// <summary>
        /// Get the number of children this node has.
        /// </summary>
        /// <returns>Number of children.</returns>
        public int NumChildren()
        {
            return children.Count;
        }

        /// <summary>
        /// Check whether or not this node has any children.
        /// </summary>
        /// <returns>True if node does not have children, false otherwise.</returns>
        public bool IsLeaf()
        {
            return NumChildren() == 0;
        }

        /// <summary>
        /// Check whether or not one of the children of this node uses the given key.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>True if a child with given key exists, false otherwise.</returns>
        public bool ContainsKey(char key)
        {
            return children.ContainsKey(key);
        }

        /// <summary>
        /// Add a child node associated with a key to this node and return the node.
        /// </summary>
        /// <param name="key">Key to associated with the child node.</param>
        /// <returns>If given key already exists then return the existing child node, else return the new child node.</returns>
        public TrieNode<V> AddChild(char key)
        {
            if (children.ContainsKey(key))
            {
                return children[key];
            }
            else
            {
                TrieNode<V> newChild = new TrieNode<V>(this, key);
                children.Add(key, newChild);
                return newChild;
            }
        }

        /// <summary>
        /// Remove the child of a node associated with a key along with all its descendents.
        /// </summary>
        /// <param name="key">The key associated with the child to remove.</param>
        public void RemoveChild(char key)
        {
            children.Remove(key);
        }

        /// <summary>
        /// Get a list of values contained in this node and all its descendants.
        /// </summary>
        /// <returns>A List of values.</returns>
        public List<V> PrefixMatches()
        {
            if (IsLeaf())
            {
                if (IsTerminater())
                {
                    return new List<V>(new V[] { Value });
                }
                else
                {
                    return new List<V>();
                }
            }
            else
            {
                List<V> values = new List<V>();
                foreach (TrieNode<V> node in children.Values)
                {
                    values.AddRange(node.PrefixMatches());
                }

                if (IsTerminater())
                {
                    values.Add(Value);
                }

                return values;
            }
        }

    }
}