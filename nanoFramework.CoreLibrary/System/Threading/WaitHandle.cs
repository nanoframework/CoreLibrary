//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Threading
{
    using Runtime.CompilerServices;
    using System;

    /// <summary>
    /// Encapsulates operating system�specific objects that wait for exclusive access to shared resources.
    /// </summary>
    public abstract class WaitHandle : MarshalByRefObject
    {
        /// <summary>
        /// Indicates that a WaitAny operation timed out before any of the wait handles were signaled. This field is constant.
        /// </summary>
        public const int WaitTimeout = 0x102;

        /// <summary>
        /// Blocks the current thread until the current WaitHandle receives a signal, using a 32-bit signed integer to specify the time interval and specifying whether to exit the synchronization domain before the wait.
        /// </summary>
        /// <param name="millisecondsTimeout">The number of milliseconds to wait, or Timeout.Infinite (-1) to wait indefinitely.</param>
        /// <param name="exitContext">true to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, false.</param>
        /// <returns>true if the current instance receives a signal; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern bool WaitOne(int millisecondsTimeout, bool exitContext);

        /// <summary>
        /// Blocks the current thread until the current WaitHandle receives a signal.
        /// </summary>
        /// <returns>true if the current instance receives a signal. If the current instance is never signaled, WaitOne never returns.</returns>
        public virtual bool WaitOne()
        {
            return WaitOne(Timeout.Infinite, false);
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern int WaitMultiple(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext, bool waitAll);

        /// <summary>
        /// Waits for all the elements in the specified array to receive a signal, using an Int32 value to specify the time interval and specifying whether to exit the synchronization domain before the wait.
        /// </summary>
        /// <param name="waitHandles">A WaitHandle array containing the objects for which the current instance will wait. This array cannot contain multiple references to the same object (duplicates).</param>
        /// <param name="millisecondsTimeout">The number of milliseconds to wait, or Timeout.Infinite (-1) to wait indefinitely.</param>
        /// <param name="exitContext">true to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, false.</param>
        /// <returns>true when every element in waitHandles has received a signal; otherwise, false.</returns>
        public static bool WaitAll(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext)
        {
            return WaitMultiple(waitHandles, millisecondsTimeout, exitContext, true /* waitall*/ ) != WaitTimeout;
        }

        /// <summary>
        /// Waits for all the elements in the specified array to receive a signal.
        /// </summary>
        /// <param name="waitHandles">A WaitHandle array containing the objects for which the current instance will wait. This array cannot contain multiple references to the same object.</param>
        /// <returns>true when every element in waitHandles has received a signal; otherwise the method never returns.</returns>
        public static bool WaitAll(WaitHandle[] waitHandles)
        {
            return WaitAll(waitHandles, Timeout.Infinite, true);
        }

        /// <summary>
        /// Waits for any of the elements in the specified array to receive a signal, using a 32-bit signed integer to specify the time interval, and specifying whether to exit the synchronization domain before the wait.
        /// </summary>
        /// <param name="waitHandles">A WaitHandle array containing the objects for which the current instance will wait.</param>
        /// <param name="millisecondsTimeout">The number of milliseconds to wait, or Timeout.Infinite (-1) to wait indefinitely.</param>
        /// <param name="exitContext">true to exit the synchronization domain for the context before the wait (if in a synchronized context), and reacquire it afterward; otherwise, false.</param>
        /// <returns>The array index of the object that satisfied the wait, or WaitTimeout if no object satisfied the wait and a time interval equivalent to millisecondsTimeout has passed.</returns>
        public static int WaitAny(WaitHandle[] waitHandles, int millisecondsTimeout, bool exitContext)
        {
            return WaitMultiple(waitHandles, millisecondsTimeout, exitContext, false /* waitany*/ );
        }

        /// <summary>
        /// Waits for any of the elements in the specified array to receive a signal.
        /// </summary>
        /// <param name="waitHandles">A WaitHandle array containing the objects for which the current instance will wait.</param>
        /// <returns>The array index of the object that satisfied the wait.</returns>
        public static int WaitAny(WaitHandle[] waitHandles)
        {
            return WaitAny(waitHandles, Timeout.Infinite, true);
        }
    }
}
