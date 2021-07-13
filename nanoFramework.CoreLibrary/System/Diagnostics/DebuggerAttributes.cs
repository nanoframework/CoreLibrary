//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Diagnostics
{
    using System;

    /// <summary>
    /// Identifies a type or member that is not part of the user code for an application.
    /// </summary>
    /// <remarks>
    /// Designer provided types and members that are not part of the code specifically created by the user can complicate the debugging experience. This attribute suppresses the display of these adjunct types and members in the debugger window and automatically steps through, rather than into, designer provided code. When the debugger encounters this attribute when stepping through user code, the user experience is to not see the designer provided code and to step to the next user-supplied code statement.
    /// The debugger behaviour when the <see cref="DebuggerNonUserCodeAttribute"/> is present is similar to using a combination of the <see cref="DebuggerHiddenAttribute"/> attribute, which hides the code from the debugger, and the <see cref="DebuggerStepThroughAttribute"/> attribute, which tells the debugger to step through, rather than into, the code it is applied to.
    /// </remarks>
    [Serializable, AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
    public sealed class DebuggerStepThroughAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebuggerNonUserCodeAttribute"/> class.
        /// </summary>
        public DebuggerStepThroughAttribute() { }
    }

    /// <summary>
    /// Indicates the code following the attribute is to be executed in run, not step, mode.
    /// </summary>
    /// <remarks>
    /// The <see cref="DebuggerStepperBoundaryAttribute"/> attribute is used as an escape from the effect of a <see cref="DebuggerNonUserCodeAttribute"/>. When executing within the boundaries of the <see cref="DebuggerNonUserCodeAttribute"/>, designer-provided code is executed as a step-through until the next user supplied code is encountered. When context switches are made on a thread, the next user-supplied code module stepped into may not relate to the code that was in the process of being debugged. To avoid this debugging experience, use the <see cref="DebuggerStepperBoundaryAttribute"/> to escape from stepping through code to running code. For example, in Visual Studio 2005, encountering a <see cref="DebuggerStepperBoundaryAttribute"/> while stepping through code using the F10 key (or Step Over command) has the same effect as pressing the F5 key or using the Start Debugging command.
    /// </remarks>
    [Serializable, AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, Inherited = false)]
    public sealed class DebuggerStepperBoundaryAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebuggerStepperBoundaryAttribute"/> class.
        /// </summary>
        public DebuggerStepperBoundaryAttribute() { }
    }

    /// <summary>
    /// Specifies the DebuggerHiddenAttribute. This class cannot be inherited.
    /// </summary>
    /// <remarks>
    /// The common language runtime attaches no semantics to this attribute. It is provided for use by source code debuggers. For example, the Visual Studio 2005 debugger does not stop in a method marked with this attribute and does not allow a breakpoint to be set in the method. Other debugger attributes recognized by the Visual Studio 2005 debugger are the <see cref="DebuggerNonUserCodeAttribute"/> and the <see cref="DebuggerStepThroughAttribute"/>. 
    /// </remarks>
    [Serializable, AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Constructor, Inherited = false)]
    public sealed class DebuggerHiddenAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebuggerHiddenAttribute"/> class.
        /// </summary>
        public DebuggerHiddenAttribute() { }
    }

    /// <summary>
    /// Identifies a type or member that is not part of the user code for an application.
    /// </summary>
    /// <remarks>
    /// Designer provided types and members that are not part of the code specifically created by the user can complicate the debugging experience. This attribute suppresses the display of these adjunct types and members in the debugger window and automatically steps through, rather than into, designer provided code. When the debugger encounters this attribute when stepping through user code, the user experience is to not see the designer provided code and to step to the next user-supplied code statement. 
    /// The debugger behaviour when the <see cref="DebuggerNonUserCodeAttribute"/> is present is similar to using a combination of the <see cref="DebuggerHiddenAttribute"/> attribute, which hides the code from the debugger, and the <see cref="DebuggerStepThroughAttribute"/> attribute, which tells the debugger to step through, rather than into, the code it is applied to.
    /// </remarks>
    [Serializable, AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Constructor | AttributeTargets.Struct, Inherited = false)]
    public sealed class DebuggerNonUserCodeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebuggerNonUserCodeAttribute"/> class.
        /// </summary>
        public DebuggerNonUserCodeAttribute() { }
    }

    // Attribute class used by the compiler to mark modules.
    // If present, then debugging information for everything in the
    // assembly was generated by the compiler, and will be preserved
    // by the Runtime so that the debugger can provide full functionality
    // in the case of JIT attach. If not present, then the compiler may
    // or may not have included debugging information, and the Runtime
    // won't preserve the debugging info, which will make debugging after
    // a JIT attach difficult.
    /// <summary>
    /// Modifies code generation for runtime just-in-time (JIT) debugging. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module)]
    public sealed class DebuggableAttribute : Attribute
    {
        /// <summary>
        /// Specifies the debugging mode for the just-in-time (JIT) compiler.
        /// </summary>
        [Flags]
        public enum DebuggingModes
        {
            /// <summary>
            /// Starting with the .NET Framework version 2.0, JIT tracking information is always generated, and this flag has the same effect as Default,
            /// except that it sets the DebuggableAttribute.IsJITTrackingEnabled property to false. However, because JIT tracking is always enabled, 
            /// the property value is ignored in version 2.0 or later.
            /// Note that, unlike the None flag, the None flag cannot be used to disable JIT optimizations.
            /// </summary>
            None = 0x0,

            /// <summary>
            /// Instructs the just-in-time (JIT) compiler to use its default behaviour, which includes enabling optimizations, disabling Edit and Continue support,
            /// and using symbol store sequence points if present. Starting with the .NET Framework version 2.0, JIT tracking information, the Microsoft intermediate
            /// language (MSIL) offset to the native-code offset within a method, is always generated.
            /// </summary>
            Default = 0x1,

            /// <summary>
            /// Disable optimizations performed by the compiler to make your output file smaller, faster, and more efficient. Optimizations result in code rearrangement
            /// in the output file, which can make debugging difficult. Typically optimization should be disabled while debugging. In versions 2.0 or later, combine this
            /// value with Default (Default | DisableOptimizations) to enable JIT tracking and disable optimizations.
            /// </summary>
            DisableOptimizations = 0x100,

            /// <summary>
            /// Use the implicit MSIL sequence points, not the program database (PDB) sequence points. The symbolic information normally includes at least one 
            /// Microsoft intermediate language (MSIL) offset for each source line. When the just-in-time (JIT) compiler is about to compile a method, it asks 
            /// the profiling services for a list of MSIL offsets that should be preserved. These MSIL offsets are called sequence points.
            /// </summary>
            IgnoreSymbolStoreSequencePoints = 0x2,

            /// <summary>
            /// Enable edit and continue. Edit and continue enables you to make changes to your source code while your program is in break mode. The ability to edit and continue is compiler dependent.
            /// </summary>
            EnableEditAndContinue = 0x4
        }

        private readonly DebuggingModes _debuggingModes;

        /// <summary>
        /// Initializes a new instance of the DebuggableAttribute class, using the specified tracking and optimization options for the just-in-time (JIT) compiler.
        /// </summary>
        /// <param name="isJITTrackingEnabled">true to enable debugging; otherwise, false.</param>
        /// <param name="isJITOptimizerDisabled">true to disable the optimizer for execution; otherwise, false.</param>
        public DebuggableAttribute(bool isJITTrackingEnabled, bool isJITOptimizerDisabled)
        {
            _debuggingModes = 0;

            if (isJITTrackingEnabled) _debuggingModes |= DebuggingModes.Default;
            if (isJITOptimizerDisabled) _debuggingModes |= DebuggingModes.DisableOptimizations;
        }

        /// <summary>
        /// Initializes a new instance of the DebuggableAttribute class, using the specified debugging modes for the just-in-time (JIT) compiler.
        /// </summary>
        /// <param name="modes">A bitwise combination of the DebuggableAttribute.DebuggingModes values specifying the debugging mode for the JIT compiler.</param>
        public DebuggableAttribute(DebuggingModes modes)
        {
            _debuggingModes = modes;
        }

        /// <summary>
        /// Gets a value that indicates whether the runtime will track information during code generation for the debugger.
        /// </summary>
        /// <value>true if the runtime will track information during code generation for the debugger; otherwise, false.</value>
        public bool IsJITTrackingEnabled
        {
            get { return (_debuggingModes & DebuggingModes.Default) != 0; }
        }

        /// <summary>
        /// Gets a value that indicates whether the runtime optimizer is disabled.
        /// </summary>
        /// <value>true if the runtime optimizer is disabled; otherwise, false.</value>
        public bool IsJITOptimizerDisabled
        {
            get { return (_debuggingModes & DebuggingModes.DisableOptimizations) != 0; }
        }

        /// <summary>
        /// Gets the debugging modes for the attribute.
        /// </summary>
        /// <value>A bitwise combination of the DebuggableAttribute.DebuggingModes values describing the debugging mode for the just-in-time (JIT) compiler. The default is Default.</value>
        public DebuggingModes DebuggingFlags
        {
            get { return _debuggingModes; }
        }
    }

    /// <summary>
    /// Provides display instructions for the debugger.
    /// </summary>
    public enum DebuggerBrowsableState
    {
        /// <summary>
        /// Never show the element.
        /// </summary>
        Never = 0,
        /// <summary>
        /// Show the element as collapsed.
        /// </summary>
        Collapsed = 2,
        /// <summary>
        /// Do not display the root element; display the child elements if the element is a collection or array of items.
        /// </summary>
        RootHidden = 3
    }

    /// <summary>
    /// Determines if and how a member is displayed in the debugger variable windows. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class DebuggerBrowsableAttribute : Attribute
    {
        private readonly DebuggerBrowsableState _state;

        /// <summary>
        /// Initializes a new instance of the DebuggerBrowsableAttribute class.
        /// </summary>
        /// <param name="state">One of the DebuggerBrowsableState values that specifies how to display the member.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public DebuggerBrowsableAttribute(DebuggerBrowsableState state)
        {
            if (state < DebuggerBrowsableState.Never || state > DebuggerBrowsableState.RootHidden) throw new ArgumentOutOfRangeException("state");

            _state = state;
        }

        /// <summary>
        /// Gets the display state for the attribute.
        /// </summary>
        /// <value>One of the DebuggerBrowsableState values.</value>
        public DebuggerBrowsableState State
        {
            get { return _state; }
        }
    }

#if NANOCLR_REFLECTION

    /// <summary>
    /// Specifies the display proxy for a type.
    /// </summary>
    /// <remarks>Available only in mscorlib build with support for System.Reflection.</remarks>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class DebuggerTypeProxyAttribute : Attribute
    {
        private readonly string _typeName;
        private string _targetName;
        private Type _target;

        /// <summary>
        /// Initializes a new instance of the DebuggerTypeProxyAttribute class using the type of the proxy.
        /// </summary>
        /// <param name="type">The proxy type.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public DebuggerTypeProxyAttribute(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");

            _typeName = type.FullName + "," + type.Assembly.FullName;
        }

        /// <summary>
        /// Initializes a new instance of the DebuggerTypeProxyAttribute class using the type name of the proxy.
        /// </summary>
        /// <param name="typeName">The type name of the proxy type.</param>
        public DebuggerTypeProxyAttribute(string typeName)
        {
            _typeName = typeName;
        }

        /// <summary>
        /// Gets the type name of the proxy type.
        /// </summary>
        /// <value>The type name of the proxy type.</value>
        public string ProxyTypeName
        {
            get { return _typeName; }
        }

        /// <summary>
        /// Gets or sets the target type for the attribute.
        /// </summary>
        /// <value>The target type for the attribute.</value>
        /// <exception cref="System.ArgumentNullException">Target is set to null.</exception>
        public Type Target
        {
            set
            {
                if (value == null) throw new ArgumentNullException("value");

#pragma warning disable S4275 // Getters and setters should access the expected fields
                _targetName = value.FullName + "," + value.Assembly.FullName;
#pragma warning restore S4275 // Getters and setters should access the expected fields
                _target = value;
            }

            get { return _target; }
        }

#pragma warning disable S2292 // Trivial properties should be auto-implemented
        /// <summary>
        /// Gets or sets the name of the target type.
        /// </summary>
        /// <value>
        /// The name of the target type.
        /// </value>
        public string TargetTypeName
#pragma warning restore S2292 // Trivial properties should be auto-implemented
        {
            get { return _targetName; }
            set { _targetName = value; }

        }
    }

    // This attribute is used to control what is displayed for the given class or field
    // in the data windows in the debugger.  The single argument to this attribute is
    // the string that will be displayed in the value column for instances of the type.
    // This string can include text between { and } which can be either a field,
    // property or method (as will be documented in mscorlib).  In the C# case,
    // a general expression will be allowed which only has implicit access to the this pointer
    // for the current instance of the target type. The expression will be limited,
    // however: there is no access to aliases, locals, or pointers.
    // In addition, attributes on properties referenced in the expression are not processed.
    /// <summary>
    /// Determines how a class or field is displayed in the debugger variable windows.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class DebuggerDisplayAttribute : Attribute
    {
        private string _name;
        private readonly string _value;
        private string _type;
        private string _targetName;
        private Type _target;

        /// <summary>
        /// Initializes a new instance of the DebuggerDisplayAttribute class.
        /// </summary>
        /// <param name="value">The string to be displayed in the value column for instances of the type; an empty string ("") causes the value column to be hidden.</param>
        public DebuggerDisplayAttribute(string value)
        {
            if (value == null) _value = "";
            else _value = value;

            _name = "";
            _type = "";
        }

        /// <summary>
        /// Gets the string to display in the value column of the debugger variable windows.
        /// </summary>
        /// <value>The string to display in the value column of the debugger variable.</value>
        public string Value
        {
            get { return _value; }
        }

#pragma warning disable S2292 // Trivial properties should be auto-implemented
        /// <summary>
        /// Gets or sets the name to display in the debugger variable windows.
        /// </summary>
        /// <value>The name to display in the debugger variable windows.</value>
        public string Name
#pragma warning restore S2292 // Trivial properties should be auto-implemented
        {
            get { return _name; }
            set { _name = value; }
        }

#pragma warning disable S2292 // Trivial properties should be auto-implemented
        /// <summary>
        /// Gets or sets the string to display in the type column of the debugger variable windows.
        /// </summary>
        /// <value>The string to display in the type column of the debugger variable windows.</value>
        public string Type
#pragma warning restore S2292 // Trivial properties should be auto-implemented
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the type of the attribute's target.
        /// </summary>
        /// <value>The attribute's target type.</value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public Type Target
        {
            set
            {
                if (value == null) throw new ArgumentNullException("value");

#pragma warning disable S4275 // Getters and setters should access the expected fields
                _targetName = value.FullName + "," + value.Assembly.FullName;
#pragma warning restore S4275 // Getters and setters should access the expected fields
                _target = value;
            }

            get { return _target; }
        }

#pragma warning disable S2292 // Trivial properties should be auto-implemented
        /// <summary>
        /// Gets or sets the type name of the attribute's target.
        /// </summary>
        /// <value>The name of the attribute's target type.</value>
        public string TargetTypeName
#pragma warning restore S2292 // Trivial properties should be auto-implemented
        {
            get { return _targetName; }
            set { _targetName = value; }
        }
    }

#endif // NANOCLR_REFLECTION

}
