// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#pragma warning disable CA1066 // Implement IEquatable when overriding Object.Equals
#nullable enable

namespace System
{
    // Because we have special type system support that says a boxed Nullable<T>
    // can be used where a boxed T is used, Nullable<T> can not implement any interfaces
    // at all (since T may not).
    //
    // Do NOT add any interfaces to Nullable!

    /// <summary>
    /// Represents a value type that can be assigned <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The underlying value type of the <see cref="Nullable{T}"/> generic type.</typeparam>
    [Serializable]
    public partial struct Nullable<T> where T : struct
    {
        // Do not rename (binary serialization)
        private readonly bool hasValue;
        // Do not rename (binary serialization) or make readonly (can be mutated in ToString, etc.)
        internal T value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Nullable{T}"/> structure to the specified value.
        /// </summary>
        /// <param name="value">A value type.</param>
        /// <remarks>
        /// The <see cref="Nullable{T}"/> constructor initializes the HasValue property of the new <see cref="Nullable{T}"/> object to <see langword="true"/>, and the Value property to the value of the <paramref name="value"/> parameter.
        /// </remarks>
        public Nullable(T value)
        {
            this.value = value;
            hasValue = true;
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="Nullable{T}"/> object has a valid value of its underlying type.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the current <see cref="Nullable{T}"/> object has a value; <see langword="false"/> if the current <see cref="Nullable{T}"/> object has no <see cref="value"/>.
        /// </returns>
        public readonly bool HasValue
        {
            get => hasValue;
        }

        /// <summary>
        /// Gets the value of the current <see cref="Nullable{T}"/> object if it has been assigned a valid underlying value.
        /// </summary>
        /// <returns>
        /// The value of the current <see cref="Nullable{T}"/> object if the <see cref="HasValue"/> property is <see langword="true"/>. An exception is thrown if the <see cref="HasValue"/> property is <see langword="false"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">The <see cref="HasValue"/> property is <see langword="false"/>.</exception>
        public readonly T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new InvalidOperationException();
                }
                return value;
            }
        }

        /// <summary>
        /// Retrieves the value of the current <see cref="Nullable{T}"/> object, or the default value of the underlying type.
        /// </summary>
        /// <returns>The value of the <see cref="Value"/> property if the <see cref="HasValue"/> property is <see langword="true"/>; otherwise, the default value of the underlying type.</returns>
        /// <remarks>
        /// The <see cref="GetValueOrDefault()"/> method returns a value even if the <see cref="HasValue"/> property is <see langword="false"/> (unlike the <see cref="Value"/> property, which throws an exception). If the <see cref="HasValue"/> property is <see langword="false"/>, the method returns the default value of the underlying type.
        /// </remarks>
        public readonly T GetValueOrDefault() => value;

        /// <summary>
        /// Retrieves the value of the current <see cref="Nullable{T}"/> object, or the specified default value.
        /// </summary>
        /// <param name="defaultValue">A value to return if the <see cref="HasValue"/> property is <see langword="false"/>.</param>
        /// <returns>The value of the <see cref="Value"/> property if the <see cref="HasValue"/> property is <see langword="true"/>; otherwise, the default value of the underlying type.</returns>
        /// <remarks>
        /// The <see cref="GetValueOrDefault(T)"/> method returns a value even if the <see cref="HasValue"/> property is <see langword="false"/> (unlike the <see cref="Value"/> property, which throws an exception). If the <see cref="HasValue"/> property is <see langword="false"/>, the method returns the default value of the underlying type.
        /// </remarks>
        public readonly T GetValueOrDefault(T defaultValue) =>
            hasValue ? value : defaultValue;

        /// <inheritdoc />
        public override bool Equals(object? other)
        {
            if (!hasValue)
            {
                return other == null;
            }

            if (other == null)
            {
                return false;
            }

            return value.Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode() => hasValue ? value.GetHashCode() : 0;

        /// <inheritdoc />
        public override string? ToString() => hasValue ? value.ToString() : "";

        /// <summary>
        /// Creates a new <see cref="Nullable{T}"/> object initialized to a specified value.
        /// </summary>
        /// <param name="value">A value type.</param>
        /// <returns>A <see cref="Nullable{T}"/> object whose <see cref="Value"/> property is initialized with the value parameter.</returns>
        public static implicit operator T?(T value) =>
            new T?(value);

        /// <summary>
        /// Defines an explicit conversion of a <see cref="Nullable{T}"/> instance to its underlying value.
        /// </summary>
        /// <param name="value">A nullable value.</param>
        /// <returns>The value of the <see cref="Value"/> property of the <paramref name="value"/> parameter.</returns>
        public static explicit operator T(T? value) => value!.Value;
    }

    /// <summary>
    /// Supports a value type that can be assigned <see langword="null"/>. This class cannot be inherited.
    /// </summary>
    public static class Nullable
    {
        //public static int Compare<T>(T? n1, T? n2) where T : struct
        //{
        //    if (n1.HasValue)
        //    {
        //        if (n2.HasValue) return Comparer<T>.Default.Compare(n1.value, n2.value);
        //        return 1;
        //    }
        //    if (n2.HasValue) return -1;
        //    return 0;
        //}

        //public static bool Equals<T>(T? n1, T? n2) where T : struct
        //{
        //    if (n1.HasValue)
        //    {
        //        if (n2.HasValue) return EqualityComparer<T>.Default.Equals(n1.value, n2.value);
        //        return false;
        //    }
        //    if (n2.HasValue) return false;
        //    return true;
        //}

        /// <summary>
        /// Returns the underlying type argument of the specified nullable type.
        /// </summary>
        /// <param name="nullableType">A <see cref="Type"/> object that describes a closed generic nullable type.</param>
        /// <returns>The type argument of the <paramref name="nullableType"/> parameter, if the <paramref name="nullableType"/> parameter is a closed generic nullable type; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="nullableType"/> is <see langword="null"/>.</exception>
        // If the type provided is not a Nullable Type, return null.
        // Otherwise, return the underlying type of the Nullable type
        public static Type? GetUnderlyingType(Type nullableType)
        {
            ArgumentNullException.ThrowIfNull(nullableType);

            if (nullableType.IsGenericType && !nullableType.IsGenericTypeDefinition)
            {
                // Instantiated generic type only
                Type genericType = nullableType.GetGenericTypeDefinition();

                if (ReferenceEquals(genericType, typeof(Nullable<>)))
                {
                    return nullableType.GetGenericArguments()[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves a readonly reference to the location in the <see cref="Nullable{T}"/> instance where the value is stored.
        /// </summary>
        /// <typeparam name="T">The underlying value type of the <see cref="Nullable{T}"/> generic type.</typeparam>
        /// <param name="nullable">The readonly reference to the input <see cref="Nullable{T}"/> value.</param>
        /// <returns>A readonly reference to the location where the instance's <typeparamref name="T"/> value is stored. If the instance's <see cref="Nullable{T}.HasValue"/> is false, the current value at that location may be the default value.</returns>
        /// <remarks>
        /// As the returned readonly reference refers to data that is stored in the input <paramref name="nullable"/> value, this method should only ever be
        /// called when the input reference points to a value with an actual location and not an "rvalue" (an expression that may appear on the right side but not left side of an assignment). That is, if this API is called and the input reference
        /// called when the input reference points to a value with an actual location and not an "rvalue" (an expression that may appear on the right side but not left side of an assignment). That is, if this API is called and the input reference
        /// points to a value that is produced by the compiler as a defensive copy or a temporary copy, the behavior might not match the desired one.
        /// </remarks>
        public static ref readonly T GetValueRefOrDefaultRef<T>(ref readonly T? nullable)
            where T : struct
        {
            return ref nullable.value;
        }
    }
}
