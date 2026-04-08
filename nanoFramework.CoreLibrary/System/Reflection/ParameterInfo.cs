// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

namespace System.Reflection
{
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
