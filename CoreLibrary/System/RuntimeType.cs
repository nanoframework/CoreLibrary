//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
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
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        public override extern String Name
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        public override extern String FullName
        {
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
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
            [MethodImplAttribute(MethodImplOptions.InternalCall)]
            get;
        }

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public override extern MethodInfo[] GetMethods(BindingFlags bindingAttr);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public override extern FieldInfo GetField(String name, BindingFlags bindingAttr);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public override extern FieldInfo[] GetFields(BindingFlags bindingAttr);

        /// <summary>
        /// This method will return all of the interfaces implemented by a class
        /// </summary>
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
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
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        public override extern Type GetElementType();

    }
}
