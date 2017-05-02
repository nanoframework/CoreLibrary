//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{

    using System;
    /**
     * This attribute is attached to members that are not to be used any longer.
     * Message is some human readable explanation of what to use
     * Error indicates if the compiler should treat usage of such a method as an
     *   error. (this would be used if the actual implementation of the obsolete
     *   method's implementation had changed).
     *
     * Issue: do we need to be able to localize this message string?
     *
     */
    [Serializable(), AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum |
        AttributeTargets.Interface | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Delegate
        , Inherited = false)]
    public sealed class ObsoleteAttribute : Attribute
    {
        private String _message;
        private bool _error;

        public ObsoleteAttribute()
        {
            _message = null;
            _error = false;
        }

        public ObsoleteAttribute(String message)
        {
            _message = message;
            _error = false;
        }

        public ObsoleteAttribute(String message, bool error)
        {
            _message = message;
            _error = error;
        }

        public String Message
        {
            get { return _message; }
        }

        public bool IsError
        {
            get { return _error; }
        }

    }
}
