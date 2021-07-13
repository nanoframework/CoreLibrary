//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// The exception that is thrown when an invoked method is not supported, or when there is an attempt to read, seek, or write to a stream that does not support the invoked functionality.
    /// </summary>
    [Serializable]
    public class NotSupportedException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the NotSupportedException class, setting the Message property of the new instance to a system-supplied message that describes the error. This message takes into account the current system culture.
        /// </summary>
        public NotSupportedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the NotSupportedException class with a specified error message.
        /// </summary>
        /// <param name="message">A String that describes the error. The content of message is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
        public NotSupportedException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NotSupportedException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public NotSupportedException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
