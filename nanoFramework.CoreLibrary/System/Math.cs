//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Runtime.CompilerServices;

    internal static class MathInternal
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Abs(int val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Min(int val1, int val2);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Max(int val1, int val2);
    }
}
