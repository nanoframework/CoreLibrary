//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Diagnostics
{
    /// <summary>
    /// Indicates to compilers that a method call or attribute should be ignored unless a specified conditional compilation symbol is defined.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true), Serializable]
    public sealed class ConditionalAttribute : Attribute
    {
        private readonly String _conditionString;

        /// <summary>
        /// Initializes a new instance of the ConditionalAttribute class.
        /// </summary>
        /// <param name="conditionString">A string that specifies the case-sensitive conditional compilation symbol that is associated with the attribute.</param>
        public ConditionalAttribute(String conditionString)
        {
            _conditionString = conditionString;
        }

        /// <summary>
        /// Gets the conditional compilation symbol that is associated with the ConditionalAttribute attribute.
        /// </summary>
        /// <value>A string that specifies the case-sensitive conditional compilation symbol that is associated with the ConditionalAttribute attribute.</value>
        public String ConditionString
        {
            get
            {
                return _conditionString;
            }
        }


    }
}
