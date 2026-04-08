// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices
{
    /// <summary>
    /// Dictates which character set marshaled strings should use.
    /// </summary>
    [ExcludeType]
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
