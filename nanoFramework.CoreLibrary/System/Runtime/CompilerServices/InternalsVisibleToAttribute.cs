// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Specifies that types that are ordinarily visible only within the current assembly are visible to a specified assembly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    [ExcludeFromStubs]
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
