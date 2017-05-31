//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace System.Text
{
    internal class UTF8Decoder : Decoder
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern void Convert(byte[] bytes, int byteIndex, int byteCount,
            char[] chars, int charIndex, int charCount, bool flush,
            out int bytesUsed, out int charsUsed, out bool completed);
    }
}
