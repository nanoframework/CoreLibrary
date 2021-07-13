//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System
{
    
    using Reflection;
    using Runtime.CompilerServices;

    /// <summary>
    /// Represents type declarations: class types, interface types, array types, value types, enumeration types, type parameters, generic type definitions, and open or closed constructed generic types.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Serializable]
    public abstract class Type : MemberInfo, IReflect
    {

        /// <summary>
        /// Gets the type that declares the current nested type or generic type parameter.
        /// </summary>
        /// <value>
        /// A Type object representing the enclosing type, if the current type is a nested type; or the generic type definition, 
        /// if the current type is a type parameter of a generic type; or the type that declares the generic method, 
        /// if the current type is a type parameter of a generic method; otherwise, null.
        /// </value>
        public override extern Type DeclaringType
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }


        /// <summary>
        /// Gets the Type with the specified name, performing a case-sensitive search.
        /// </summary>
        /// <param name="typeName">The assembly-qualified name of the type to get. See AssemblyQualifiedName. 
        /// If the type is in the currently executing assembly or in Mscorlib.dll, it is sufficient to supply the type name qualified by its namespace.</param>
        /// <returns>The type with the specified name, if found; otherwise, null.</returns>
        public static Type GetType(String typeName)
        {
            var fVersion = false;
            var ver = new int[4];
            var assemblyString = String.Empty;
            var assemblyName = "";
            var name = ParseTypeName(typeName, ref assemblyString);

            if (assemblyString.Length > 0) assemblyName = Assembly.ParseAssemblyName(assemblyString, ref fVersion, ref ver);

            return GetTypeInternal(name, assemblyName, fVersion, ver);
        }

        [Diagnostics.DebuggerHidden]
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Type GetTypeInternal(String typeName, string assemblyName, bool fVersion, int[] ver);

        /// <summary>
        /// Invokes the specified member, using the specified binding constraints and matching the specified argument list.
        /// </summary>
        /// <param name="name">The string containing the name of the constructor, method, property, or field member to invoke.
        /// <para>-or-</para>
        /// <para>An empty string ("") to invoke the default member.</para>
        /// <para>-or-</para>
        /// <para>For IDispatch members, a string representing the DispID, for example "[DispID=3]".</para>
        /// </param>
        /// <param name="invokeAttr">A bitmask comprised of one or more BindingFlags that specify how the search is conducted. 
        /// The access can be one of the BindingFlags such as Public, NonPublic, Private, InvokeMethod, GetField, and so on. 
        /// The type of lookup need not be specified. If the type of lookup is omitted, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static are used.</param>
        /// <param name="binder">An object that defines a set of properties and enables binding, which can involve selection of an overloaded method, coercion of argument types, and invocation of a member through reflection.
        /// <para>-or-</para>
        /// <para>A null reference(Nothing in Visual Basic), to use the DefaultBinder.Note that explicitly defining a Binder object may be required for successfully invoking method overloads with variable arguments.</para>
        /// </param>
        /// <param name="target">The object on which to invoke the specified member.</param>
        /// <param name="args">An array containing the arguments to pass to the member to invoke.</param>
        /// <returns>An object representing the return value of the invoked member.</returns>
        [Diagnostics.DebuggerStepThrough]
        [Diagnostics.DebuggerHidden]
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern Object InvokeMember(String name, BindingFlags invokeAttr, Binder binder, Object target, Object[] args);

        /// <summary>
        /// Gets the Assembly in which the type is declared. For generic types, gets the Assembly in which the generic type is defined.
        /// </summary>
        /// <value>
        /// An Assembly instance that describes the assembly containing the current type. For generic types, the instance describes the assembly that 
        /// contains the generic type definition, not the assembly that creates and uses a particular constructed type.
        /// </value>
        public abstract Assembly Assembly
        {
            get;
        }

        /// <summary>
        /// Gets the type referenced by the specified type handle.
        /// </summary>
        /// <param name="handle">The object that refers to the type.</param>
        /// <returns>The type referenced by the specified RuntimeTypeHandle, or null if the Value property of handle is null.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern Type GetTypeFromHandle(RuntimeTypeHandle handle);

        /// <summary>
        /// Gets the fully qualified name of the type, including its namespace but not its assembly.
        /// </summary>
        /// <value>
        /// The fully qualified name of the type, including its namespace but not its assembly; or null if the current instance represents
        /// a generic type parameter, an array type, pointer type, or byref type based on a type parameter, or a generic type that is not 
        /// a generic type definition but contains unresolved type parameters.
        /// </value>
        public abstract String FullName
        {
            get;
        }

        /// <summary>
        /// Gets the assembly-qualified name of the type, which includes the name of the assembly from which this Type object was loaded.
        /// </summary>
        /// <value>
        /// The assembly-qualified name of the Type, which includes the name of the assembly from which the Type was loaded, or null if the current instance represents a generic type parameter.
        /// </value>
        public abstract String AssemblyQualifiedName
        {
            get;
        }

        /// <summary>
        /// Gets the type from which the current Type directly inherits.
        /// </summary>
        /// <value>
        /// The Type from which the current Type directly inherits, or null if the current Type represents the Object class or an interface.
        /// </value>
        public abstract Type BaseType
        {
            get;
        }

        /// <summary>
        /// Searches for a public instance constructor whose parameters match the types in the specified array.
        /// </summary>
        /// <param name="types">An array of Type objects representing the number, order, and type of the parameters for the desired constructor.
        /// <para>-or-</para>
        /// <para>An empty array of Type objects, to get a constructor that takes no parameters.Such an empty array is provided by the static field Type.EmptyTypes.</para>
        /// </param>
        /// <returns>An object representing the public instance constructor whose parameters match the types in the parameter type array, if found; otherwise, null.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern ConstructorInfo GetConstructor(Type[] types);

        /// <summary>
        /// Searches for the specified public method whose parameters match the specified argument types.
        /// </summary>
        /// <param name="name">The string containing the name of the public method to get.</param>
        /// <param name="types">An array of Type objects representing the number, order, and type of the parameters for the desired constructor.
        /// <para>-or-</para>
        /// <para>An empty array of Type objects, to get a constructor that takes no parameters.Such an empty array is provided by the static field Type.EmptyTypes.</para>
        /// </param>
        /// <returns>An object representing the public method whose parameters match the specified argument types, if found; otherwise, null.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern MethodInfo GetMethod(String name, Type[] types);

        /// <summary>
        /// Searches for the specified method, using the specified binding constraints.
        /// </summary>
        /// <param name="name">The string containing the name of the method to get.</param>
        /// <param name="bindingAttr">A bitmask comprised of one or more BindingFlags that specify how the search is conducted or Zero, to return null.</param>
        /// <returns>An object representing the method that matches the specified requirements, if found; otherwise, null.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern MethodInfo GetMethod(String name, BindingFlags bindingAttr);

        /// <summary>
        /// Searches for the public method with the specified name.
        /// </summary>
        /// <param name="name">The string containing the name of the public method to get.</param>
        /// <returns>An object that represents the public method with the specified name, if found; otherwise, null.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern MethodInfo GetMethod(String name);

        // GetMethods
        // This routine will return all the methods implemented by the class
        /// <summary>
        /// Returns all the public methods of the current Type.
        /// </summary>
        /// <returns>An array of MethodInfo objects representing all the public methods defined for the current Type.
        /// <para>-or-</para>
        /// <para>An empty array of type MethodInfo, if no public methods are defined for the current Type.</para>
        /// </returns>
        public MethodInfo[] GetMethods()
        {
            return GetMethods(DefaultLookup);
        }

        /// <summary>
        /// When overridden in a derived class, searches for the methods defined for the current Type, using the specified binding constraints.
        /// </summary>
        /// <param name="bindingAttr">A bitmask comprised of one or more BindingFlags that specify how the search is conducted or Zero, to return null.</param>
        /// <returns>An array of MethodInfo objects representing all the public methods defined for the current Type.
        /// <para>-or-</para>
        /// <para>An empty array of type MethodInfo, if no public methods are defined for the current Type.</para>
        /// </returns>
        public abstract MethodInfo[] GetMethods(BindingFlags bindingAttr);

        /// <summary>
        /// Searches for the specified field, using the specified binding constraints.
        /// </summary>
        /// <param name="name">The string containing the name of the data field to get.</param>
        /// <param name="bindingAttr">A bitmask comprised of one or more BindingFlags that specify how the search is conducted or Zero, to return null.</param>
        /// <returns>An object representing the field that matches the specified requirements, if found; otherwise, null.</returns>
        public abstract FieldInfo GetField(String name, BindingFlags bindingAttr);

        /// <summary>
        /// Searches for the public field with the specified name.
        /// </summary>
        /// <param name="name">The string containing the name of the data field to get.</param>
        /// <returns>An object representing the public field with the specified name, if found; otherwise, null.</returns>
        public FieldInfo GetField(String name)
        {
            return GetField(name, DefaultLookup);
        }

        /// <summary>
        /// Returns all the public fields of the current Type.
        /// </summary>
        /// <returns>An array of FieldInfo objects representing all the public fields defined for the current Type.
        /// <para>-or-</para>
        /// <para>An empty array of type FieldInfo, if no public fields are defined for the current Type.</para>
        /// </returns>
        public FieldInfo[] GetFields()
        {
            return GetFields(DefaultLookup);
        }

        /// <summary>
        /// When overridden in a derived class, searches for the fields defined for the current Type, using the specified binding constraints.
        /// </summary>
        /// <param name="bindingAttr">A bitmask comprised of one or more BindingFlags that specify how the search is conducted or Zero, to return null.</param>
        /// <returns>An array of FieldInfo objects representing all the public fields defined for the current Type.
        /// <para>-or-</para>
        /// <para>An empty array of type FieldInfo, if no public fields are defined for the current Type.</para>
        /// </returns>
        public abstract FieldInfo[] GetFields(BindingFlags bindingAttr);

        /// <summary>
        /// When overridden in a derived class, gets all the interfaces implemented or inherited by the current Type.
        /// </summary>
        /// <returns>An array of Type objects representing all the interfaces implemented or inherited by the current Type.
        /// <para>-or-</para>
        /// <para>An empty array of type Type, if no interfaces are implemented or inherited by the current Type.</para>
        /// </returns>
        public abstract Type[] GetInterfaces();

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
        /// <summary>
        /// Gets a value indicating whether the Type is not declared public.
        /// </summary>
        /// <value>true if the Type is not declared public and is not a nested type; otherwise, false.</value>
        public extern bool IsNotPublic
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the Type is declared public.
        /// </summary>
        /// <value>true if the Type is declared public and is not a nested type; otherwise, false.</value>
        public extern bool IsPublic
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the Type is a class or a delegate; that is, not a value type or interface.        
        /// </summary>
        /// <value>true if the Type is a class; otherwise, false.</value>
        public extern bool IsClass
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the Type is an interface; that is, not a class or a value type.        
        /// </summary>
        /// <value>true if the Type is an interface; otherwise, false.</value>
        public extern bool IsInterface
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the Type is a value type.        
        /// </summary>
        /// <value>true if the Type is a value type; otherwise, false.</value>
        public extern bool IsValueType
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the Type is abstract and must be overridden.       
        /// </summary>
        /// <value>true if the Type is abstract; otherwise, false.</value>
        public extern bool IsAbstract
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the current Type represents an enumeration.      
        /// </summary>
        /// <value>true if the current Type represents an enumeration; otherwise, false.</value>
        public extern bool IsEnum
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value indicating whether the Type is serializable.      
        /// </summary>
        /// <value>true if the Type is serializable; otherwise, false.</value>
        public extern bool IsSerializable
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets a value that indicates whether the type is an array.  
        /// </summary>
        /// <value>true if the current type is an array; otherwise, false.</value>
        public extern bool IsArray
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// When overridden in a derived class, returns the Type of the object encompassed or referred to by the current array, pointer or reference type.
        /// </summary>
        /// <returns>The Type of the object encompassed or referred to by the current array, pointer, or reference type, or null if the current Type is 
        /// not an array or a pointer, or is not passed by reference, or represents a generic type or a type parameter in the definition of a generic type or generic method.
        /// </returns>
        public abstract Type GetElementType();

        /// <summary>
        /// Determines whether the current Type derives from the specified Type.
        /// </summary>
        /// <param name="c">The type to compare with the current type.</param>
        /// <returns>true if the current Type derives from c; otherwise, false. This method also returns false if c and the current Type are equal.</returns>
        public virtual bool IsSubclassOf(Type c)
        {
            var p = this;
            if (p == c) return false;
            while (p != null)
            {
                if (p == c) return true;
                p = p.BaseType;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified object is an instance of the current Type.
        /// </summary>
        /// <param name="o">The object to compare with the current type.</param>
        /// <returns>true if the current Type is in the inheritance hierarchy of the object represented by o, or if the current Type is an interface that o implements. 
        /// false if neither of these conditions is the case, if o is null, or if the current Type is an open generic type (that is, ContainsGenericParameters returns true).
        /// </returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern bool IsInstanceOfType(Object o);

        /// <summary>
        /// Returns a String representing the name of the current Type.
        /// </summary>
        /// <returns>A String representing the name of the current Type.</returns>
        public override String ToString()
        {
            return FullName;
        }

        private const BindingFlags DefaultLookup = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

        private static string ParseTypeName(String typeName, ref String assemblyString)
        {
            //TODO: change names here to reflect nanoFramework name
            // valid names are in the forms:
            // 1) "Windows.Devices.Gpio.GpioPin" or
            // 2) "Windows.Devices.Gpio.GpioPin, Windows.Devices.Gpio" or
            // 3) "Windows.Devices.Gpio.GpioPin, Windows.Devices.Gpio, Version=1.2.3.4" 
            // 4) (FROM THE DEBUGGER) "Windows.Devices.Gpio.GpioPin, Windows.Devices.Gpio, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null[, ...]

            int commaIdx;
            string name;

            // if there is no comma then we have an assembly name in the form with no version
            if ((commaIdx = typeName.IndexOf(',')) != -1)
            {
                // we grab the type name, but we already know there is more
                name = typeName.Substring(0, commaIdx);

                // after the comma we need ONE (1) space only and then the assembly name
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                if (typeName.Length <= commaIdx + 2) throw new ArgumentException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

                // now we can grab the assemblyName 
                // at this point there could be also the Version appended to it
                assemblyString = typeName.Substring(commaIdx + 2);
            }
            else
            {
                name = typeName;
                assemblyString = "";
            }

            return name;
        }
    }
}

#endif // NANOCLR_REFLECTION
