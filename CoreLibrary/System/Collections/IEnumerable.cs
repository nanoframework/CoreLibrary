//
// Copyright (c) 2017 The nanoFramework project contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System.Collections
{
    using System;
    //
    // Implement this interface if you need to support VB's foreach semantics.
    // Also, COM classes that support an enumerator will also implement this interface.
   ///
    public interface IEnumerable
    {
      // Interfaces are not serializable
      //
      // Returns an IEnumerator for this enumerable Object.  The enumerator provides
      // a simple way to access all the contents of a collection.
       ///
        IEnumerator GetEnumerator();
    }
}


