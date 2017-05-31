//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Threading
{
    /// <summary>
    /// Contains constants that specify infinite time-out intervals. This class cannot be inherited.
    /// </summary>
    public static class Timeout
    {
        /// <summary>
        /// A constant used to specify an infinite waiting period, for threading methods that accept an Int32 parameter.
        /// </summary>
        /// <remarks>The value of this field is -1 (0xFFFFFFFF).</remarks>
        public const int Infinite = -1;
    }

}
