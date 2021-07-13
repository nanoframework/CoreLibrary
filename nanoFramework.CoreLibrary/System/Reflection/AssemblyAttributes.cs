//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Reflection
{
    using System;

    /// <summary>
    /// Specifies which culture the assembly supports.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyCultureAttribute : Attribute
    {
        private readonly String _culture;

        /// <summary>
        /// Initializes a new instance of the AssemblyCultureAttribute class with the culture supported by the assembly being attributed.
        /// </summary>
        /// <param name="culture">The culture supported by the attributed assembly.</param>
        public AssemblyCultureAttribute(String culture)
        {
            _culture = culture;
        }

        /// <summary>
        /// Gets the supported culture of the attributed assembly.
        /// </summary>
        /// <value>
        /// A string containing the name of the supported culture.
        /// </value>
        public String Culture
        {
            get { return _culture; }
        }
    }

    /// <summary>
    /// Specifies the version of the assembly being attributed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyVersionAttribute : Attribute
    {
        private readonly String _version;

        /// <summary>
        /// Initializes a new instance of the AssemblyVersionAttribute class with the version number of the assembly being attributed.
        /// </summary>
        /// <param name="version">The version number of the attributed assembly.</param>
        public AssemblyVersionAttribute(String version)
        {
            _version = version;
        }

        /// <summary>
        /// Gets the version number of the attributed assembly.
        /// </summary>
        /// <value>
        /// A string containing the assembly version number.
        /// </value>
        public String Version
        {
            get { return _version; }
        }
    }

    /// <summary>
    /// Specifies the name of a file containing the key pair used to generate a strong name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyKeyFileAttribute : Attribute
    {
        private readonly String _keyFile;

        /// <summary>
        /// Initializes a new instance of the AssemblyKeyFileAttribute class with the name of the file containing the key pair to generate a strong name for the assembly being attributed.
        /// </summary>
        /// <param name="keyFile">The name of the file containing the key pair.</param>
        public AssemblyKeyFileAttribute(String keyFile)
        {
            _keyFile = keyFile;
        }

        /// <summary>
        /// Gets the name of the file containing the key pair used to generate a strong name for the attributed assembly.
        /// </summary>
        /// <value>
        /// A string containing the name of the file that contains the key pair.
        /// </value>
        public String KeyFile
        {
            get { return _keyFile; }
        }
    }

    /// <summary>
    /// Specifies the name of a key container within the CSP containing the key pair used to generate a strong name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyKeyNameAttribute : Attribute
    {
        private readonly String _keyName;

        /// <summary>
        /// Initializes a new instance of the AssemblyKeyNameAttribute class with the name of the container holding the key pair used to generate a strong name for the assembly being attributed.
        /// </summary>
        /// <param name="keyName">The name of the container containing the key pair.</param>
        public AssemblyKeyNameAttribute(String keyName)
        {
            _keyName = keyName;
        }

        /// <summary>
        /// Gets the name of the container having the key pair that is used to generate a strong name for the attributed assembly.
        /// </summary>
        /// <value>
        /// A string containing the name of the container that has the relevant key pair.
        /// </value>
        public String KeyName
        {
            get { return _keyName; }
        }
    }

    /// <summary>
    /// Specifies that the assembly is not fully signed when created.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyDelaySignAttribute : Attribute
    {
        private readonly bool _delaySign;

        /// <summary>
        /// Initializes a new instance of the AssemblyDelaySignAttribute class.
        /// </summary>
        /// <param name="delaySign">true if the feature this attribute represents is activated; otherwise, false.</param>
        public AssemblyDelaySignAttribute(bool delaySign)
        {
            _delaySign = delaySign;
        }

        /// <summary>
        /// Gets a value indicating the state of the attribute.
        /// </summary>
        /// <value>
        /// true if this assembly has been built as delay-signed; otherwise, false.
        /// </value>
        public bool DelaySign
        {
            get { return _delaySign; }
        }
    }

#if NANOCLR_REFLECTION
    /// <summary>
    /// Specifies a bitwise combination of AssemblyNameFlags flags for an assembly, describing just-in-time (JIT) compiler options,
    /// whether the assembly is retargetable, and whether it has a full or tokenized public key. This class cannot be inherited.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyFlagsAttribute : Attribute
    {
        private readonly AssemblyNameFlags _flags;

        /// <summary>
        /// Note: This API is now obsolete.
        /// Initializes a new instance of the AssemblyFlagsAttribute class with the specified combination of AssemblyNameFlags flags, cast as an unsigned integer value.
        /// </summary>
        /// <param name="flags">A bitwise combination of AssemblyNameFlags flags, cast as an unsigned integer value, representing just-in-time (JIT) compiler options, longevity, whether an assembly is retargetable, and whether it has a full or tokenized public key.</param>
        [CLSCompliant(false)]
        public AssemblyFlagsAttribute(uint flags)
        {
            _flags = (AssemblyNameFlags)flags;
        }

        /// <summary>
        /// Note: This API is now obsolete.
        /// Gets an unsigned integer value representing the combination of AssemblyNameFlags flags specified when this attribute instance was created.
        /// </summary>
        /// <value>
        /// An unsigned integer value representing a bitwise combination of AssemblyNameFlags flags.
        /// </value>
        [CLSCompliant(false)]
        public uint Flags
        {
            get { return (uint)_flags; }
        }

        /// <summary>
        /// Initializes a new instance of the AssemblyFlagsAttribute class with the specified combination of AssemblyNameFlags flags.
        /// </summary>
        /// <param name="assemblyFlags">A bitwise combination of AssemblyNameFlags flags representing just-in-time (JIT) compiler options, longevity, whether an assembly is retargetable, and whether it has a full or tokenized public key.</param>
        public AssemblyFlagsAttribute(AssemblyNameFlags assemblyFlags)
        {
            _flags = assemblyFlags;
        }
    }
#endif //NANOCLR_REFLECTION

    /// <summary>
    /// Instructs a compiler to use a specific version number for the Win32 file version resource. The Win32 file version is not required to be the same as the assembly's version number.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyFileVersionAttribute : Attribute
    {
        private readonly String _version;

        /// <summary>
        /// Initializes a new instance of the AssemblyFileVersionAttribute class, specifying the file version.
        /// </summary>
        /// <param name="version">The file version.</param>
        /// <exception cref="ArgumentNullException">version is null</exception>
        public AssemblyFileVersionAttribute(String version)
        {
            if (version == null) throw new ArgumentNullException("version");
            _version = version;
        }

        /// <summary>
        /// Gets the Win32 file version resource name.
        /// </summary>
        /// <value>
        /// A string containing the file version resource name.
        /// </value>
        public String Version
        {
            get { return _version; }
        }
    }

    /// <summary>
    /// Defines the required native version required for an assembly.
    /// At deploy time this is used to check if the target device has the correct native version to support this assembly.
    /// </summary>
    /// <remarks>
    /// This attribute is specific of nanoFramework.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, Inherited = false)]
    public sealed class AssemblyNativeVersionAttribute : Attribute
    {
        private readonly String _nativeVersion;

        /// <summary>
        /// Initializes a new instance of the AssemblyNativeVersionAttribute class.
        /// </summary>
        /// <param name="version">The native version required for the assembly.</param>
        public AssemblyNativeVersionAttribute(String version)
        {
            _nativeVersion = version;
        }

        /// <summary>
        /// Gets the native version required for the assembly.
        /// </summary>
        /// <value>
        /// A string containing the native version.
        /// </value>
        public String NativeVersion
        {
            get { return _nativeVersion; }
        }
    }
}
