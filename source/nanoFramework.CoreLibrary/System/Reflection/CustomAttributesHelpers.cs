//
// Copyright (c) 2020 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace System.Reflection
{
    internal class CustomAttributesHelpers
    {
        public static object[] GetCustomAttributesInternal(object[] rawAttributes)
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

            object[] attributes = new object[rawAttributes.Length / 2];

            for (int i = 0; i < rawAttributes.Length; i += 2)
            {
                // peek next element to determine if it's null
                if (rawAttributes[i + 1] == null)
                {
                    // attribute without default constructor, just copy it
                    attributes[i / 2] = rawAttributes[i];
                }
                else
                {
                    // has default constructor, invoke it

                    // get the types
                    Type objectType = rawAttributes[i].GetType();
                    Type paramType = rawAttributes[i + 1].GetType();

                    // get constructor
                    ConstructorInfo ctor = objectType.GetConstructor(new Type[] { paramType });

                    // invoke constructor with the parameter
                    attributes[i / 2] = ctor.Invoke(new object[] { rawAttributes[i + 1] });
                }
            }

            return attributes;
        }
    }
}
