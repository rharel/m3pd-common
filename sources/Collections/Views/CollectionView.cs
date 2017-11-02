using System;
using System.Collections;
using System.Collections.Generic;

namespace rharel.M3PD.Common.Collections
{
    /// <summary>
    /// Represents an immutable view of a collection.
    /// </summary>
    /// <typeparam name="T">The type of the collection's items.</typeparam>
    public class CollectionView<T>: ImmutableCollection<T>
    {
        /// <summary>
        /// Creates a new view of the specified collection.
        /// </summary>
        /// <param name="collection">The collection to observe.</param>
        /// <exception cref="ArgumentNullException">
        /// When <paramref name="collection"/> is null.
        /// </exception>
        public CollectionView(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            Collection = collection;
        }

        /// <summary>
        /// Gets the item count.
        /// </summary>
        public int Count
        {
            get { return Collection.Count; }
        }

        /// <summary>
        /// Determines whether this collection contains the specified item.
        /// </summary>
        /// <param name="query">The item to search for.</param>
        /// <returns>
        /// True iff this collection contains the specified item.
        /// </returns>
        public bool Contains(object query)
        {
            return query is T && Contains((T)query);
        }
        /// <summary>
        /// Determines whether this collection contains the specified item.
        /// </summary>
        /// <param name="query">The item to search for.</param>
        /// <returns>
        /// True iff this collection contains the specified item.
        /// </returns>
        public bool Contains(T query)
        {
            return Collection.Contains(query);
        }

        /// <summary>
        /// Gets a generic enumerator over items.
        /// </summary>
        /// <returns>Generic enumerator over items.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
        /// <summary>
        /// Gets a non-generic enumerator over items.
        /// </summary>
        /// <returns>Enumerator over items.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Collection).GetEnumerator();
        }

        /// <summary>
        /// Determines whether the specified object is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>
        /// True if the specified object is equal to this instance; 
        /// otherwise false.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as CollectionView<T>;

            if (ReferenceEquals(other, null)) { return false; }
            if (ReferenceEquals(other, this)) { return true; }

            return other.Collection.Equals(Collection);
        }
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing 
        /// algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Collection.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents this instance.
        /// </summary>
        /// <returns>
        /// A human-readable string.
        /// </returns>
        public override string ToString()
        {
            return $"{nameof(CollectionView<T>)}{{ " +
                   $"{nameof(Count)} = {Count} }}";
        }

        /// <summary>
        /// Gets the observed collection.
        /// </summary>
        protected ICollection<T> Collection { get; }
    }
}
