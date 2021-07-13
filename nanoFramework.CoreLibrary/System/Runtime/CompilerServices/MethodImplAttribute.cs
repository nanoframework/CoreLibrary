//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// Defines the details of how a method is implemented.
    /// </summary>
    [Serializable]
    public enum MethodImplOptions
    {
        /// <summary>
        /// The method is implemented in unmanaged code.
        /// </summary>
        Unmanaged = Reflection.MethodImplAttributes.Unmanaged,
        /// <summary>
        /// The method is declared, but its implementation is provided elsewhere.
        /// </summary>
        ForwardRef = Reflection.MethodImplAttributes.ForwardRef,
        /// <summary>
        /// The method signature is exported exactly as declared.
        /// </summary>
        PreserveSig = Reflection.MethodImplAttributes.PreserveSig,
        /// <summary>
        /// The call is internal, that is, it calls a method that is implemented within the common language runtime.
        /// </summary>
        InternalCall = Reflection.MethodImplAttributes.InternalCall,
        /// <summary>
        /// The method can be executed by only one thread at a time. Static methods lock on the type, whereas instance methods lock on the instance.
        /// Only one thread can execute in any of the instance functions, and only one thread can execute in any of a class's static functions.
        /// </summary>
        Synchronized = Reflection.MethodImplAttributes.Synchronized,
        /// <summary>
        /// The method cannot be inlined. Inlining is an optimization by which a method call is replaced with the method body.
        /// </summary>
        NoInlining = Reflection.MethodImplAttributes.NoInlining,
    }

    /// <summary>
    /// Defines how a method is implemented.
    /// </summary>
    [Serializable]
    public enum MethodCodeType
    {
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method implementation is in Microsoft intermediate language (MSIL).
        /// </summary>
        IL = Reflection.MethodImplAttributes.IL,
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method is implemented in native code.
        /// </summary>
        Native = Reflection.MethodImplAttributes.Native,
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method implementation is in optimized intermediate language (OPTIL).
        /// </summary>
        OPTIL = Reflection.MethodImplAttributes.OPTIL,
        /// <summary>
        /// This API supports the product infrastructure and is not intended to be used directly from your code. Specifies that the method implementation is provided by the runtime.
        /// </summary>
        Runtime = Reflection.MethodImplAttributes.Runtime
    }

    /// <summary>
    /// Specifies the details of how a method is implemented. This class cannot be inherited.
    /// </summary>
    [Serializable, AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
    public sealed class MethodImplAttribute : Attribute
    {
        internal MethodImplOptions _val;
        /// <summary>
        /// A MethodCodeType _value indicating what kind of implementation is provided for this method.
        /// </summary>
        public MethodCodeType MethodCodeType;

        /// <summary>
        /// Initializes a new instance of the MethodImplAttribute class with the specified MethodImplOptions _value.
        /// </summary>
        /// <param name="methodImplOptions">A MethodImplOptions _value specifying properties of the attributed method.</param>
        public MethodImplAttribute(MethodImplOptions methodImplOptions)
        {
            _val = methodImplOptions;
        }

        /// <summary>
        /// Initializes a new instance of the MethodImplAttribute class with the specified MethodImplOptions _value.
        /// </summary>
        /// <param name="_value">A bitmask representing the desired MethodImplOptions _value which specifies properties of the attributed method.</param>
        public MethodImplAttribute(short _value)
        {
            _val = (MethodImplOptions)_value;
        }

        /// <summary>
        /// Initializes a new instance of the MethodImplAttribute class.
        /// </summary>
        public MethodImplAttribute()
        {
        }

        /// <summary>
        /// Gets the MethodImplOptions _value describing the attributed method.
        /// </summary>
        /// <_value>
        /// The MethodImplOptions _value describing the attributed method.
        /// </_value>
        public MethodImplOptions Value { get { return _val; } }
    }

}
