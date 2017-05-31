//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Reflection
{
    using System;

    /// <summary>
    /// Obtains information about the attributes of a member and provides access to member metadata.
    /// </summary>
    [Serializable]
    public abstract class MemberInfo
    {
        /// <summary>
        /// When overridden in a derived class, gets a MemberTypes value indicating the type of the member — method, constructor, event, and so on.
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
    }
}
