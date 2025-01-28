//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System.Runtime.CompilerServices;

namespace System.Reflection
{
    [AttributeUsage(AttributeTargets.Field)]
    [ExcludeFromStubs]
    internal sealed class FieldNoReflectionAttribute : Attribute
    {
    }
}
