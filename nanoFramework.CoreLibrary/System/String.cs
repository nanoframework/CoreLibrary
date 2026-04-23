// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// Represents text as a sequence of UTF-16 code units.
    /// </summary>
    [Serializable]
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    // GetHashCode() implementation is provided by general native function CLR_RT_HeapBlock::GetHashCode //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////
#pragma warning disable S1206 // "Equals(Object)" and "GetHashCode()" should be overridden in pairs
    public sealed class String : IComparable, IEnumerable
#pragma warning restore S1206 // "Equals(Object)" and "GetHashCode()" should be overridden in pairs
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        /// <summary>
        /// **Not supported in NanoFramework**  
        /// Return an enumerator that iterate on each char of the string.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection.</returns>
        public IEnumerator GetEnumerator()
        {
            // Not implemented because of assembly size constraint
            // Throw a NotSupportedException in compliance with .NET practices 
            // (no message to preserve assembly size/memory consumption)
            // See https://docs.microsoft.com/en-us/dotnet/api/system.notsupportedexception 
            throw new NotSupportedException();
        }

        /// <summary>
        /// Represents the empty string. This field is read-only.
        /// </summary>
        public static readonly string Empty = "";

        /// <summary>
        /// Determines whether this instance and a specified object, which must also be a String object, have the same value.
        /// </summary>
        /// <param name="obj">The string to compare to this instance.</param>
        /// <returns>true if obj is a String and its value is the same as this instance; otherwise, false. If obj is null, the method returns false.</returns>
        public override bool Equals(object obj)
        {
            var s = obj as string;
            return s != null && Equals(this, s);
        }

        /// <summary>
        /// Determines whether two specified String objects have the same value.
        /// </summary>
        /// <param name="a">The first string to compare, or null.</param>
        /// <param name="b">The second string to compare, or null.</param>
        /// <returns><see langword="true"/> if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, false. If both <paramref name="a"/> and <paramref name="b"/> are <see langword="null"/>, the method returns <see langword="true"/>.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool Equals(string a, string b);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool Equals(string a, string b);
#endif

        /// <summary>
        /// Determines whether two specified strings have the same value.
        /// </summary>
        /// <param name="a">The first string to compare, or null.</param>
        /// <param name="b">The second string to compare, or null.</param>
        /// <returns><see langword="true"/> if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, <see langword="false"/>.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool operator ==(string? a, string? b);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool operator ==(string a, string b);
#endif

        /// <summary>
        /// Determines whether two specified strings have different values.
        /// </summary>
        /// <param name="a">The first string to compare, or null.</param>
        /// <param name="b">The second string to compare, or null.</param>
        /// <returns><see langword="true"/> if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise, <see langword="false"/>.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool operator !=(string? a, string? b);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool operator !=(string a, string b);
#endif

        /// <summary>
        /// Gets the <see cref="char"/> object at a specified position in the current <see cref="string"/> object.
        /// </summary>
        /// <value>The object at position index.</value>
        /// <param name="index">A position in the current string.</param>
        [IndexerName("Chars")]
        public extern char this[int index]
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        internal char GetCharByIndex(int index)
        {
            return this[index];
        }

        /// <summary>
        /// Copies the characters in this instance to a Unicode character array.
        /// </summary>
        /// <returns>A Unicode character array whose elements are the individual characters of this instance. If this instance is an empty string, the returned array is empty and has a zero length.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern char[] ToCharArray();

        /// <summary>
        /// Copies the characters in a specified substring in this instance to a Unicode character array.
        /// </summary>
        /// <param name="startIndex">The starting position of a substring in this instance.</param>
        /// <param name="length">The length of the substring in this instance.</param>
        /// <returns>A Unicode character array whose elements are the length number of characters in this instance starting from character position <paramref name="startIndex"/>.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern char[] ToCharArray(int startIndex, int length);

        /// <summary>
        /// Gets the number of characters in the current String object.
        /// </summary>
        /// <value>
        /// The number of characters in the current string.
        /// </value>
        public extern int Length
        {
            [MethodImpl(MethodImplOptions.InternalCall)]
            get;
        }

        /// <summary>
        /// Splits a string into substrings that are based on the characters in an array.
        /// </summary>
        /// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by one or more characters in <paramref name="separator"/>.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string[] Split(params char[]? separator);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string[] Split(params char[] separator);
#endif

        /// <summary>
        /// Splits a string into a maximum number of substrings based on the characters in an array. You also specify the maximum number of substrings to return.
        /// </summary>
        /// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <returns>An array whose elements contain the substrings in this instance that are delimited by one or more characters in <paramref name="separator"/></returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string[] Split(char[]? separator, int count);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string[] Split(char[] separator, int count);
#endif

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.
        /// </summary>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <returns>A string that is equivalent to the substring that begins at <paramref name="startIndex"/> in this instance, or <see cref="Empty"/> if <paramref name="startIndex"/> is equal to the length of this instance.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string Substring(int startIndex);

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
        /// </summary>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>A string that is equivalent to the substring of length <paramref name="length"/> that begins at <paramref name="startIndex"/> in this instance, or <see cref="Empty"/> if <paramref name="startIndex"/> is equal to the length of this instance and length is zero.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string Substring(int startIndex, int length);

        /// <summary>
        /// Removes all leading and trailing white-space characters from the current string.
        /// </summary>
        /// <returns>The string that remains after all white-space characters are removed from the start and end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string Trim();

#if NANOCLR_REFLECTION

#nullable enable

        /// <summary>
        /// Removes all the leading occurrences of a set of characters specified in an array from the current string.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
        /// <returns>The string that remains after all occurrences of characters in the <paramref name="trimChars"/> parameter are removed from the start of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string Trim(params char[]? trimChars);

        /// <summary>
        /// Removes all the leading occurrences of a set of characters specified in an array from the current string.
        /// </summary>
        /// <returns>The string that remains after all occurrences of characters in the trimChars parameter are removed from the start of the current string. If trimChars is null or an empty array, white-space characters are removed instead.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string TrimStart();

        /// <summary>
        /// Removes all the leading occurrences of a set of characters specified in an array from the current string.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
        /// <returns>The string that remains after all occurrences of characters in the <paramref name="trimChars"/> parameter are removed from the start of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string TrimStart(params char[]? trimChars);

        /// <summary>
        /// Removes all the trailing occurrences of a set of characters specified in an array from the current string.
        /// </summary>
        /// <returns>The string that remains after all white-space characters are removed from the end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string TrimEnd();

        /// <summary>
        /// Removes all the trailing occurrences of a set of characters specified in an array from the current string.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
        /// <returns>The string that remains after all occurrences of the characters in the <paramref name="trimChars"/> parameter are removed from the end of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, Unicode white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string TrimEnd(params char[]? trimChars);

#nullable restore

#else

        /// <summary>
        /// Removes all leading and trailing occurrences of a set of characters specified in an array from the current String object.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        /// <returns>The string that remains after all occurrences of the characters in the trimChars parameter are removed from the start and end of the current string.
        /// If trimChars is null or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, 
        /// the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string Trim(params char[] trimChars);

        /// <summary>
        /// Removes all the leading occurrences of a set of characters specified in an array from the current string.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
        /// <returns>The string that remains after all occurrences of characters in the <paramref name="trimChars"/> parameter are removed from the start of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string TrimStart(params char[] trimChars);

        /// <summary>
        /// Removes all the trailing occurrences of a set of characters specified in an array from the current string.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or <see langword="null"/>.</param>
        /// <returns>The string that remains after all occurrences of the characters in the <paramref name="trimChars"/> parameter are removed from the end of the current string. If <paramref name="trimChars"/> is <see langword="null"/> or an empty array, Unicode white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string TrimEnd(params char[] trimChars);

#endif

        /// <summary>
        /// Initializes a new instance of the String class to the value indicated by an array of Unicode characters, a starting character position within that array, and a length.
        /// </summary>
        /// <param name="value">An array of Unicode characters. </param>
        /// <param name="startIndex">The starting position within value. </param>
        /// <param name="length">The number of characters within value to use. </param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String(char[] value, int startIndex, int length);

        /// <summary>
        /// Initializes a new instance of the String class to the value indicated by an array of Unicode characters.
        /// </summary>
        /// <param name="value">An array of Unicode characters.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String(char[] value);

        /// <summary>
        /// Initializes a new instance of the String class to the value indicated by a specified Unicode character repeated a specified number of times.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <param name="count">The number of times c occurs.</param>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String(char c, int count);

        /// <summary>
        /// Compares two specified String objects and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="strA">The first string to compare.</param>
        /// <param name="strB">The second string to compare.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the lexical relationship between the two comparands.
        /// <para>Less than zero : <paramref name="strA"/> precedes <paramref name="strB"/> in the sort order.</para>
        /// <para>Zero : <paramref name="strA"/> occurs in the same position as <paramref name="strB"/> in the sort order.</para>
        /// <para>Greater than zero : <paramref name="strA"/> follows <paramref name="strB"/> in the sort order.</para>
        /// </returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int Compare(string? strA, string? strB);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int Compare(string strA, string strB);
#endif

        /// <summary>
        /// Compares this instance with a specified <see cref="object"/> and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified <see cref="object"/>.
        /// </summary>
        /// <param name="value">An object that evaluates to a <see cref="string"/>.</param>
        /// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the <paramref name="value"/> parameter.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int CompareTo(object? value);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int CompareTo(object value);
#endif

        /// <summary>
        /// Compares this instance with a specified <see cref="string"/> object and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified string.
        /// </summary>
        /// <param name="strB">The string to compare with this instance.</param>
        /// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the <paramref name="strB"/> parameter.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int CompareTo(string? strB);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int CompareTo(string strB);
#endif

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this string.
        /// </summary>
        /// <param name="value">A Unicode character to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(char value);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this string. The search starts at a specified character position.
        /// </summary>
        /// <param name="value">A Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the string if that character is found, or -1 if it is not.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(char value, int startIndex);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified character in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="value">A Unicode character to seek. </param>
        /// <param name="startIndex">The search starting position. </param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(char value, int startIndex, int count);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="Empty"/>, the return value is 0.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(string value);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance. The search starts at a specified character position.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> from the start of the current instance if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="Empty"/>, the return value is <paramref name="startIndex"/>.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(string value, int startIndex);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of value from the start of the current instance if that string is found, or -1 if it is not. If value is String.Empty, the return value is startIndex.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(string value, int startIndex, int count);

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOfAny(char[] anyOf);

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in anyOf was found; -1 if no character in anyOf was found.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOfAny(char[] anyOf, int startIndex);

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOfAny(char[] anyOf, int startIndex, int count);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified Unicode character within this instance.
        /// </summary>
        /// <param name="value">The Unicode character to seek.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(char value);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified Unicode character within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The starting position of the search. The search proceeds from <paramref name="startIndex"/> toward the beginning of this instance.</param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not found or if the current instance equals <see cref="Empty"/>.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(char value, int startIndex);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of the specified Unicode character in a substring within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string for a specified number of character positions.
        /// </summary>
        /// <param name="value">The Unicode character to seek. </param>
        /// <param name="startIndex">The starting position of the search. The search proceeds from <paramref name="startIndex"/> toward the beginning of this instance.</param>
        /// <param name="count">The number of character positions to examine. </param>
        /// <returns>The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not found or if the current instance equals <see cref="Empty"/>.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(char value, int startIndex, int count);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <returns>The index position of the last occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOfAny(char[] anyOf);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <returns>The index position of the last occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found or if the current instance equals <see cref="Empty"/>.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOfAny(char[] anyOf, int startIndex);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and proceeds backward toward the beginning of the string for a specified number of character positions.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The index position of the last occurrence in this instance where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found or if the current instance equals <see cref="Empty"/>.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOfAny(char[] anyOf, int startIndex, int count);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified string within this instance.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based starting index position of <paramref name="value"/> if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="Empty"/>, the return value is the last index position in this instance.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(string value);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified string within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <returns>The zero-based starting index position of <paramref name="value"/> if that string is found, or -1 if it is not found or if the current instance equals <see cref="Empty"/>. If <paramref name="value"/> is <see cref="Empty"/>, the return value is the smaller of <paramref name="startIndex"/> and the last index position in this instance.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(string value, int startIndex);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified string within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string for a specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based starting index position of <paramref name="value"/> if that string is found, or -1 if it is not found or if the current instance equals <see cref="Empty"/>. If <paramref name="value"/> is <see cref="Empty"/>, the return value is the smaller of <paramref name="startIndex"/> and the last index position in this instance.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(string value, int startIndex, int count);

        /// <summary>
        /// Returns a copy of this string converted to lowercase.
        /// </summary>
        /// <returns>A string in lowercase.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string ToLower();

        /// <summary>
        /// Returns a copy of this string converted to uppercase.
        /// </summary>
        /// <returns>The uppercase equivalent of the current string.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern string ToUpper();

        /// <summary>
        /// Returns this instance of String; no actual conversion is performed.
        /// </summary>
        /// <returns>The current string.</returns>
        public override string ToString()
        {
            return this;
        }

        /// <summary>
        /// Creates the string representation of a specified object.
        /// </summary>
        /// <param name="arg0">The object to represent, or null.</param>
        /// <returns>The string representation of the value of arg0, or String.Empty if arg0 is null.</returns>
        public static string Concat(object arg0)
        {
            return arg0 == null ? Empty : arg0.ToString();
        }

        /// <summary>
        /// Concatenates the string representations of two specified objects.
        /// </summary>
        /// <param name="arg0">The first object to concatenate.</param>
        /// <param name="arg1">The second object to concatenate.</param>
        /// <returns>The concatenated string representations of the values of arg0 and arg1.</returns>
        public static string Concat(object arg0, object arg1)
        {
            arg0 ??= Empty;

            arg1 ??= Empty;

            return Concat(arg0.ToString(), arg1.ToString());
        }

        /// <summary>
        /// Concatenates the string representations of three specified objects.
        /// </summary>
        /// <param name="arg0">The first object to concatenate.</param>
        /// <param name="arg1">The second object to concatenate.</param>
        /// <param name="arg2">The third object to concatenate.</param>
        /// <returns>The concatenated string representations of the values of arg0, arg1 and arg2.</returns>
        public static string Concat(object arg0, object arg1, object arg2)
        {
            arg0 ??= Empty;
            arg1 ??= Empty;
            arg2 ??= Empty;

            return Concat(arg0.ToString(), arg1.ToString(), arg2.ToString());
        }

        /// <summary>
        /// Concatenates the string representations of the elements in a specified Object array.
        /// </summary>
        /// <param name="args">An object array that contains the elements to concatenate.</param>
        /// <returns>The concatenated string representations of the values of the elements in args.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Concat(params object[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            int length = args.Length;
            string[] sArgs = new string[length];

            for (int i = 0; i < length; i++)
            {
                sArgs[i] = args[i] == null ? Empty : args[i].ToString();
            }

            return Concat(sArgs);
        }

        /// <summary>
        /// Concatenates two specified instances of <see cref="string"/>.
        /// </summary>
        /// <param name="str0">The first string to concatenate.</param>
        /// <param name="str1">The second string to concatenate.</param>
        /// <returns>The concatenation of <paramref name="str0"/> and <paramref name="str1"/>.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Concat(string? str0, string? str1);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Concat(string str0, string str1);
#endif

        /// <summary>
        /// Concatenates three specified instances of <see cref="string"/>.
        /// </summary>
        /// <param name="str0">The first string to concatenate.</param>
        /// <param name="str1">The second string to concatenate.</param>
        /// <param name="str2">The third string to concatenate.</param>
        /// <returns>The concatenation of <paramref name="str0"/>, <paramref name="str1"/> and <paramref name="str2"/>.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Concat(string? str0, string? str1, string? str2);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Concat(string str0, string str1, string str2);
#endif

        /// <summary>
        /// Concatenates four specified instances of <see cref="string"/>.
        /// </summary>
        /// <param name="str0">The first string to concatenate.</param>
        /// <param name="str1">The second string to concatenate.</param>
        /// <param name="str2">The third string to concatenate.</param>
        /// <param name="str3">The fourth string to concatenate.</param>
        /// <returns>The concatenation of str0, str1, str2 and str3.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Concat(string? str0, string? str1, string? str2, string? str3);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Concat(string str0, string str1, string str2, string str3);
#endif

        /// <summary>
        /// Concatenates the elements of a specified <see cref="string"/> array.
        /// </summary>
        /// <param name="values">An array of string instances.</param>
        /// <returns>The concatenated elements of <paramref name="values"/>.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Concat(params string?[] values);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Concat(params string[] values);
#endif

        /// <summary>
        /// Retrieves the system's reference to the specified <see cref="string"/>.
        /// </summary>
        /// <param name="str">A string to search for in the intern pool.</param>
        /// <returns>The system's reference to <paramref name="str"/>, if it is interned; otherwise, a new reference to a string with the value of <paramref name="str"/>.</returns>
        public static string Intern(string str)
        {
            return str;
        }

        /// <summary>
        /// Retrieves a reference to a specified <see cref="string"/>.
        /// </summary>
        /// <param name="str">The string to search for in the intern pool.</param>
        /// <returns>A reference to <paramref name="str"/> if it is in the common language runtime intern pool; otherwise, <see langword="null"/>.</returns>
        public static string IsInterned(string str)
        {
            return str;
        }

        /// <summary>
        /// Replaces the format items in a string with the string representations of corresponding objects in a specified array.
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of <paramref name="format"/> in which the format items have been replaced by the string representation of the corresponding objects in <paramref name="args"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
#if NANOCLR_REFLECTION

#nullable enable
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Format(string format, params object?[] args);
#nullable restore

#else
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern string Format(string format, params object[] args);
#endif

        /// <summary>
        /// Returns a new string that right-aligns the characters in this instance by padding them on the left with a specified Unicode character, for a specified total length.
        /// </summary>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <param name="paddingChar">A Unicode padding character.</param>
        /// <returns>A new string that is equivalent to this instance, but right-aligned and padded on the left with as many <paramref name="paddingChar"/> characters as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
        public string PadLeft(int totalWidth, char paddingChar = ' ')
        {
            if (totalWidth < 0)
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            }

            if (Length >= totalWidth)
            {
                return this;
            }
            else
            {
                return new string(paddingChar, totalWidth - Length) + this;
            }
        }

        /// <summary>
        /// Returns a new string that left-aligns the characters in this string by padding them on the right with a specified Unicode character, for a specified total length.
        /// </summary>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <param name="paddingChar">A Unicode padding character.</param>
        /// <returns>A new string that is equivalent to this instance, but left-aligned and padded on the right with as many <paramref name="paddingChar"/> characters as needed to create a length of <paramref name="totalWidth"/>. However, if <paramref name="totalWidth"/> is less than the length of this instance, the method returns a reference to the existing instance. If <paramref name="totalWidth"/> is equal to the length of this instance, the method returns a new string that is identical to this instance.</returns>
        public string PadRight(int totalWidth, char paddingChar = ' ')
        {
            if (totalWidth < 0)
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentOutOfRangeException();
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            }

            if (Length >= totalWidth)
            {
                return this;
            }
            else
            {
                return this + new string(paddingChar, totalWidth - Length);
            }
        }

        /// <summary>
        /// Indicates whether the specified string is <see langword="null"/> or an empty string ("").
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns><see langword="true"/> if the value parameter is <see langword="null"/> or an empty string (""); otherwise, <see langword="false"/>.</returns>
#if NANOCLR_REFLECTION

#nullable enable
        public static bool IsNullOrEmpty([NotNullWhen(false)] string? value)
#nullable restore

#else
        public static bool IsNullOrEmpty(string value)
#endif
        {
            return value == null || value.Length == 0;
        }

        /// <summary>
        /// Returns a value indicating whether a specified substring occurs within this string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns><see langword="true"/> if the <paramref name="value"/> parameter occurs within this string, or if <paramref name="value"/> is the empty string (""); otherwise, <see langword="false"/>.</returns>
        public bool Contains(string value)
        {
            if (value == Empty)
            {
                return true;
            }

            return IndexOf(value) >= 0;
        }

        /// <summary>
        /// Determines whether the beginning of this string instance matches the specified string.
        /// </summary>
        /// <param name="value">The string to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> matches the beginning of this string; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        public bool StartsWith(string value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if ((object)this == value)
            {
                return true;
            }

            if (value.Length == 0)
            {
                return true;
            }

            if (Length < value.Length)
            {
                return false;
            }

            return Compare(
                Substring(0, value.Length),
                value) == 0;
        }

        /// <summary>
        /// Determines whether the end of this string instance matches the specified string.
        /// </summary>
        /// <param name="value">The string to compare to the substring at the end of this instance.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> matches the end of this instance; otherwise, <see langword="false"/>.</returns>
        public bool EndsWith(string value)
        {
            ArgumentNullException.ThrowIfNull(value);

            if ((object)this == value)
            {
                return true;
            }

            if (value.Length == 0)
            {
                return true;
            }

            return Length >= value.Length
                   && (Compare(
                       Substring(Length - value.Length),
                       value) == 0);
        }
    }
}
