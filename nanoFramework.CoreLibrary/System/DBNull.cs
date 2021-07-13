//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Represents a nonexistent value. This class cannot be inherited.
    /// </summary>
    [ComponentModel.EditorBrowsableAttribute(ComponentModel.EditorBrowsableState.Never)]
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
