//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

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
    }
}
