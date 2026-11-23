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

        /// <summary>
        /// Gets a value indicating whether the method is generic.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the current <see cref="MethodBase"/> represents a generic method; otherwise, <see langword="false"/>.
        /// </value>
        public virtual bool IsGenericMethod => GetGenericFlags().HasFlag(GenericMethodFlags.GenericMethod);

        /// <summary>
        /// Gets a value indicating whether the method is a generic method definition.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the current <see cref="MethodBase"/> object represents the definition of a generic method; otherwise, <see langword="false"/>.
        /// </value>
        public virtual bool IsGenericMethodDefinition => GetGenericFlags().HasFlag(GenericMethodFlags.GenericMethodDefinition);

        /// <summary>
        /// Gets a value indicating whether the generic method contains unassigned generic type parameters.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the current <see cref="MethodBase"/> object represents a generic method that contains unassigned generic type parameters, or is declared by an open generic type; otherwise, <see langword="false"/>.
        /// </value>
        public virtual bool ContainsGenericParameters => GetGenericFlags().HasFlag(GenericMethodFlags.ContainsGenericParameters);

        /// <summary>
        /// Returns an array of <see cref="Type"/> objects that represent the type arguments of a generic method or the type parameters of a generic method definition.
        /// </summary>
        /// <returns>An array of <see cref="Type"/> objects that represent the type arguments of a generic method or the type parameters of a generic method definition. Returns an empty array if the current method is not a generic method.</returns>
        /// <exception cref="NotSupportedException">The current object is a <see cref="ConstructorInfo"/>.</exception>
        public virtual Type[] GetGenericArguments()
        {
            throw new NotSupportedException();
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern ParameterInfo[] GetParametersNative();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern GenericMethodFlags GetGenericFlags();

        [Flags]
        private enum GenericMethodFlags
        {
            None = 0,
            GenericMethod = 1,
            GenericMethodDefinition = 2,
            ContainsGenericParameters = 4,
        }
    }
}

#endif // NANOCLR_REFLECTION
