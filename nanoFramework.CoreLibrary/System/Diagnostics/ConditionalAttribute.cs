// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System.Diagnostics
{
    /// <summary>
    /// Indicates to compilers that a method call or attribute should be ignored unless a specified conditional compilation symbol is defined.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    [ExcludeType]
    [Serializable]
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
