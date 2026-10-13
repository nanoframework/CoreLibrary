// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.InteropServices
{
    /// <summary>
    /// Specifies that a parameter is passed to a method by reference, but is not modified by the method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class InAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InAttribute"/> class.
        /// </summary>
        public InAttribute()
        {
        }
    }
}
