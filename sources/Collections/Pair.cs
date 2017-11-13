using rharel.M3PD.Common.Hashing;
using System.Collections;
using System.Collections.Generic;

namespace rharel.M3PD.Common.Collections
{
    /// <summary>
    /// Represents a pair of items.
    /// </summary>
    /// <remarks>
    /// See <see cref="Pair{T}"/> for the generic versions.
    /// </remarks>
    internal interface ObjectPair: IEnumerable
    {
        /// <summary>
        /// Gets the first item.
        /// </summary>
        object First { get; }
        /// <summary>
        /// Gets the second item.
        /// </summary>
        object Second { get; }
    }
    /// <summary>
    /// Represents a generic homogeneous pair.
    /// </summary>
    /// <typeparam name="T">The type of contained items.</typeparam>
    /// <remarks>
    /// See <see cref="ObjectPair"/> for the non-generic version.
    /// </remarks>
    public struct Pair<T> : ObjectPair, IEnumerable<T>
    {
        /// <summary>
        /// Creates a new pair.
        /// </summary>
        /// <param name="first">The first item.</param>
        /// <param name="second">The second item.</param>
        public Pair(T first, T second)
        {
            First = first;
            Second = second;
        }

        /// <summary>
        /// Gets the first item.
        /// </summary>
        public T First { get; }
        /// <summary>
        /// Gets the second item.
        /// </summary>
        public T Second { get; }

        /// <summary>
        /// Gets the first item.
        /// </summary>
        object ObjectPair.First => First;
        /// <summary>
        /// Gets the second item.
        /// </summary>
        object ObjectPair.Second => Second;

        /// <summary>
        /// Gets a generic enumerator over items.
        /// </summary>
        /// <returns>Generic enumerator over items.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            yield return First;
            yield return Second;
        }
        /// <summary>
        /// Gets a non-generic enumerator over items.
        /// </summary>
        /// <returns>Enumerator over items.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Determines whether the specified object is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>
        /// True iff the specified object is equal to this instance.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is ObjectPair other)
            {
                if (other.First is T other_first &&
                    other.Second is T other_second)
                {
                    return other_first.Equals(First) &&
                           other_second.Equals(Second);
                }
            }
            return false;
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
            int hash = HashCombiner.Initialize();
            hash = HashCombiner.Hash(hash, First);
            hash = HashCombiner.Hash(hash, Second);

            return hash;
        }

        /// <summary>
        /// Returns a string that represents this instance.
        /// </summary>
        /// <returns>A human-readable string.</returns>
        public override string ToString()
        {
            return $"{nameof(Pair<T>)}{{ " +
                   $"{nameof(First)} = {First}, " +
                   $"{nameof(Second)} = {Second} }}";
        }
    }
}
