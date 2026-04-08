// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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

        public override ParameterInfo[] GetParameters()
        {
            return GetParametersNative();
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern object[] GetCustomAttributesNative(bool inherit);
    }
}

#endif // NANOCLR_REFLECTION
