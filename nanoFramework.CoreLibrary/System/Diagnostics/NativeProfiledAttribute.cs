// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System.Diagnostics
{
    /// <summary>
    /// Indicates that a method will profiled by the runtime, providing it has profiling capabilities enabled.
    /// </summary>
    /// <remarks>
    /// This attribute is exclusive to the .NET nanoFramework runtime and has no effect on other runtimes.
    /// </remarks>
    [ExcludeType]
    [DebuggerNonUserCode]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
    public sealed class NativeProfiledAttribute : Attribute
    { }
}
