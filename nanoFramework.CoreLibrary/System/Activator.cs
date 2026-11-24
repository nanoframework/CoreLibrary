// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

namespace System
{
    using System.Reflection;

    /// <summary>
    /// Contains methods to create types of objects locally.
    /// </summary>
    public static class Activator
    {
        /// <summary>
        /// Creates an instance of the type designated by the specified generic type parameter, using the public parameterless constructor.
        /// </summary>
        /// <typeparam name="T">The type to create.</typeparam>
        /// <returns>A reference to the newly created object, or the default value for a value type.</returns>
        /// <exception cref="NotSupportedException">The type has no public parameterless constructor, it is abstract, or it is a value type that declares a parameterless constructor.</exception>
        public static T CreateInstance<T>()
        {
            Type type = typeof(T);

            ConstructorInfo constructor = type.IsAbstract ? null : type.GetConstructor(new Type[0]);

            if (type.IsValueType)
            {
                if (constructor != null)
                {
                    throw new NotSupportedException();
                }

                return default(T);
            }

            if (constructor == null || !constructor.IsPublic)
            {
                throw new NotSupportedException();
            }

            return (T)constructor.Invoke(null);
        }
    }
}

#endif // NANOCLR_REFLECTION
