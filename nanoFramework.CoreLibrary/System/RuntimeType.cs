// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

namespace System
{
    using Reflection;
    using Runtime.CompilerServices;

    [Serializable]
    internal sealed class RuntimeType : Type
    {

        public override MemberTypes MemberType
        {
            get
            {
                return (DeclaringType != null) ? MemberTypes.NestedType : MemberTypes.TypeInfo;
            }
        }

        public override extern Assembly Assembly
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public override extern String Name
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public override extern String FullName
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        public override String AssemblyQualifiedName
        {
            get
            {
                return FullName + ", " + Assembly.FullName;
            }
        }

        public override extern Type BaseType
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern MethodInfo[] GetMethods(BindingFlags bindingAttr);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern FieldInfo GetField(String name, BindingFlags bindingAttr);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern FieldInfo[] GetFields(BindingFlags bindingAttr);

        /// <summary>
        /// This method will return all of the interfaces implemented by a class
        /// </summary>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern Type[] GetInterfaces();
        ////////////////////////////////////////////////////////////////////////////////////
        //////
        ////// Attributes
        //////
        //////   The attributes are all treated as read-only properties on a class.  Most of
        //////  these boolean properties have flag values defined in this class and act like
        //////  a bit mask of attributes.  There are also a set of boolean properties that
        //////  relate to the classes relationship to other classes and to the state of the
        //////  class inside the runtime.
        //////
        ////////////////////////////////////////////////////////////////////////////////////
        [MethodImpl(MethodImplOptions.InternalCall)]
        public override extern Type GetElementType();

        public override object[] GetCustomAttributes(bool inherit)
        {
            return CustomAttributesHelpers.GetCustomAttributesInternal(GetCustomAttributesNative(inherit));
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern object[] GetCustomAttributesNative(bool inherit);
    }
}

#endif // NANOCLR_REFLECTION
