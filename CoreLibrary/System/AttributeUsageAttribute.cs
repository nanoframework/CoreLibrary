//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Specifies the usage of another attribute class. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class), Serializable]
    public sealed class AttributeUsageAttribute : Attribute
    {
        internal AttributeTargets AttributeTarget;
        internal bool AllowMultipleAttributes;
        internal bool InheritedAttribute = true;

        internal static AttributeUsageAttribute Default = new AttributeUsageAttribute(AttributeTargets.All);

        /// <summary>
        /// Initializes a new instance of the AttributeUsageAttribute class with the specified list of AttributeTargets, the AllowMultiple value, and the Inherited value.
        /// </summary>
        /// <param name="validOn">The set of values combined using a bitwise OR operation to indicate which program elements are valid.</param>
        public AttributeUsageAttribute(AttributeTargets validOn)
        {
            AttributeTarget = validOn;
        }

        /// <summary>
        /// Gets a set of values identifying which program elements that the indicated attribute can be applied to.
        /// </summary>
        /// <value>One or several AttributeTargets values. The default is All.</value>
        public AttributeTargets ValidOn
        {
            get { return AttributeTarget; }
        }

        /// <summary>
        /// Gets or sets a Boolean value indicating whether more than one instance of the indicated attribute can be specified for a single program element.
        /// </summary>
        /// <value>true if more than one instance is allowed to be specified; otherwise, false. The default is false.</value>
        public bool AllowMultiple
        {
            get { return AllowMultipleAttributes; }
            set { AllowMultipleAttributes = value; }
        }

        /// <summary>
        /// Gets or sets a Boolean value that determines whether the indicated attribute is inherited by derived classes and overriding members.
        /// </summary>
        /// <value>true if the attribute can be inherited by derived classes and overriding members; otherwise, false. The default is true.</value>
        public bool Inherited
        {
            get { return InheritedAttribute; }
            set { InheritedAttribute = value; }
        }
    }
}
