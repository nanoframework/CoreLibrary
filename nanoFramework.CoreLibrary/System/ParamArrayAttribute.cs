// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Indicates that a method will allow a variable number of arguments in its invocation. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [ExcludeType]
    public sealed class ParamArrayAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the ParamArrayAttribute class with default properties.
        /// </summary>
        public ParamArrayAttribute() { }
    }
}
