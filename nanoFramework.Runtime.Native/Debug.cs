//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Native
{
    /// <summary>
    /// Provides a set of methods and properties that help developers to debug code.
    /// </summary>
    public static class Debug
    {
        /// <summary>
        /// Runs GC (garbage collection), a service that automatically reclaims unused computer memory.
        /// </summary>
        /// <param name="force">true if garbage collection should be forced; otherwise, false.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static public uint GC(bool force);

        /// <summary>
        /// Specifies whether GC (garbage collection) messages are enabled.
        /// </summary>
        /// <param name="enable">true to enable output of messages; otherwise, false.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static public void EnableGCMessages(bool enable);

        //--//

        /// <summary>
        /// Causes a break in execution if the specified assertion (condition) evaluates to false.
        /// </summary>
        /// <param name="condition">The condition to be evaluated. If the value is false, program execution stops.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        static public void Assert(bool condition)
        {
            if (!condition)
            {
                Debugger.Break();
            }
        }

        /// <summary>
        /// Causes a break in execution if the specified assertion (condition) evaluates to false.
        /// </summary>
        /// <param name="condition">The condition to be evaluated. If the value is false, program execution stops.</param>
        /// <param name="message">The text to be output if the assertion is false.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        static public void Assert(bool condition, string message)
        {
            if (!condition)
            {
                Debugger.Break();
            }
        }

        /// <summary>
        /// Causes a break in execution if the specified assertion (condition) evaluates to false.
        /// </summary>
        /// <param name="condition">The condition to be evaluated. If the value is false, program execution stops.</param>
        /// <param name="message">The text to be output if the assertion is false.</param>
        /// <param name="detailedMessage">The detailed message to be displayed if the assertion is false.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        static public void Assert(bool condition, string message, string detailedMessage)
        {
            if (!condition)
            {
                Debugger.Break();
            }
        }
    }
}
