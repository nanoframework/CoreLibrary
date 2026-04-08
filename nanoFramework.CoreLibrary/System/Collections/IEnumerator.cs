// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Collections
{
    using System;

    /// <summary>
    /// Supports a simple iteration over a non-generic collection.
    /// </summary>
    public interface IEnumerator
    {
        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
        bool MoveNext();

        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <value>
        /// The element in the collection at the current position of the enumerator.
        /// </value>
        Object Current
        {
            get;
        }

        /// <summary>
        /// Sets the enumerator to its initial position, which is before the first element in the collection.
        /// </summary>
        void Reset();
    }
}
