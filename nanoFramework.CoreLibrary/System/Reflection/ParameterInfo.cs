//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using Runtime.CompilerServices;
    using System;

    /// <summary>
    /// Discovers the attributes of a parameter and provides access to parameter metadata.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Serializable]
    public abstract class ParameterInfo
    {
#pragma warning disable S3459 // required to fill in in native code
        private readonly Type _parameterType;
#pragma warning restore S3459 // Unassigned members should be removed

        /// <summary>
        /// Gets the <see cref="Type"/> of this parameter.
        /// </summary>
        /// <value>The <see cref="Type"/> object that represents the <see cref="Type"/> of this parameter.</value>
        public virtual Type ParameterType => _parameterType;
    }
}

#endif // NANOCLR_REFLECTION
