//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#if NANOCLR_REFLECTION

namespace System.Reflection
{
    using System;
    using CultureInfo = Globalization.CultureInfo;
    using Runtime.CompilerServices;

    /// <summary>
    /// Describes an assembly's unique identity in full.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    public sealed class AssemblyName
    {
        private readonly Assembly _assembly;

        internal AssemblyName(Assembly assm)
        {
            _assembly = assm;
        }

        /// <summary>
        /// Gets the simple name of the assembly. This is usually, but not necessarily, the file name of the manifest file of the assembly, minus its extension.
        /// </summary>
        /// <value>The simple name of the assembly.</value>
        public String Name
        {
            get
            {
                return _assembly.FullName.Substring(0, _assembly.FullName.IndexOf(','));
            }
        }

        /// <summary>
        /// Gets the full name of the assembly, also known as the display name.
        /// </summary>
        /// <value>A string that is the full name of the assembly, also known as the display name.</value>
        public String FullName
        {
            get
            {
                return _assembly.FullName;
            }
        }

        /// <summary>
        /// Gets or sets the major, minor, build, and revision numbers of the assembly.
        /// </summary>
        /// <value>An object that represents the major, minor, build, and revision numbers of the assembly.</value>
        public Version Version
        {
            get
            {
                int major = -1, minor = -1, build = -1, revision = -1;

                _assembly.GetVersion(ref major, ref minor, ref build, ref revision);

                return new Version(major, minor, build, revision);
            }
        }
    }

    /// <summary>
    /// Represents an assembly, which is a reusable, versionable, and self-describing building block of a common language runtime application.
    /// </summary>
    [Serializable]
    public class Assembly
    {
        /// <summary>
        /// Gets the display name of the assembly.
        /// </summary>
        /// <value>The display name of the assembly.</value>
        public virtual extern String FullName
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Gets the assembly that contains the code that is currently executing.
        /// </summary>
        /// <returns>The assembly that contains the code that is currently executing.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern Assembly GetExecutingAssembly();

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern void GetVersion(ref int major, ref int minor, ref int build, ref int revision);

        /// <summary>
        /// Gets an AssemblyName for this assembly.
        /// </summary>
        /// <returns>An object that contains the fully parsed display name for this assembly.</returns>
        public AssemblyName GetName()
        {
            return new AssemblyName(this);
        }

        /// <summary>
        /// Gets the currently loaded assembly in which the specified type is defined.
        /// </summary>
        /// <param name="type">An object representing a type in the assembly that will be returned.</param>
        /// <returns>The assembly in which the specified type is defined.</returns>
        public static Assembly GetAssembly(Type type)
        {
            return type.Assembly;
        }

        /// <summary>
        /// Gets the Type object with the specified name in the assembly instance.
        /// </summary>
        /// <param name="name">The full name of the type.</param>
        /// <returns>An object that represents the specified class, or null if the class is not found.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern Type GetType(String name);

        /// <summary>
        /// Gets the Type object with the specified name in the assembly instance and optionally throws an exception if the type is not found.
        /// </summary>
        /// <param name="name">The full name of the type.</param>
        /// <param name="throwOnError">true to throw an exception if the type is not found; false to return null.</param>
        /// <returns>An object that represents the specified class.</returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual Type GetType(String name, bool throwOnError)
        {
            var type = GetType(name);

#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if ( (type == null) && (throwOnError) ) throw new ArgumentException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            return type;
        }

        /// <summary>
        /// Gets the types defined in this assembly.
        /// </summary>
        /// <returns>An array that contains all the types that are defined in this assembly.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public virtual extern Type[] GetTypes();

        /// <summary>
        /// Gets the satellite assembly for the specified culture.
        /// </summary>
        /// <param name="culture">The specified culture.</param>
        /// <returns>The specified satellite assembly.</returns>
        /// <exception cref="ArgumentNullException">culture is null.</exception>
        /// <exception cref="ArgumentException"></exception>
        public Assembly GetSatelliteAssembly(CultureInfo culture)
        {
            if (culture == null) throw new ArgumentNullException("culture");

            Assembly assm = null;
            var baseName = FullName;
            string cultureName;

            while (assm == null && (cultureName = culture.Name) != "")
            {
                var assmName = baseName + "." + cultureName;

                assm = Load(assmName, false);

                culture = culture.Parent;
            }

            if (assm == null)
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                // FIXME -- throw new FileNotFoundException();
            }

            return assm;
        }

        /// <summary>
        /// Loads an assembly given the long form of its name.
        /// </summary>
        /// <param name="assemblyString">The long form of the assembly name.</param>
        /// <returns>The loaded assembly.</returns>
        /// <exception cref="ArgumentNullException">assemblyString is null.</exception>
        public static Assembly Load(String assemblyString)
        {
            if (assemblyString == null) throw new ArgumentNullException("assemblyString");

            return Load(assemblyString, true);
        }

        internal static string ParseAssemblyName(String assemblyString, ref bool fVersion, ref int[] ver)
        {
            // valid names are in the forms:
            // 1) "nanoFramework.Runtime.Native" or
            // 2) "nanoFramework.Runtime.Native, Version=1.2.3.4" or
            // 3) "nanoFramework.Runtime.Native.resources, Version=1.2.3.4" or
            // 4) "nanoFramework.Runtime.Native.nanoresources, Version=1.2.3.4"
            // 5) (FROM THE DEBUGGER) "nanoFramework.Runtime.Native, Version=1.2.3.4, Culture=neutral, PublicKeyToken=null[, ...]

            int commaIdx;
            string name;

            fVersion = false;

            // if there is no comma then we have an assembly name in the form with no version
            if ((commaIdx = assemblyString.IndexOf(',')) != -1)
            {
                name = assemblyString.Substring(0, commaIdx);

                const string versionTag = "version=";

                // verify that the format with the version is correct and skip the ", Version=" part of the string
                int versionIdx;
                if ((versionIdx = assemblyString.ToLower().IndexOf(versionTag)) != 0)
                {
                    fVersion = true;

                    // the "version=" string must come right after the ' ,'
                    if (versionIdx == commaIdx + 2)
                    {
                        var startIdx = versionIdx + versionTag.Length;
                        int endIdx;

                        // trim off the Culture, PublicKeyToken, etc for now
                        assemblyString = -1 != (endIdx = assemblyString.IndexOf(',', startIdx)) ? assemblyString.Substring(startIdx, endIdx - startIdx) : assemblyString.Substring(startIdx);

                        // at this point we have assemblyString = "1.2.3.4"
                        var version = assemblyString.Split('.');

                        if (version.Length > 0) ver[0] = UInt16.Parse(version[0]);
                        if (version.Length > 1) ver[1] = UInt16.Parse(version[1]);
                        // build and revision versions may be -1 (which means "don't care")
                        if (version.Length > 2) ver[2] = int.Parse(version[2]);
                        if (version.Length > 3) ver[3] = int.Parse(version[3]);
                    }
                    else
                    {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                        throw new ArgumentException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                    }
                }
                else
                {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                    throw new ArgumentException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                }
            }
            else
            {
                name = assemblyString;
            }

            return name;
        }

        internal static Assembly Load(String assemblyString, bool fThrowOnError)
        {
            var fVersion = false;
            var ver = new int[4];
            var name = ParseAssemblyName(assemblyString, ref fVersion, ref ver);
            var assm = LoadInternal(name, fVersion, ver[0], ver[1], ver[2], ver[3]);

            if (assm == null)
            {
                if (fThrowOnError)
                {
                    // FIXME -- should be FileNotFoundException, per spec.
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                    throw new ArgumentException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                }
            }

            return assm;
        }

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Assembly LoadInternal(String assemblyString, bool fVersion, int maj, int min, int build, int rev);

        /// <summary>
        /// Loads the assembly with a common object file format (COFF)-based image containing an emitted assembly. The assembly is loaded into the application domain of the caller.
        /// </summary>
        /// <param name="rawAssembly">A byte array that is a COFF-based image containing an emitted assembly.</param>
        /// <returns>The loaded assembly.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern Assembly Load(byte[] rawAssembly);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal extern String[] GetManifestResourceNames();
    }
}

#endif // NANOCLR_REFLECTION
