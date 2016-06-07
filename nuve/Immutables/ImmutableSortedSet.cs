using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuve.Immutables
{
    internal class ImmutableSortedSet<T> : SortedSet<T>, ISet<T>
    {
        public ImmutableSortedSet(IEnumerable<T> collection) : base(collection)
        {
        }

        private const string Message = "Modifying the collection is not supported";


        public new bool Add(T item)
        {
            throw new NotSupportedException(Message);
        }

        public new void UnionWith(IEnumerable<T> other)
        {
            throw new NotSupportedException(Message);
        }

        public new void IntersectWith(IEnumerable<T> other)
        {
            throw new NotSupportedException(Message);
        }

        public new void ExceptWith(IEnumerable<T> other)
        {
            throw new NotSupportedException(Message);
        }

        public new void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotSupportedException(Message);
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotSupportedException(Message);
        }

        public new void Clear()
        {
            throw new NotSupportedException(Message);
        }

        public new bool Remove(T item)
        {
            throw new NotSupportedException(Message);
        }
    }
}
