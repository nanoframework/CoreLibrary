//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Writes the specified data, followed by the current line terminator, to the standard output stream.
    /// </summary>
    /// <remarks>
    /// The default line terminator is a string whose value is a carriage return followed by a line feed ("\r\n" in C#, or vbCrLf in Visual Basic).
    /// In .NET nanoFramework this will write to Visual Studio Output window.
    /// </remarks>
    public static class Console
    {
        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <remarks>
        /// In .NET nanoFramework this will write to Visual Studio Output window.
        /// </remarks>
        public static void Write(string value) => Diagnostics.Debug.WriteLineNative(value, false);

        /// <summary>
        /// Writes the current line terminator to the standard output stream.
        /// </summary>
        /// <remarks>
        /// In .NET nanoFramework this will write to Visual Studio Output window.
        /// </remarks>
        public static void WriteLine() => Diagnostics.Debug.WriteLineNative(string.Empty, true);

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to the standard output stream.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <remarks>
        /// In .NET nanoFramework this will write to Visual Studio Output window.
        /// </remarks>
        public static void WriteLine(string value) => Diagnostics.Debug.WriteLineNative(value, true);
    }
}
