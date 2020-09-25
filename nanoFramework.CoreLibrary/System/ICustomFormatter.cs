//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System
{
    /// <summary>
    /// Defines a method that supports custom formatting of the value of an object.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    public interface ICustomFormatter
    {
        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A format string containing formatting specifications. </param>
        /// <param name="arg">An object to format. </param>
        /// <param name="formatProvider">An object that supplies format information about the current instance. </param>
        /// <returns>The string representation of the value of arg, formatted as specified by format and formatProvider.</returns>
        String Format(String format, Object arg, IFormatProvider formatProvider);

    }
}

#endif //NANOCLR_REFLECTION
