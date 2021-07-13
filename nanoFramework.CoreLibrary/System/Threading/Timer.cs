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
    /// Represents the method that handles calls from a Timer.
    /// </summary>
    /// <param name="state"></param>
    public delegate void TimerCallback(Object state);

    /// <summary>
    /// Provides a mechanism for executing a method on a thread pool thread at specified intervals. This class cannot be inherited.
    /// </summary>
    public sealed class Timer : MarshalByRefObject, IDisposable
    {
        // these fields are required in the native end
#pragma warning disable 0169
        [Reflection.FieldNoReflection]
        private object _timer;
        private object _state;
        private TimerCallback _callback;
#pragma warning restore 0169

        /// <summary>
        /// Initializes a new instance of the Timer class, using a 32-bit signed integer to specify the time interval.
        /// </summary>
        /// <param name="callback">A TimerCallback delegate representing a method to be executed.</param>
        /// <param name="state">An object containing information to be used by the callback method, or null.</param>
        /// <param name="dueTime">The amount of time to delay before callback is invoked, in milliseconds. Specify Timeout.Infinite to prevent the timer from starting. Specify zero (0) to start the timer immediately.</param>
        /// <param name="period">The time interval between invocations of callback, in milliseconds. Specify Timeout.Infinite to disable periodic signaling.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern Timer(TimerCallback callback, Object state, int dueTime, int period);

        /// <summary>
        /// Initializes a new instance of the Timer class, using TimeSpan values to measure time intervals.
        /// </summary>
        /// <param name="callback">A delegate representing a method to be executed.</param>
        /// <param name="state">An object containing information to be used by the callback method, or null.</param>
        /// <param name="dueTime">The amount of time to delay before the callback parameter invokes its methods. Specify negative one (-1) milliseconds to prevent the timer from starting. Specify zero (0) to start the timer immediately.</param>
        /// <param name="period">The time interval between invocations of the methods referenced by callback. Specify negative one (-1) milliseconds to disable periodic signaling.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern Timer(TimerCallback callback, Object state, TimeSpan dueTime, TimeSpan period);

        /// <summary>
        /// Changes the start time and the interval between method invocations for a timer, using 32-bit signed integers to measure time intervals.
        /// </summary>
        /// <param name="dueTime">The amount of time to delay before the invoking the callback method specified when the Timer was constructed, in milliseconds. 
        /// Specify Timeout.Infinite to prevent the timer from restarting. Specify zero (0) to restart the timer immediately.</param>
        /// <param name="period">The time interval between invocations of the callback method specified when the Timer was constructed, in milliseconds. 
        /// Specify Timeout.Infinite to disable periodic signaling.</param>
        /// <returns>true if the timer was successfully updated; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern bool Change(int dueTime, int period);

        /// <summary>
        /// Changes the start time and the interval between method invocations for a timer, using TimeSpan values to measure time intervals.
        /// </summary>
        /// <param name="dueTime">A TimeSpan representing the amount of time to delay before invoking the callback method specified when the Timer was constructed. 
        /// Specify negative one (-1) milliseconds to prevent the timer from restarting. Specify zero (0) to restart the timer immediately.</param>
        /// <param name="period">The time interval between invocations of the callback method specified when the Timer was constructed. Specify negative one (-1) milliseconds to disable periodic signaling.</param>
        /// <returns>true if the timer was successfully updated; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern bool Change(TimeSpan dueTime, TimeSpan period);

        /// <summary>
        /// Releases all resources used by the current instance of Timer.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void Dispose();
    }
}


