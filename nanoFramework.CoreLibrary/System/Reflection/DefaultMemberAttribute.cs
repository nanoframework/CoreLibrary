// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System.Reflection
{
    using System;

    /// <summary>
    /// Defines the member of a type that is the default member used by InvokeMember.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface)]
    [ExcludeType]
    [Serializable]
    public sealed class DefaultMemberAttribute : Attribute
    {
        // You must provide the name of the member, this is required
        /// <summary>
        /// Initializes a new instance of the DefaultMemberAttribute class.
        /// </summary>
        /// <param name="memberName">A String containing the name of the member to invoke. This may be a constructor, method, property, or field. 
        /// A suitable invocation attribute must be specified when the member is invoked. The default member of a class can be specified by passing an empty String as the name of the member.</param>
        public DefaultMemberAttribute(string memberName)
        {
            MemberName = memberName;
        }

        /// <summary>
        /// Gets the name from the attribute.
        /// </summary>
        /// <value>
        /// A string representing the member name.
        /// </value>
        public string MemberName { get; }
    }
}
