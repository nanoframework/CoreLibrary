//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

// The worker functions in this file was optimized for performance. If you make changes
// you should use care to consider all of the interesting cases.

// The code of all worker functions in this file is written twice: Once as as a slow loop, and the
// second time as a fast loop. The slow loops handles all special cases, throws exceptions, etc.
// The fast loops attempts to blaze through as fast as possible with optimistic range checks,
// processing multiple characters at a time, and falling back to the slow loop for all special cases.

// This define can be used to turn off the fast loops. Useful for finding whether
// the problem is fast-loop specific.
#define FASTLOOP

namespace System.Text
{
    using System;
    using Runtime.CompilerServices;
    // Encodes text into and out of UTF-8.  UTF-8 is a way of writing
    // Unicode characters with variable numbers of bytes per character,
    // optimized for the lower 127 ASCII characters.  It's an efficient way
    // of encoding US English in an internationalizable way.
    //
    // Don't override IsAlwaysNormalized because it is just a Unicode Transformation and could be confused.
    //
    // The UTF-8 byte order mark is simply the Unicode byte order mark
    // (0xFEFF) written in UTF-8 (0xEF 0xBB 0xBF).  The byte order mark is
    // used mostly to distinguish UTF-8 text from other encodings, and doesn't
    // switch the byte orderings.

    /// <summary>
    /// Represents a UTF-8 encoding of Unicode characters.
    /// </summary>
    public class UTF8Encoding : Encoding
    {

        //bytes   bits    UTF-8 representation
        //-----   ----    -----------------------------------
        //1        7      0vvvvvvv
        //2       11      110vvvvv 10vvvvvv
        //3       16      1110vvvv 10vvvvvv 10vvvvvv
        //4       21      11110vvv 10vvvvvv 10vvvvvv 10vvvvvv
        //-----   ----    -----------------------------------

        //Surrogate:
        //Real Unicode value = (HighSurrogate - 0xD800) * 0x400 + (LowSurrogate - 0xDC00) + 0x10000

        /// <summary>
        /// Represents a UTF-8 encoding of Unicode characters.
        /// </summary>
        public UTF8Encoding()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public override extern byte[] GetBytes(String s);
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// Encodes a set of characters from the specified <see cref="String"/> into the specified byte array.
        /// </summary>
        /// <param name="s">The <see cref="String"/> containing the set of characters to encode.</param>
        /// <param name="charIndex">The index of the first character to encode.</param>
        /// <param name="charCount">The number of characters to encode.</param>
        /// <param name="bytes">The byte array to contain the resulting sequence of bytes.</param>
        /// <param name="byteIndex">The index at which to start writing the resulting sequence of bytes.</param>
        /// <returns>The actual number of bytes written into <paramref name="bytes"/>.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public override extern int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex);
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// Decodes a sequence of bytes from the specified byte array into a set of characters.
        /// </summary>
        /// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
        /// <returns>The actual number of characters returned.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public override extern char[] GetChars(byte[] bytes);
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// Decodes a sequence of bytes from the specified byte array into a set of characters.
        /// </summary>
        /// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
        /// <param name="byteIndex">The index of the first byte to decode.</param>
        /// <param name="byteCount">The number of bytes to decode.</param>
        /// <returns>The actual number of characters returned.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public override extern char[] GetChars(byte[] bytes, int byteIndex, int byteCount);
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// Obtains a decoder that converts a UTF-8 encoded sequence of bytes into a sequence of Unicode characters.
        /// </summary>
        /// <returns>A decoder that converts a UTF-8 encoded sequence of bytes into a sequence of Unicode characters.</returns>
        public override Decoder GetDecoder()
        {
            return new UTF8Decoder();
        }
    }
}
