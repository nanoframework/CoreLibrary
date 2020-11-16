//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

namespace System
{
    using Runtime.CompilerServices;
    using System.Collections;
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
            // Throw a NotSupportedException in compliance of .net practices 
            // (no message to preserve assembly size/memory consumption)
            // See https://docs.microsoft.com/en-us/dotnet/api/system.notsupportedexception 
            throw new NotSupportedException(); 
        }


        /// <summary>
        /// Represents the empty string. This field is read-only.
        /// </summary>
        public static readonly String Empty = "";
        /// <summary>
        /// Determines whether this instance and a specified object, which must also be a String object, have the same value.
        /// </summary>
        /// <param name="obj">The string to compare to this instance.</param>
        /// <returns>true if obj is a String and its value is the same as this instance; otherwise, false. If obj is null, the method returns false.</returns>
        public override bool Equals(object obj)
        {
            var s = obj as String;
            return s != null && Equals(this, s);
        }

        /// <summary>
        /// Determines whether two specified String objects have the same value.
        /// </summary>
        /// <param name="a">The first string to compare, or null.</param>
        /// <param name="b">The second string to compare, or null.</param>
        /// <returns>true if the value of a is the same as the value of b; otherwise, false. If both a and b are null, the method returns true.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool Equals(String a, String b);

        /// <summary>
        /// Determines whether two specified strings have the same value.
        /// </summary>
        /// <param name="a">The first string to compare, or null.</param>
        /// <param name="b">The second string to compare, or null.</param>
        /// <returns>true if the value of a is the same as the value of b; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool operator ==(String a, String b);

        /// <summary>
        /// Determines whether two specified strings have different values.
        /// </summary>
        /// <param name="a">The first string to compare, or null.</param>
        /// <param name="b">The second string to compare, or null.</param>
        /// <returns>true if the value of a is different from the value of b; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern bool operator !=(String a, String b);


        

        /// <summary>
        /// Gets the Char object at a specified position in the current String object.
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
        /// <returns>A Unicode character array whose elements are the length number of characters in this instance starting from character position startIndex.</returns>
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
        /// <returns>An array whose elements contain the substrings from this instance that are delimited by one or more characters in separator. For more information, see the Remarks section.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String[] Split(params char[] separator);

        /// <summary>
        /// Splits a string into a maximum number of substrings based on the characters in an array. You also specify the maximum number of substrings to return.
        /// </summary>
        /// <param name="separator">A character array that delimits the substrings in this string, an empty array that contains no delimiters, or null.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <returns>An array whose elements contain the substrings in this instance that are delimited by one or more characters in separator. For more information, see the Remarks section.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String[] Split(char[] separator, int count);

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.
        /// </summary>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <returns>A string that is equivalent to the substring that begins at startIndex in this instance, or Empty if startIndex is equal to the length of this instance.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String Substring(int startIndex);

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
        /// </summary>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>A string that is equivalent to the substring of length length that begins at startIndex in this instance, or Empty if startIndex is equal to the length of this instance and length is zero.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String Substring(int startIndex, int length);

        /// <summary>
        /// Removes all leading and trailing occurrences of a set of characters specified in an array from the current String object.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        /// <returns>The string that remains after all occurrences of the characters in the trimChars parameter are removed from the start and end of the current string.
        /// If trimChars is null or an empty array, white-space characters are removed instead. If no characters can be trimmed from the current instance, 
        /// the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String Trim(params char[] trimChars);

        /// <summary>
        /// Removes all leading occurrences of a set of characters specified in an array from the current String object.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        /// <returns>The string that remains after all occurrences of characters in the trimChars parameter are removed from the start of the current string. If trimChars is null or an empty array, white-space characters are removed instead.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String TrimStart(params char[] trimChars);

        /// <summary>
        /// Removes all trailing occurrences of a set of characters specified in an array from the current String object.
        /// </summary>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        /// <returns>The string that remains after all occurrences of the characters in the trimChars parameter are removed from the end of the current string. If trimChars is null or an empty array, Unicode white-space characters are removed instead. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String TrimEnd(params char[] trimChars);

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
        /// <returns>A 32-bit signed integer that indicates the lexical relationship between the two comparands.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern int Compare(String strA, String strB);

        /// <summary>
        /// Compares this instance with a specified Object and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified Object.
        /// </summary>
        /// <param name="value">An object that evaluates to a String.</param>
        /// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the value parameter.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int CompareTo(Object value);

        /// <summary>
        /// Compares this instance with a specified String object and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified string.
        /// </summary>
        /// <param name="strB">The string to compare with this instance.</param>
        /// <returns>A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the strB parameter.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int CompareTo(String strB);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this string.
        /// </summary>
        /// <param name="value">A Unicode character to seek.</param>
        /// <returns>The zero-based index position of value if that character is found, or -1 if it is not.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(char value);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode character in this string. The search starts at a specified character position.
        /// </summary>
        /// <param name="value">A Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of value from the start of the string if that character is found, or -1 if it is not.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(char value, int startIndex);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified character in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="value">A Unicode character to seek. </param>
        /// <param name="startIndex">The search starting position. </param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of value if that character is found, or -1 if it is not.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(char value, int startIndex, int count);

        /// <summary>
        /// Reports the zero-based index of the first occurrence in this instance of any character in a specified array of Unicode characters.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in anyOf was found; -1 if no character in anyOf was found.</returns>
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
        /// <returns>The zero-based index position of the first occurrence in this instance where any character in anyOf was found; -1 if no character in anyOf was found.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOfAny(char[] anyOf, int startIndex, int count);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based index position of value if that string is found, or -1 if it is not. If value is String.Empty, the return value is 0.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(String value);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance. The search starts at a specified character position.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>The zero-based index position of value from the start of the current instance if that string is found, or -1 if it is not. If value is String.Empty, the return value is startIndex.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(String value, int startIndex);

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based index position of value from the start of the current instance if that string is found, or -1 if it is not. If value is String.Empty, the return value is startIndex.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int IndexOf(String value, int startIndex, int count);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified Unicode character within this instance.
        /// </summary>
        /// <param name="value">The Unicode character to seek.</param>
        /// <returns>The zero-based index position of value if that character is found, or -1 if it is not.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(char value);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified Unicode character within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="value">The Unicode character to seek.</param>
        /// <param name="startIndex">The starting position of the search. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <returns>The zero-based index position of value if that character is found, or -1 if it is not found or if the current instance equals String.Empty.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(char value, int startIndex);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of the specified Unicode character in a substring within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string for a specified number of character positions.
        /// </summary>
        /// <param name="value">The Unicode character to seek. </param>
        /// <param name="startIndex">The starting position of the search. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <param name="count">The number of character positions to examine. </param>
        /// <returns>The zero-based index position of value if that character is found, or -1 if it is not found or if the current instance equals String.Empty.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(char value, int startIndex, int count);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <returns>The index position of the last occurrence in this instance where any character in anyOf was found; -1 if no character in anyOf was found.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOfAny(char[] anyOf);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <returns>The index position of the last occurrence in this instance where any character in anyOf was found; -1 if no character in anyOf was found or if the current instance equals String.Empty.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOfAny(char[] anyOf, int startIndex);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and proceeds backward toward the beginning of the string for a specified number of character positions.
        /// </summary>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The index position of the last occurrence in this instance where any character in anyOf was found; -1 if no character in anyOf was found or if the current instance equals String.Empty.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOfAny(char[] anyOf, int startIndex, int count);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified string within this instance.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <returns>The zero-based starting index position of value if that string is found, or -1 if it is not. If value is String.Empty, the return value is the last index position in this instance.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(String value);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified string within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <returns>The zero-based starting index position of value if that string is found, or -1 if it is not found or if the current instance equals String.Empty. If value is String.Empty, the return value is the smaller of startIndex and the last index position in this instance.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(String value, int startIndex);

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of a specified string within this instance. The search starts at a specified character position and proceeds backward toward the beginning of the string for a specified number of character positions.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position. The search proceeds from startIndex toward the beginning of this instance.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>The zero-based starting index position of value if that string is found, or -1 if it is not found or if the current instance equals String.Empty. If value is Empty, the return value is the smaller of startIndex and the last index position in this instance.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern int LastIndexOf(String value, int startIndex, int count);

        /// <summary>
        /// Returns a copy of this string converted to lowercase.
        /// </summary>
        /// <returns>A string in lowercase.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String ToLower();

        /// <summary>
        /// Returns a copy of this string converted to uppercase.
        /// </summary>
        /// <returns>The uppercase equivalent of the current string.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String ToUpper();

        /// <summary>
        /// Returns this instance of String; no actual conversion is performed.
        /// </summary>
        /// <returns>The current string.</returns>
        public override String ToString()
        {
            return this;
        }

        /// <summary>
        /// Removes all leading and trailing white-space characters from the current String object.
        /// </summary>
        /// <returns>The string that remains after all white-space characters are removed from the start and end of the current string. If no characters can be trimmed from the current instance, the method returns the current instance unchanged.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern String Trim();
        /// <summary>
        /// Creates the string representation of a specified object.
        /// </summary>
        /// <param name="arg0">The object to represent, or null.</param>
        /// <returns>The string representation of the value of arg0, or String.Empty if arg0 is null.</returns>
        public static String Concat(Object arg0)
        {
            return arg0 == null ? Empty : arg0.ToString();
        }

        /// <summary>
        /// Concatenates the string representations of two specified objects.
        /// </summary>
        /// <param name="arg0">The first object to concatenate.</param>
        /// <param name="arg1">The second object to concatenate.</param>
        /// <returns>The concatenated string representations of the values of arg0 and arg1.</returns>
        public static String Concat(Object arg0, Object arg1)
        {
            if (arg0 == null)
            {
                arg0 = Empty;
            }

            if (arg1 == null)
            {
                arg1 = Empty;
            }

            return Concat(arg0.ToString(), arg1.ToString());
        }

        /// <summary>
        /// Concatenates the string representations of three specified objects.
        /// </summary>
        /// <param name="arg0">The first object to concatenate.</param>
        /// <param name="arg1">The second object to concatenate.</param>
        /// <param name="arg2">The third object to concatenate.</param>
        /// <returns>The concatenated string representations of the values of arg0, arg1 and arg2.</returns>
        public static String Concat(Object arg0, Object arg1, Object arg2)
        {
            if (arg0 == null)
            {
                arg0 = Empty;
            }

            if (arg1 == null)
            {
                arg1 = Empty;
            }

            if (arg2 == null)
            {
                arg2 = Empty;
            }

            return Concat(arg0.ToString(), arg1.ToString(), arg2.ToString());
        }

        /// <summary>
        /// Concatenates the string representations of the elements in a specified Object array.
        /// </summary>
        /// <param name="args">An object array that contains the elements to concatenate.</param>
        /// <returns>The concatenated string representations of the values of the elements in args.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static String Concat(params Object[] args)
        {
            if (args == null) throw new ArgumentNullException("args");

            var length = args.Length;
            var sArgs = new String[length];

            for (var i = 0; i < length; i++)
            {
                sArgs[i] = args[i] == null ? Empty : args[i].ToString();
            }

            return Concat(sArgs);
        }

        /// <summary>
        /// Concatenates two specified instances of String.
        /// </summary>
        /// <param name="str0">The first string to concatenate.</param>
        /// <param name="str1">The second string to concatenate.</param>
        /// <returns>The concatenation of str0 and str1.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern String Concat(String str0, String str1);

        /// <summary>
        /// Concatenates three specified instances of String.
        /// </summary>
        /// <param name="str0">The first string to concatenate.</param>
        /// <param name="str1">The second string to concatenate.</param>
        /// <param name="str2">The third string to concatenate.</param>
        /// <returns>The concatenation of str0, str1 and str2.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern String Concat(String str0, String str1, String str2);

        /// <summary>
        /// Concatenates four specified instances of String.
        /// </summary>
        /// <param name="str0">The first string to concatenate.</param>
        /// <param name="str1">The second string to concatenate.</param>
        /// <param name="str2">The third string to concatenate.</param>
        /// <param name="str3">The fourth string to concatenate.</param>
        /// <returns>The concatenation of str0, str1, str2 and str3.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern String Concat(String str0, String str1, String str2, String str3);

        /// <summary>
        /// Concatenates the elements of a specified String array.
        /// </summary>
        /// <param name="values">An array of string instances.</param>
        /// <returns>The concatenated elements of values.</returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern String Concat(params String[] values);

        /// <summary>
        /// Retrieves the system's reference to the specified String.
        /// </summary>
        /// <param name="str">A string to search for in the intern pool.</param>
        /// <returns>The system's reference to str, if it is interned; otherwise, a new reference to a string with the value of str.</returns>
        public static String Intern(String str)
        {
            return str;
        }

        /// <summary>
        /// Retrieves a reference to a specified String.
        /// </summary>
        /// <param name="str">The string to search for in the intern pool.</param>
        /// <returns>A reference to str if it is in the common language runtime intern pool; otherwise, null.</returns>
        public static String IsInterned(String str)
        {
            return str;
        }

        /// <summary>
        /// Replaces the format items in a string with the string representations of corresponding objects in a specified array.
        /// </summary>
        /// <param name="format">A composite format string</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string Format(string format, params object[] args)
        {
            var index = 0;
            var alignment = 0;
            var chr = '\0';
            var len = format.Length;
            var fmt = Empty;
            var token = Empty;
            var output = Empty;

            if (format is null)
            {
                throw new ArgumentNullException("format can't be null");
            }

            for (var i = 0; i < len; i++)
            {
                token = Empty;
                chr = format[i];

                if (chr == '{')
                {
                    if (i + 1 == len)
                    {
                        throw new ArgumentException("Format error: no closed brace, column " + i);
                    }

                    if (format[i + 1] == '{')
                    {
                        output += chr;
                        i++;
                        continue;
                    }
                    else
                    {
                        alignment = 0;
                        fmt = Empty;

                        for (i++; i < len; i++)
                        {
                            chr = format[i];

                            if (chr >= '0' && chr <= '9')
                            {
                                token += chr;
                            }
                            else if (chr == ',' || chr == ':' || chr == '}')
                            {
                                break;
                            }
                            else
                            {
                                throw new ArgumentException("Format error: wrong symbol at {}, column " + i);
                            }
                        }

                        if (token.Length > 0)
                        {
                            index = int.Parse(token);
                        }
                        else
                        {
                            throw new ArgumentException("Format error: empty {}, column " + i);
                        }

                        if (chr == ',')
                        {
                            if (format[i + 1] == '-')
                            {
                                token = "-";
                                i++;
                            }
                            else
                            {
                                token = Empty;
                            }

                            for (i++; i < len; i++)
                            {
                                chr = format[i];

                                if (chr >= '0' && chr <= '9')
                                {
                                    token += chr;
                                }
                                else if (chr == ':' || chr == '}')
                                {
                                    break;
                                }
                                else
                                {
                                    throw new ArgumentException("Format error: wrong symbol at alignment, column " + i);
                                }
                            }

                            if (token.Length > 0)
                            {
                                alignment = int.Parse(token);
                            }
                            else
                            {
                                throw new ArgumentException("Format error: empty alignment, column " + i);
                            }
                        }

                        if (chr == ':')
                        {
                            token = Empty;
                            for (i++; i < len; i++)
                            {
                                chr = format[i];

                                if (chr == '}')
                                {
                                    break;
                                }
                                else
                                {
                                    token += chr;
                                }
                            }

                            if (token.Length > 0)
                            {
                                fmt = token;
                            }
                            else
                            {
                                throw new ArgumentException("Format error: empty format after ':', column " + i);
                            }
                        }
                    }

                    if (chr != '}')
                    {
                        throw new ArgumentException("Format error: no closed brace, column " + i);
                    }

                    if (fmt.Length > 0)
                    {
#if NANOCLR_REFLECTION
                        var method = args[index].GetType().GetMethod("ToString", new Type[] { typeof(string) });
                        token = (method is null)
                            ? args[index].ToString()
                            : method.Invoke(args[index], new object[] { token }).ToString();
#else
                        throw new NotImplementedException();
#endif // NANOCLR_REFLECTION

                    }
                    else
                    {
                        token = args[index].ToString();
                    }

                    if (alignment > 0)
                    {
                        output += token.PadLeft(alignment);
                    }
                    else if (alignment < 0)
                    {
                        output += token.PadRight(MathInternal.Abs(alignment));
                    }
                    else
                    {
                        output += token;
                    }
                }
                else if (chr == '}')
                {
                    if (i + 1 == len)
                    {
                        throw new ArgumentException("Format error: no closed brace, column " + i);
                    }

                    if (format[i + 1] == '}')
                    {
                        output += chr;
                        i++;
                    }
                    else
                    {
                        throw new ArgumentException("Format error: no closed brace, column " + i);
                    }
                }
                else
                {
                    output += chr;
                }
            }

            return output;
        }

        /// <summary>
        /// Returns a new string that right-aligns the characters in this instance by padding them on the left with a specified Unicode character, for a specified total length.
        /// </summary>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <param name="paddingChar">A Unicode padding character.</param>
        /// <returns></returns>
        public String PadLeft(int totalWidth, char paddingChar = ' ')
        {
            if (totalWidth < 0)
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentOutOfRangeException("totalWidth can't be less than 0");
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            }

            if (Length >= totalWidth)
            {
                return this;
            }
            else
            {
                return new String(paddingChar, totalWidth - Length) + this;
            }
        }

        /// <summary>
        /// Returns a new string that left-aligns the characters in this string by padding them on the right with a specified Unicode character, for a specified total length.
        /// </summary>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <param name="paddingChar">A Unicode padding character.</param>
        /// <returns></returns>
        public String PadRight(int totalWidth, char paddingChar = ' ')
        {
            if (totalWidth < 0)
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentOutOfRangeException("totalWidth can't be less than 0");
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            }

            if (Length >= totalWidth)
            {
                return this;
            }
            else
            {
                return this + new String(paddingChar, totalWidth - Length);
            }
        }
    }
}
