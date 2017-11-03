namespace rharel.M3PD.Common.Delegates
{
    /// <summary>
    /// A predicate.
    /// </summary>
    public delegate bool Predicate();
    /// <summary>
    /// Common predicates.
    /// </summary>
    public static class Predicates
    {
        /// <summary>
        /// Always evaluates to true.
        /// </summary>
        public static readonly Predicate Always = () => true;
        /// <summary>
        /// Never evaluates to true.
        /// </summary>
        public static readonly Predicate Never = () => false;
    }
}
