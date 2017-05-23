//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

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
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern void Enter(Object obj);

        /// <summary>
        /// Releases an exclusive lock on the specified object.
        /// </summary>
        /// <param name="obj">The object on which to release the lock.</param>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public static extern void Exit(Object obj);
    }
}


