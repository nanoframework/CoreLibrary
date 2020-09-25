//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Threading
{
    /// <summary>
    /// Specifies the execution states of a Thread.
    /// </summary>
    [Serializable, Flags]
    public enum ThreadState
    {
        /// <summary>
        /// The thread has been started, it is not blocked, and there is no pending ThreadAbortException.
        /// </summary>
        Running = 0,
        /// <summary>
        /// The thread is being requested to stop. This is for internal use only.
        /// </summary>
        StopRequested = 1,
        /// <summary>
        /// The thread is being requested to suspend.
        /// </summary>
        SuspendRequested = 2,
        /// <summary>
        /// The thread is being executed as a background thread, as opposed to a foreground thread. This state is controlled by setting the Thread.IsBackground property.
        /// </summary>
        Background = 4,
        /// <summary>
        /// The Thread.Start method has not been invoked on the thread.
        /// </summary>
        Unstarted = 8,
        /// <summary>
        /// The thread has stopped.
        /// </summary>
        Stopped = 16,
        /// <summary>
        /// The thread is blocked. This could be the result of calling Thread.Sleep or Thread.Join, of requesting a lock � for example, by calling Monitor.Enter 
        /// or Monitor.Wait � or of waiting on a thread synchronization object such as ManualResetEvent.
        /// </summary>
        WaitSleepJoin = 32,
        /// <summary>
        /// The thread has been suspended.
        /// </summary>
        Suspended = 64,
        /// <summary>
        /// The Thread.Abort method has been invoked on the thread, but the thread has not yet received the pending System.Threading.ThreadAbortException that will attempt to terminate it.
        /// </summary>
        AbortRequested = 128,
        /// <summary>
        /// The thread state includes AbortRequested and the thread is now dead, but its state has not yet changed to Stopped.
        /// </summary>
        Aborted = 256
    }
}
