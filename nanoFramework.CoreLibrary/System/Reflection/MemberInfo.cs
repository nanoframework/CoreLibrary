//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using System;

    /// <summary>
    /// Obtains information about the attributes of a member and provides access to member metadata.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Serializable]
    public abstract class MemberInfo
    {
        /// <summary>
        /// When overridden in a derived class, gets a MemberTypes value indicating the type of the member � method, constructor, event, and so on.
        /// </summary>
        /// <value>
        /// A MemberTypes value indicating the type of member.
        /// </value>
        public abstract MemberTypes MemberType
        {
            get;
        }

        /// <summary>
        /// Gets the name of the current member.
        /// </summary>
        /// <value>
        /// A String containing the name of this member.
        /// </value>
        public abstract String Name
        {
            get;
        }

        /// <summary>
        /// Gets the class that declares this member.
        /// </summary>
        /// <value>
        /// The Type object for the class that declares this member.
        /// </value>
        public abstract Type DeclaringType
        {
            get;
        }

        /// <summary>
        /// When overridden in a derived class, returns an array of all custom attributes applied to this member.
        /// </summary>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events.</param>
        /// <returns>An array that contains all the custom attributes applied to this member, or an array with zero elements if no attributes are defined.</returns>
        public abstract object[] GetCustomAttributes(bool inherit);
    }
}

#endif // NANOCLR_REFLECTION
