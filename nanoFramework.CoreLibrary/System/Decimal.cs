//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    // The System.Decimal class it's available only as a managed class. There is no native support for it.
    // It can be added to mscorlib to make the type available but it will throw a "type unavailable" exception during the type resolution stage if used.

    /// <summary>
    /// Represents a decimal number.
    /// </summary>
    [ComponentModel.EditorBrowsableAttribute(ComponentModel.EditorBrowsableState.Never)]
    public struct Decimal
    {
        /// <summary>
        /// Initializes a new instance of Decimal to the value of the specified 32-bit signed integer.
        /// </summary>
        /// <param name="value">The value to represent as a Decimal. </param>
        public Decimal(int value) { }

        /// <summary>
        /// Initializes a new instance of Decimal to the value of the specified 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">The value to represent as a Decimal. </param>
        [CLSCompliant(false)]
        public Decimal(uint value) { }

        /// <summary>
        /// Initializes a new instance of Decimal to the value of the specified 64-bit signed integer.
        /// </summary>
        /// <param name="value">The value to represent as a Decimal. </param>
        public Decimal(long value) { }

        /// <summary>
        /// Initializes a new instance of Decimal to the value of the specified 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">The value to represent as a Decimal. </param>
        [CLSCompliant(false)]
        public Decimal(ulong value) { }

        /// <summary>
        /// Initializes a new instance of Decimal to the value of the specified single-precision floating-point number.
        /// </summary>
        /// <param name="value">The value to represent as a Decimal. </param>
        public Decimal(float value) { }

        /// <summary>
        /// Initializes a new instance of Decimal to the value of the specified double-precision floating-point number.
        /// </summary>
        /// <param name="value">The value to represent as a Decimal. </param>
        public Decimal(double value) { }

        //internal Decimal(Currency value) { }

        /// <summary>
        /// Initializes a new instance of Decimal to a decimal value represented in binary and contained in a specified array.
        /// </summary>
        /// <param name="bits">An array of 32-bit signed integers containing a representation of a decimal value. </param>
        public Decimal(int[] bits) { }
        /// <summary>
        /// Initializes a new instance of Decimal from parameters specifying the instance's constituent parts.
        /// </summary>
        /// <param name="lo">The low 32 bits of a 96-bit integer. </param>
        /// <param name="mid">The middle 32 bits of a 96-bit integer. </param>
        /// <param name="hi">The high 32 bits of a 96-bit integer. </param>
        /// <param name="isNegative">The sign of the number; true is negative, false is positive.</param>
        /// <param name="scale">A power of 10 ranging from 0 to 28. </param>
        public Decimal(int lo, int mid, int hi, bool isNegative, byte scale) { }
    }
}
