//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//
namespace System
{
    /// <summary>
    /// Defines a generalized type-specific comparison method that a value type or class implements to order or sort its instances.
    /// </summary>
    public interface IComparable
    {
        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance. </param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        /// <para>Less than zero : This instance precedes obj in the sort order.</para>
        /// <para>Zero : This instance occurs in the same position in the sort order as obj.</para>
        /// <para>Greater than zero : This instance follows obj in the sort order.</para>
        /// </returns>
        int CompareTo(Object obj);
    }

}
