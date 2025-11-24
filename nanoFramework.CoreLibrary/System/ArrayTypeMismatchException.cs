// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    /// <summary>
    /// The exception that is thrown when an attempt is made to store an element of the wrong type within an array.
    /// </summary>
    [Serializable]
    public class ArrayTypeMismatchException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayTypeMismatchException"/> class.
        /// </summary>
        public ArrayTypeMismatchException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayTypeMismatchException"/> class with a specified error message.
        /// </summary>
        /// <param name="message"></param>
        public ArrayTypeMismatchException(string? message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayTypeMismatchException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ArrayTypeMismatchException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
