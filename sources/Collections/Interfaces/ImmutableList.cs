namespace rharel.M3PD.Common.Collections
{
    /// <summary>
    /// Represents an immutable list.
    /// </summary>
    /// <remarks>
    /// <see cref="ImmutableList{T}"/> for the generic version.
    /// </remarks>
    public interface ImmutableList: ImmutableCollection
    {
        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="index">The desired item's index.</param>
        /// <returns>The item at the specified index.</returns>
        object this[int index] { get; }
        /// <summary>
        /// Determines the index of the specified item in this list.
        /// </summary>
        /// <param name="query">The item to index.</param>
        /// <returns>
        /// The index of the item's first occurrence if found, otherwise -1.
        /// </returns>
        int IndexOf(object query);
    }
    /// <summary>
    /// Represents an immutable list.
    /// </summary>
    /// <typeparam name="T">The type of the list's items.</typeparam>
    /// <remarks>
    /// <see cref="ImmutableList{T}"/> for the non-generic version.
    /// </remarks>
    public interface ImmutableList<T>: ImmutableList, ImmutableCollection<T>
    {
        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="index">The desired item's index.</param>
        /// <returns>The item at the specified index.</returns>
        new T this[int index] { get; }
        /// <summary>
        /// Determines the index of the specified item in this list.
        /// </summary>
        /// <param name="query">The item to index.</param>
        /// <returns>
        /// The index of the item's first occurrence if found, otherwise -1.
        /// </returns>
        int IndexOf(T query);
    }
}
