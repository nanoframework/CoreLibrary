//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System.Collections;

namespace System.Reflection
{
    internal class CustomAttributesHelpers
    {
        /// <summary>
        /// Creates an array of <see cref="Attribute"/> from a set of attribute definitions.
        /// </summary>
        /// <param name="attributeDefinitions">An array of attribute definitions returned from a call to GetCustomAttributesNative.</param>
        /// <returns>An array of <see cref="Attribute"/>s</returns>
        /// <remarks>
        /// <para>
        /// The attribute definitions are "encoded" into an object array with two positions for each attribute.
        /// </para>
        /// 
        /// <para>
        /// 1st position - The type of the <see cref="Attribute"/><br/>
        /// 2nd position - The constructor parameter(s) or null
        /// </para>
        ///
        /// <para>
        /// Current limitations:<br/>
        /// </para>
        /// 
        /// <para>
        /// - The parameter(s) have to be a string or numeric type
        /// - Properties and fields are not supported
        /// </para>
        /// </remarks>
        public static object[] GetCustomAttributesInternal(object[] attributeDefinitions)
        {
            if (attributeDefinitions is null)
            {
                return new object[0];
            }

            var attributes = new ArrayList();

            for (var i = 0; i < attributeDefinitions.Length; i += 2)
            {
                var objectType = attributeDefinitions[i].GetType();
                var parameterType = attributeDefinitions[i + 1]?.GetType();

                ConstructorInfo constructorInfo;
                var constructorParameters = new object[0];

                if (parameterType is null)
                {
                    // If the parameter type is null we'll use the parameterless constructor
                    constructorInfo = objectType.GetConstructor(new Type[0]);
                }
                else if (parameterType.IsArray)
                {
                    // Check for a constructor with a single parameter of the correct array type
                    constructorInfo = objectType.GetConstructor(new[] { parameterType });
                    constructorParameters = new[] { attributeDefinitions[i + 1] };

                    if (constructorInfo is null)
                    {
                        // Check for a constructor with multiple parameters of the correct types
                        constructorParameters = (object[])attributeDefinitions[i + 1];

                        var parameterTypes = new Type[constructorParameters.Length];

                        for (var p = 0; p < constructorParameters.Length; p++)
                        {
                            parameterTypes[p] = constructorParameters[p].GetType();
                        }

                        constructorInfo = objectType.GetConstructor(parameterTypes);
                    }
                }
                else
                {
                    // Get a constructor with a single parameter of the correct type
                    constructorInfo = objectType.GetConstructor(new[] { parameterType });
                    constructorParameters = new[] { attributeDefinitions[i + 1] };
                }

                // If we found a constructor invoke it with the parameters
                if (constructorInfo is not null)
                {
                    attributes.Add(constructorInfo.Invoke(constructorParameters));
                }
#if DEBUG
                else
                {
                    // If a constructor was not found we're assuming it's a type that hasn't been implemented in nanoFramework
                    // eg: System.Runtime.CompilerServices.NullableContextAttribute
                    Console.WriteLine($"Attribute type is not found: {attributeDefinitions[i]}");
                }
#endif
            }

            return (object[])attributes.ToArray(typeof(object));
        }
    }
}
