//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Indicates whether a program element is compliant with the Common Language Specification (CLS). This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.All), Serializable]
    public sealed class CLSCompliantAttribute : Attribute
    {
        private bool _compliant;

        /// <summary>
        /// Initializes an instance of the CLSCompliantAttribute class with a Boolean value indicating whether the indicated program element is CLS-compliant.
        /// </summary>
        /// <param name="isCompliant">true if CLS-compliant; otherwise, false.</param>
        public CLSCompliantAttribute(bool isCompliant)
        {
            _compliant = isCompliant;
        }

        /// <summary>
        /// GGets the Boolean value indicating whether the indicated program element is CLS-compliant.
        /// </summary>
        /// <value>true if the program element is CLS-compliant; otherwise, false.</value>
        public bool IsCompliant
        {
            get { return _compliant; }
        }
    }
}
