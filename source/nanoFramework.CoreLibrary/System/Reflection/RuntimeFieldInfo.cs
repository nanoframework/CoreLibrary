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
    internal sealed class RuntimeFieldInfo : FieldInfo
    {
        public override extern String Name
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public override extern Type DeclaringType
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public override extern Type FieldType
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern Object GetValue(Object obj);
    }
}
