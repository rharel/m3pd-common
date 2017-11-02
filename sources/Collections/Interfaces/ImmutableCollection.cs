using System.Collections;
using System.Collections.Generic;

namespace rharel.M3PD.Common.Collections
{
    /// <summary>
    /// Represents an immutable collection. 
    /// </summary>
    /// <remarks>
    /// <see cref="ImmutableCollection{T}"/> for the generic version.
    /// </remarks>
    public interface ImmutableCollection: IEnumerable
    {
        /// <summary>
        /// Gets the item count.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Determines whether this collection contains the specified item.
        /// </summary>
        /// <param name="query">The item to search for.</param>
        /// <returns>
        /// True iff this collection contains the specified item.
        /// </returns>
        bool Contains(object query);
    }
    /// <summary>
    /// Represents an immutable collection. 
    /// </summary>
    /// <typeparam name="T">The type of the collection's items.</typeparam>
    /// <remarks>
    /// <see cref="ImmutableCollection"/> for the non-generic version.
    /// </remarks>
    public interface ImmutableCollection<T>: ImmutableCollection, 
                                             IEnumerable<T>
    {
        /// <summary>
        /// Determines whether this collection contains the specified item.
        /// </summary>
        /// <param name="query">The item to search for.</param>
        /// <returns>
        /// True iff this collection contains the specified item.
        /// </returns>
        bool Contains(T query);
    }
}
