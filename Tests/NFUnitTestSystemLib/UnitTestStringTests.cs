//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class UnitTestStringTests
    {
        //String Test methods
        [TestMethod]
        public void Ctor_Test()
        {
            OutputHelper.WriteLine("Test of the standard constructor");
            char[] car = new Char[] { 'a', 'b', 'c', 'd' };

            OutputHelper.WriteLine("Char [], start, number");
            string str = new string(car, 1, 2);
            Assert.Equal(str, "bc");

            str = new string(car, 0, 4);
            Assert.Equal(str, "abcd");

            OutputHelper.WriteLine("Char []");
            str = new string(car);
            Assert.Equal(str, "abcd");

            OutputHelper.WriteLine("Char, number");
            str = new string('\n', 33);
            Assert.Equal(str.Length, 33);
            for (int i = 0; i < str.Length; i++)
            {
                Assert.Equal(str[i], '\n');
            }

            OutputHelper.WriteLine("Char, string terminator known failure. ");
            char[] car2 = new char[] { (char)0, (char)65 };
            string s = new string(car2);
            Assert.Equal(s, "\0A");
            OutputHelper.WriteLine("This was previously bug 20620");

            OutputHelper.WriteLine("new char[0]");
            str = new string(new char[0]);
            Assert.Equal(str, string.Empty);

            OutputHelper.WriteLine("null");
            str = new string(null);
            Assert.Equal(str, string.Empty);
        }

        [TestMethod]
        public void CompareTo_Test3()
        {
            OutputHelper.WriteLine("Test of the CompareTo method");
            string str = "hello";
            object ob = "Hello";
            OutputHelper.WriteLine("NormalCompareTo");
            Assert.Equal(str.CompareTo((object)"hello"), 0);
            Assert.True(str.CompareTo(ob) > 0);
            Assert.True(str.CompareTo((object)"zello") < 0);
            OutputHelper.WriteLine("CompareTo null");
            Assert.True(str.CompareTo((object)null) > 0);
        }

        [TestMethod]
        public void GetHashCode_Test4()
        {
            OutputHelper.WriteLine("Test of the GetHashCode method");
            string[] strs = new string[] { "abcd", "bcda", "cdab", "dabc" };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    OutputHelper.WriteLine(strs[i].GetHashCode().ToString() + " - " +
                        strs[j].GetHashCode().ToString());
                    if (i == j)
                    {
                        Assert.Equal(strs[i].GetHashCode(), strs[j].GetHashCode());
                    }
                    else
                    {
                        Assert.NotEqual(strs[i].GetHashCode(), strs[j].GetHashCode());
                    }
                }
            }
        }

        [TestMethod]
        public void Equals_Test5()
        {
            OutputHelper.WriteLine("This verifies the String.Equals functionality.");
            OutputHelper.WriteLine("It compares the string value using the Equals function");
            OutputHelper.WriteLine("to valid and invalid values as well as casted object values.");

            string str = "abcd";
            object ob2 = "bcd";
            object ob = str as object;

            Assert.True(str.Equals(ob));
            Assert.False(str.Equals((object)123));
            Assert.True(str.Equals((object)"abcd"));
            Assert.False(str.Equals((object)"bcd"));
            Assert.False(str.Equals(ob2));
            string str1 = "abc\n";
            string str2 = "abcd";
            string str3 = "abc\n";
            Assert.True(str1.Equals(str3));
            Assert.False(str1.Equals(str2));
            Assert.True(str3.Equals(str1));
            Assert.True(str3.Equals("abc" + "\n"));
            Assert.True(str2.Equals("a" + "b" + 'c' + "d"));
        }

        [TestMethod]
        public void ToString_Test6()
        {
            OutputHelper.WriteLine("Test of the ToString method");
            string str = "abc";
            Assert.Equal(str, str.ToString());
            Assert.Equal(str, str.ToString().ToString().ToString());
            Assert.Equal(str.ToString(), "abc");
        }

        [TestMethod]
        public void ToCharArray_Test13()
        {
            OutputHelper.WriteLine("Test of the ToCharArray method");

            char[] car1 = new Char[] { 'a', 'b', 'c', 'd' };
            char[] car2 = new Char[] { };

            string str1 = "abcd";
            string str2 = "abcde";
            string str3 = "ABCD";

            OutputHelper.WriteLine("With 0 args");
            CollectionAssert.AreEqual(str1.ToCharArray(), car1);
            CollectionAssert.AreNotEqual(str2.ToCharArray(), car1);
            CollectionAssert.AreNotEqual(str3.ToCharArray(), car1);
            CollectionAssert.AreNotEqual(str1.ToCharArray(), car2);

            OutputHelper.WriteLine("With 1 args");
            CollectionAssert.AreNotEqual(str1.ToCharArray(0, 3), car1);
            CollectionAssert.AreEqual(str2.ToCharArray(0, 4), car1);
            CollectionAssert.AreNotEqual(str3.ToCharArray(0, 3), car1);
            CollectionAssert.AreNotEqual(str1.ToCharArray(1, 3), car2);
        }

        [TestMethod]
        public void Split_Test15()
        {
            OutputHelper.WriteLine("Testing the Split method");
            char[] car1 = new Char[] { '@', 'q' };
            char[] car2 = new Char[] { };
            string str1 = "ab@cd";
            string str2 = "abcd@";

            Assert.Equal(str1.Split(car1)[0], "ab");
            Assert.Equal(str1.Split(car1)[1], "cd");
            Assert.Equal(str2.Split(car1)[0], "abcd");
            Assert.Equal(str2.Split(car1)[1], "");
            Assert.Equal(str1.Split(car2)[0], "ab@cd");

            OutputHelper.WriteLine("Verify split with a count");
            OutputHelper.WriteLine("This is currently a known issue");
            OutputHelper.WriteLine("20659	String.Split with a count parameter always returns the whole string.");
            string[] oneTwoThree = "1 2 3".Split(new char[] { ' ' }, 1);
            Assert.True(oneTwoThree.Length <= 1);
        }

        [TestMethod]
        public void Substring_Test17()
        {
            OutputHelper.WriteLine("Testing the Substring method");
            string str1 = "abcde";

            Assert.Equal(str1.Substring(0), str1);
            Assert.Equal(str1.Substring(0, 5), str1);
            Assert.Equal(str1.Substring(2), "cde");
            Assert.Equal(str1.Substring(2, 1), "c");
        }

        [TestMethod]
        public void Trim_Test19()
        {
            OutputHelper.WriteLine("Testing the Trim method");

            char[] car1 = new Char[] { '@', 'q' };
            string str1 = " abc@de ";
            string str2 = "@abc  @  de@";
            Assert.Equal(str1.Trim(), "abc@de");
            Assert.Equal(str1.Trim(car1), " abc@de ");
            Assert.Equal(str2.Trim(), "@abc  @  de@");
            Assert.Equal(str2.Trim(car1), "abc  @  de");
        }

        [TestMethod]
        public void TrimStart_Test20()
        {
            OutputHelper.WriteLine("Testing the TrimStart method");

            char[] car1 = new Char[] { '@', 'q' };
            string str1 = " abc@de ";
            string str2 = "@abc  @  de@";
            Assert.Equal(str1.TrimStart(), "abc@de ");
            Assert.Equal(str1.TrimStart(car1), " abc@de ");
            Assert.Equal(str2.TrimStart(), "@abc  @  de@");
            Assert.Equal(str2.TrimStart(car1), "abc  @  de@");
        }

        [TestMethod]
        public void TrimEnd_Test21()
        {
            OutputHelper.WriteLine("Testing the TrimEnd method");

            char[] car1 = new Char[] { '@', 'q' };
            string str1 = " abc@de ";
            string str2 = "@abc  @  de@";
            Assert.Equal(str1.TrimEnd(), " abc@de");
            Assert.Equal(str1.TrimEnd(car1), " abc@de ");
            Assert.Equal(str2.TrimEnd(), "@abc  @  de@");
            Assert.Equal(str2.TrimEnd(car1), "@abc  @  de");
        }

        [TestMethod]
        public void IndexOf_Test28()
        {
            OutputHelper.WriteLine("Testing the IndexOf method");

            string str1 = "@ abc@de ";
            Assert.Equal(str1.IndexOf('@'), 0);
            Assert.Equal(str1.IndexOf("abc"), 2);
            Assert.Equal(str1.IndexOf('@', 1), 5);
            Assert.Equal(str1.IndexOf('@', 1, 1), -1);
            Assert.Equal(str1.IndexOf("abc", 2), 2);
            Assert.Equal(str1.IndexOf("abc", 1, 1), -1);
        }

        [TestMethod]
        public void IndexOfAny_Test31()
        {
            OutputHelper.WriteLine("Testing the IndexOfAny method");

            string str1 = "@ abc@de ";
            char[] car1 = new Char[] { '@', 'b' };

            Assert.Equal(str1.IndexOfAny(car1), 0);
            Assert.Equal(str1.IndexOfAny(car1, 1), 3);
        }

        [TestMethod]
        public void LastIndexOf_Test37()
        {
            OutputHelper.WriteLine("Testing the LastIndexOf method");

            string str1 = "@ abc@de ";
            Assert.Equal(str1.LastIndexOf('@'), 5);
            Assert.Equal(str1.LastIndexOf("abc"), 2);
            Assert.Equal(str1.LastIndexOf('@', 1), 0);
            Assert.Equal(str1.LastIndexOf('@', 1, 1), -1);
            Assert.Equal(str1.LastIndexOf("abc", 2), -1);
            Assert.Equal(str1.LastIndexOf("@", 6, 1), -1);
        }

        [TestMethod]
        public void LastIndexOfAny_Test40()
        {
            OutputHelper.WriteLine("Testing the LastIndexOfAny method");

            string str1 = "@ abc@de ";
            char[] car1 = new Char[] { '@', 'b' };

            Assert.Equal(str1.LastIndexOfAny(car1), 5);
            Assert.Equal(str1.LastIndexOfAny(car1, 1), 0);
            Assert.Equal(str1.LastIndexOfAny(car1, 4, 1), -1);
        }

        [TestMethod]
        public void ToLower_Test51()
        {
            OutputHelper.WriteLine("Testing the ToLower method");

            string str1 = "@ ABC@de ";
            Assert.Equal(str1.ToLower(), "@ abc@de ");
        }

        [TestMethod]
        public void ToUpper_Test52()
        {
            OutputHelper.WriteLine("Testing the ToUpper method"); ;

            string str1 = "@ ABC@de ";
            Assert.Equal(str1.ToUpper(), "@ ABC@DE ");
        }

        [TestMethod]
        public void Length_Test71()
        {
            OutputHelper.WriteLine("Testing the Length property"); ;

            string str1 = "@ ABC@de ";
            Assert.Equal(str1.Length, 9);
        }

        [TestMethod]
        public void Concat_Test1()
        {
            string str = "a" + 1 + "b" + new ToStringReturnsNull();
            Assert.Equal(str, "a1b");
        }

        [TestMethod]
        public void Format()
        {
            Assert.Equal(String.Format("The value is {0}", 32), "The value is 32",
                "String.Format with a single variable");
            Assert.Equal(String.Format("The value with formatter is {0:d3}", 32), "The value with formatter is 032",
                "String.Format with a decimal formatter.");
        }

        [TestMethod]
        public void FormatWithNull()
        {
            object nullObject = null;
            Assert.Equal(String.Format("The value is {0}", nullObject), "The value is ",
                "String.Format should treat a null argument as an empty string");
            Assert.Equal(String.Format("The value with formatter is {0:d}", nullObject), "The value with formatter is ",
                "String.Format should treat a null argument as an empty string when used with formatters.");
            Assert.Equal(String.Format("First parm: '{0}' second parm: '{1}'", new object[] { nullObject, 32 }), "First parm: '' second parm: '32'",
                "Formatting with two parms should also work");
            Assert.Equal($"the value is {nullObject}", "the value is ", "Interpolated strings should use string.format and work correctly");
        }

        [TestMethod]
        public void Contains_String()
        {
            OutputHelper.WriteLine("Test of Contains");

            string s = "Hello";
            string value = "ello";
            Assert.True(s.Contains(value));

            value = "";
            Assert.True(s.Contains(value));

            value = "hello";
            Assert.False(s.Contains(value));

            value = "ELL";
            Assert.False(s.Contains(value));

            value = "Larger Hello";
            Assert.False(s.Contains(value));

            value = "Goodbye";
            Assert.False(s.Contains(value));

            value = "";
            Assert.True(value.Contains(value));

            string s1 = "456";
            Assert.True(s1.Contains(s1));
        }

        [TestMethod]
        public void ZeroLengthContains_StringComparison()
        {
            OutputHelper.WriteLine("Test of Zero Length Contains");

            var a = new char[3];

            string s1 = new string(a);
            string s2 = new string(a, 2, 0);
            Assert.True(s1.Contains(s2));

            s1 = string.Empty;
            Assert.True(s1.Contains(s2));

            var span = new string(a);
            var emptySlice = new string(a, 2, 0);
            Assert.True(span.Contains(emptySlice));

            Assert.True(span.Contains(emptySlice));

            span = string.Empty;
            Assert.True(span.Contains(emptySlice));
        }

        [TestMethod]
        public void ContainsMatch_StringComparison()
        {
            OutputHelper.WriteLine("Test of Contains match");

            string value = "456";

            string s1 = value.Substring(0, 3);
            string s2 = value.Substring(0, 2);
            Assert.True(s1.Contains(s2));
        }

        [TestMethod]
        public void ContainsMatchDifferentSpans_StringComparison()
        {
            OutputHelper.WriteLine("Test of Contains match with differnet lengths");

            string value1 = "4567";
            string value2 = "456";

            string s1 = value1.Substring(0, 3);
            string s2 = value2.Substring(0, 3);
            Assert.True(s1.Contains(s2));
        }

        [TestMethod]
        public void ContainsNoMatch_StringComparison()
        {
            OutputHelper.WriteLine("Test of Contains with no match");

            for (int length = 1; length < 150; length++)
            {
                for (int mismatchIndex = 0; mismatchIndex < length; mismatchIndex++)
                {
                    var first = new char[length];
                    var second = new char[length];
                    for (int i = 0; i < length; i++)
                    {
                        first[i] = second[i] = (char)(i + 1);
                    }

                    second[mismatchIndex] = (char)(second[mismatchIndex] + 1);

                    string s1 = new(first);
                    string s2 = new(second);
                    Assert.False(s1.Contains(s2));

                    Assert.Equal(
                        s1.StartsWith(s2),
                        s1.Contains(s2));
                }
            }
        }

        [TestMethod]
        public void MakeSureNoContainsChecksGoOutOfRange_StringComparison()
        {
            OutputHelper.WriteLine("Test of Contains with no match out of range");

            for (int length = 0; length < 100; length++)
            {
                var first = new char[length + 2];
                first[0] = (char)99;
                first[length + 1] = (char)99;
                var second = new char[length + 2];
                second[0] = (char)100;
                second[length + 1] = (char)100;

                string s1 = new(first, 1, length);
                string s2 = new(second, 1, length);

                // Contains either works or throws ArgumentOutOfRangeException
                try
                {
                    Assert.True(s1.Contains(s2));
                }
                catch(ArgumentOutOfRangeException)
                {
                    // this is the intended outcome at some point
                    Assert.True(true);
                }
            }
        }

        [TestMethod]
        public static void StartsWith_StringComparison()
        {
            OutputHelper.WriteLine("Test of StartsWith");

            string s = "Hello";
            string value = "H";

            Assert.True(s.StartsWith(value));

            value = "Hel";
            Assert.True(s.StartsWith(value));

            value = "Hello";
            Assert.True(s.StartsWith(value));

            value = "";
            Assert.True(s.StartsWith(value));

            value = "Hello Larger";
            Assert.False(s.StartsWith(value));

            value = "HEL";
            Assert.False(s.StartsWith(value));

            value = "Abc";
            Assert.False(s.StartsWith(value));

            s = "";
            value = "Hello";
            Assert.False(s.StartsWith(value));

            s = "abcdefghijklmnopqrstuvwxyz";
            value = "abcdefghijklmnopqrstuvwxyz";
            Assert.True(s.StartsWith(value));

            value = "abcdefghijklmnopqrstuvwx";
            Assert.True(s.StartsWith(value));

            value = "abcdefghijklm";
            Assert.True(s.StartsWith(value));

            value = "ab_defghijklmnopqrstu";
            Assert.False(s.StartsWith(value));

            value = "abcdef_hijklmn";
            Assert.False(s.StartsWith(value));

            value = "abcdefghij_lmn";
            Assert.False(s.StartsWith(value));

            value = "a";
            Assert.True(s.StartsWith(value));

            value = "abcdefghijklmnopqrstuvwxyza";
            Assert.False(s.StartsWith(value));
        }

        [TestMethod]
        public static void StartsWith_NullInStrings()
        {
            OutputHelper.WriteLine("Test of StartsWith with null strings");

            Assert.False("\0test".StartsWith("test"));
            Assert.False("te\0st".StartsWith("test"));
            Assert.True("te\0st".StartsWith("te\0s"));
            Assert.True("test\0".StartsWith("test"));
            Assert.True("test".StartsWith("te\0"));
        }

        [TestMethod]
        public static void StartsWith_Invalid()
        {
            OutputHelper.WriteLine("Test of invalid StartsWith");

            string s = "Hello";

            // Value is null
            Assert.Throws(typeof(ArgumentNullException), () => { s.StartsWith(null); });
        }

        [TestMethod]
        public static void ZeroLengthStartsWith_Char()
        {
            OutputHelper.WriteLine("Test of StartsWith with zero length char");

            var a = new char[3];

            string s1 = new(a);
            string s2 = new(a, 2, 0);
            bool b = s1.StartsWith(s2);
            Assert.True(b);
        }

        [TestMethod]
        public static void EndsWith_Invalid()
        {
            OutputHelper.WriteLine("Test of invalid EndsWith");

            string s = "Hello";

            // Value is null
            Assert.Throws(typeof(ArgumentNullException), () => { s.EndsWith(null); });
        }

        [TestMethod]
        public static void SameSpanStartsWith_Char()
        {
            OutputHelper.WriteLine("Test of StartsWith with self");

            string s1 = "456";

            Assert.True(s1.StartsWith(s1));
        }

        [TestMethod]
        public static void LengthMismatchStartsWith_Char()
        {
            OutputHelper.WriteLine("Test of StartsWith with length mismatch and chars");

            char[] a = { '4', '5', '6' };

            string s1 = new string(a, 0, 2);
            string s2 = new string(a, 0, 3);
            bool b = s1.StartsWith(s2);
            Assert.False(b);
        }

        [TestMethod]
        public static void StartsWithMatch_Char()
        {
            OutputHelper.WriteLine("Test of StartsWith with matching chars");

            char[] a = { '4', '5', '6' };

            string s1 = new(a, 0, 3);
            string s2 = new(a, 0, 2);
            bool b = s1.StartsWith(s2);
            Assert.True(b);
        }

        [TestMethod]
        public static void StartsWithNoMatch_Char()
        {
            OutputHelper.WriteLine("Test of StartsWith with no matching chars");

            for (int length = 1; length < 32; length++)
            {
                for (int mismatchIndex = 0; mismatchIndex < length; mismatchIndex++)
                {
                    var first = new char[length];
                    var second = new char[length];
                    for (int i = 0; i < length; i++)
                    {
                        first[i] = second[i] = (char)(i + 1);
                    }

                    second[mismatchIndex] = (char)(second[mismatchIndex] + 1);

                    string s1 = new(first);
                    string s2 = new(second);
                    bool b = s1.StartsWith(s2);
                    Assert.False(b);
                }
            }
        }

        [TestMethod]
        public static void MakeSureNoStartsWithChecksGoOutOfRange_Char()
        {
            OutputHelper.WriteLine("Test of StartsWith with no matching chars and going out of range");

            for (int length = 0; length < 100; length++)
            {
                var first = new char[length + 2];
                first[0] = '9';
                first[length + 1] = '9';
                var second = new char[length + 2];
                second[0] = 'a';
                second[length + 1] = 'a';

                string s1 = new(first, 1, length);
                string s2 = new(second, 1, length);
                bool b = s1.StartsWith(s2);
                Assert.True(b);
            }
        }

        [TestMethod]
        public static void ZeroLengthStartsWith_StringComparison()
        {
            OutputHelper.WriteLine("Test of StartsWith with zero length");

            var a = new char[3];

            string s1 = new string(a);
            string s2 = new string(a, 2, 0);
            Assert.True(s1.StartsWith(s2));

            s1 = string.Empty;
            Assert.True(s1.StartsWith(s2));
        }

        [TestMethod]
        public static void SameSpanStartsWith_StringComparison()
        {
            OutputHelper.WriteLine("Test of StartsWith with self");

            string s1 = "456";
            Assert.True(s1.StartsWith(s1));
        }

        [TestMethod]
        public static void LengthMismatchStartsWith_StringComparison()
        {
            OutputHelper.WriteLine("Test of StartsWith with length mismatch");

            string value = "456";

            string s1 = value.Substring(0, 2);
            string s2 = value.Substring(0, 3);
            Assert.False(s1.StartsWith(s2));
        }

        [TestMethod]
        public static void StartsWithMatch_StringComparison()
        {
            OutputHelper.WriteLine("Test of StartsWith with match with different lengths");

            string value = "456";

            string s1 = value.Substring(0, 3);
            string s2 = value.Substring(0, 2);
            Assert.True(s1.StartsWith(s2));
        }

        [TestMethod]
        public static void EndsWith_StringComparison()
        {
            OutputHelper.WriteLine("Test of EndsWith");

            string s = "Hello";
            string value = "o";

            Assert.True(s.EndsWith(value));

            value = "llo";
            Assert.True(s.EndsWith(value));

            value = "Hello";
            Assert.True(s.EndsWith(value));

            value = "";
            Assert.True(s.EndsWith(value));

            value = "Larger Hello";
            Assert.False(s.EndsWith(value));

            value = "LLO";
            Assert.False(s.EndsWith(value));

            value = "Abc";
            Assert.False(s.EndsWith(value));

            value = "a";
            Assert.False(s.EndsWith(value));

            s = "";
            value = "";
            Assert.True(s.EndsWith(value));

            value = "a";
            Assert.False(s.EndsWith(value));
        }

        [TestMethod]
        public static void EndsWith_NullInStrings()
        {
            OutputHelper.WriteLine("Test of EndsWith with null strings");

            Assert.True("te\0st".EndsWith("e\0st"));
            Assert.False("te\0st".EndsWith("test"));
            Assert.True("test\0".EndsWith("test"));
            Assert.True("test".EndsWith("\0st"));
        }

        [TestMethod]
        public static void ZeroLengthEndsWith_Char()
        {
            OutputHelper.WriteLine("Test of EndsWith with chars");
            
            var a = new char[3];

            string s1 = new string(a);
            string s2 = new string(a, 2, 0);
            bool b = s1.EndsWith(s2);
            Assert.True(b);
        }

        [TestMethod]
        public static void SameSpanEndsWith_Char()
        {
            OutputHelper.WriteLine("Test of EndsWith with self");

            string s = "456";
            bool b = s.EndsWith(s);
            Assert.True(b);
        }

        [TestMethod]
        public static void LengthMismatchEndsWith_Char()
        {
            OutputHelper.WriteLine("Test of EndsWith with length mismatch");

            string value = "456";

            string s1 = value.Substring(0, 2);
            string s2 = value.Substring(0, 3);
            bool b = s1.EndsWith(s2);
            Assert.False(b);
        }

        [TestMethod]
        public static void EndsWithMatch_Char()
        {
            OutputHelper.WriteLine("Test of EndsWith match with chars");

            string value = "456";

            string s1 = value.Substring(0, 3);
            string s2 = value.Substring(1, 2);
            bool b = s1.EndsWith(s2);
            Assert.True(b);
        }

        [TestMethod]
        public static void EndsWithNoMatch_Char()
        {
            OutputHelper.WriteLine("Test of EndsWith with no match");

            for (int length = 1; length < 32; length++)
            {
                for (int mismatchIndex = 0; mismatchIndex < length; mismatchIndex++)
                {
                    var first = new char[length];
                    var second = new char[length];
                    for (int i = 0; i < length; i++)
                    {
                        first[i] = second[i] = (char)(i + 1);
                    }

                    second[mismatchIndex] = (char)(second[mismatchIndex] + 1);

                    string s1 = new(first);
                    string s2 = new(second);

                    bool b = s1.EndsWith(s2);
                    Assert.False(b);
                }
            }
        }

        [TestMethod]
        public static void ZeroLengthEndsWith_StringComparison()
        {
            OutputHelper.WriteLine("Test of EndsWith with zero length");

            var a = new char[3];

            string s1 = new(a);
            string s2 = new(a, 2, 0);
            Assert.True(s1.EndsWith(s2));

            s1 = string.Empty;
            Assert.True(s1.EndsWith(s2));
        }

        [TestMethod]
        public static void MakeSureNoEndsWithChecksGoOutOfRange_Char()
        {
            OutputHelper.WriteLine("Test of EndsWith with no match and going out of range");

            for (int length = 0; length < 100; length++)
            {
                var first = new char[length + 2];
                first[0] = '9';
                first[length + 1] = '9';
                var second = new char[length + 2];
                second[0] = 'a';
                second[length + 1] = 'a';

                string s1 = new(first, 1, length);
                string s2 = new(second, 1, length);
                bool b = s1.EndsWith(s2);
                Assert.True(b);
            }
        }

        [TestMethod]
        public static void LengthMismatchEndsWith_StringComparison()
        {
            OutputHelper.WriteLine("Test of EndsWith with lenght mismatch");

            string value = "456";

            string s1 = value.Substring(0, 2);
            string s2 = value.Substring(0, 3);
            Assert.False(s1.EndsWith(s2));
        }

        [TestMethod]
        public static void EndsWithMatch_StringComparison()
        {
            OutputHelper.WriteLine("Test of EndsWith with substrings");

            string value = "456";

            string s1 = value.Substring(0, 3);
            string s2 = value.Substring(1, 2);
            Assert.True(s1.EndsWith(s2));
        }

        [TestMethod]
        public static void EndsWithMatchDifferentSpans_StringComparison()
        {
            OutputHelper.WriteLine("Test of EndsWith with natch on different comparisons");

            string value1 = "7456";
            string value2 = "456";

            string s1 = value1.Substring(1, 3);
            string s2 = value2.Substring(0, 3);
            Assert.True(s1.EndsWith(s2));
        }

        [TestMethod]
        public static void EndsWithNoMatch_StringComparison()
        {
            OutputHelper.WriteLine("Test of EndsWith with no match on different lengths and comparisons");

            for (int length = 1; length < 150; length++)
            {
                for (int mismatchIndex = 0; mismatchIndex < length; mismatchIndex++)
                {
                    var first = new char[length];
                    var second = new char[length];
                    for (int i = 0; i < length; i++)
                    {
                        first[i] = second[i] = (char)(i + 1);
                    }

                    second[mismatchIndex] = (char)(second[mismatchIndex] + 1);

                    string s1 = new(first);
                    string s2 = new(second);
                    Assert.False(s1.EndsWith(s2));
                }
            }
        }

        [TestMethod]
        public static void MakeSureNoEndsWithChecksGoOutOfRange_StringComparison()
        {
            OutputHelper.WriteLine("Test of EndsWith with no match and gogin out of range");

            for (int length = 0; length < 100; length++)
            {
                var first = new char[length + 2];
                first[0] = (char)99;
                first[length + 1] = (char)99;
                var second = new char[length + 2];
                second[0] = (char)100;
                second[length + 1] = (char)100;

                string s1 = new string(first, 1, length);
                string s2 = new string(second, 1, length);
                Assert.True(s1.EndsWith(s2));
            }
        }

        [TestMethod]
        public static void EndsWithNoMatchNonOrdinal_StringComparison()
        {
            OutputHelper.WriteLine("Test of EndsWith with no match on different ordinal comparisons");

            string s = "dabc";
            string value = "aDc";
            Assert.False(s.EndsWith(value));
        }

        /// <summary>
        /// A class whose ToString method return null
        /// </summary>
        public class ToStringReturnsNull
        {
            public override string ToString()
            {
                return null;
            }
        }
    }
}

