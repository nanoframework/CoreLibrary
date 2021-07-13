//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Indicates the name by which an indexer is known in programming languages that do not support indexers directly.
    /// </summary>
    [Serializable, AttributeUsage(AttributeTargets.Property)]
    public sealed class IndexerNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the IndexerNameAttribute class.
        /// </summary>
        /// <param name="indexerName">The name of the indexer, as shown to other languages.</param>
        public IndexerNameAttribute(String indexerName)
        { }
    }
}
