using System;

namespace System.Runtime.CompilerServices
{
    /// <summary>
    /// When a class is marked with <see cref="ExcludeClassAttribute"/> it will be excluded from the native stubs generated for the nanoFramework interpreter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Struct, AllowMultiple = false, Inherited = true)]
    public class ExcludeClassAttribute: Attribute
    {
    }
}
