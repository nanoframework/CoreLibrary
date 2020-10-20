//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Threading
{
    using Runtime.CompilerServices;
    /// <summary>
    /// Notifies a waiting thread that an event has occurred. This class cannot be inherited.
    /// </summary>
    public sealed class AutoResetEvent : WaitHandle
    {
        /// <summary>
        /// Initializes a new instance of the AutoResetEvent class with a Boolean value indicating whether to set the initial state to signaled.
        /// </summary>
        /// <param name="initialState">true to set the initial state to signaled; false to set the initial state to non-signaled.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern AutoResetEvent(bool initialState);

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
