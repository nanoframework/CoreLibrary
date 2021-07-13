//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System
{
    /// <summary>
    /// Indicates that an enumeration can be treated as a bit field; that is, a set of flags.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum), Serializable]
    public class FlagsAttribute : Attribute
    {
    }
}
