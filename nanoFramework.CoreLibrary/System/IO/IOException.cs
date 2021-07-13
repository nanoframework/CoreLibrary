//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.IO
{
    /// <summary>
    /// The exception that is thrown when an I/O error occurs.
    /// </summary>
    [Serializable]
    public class IOException : SystemException
    {
        /// <summary>
        /// Provides values for error codes.
        /// </summary>
        public enum IOExceptionErrorCode
        {
            /// <summary>
            /// Others
            /// </summary>
            Others = unchecked((int)0xE0000000), // CLR_E_FILE_IO
            /// <summary>
            /// Invalid driver
            /// </summary>
            InvalidDriver = unchecked((int)0xE1000000), // CLR_E_INVALID_DRIVER
            /// <summary>
            /// File not found
            /// </summary>
            FileNotFound = unchecked((int)0xE2000000), // CLR_E_FILE_NOT_FOUND
            /// <summary>
            /// Directory not found
            /// </summary>
            DirectoryNotFound = unchecked((int)0xE3000000), // CLR_E_DIRECTORY_NOT_FOUND
            /// <summary>
            /// Volume not found
            /// </summary>
            VolumeNotFound = unchecked((int)0xE4000000), // CLR_E_VOLUME_NOT_FOUND
            /// <summary>
            /// Path too long
            /// </summary>
            PathTooLong = unchecked((int)0xE5000000), // CLR_E_PATH_TOO_LONG
            /// <summary>
            /// Directory not empty
            /// </summary>
            DirectoryNotEmpty = unchecked((int)0xE6000000), // CLR_E_DIRECTORY_NOT_EMPTY
            /// <summary>
            /// Unauthorized access
            /// </summary>
            UnauthorizedAccess = unchecked((int)0xE7000000), // CLR_E_UNAUTHORIZED_ACCESS
            /// <summary>
            /// Path already exists
            /// </summary>
            PathAlreadyExists = unchecked((int)0xE8000000), // CLR_E_PATH_ALREADY_EXISTS
            /// <summary>
            /// Too many open handles
            /// </summary>
            TooManyOpenHandles = unchecked((int)0xE9000000), // CLR_E_TOO_MANY_OPEN_HANDLES
        }

        /// <summary>
        /// Initializes a new instance of the IOException class with its message string set to the empty string (""), its HRESULT set to COR_E_IO, and its inner exception set to a null reference.
        /// </summary>
        public IOException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the IOException class with its message string set to message, its HRESULT set to COR_E_IO, and its inner exception set to  null reference (Nothing in Visual Basic).
        /// </summary>
        /// <param name="message">A String that describes the error. The content of message is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture. </param>
        public IOException(String message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the IOException class with its message string set to message and its HRESULT user-defined.
        /// </summary>
        /// <param name="message">A String that describes the error. The content of message is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture. </param>
        /// <param name="hresult">An integer identifying the error that has occurred. </param>
        public IOException(String message, int hresult)
            : base(message)
        {
            HResult = hresult;
        }

        /// <summary>
        /// Initializes a new instance of the IOException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. </param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not  null reference (Nothing in Visual Basic), the current exception is raised in a catch block that handles the inner exception. </param>
        public IOException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// The error code associated with this IOException object.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        public IOExceptionErrorCode ErrorCode
        {
            get { return (IOExceptionErrorCode)HResult; }
        }
    }
}
