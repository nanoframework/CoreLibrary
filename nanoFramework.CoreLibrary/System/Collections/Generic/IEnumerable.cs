// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Collections.Generic
{
    /// <summary>
    /// Exposes the enumerator, which supports a simple iteration over a collection of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of objects to enumerate. This type parameter is covariant. That is, you can use either the type you specified or any type that is more derived.</typeparam>
    public interface IEnumerable<out T> : IEnumerable
        where T : allows ref struct
    {
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        new IEnumerator<T> GetEnumerator();
    }
}
