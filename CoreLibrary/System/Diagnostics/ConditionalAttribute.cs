//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using System;

namespace System.Diagnostics
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true), Serializable]
    public sealed class ConditionalAttribute : Attribute
    {
        public ConditionalAttribute(String conditionString)
        {
            m_conditionString = conditionString;
        }

        public String ConditionString
        {
            get
            {
                return m_conditionString;
            }
        }

        private String m_conditionString;
    }
}


