// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using System;
    using Runtime.CompilerServices;

    /// <summary>
    /// Provides information about methods and constructors.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Serializable]
    public abstract class MethodBase : MemberInfo
    {
        // required to store native
        private int _token;

        /// <summary>
        /// Gets a value indicating whether this is a public method.
        /// </summary>
        /// <value>
        /// true if this method is public; otherwise, false.
        /// </value>
        public extern bool IsPublic
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
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
            [MethodImpl(MethodImplOptions.InternalCall)]
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
            [MethodImpl(MethodImplOptions.InternalCall)]
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
            [MethodImpl(MethodImplOptions.InternalCall)]
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
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// When overridden in a derived class, gets the parameters of the specified method or constructor.
        /// </summary>
        /// <returns>An array of type <see cref="ParameterInfo"/> containing information that matches the signature of the method (or constructor) reflected by this <see cref="MethodBase"/> instance.</returns>
        public abstract ParameterInfo[] GetParameters();

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
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern Object Invoke(Object obj, Object[] parameters);

        /// <summary>
        /// Gets the name of the current member.
        /// </summary>
        /// <value>
        /// A String containing the name of this member.
        /// </value>
        public override extern String Name
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
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
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern ParameterInfo[] GetParametersNative();
    }
}

#endif // NANOCLR_REFLECTION
