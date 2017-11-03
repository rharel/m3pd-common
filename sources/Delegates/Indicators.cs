namespace rharel.M3PD.Common.Delegates
{
    /// <summary>
    /// Indicates whether the specified item belongs to the specified set.
    /// </summary>
    /// <typeparam name="T">The type of the items to test.</typeparam>
    /// <param name="item">The item to test.</param>
    /// <returns>
    /// True iff the specified item belongs to the specified set.
    /// </returns>
    public delegate bool Indicator<T>(T item);
    /// <summary>
    /// Common indicators.
    /// </summary>
    /// <typeparam name="T">The type of the items to test.</typeparam>
    public static class Indicators<T>
    {
        /// <summary>
        /// Indicates the universe (complement of the empty set).
        /// </summary>
        public static readonly Indicator<T> All = item => true;
        /// <summary>
        /// Indicates the empty set.
        /// </summary>
        public static readonly Indicator<T> None = item => false;
    }
}
