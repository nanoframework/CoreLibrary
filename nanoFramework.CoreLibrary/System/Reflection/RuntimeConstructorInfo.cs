// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using System;
    using System.Runtime.CompilerServices;

    [Serializable]
    internal sealed class RuntimeConstructorInfo : ConstructorInfo
    {
        public override ParameterInfo[] GetParameters()
        {
            return GetParametersNative();
        }
    }
}

#endif // NANOCLR_REFLECTION
