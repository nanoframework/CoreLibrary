//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Threading
{
    /// <summary>
    /// Contains constants that specify infinite time-out intervals. This class cannot be inherited.
    /// </summary>
    public static class Timeout
    {
        /// <summary>
        /// A constant used to specify an infinite waiting period, for threading methods that accept an Int32 parameter.
        /// </summary>
        /// <remarks>The value of this field is -1 (0xFFFFFFFF).</remarks>
        public const int Infinite = -1;

        /// <summary>
        /// A constant used to specify an infinite waiting period, for methods that accept a <see cref="TimeSpan"/> parameter.
        /// </summary>
        /// <remarks>
        /// For threading methods that accept a timeout parameter of type <see cref="TimeSpan"/>, such as <see cref="Thread.Sleep(TimeSpan)"/> and <see cref="Thread.Join(TimeSpan)"/>, this value is used to suspend the thread indefinitely. However, in most cases, we recommend that you use other <see cref="System.Threading"/> classes such as <see cref="AutoResetEvent"/>, <see cref="ManualResetEvent"/>, <see cref="Monitor"/> or <see cref="WaitHandle"/> instead to synchronize threads or manage resources. 
        /// The value of this field is -00:00:00.0010000, or -1 millisecond.
        /// </remarks>
        public static readonly TimeSpan InfiniteTimeSpan = new TimeSpan(0, 0, 0, 0, Infinite);
    }
}
