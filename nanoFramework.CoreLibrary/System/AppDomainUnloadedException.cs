//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// The exception that is thrown when an attempt is made to access an unloaded application domain.
    /// </summary>
    [Serializable]
    public class AppDomainUnloadedException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the AppDomainUnloadedException class.
        /// </summary>
        public AppDomainUnloadedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AppDomainUnloadedException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AppDomainUnloadedException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AppDomainUnloadedException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public AppDomainUnloadedException(String message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
