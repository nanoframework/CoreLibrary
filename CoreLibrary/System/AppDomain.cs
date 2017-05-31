//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Reflection;
using System.Threading;
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Represents an application domain, which is an isolated environment where applications execute. This class cannot be inherited.
    /// </summary>
    public sealed class AppDomain : MarshalByRefObject
    {
        [FieldNoReflection]
        private object _appDomain;
        private string _friendlyName;

        private AppDomain()
        {
            throw new Exception();
        }

        /// <summary>
        /// Creates a new application domain with the specified name.
        /// </summary>
        /// <param name="friendlyName">The friendly name of the domain.</param>
        /// <returns>The newly created application domain.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern AppDomain CreateDomain(String friendlyName);

        /// <summary>
        /// Creates a new instance of the specified type. Parameters specify the assembly where the type is defined, and the name of the type.
        /// </summary>
        /// <param name="assemblyName">The display name of the assembly. See Assembly.FullName.</param>
        /// <param name="typeName">The fully qualified name of the requested type, including the namespace but not the assembly, as returned by the Type.FullName property.</param>
        /// <returns>An instance of the object specified by typeName.</returns>
        public Object CreateInstanceAndUnwrap(String assemblyName, String typeName)
        {
            var assembly = Assembly.Load(assemblyName);
            var type = assembly.GetType(typeName);
            var ci = type.GetConstructor(new Type[0]);
            var obj = ci.Invoke(null);

            return obj;
        }

        /// <summary>
        /// Gets the current application domain for the current Thread.
        /// </summary>
        /// <value>
        /// The current application domain.
        /// </value>
        public static AppDomain CurrentDomain
        {
            get
            {
                return Thread.GetDomain();
            }
        }

        /// <summary>
        /// Gets the friendly name of this application domain.
        /// </summary>
        /// <value>
        /// The friendly name of this application domain.
        /// </value>
        public String FriendlyName
        {
            get
            {
                return _friendlyName;
            }
        }

        /// <summary>
        /// Loads an Assembly given its display name.
        /// </summary>
        /// <param name="assemblyString">The display name of the assembly. See Assembly.FullName.</param>
        /// <returns>The loaded assembly.</returns>
        public Assembly Load(String assemblyString)
        {
            var fVersion = false;
            var ver = new int[4];
            var name = Assembly.ParseAssemblyName(assemblyString, ref fVersion, ref ver);

            return LoadInternal(name, fVersion, ver[0], ver[1], ver[2], ver[3]);

        }

        /// <summary>
        /// Gets the assemblies that have been loaded into the execution context of this application domain.
        /// </summary>
        /// <returns>An array of assemblies in this application domain.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern Assembly[] GetAssemblies();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern Assembly LoadInternal(String assemblyString, bool fVersion, int maj, int min, int build, int rev);

        /// <summary>
        /// Unloads the specified application domain.
        /// </summary>
        /// <param name="domain">An application domain to unload.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void Unload(AppDomain domain);
    }
}
