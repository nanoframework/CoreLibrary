//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System
{
    /// <summary>
    /// The exception that is thrown when there is an attempt to dereference a null object reference.
    /// </summary>
    [Serializable]
    public class NullReferenceException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the NullReferenceException class, setting the Message property of the new instance to a system-supplied message that describes the error, such as "The value 'null' was found where an instance of an object was required." This message takes into account the current system culture.
        /// </summary>
        public NullReferenceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the NullReferenceException class with a specified error message.
        /// </summary>
        /// <param name="message">A String that describes the error. The content of message is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
        public NullReferenceException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NullReferenceException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not null, the current exception is raised in a catch block that handles the inner exception.</param>
        public NullReferenceException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
