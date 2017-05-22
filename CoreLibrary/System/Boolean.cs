//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Represents a Boolean value.
    /// </summary>
    [Serializable]
    public struct Boolean
    {
        /// <summary>
        /// Represents the Boolean value false as a string. This field is read-only.
        /// </summary>
        public static readonly string FalseString = "False";
        /// <summary>
        /// Represents the Boolean value true as a string. This field is read-only.
        /// </summary>
        public static readonly string TrueString = "True";

        private bool _value;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation (either "True" or "False").
        /// </summary>
        /// <returns>TrueString if the value of this instance is true, or FalseString if the value of this instance is false.</returns>
        public override String ToString()
        {
            return _value ? TrueString : FalseString;
        }

    }
}
