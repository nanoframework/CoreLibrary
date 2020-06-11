//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using System;
    using Runtime.CompilerServices;

    [Serializable]
    internal sealed class RuntimeMethodInfo : MethodInfo
    {
        public override extern Type ReturnType
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public override object[] GetCustomAttributes(bool inherit)
        {
            return CustomAttributesHelpers.GetCustomAttributesInternal(GetCustomAttributesNative(inherit));
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        private extern object[] GetCustomAttributesNative(bool inherit);
#pragma warning restore S4200 // Native methods should be wrapped
    }
}

#endif // NANOCLR_REFLECTION
