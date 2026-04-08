// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

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

#endif // NANOCLR_REFLECTION
