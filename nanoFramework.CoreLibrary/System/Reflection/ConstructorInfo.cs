//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using Runtime.CompilerServices;
    using System;

    /// <summary>
    /// Discovers the attributes of a class constructor and provides access to constructor metadata.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Serializable]
    public abstract class ConstructorInfo : MethodBase
    {
        /// <summary>
        /// Gets a MemberTypes value indicating that this member is a constructor.
        /// </summary>
        /// <value>
        /// A MemberTypes value indicating that this member is a constructor.
        /// </value>
        public override MemberTypes MemberType
        {
            get { return MemberTypes.Constructor; }
        }

        /// <summary>
        /// Invokes the constructor reflected by the instance that has the specified parameters, providing default values for the parameters not commonly used.
        /// </summary>
        /// <param name="parameters">An array of values that matches the number, order and type (under the constraints of the default binder) of the parameters for this constructor.
        /// If this constructor takes no parameters, then use either an array with zero elements or null, as in Object[] parameters = new Object[0]. 
        /// Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference-type elements, this value is null.
        /// For value-type elements, this value is 0, 0.0, or false, depending on the specific element type.</param>
        /// <returns>An instance of the class associated with the constructor.</returns>
        [Diagnostics.DebuggerStepThrough]
        [Diagnostics.DebuggerHidden]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern Object Invoke(Object[] parameters);

        /// <summary>
        /// When overridden in a derived class, returns an array of all custom attributes applied to this member.
        /// </summary>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events.</param>
        /// <returns>An array that contains all the custom attributes applied to this member, or an array with zero elements if no attributes are defined.</returns>
        /// <remarks>This method is not implemented in nanoFramework.</remarks>
        /// <exception cref="NotImplementedException"/>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern override object[] GetCustomAttributes(bool inherit);
    }
}

#endif // NANOCLR_REFLECTION
