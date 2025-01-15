//
// Copyright (c) .NET Foundation and Contributors
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
            // 2nd the constructor parameter or null, if the attribute has no constructor parameters
            // 
            // current limitations: 
            // - works only for constructors with a single parameter
            // - the parameter has to be a string or numeric type
            //
            // both limitations above can be relatively easily overcome by adding the appropriate code at the native handler

            if (rawAttributes is null)
            {
                return new object[0];
            }

            var attributes = new object[rawAttributes.Length / 2];

            for (var i = 0; i < rawAttributes.Length; i += 2)
            {
                var objectType = rawAttributes[i].GetType();

                // peek next element to determine if it's null
                if (rawAttributes[i + 1] == null)
                {
                    var ctor = objectType.GetConstructor(new Type[0]);

                    if (ctor is null)
                    {
                        throw new InvalidOperationException();
                    }

                    // has default constructor, invoke it
                    attributes[i / 2] = ctor.Invoke(new object[0]);
                }
                else
                {
                    // get the parameter types
                    var paramType = rawAttributes[i + 1].GetType();

                    // get constructor
                    var ctor = objectType.GetConstructor(new Type[] { paramType });

                    // get params
                    var ctorParams = new[] { rawAttributes[i + 1] };

                    if (ctor is null)
                    {
                        // give it another try, this time with an array of the parameters types
                        // rebuild params list 
                        ctorParams = (object[])rawAttributes[i + 1];

                        var paramsTypes = new Type[ctorParams.Length];

                        for (var p = 0; p < ctorParams.Length; p++)
                        {
                            paramsTypes[p] = ctorParams[p].GetType();
                        }

                        ctor = objectType.GetConstructor(paramsTypes);

                        if (ctor is null)
                        {
                            throw new InvalidOperationException();
                        }
                    }

                    // invoke constructor with the parameter
                    attributes[i / 2] = ctor.Invoke(ctorParams);
                }
            }

            return attributes;
        }
    }
}
