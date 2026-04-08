// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// The exception that is thrown when one of the arguments provided to a method is not valid.
    /// </summary>
    [Serializable]
    public class ArgumentException : SystemException
    {
        // ReSharper disable InconsistentNaming
        private static readonly string Arg_ArgumentException = "Value does not fall within the expected range.";
        private static readonly string Arg_ParamName_Name = "(Parameter '{0}')";
        private static readonly string Argument_EmptyString = "The value cannot be an empty string.";
        // ReSharper restore InconsistentNaming

        private readonly string? _paramName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentException"/> class.
        /// </summary>
        public ArgumentException() : base(Arg_ArgumentException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ArgumentException(string? message) : base(message ?? Arg_ArgumentException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ArgumentException(string? message, Exception? innerException) : base(message ?? Arg_ArgumentException, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentException"/> class with a specified error message and the name of the parameter that causes this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        public ArgumentException(string? message, string? paramName) : base(message ?? Arg_ArgumentException)
        {
            _paramName = paramName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentException"/> class with a specified error message, the parameter name, and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the current exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ArgumentException(string? message, string? paramName, Exception? innerException) : base(message ?? Arg_ArgumentException, innerException)
        {
            _paramName = paramName;
        }

        /// <summary>
        /// Gets the error message and the parameter name, or only the error message if no parameter name is set.
        /// </summary>
        /// <value>
        /// A text string describing the details of the exception.
        /// </value>
        public override string Message
        {
            get
            {
                var s = base.Message;
                if (!string.IsNullOrEmpty(_paramName))
                {
                    s += " " + string.Format(Arg_ParamName_Name, _paramName);
                }

                return s;
            }
        }

        /// <summary>
        /// Gets the name of the parameter that causes this exception.
        /// </summary>
        /// <value>The parameter name.</value>
        public virtual string? ParamName => _paramName;

        /// <summary>Throws an exception if <paramref name="argument"/> is null or empty.</summary>
        /// <param name="argument">The string argument to validate as non-null and non-empty.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> is empty.</exception>
        public static void ThrowIfNullOrEmpty([NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
        {
            if (string.IsNullOrEmpty(argument))
            {
                ThrowNullOrEmptyException(argument, paramName);
            }
        }

        /* TODO: Implement when string.IsNullOrWhiteSpace exists
        /// <summary>Throws an exception if <paramref name="argument"/> is null, empty, or consists only of white-space characters.</summary>
        /// <param name="argument">The string argument to validate.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
        /// <exception cref="ArgumentNullException"><paramref name="argument"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="argument"/> is empty or consists only of white-space characters.</exception>
        public static void ThrowIfNullOrWhiteSpace([NotNull] string? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                ThrowNullOrWhiteSpaceException(argument, paramName);
            }
        }
        */

        [DoesNotReturn]
        private static void ThrowNullOrEmptyException(string? argument, string? paramName)
        {
            ArgumentNullException.ThrowIfNull(argument, paramName);
            throw new ArgumentException(Argument_EmptyString, paramName);
        }

        /* TODO: Implement when string.IsNullOrWhiteSpace exists
        [DoesNotReturn]
        private static void ThrowNullOrWhiteSpaceException(string? argument, string? paramName)
        {
            ArgumentNullException.ThrowIfNull(argument, paramName);
            throw new ArgumentException(SR.Argument_EmptyOrWhiteSpaceString, paramName);
        }
        */
    }
}
