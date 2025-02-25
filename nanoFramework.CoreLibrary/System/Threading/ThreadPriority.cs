// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Threading
{
    /// <summary>
    /// Specifies the scheduling priority of a Thread.
    /// </summary>
    [Serializable]
    public enum ThreadPriority
    {
        /// <summary>
        /// The Thread can be scheduled after threads with any other priority.
        /// </summary>
        Lowest = 0,
        /// <summary>
        /// The Thread can be scheduled after threads with Normal priority and before those with Lowest priority.
        /// </summary>
        BelowNormal = 1,
        /// <summary>
        /// The Thread can be scheduled after threads with AboveNormal priority and before those with BelowNormal priority. Threads have Normal priority by default.
        /// </summary>
        Normal = 2,
        /// <summary>
        /// The Thread can be scheduled after threads with Highest priority and before those with Normal priority.
        /// </summary>
        AboveNormal = 3,
        /// <summary>
        /// The Thread can be scheduled before threads with any other priority.
        /// </summary>
        Highest = 4

    }
}
