//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Reflection
{
    using System;

    /// <summary>
    /// Specifies flags for the attributes of a method implementation.
    /// </summary>
    [Serializable]
    public enum MethodImplAttributes
    {
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies flags about code type.
        /// </summary>
        CodeTypeMask = 0x0003,
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method implementation is in Microsoft intermediate language (MSIL).
        /// </summary>
        IL = 0x0000,
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method implementation is native.
        /// </summary>
        Native = 0x0001,

        // <internalonly/>
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method implementation is in Optimized Intermediate Language (OPTIL).
        /// </summary>
        OPTIL = 0x0002,
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method implementation is provided by the runtime.
        /// </summary>
        Runtime = 0x0003,

        // managed mask
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies whether the method is implemented in managed or unmanaged code.
        /// </summary>
        ManagedMask = 0x0004,
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method is implemented in unmanaged code.
        /// </summary>
        Unmanaged = 0x0004,
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method is implemented in managed code.
        /// </summary>
        Managed = 0x0000,
        // end managed mask

        // implementation info and interop
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method is not defined.
        /// </summary>
        ForwardRef = 0x0010,
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method signature is exported exactly as declared.
        /// </summary>
        PreserveSig = 0x0080,

        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies an internal call.
        /// </summary>
        InternalCall = 0x1000,

        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method is single-threaded through the body. 
        /// Static methods (Shared in Visual Basic) lock on the type, whereas instance methods lock on the instance. You can also use the C# lock statement or the Visual Basic 
        /// SyncLock statement for this purpose.
        /// </summary>
        Synchronized = 0x0020,
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method cannot be inlined.
        /// </summary>
        NoInlining = 0x0008,

        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies a range check value.
        /// </summary>
        MaxMethodImplVal = 0xFFFF
    }
}
