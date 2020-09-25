//
// Copyright (c) .NET Foundation and Contributors
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
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public static extern void Enter(Object obj);
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// Releases an exclusive lock on the specified object.
        /// </summary>
        /// <param name="obj">The object on which to release the lock.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public static extern void Exit(Object obj);
#pragma warning restore S4200 // Native methods should be wrapped
    }
}
