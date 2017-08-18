//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Runtime.CompilerServices;

    /// <summary>
    /// Represents the standard input, output, and error streams for console applications. This class cannot be inherited.
    /// </summary>
    [Serializable]
    public class Console
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern static private void OutNative(string text, bool addLineFeed);

        /// <summary>
        /// Writes the specified string value to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public static void Write(string value)
        {
            OutNative(value, false);
        }

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public static void WriteLine(string value)
        {
            OutNative(value, true);
        }
    }
}
