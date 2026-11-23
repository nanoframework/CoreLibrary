// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Reflection
{
    /// <summary>
    /// The exception that is thrown when the number of parameters for an invocation does not match the number expected.
    /// </summary>
    [Serializable]
    public class TargetParameterCountException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TargetParameterCountException"/> class with an empty message string and the root cause of the exception being <see langword="null"/>.
        /// </summary>
        public TargetParameterCountException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TargetParameterCountException"/> class with its message string set to the given message and the root cause exception set to <see langword="null"/>.
        /// </summary>
        /// <param name="message">A <see cref="string"/> describing the reason this exception was thrown.</param>
        public TargetParameterCountException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TargetParameterCountException"/> class with the specified error message and a reference to the inner exception that is the root cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the root cause of the current exception. If the <paramref name="innerException"/> parameter is not a <see langword="null"/> reference, the current exception is raised in a <see langword="catch"/> block that handles the inner exception.</param>
        public TargetParameterCountException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
