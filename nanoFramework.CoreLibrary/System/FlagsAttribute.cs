// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Indicates that an enumeration can be treated as a bit field; that is, a set of flags.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    [ExcludeFromStubs]
    [Serializable]
    public class FlagsAttribute : Attribute
    {
    }
}
