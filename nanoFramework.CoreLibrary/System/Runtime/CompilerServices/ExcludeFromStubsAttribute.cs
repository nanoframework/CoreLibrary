﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// When a class, enum, or struct is marked with <see cref="ExcludeFromStubsAttribute"/> it will be excluded from the native stubs generated by .NET nanoFramework metadata processor.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class ExcludeFromStubsAttribute : Attribute
    {
    }
}
