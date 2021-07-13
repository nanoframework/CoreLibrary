//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Represents a character as a UTF-16 code unit.
    /// </summary>
    [Serializable]
    public struct Char
    {
        // this field is required in the native end
#pragma warning disable 0649
        private char _value;
#pragma warning restore 0649

        /// <summary>
        /// Represents the largest possible value of a Char. This field is constant.
        /// </summary>
        public const char MaxValue = (char)0xFFFF;
        /// <summary>
        /// Represents the smallest possible value of a Char. This field is constant.
        /// </summary>
        public const char MinValue = (char)0x00;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public override String ToString()
        {
            return new String(_value, 1);
        }

        /// <summary>
        /// Returns the lower case character.
        /// </summary>
        /// <returns>The lower case character.</returns>
        public char ToLower()
        {
            if ('A' <= _value && _value <= 'Z')
            {
                return (char)(_value - ('A' - 'a'));
            }

            return _value;
        }

        /// <summary>
        /// Returns the upper case character.
        /// </summary>
        /// <returns>The upper case character.</returns>
        public char ToUpper()
        {
            if ('a' <= _value && _value <= 'z')
            {
                return (char)(_value + ('A' - 'a'));
            }

            return _value;
        }
    }
}
