//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#define ENABLE_CROSS_APPDOMAIN

namespace System.Globalization
{
    /// <summary>
    /// Defines the types of culture lists that can be retrieved using the CultureInfo.GetCultures method.
    /// </summary>
    public enum CultureTypes
    {
        /// <summary>
        /// All cultures that ship with the .NET Framework, including neutral and specific cultures, cultures installed in the Windows operating system, and custom cultures created by the user.
        /// CultureTypes.AllCultures is a composite field that includes the CultureTypes.NeutralCultures, CultureTypes.SpecificCultures, and CultureTypes.InstalledWin32Cultures values.
        /// </summary>
        AllCultures,
        /// <summary>
        /// Obsolete. This member is deprecated; using this value with CultureInfo.GetCultures returns neutral and specific cultures shipped with the .NET Framework 2.0.
        /// </summary>
        FrameworkCultures,
        /// <summary>
        /// All cultures that are installed in the Windows operating system. Note that not all cultures supported by the .NET Framework are installed in the operating system.
        /// </summary>
        InstalledWin32Cultures,
        /// <summary>
        /// Cultures that are associated with a language but are not specific to a country/region. The names of .NET Framework cultures consist of the lowercase two-letter code derived from ISO 639-1. For example: "en" (English) is a neutral culture.
        /// </summary>
        NeutralCultures,
        /// <summary>
        /// Custom cultures created by the user that replace cultures shipped with the .NET Framework.
        /// </summary>
        ReplacementCultures,
        /// <summary>
        /// Cultures that are specific to a country/region. The names of these cultures follow RFC 4646 (Windows Vista and later).
        /// </summary>
        SpecificCultures,
        /// <summary>
        /// Custom cultures created by the user.
        /// </summary>
        UserCustomCulture,
        /// <summary>
        /// Obsolete. This member is deprecated. If it is used as an argument to the CultureInfo.GetCultures method, the method returns an empty array.
        /// </summary>
        WindowsOnlyCultures
    }
}
