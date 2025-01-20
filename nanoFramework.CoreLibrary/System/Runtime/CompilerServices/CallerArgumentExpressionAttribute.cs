// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// ReSharper disable ConvertToAutoProperty
namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Indicates that a parameter captures the expression passed for another parameter as a string.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public sealed class CallerArgumentExpressionAttribute : Attribute
    {
        private readonly string _parameterName;

        /// <summary>
        /// Initializes a new instance of the <see cref="CallerArgumentExpressionAttribute"/> class.
        /// </summary>
        /// <param name="parameterName">The name of the parameter whose expression should be captured as a string.</param>
        public CallerArgumentExpressionAttribute(string parameterName)
        {
            _parameterName = parameterName;
        }

        /// <summary>
        /// Gets the name of the parameter whose expression should be captured as a string.
        /// </summary>
        public string ParameterName => _parameterName;
    }
}
