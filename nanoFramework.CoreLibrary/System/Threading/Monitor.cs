// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Threading
{
    using System;
    using Runtime.CompilerServices;

    /// <summary>
    /// Provides a mechanism that synchronizes access to objects.
    /// </summary>
    public static class Monitor
    {
        /// <summary>
        /// Acquires an exclusive lock on the specified object.
        /// </summary>
        /// <param name="obj">The object on which to acquire the monitor lock.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Enter(Object obj);

        /// <summary>
        /// Releases an exclusive lock on the specified object.
        /// </summary>
        /// <param name="obj">The object on which to release the lock.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Exit(Object obj);
    }
}
