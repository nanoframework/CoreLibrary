//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

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
