//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;

namespace NFUnitTestString
{
    [TestClass]
    public class UnitTestStringTests
    {
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
    }
}
