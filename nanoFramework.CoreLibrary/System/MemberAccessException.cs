// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

namespace System
{
    /// <summary>
    /// The exception that is thrown when an attempt to access a class member fails.
    /// </summary>
    [Serializable]
    public class MemberAccessException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberAccessException"/> class.
        /// </summary>
        public MemberAccessException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberAccessException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MemberAccessException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberAccessException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public MemberAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

#endif // NANOCLR_REFLECTION
