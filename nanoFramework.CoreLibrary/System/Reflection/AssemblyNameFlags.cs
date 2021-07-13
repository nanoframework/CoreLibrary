//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using System;
    /// <summary>
    /// Provides information about an Assembly reference.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Serializable, FlagsAttribute]
    public enum AssemblyNameFlags
    {
        /// <summary>
        /// Specifies that no flags are in effect.
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// Specifies that a public key is formed from the full public key rather than the public key token.
        /// </summary>
        PublicKey = 0x0001,
        /// <summary>
        /// Specifies that just-in-time (JIT) compiler optimization is disabled for the assembly. This is the exact opposite of the meaning that is suggested by the member name.
        /// </summary>
        EnableJITcompileOptimizer = 0x4000,
        /// <summary>
        /// Specifies that just-in-time (JIT) compiler tracking is enabled for the assembly.
        /// </summary>
        EnableJITcompileTracking = 0x8000,
        /// <summary>
        /// Specifies that the assembly can be retargeted at runtime to an assembly from a different publisher. This value supports the .NET Framework infrastructure and is not intended to be used directly from your code.
        /// </summary>
        Retargetable = 0x0100,

    }

    /// <summary>
    /// Identifies the processor and bits-per-word of the platform targeted by an executable.
    /// </summary>
    [Serializable]
    public enum ProcessorArchitecture
    {
        /// <summary>
        /// An unknown or unspecified combination of processor and bits-per-word.
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// Neutral with respect to processor and bits-per-word.
        /// </summary>
        MSIL = 0x0001,
        /// <summary>
        /// A 32-bit Intel processor, either native or in the Windows on Windows environment on a 64-bit platform (WOW64).
        /// </summary>
        X86 = 0x0002,
        /// <summary>
        /// A 64-bit Intel processor only.
        /// </summary>
        IA64 = 0x0003,
        /// <summary>
        /// A 64-bit AMD processor only.
        /// </summary>
        Amd64 = 0x0004
    }
}

#endif // NANOCLR_REFLECTION
