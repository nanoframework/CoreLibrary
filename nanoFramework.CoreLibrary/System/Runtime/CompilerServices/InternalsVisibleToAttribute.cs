//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Specifies that types that are ordinarily visible only within the current assembly are visible to a specified assembly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class InternalsVisibleToAttribute : Attribute
    {
        private readonly string _assemblyName;

        /// <summary>
        /// Initializes a new instance of the InternalsVisibleToAttribute class with the name of the specified friend assembly.
        /// </summary>
        /// <param name="assemblyName">The name of a friend assembly.</param>
        public InternalsVisibleToAttribute(string assemblyName)
        {
            _assemblyName = assemblyName;
        }

        /// <summary>
        /// Gets the name of the friend assembly to which all types and type members that are marked with the internal keyword are to be made visible.
        /// </summary>
        /// <value>
        /// A string that represents the name of the friend assembly.
        /// </value>
        public string AssemblyName
        {
            get
            {
                return _assemblyName;
            }
        }

    }
}
