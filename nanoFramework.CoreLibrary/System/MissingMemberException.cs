// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#if NANOCLR_REFLECTION

namespace System
{
    /// <summary>
    /// The exception that is thrown when there is an attempt to dynamically access a class member that does not exist.
    /// </summary>
    [Serializable]
    public class MissingMemberException : MemberAccessException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingMemberException"/> class.
        /// </summary>
        public MissingMemberException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingMemberException"/> class with the specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MissingMemberException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MissingMemberException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public MissingMemberException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

#endif // NANOCLR_REFLECTION
