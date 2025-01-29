//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Indicates that a method will allow a variable number of arguments in its invocation. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [ExcludeFromStubs]
    public sealed class ParamArrayAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the ParamArrayAttribute class with default properties.
        /// </summary>
        public ParamArrayAttribute() { }
    }
}
