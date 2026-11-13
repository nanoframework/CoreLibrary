// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Collections.Generic
{
    /// <summary>
    /// Supports a simple iteration over a generic collection.
    /// </summary>
    /// <typeparam name="T">
    /// The type of objects to enumerate. This type parameter is covariant. That is, you can use either the type you specified or any type that is more derived. 
    /// </typeparam>

    public interface IEnumerator<out T> : IDisposable, IEnumerator
        where T : allows ref struct
    {
        /// <summary>
        /// Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        /// <value>The element in the collection at the current position of the enumerator.</value>
        new T Current
        {
            get;
        }

        // NOTE: An implementation of an enumerator using a ref struct T will
        // not be able to implement IEnumerator.Current to return that T (as
        // doing so would require boxing). It should throw a NotSupportedException
        // from that property implementation.
    }
}
