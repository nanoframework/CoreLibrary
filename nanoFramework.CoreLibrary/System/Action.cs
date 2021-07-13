//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Encapsulates a method that has no parameters and does not return a value.
    /// </summary>
    public delegate void Action();

    /// <summary>
    /// Encapsulates a method that has a single parameter and does not return a value.
    /// </summary>
    /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.
    /// This type parameter is covariant.That is, you can use either the type you specified or any type that is more derived.For more information about covariance and contravariance, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance">Covariance and Contravariance in Generics</see>.</typeparam>
    /// <param name="obj">The parameter of the method that this delegate encapsulates.</param>
    public delegate void Action<in T>(T obj);

    /// <summary>
    /// Encapsulates a method that has a single parameter and does not return a value.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.
    /// This type parameter is covariant.That is, you can use either the type you specified or any type that is more derived.For more information about covariance and contravariance, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance">Covariance and Contravariance in Generics</see>.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.
    /// This type parameter is covariant.That is, you can use either the type you specified or any type that is more derived.For more information about covariance and contravariance, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance">Covariance and Contravariance in Generics</see>.</typeparam>
    /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
    public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);

    /// <summary>
    /// Encapsulates a method that has no parameters and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
    /// </summary>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.
    /// This type parameter is covariant.That is, you can use either the type you specified or any type that is more derived.For more information about covariance and contravariance, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance">Covariance and Contravariance in Generics</see>.</typeparam>
    /// <returns>The return value of the method that this delegate encapsulates.</returns>
    public delegate TResult Func<out TResult>();

    /// <summary>
    /// Encapsulates a method that has one parameter and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
    /// </summary>
    /// <typeparam name="T">The type of the parameter of the method that this delegate encapsulates.
    /// This type parameter is covariant.That is, you can use either the type you specified or any type that is more derived.For more information about covariance and contravariance, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance">Covariance and Contravariance in Generics</see>.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.
    /// This type parameter is covariant.That is, you can use either the type you specified or any type that is more derived.For more information about covariance and contravariance, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance">Covariance and Contravariance in Generics</see>.</typeparam>
    /// <param name="arg">The parameter of the method that this delegate encapsulates.</param>
    /// <returns>The return value of the method that this delegate encapsulates.</returns>
    public delegate TResult Func<in T, out TResult>(T arg);

    /// <summary>
    /// Encapsulates a method that has one parameter and returns a value of the type specified by the <typeparamref name="TResult"/> parameter.
    /// </summary>
    /// <typeparam name="T1">The type of the parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="T2">The type of the parameter of the method that this delegate encapsulates.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.
    /// This type parameter is covariant.That is, you can use either the type you specified or any type that is more derived.For more information about covariance and contravariance, see <see href="https://docs.microsoft.com/en-us/dotnet/standard/generics/covariance-and-contravariance">Covariance and Contravariance in Generics</see>.</typeparam>
    /// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
    /// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
    /// <returns>The return value of the method that this delegate encapsulates.</returns>
    public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
}
