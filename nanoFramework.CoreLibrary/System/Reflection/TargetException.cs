// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Reflection
{
    /// <summary>
    /// Represents the exception that is thrown when an attempt is made to invoke an invalid target.
    /// </summary>
    [Serializable]
    public class TargetException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TargetException"/> class with an empty message and the root cause of the exception being <see langword="null"/>.
        /// </summary>
        public TargetException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TargetException"/> class with its message string set to the given message and the root cause exception set to <see langword="null"/>.
        /// </summary>
        /// <param name="message">A <see cref="string"/> describing the reason this exception was thrown.</param>
        public TargetException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TargetException"/> class with the specified error message and a reference to the inner exception that is the root cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the root cause of the current exception. If the <paramref name="innerException"/> parameter is not a <see langword="null"/> reference, the current exception is raised in a <see langword="catch"/> block that handles the inner exception.</param>
        public TargetException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
