// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using System;

    /// <summary>
    /// Discovers the attributes of a method and provides access to method metadata.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
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

        /// <summary>
        /// Substitutes the elements of an array of types for the type parameters of the current generic method definition, and returns a <see cref="MethodInfo"/> object representing the resulting constructed method.
        /// </summary>
        /// <param name="typeArguments">An array of types to be substituted for the type parameters of the current generic method definition.</param>
        /// <returns>A <see cref="MethodInfo"/> object that represents the constructed method formed by substituting the elements of <paramref name="typeArguments"/> for the type parameters of the current generic method definition.</returns>
        /// <exception cref="InvalidOperationException">The current <see cref="MethodInfo"/> does not represent a generic method definition.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="typeArguments"/> is <see langword="null"/>, or any element of <paramref name="typeArguments"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">The number of elements in <paramref name="typeArguments"/> is not the same as the number of type parameters of the current generic method definition, or an element of <paramref name="typeArguments"/> does not satisfy the constraints of the corresponding type parameter.</exception>
        public virtual MethodInfo MakeGenericMethod(params Type[] typeArguments)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Returns a <see cref="MethodInfo"/> object that represents a generic method definition from which the current method can be constructed.
        /// </summary>
        /// <returns>A <see cref="MethodInfo"/> object representing a generic method definition from which the current method can be constructed.</returns>
        /// <exception cref="InvalidOperationException">The current method is not a generic method. That is, <see cref="MethodBase.IsGenericMethod"/> returns <see langword="false"/>.</exception>
        public virtual MethodInfo GetGenericMethodDefinition()
        {
            throw new NotSupportedException();
        }
    }
}

#endif // NANOCLR_REFLECTION
