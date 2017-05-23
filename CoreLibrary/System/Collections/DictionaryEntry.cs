//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Collections
{
    /// <summary>
    /// Defines a dictionary key/value pair that can be set or retrieved.
    /// </summary>
    public class DictionaryEntry
    {
        /// <summary>
        /// Gets or sets the key in the key/value pair.
        /// </summary>
        /// <returns>The key in the key/value pair.</returns>
        public Object Key;
        /// <summary>
        /// Gets or sets the value in the key/value pair.
        /// </summary>
        /// <returns>The value in the key/value pair.</returns>
        public Object Value;

        /// <summary>
        /// Initializes an instance of the DictionaryEntry type with the specified key and value.
        /// </summary>
        /// <param name="key">The object defined in each key/value pair.</param>
        /// <param name="value">The definition associated with key.</param>
        public DictionaryEntry(Object key, Object value)
        {
            Key = key;
            Value = value;
        }
    }
}
