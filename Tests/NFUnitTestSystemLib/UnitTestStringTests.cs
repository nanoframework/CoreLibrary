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
            Debug.WriteLine("Test of the standard constructor");
            char[] car = new Char[] { 'a', 'b', 'c', 'd' };

            Debug.WriteLine("Char [], start, number");
            string str = new string(car, 1, 2);
            Assert.Equal(str, "bc");

            str = new string(car, 0, 4);
            Assert.Equal(str, "abcd");

            Debug.WriteLine("Char []");
            str = new string(car);
            Assert.Equal(str, "abcd");

            Debug.WriteLine("Char, number");
            str = new string('\n', 33);
            Assert.Equal(str.Length, 33);
            for (int i = 0; i < str.Length; i++)
            {
                Assert.Equal(str[i], '\n');
            }

            Debug.WriteLine("Char, string terminator known failure. ");
            char[] car2 = new char[] { (char)0, (char)65 };
            string s = new string(car2);
            Assert.Equal(s, "\0A");
            Debug.WriteLine("This was previously bug 20620");

            Debug.WriteLine("new char[0]");
            str = new string(new char[0]);
            Assert.Equal(str, string.Empty);

            Debug.WriteLine("null");
            str = new string(null);
            Assert.Equal(str, string.Empty);
        }

        [TestMethod]
        public void CompareTo_Test3()
        {
            Debug.WriteLine("Test of the CompareTo method");
            string str = "hello";
            object ob = "Hello";
            Debug.WriteLine("NormalCompareTo");
            Assert.Equal(str.CompareTo((object)"hello"), 0);
            Assert.True(str.CompareTo(ob) > 0);
            Assert.True(str.CompareTo((object)"zello") < 0);
            Debug.WriteLine("CompareTo null");
            Assert.True(str.CompareTo((object)null) > 0);
        }

        [TestMethod]
        public void GetHashCode_Test4()
        {
            Debug.WriteLine("Test of the GetHashCode method");
            string[] strs = new string[] { "abcd", "bcda", "cdab", "dabc" };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Debug.WriteLine(strs[i].GetHashCode().ToString() + " - " +
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
            Debug.WriteLine("This verifies the String.Equals functionality.");
            Debug.WriteLine("It compares the string value using the Equals function");
            Debug.WriteLine("to valid and invalid values as well as casted object values.");

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
            Debug.WriteLine("Test of the ToString method");
            string str = "abc";
            Assert.Equal(str, str.ToString());
            Assert.Equal(str, str.ToString().ToString().ToString());
            Assert.Equal(str.ToString(), "abc");
        }

        [TestMethod]
        public void ToCharArray_Test13()
        {
            Debug.WriteLine("Test of the ToCharArray method");

            char[] car1 = new Char[] { 'a', 'b', 'c', 'd' };
            char[] car2 = new Char[] { };

            string str1 = "abcd";
            string str2 = "abcde";
            string str3 = "ABCD";

            Debug.WriteLine("With 0 args");
            Assert.Equal(str1.ToCharArray(), car1);
            Assert.NotEqual(str2.ToCharArray(), car1);
            Assert.NotEqual(str3.ToCharArray(), car1);
            Assert.NotEqual(str1.ToCharArray(), car2);

            Debug.WriteLine("With 1 args");
            Assert.NotEqual(str1.ToCharArray(0, 3), car1);
            Assert.Equal(str2.ToCharArray(0, 4), car1);
            Assert.NotEqual(str3.ToCharArray(0, 3), car1);
            Assert.NotEqual(str1.ToCharArray(1, 3), car2);
        }

        [TestMethod]
        public void Split_Test15()
        {
            Debug.WriteLine("Testing the Split method");
            char[] car1 = new Char[] { '@', 'q' };
            char[] car2 = new Char[] { };
            string str1 = "ab@cd";
            string str2 = "abcd@";

            Assert.Equal(str1.Split(car1)[0], "ab");
            Assert.Equal(str1.Split(car1)[1], "cd");
            Assert.Equal(str2.Split(car1)[0], "abcd");
            Assert.Equal(str2.Split(car1)[1], "");
            Assert.Equal(str1.Split(car2)[0], "ab@cd");

            Debug.WriteLine("Verify split with a count");
            Debug.WriteLine("This is currently a known issue");
            Debug.WriteLine("20659	String.Split with a count parameter always returns the whole string.");
            string[] oneTwoThree = "1 2 3".Split(new char[] { ' ' }, 1);
            Assert.True(oneTwoThree.Length <= 1);
        }

        [TestMethod]
        public void Substring_Test17()
        {
            Debug.WriteLine("Testing the Substring method");
            string str1 = "abcde";

            Assert.Equal(str1.Substring(0), str1);
            Assert.Equal(str1.Substring(0, 5), str1);
            Assert.Equal(str1.Substring(2), "cde");
            Assert.Equal(str1.Substring(2, 1), "c");
        }

        [TestMethod]
        public void Trim_Test19()
        {
            Debug.WriteLine("Testing the Trim method");

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
            Debug.WriteLine("Testing the TrimStart method");

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
            Debug.WriteLine("Testing the TrimEnd method");

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
            Debug.WriteLine("Testing the IndexOf method");

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
            Debug.WriteLine("Testing the IndexOfAny method");

            string str1 = "@ abc@de ";
            char[] car1 = new Char[] { '@', 'b' };

            Assert.Equal(str1.IndexOfAny(car1), 0);
            Assert.Equal(str1.IndexOfAny(car1, 1), 3);
        }

        [TestMethod]
        public void LastIndexOf_Test37()
        {
            Debug.WriteLine("Testing the LastIndexOf method");

            string str1 = "@ abc@de ";
            Assert.Equal(str1.LastIndexOf('@'), 5);
            Assert.Equal(str1.LastIndexOf("abc"), 2);
            Assert.Equal(str1.LastIndexOf('@', 1), 5);
            Assert.Equal(str1.LastIndexOf('@', 1, 1), -1);
            Assert.Equal(str1.LastIndexOf("abc", 2), 2);
            Assert.Equal(str1.LastIndexOf("@", 6, 1), -1);
        }

        [TestMethod]
        public void LastIndexOfAny_Test40()
        {
            Debug.WriteLine("Testing the LastIndexOfAny method");

            string str1 = "@ abc@de ";
            char[] car1 = new Char[] { '@', 'b' };

            Assert.Equal(str1.LastIndexOfAny(car1), 5);
            Assert.Equal(str1.LastIndexOfAny(car1, 1), 5);
            Assert.Equal(str1.LastIndexOfAny(car1, 4, 1), -1);
        }

        [TestMethod]
        public void ToLower_Test51()
        {
            Debug.WriteLine("Testing the ToLower method");

            string str1 = "@ ABC@de ";
            Assert.Equal(str1.ToLower(), "@ abc@de ");
        }

        [TestMethod]
        public void ToUpper_Test52()
        {
            Debug.WriteLine("Testing the ToUpper method"); ;

            string str1 = "@ ABC@de ";
            Assert.Equal(str1.ToUpper(), "@ ABC@DE ");
        }

        [TestMethod]
        public void Length_Test71()
        {
            Debug.WriteLine("Testing the Length property"); ;

            string str1 = "@ ABC@de ";
            Assert.Equal(str1.Length, 9);
        }

        [TestMethod]
        public void Concat_Test1()
        {
            string str = "a" + 1 + "b" + new ToStringReturnsNull();
            Assert.Equal(str, "a1b");
        }
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

