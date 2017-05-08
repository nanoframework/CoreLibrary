//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Globalization;

    //
    // Wrapper for unsigned 32 bit integers.
    //
    [Serializable, CLSCompliant(false)]
    public struct UInt32
    {
        private uint m_value;

        public const uint MaxValue = (uint)0xffffffff;
        public const uint MinValue = 0U;

        public override String ToString()
        {
            return Number.Format(m_value, true, "G", NumberFormatInfo.CurrentInfo);
        }

        public String ToString(String format)
        {
            return Number.Format(m_value, true, format, NumberFormatInfo.CurrentInfo);
        }

        [CLSCompliant(false)]
        public static uint Parse(String s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            return Convert.ToUInt32(s);
        }

    }
}
