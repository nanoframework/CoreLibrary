// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Specifies the details of how a method is implemented. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
    public sealed class MethodImplAttribute : Attribute
    {
        /// <summary>
        /// A <see cref="CompilerServices.MethodCodeType"/> value indicating what kind of implementation is provided for this method.
        /// </summary>
        public MethodCodeType MethodCodeType;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodImplAttribute"/> class with the specified <see cref="MethodImplOptions"/> value.
        /// </summary>
        public MethodImplAttribute(MethodImplOptions methodImplOptions)
        {
            Value = methodImplOptions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodImplAttribute"/> class with the specified <see cref="MethodImplOptions"/> value.
        /// </summary>
        public MethodImplAttribute(short value)
        {
            Value = (MethodImplOptions)value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodImplAttribute"/> class.
        /// </summary>
        public MethodImplAttribute()
        {
        }

        /// <summary>
        /// Gets the <see cref="MethodImplOptions"/> value describing the attributed method
        /// </summary>
        public MethodImplOptions Value { get; }
    }
}