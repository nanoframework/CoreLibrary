//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using Runtime.CompilerServices;
    using System;

    /// <summary>
    /// Discovers the attributes of a field and provides access to field metadata.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Serializable]
    public abstract class FieldInfo : MemberInfo
    {

        /// <summary>
        /// Gets a MemberTypes value indicating that this member is a field.
        /// </summary>
        /// <value>
        /// A MemberTypes value indicating that this member is a field.
        /// </value>
        public override MemberTypes MemberType
        {
            get
            {
                return MemberTypes.Field;
            }
        }

        /// <summary>
        /// Gets the type of this field object.
        /// </summary>
        /// <value>
        /// The type of this field object.
        /// </value>
        public abstract Type FieldType
        {
            get;
        }

        /// <summary>
        /// When overridden in a derived class, returns the value of a field supported by a given object.
        /// </summary>
        /// <param name="obj">The object whose field value will be returned.</param>
        /// <returns>An object containing the value of the field reflected by this instance.</returns>
        [Diagnostics.DebuggerStepThrough]
        [Diagnostics.DebuggerHidden]
        public abstract object GetValue(object obj);

        /// <summary>
        /// Sets the value of the field supported by the given object.
        /// </summary>
        /// <param name="obj">The object whose field value will be set.</param>
        /// <param name="value">The value to assign to the field.</param>
        [Diagnostics.DebuggerStepThrough]
        [Diagnostics.DebuggerHidden]
        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        public virtual extern void SetValue(Object obj, Object value);
#pragma warning restore S4200 // Native methods should be wrapped

        /// <summary>
        /// When overridden in a derived class, returns an array of all custom attributes applied to this member.
        /// </summary>
        /// <param name="inherit"><c>true</c> to search this member's inheritance chain to find the attributes; otherwise, <c>false</c>. This parameter is ignored for properties and events.</param>
        /// <returns>An array that contains all the custom attributes applied to this member, or an array with zero elements if no attributes are defined.</returns>
        /// <remarks>This method ignores the inherit parameter for properties and events.</remarks>
        public override object[] GetCustomAttributes(bool inherit)
        {
            // get the custom attributes data for the field
            // these are returned "encoded" in an object array with 2 positions for each attribute
            // 1st the attribute type
            // 2nd the constructor parameter or null, if the attribute has no constructor
            // 
            // current limitations: 
            // - works only for constructors with a single parameter
            // - the parameter has to be a string or numeric type
            //
            // both limitations above can be relatively easily overcome by adding the appropriate code at the native handler
            var ret = GetCustomAttributesNative(inherit);

            object[] attributes = new object[ ret.Length/2 ];

            for (int i = 0; i < ret.Length; i += 2)
            {
                // peek next element to determine if it's null
                if(ret[ i+1 ] == null)
                {
                    // attribute without default constructor, just copy it
                    attributes[ i/2 ] = ret[i];
                }
                else
                {
                    // has default constructor, invoke it

                    // get the types
                    Type objectType = ret[i].GetType();
                    Type paramType = ret[ i+1 ].GetType();

                    // get constructor
                    ConstructorInfo ctor = objectType.GetConstructor(new Type[] { paramType });

                    // invoke constructor with the parameter
                    attributes[ i/2 ] = ctor.Invoke(new object[] { ret[ i+1 ] });
                }
            }

            return attributes;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
#pragma warning disable S4200 // Native methods should be wrapped
        private extern object[] GetCustomAttributesNative(bool inherit);
#pragma warning restore S4200 // Native methods should be wrapped
    }
}

#endif // NANOCLR_REFLECTION
