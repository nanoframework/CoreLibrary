//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Provides the base class for enumerations.
    /// </summary>
    [Serializable]
    public abstract class Enum : ValueType
    {

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns>The string representation of the value of this instance.</returns>
        public override String ToString()
        {
            var type = GetType();
            var field = type.GetField("value__");
            var value = field.GetValue(this);

            return value.ToString();
        }

    }
}
