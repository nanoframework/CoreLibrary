//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Runtime.CompilerServices;

    /// <summary>
    /// Controls the system garbage collector, a service that automatically reclaims unused memory.
    /// </summary>
    public static class GC
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool AnyPendingFinalizers();

        /// <summary>
        /// Suspends the current thread until the thread that is processing the queue of finalizers has emptied that queue.
        /// </summary>
        public static void WaitForPendingFinalizers()
        {
            while (AnyPendingFinalizers()) Threading.Thread.Sleep(10);
        }

        /// <summary>
        /// Requests that the system not call the finalizer for the specified object.
        /// </summary>
        /// <param name="obj">The object that a finalizer must not be called for. </param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SuppressFinalize(Object obj);

        /// <summary>
        /// Requests that the system call the finalizer for the specified object for which SuppressFinalize has previously been called.
        /// </summary>
        /// <param name="obj">The object that a finalizer must be called for. </param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void ReRegisterForFinalize(Object obj);

    }
}
