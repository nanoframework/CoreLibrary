// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using nanoFramework.TestFramework;

namespace NFUnitTestSystemLib
{
    [TestClass]
    class CharTests
    {
        [TestMethod]
        public void Equals()
        {
            CharTestData[] testData = new CharTestData[]
            {
                new CharTestData((char)'a', (char)'a', true),
                new CharTestData((char)'a', (char)'A', false),
                new CharTestData((char)'a', (char)'b', false),
                new CharTestData((char)'a', (int)'a', false),
                new CharTestData((char)'a', "a", false),
                new CharTestData((char)'a', null, false)
            };

            foreach (var test in testData)
            {
                if (test.Obj is char)
                {
                    Assert.AreEqual(test.Expected, test.C.Equals((char)test.Obj));
                    Assert.AreEqual(test.Expected, test.C.GetHashCode().Equals(test.Obj.GetHashCode()));
                }

                Assert.AreEqual(test.Expected, test.C.Equals(test.Obj));
            }
        }

        private sealed class CharTestData
        {
            public object C { get; }
            public object Obj { get; }
            public bool Expected { get; }

            public CharTestData(object c, object obj, bool expected)
            {
                C = c;
                Obj = obj;
                Expected = expected;
            }
        }
    }
}
