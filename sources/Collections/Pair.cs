using rharel.M3PD.Common.Hashing;
using System.Collections;
using System.Collections.Generic;

namespace rharel.M3PD.Common.Collections
{
    /// <summary>
    /// Represents a pair of items.
    /// </summary>
    /// <remarks>
    /// <see cref="Pair{T}"/> and <see cref="Pair{TFirst, TSecond}"/> for the 
    /// generic versions.
    /// </remarks>
    public interface Pair: IEnumerable
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
    /// <see cref="Pair"/> for the non-generic version.
    /// <see cref="Pair{TFirst, TSecond}"/> for the non-homogeneous version.
    /// </remarks>
    public struct Pair<T> : Pair, IEnumerable<T>
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
        object Pair.First => First;
        /// <summary>
        /// Gets the second item.
        /// </summary>
        object Pair.Second => Second;

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
            if (obj is Pair other)
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
    /// <summary>
    /// Represents a generic pair.
    /// </summary>
    /// <typeparam name="TFirst">The type of the first item.</typeparam>
    /// <typeparam name="TSecond">The type of the second item.</typeparam>
    /// <remarks>
    /// <see cref="Pair"/> for the non-generic version.
    /// <see cref="Pair{T}"/> for the homogeneous version.
    /// </remarks>
    public struct Pair<TFirst, TSecond>: Pair
    {
        /// <summary>
        /// Creates a new pair.
        /// </summary>
        /// <param name="first">The first item.</param>
        /// <param name="second">The second item.</param>
        public Pair(TFirst first, TSecond second)
        {
            First = first;
            Second = second;
        }

        /// <summary>
        /// Gets the first item.
        /// </summary>
        public TFirst First { get; }
        /// <summary>
        /// Gets the second item.
        /// </summary>
        public TSecond Second { get; }

        /// <summary>
        /// Gets the first item.
        /// </summary>
        object Pair.First => First;
        /// <summary>
        /// Gets the second item.
        /// </summary>
        object Pair.Second => Second;

        /// <summary>
        /// Gets a non-generic enumerator over items.
        /// </summary>
        /// <returns>Enumerator over items.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return ((Pair)this).First;
            yield return ((Pair)this).Second;
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
            if (obj is Pair other)
            {
                if (other.First is TFirst other_first &&
                    other.Second is TSecond other_second)
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
            return $"{nameof(Pair<TFirst, TSecond>)}{{ " +
                   $"{nameof(First)} = {First}, " +
                   $"{nameof(Second)} = {Second} }}";
        }
    }
}
