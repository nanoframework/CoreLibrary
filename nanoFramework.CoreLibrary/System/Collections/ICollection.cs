//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Collections
{
    using System;

    /// <summary>
    /// Defines size, enumerators, and synchronization methods for all nongeneric collections.
    /// </summary>
    public interface ICollection : IEnumerable
    {
        /// <summary>
        /// Copies the elements of the ICollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from ICollection. The Array must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        void CopyTo(Array array, int index);

        /// <summary>
        /// Gets the number of elements contained in the ICollection.
        /// </summary>
        /// <value>
        /// The number of elements contained in the ICollection.
        /// </value>
        int Count
        {
            get;
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the ICollection.
        /// </summary>
        /// <value>
        /// An object that can be used to synchronize access to the ICollection.
        /// </value>
        Object SyncRoot
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating whether access to the ICollection is synchronized (thread safe).
        /// </summary>
        /// <value>
        /// true if access to the ICollection is synchronized (thread safe); otherwise, false.
        /// </value>
        bool IsSynchronized
        {
            get;
        }
    }
}
