//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

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
