//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{

    using System;
    /**
     * Defines an interface indicating that an object may be cloned.  Only objects
     * that implement <i>ICloneable</i> may be cloned. The interface defines a single
     * method which is called to create a clone of the object.   Object defines a method
     * <i>MemberwiseClone</i> to support default clone operations.
     *
     * @see System.Object
     */
    public interface ICloneable
    {
        // Interface does not need to be marked with the serializable attribute
        /**
         * Make a new object which is a copy of the object instanced.  This object may be either
         * deep copy or a shallow copy depending on the implementation of clone.  The default
         * Object support for clone does a shallow copy.
         *
         * @return A new object that represents a clone of the object.
         */
        Object Clone();
    }
}
