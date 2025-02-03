// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System.Diagnostics
{
    /// <summary>
    /// Enables communication with a debugger. This class cannot be inherited.
    /// </summary>
    public static class Debugger
    {
        /// <summary>
        /// Gets a value that indicates whether a debugger is attached to the process.
        /// </summary>
        /// <value>true if a debugger is attached; otherwise, false.</value>
        public static extern bool IsAttached
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Signals a breakpoint to an attached debugger.
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Break();
    }
}
