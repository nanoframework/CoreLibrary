//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false), Serializable]
    public sealed class CLSCompliantAttribute : Attribute
    {
        private bool m_compliant;

        public CLSCompliantAttribute(bool isCompliant)
        {
            m_compliant = isCompliant;
        }

        public bool IsCompliant
        {
            get
            {
                return m_compliant;
            }
        }
    }
}
