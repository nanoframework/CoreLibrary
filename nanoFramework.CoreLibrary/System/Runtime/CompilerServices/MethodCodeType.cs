// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// <para>Defines how a method is implemented.</para>
    /// <para>This enumeration supports a bitwise combination of its member values.</para>
    /// <para>This API supports the product infrastructure and is not intended to be used directly from your code.</para>
    /// </summary>
    public enum MethodCodeType
    {
        /// <summary>Specifies that the method implementation is in Microsoft intermediate language (MSIL).</summary>
        IL = MethodImplAttributes.IL,
        /// <summary>Specifies that the method is implemented in native code.</summary>
        Native = MethodImplAttributes.Native,
        /// <summary>Specifies that the method implementation is in optimized intermediate language (OPTIL).</summary>
        OPTIL = MethodImplAttributes.OPTIL,
        /// <summary>Specifies that the method implementation is provided by the runtime.</summary>
        Runtime = MethodImplAttributes.Runtime
    }
}