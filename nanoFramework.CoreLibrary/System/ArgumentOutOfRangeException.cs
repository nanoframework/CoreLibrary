// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System
{
    /// <summary>
    /// The exception that is thrown when the value of an argument is outside the allowable range of values as defined by the invoked method.
    /// </summary>
    [Serializable]
    public class ArgumentOutOfRangeException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the ArgumentOutOfRangeException class.
        /// </summary>
        public ArgumentOutOfRangeException()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ArgumentOutOfRangeException class with the name of the parameter that causes this exception.
        /// </summary>
        /// <param name="paramName">The name of the parameter that causes this exception.</param>
        public ArgumentOutOfRangeException(String paramName)
            : base(null, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ArgumentOutOfRangeException class with the name of the parameter that causes this exception and a specified error message.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception. </param>
        /// <param name="message">The message that describes the error. </param>
        public ArgumentOutOfRangeException(String paramName, String message)
            : base(message, paramName)
        {
        }

        // We will not use this in the classlibs, but we'll provide it for
        // anyone that's really interested so they don't have to stick a bunch
        // of printf's in their code.

        // Gets the value of the argument that caused the exception.
        // Note - we don't set this anywhere in the class libraries in
        // version 1, but it might come in handy for other developers who
        // want to avoid sticking printf's in their code.

    }
}
