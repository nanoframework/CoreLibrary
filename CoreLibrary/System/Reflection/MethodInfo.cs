//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Reflection
{
    using System;

    /// <summary>
    /// Discovers the attributes of a method and provides access to method metadata.
    /// </summary>
    [Serializable]
    public abstract class MethodInfo : MethodBase
    {
        /// <summary>
        /// Gets a MemberTypes value indicating that this member is a method.
        /// </summary>
        /// <value>
        /// A MemberTypes value indicating that this member is a method.
        /// </value>
        public override MemberTypes MemberType
        {
            get { return MemberTypes.Method; }
        }

        /// <summary>
        /// Gets the return type of this method.
        /// </summary>
        /// <value>
        /// The return type of this method.
        /// </value>
        /// <remarks>To get the return type property, first get the class Type. From the Type, get the MethodInfo. From the MethodInfo, get the ReturnType.</remarks>
        public abstract Type ReturnType
        {
            get;
        }
    }
}
