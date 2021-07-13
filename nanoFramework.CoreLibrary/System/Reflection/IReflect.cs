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
    /// Interoperates with the IDispatch interface.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    public interface IReflect
    {
        /// <summary>
        /// Retrieves a MethodInfo object that corresponds to a specified method under specified search constraints.
        /// </summary>
        /// <param name="name">The name of the member to find.</param>
        /// <param name="bindingAttr">The binding attributes used to control the search.</param>
        /// <returns>A MethodInfo object containing the method information, with the match being based on the method name and search constraints specified in bindingAttr.</returns>
        MethodInfo GetMethod(String name, BindingFlags bindingAttr);

        /// <summary>
        /// Returns the FieldInfo object that corresponds to the specified field and binding flag.
        /// </summary>
        /// <param name="name">The name of the field to find.</param>
        /// <param name="bindingAttr">The binding attributes used to control the search.</param>
        /// <returns>A FieldInfo object containing the field information for the named object that meets the search constraints specified in bindingAttr.</returns>
        FieldInfo GetField(String name, BindingFlags bindingAttr);
    }
}

#endif // NANOCLR_REFLECTION
