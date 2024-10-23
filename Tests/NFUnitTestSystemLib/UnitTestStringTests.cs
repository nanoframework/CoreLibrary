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
            // Test of the standard constructor
            char[] car = new Char[] { 'a', 'b', 'c', 'd' };

            // Char [], start, number
            string str = new string(car, 1, 2);
            Assert.AreEqual(str, "bc");

            str = new string(car, 0, 4);
            Assert.AreEqual(str, "abcd");

            // Char []
            str = new string(car);
            Assert.AreEqual(str, "abcd");

            // Char, number
            str = new string('\n', 33);
            Assert.AreEqual(str.Length, 33);
            for (int i = 0; i < str.Length; i++)
            {
                Assert.AreEqual(str[i], '\n');
            }

            // Char, string terminator known failure. 
            char[] car2 = new char[] { (char)0, (char)65 };
            string s = new string(car2);
            Assert.AreEqual(s, "\0A");
            // This was previously bug 20620

            // new char[0]
            str = new string(new char[0]);
            Assert.AreEqual(str, string.Empty);

            // null
            str = new string(null);
            Assert.AreEqual(str, string.Empty);
        }

        [TestMethod]
        public void CompareTo_Test3()
        {
            // Test of the CompareTo method
            string str = "hello";
            object ob = "Hello";
            // NormalCompareTo
            Assert.AreEqual(str.CompareTo((object)"hello"), 0);
            Assert.IsTrue(str.CompareTo(ob) > 0);
            Assert.IsTrue(str.CompareTo((object)"zello") < 0);
            // CompareTo null
            Assert.IsTrue(str.CompareTo((object)null) > 0);
        }

        [TestMethod]
        public void GetHashCode_Test4()
        {
            // Test of the GetHashCode method
            string[] strs = new string[] { "abcd", "bcda", "cdab", "dabc" };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    OutputHelper.WriteLine(strs[i].GetHashCode().ToString() + " - " +
                        strs[j].GetHashCode().ToString());
                    if (i == j)
                    {
                        Assert.AreEqual(strs[i].GetHashCode(), strs[j].GetHashCode());
                    }
                    else
                    {
                        Assert.AreNotEqual(strs[i].GetHashCode(), strs[j].GetHashCode());
                    }
                }
            }
        }

        [TestMethod]
        public void Equals_Test5()
        {
            // This verifies the String.Equals functionality.
            // It compares the string value using the Equals function
            // to valid and invalid values as well as casted object values.

            string str = "abcd";
            object ob2 = "bcd";
            object ob = str as object;

            Assert.IsTrue(str.Equals(ob));
            Assert.IsFalse(str.Equals((object)123));
            Assert.IsTrue(str.Equals((object)"abcd"));
            Assert.IsFalse(str.Equals((object)"bcd"));
            Assert.IsFalse(str.Equals(ob2));
            string str1 = "abc\n";
            string str2 = "abcd";
            string str3 = "abc\n";
            Assert.IsTrue(str1.Equals(str3));
            Assert.IsFalse(str1.Equals(str2));
            Assert.IsTrue(str3.Equals(str1));
            Assert.IsTrue(str3.Equals("abc" + "\n"));
            Assert.IsTrue(str2.Equals("a" + "b" + 'c' + "d"));
        }

        [TestMethod]
        public void ToString_Test6()
        {
            // Test of the ToString method
            string str = "abc";
            Assert.AreEqual(str, str.ToString());
            Assert.AreEqual(str, str.ToString().ToString().ToString());
            Assert.AreEqual(str.ToString(), "abc");
        }

        [TestMethod]
        public void ToCharArray_Test13()
        {
            // Test of the ToCharArray method

            char[] car1 = new Char[] { 'a', 'b', 'c', 'd' };
            char[] car2 = new Char[] { };

            string str1 = "abcd";
            string str2 = "abcde";
            string str3 = "ABCD";

            // With 0 args
            CollectionAssert.AreEqual(str1.ToCharArray(), car1);
            CollectionAssert.AreNotEqual(str2.ToCharArray(), car1);
            CollectionAssert.AreNotEqual(str3.ToCharArray(), car1);
            CollectionAssert.AreNotEqual(str1.ToCharArray(), car2);

            // With 1 args
            CollectionAssert.AreNotEqual(str1.ToCharArray(0, 3), car1);
            CollectionAssert.AreEqual(str2.ToCharArray(0, 4), car1);
            CollectionAssert.AreNotEqual(str3.ToCharArray(0, 3), car1);
            CollectionAssert.AreNotEqual(str1.ToCharArray(1, 3), car2);
        }

        [TestMethod]
        public void Split_Test15()
        {
            // Testing the Split method
            char[] car1 = new Char[] { '@', 'q' };
            char[] car2 = new Char[] { };
            string str1 = "ab@cd";
            string str2 = "abcd@";

            Assert.AreEqual(str1.Split(car1)[0], "ab");
            Assert.AreEqual(str1.Split(car1)[1], "cd");
            Assert.AreEqual(str2.Split(car1)[0], "abcd");
            Assert.AreEqual(str2.Split(car1)[1], "");
            Assert.AreEqual(str1.Split(car2)[0], "ab@cd");

            // Verify split with a count
            // This is currently a known issue
            // 20659	String.Split with a count parameter always returns the whole string.
            string[] oneTwoThree = "1 2 3".Split(new char[] { ' ' }, 1);
            Assert.IsTrue(oneTwoThree.Length <= 1);
        }

        [TestMethod]
        public void Substring_Test17()
        {
            // Testing the Substring method
            string str1 = "abcde";

            Assert.AreEqual(str1.Substring(0), str1);
            Assert.AreEqual(str1.Substring(0, 5), str1);
            Assert.AreEqual(str1.Substring(2), "cde");
            Assert.AreEqual(str1.Substring(2, 1), "c");
        }

        [TestMethod]
        public void Trim_Test19()
        {
            // Testing the Trim method

            char[] car1 = new Char[] { '@', 'q' };
            string str1 = " abc@de ";
            string str2 = "@abc  @  de@";
            Assert.AreEqual(str1.Trim(), "abc@de");
            Assert.AreEqual(str1.Trim(car1), " abc@de ");
            Assert.AreEqual(str2.Trim(), "@abc  @  de@");
            Assert.AreEqual(str2.Trim(car1), "abc  @  de");
        }

        [TestMethod]
        public void TrimStart_Test20()
        {
            // Testing the TrimStart method

            char[] car1 = new Char[] { '@', 'q' };
            string str1 = " abc@de ";
            string str2 = "@abc  @  de@";
            Assert.AreEqual(str1.TrimStart(), "abc@de ");
            Assert.AreEqual(str1.TrimStart(car1), " abc@de ");
            Assert.AreEqual(str2.TrimStart(), "@abc  @  de@");
            Assert.AreEqual(str2.TrimStart(car1), "abc  @  de@");
        }

        [TestMethod]
        public void TrimEnd_Test21()
        {
            // Testing the TrimEnd method

            char[] car1 = new Char[] { '@', 'q' };
            string str1 = " abc@de ";
            string str2 = "@abc  @  de@";
            Assert.AreEqual(str1.TrimEnd(), " abc@de");
            Assert.AreEqual(str1.TrimEnd(car1), " abc@de ");
            Assert.AreEqual(str2.TrimEnd(), "@abc  @  de@");
            Assert.AreEqual(str2.TrimEnd(car1), "@abc  @  de");
        }

        [TestMethod]
        public void IndexOf_Test28()
        {
            // Testing the IndexOf method

            string str1 = "@ abc@de ";
            Assert.AreEqual(str1.IndexOf('@'), 0);
            Assert.AreEqual(str1.IndexOf("abc"), 2);
            Assert.AreEqual(str1.IndexOf('@', 1), 5);
            Assert.AreEqual(str1.IndexOf('@', 1, 1), -1);
            Assert.AreEqual(str1.IndexOf("abc", 2), 2);
            Assert.AreEqual(str1.IndexOf("abc", 1, 1), -1);
        }

        [TestMethod]
        public void IndexOfAny_Test31()
        {
            // Testing the IndexOfAny method

            string str1 = "@ abc@de ";
            char[] car1 = new Char[] { '@', 'b' };

            Assert.AreEqual(str1.IndexOfAny(car1), 0);
            Assert.AreEqual(str1.IndexOfAny(car1, 1), 3);
        }

        [TestMethod]
        public void LastIndexOf_Test37()
        {
            // Testing the LastIndexOf method

            string str1 = "@ abc@de ";
            Assert.AreEqual(str1.LastIndexOf('@'), 5);
            Assert.AreEqual(str1.LastIndexOf("abc"), 2);
            Assert.AreEqual(str1.LastIndexOf('@', 1), 0);
            Assert.AreEqual(str1.LastIndexOf('@', 1, 1), -1);
            Assert.AreEqual(str1.LastIndexOf("abc", 2), -1);
            Assert.AreEqual(str1.LastIndexOf("@", 6, 1), -1);
        }

        [TestMethod]
        public void LastIndexOfAny_Test40()
        {
            // Testing the LastIndexOfAny method

            string str1 = "@ abc@de ";
            char[] car1 = new Char[] { '@', 'b' };

            Assert.AreEqual(str1.LastIndexOfAny(car1), 5);
            Assert.AreEqual(str1.LastIndexOfAny(car1, 1), 0);
            Assert.AreEqual(str1.LastIndexOfAny(car1, 4, 1), -1);
        }

        [TestMethod]
        public void ToLower_Test51()
        {
            // Testing the ToLower method

            string str1 = "@ ABC@de ";
            Assert.AreEqual(str1.ToLower(), "@ abc@de ");
        }

        [TestMethod]
        public void ToUpper_Test52()
        {
            // Testing the ToUpper method ;

            string str1 = "@ ABC@de ";
            Assert.AreEqual(str1.ToUpper(), "@ ABC@DE ");
        }

        [TestMethod]
        public void Length_Test71()
        {
            // Testing the Length property ;

            string str1 = "@ ABC@de ";
            Assert.AreEqual(str1.Length, 9);
        }

        [TestMethod]
        public void Concat_Test1()
        {
            string str = "a" + 1 + "b" + new ToStringReturnsNull();
            Assert.AreEqual(str, "a1b");
        }

        [TestMethod]
        public void Format()
        {
            Assert.AreEqual(String.Format("The value is {0}", 32), "The value is 32",
                "String.Format with a single variable");
            Assert.AreEqual(String.Format("The value with formatter is {0:d3}", 32), "The value with formatter is 032",
                "String.Format with a decimal formatter.");
        }

        [TestMethod]
        public void FormatWithNull()
        {
            object nullObject = null;
            Assert.AreEqual(String.Format("The value is {0}", nullObject), "The value is ",
                "String.Format should treat a null argument as an empty string");
            Assert.AreEqual(String.Format("The value with formatter is {0:d}", nullObject), "The value with formatter is ",
                "String.Format should treat a null argument as an empty string when used with formatters.");
            Assert.AreEqual(String.Format("First parm: '{0}' second parm: '{1}'", new object[] { nullObject, 32 }), "First parm: '' second parm: '32'",
                "Formatting with two parms should also work");
            Assert.AreEqual($"the value is {nullObject}", "the value is ", "Interpolated strings should use string.format and work correctly");
        }

        [TestMethod]
        public void Contains_String()
        {
            // Test of Contains

            string s = "Hello";
            string value = "ello";
            Assert.IsTrue(s.Contains(value));

            value = "";
            Assert.IsTrue(s.Contains(value));

            value = "hello";
            Assert.IsFalse(s.Contains(value));

            value = "ELL";
            Assert.IsFalse(s.Contains(value));

            value = "Larger Hello";
            Assert.IsFalse(s.Contains(value));

            value = "Goodbye";
            Assert.IsFalse(s.Contains(value));

            value = "";
            Assert.IsTrue(value.Contains(value));

            string s1 = "456";
            Assert.IsTrue(s1.Contains(s1));
        }

        [TestMethod]
        public void ZeroLengthContains_StringComparison()
        {
            // Test of Zero Length Contains

            var a = new char[3];

            string s1 = new string(a);
            string s2 = new string(a, 2, 0);
            Assert.IsTrue(s1.Contains(s2));

            s1 = string.Empty;
            Assert.IsTrue(s1.Contains(s2));

            var span = new string(a);
            var emptySlice = new string(a, 2, 0);
            Assert.IsTrue(span.Contains(emptySlice));

            Assert.IsTrue(span.Contains(emptySlice));

            span = string.Empty;
            Assert.IsTrue(span.Contains(emptySlice));
        }

        [TestMethod]
        public void ContainsMatch_StringComparison()
        {
            // Test of Contains match

            string value = "456";

            string s1 = value.Substring(0, 3);
            string s2 = value.Substring(0, 2);
            Assert.IsTrue(s1.Contains(s2));
        }

        [TestMethod]
        public void ContainsMatchDifferentSpans_StringComparison()
        {
            // Test of Contains match with differnet lengths

            string value1 = "4567";
            string value2 = "456";

            string s1 = value1.Substring(0, 3);
            string s2 = value2.Substring(0, 3);
            Assert.IsTrue(s1.Contains(s2));
        }

        [TestMethod]
        public void ContainsNoMatch_StringComparison()
        {
            // Test of Contains with no match

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
                    Assert.IsFalse(s1.Contains(s2));

                    Assert.AreEqual(
                        s1.StartsWith(s2),
                        s1.Contains(s2));
                }
            }
        }

        [TestMethod]
        public void MakeSureNoContainsChecksGoOutOfRange_StringComparison()
        {
            // Test of Contains with no match out of range

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
                    Assert.IsTrue(s1.Contains(s2));
                }
                catch (ArgumentOutOfRangeException)
                {
                    // this is the intended outcome at some point
                    Assert.IsTrue(true);
                }
            }
        }

        [TestMethod]
        public static void StartsWith_StringComparison()
        {
            // Test of StartsWith

            string s = "Hello";
            string value = "H";

            Assert.IsTrue(s.StartsWith(value));

            value = "Hel";
            Assert.IsTrue(s.StartsWith(value));

            value = "Hello";
            Assert.IsTrue(s.StartsWith(value));

            value = "";
            Assert.IsTrue(s.StartsWith(value));

            value = "Hello Larger";
            Assert.IsFalse(s.StartsWith(value));

            value = "HEL";
            Assert.IsFalse(s.StartsWith(value));

            value = "Abc";
            Assert.IsFalse(s.StartsWith(value));

            s = "";
            value = "Hello";
            Assert.IsFalse(s.StartsWith(value));

            s = "abcdefghijklmnopqrstuvwxyz";
            value = "abcdefghijklmnopqrstuvwxyz";
            Assert.IsTrue(s.StartsWith(value));

            value = "abcdefghijklmnopqrstuvwx";
            Assert.IsTrue(s.StartsWith(value));

            value = "abcdefghijklm";
            Assert.IsTrue(s.StartsWith(value));

            value = "ab_defghijklmnopqrstu";
            Assert.IsFalse(s.StartsWith(value));

            value = "abcdef_hijklmn";
            Assert.IsFalse(s.StartsWith(value));

            value = "abcdefghij_lmn";
            Assert.IsFalse(s.StartsWith(value));

            value = "a";
            Assert.IsTrue(s.StartsWith(value));

            value = "abcdefghijklmnopqrstuvwxyza";
            Assert.IsFalse(s.StartsWith(value));
        }

        [TestMethod]
        public static void StartsWith_NullInStrings()
        {
            // Test of StartsWith with null strings

            Assert.IsFalse("\0test".StartsWith("test"));
            Assert.IsFalse("te\0st".StartsWith("test"));
            Assert.IsTrue("te\0st".StartsWith("te\0s"));
            Assert.IsTrue("test\0".StartsWith("test"));
            Assert.IsTrue("test".StartsWith("te\0"));
        }

        [TestMethod]
        public static void StartsWith_Invalid()
        {
            // Test of invalid StartsWith

            string s = "Hello";

            // Value is null
            Assert.ThrowsException(typeof(ArgumentNullException), () => { s.StartsWith(null); });
        }

        [TestMethod]
        public static void ZeroLengthStartsWith_Char()
        {
            // Test of StartsWith with zero length char

            var a = new char[3];

            string s1 = new(a);
            string s2 = new(a, 2, 0);
            bool b = s1.StartsWith(s2);
            Assert.IsTrue(b);
        }

        [TestMethod]
        public static void EndsWith_Invalid()
        {
            // Test of invalid EndsWith

            string s = "Hello";

            // Value is null
            Assert.ThrowsException(typeof(ArgumentNullException), () => { s.EndsWith(null); });
        }

        [TestMethod]
        public static void SameSpanStartsWith_Char()
        {
            // Test of StartsWith with self

            string s1 = "456";

            Assert.IsTrue(s1.StartsWith(s1));
        }

        [TestMethod]
        public static void LengthMismatchStartsWith_Char()
        {
            // Test of StartsWith with length mismatch and chars

            char[] a = { '4', '5', '6' };

            string s1 = new string(a, 0, 2);
            string s2 = new string(a, 0, 3);
            bool b = s1.StartsWith(s2);
            Assert.IsFalse(b);
        }

        [TestMethod]
        public static void StartsWithMatch_Char()
        {
            // Test of StartsWith with matching chars

            char[] a = { '4', '5', '6' };

            string s1 = new(a, 0, 3);
            string s2 = new(a, 0, 2);
            bool b = s1.StartsWith(s2);
            Assert.IsTrue(b);
        }

        [TestMethod]
        public static void StartsWithNoMatch_Char()
        {
            // Test of StartsWith with no matching chars

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
                    Assert.IsFalse(b);
                }
            }
        }

        [TestMethod]
        public static void MakeSureNoStartsWithChecksGoOutOfRange_Char()
        {
            // Test of StartsWith with no matching chars and going out of range

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
                Assert.IsTrue(b);
            }
        }

        [TestMethod]
        public static void ZeroLengthStartsWith_StringComparison()
        {
            // Test of StartsWith with zero length

            var a = new char[3];

            string s1 = new string(a);
            string s2 = new string(a, 2, 0);
            Assert.IsTrue(s1.StartsWith(s2));

            s1 = string.Empty;
            Assert.IsTrue(s1.StartsWith(s2));
        }

        [TestMethod]
        public static void SameSpanStartsWith_StringComparison()
        {
            // Test of StartsWith with self

            string s1 = "456";
            Assert.IsTrue(s1.StartsWith(s1));
        }

        [TestMethod]
        public static void LengthMismatchStartsWith_StringComparison()
        {
            // Test of StartsWith with length mismatch

            string value = "456";

            string s1 = value.Substring(0, 2);
            string s2 = value.Substring(0, 3);
            Assert.IsFalse(s1.StartsWith(s2));
        }

        [TestMethod]
        public static void StartsWithMatch_StringComparison()
        {
            // Test of StartsWith with match with different lengths

            string value = "456";

            string s1 = value.Substring(0, 3);
            string s2 = value.Substring(0, 2);
            Assert.IsTrue(s1.StartsWith(s2));
        }

        [TestMethod]
        public static void EndsWith_StringComparison()
        {
            // Test of EndsWith

            string s = "Hello";
            string value = "o";

            Assert.IsTrue(s.EndsWith(value));

            value = "llo";
            Assert.IsTrue(s.EndsWith(value));

            value = "Hello";
            Assert.IsTrue(s.EndsWith(value));

            value = "";
            Assert.IsTrue(s.EndsWith(value));

            value = "Larger Hello";
            Assert.IsFalse(s.EndsWith(value));

            value = "LLO";
            Assert.IsFalse(s.EndsWith(value));

            value = "Abc";
            Assert.IsFalse(s.EndsWith(value));

            value = "a";
            Assert.IsFalse(s.EndsWith(value));

            s = "";
            value = "";
            Assert.IsTrue(s.EndsWith(value));

            value = "a";
            Assert.IsFalse(s.EndsWith(value));
        }

        [TestMethod]
        public static void EndsWith_NullInStrings()
        {
            // Test of EndsWith with null strings

            Assert.IsTrue("te\0st".EndsWith("e\0st"));
            Assert.IsFalse("te\0st".EndsWith("test"));
            Assert.IsTrue("test\0".EndsWith("test"));
            Assert.IsTrue("test".EndsWith("\0st"));
        }

        [TestMethod]
        public static void ZeroLengthEndsWith_Char()
        {
            // Test of EndsWith with chars
            var a = new char[3];

            string s1 = new string(a);
            string s2 = new string(a, 2, 0);
            bool b = s1.EndsWith(s2);
            Assert.IsTrue(b);
        }

        [TestMethod]
        public static void SameSpanEndsWith_Char()
        {
            // Test of EndsWith with self

            string s = "456";
            bool b = s.EndsWith(s);
            Assert.IsTrue(b);
        }

        [TestMethod]
        public static void LengthMismatchEndsWith_Char()
        {
            // Test of EndsWith with length mismatch

            string value = "456";

            string s1 = value.Substring(0, 2);
            string s2 = value.Substring(0, 3);
            bool b = s1.EndsWith(s2);
            Assert.IsFalse(b);
        }

        [TestMethod]
        public static void EndsWithMatch_Char()
        {
            // Test of EndsWith match with chars

            string value = "456";

            string s1 = value.Substring(0, 3);
            string s2 = value.Substring(1, 2);
            bool b = s1.EndsWith(s2);
            Assert.IsTrue(b);
        }

        [TestMethod]
        public static void EndsWithNoMatch_Char()
        {
            // Test of EndsWith with no match

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
                    Assert.IsFalse(b);
                }
            }
        }

        [TestMethod]
        public static void ZeroLengthEndsWith_StringComparison()
        {
            // Test of EndsWith with zero length

            var a = new char[3];

            string s1 = new(a);
            string s2 = new(a, 2, 0);
            Assert.IsTrue(s1.EndsWith(s2));

            s1 = string.Empty;
            Assert.IsTrue(s1.EndsWith(s2));
        }

        [TestMethod]
        public static void MakeSureNoEndsWithChecksGoOutOfRange_Char()
        {
            // Test of EndsWith with no match and going out of range

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
                Assert.IsTrue(b);
            }
        }

        [TestMethod]
        public static void LengthMismatchEndsWith_StringComparison()
        {
            // Test of EndsWith with lenght mismatch

            string value = "456";

            string s1 = value.Substring(0, 2);
            string s2 = value.Substring(0, 3);
            Assert.IsFalse(s1.EndsWith(s2));
        }

        [TestMethod]
        public static void EndsWithMatch_StringComparison()
        {
            // Test of EndsWith with substrings

            string value = "456";

            string s1 = value.Substring(0, 3);
            string s2 = value.Substring(1, 2);
            Assert.IsTrue(s1.EndsWith(s2));
        }

        [TestMethod]
        public static void EndsWithMatchDifferentSpans_StringComparison()
        {
            // Test of EndsWith with natch on different comparisons

            string value1 = "7456";
            string value2 = "456";

            string s1 = value1.Substring(1, 3);
            string s2 = value2.Substring(0, 3);
            Assert.IsTrue(s1.EndsWith(s2));
        }

        [TestMethod]
        public static void EndsWithNoMatch_StringComparison()
        {
            // Test of EndsWith with no match on different lengths and comparisons

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
                    Assert.IsFalse(s1.EndsWith(s2));
                }
            }
        }

        [TestMethod]
        public static void MakeSureNoEndsWithChecksGoOutOfRange_StringComparison()
        {
            // Test of EndsWith with no match and gogin out of range

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
                Assert.IsTrue(s1.EndsWith(s2));
            }
        }

        [TestMethod]
        public static void EndsWithNoMatchNonOrdinal_StringComparison()
        {
            // Test of EndsWith with no match on different ordinal comparisons

            string s = "dabc";
            string value = "aDc";
            Assert.IsFalse(s.EndsWith(value));
        }

        [TestMethod]
        public void IndexOf_should_return_first_index_of_value()
        {
            // TODO: Check docs to confirm constraints on "count". Currently ArgumentOutOfRangeException is thrown if start + count exceeds string.Length
            var source = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";

            Assert.AreEqual(0, source.IndexOf('a'), "Case 1");
            Assert.AreEqual(26, source.IndexOf('a', 1), "Case 2");
            Assert.AreEqual(26, source.IndexOf('a', 1, source.Length - 1), "Case 3");
            Assert.AreEqual(0, source.IndexOf("a"), "Case 4");
            Assert.AreEqual(26, source.IndexOf("a", 1), "Case 5");
            Assert.AreEqual(26, source.IndexOf("a", 1, source.Length - 1), "Case 6");
        }

        [TestMethod]
        public void IndexOf_should_return_negative_one_if_source_is_empty_string()
        {
            Assert.AreEqual(-1, string.Empty.IndexOf('.'), "Case 1");
            Assert.AreEqual(-1, string.Empty.IndexOf('.', 1), "Case 2");
            Assert.AreEqual(-1, string.Empty.IndexOf('.', 1, 2), "Case 3");
            Assert.AreEqual(-1, string.Empty.IndexOf("."), "Case 4");
            Assert.AreEqual(-1, string.Empty.IndexOf(".", 1), "Case 5");
            Assert.AreEqual(-1, string.Empty.IndexOf(".", 1, 2), "Case 6");
        }

        [TestMethod]
        public void IndexOf_should_return_negative_one_if_value_is_not_found()
        {
            var source = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";

            Assert.AreEqual(-1, source.IndexOf('.'), "Case 1");
            Assert.AreEqual(-1, source.IndexOf('.', 1), "Case 2");
            Assert.AreEqual(-1, source.IndexOf('.', 1, 2), "Case 3");
            Assert.AreEqual(-1, source.IndexOf("."), "Case 4");
            Assert.AreEqual(-1, source.IndexOf(".", 1), "Case 5");
            Assert.AreEqual(-1, source.IndexOf(".", 1, 2), "Case 6");
        }

        [TestMethod]
        public void LastIndexOf_should_return_last_index_of_value()
        {
            var source = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";

            Assert.AreEqual(26, source.LastIndexOf('a'), "Case 1");
            Assert.AreEqual(0, source.LastIndexOf('a', 1), "Case 2");
            Assert.AreEqual(0, source.LastIndexOf('a', 1, 2), "Case 3");
            Assert.AreEqual(26, source.LastIndexOf("a"), "Case 4");
            Assert.AreEqual(0, source.LastIndexOf("a", 1), "Case 5");
            Assert.AreEqual(0, source.LastIndexOf("a", 1, 2), "Case 6");
        }

        [TestMethod]
        public void LastIndexOf_should_return_negative_one_if_source_is_empty_string()
        {
            Assert.AreEqual(-1, string.Empty.LastIndexOf('.'), "Case 1");
            Assert.AreEqual(-1, string.Empty.LastIndexOf('.', 1), "Case 2");
            Assert.AreEqual(-1, string.Empty.LastIndexOf('.', 1, 2), "Case 3");
            Assert.AreEqual(-1, string.Empty.LastIndexOf("."), "Case 4");
            Assert.AreEqual(-1, string.Empty.LastIndexOf(".", 1), "Case 5");
            Assert.AreEqual(-1, string.Empty.LastIndexOf(".", 1, 2), "Case 6");
        }

        [TestMethod]
        public void LastIndexOf_should_return_negative_one_if_value_is_not_found()
        {
            var source = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";

            Assert.AreEqual(-1, source.LastIndexOf('.'), "Case 1");
            Assert.AreEqual(-1, source.LastIndexOf('.', 1), "Case 2");
            Assert.AreEqual(-1, source.LastIndexOf('.', 1, 2), "Case 3");
            Assert.AreEqual(-1, source.LastIndexOf("."), "Case 4");
            Assert.AreEqual(-1, source.LastIndexOf(".", 1), "Case 5");
            Assert.AreEqual(-1, source.LastIndexOf(".", 1, 2), "Case 6");
        }

        [TestMethod]
        public void Concat_should_work_with_nulls()
        {
            const string baseContent = "Hello";
            string[] dispOut = new string[4];
            dispOut[0] = baseContent;

            string test = string.Concat(dispOut);

            Console.WriteLine(test);

            Assert.AreSame(baseContent, test);
        }

        [TestMethod]
        public void Concat_Should_Concatenate_Two_Strings()
        {
            // Arrange
            string str1 = "Hello";
            string str2 = "World";

            // Act
            string result = string.Concat(str1, str2);

            // Assert
            Assert.AreEqual("HelloWorld", result);
        }

        [TestMethod]
        public void Concat_Should_Concatenate_Multiple_Strings()
        {
            // Arrange
            string str1 = "Hello";
            string str2 = " ";
            string str3 = "World";
            string str4 = "!";

            // Act
            string result = string.Concat(str1, str2, str3, str4);

            // Assert
            Assert.AreEqual("Hello World!", result);
        }

        [TestMethod]
        public void Concat_Should_Handle_Null_Strings()
        {
            // Arrange
            string str1 = null;
            string str2 = "World";

            // Act
            string result = string.Concat(str1, str2);

            // Assert
            Assert.AreEqual("World", result);
        }

        [TestMethod]
        public void Concat_Should_Handle_Empty_Strings()
        {
            // Arrange
            string str1 = "";
            string str2 = "World";

            // Act
            string result = string.Concat(str1, str2);

            // Assert
            Assert.AreEqual("World", result);
        }

        [TestMethod]
        public void Concat_Should_Handle_Null_And_Empty_Strings()
        {
            // Arrange
            string str1 = null;
            string str2 = "";
            string str3 = "Hello";
            string str4 = null;

            // Act
            string result = string.Concat(str1, str2, str3, str4);

            // Assert
            Assert.AreEqual("Hello", result);
        }

        [TestMethod]
        public void Concat_Should_Concatenate_String_Array()
        {
            // Arrange
            string[] strings = { "Hello", " ", "World", "!" };

            // Act
            string result = string.Concat(strings);

            // Assert
            Assert.AreEqual("Hello World!", result);
        }

        [TestMethod]
        public void Concat_Should_Handle_Null_Elements_In_Array()
        {
            // Arrange
            string[] strings = { "Hello", null, "World", "!" };

            // Act
            string result = string.Concat(strings);

            // Assert
            Assert.AreEqual("HelloWorld!", result);
        }

        [TestMethod]
        public void Concat_Should_Handle_Empty_Elements_In_Array()
        {
            // Arrange
            string[] strings = { "Hello", "", "World", "!" };

            // Act
            string result = string.Concat(strings);

            // Assert
            Assert.AreEqual("HelloWorld!", result);
        }

        [TestMethod]
        public void Concat_Should_Handle_Null_And_Empty_Elements_In_Array()
        {
            // Arrange
            string[] strings = { null, "", "Hello", null, "", "World", "!" };

            // Act
            string result = string.Concat(strings);

            // Assert
            Assert.AreEqual("HelloWorld!", result);
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
