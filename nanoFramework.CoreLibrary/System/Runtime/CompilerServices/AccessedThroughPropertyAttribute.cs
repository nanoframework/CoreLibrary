// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.CompilerServices
{
    using System;

    /// <summary>
    /// Specifies the name of the property that accesses the attributed field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class AccessedThroughPropertyAttribute : Attribute
    {
        private readonly string _propertyName;

        /// <summary>
        /// Initializes a new instance of the AccessedThroughPropertyAttribute class with the name of the property used to access the attributed field.
        /// </summary>
        /// <param name="propertyName">The name of the property used to access the attributed field.</param>
        public AccessedThroughPropertyAttribute(string propertyName)
        {
            _propertyName = propertyName;
        }

        /// <summary>
        /// Gets the name of the property used to access the attributed field.
        /// </summary>
        /// <value>
        /// The name of the property used to access the attributed field.
        /// </value>
        public string PropertyName
        {
            get
            {
                return _propertyName;
            }
        }
    }
}
