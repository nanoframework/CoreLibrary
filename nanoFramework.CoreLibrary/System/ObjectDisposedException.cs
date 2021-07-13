//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// The exception that is thrown when an operation is performed on a disposed object.
    /// </summary>
    [Serializable]
    public class ObjectDisposedException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the ObjectDisposedException class.
        /// </summary>
        public ObjectDisposedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ObjectDisposedException class with a string containing the name of the disposed object.
        /// </summary>
        /// <param name="message">A string containing the name of the disposed object.</param>
        public ObjectDisposedException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ObjectDisposedException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If innerException is not  null reference (Nothing in Visual Basic), the current exception is raised in a catch block that handles the inner exception.</param>
        public ObjectDisposedException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
