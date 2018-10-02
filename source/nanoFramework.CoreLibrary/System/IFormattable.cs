//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System
{
    /// <summary>
    /// Provides functionality to format the value of an object into a string representation.
    /// </summary>
    public interface IFormattable
    {
        /// <summary>
        /// Formats the value of the current instance using the specified format.
        /// </summary>
        /// <param name="format">The format to use -or- A null reference(Nothing in Visual Basic) to use the default format defined for the type of the IFormattable implementation. </param>
        /// <param name="formatProvider">The provider to use to format the value -or- A null reference(Nothing in Visual Basic) to obtain the numeric format information from the current locale setting of the operating system. </param>
        /// <returns>The value of the current instance in the specified format.</returns>
        String ToString(String format, IFormatProvider formatProvider);
    }
}
