// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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
        // Do not rename (binary serialization)
        private bool m_value;
#pragma warning restore 0649

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation (either "True" or "False").
        /// </summary>
        /// <returns>TrueString if the value of this instance is true, or FalseString if the value of this instance is false.</returns>
        public override String ToString()
        {
            return m_value ? TrueString : FalseString;
        }

    }
}
