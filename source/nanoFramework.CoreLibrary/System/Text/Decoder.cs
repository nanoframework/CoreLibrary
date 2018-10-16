//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Text
{
    /// <summary>
    /// Converts a sequence of encoded bytes into a set of characters.
    /// </summary>
    public abstract class Decoder
    {
        /// <summary>
        /// Converts an array of encoded bytes to UTF-16 encoded characters and stores the result in a character array.
        /// </summary>
        /// <param name="bytes">A byte array to convert.</param>
        /// <param name="byteIndex">The first element of bytes to convert.</param>
        /// <param name="byteCount">The number of elements of bytes to convert.</param>
        /// <param name="chars">An array to store the converted characters.</param>
        /// <param name="charIndex">The first element of chars in which data is stored.</param>
        /// <param name="charCount">The maximum number of elements of chars to use in the conversion.</param>
        /// <param name="flush">true to indicate that no further data is to be converted; otherwise, false.</param>
        /// <param name="bytesUsed">When this method returns, contains the number of bytes that were used in the conversion. This parameter is passed uninitialized.</param>
        /// <param name="charsUsed">When this method returns, contains the number of characters from chars that were produced by the conversion. This parameter is passed uninitialized.</param>
        /// <param name="completed">When this method returns, contains true if all the characters specified by byteCount were converted; otherwise, false. This parameter is passed uninitialized.</param>
        public abstract void Convert(byte[] bytes, int byteIndex, int byteCount,
            char[] chars, int charIndex, int charCount, bool flush,
            out int bytesUsed, out int charsUsed, out bool completed);
    }
}
