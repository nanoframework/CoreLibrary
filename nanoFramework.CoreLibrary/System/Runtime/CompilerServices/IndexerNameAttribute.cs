// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Indicates the name by which an indexer is known in programming languages that do not support indexers directly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    [ExcludeType]
    [Serializable]
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
