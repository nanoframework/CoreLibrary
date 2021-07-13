//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    /// <summary>
    /// The exception that is thrown when one of the arguments provided to a method is not valid.
    /// </summary>
    [Serializable]
    public class ArgumentException : SystemException
    {
        private String _paramName;

        /// <summary>
        /// Initializes a new instance of the ArgumentException class.
        /// </summary>
        public ArgumentException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ArgumentException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        public ArgumentException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ArgumentException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ArgumentException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ArgumentException class with a specified error message, the parameter name, and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the current exception. </param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception. </param>
        public ArgumentException(String message, String paramName, Exception innerException)
            : base(message, innerException)
        {
            _paramName = paramName;
        }

        /// <summary>
        /// Initializes a new instance of the ArgumentException class with a specified error message and the name of the parameter that causes this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="paramName">The name of the parameter that caused the current exception. </param>
        public ArgumentException(String message, String paramName)

            : base(message)
        {
            _paramName = paramName;
        }

        /// <summary>
        /// Gets the error message and the parameter name, or only the error message if no parameter name is set.
        /// </summary>
        /// <value>
        /// A text string describing the details of the exception.
        /// </value>
        public override String Message
        {
            get
            {
                var s = base.Message;
                if (!(_paramName == null || _paramName.Length == 0))
                    return s + "\n" + "Invalid argument " + "'" + _paramName + "'";
                return s;
            }
        }

        /// <summary>
        /// Gets the name of the parameter that causes this exception.
        /// </summary>
        /// <value>
        /// The parameter name.
        /// </value>
        public virtual String ParamName
        {
            get { return _paramName; }
        }

    }
}
