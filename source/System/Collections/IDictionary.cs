//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Collections
{
    /// <summary>
    /// Represents a nongeneric collection of key/value pairs.
    /// </summary>
    public interface IDictionary : ICollection
    {
        /// <summary>
        /// Gets a value indicating whether the IDictionary object is read-only.
        /// </summary>
        /// <value>
        /// true if the IDictionary object is read-only; otherwise, false.
        /// </value>
        bool IsReadOnly { get; }
        /// <summary>
        /// Gets a value indicating whether the IDictionary object has a fixed size.
        /// </summary>
        /// <value>
        /// true if the IDictionary object has a fixed size; otherwise, false.
        /// </value>
        bool IsFixedSize { get; }
        /// <summary>
        /// Gets an ICollection object containing the keys of the IDictionary object.
        /// </summary>
        /// <value>
        /// An ICollection object containing the keys of the IDictionary object.
        /// </value>
        ICollection Keys { get; }
        /// <summary>
        /// Gets an ICollection object containing the values in the IDictionary object.
        /// </summary>
        /// <value>
        /// An ICollection object containing the values in the IDictionary object.
        /// </value>
        ICollection Values { get; }

        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        /// <param name="key">The key of the element to get or set.</param>
        /// <returns>The element with the specified key, or <see langword="null"/> if the key does not exist.</returns>
        object this[object key] { get; set; }

        /// <summary>
        /// Adds an element with the provided key and value to the IDictionary object.
        /// </summary>
        /// <param name="key">The Object to use as the key of the element to add.</param>
        /// <param name="value">The Object to use as the value of the element to add.</param>
        void Add(object key, object value);

        /// <summary>
        /// Removes all elements from the IDictionary object.
        /// </summary>
        void Clear();

        /// <summary>
        /// Determines whether the IDictionary object contains an element with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the IDictionary object.</param>
        /// <returns>true if the IDictionary contains an element with the key; otherwise, false.</returns>
        bool Contains(object key);

        /// <summary>
        /// Removes the element with the specified key from the IDictionary object.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        void Remove(object key);
    }
}
