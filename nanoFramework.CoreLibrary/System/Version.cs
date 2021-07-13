//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// Represents the version number of an assembly, operating system, or the common language runtime. This class cannot be inherited.
    /// </summary>
    public sealed class Version // : ICloneable, IComparable, IComparable<Version>, IEquatable<Version>
    {
        // AssemblyName depends on the order staying the same
        private readonly int _Major;
        private readonly int _Minor;
        private readonly int _Build = -1;
        private readonly int _Revision = -1;

        /// <summary>
        /// Initializes a new instance of the Version class with the specified major, minor, build, and revision numbers.
        /// </summary>
        /// <param name="major">The major version number.</param>
        /// <param name="minor">The minor version number.</param>
        /// <param name="build">The build number.</param>
        /// <param name="revision">The revision number.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Version(int major, int minor, int build, int revision)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (major < 0 || minor < 0 || revision < 0 || build < 0) throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            _Major = major;
            _Minor = minor;
            _Revision = revision;
            _Build = build;
        }

        /// <summary>
        /// Initializes a new instance of the Version class using the specified major and minor values.
        /// </summary>
        /// <param name="major">The major version number.</param>
        /// <param name="minor">The minor version number.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Version(int major, int minor)
        {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (major < 0) throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            if (minor < 0) throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 

            _Major = major;
            _Minor = minor;

            // Other 2 initialize to -1 as it done on desktop and CE
            _Build = -1;
            _Revision = -1;
        }

        /// <summary>
        /// Gets the value of the major component of the version number for the current Version object.
        /// </summary>
        /// <value>The major version number.</value>
        public int Major => _Major;

        /// <summary>
        /// Gets the value of the minor component of the version number for the current Version object.
        /// </summary>
        /// <value>The minor version number.</value>
        public int Minor => _Minor;

        /// <summary>
        /// Gets the value of the revision component of the version number for the current Version object.
        /// </summary>
        /// <value>The revision version number.</value>
        public int Revision => _Revision;

        /// <summary>
        /// Gets the value of the build component of the version number for the current Version object.
        /// </summary>
        /// <value>The build version number.</value>
        public int Build => _Build;

        /// <summary>
        /// Returns a value indicating whether the current Version object is equal to a specified object.
        /// </summary>
        /// <param name="obj">An object to compare with the current Version object, or null.</param>
        /// <returns>true if the current Version object and obj are both Version objects, and every component of the current Version object matches the corresponding component of obj; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {
            if (!(obj is Version)) return false;

            var v = (Version)obj;
            // check that major, minor, build & revision numbers match
            return _Major == v._Major && _Minor == v._Minor && _Build == v._Build && _Revision == v._Revision;
        }

        /// <summary>
        /// Converts the value of the current Version object to its equivalent String representation.
        /// </summary>
        /// <returns>The String representation of the values of the major, minor, build, and revision components of the current Version object, as depicted in the following format.
        /// Each component is separated by a period character ('.'). Square brackets ('[' and ']') indicate a component that will not appear in the return value if the component is not defined:
        /// major.minor[.build[.revision]]</returns>
        public override String ToString()
        {
            var retStr = _Major + "." + _Minor;

            // Adds _Build and then _Revision if they are positive. They could be -1 in this case not added.
            if (_Build >= 0)
            {
                retStr += "." + _Build;
                if (_Revision >= 0) retStr += "." + _Revision;
            }

            return retStr;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            // Let's assume that most version numbers will be pretty small and just
            // OR some lower order bits together.

            int accumulator = 0;

            accumulator |= (_Major & 0x0000000F) << 28;
            accumulator |= (_Minor & 0x000000FF) << 20;
            accumulator |= (_Build & 0x000000FF) << 12;
            accumulator |= (_Revision & 0x00000FFF);

            return accumulator;
        }
    }
}
