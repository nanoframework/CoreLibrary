// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Specifies the usage of another attribute class. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [ExcludeType]
    [Serializable]
    public sealed class AttributeUsageAttribute : Attribute
    {
        internal AttributeTargets _attributeTarget;
        internal bool _allowMultipleAttributes;
        internal bool _iInheritedAttribute = true;

        internal static AttributeUsageAttribute Default = new AttributeUsageAttribute(AttributeTargets.All);

        /// <summary>
        /// Initializes a new instance of the AttributeUsageAttribute class with the specified list of AttributeTargets, the AllowMultiple value, and the Inherited value.
        /// </summary>
        /// <param name="validOn">The set of values combined using a bitwise OR operation to indicate which program elements are valid.</param>
        public AttributeUsageAttribute(AttributeTargets validOn)
        {
            _attributeTarget = validOn;
        }

        /// <summary>
        /// Gets a set of values identifying which program elements that the indicated attribute can be applied to.
        /// </summary>
        /// <value>One or several AttributeTargets values. The default is All.</value>
        public AttributeTargets ValidOn
        {
            get { return _attributeTarget; }
        }

#pragma warning disable S2292 // Trivial properties should be auto-implemented
        /// <summary>
        /// Gets or sets a Boolean value indicating whether more than one instance of the indicated attribute can be specified for a single program element.
        /// </summary>
        /// <value>true if more than one instance is allowed to be specified; otherwise, false. The default is false.</value>
        public bool AllowMultiple
#pragma warning restore S2292 // Trivial properties should be auto-implemented
        {
            get { return _allowMultipleAttributes; }
            set { _allowMultipleAttributes = value; }
        }

#pragma warning disable S2292 // Trivial properties should be auto-implemented
        /// <summary>
        /// Gets or sets a Boolean value that determines whether the indicated attribute is inherited by derived classes and overriding members.
        /// </summary>
        /// <value>true if the attribute can be inherited by derived classes and overriding members; otherwise, false. The default is true.</value>
        public bool Inherited
#pragma warning restore S2292 // Trivial properties should be auto-implemented
        {
            get { return _iInheritedAttribute; }
            set { _iInheritedAttribute = value; }
        }
    }
}
