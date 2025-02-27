// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Marks the program elements that are no longer in use. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Struct, Inherited = false)]
    [ExcludeType]
    [Serializable]
    public sealed class ObsoleteAttribute : Attribute
    {
        private readonly String _message;
        private readonly bool _error;

        /// <summary>
        /// Initializes a new instance of the ObsoleteAttribute class with default properties.
        /// </summary>
        public ObsoleteAttribute()
        {
            _message = null;
            _error = false;
        }

        /// <summary>
        /// Initializes a new instance of the ObsoleteAttribute class with a specified workaround message.
        /// </summary>
        /// <param name="message">The text string that describes alternative workarounds.</param>
        public ObsoleteAttribute(String message)
        {
            _message = message;
            _error = false;
        }

        /// <summary>
        /// Initializes a new instance of the ObsoleteAttribute class with a workaround message and a Boolean value indicating whether the obsolete element usage is considered an error.
        /// </summary>
        /// <param name="message">The text string that describes alternative workarounds.</param>
        /// <param name="error">true if the obsolete element usage generates a compiler error; false if it generates a compiler warning.</param>
        public ObsoleteAttribute(String message, bool error)
        {
            _message = message;
            _error = error;
        }

        /// <summary>
        /// Gets the workaround message, including a description of the alternative program elements.
        /// </summary>
        /// <value>
        /// The workaround text string.
        /// </value>
        public String Message
        {
            get { return _message; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether the compiler will treat usage of the obsolete program element as an error.
        /// </summary>
        /// <value>true if the obsolete element usage is considered an error; otherwise, false. The default is false.</value>
        public bool IsError
        {
            get { return _error; }
        }

    }
}
