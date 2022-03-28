//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

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
