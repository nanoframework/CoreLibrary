// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    /// <summary>
    /// The exception that is thrown for invalid casting or explicit conversion.
    /// </summary>
    [Serializable]
    public class InvalidCastException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the InvalidCastException class.
        /// </summary>
        public InvalidCastException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the InvalidCastException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        public InvalidCastException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the InvalidCastException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference (Nothing in Visual Basic), the current exception is raised in a catch block that handles the inner exception. </param>
        public InvalidCastException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
