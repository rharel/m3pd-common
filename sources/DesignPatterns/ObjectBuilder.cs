using rharel.Functional;
using System;
using static rharel.Functional.Option;

namespace rharel.M3PD.Common.DesignPatterns
{
    /// <summary>
    /// Represents the builder design pattern for object creation.
    /// </summary>
    /// <typeparam name="T">The type of the built object.</typeparam>
    public abstract class ObjectBuilder<T>
    {
        /// <summary>
        /// Indicates whether the object is already built.
        /// </summary>
        public bool IsBuilt { get; private set; } = false;
        /// <summary>
        /// Gets the built object.
        /// </summary>
        public Optional<T> Object { get; private set; } = None<T>();

        /// <summary>
        /// Builds the object.
        /// </summary>
        /// <returns>The built object.</returns>
        /// <exception cref="InvalidOperationException">
        /// When calling this more than once per instance.
        /// </exception>
        public T Build()
        {
            if (IsBuilt)
            {
                throw new InvalidOperationException(
                    "Cannot build an already built object."
                );
            }

            Object = Some(CreateObject());
            IsBuilt = true;

            return Object.Unwrap();
        }

        /// <summary>
        /// Creates the object.
        /// </summary>
        /// <returns>The built object.</returns>
        protected abstract T CreateObject();
    }
}
