using System.Collections.Generic;

namespace rharel.M3PD.Common.Collections
{
    /// <summary>
    /// Represents an immutable view of a list.
    /// </summary>
    /// <typeparam name="T">The type of the list's items.</typeparam>
    public sealed class ListView<T>: CollectionView<T>, ImmutableList<T>
    {
        /// <summary>
        /// Creates a new view of the specified list.
        /// </summary>
        /// <param name="list">The list to observe.</param>
        /// <exception cref="ArgumentNullException">
        /// When <paramref name="list"/> is null.
        /// </exception>
        public ListView(IList<T> list): base(list)
        {
            _list = list;
        }

        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="index">The desired item's index.</param>
        /// <returns>The item at the specified index.</returns>
        object ImmutableList.this[int index] => this[index];
        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="index">The desired item's index.</param>
        /// <returns>The item at the specified index.</returns>
        public T this[int index]
        {
            get { return _list[index]; }
        }

        /// <summary>
        /// Determines the index of the specified item in this list.
        /// </summary>
        /// <param name="query">The item to index.</param>
        /// <returns>
        /// The index of the item's first occurrence if found, otherwise -1.
        /// </returns>
        public int IndexOf(object query)
        {
            if (query is T) { return IndexOf((T)query); }
            else            { return -1; }
        }
        /// <summary>
        /// Determines the index of the specified item in this list.
        /// </summary>
        /// <param name="query">The item to index.</param>
        /// <returns>
        /// The index of the item's first occurrence if found, otherwise -1.
        /// </returns>
        public int IndexOf(T query)
        {
            return _list.IndexOf(query);
        }

        /// <summary>
        /// Returns a string that represents this instance.
        /// </summary>
        /// <returns>
        /// A human-readable string.
        /// </returns>
        public override string ToString()
        {
            return $"{nameof(ListView<T>)}{{ " +
                   $"{nameof(Count)} = {Count} }}";
        }

        private readonly IList<T> _list;

    }
}
