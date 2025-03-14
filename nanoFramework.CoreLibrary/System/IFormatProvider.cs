// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

namespace System
{
    /// <summary>
    /// Provides a mechanism for retrieving an object to control formatting.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    public interface IFormatProvider
    {
        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return. </param>
        /// <returns>An instance of the object specified by formatType, if the IFormatProvider implementation can supply that type of object; otherwise,  null reference (Nothing in Visual Basic).</returns>
        Object GetFormat(Type formatType);
    }
}

#endif // NANOCLR_REFLECTION

