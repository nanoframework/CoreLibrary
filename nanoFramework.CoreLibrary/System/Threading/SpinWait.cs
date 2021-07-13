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
    /// Provides support for spin-based waiting.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="SpinWait"/> encapsulates common spinning logic. On single-processor machines, yields are
    /// always used instead of busy waits, and on computers with Intel™ processors employing Hyper-Threading™
    /// technology, it helps to prevent hardware thread starvation. SpinWait encapsulates a good mixture of
    /// spinning and true yielding.
    /// </para>
    /// <para>
    /// <see cref="SpinWait"/> is a value type, which means that low-level code can utilize SpinWait without
    /// fear of unnecessary allocation overheads. SpinWait is not generally useful for ordinary applications.
    /// In most cases, you should use the synchronization classes provided by the .NET Framework, such as
    /// <see cref="System.Threading.Monitor"/>. For most purposes where spin waiting is required, however,
    /// the <see cref="SpinWait"/> type should be preferred over the <see
    /// cref="Thread.SpinWait"/> method.
    /// </para>
    /// <para>
    /// While SpinWait is designed to be used in concurrent applications, it is not designed to be
    /// used from multiple threads concurrently.  SpinWait's members are not thread-safe.  If multiple
    /// threads must spin, each should use its own instance of SpinWait.
    /// </para>
    /// </remarks>
    public struct SpinWait
    {
        /// <summary>
        /// Performs a single spin.
        /// </summary>
        /// <remarks>
        /// This is typically called in a loop, and may change in behavior based on the number of times a
        /// <see cref="SpinOnce"/> has been called thus far on this instance.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void SpinOnce();

        /// <summary>
        /// Spins until the specified timeout is expired.
        /// </summary>
        /// <param name="timeout">
        /// A <see cref="TimeSpan"/> that represents the number of milliseconds to wait.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="timeout"/> is a negative number
        /// other than -1 milliseconds, which represents an infinite time-out 
        /// -or- timeout is greater than <see cref="Int32.MaxValue"/>.</exception>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SpinUntil(TimeSpan timeout);

        /// <summary>
        /// Spins until the specified timeout is expired.
        /// </summary>
        /// <param name="millisecondsTimeout">The number of milliseconds to wait.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="millisecondsTimeout"/> is a 
        /// negative number other than -1, which represents an infinite time-out.</exception>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void SpinUntil(int millisecondsTimeout);
    }
}
