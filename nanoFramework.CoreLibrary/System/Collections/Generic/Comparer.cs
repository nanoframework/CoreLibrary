// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#nullable enable

namespace System.Collections.Generic
{
    ///// <summary>
    ///// Provides a base class for implementations of the IComparer{T} generic interface.
    ///// </summary>
    ///// <typeparam name="T">The type of objects to compare.</typeparam>
    //[Serializable]
    //public abstract partial class Comparer<T> : IComparer, IComparer<T>
    //{
    //    protected Comparer()
    //    {

    //    }
    //    //public static Comparer<T> Create(Comparison<T> comparison)
    //    //{
    //    //    ArgumentNullException.ThrowIfNull(comparison);

    //    //    return new ComparisonComparer<T>(comparison);
    //    //}

    //    /// <summary>
    //    /// Returns a default sort-order comparer for the type specified by the generic argument.
    //    /// </summary>
    //    /// <value>
    //    /// An object that inherits <see cref="Comparer"/>{T} and serves as a sort-order comparer for type {T}.
    //    /// </value>
    //    public static extern Comparer<T> Default
    //    {
    //        [MethodImpl(MethodImplOptions.InternalCall)]
    //        get;
    //    }

    //    public abstract int Compare(T? x, T? y);

    //    int IComparer.Compare(object? x, object? y)
    //    {
    //        if (x == null)
    //        {
    //            return y == null ? 0 : -1;
    //        }

    //        if (y == null)
    //        {
    //            return 1;
    //        }

    //        if (x is T && y is T)
    //        {
    //            return Compare((T)x, (T)y);
    //        }

    //        throw new ArgumentException();
    //    }
    //}

    //internal sealed class ComparisonComparer<T> : Comparer<T>
    //{
    //    private readonly Comparison<T> _comparison;

    //    public ComparisonComparer(Comparison<T> comparison)
    //    {
    //        _comparison = comparison;
    //    }

    //    public override int Compare(T? x, T? y) => _comparison(x!, y!);
    //}

    // Note: although there is a lot of shared code in the following
    // comparers, we do not incorporate it into a base class for perf
    // reasons. Adding another base class (even one with no fields)
    // means another generic instantiation, which can be costly esp.
    // for value types.
    //[Serializable]
    // Needs to be public to support binary serialization compatibility
    //public sealed partial class GenericComparer<T> : Comparer<T> where T : IComparable<T>?
    //{
    //    public override int Compare(T? x, T? y)
    //    {
    //        if (x != null)
    //        {
    //            if (y != null)
    //            {
    //                return x.CompareTo(y);
    //            }

    //            return 1;
    //        }
    //        if (y != null)
    //        {
    //            return -1;
    //        }

    //        return 0;
    //    }

    //    // Equals method for the comparer itself.
    //    public override bool Equals([NotNullWhen(true)] object? obj) =>
    //        obj != null && GetType() == obj.GetType();

    //    public override int GetHashCode() =>
    //        GetType().GetHashCode();
    //}

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //[Serializable]
    //public sealed class NullableComparer<T> : Comparer<T?> where T : struct
    //{
    //    public NullableComparer() { }

    //    public override int Compare(T? x, T? y)
    //    {
    //        if (x.HasValue)
    //        {
    //            if (y.HasValue)
    //            {
    //                return Comparer<T>.Default.Compare(x.value, y.value);
    //            }

    //            return 1;
    //        }

    //        if (y.HasValue)
    //        {
    //            return -1;
    //        }

    //        return 0;
    //    }

    //    // Equals method for the comparer itself.
    //    public override bool Equals([NotNullWhen(true)] object? obj) =>
    //        obj != null && GetType() == obj.GetType();

    //    public override int GetHashCode() =>
    //        GetType().GetHashCode();
    //}

    //[Serializable]
    //public sealed partial class ObjectComparer<T> : Comparer<T>
    //{
    //    public override int Compare(T? x, T? y)
    //    {
    //        return Default.Compare(x, y);
    //    }

    //    // Equals method for the comparer itself.
    //    public override bool Equals([NotNullWhen(true)] object? obj) =>
    //        obj != null && GetType() == obj.GetType();

    //    public override int GetHashCode() =>
    //        GetType().GetHashCode();
    //}

    //[Serializable]
    //internal sealed partial class EnumComparer<T> : Comparer<T> where T : struct, Enum
    //{
    //    public EnumComparer() { }

    //    public override int Compare(T x, T y)
    //    {
    //        // TODO: native?
    //        throw new NotImplementedException();
    //    }

    //    // Equals method for the comparer itself.
    //    public override bool Equals([NotNullWhen(true)] object? obj) =>
    //        obj != null && GetType() == obj.GetType();

    //    public override int GetHashCode() =>
    //        GetType().GetHashCode();
    //}
}
