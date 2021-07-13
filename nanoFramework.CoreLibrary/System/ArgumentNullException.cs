//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System
{
    /// <summary>
    /// The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.
    /// </summary>
    [Serializable]
    public class ArgumentNullException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the ArgumentNullException class.
        /// </summary>
        public ArgumentNullException()
        { }

        /// <summary>
        /// Initializes a new instance of the ArgumentNullException class with the name of the parameter that causes this exception.
        /// </summary>
        /// <param name="argument">The name of the parameter that caused the exception.</param>
        public ArgumentNullException(string argument) : base(null, argument) { }

        /// <summary>
        /// Initializes an instance of the ArgumentNullException class with a specified error message and the name of the parameter that causes this exception.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception. </param>
        /// <param name="message">A message that describes the error. </param>
        public ArgumentNullException(String paramName, String message) : base(message, paramName) { }
    }
}
