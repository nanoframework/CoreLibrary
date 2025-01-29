//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

#nullable enable
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// The exception that is thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument.
    /// </summary>
    [Serializable]
    public class ArgumentNullException : ArgumentException
    {
        // ReSharper disable InconsistentNaming
        private static readonly string ArgumentNull_Generic = "Value cannot be null.";
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentNullException"/> class.
        /// </summary>
        public ArgumentNullException(): base(ArgumentNull_Generic)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentNullException"/> class with the name of the parameter that causes this exception.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public ArgumentNullException(string? paramName) : base(ArgumentNull_Generic, paramName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentNullException"/> class with a specified error message and the exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ArgumentNullException(string? message, Exception? innerException) : base(message ?? ArgumentNull_Generic, innerException)
        {
        }

        /// <summary>
        /// Initializes an instance of the <see cref="ArgumentNullException"/> class with a specified error message and the name of the parameter that causes this exception.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        /// <param name="message">The error message that explains the reason for this exception.</param>
        public ArgumentNullException(string? paramName, string? message) : base(message ?? ArgumentNull_Generic, paramName) { }

        /// <summary>Throws an <see cref="ArgumentNullException"/> if <paramref name="argument"/> is null.</summary>
        /// <param name="argument">The reference type argument to validate as non-null.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
        public static void ThrowIfNull([NotNull] object? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
        {
            if (argument is null)
            {
                Throw(paramName);
            }
        }

        [DoesNotReturn]
        internal static void Throw(string? paramName) =>
            throw new ArgumentNullException(paramName);
    }
}
