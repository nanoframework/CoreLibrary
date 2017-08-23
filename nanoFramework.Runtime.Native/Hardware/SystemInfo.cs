//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace nanoFramework.Runtime.Hardware
{
    /// <summary>
    /// Provides information about the system.
    /// </summary>
    public static class SystemInfo
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        extern private static void GetSystemVersion(out int major, out int minor, out int build, out int revision);

        /// <summary>
        /// Gets a string containing version information about this system. 
        /// </summary>
        public static Version Version
        {
            get
            {
                int major, minor, build, revision;

                GetSystemVersion(out major, out minor, out build, out revision);

                return new Version(major, minor, build, revision);
            }
        }

        /// <summary>
        /// Gets a string that contains information provided by the equipment manufacturer (OEM) about this system.
        /// </summary>
        extern public static String OEMString
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value that represents an original equipment manufacturer (OEM).
        /// </summary>
        extern static public byte OEM
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value that represents a product model.
        /// </summary>
        extern static public byte Model
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value that represents a product's stock-keeping unit (SKU).
        /// </summary>
        extern static public ushort SKU
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }
    }
}
