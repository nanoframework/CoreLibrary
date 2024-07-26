// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Specifies constants that define the details of how a method is implemented.
    /// </summary>
    [Flags]
    public enum MethodImplOptions
    {
        /// <summary>
        /// The method is implemented in unmanaged code.
        /// </summary>
        Unmanaged = 4,
        /// <summary>
        /// The method cannot be inlined. Inlining is an optimization by which a method call is replaced with the method body.
        /// </summary>
        NoInlining = 8,
        /// <summary>
        /// The method is declared, but its implementation is provided elsewhere.
        /// </summary>
        ForwardRef = 16, // 0x00000010
        /// <summary>
        /// The method can be executed by only one thread at a time. Static methods lock on the type, whereas instance methods lock on the instance. Only one thread can execute in any of the instance functions, and only one thread can execute in any of a class's static functions.
        /// </summary>
        Synchronized = 32, // 0x00000020
        /// <summary>
        /// The method is not optimized by the just-in-time (JIT) compiler or by native code generation (see Ngen.exe) when debugging possible code generation problems.
        /// </summary>
        NoOptimization = 64, // 0x00000040
        /// <summary>
        /// The method signature is exported exactly as declared.
        /// </summary>
        PreserveSig = 128, // 0x00000080
        /// <summary>
        ///   <para>The method should be inlined if possible.</para>
        ///   <para>Unnecessary use of this attribute can reduce performance. The attribute might cause implementation limits to be encountered that will result in slower generated code. Always measure performance to ensure it's helpful to apply this attribute.</para>
        /// </summary>
        AggressiveInlining = 256, // 0x00000100
        /// <summary>
        ///   <para>The method contains code that should always be optimized for performance.</para>
        ///   <para>It's rarely appropriate to use this attribute. Methods that apply this attribute bypass the first tier of tiered compilation and therefore don't benefit from optimizations that rely on tiered compilation. Those optimizations include dynamic PGO and optimizations based on initialized classes. Use of this attribute might also increase memory use. Always measure performance to ensure it's helpful to apply this attribute.</para>
        /// </summary>
        AggressiveOptimization = 512, // 0x00000200
        /// <summary>
        /// The call is internal, that is, it calls a method that's implemented within the common language runtime.
        /// </summary>
        InternalCall = 4096, // 0x00001000
    }
}
