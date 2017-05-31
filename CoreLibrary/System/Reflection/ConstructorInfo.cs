//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Reflection
{
    using System;
    using Runtime.CompilerServices;

    /// <summary>
    /// Discovers the attributes of a class constructor and provides access to constructor metadata.
    /// </summary>
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
    }
}
