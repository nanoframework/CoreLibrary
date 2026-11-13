// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Controls the system garbage collector, a service that automatically reclaims unused memory.
    /// </summary>
    public static class GC
    {
#pragma warning disable S4200 // Native methods should be wrapped

        /// <summary>
        /// Enables or disables the output of garbage collection messages.
        /// </summary>
        /// <param name="enable"><see langword="true"/> to enable the output of GC messages; otherwise, <see langword="false"/>.</param>
        /// <remarks>
        /// <para>
        /// Enabling GC messages may not always result in output, depending on the target build options.
        /// For example, RTM builds, which remove all non-essential features, may not output these messages.
        /// </para>
        /// <para>
        /// This method is specific of .NET nanoFramework implementation. There is no equivalent in full .NET API.
        /// </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void EnableGCMessages(bool enable);

        /// <summary>
        /// Retrieves the heap size excluding fragmentation. For example if the total GC heap size is 1MB and fragmentation, ie, space taken up by free objects, takes up 400kB, this API would report 600kB. A parameter indicates whether this method can wait a short interval before returning, to allow the system to collect garbage and finalize objects.
        /// </summary>
        /// <param name="forceFullCollection"><see langword="true"/> to indicate that this method can wait for garbage collection and heap compaction to occur before returning; otherwise, <see langword="false"/>.</param>
        /// <returns>The heap size, in bytes, excluding fragmentation.</returns>
        public static long GetTotalMemory(bool forceFullCollection) => Run(forceFullCollection);

        /// <summary>
        /// Requests that the system call the finalizer for the specified object for which <see cref="SuppressFinalize"/> has previously been called.
        /// </summary>
        /// <param name="obj">The object that a finalizer must be called for.</param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> is <see langword="null"/>.</exception>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void ReRegisterForFinalize(object obj);

        /// <summary>
        /// Forces an immediate garbage collection of all generations.
        /// </summary>
        /// <remarks>
        /// Use this method to try to reclaim all memory that is inaccessible. It performs a blocking garbage collection of all generations.
        /// All objects, regardless of how long they have been in memory, are considered for collection; however, objects that are referenced in managed code are not collected. Use this method to force the system to try to reclaim the maximum amount of available memory.
        /// </remarks>
        public static void Collect() => Run(true);

        /// <summary>
        /// Requests that the common language runtime not call the finalizer for the specified object.
        /// </summary>
        /// <param name="obj">The object whose finalizer must not be executed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="obj"/> is <see langword="null"/>.</exception>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SuppressFinalize(object obj);

        /// <summary>
        /// Suspends the current thread until the thread that is processing the queue of finalizers has emptied that queue.
        /// </summary>
        public static void WaitForPendingFinalizers()
        {
            while (AnyPendingFinalizers()) Threading.Thread.Sleep(10);
        }

#pragma warning restore S4200 // Native methods should be wrapped

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern bool AnyPendingFinalizers();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern uint Run(bool compactHeap);
    }
}
