// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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

#if NANOCLR_REFLECTION

#nullable enable

    /// <summary>
    /// Defines a generalized comparison method that a value type or class implements to create a type-specific comparison method for ordering or sorting its instances.
    /// </summary>
    /// <typeparam name="T">
    /// The type of object to compare. This type parameter is contravariant. That is, you can use either the type you specified or any type that is less derived.
    /// </typeparam>
    public interface IComparable<in T> where T : allows ref struct
    {
        // Interface does not need to be marked with the serializable attribute

        /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// <para>A value that indicates the relative order of the objects being compared. The return value has these meanings:</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <description>Meaning</description>
        /// </listheader>
        /// <item>
        /// <term>Less than zero</term>
        /// <description>This instance precedes <paramref name="other" /> in the sort order.</description>
        /// </item>
        /// <item>
        /// <term>Zero</term>
        /// <description>This instance occurs in the same position in the sort order as <paramref name="other" />.</description>
        /// </item>
        /// <item>
        /// <term>Greater than zero</term>
        /// <description>This instance follows <paramref name="other" /> in the sort order.</description>
        /// </item>
        /// </list>
        /// </returns>
        int CompareTo(T? other);
    }

#endif

}
