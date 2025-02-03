// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Threading
{
    using Runtime.CompilerServices;
    /// <summary>
    /// Notifies one or more waiting threads that an event has occurred. This class cannot be inherited.
    /// </summary>
    public sealed class ManualResetEvent : WaitHandle
    {
        /// <summary>
        /// Initializes a new instance of the ManualResetEvent class with a Boolean value indicating whether to set the initial state to signaled.
        /// </summary>
        /// <param name="initialState">true to set the initial state signaled; false to set the initial state to nonsignaled.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern ManualResetEvent(bool initialState);

        /// <summary>
        /// Sets the state of the event to nonsignaled, causing threads to block.
        /// </summary>
        /// <returns>true if the operation succeeds; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern bool Reset();

        /// <summary>
        /// Sets the state of the event to signaled, allowing one or more waiting threads to proceed.
        /// </summary>
        /// <returns>true if the operation succeeds; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern bool Set();
    }
}
