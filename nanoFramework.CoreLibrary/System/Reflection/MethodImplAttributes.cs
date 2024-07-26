// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Reflection
{
    /// <summary>
    /// <para>Specifies flags for the attributes of a method implementation.</para>
    /// <para>This enumeration supports a bitwise combination of its member values.</para>
    /// <para>This API supports the product infrastructure and is not intended to be used directly from your code.</para>
    /// </summary>
    public enum MethodImplAttributes
    {
        /// <summary>Specifies flags about code type.</summary>
        CodeTypeMask = 0x0003,
        /// <summary>Specifies that the method implementation is in Microsoft intermediate language (MSIL).</summary>
        IL = 0x0000,
        /// <summary>Specifies that the method implementation is native.</summary>
        Native = 0x0001,
        /// <summary>Specifies that the method implementation is in Optimized Intermediate Language (OPTIL).</summary>
        OPTIL = 0x0002,
        /// <summary>Specifies that the method implementation is provided by the runtime.</summary>
        Runtime = 0x0003,
        /// <summary>Specifies whether the method is implemented in managed or unmanaged code.</summary>
        ManagedMask = 0x0004,
        /// <summary>Specifies that the method is implemented in unmanaged code.</summary>
        Unmanaged = 0x0004,
        /// <summary>Specifies that the method is implemented in managed code.</summary>
        Managed = 0x0000,
        /// <summary>Specifies that the method is not defined.</summary>
        ForwardRef = 0x0010,
        /// <summary>Specifies that the method signature is exported exactly as declared.</summary>
        PreserveSig = 0x0080,
        /// <summary>Specifies an internal call.</summary>
        InternalCall = 0x1000,
        /// <summary>Specifies that the method is single-threaded through the body. Static methods (Shared in Visual Basic) lock on the type, whereas instance methods lock on the instance. You can also use the C# lock statement or the Visual Basic SyncLock statement for this purpose.</summary>
        Synchronized = 0x0020,
        /// <summary>Specifies that the method cannot be inlined.</summary>
        NoInlining = 0x0008,
        /// <summary>Specifies that the method should be inlined wherever possible.</summary>
        AggressiveInlining = 0x0100,
        /// <summary>Specifies that the method is not optimized by the just-in-time (JIT) compiler or by native code generation (see Ngen.exe) when debugging possible code generation problems.</summary>
        NoOptimization = 0x0040,
        /// <summary>Specifies that the method should be optimized whenever possible.</summary>
        AggressiveOptimization = 0x0200,
        /// <summary>Specifies a range check value.</summary>
        MaxMethodImplVal = 0xffff,
    }
}