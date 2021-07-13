//
// Copyright (c) .NET Foundation and Contributors
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

        // this field is required in the native end
#pragma warning disable 0169
        private object _stackTrace;
#pragma warning restore 0169

        /// <summary>
        /// Gets or sets HRESULT, a coded numerical value that is assigned to a specific exception.
        /// </summary>
        /// <value>The HRESULT value./// </value>
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
#if NANOCLR_REFLECTION
                if (_message == null) return "Exception was thrown: " + GetType().FullName;
#else
                if (_message == null) return "Exception was thrown";
#endif // NANOCLR_REFLECTION

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
