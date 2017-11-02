using System;

namespace rharel.M3PD.Common.Collections
{
    /// <summary>
    /// Extension methods for immutable collections.
    /// </summary>
    public static class ImmutableCollectionExtensions
    {
        /// <summary>
        /// Determines whether the specified collection is empty.
        /// </summary>
        /// <param name="collection">The collection to test.</param>
        /// <returns>True iff the specified collection is empty.</returns>
        /// <exception cref="ArgumentNullException">
        /// When <paramref name="collection"/> is null.
        /// </exception>
        public static bool IsEmpty(this ImmutableCollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            return collection.Count == 0;
        }
    }
}
