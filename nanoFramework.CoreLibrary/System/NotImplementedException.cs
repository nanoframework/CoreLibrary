// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    /// <summary>
    /// The exception that is thrown when a requested method or operation is not implemented.
    /// </summary>
    [Serializable]
    public class NotImplementedException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the NotImplementedException class with default properties.
        /// </summary>
        public NotImplementedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the NotImplementedException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public NotImplementedException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NotImplementedException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the inner parameter is not null, the current exception is raised in a catch block that handles the inner exception.</param>
        public NotImplementedException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
