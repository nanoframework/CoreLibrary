//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Runtime.InteropServices
{
    /// <summary>
    /// Dictates which character set marshaled strings should use.
    /// </summary>
    [Serializable]
    public enum CharSet
    {
        /// <summary>
        /// This value is obsolete and has the same behavior as CharSet.Ansi.
        /// </summary>
        None = 1,
        /// <summary>
        /// Marshal strings as multiple-byte character strings.
        /// </summary>
        Ansi = 2,
        /// <summary>
        /// Marshal strings as Unicode 2-byte characters.
        /// </summary>
        Unicode = 3,
        /// <summary>
        /// Automatically marshal strings appropriately for the target operating system. The default is Unicode on Windows NT, Windows 2000, Windows XP, and the Windows Server 2003 family;
        /// the default is Ansi on Windows 98 and Windows Me. Although the common language runtime default is Auto, languages may override this default. 
        /// For example, by default C# marks all methods and types as Ansi.
        /// </summary>
        Auto = 4
    }
}
