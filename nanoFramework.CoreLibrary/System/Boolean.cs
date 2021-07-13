//
// Copyright (c) .NET Foundation and Contributors
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

        // this field is required in the native end
#pragma warning disable 0649
        private bool _value;
#pragma warning restore 0649

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
