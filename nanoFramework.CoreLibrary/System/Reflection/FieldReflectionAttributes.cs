// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [AttributeUsage(AttributeTargets.Field)]
    [ExcludeFromStubs]
    internal sealed class FieldNoReflectionAttribute : Attribute
    {
    }
}
