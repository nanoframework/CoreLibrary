// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Defines APIs to determine whether specific features are supported by the common language runtime.
    /// </summary>
    public static partial class RuntimeFeature
    {
        /// <summary>
        /// Indicates that this version of runtime supports default interface method implementations.
        /// </summary>
        public const string DefaultImplementationsOfInterfaces = nameof(DefaultImplementationsOfInterfaces);

        /// <summary>
        /// Checks whether a certain feature is supported by the Runtime.
        /// </summary>
        public static bool IsSupported(string feature)
        {
            if (feature == DefaultImplementationsOfInterfaces)
            {
                return true;
            }

            return false;
        }
    }
}
