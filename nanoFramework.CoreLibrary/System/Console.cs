//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

namespace System
{
    internal static class Console
    {
        internal static void Write(string value) => Diagnostics.Debug.WriteLineNative(value, false);

        internal static void WriteLine(string value) => Diagnostics.Debug.WriteLineNative(value, true);
    }
}
