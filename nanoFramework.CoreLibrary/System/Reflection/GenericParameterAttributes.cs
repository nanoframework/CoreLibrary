// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    /// <summary>
    /// Describes the constraints on a generic type parameter of a generic type or method.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Flags]
    public enum GenericParameterAttributes
    {
        /// <summary>
        /// There are no special flags.
        /// </summary>
        None = 0,

        /// <summary>
        /// Selects the combination of all variance flags. This value is the result of using logical OR to combine the following flags: <see cref="Contravariant"/> and <see cref="Covariant"/>.
        /// </summary>
        VarianceMask = 3,

        /// <summary>
        /// The generic type parameter is covariant. A covariant type parameter can appear as the result type of a method, the type of a read-only field, a declared base type, or an implemented interface.
        /// </summary>
        Covariant = 1,

        /// <summary>
        /// The generic type parameter is contravariant. A contravariant type parameter can appear as a parameter type in method signatures.
        /// </summary>
        Contravariant = 2,

        /// <summary>
        /// Selects the combination of all special constraint flags. This value is the result of using logical OR to combine the following flags: <see cref="DefaultConstructorConstraint"/>, <see cref="ReferenceTypeConstraint"/>, and <see cref="NotNullableValueTypeConstraint"/>.
        /// </summary>
        SpecialConstraintMask = 28,

        /// <summary>
        /// A type can be substituted for the generic type parameter only if it is a reference type.
        /// </summary>
        ReferenceTypeConstraint = 4,

        /// <summary>
        /// A type can be substituted for the generic type parameter only if it is a value type and is not nullable.
        /// </summary>
        NotNullableValueTypeConstraint = 8,

        /// <summary>
        /// A type can be substituted for the generic type parameter only if it has a parameterless constructor.
        /// </summary>
        DefaultConstructorConstraint = 16,
    }
}

#endif // NANOCLR_REFLECTION
