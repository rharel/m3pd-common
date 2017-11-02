namespace rharel.M3PD.Common.Hashing
{
    /// <summary>
    /// A helper class for the generation of a combined hash code made up of 
    /// multiple components.
    /// </summary>
    /// <example>
    /// <code>
    /// int hash = HashCombiner.Initialize();
    /// hash = HashCombiner.Hash(hash, "Hello world!");
    /// hash = HashCombiner.Hash(hash, 2.5f);
    /// ...
    /// return hash;
    /// </code>
    /// </example>
    public static class HashCombiner
    {
        /// <summary>
        /// Configures the combiner's parameters.
        /// </summary>
        /// <param name="seed">The initial seed.</param>
        /// <param name="factor">The multiplication factor.</param>
        /// <remarks>
        /// The combination algorithm used is dependent on two parameters: an
        /// initial seed and a multiplication factor. The seed is just a value
        /// yielded when calling <see cref="Initialize"/>. The factor is being 
        /// used to combine two existing hash-codes into one:
        /// <code>
        /// int first_hash = seed;
        /// int combined_hash = first_hash * factor + second_hash;
        /// </code>
        /// </remarks>
        public static void Configure(int seed, int factor)
        {
            _seed = seed;
            _factor = factor;
        }
        /// <summary>
        /// Yields a seeding value.
        /// </summary>
        /// <returns>The initial hash value.</returns>
        /// <remarks>
        /// The initial seed can be configured through 
        /// <see cref="Configure(int, int)"/> 
        /// </remarks>
        public static int Initialize()
        {
            return _seed;
        }
        /// <summary>
        /// Combines the specified value with the hash code of a given object.
        /// </summary>
        /// <param name="code">An existing hash code.</param>
        /// <param name="some_object">
        /// The object whose hash code should be combined with the existing 
        /// hash.
        /// </param>
        /// <returns>
        /// The combined hash of <paramref name="code"/> and 
        /// <paramref name="some_object"/>.
        /// </returns>
        /// <remarks>
        /// The hash code of the <c>null</c> object is considered to be equal 
        /// to zero.
        /// </remarks>
        public static int Hash(int code, object some_object)
        {
            unchecked
            {
                int combined_hash = code * _factor;

                if (some_object != null)
                {
                    combined_hash += some_object.GetHashCode();
                }

                return combined_hash;
            }
        }

        private static int _seed = 17;
        private static int _factor = 31;
    }
}
