//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Runtime.CompilerServices;

    /// <summary>
    /// Represents errors that occur during application execution.
    /// </summary>
    [Serializable]
    public class Exception
    {
        private readonly string _message;
        private readonly Exception _innerException;

        private object _stackTrace;
        protected int HResult;

        /// <summary>
        /// Initializes a new instance of the Exception class.
        /// </summary>
        public Exception()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        public Exception(String message)
        {
            _message = message;
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
        public Exception(String message, Exception innerException)
        {
            _message = message;
            _innerException = innerException;
        }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        /// <value>
        /// The error message that explains the reason for the exception, or an empty string("").
        /// </value>
        public virtual String Message
        {
            get
            {
                if (_message == null) return "Exception was thrown: " + GetType().FullName;

                return _message;
            }
        }

        /// <summary>
        /// Gets the Exception instance that caused the current exception.
        /// </summary>
        /// <value>
        /// An instance of Exception that describes the error that caused the current exception. The InnerException property returns the same value as was passed into the constructor, or a null reference (Nothing in Visual Basic) if the inner exception value was not supplied to the constructor. This property is read-only.
        /// </value>
        public Exception InnerException
        {
            get { return _innerException; }
        }

        /// <summary>
        /// Gets a string representation of the immediate frames on the call stack.
        /// </summary>
        /// <value>
        /// A string that describes the immediate frames of the call stack.
        /// </value>
        public virtual extern String StackTrace
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Creates and returns a string representation of the current exception.
        /// </summary>
        /// <returns>A string representation of the current exception.</returns>
        public override String ToString()
        {
            var message = Message;
            var s = base.ToString();

            if (message != null && message.Length > 0)
            {
                s += ": " + message;
            }

            return s;
        }

    }

}
