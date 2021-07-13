//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using System;
    /// <summary>
    /// Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [Flags, Serializable]
    public enum BindingFlags
    {
        /// <summary>
        /// Specifies that no binding flags are defined.
        /// </summary>
        Default = 0x00,

        // These flags indicate what to search for when binding
        /// <summary>
        /// Specifies that the case of the member name should not be considered when binding.
        /// </summary>
        IgnoreCase = 0x01,   // Ignore the case of Names while searching
        /// <summary>
        /// Specifies that only members declared at the level of the supplied type's hierarchy should be considered. Inherited members are not considered.
        /// </summary>
        DeclaredOnly = 0x02,   // Only look at the members declared on the Type
        /// <summary>
        /// Specifies that instance members are to be included in the search.
        /// </summary>
        Instance = 0x04,   // Include Instance members in search
        /// <summary>
        /// Specifies that static members are to be included in the search.
        /// </summary>
        Static = 0x08,   // Include Static members in search
        /// <summary>
        /// Specifies that public members are to be included in the search.
        /// </summary>
        Public = 0x10,   // Include Public members in search
        /// <summary>
        /// Specifies that non-public members are to be included in the search.
        /// </summary>
        NonPublic = 0x20,   // Include Non-Public members in search
        /// <summary>
        /// Specifies that public and protected static members up the hierarchy should be returned. 
        /// Private static members in inherited classes are not returned. Static members include fields, methods, events, and properties. Nested types are not returned.
        /// </summary>
        FlattenHierarchy = 0x40,   // Rollup the statics into the class.

        // These flags are used by InvokeMember to determine
        // what type of member we are trying to Invoke.
        // BindingAccess = 0xFF00;
        /// <summary>
        /// Specifies that a method is to be invoked. This must not be a constructor or a type initializer.
        /// This flag is passed to an InvokeMember method to invoke a method.
        /// </summary>
        InvokeMethod = 0x0100,
        /// <summary>
        /// Specifies that reflection should create an instance of the specified type. Calls the constructor that matches the given arguments. The supplied member name is ignored.
        /// If the type of lookup is not specified, (Instance | Public) will apply. It is not possible to call a type initializer.
        /// This flag is passed to an InvokeMember method to invoke a constructor.
        /// </summary>
        CreateInstance = 0x0200,
        /// <summary>
        /// Specifies that the value of the specified field should be returned.
        /// This flag is passed to an InvokeMember method to get a field value.
        /// </summary>
        GetField = 0x0400,
        /// <summary>
        /// Specifies that the value of the specified field should be set.
        /// This flag is passed to an InvokeMember method to set a field value.
        /// </summary>
        SetField = 0x0800,
        /// <summary>
        /// Specifies that the value of the specified property should be returned.
        /// This flag is passed to an InvokeMember method to invoke a property getter.
        /// </summary>
        GetProperty = 0x1000,
        /// <summary>
        /// Specifies that the value of the specified property should be set. For COM properties, specifying this binding flag is equivalent to specifying PutDispProperty and PutRefDispProperty.
        /// This flag is passed to an InvokeMember method to invoke a property setter.
        /// </summary>
        SetProperty = 0x2000,

        // These flags are also used by InvokeMember but they should only
        // be used when calling InvokeMember on a COM object.
        /// <summary>
        /// Specifies that the PROPPUT member on a COM object should be invoked. PROPPUT specifies a property-setting function that uses a value.
        /// Use PutDispProperty if a property has both PROPPUT and PROPPUTREF and you need to distinguish which one is called.
        /// </summary>
        PutDispProperty = 0x4000,
        /// <summary>
        /// Specifies that the PROPPUTREF member on a COM object should be invoked. PROPPUTREF specifies a property-setting function that uses a reference instead of a value.
        /// Use PutRefDispProperty if a property has both PROPPUT and PROPPUTREF and you need to distinguish which one is called.
        /// </summary>
        PutRefDispProperty = 0x8000,

        /// <summary>
        /// Specifies that types of the supplied arguments must exactly match the types of the corresponding formal parameters. Reflection throws an exception 
        /// if the caller supplies a non-null Binder object, since that implies that the caller is supplying BindToXXX implementations that will pick the appropriate method.
        /// </summary>
        ExactBinding = 0x010000,   // Bind with Exact Type matching, No Change type
        /// <summary>
        /// Not implemented.
        /// </summary>
        SuppressChangeType = 0x020000,

        // DefaultValueBinding will return the set of methods having ArgCount or more parameters.  This is used for default values, etc.
        /// <summary>
        /// Returns the set of members whose parameter count matches the number of supplied arguments. This binding flag is used for methods with parameters that have default values and methods with variable arguments (varargs).
        /// This flag should only be used with Type.InvokeMember.
        /// </summary>
        OptionalParamBinding = 0x040000,

        // These are a couple of misc attributes used
        /// <summary>
        /// Used in COM interop to specify that the return value of the member can be ignored.
        /// </summary>
        IgnoreReturn = 0x01000000,   // This is used in COM Interop
    }
}

#endif // NANOCLR_REFLECTION
