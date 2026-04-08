// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    using Runtime.CompilerServices;

    internal static class MathInternal
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Abs(int val);

        /// <summary>
        /// Returns the larger of two 32-bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 32-bit signed integers to compare. </param>
        /// <param name="val2">The second of two 32-bit signed integers to compare. </param>
        /// <returns>Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is larger.</returns>
        internal static int Max(int val1, int val2)
        {
            return (val1 >= val2) ? val1 : val2;
        }

        /// <summary>
        /// Returns the smaller of two 32-bit signed integers.
        /// </summary>
        /// <param name="val1">The first of two 32-bit signed integers to compare. </param>
        /// <param name="val2">The second of two 32-bit signed integers to compare. </param>
        /// <returns>Parameter <paramref name="val1"/> or <paramref name="val2"/>, whichever is smaller.</returns>
        internal static int Min(int val1, int val2)
        {
            return (val2 >= val1) ? val1 : val2;
        }
    }
}
