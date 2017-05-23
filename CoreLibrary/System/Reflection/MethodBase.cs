//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Reflection
{
    using Runtime.CompilerServices;
    using System;

    /// <summary>
    /// Provides information about methods and constructors.
    /// </summary>
    [Serializable]
    public abstract class MethodBase : MemberInfo
    {
        /// <summary>
        /// Gets a value indicating whether this is a public method.
        /// </summary>
        /// <value>
        /// true if this method is public; otherwise, false.
        /// </value>
        public extern bool IsPublic
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the method is static.
        /// </summary>
        /// <value>
        /// true if this method is static; otherwise, false.
        /// </value>
        public extern bool IsStatic
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// GGets a value indicating whether the method is final.
        /// </summary>
        /// <value>
        ///  true if this method is final; otherwise, false.
        /// </value>
        public extern bool IsFinal
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the method is virtual 
        /// </summary>
        /// <value>
        /// true if this method is virtual; otherwise, false.
        /// </value>
        public extern bool IsVirtual
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the method is abstract
        /// </summary>
        /// <value>
        /// true if this method is abstract; otherwise, false.
        /// </value>
        public extern bool IsAbstract
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Invokes the method or constructor represented by the current instance, using the specified parameters.
        /// </summary>
        /// <param name="obj">The object on which to invoke the method or constructor. If a method is static, this argument is ignored. 
        /// If a constructor is static, this argument must be null or an instance of the class that defines the constructor.</param>
        /// <param name="parameters">An argument list for the invoked method or constructor. This is an array of objects with the same number, 
        /// order, and type as the parameters of the method or constructor to be invoked. If there are no parameters, parameters should be null.</param>
        /// <returns>An object containing the return value of the invoked method, or null in the case of a constructor.</returns>
        [Diagnostics.DebuggerStepThrough]
        [Diagnostics.DebuggerHidden]
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public extern Object Invoke(Object obj, Object[] parameters);

        /// <summary>
        /// Gets the name of the current member.
        /// </summary>
        /// <value>
        /// A String containing the name of this member.
        /// </value>
        public override extern String Name
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the class that declares this member.
        /// </summary>
        /// <value>
        /// The Type object for the class that declares this member.
        /// </value>
        public override extern Type DeclaringType
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }
    }
}


