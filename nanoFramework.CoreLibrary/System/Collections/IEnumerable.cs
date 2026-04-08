// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Collections
{
    /// <summary>
    /// Exposes an enumerator, which supports a simple iteration over a non-generic collection.
    /// </summary>
    public interface IEnumerable
    {
        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        IEnumerator GetEnumerator();
    }
}
