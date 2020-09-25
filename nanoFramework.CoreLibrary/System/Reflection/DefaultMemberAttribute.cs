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
    /// Defines the member of a type that is the default member used by InvokeMember.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface), Serializable]
    public sealed class DefaultMemberAttribute : Attribute
    {
        private readonly String _memberName;

        // You must provide the name of the member, this is required
        /// <summary>
        /// Initializes a new instance of the DefaultMemberAttribute class.
        /// </summary>
        /// <param name="memberName">A String containing the name of the member to invoke. This may be a constructor, method, property, or field. 
        /// A suitable invocation attribute must be specified when the member is invoked. The default member of a class can be specified by passing an empty String as the name of the member.</param>
        public DefaultMemberAttribute(String memberName)
        {
            _memberName = memberName;
        }

        /// <summary>
        /// Gets the name from the attribute.
        /// </summary>
        /// <value>
        /// A string representing the member name.
        /// </value>
        public String MemberName
        {
            get { return _memberName; }
        }
    }
}

#endif // NANOCLR_REFLECTION
