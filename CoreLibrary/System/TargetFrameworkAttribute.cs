//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Runtime.Versioning
{
    /// <summary>
    /// Identifies the version of the .NET Framework that a particular assembly was compiled against.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Assembly)]
    public sealed class TargetFrameworkAttribute : Attribute
    {
        private String _frameworkName;
        private String _frameworkDisplayName;

        /// <summary>
        /// Initializes an instance of the TargetFrameworkAttribute class by specifying the .NET Framework version against which an assembly was built.
        /// </summary>
        /// <param name="frameworkName">The version of the .NET Framework against which the assembly was built.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public TargetFrameworkAttribute(String frameworkName)
        {
            if (frameworkName == null) throw new ArgumentNullException();
            _frameworkName = frameworkName;
        }

        /// <summary>
        /// Gets the name of the .NET Framework version against which a particular assembly was compiled.
        /// </summary>
        /// <value>
        /// The name of the .NET Framework version with which the assembly was compiled.
        /// </value>
        public String FrameworkName
        {
            get { return _frameworkName; }
        }

        /// <summary>
        /// Gets the display name of the .NET Framework version against which an assembly was built.
        /// </summary>
        /// <value>
        /// The display name of the .NET Framework version.
        /// </value>
        public String FrameworkDisplayName
        {
            get { return _frameworkDisplayName; }
            set { _frameworkDisplayName = value; }
        }
    }
}
