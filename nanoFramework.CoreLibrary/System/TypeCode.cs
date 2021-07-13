//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System
{
    /// <summary>
    /// Specifies the type of an object.
    /// </summary>
    [Serializable]
    public enum TypeCode
    {
        /// <summary>
        /// A null reference.
        /// </summary>
        Empty = 0,          // Null reference
        /// <summary>
        /// A general type representing any reference or value type not explicitly represented by another TypeCode.
        /// </summary>
        Object = 1,         // Instance that isn't a value
        /// <summary>
        /// A database null (column) value.
        /// </summary>
        DBNull = 2,         // Database null value
        /// <summary>
        /// A simple type representing Boolean values of true or false.
        /// </summary>
        Boolean = 3,        // Boolean
        /// <summary>
        /// An integral type representing unsigned 16-bit integers with values between 0 and 65535. The set of possible values for the Char type corresponds to the Unicode character set.
        /// </summary>
        Char = 4,           // Unicode character
        /// <summary>
        /// An integral type representing signed 8-bit integers with values between -128 and 127.
        /// </summary>
        SByte = 5,          // Signed 8-bit integer
        /// <summary>
        /// An integral type representing unsigned 8-bit integers with values between 0 and 255.
        /// </summary>
        Byte = 6,           // Unsigned 8-bit integer
        /// <summary>
        /// An integral type representing signed 16-bit integers with values between -32768 and 32767.
        /// </summary>
        Int16 = 7,          // Signed 16-bit integer
        /// <summary>
        /// An integral type representing unsigned 16-bit integers with values between 0 and 65535.
        /// </summary>
        UInt16 = 8,         // Unsigned 16-bit integer
        /// <summary>
        /// An integral type representing signed 32-bit integers with values between -2147483648 and 2147483647.
        /// </summary>
        Int32 = 9,          // Signed 32-bit integer
        /// <summary>
        /// An integral type representing unsigned 32-bit integers with values between 0 and 4294967295.
        /// </summary>
        UInt32 = 10,        // Unsigned 32-bit integer
        /// <summary>
        /// An integral type representing signed 64-bit integers with values between -9223372036854775808 and 9223372036854775807.
        /// </summary>
        Int64 = 11,         // Signed 64-bit integer
        /// <summary>
        /// An integral type representing unsigned 64-bit integers with values between 0 and 18446744073709551615.
        /// </summary>
        UInt64 = 12,        // Unsigned 64-bit integer
        /// <summary>
        /// A floating point type representing values ranging from approximately 1.5 x 10 -45 to 3.4 x 10 38 with a precision of 7 digits.
        /// </summary>
        Single = 13,        // IEEE 32-bit float
        /// <summary>
        /// A floating point type representing values ranging from approximately 5.0 x 10 -324 to 1.7 x 10 308 with a precision of 15-16 digits.
        /// </summary>
        Double = 14,        // IEEE 64-bit double
        /// <summary>
        /// A simple type representing values ranging from 1.0 x 10 -28 to approximately 7.9 x 10 28 with 28-29 significant digits.
        /// </summary>
        Decimal = 15,       // Decimal
        /// <summary>
        /// A type representing a date and time value.
        /// </summary>
        DateTime = 16,      // DateTime
        /// <summary>
        /// A sealed class type representing Unicode character strings.
        /// </summary>
        String = 18,        // Unicode character string
    }
}
