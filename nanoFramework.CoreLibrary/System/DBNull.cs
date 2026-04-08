// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Represents a nonexistent value. This class cannot be inherited.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ExcludeType]
    public sealed class DBNull
    {

        /// <summary>
        /// Represents the sole instance of the DBNull class.
        /// </summary>
        /// <remarks>DBNull is a singleton class, which means only this instance of this class can exist.</remarks>
        public static readonly DBNull Value = new DBNull();

        private DBNull() { }
    }
}
