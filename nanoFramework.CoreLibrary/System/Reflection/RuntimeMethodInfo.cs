//
// Copyright (c) .NET Foundation and Contributors
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
        private extern object[] GetCustomAttributesNative(bool inherit);
    }
}

#endif // NANOCLR_REFLECTION
