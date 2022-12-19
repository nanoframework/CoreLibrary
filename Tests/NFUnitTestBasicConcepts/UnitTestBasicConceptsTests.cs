//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestBasicConcepts
{
    [TestClass]
    public class UnitTestBasicConceptsTests
    {
        [TestMethod]
        public void Basic_scope001_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a namespace member declared by");
            OutputHelper.WriteLine("a namespace-member-declaration with no enclosing");
            OutputHelper.WriteLine("namespace-declaration is the entire program text");
            OutputHelper.WriteLine("of each compilation unit.");
            Assert.IsTrue(Basic_TestClass_scope001.testMethod());
        }
        [TestMethod]
        public void Basic_scope002_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a namespace member declared by a ");
            OutputHelper.WriteLine("namespace-member-declaration within a ");
            OutputHelper.WriteLine("namespace-declaration whose fully qualified name");
            OutputHelper.WriteLine("is N is the namespace-body of every namespace-declaration");
            OutputHelper.WriteLine("whose fully qualified name is N or starts with the same ");
            OutputHelper.WriteLine("sequence of indentifiers as N.");
            Assert.IsTrue(NS_Basic_TestClass_scope002.Basic_TestClass_scope002.testMethod());
        }
        [TestMethod]
        public void Basic_scope003_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a namespace member declared by a ");
            OutputHelper.WriteLine("namespace-member-declaration within a ");
            OutputHelper.WriteLine("namespace-declaration whose fully qualified name");
            OutputHelper.WriteLine("is N is the namespace-body of every namespace-declaration");
            OutputHelper.WriteLine("whose fully qualified name is N or starts with the same ");
            OutputHelper.WriteLine("sequence of indentifiers as N.");
            Assert.IsTrue(NS_Basic_TestClass_scope003.Basic_TestClass_scope003.testMethod());
        }
        [TestMethod]
        public void Basic_scope004_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a namespace member declared by a ");
            OutputHelper.WriteLine("namespace-member-declaration within a ");
            OutputHelper.WriteLine("namespace-declaration whose fully qualified name");
            OutputHelper.WriteLine("is N is the namespace-body of every namespace-declaration");
            OutputHelper.WriteLine("whose fully qualified name is N or starts with the same ");
            OutputHelper.WriteLine("sequence of indentifiers as N.");
            Assert.IsTrue(NS_Basic_TestClass_scope004.NS_Basic_TestClass_scope004_2.Basic_TestClass_scope004.testMethod());
        }
        [TestMethod]
        public void Basic_scope005_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a namespace member declared by a ");
            OutputHelper.WriteLine("namespace-member-declaration within a ");
            OutputHelper.WriteLine("namespace-declaration whose fully qualified name");
            OutputHelper.WriteLine("is N is the namespace-body of every namespace-declaration");
            OutputHelper.WriteLine("whose fully qualified name is N or starts with the same ");
            OutputHelper.WriteLine("sequence of indentifiers as N.");
            Assert.IsTrue(NS_Basic_TestClass_scope005.NS_Basic_TestClass_scope005_2.Basic_TestClass_scope005.testMethod());
        }
        [TestMethod]
        public void Basic_scope006_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a namespace member declared by a ");
            OutputHelper.WriteLine("namespace-member-declaration within a ");
            OutputHelper.WriteLine("namespace-declaration whose fully qualified name");
            OutputHelper.WriteLine("is N is the namespace-body of every namespace-declaration");
            OutputHelper.WriteLine("whose fully qualified name is N or starts with the same ");
            OutputHelper.WriteLine("sequence of indentifiers as N.");
            Assert.IsTrue(NS_Basic_TestClass_scope006.NS_Basic_TestClass_scope006_2.Basic_TestClass_scope006.testMethod());
        }
        [TestMethod]
        public void Basic_scope012_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a name defined or imported by a using-directive");
            OutputHelper.WriteLine("extends over the namespace-member-declarations of the");
            OutputHelper.WriteLine("compilation-unit or namespace-body in which the using-directive");
            OutputHelper.WriteLine("occurs.");
            Assert.IsTrue(NS_Basic_TestClass_scope012.Basic_TestClass_scope012.testMethod());
        }
        [TestMethod]
        public void Basic_scope019_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a member declared by a class-member-declaration");
            OutputHelper.WriteLine("is the class body in which the declaration occurs.");
            Assert.IsTrue(Basic_TestClass_scope019.testMethod());
        }
        [TestMethod]
        public void Basic_scope022_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a member declared by a class-member-declaration");
            OutputHelper.WriteLine("is the class body in which the declaration occurs.  In addition,");
            OutputHelper.WriteLine("the scope of a class member extends to the class-body of those");
            OutputHelper.WriteLine("derived classes that are included in the accessibility domain");
            OutputHelper.WriteLine("of the member.");
            Assert.IsTrue(Basic_TestClass_scope022.testMethod());
        }
        [TestMethod]
        public void Basic_scope023_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a member declared by a class-member-declaration");
            OutputHelper.WriteLine("is the class body in which the declaration occurs.  In addition,");
            OutputHelper.WriteLine("the scope of a class member extends to the class-body of those");
            OutputHelper.WriteLine("derived classes that are included in the accessibility domain");
            OutputHelper.WriteLine("of the member.");
            Assert.IsTrue(Basic_TestClass_scope023.testMethod());
        }
        [TestMethod]
        public void Basic_scope024_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a member declared by a class-member-declaration");
            OutputHelper.WriteLine("is the class body in which the declaration occurs.  In addition,");
            OutputHelper.WriteLine("the scope of a class member extends to the class-body of those");
            OutputHelper.WriteLine("derived classes that are included in the accessibility domain");
            OutputHelper.WriteLine("of the member.");
            Assert.IsTrue(Basic_TestClass_scope024.testMethod());
        }
        [TestMethod]
        public void Basic_scope025_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a member declared by a struct-member-declaration");
            OutputHelper.WriteLine("is the struct-body in which the declaration occurs.");
            Assert.IsTrue(Basic_TestClass_scope025.testMethod());
        }
        [TestMethod]
        public void Basic_scope027_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a member declared by an enum-member-declaration");
            OutputHelper.WriteLine("is the enum-body in which the declaration occurs.");
            Assert.IsTrue(Basic_TestClass_scope027.testMethod());
        }
        [TestMethod]
        public void Basic_scope029_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a parameter declared in a constructor-declaration");
            OutputHelper.WriteLine("is the constructor-initializer and the block of that ");
            OutputHelper.WriteLine("constructor-declaration.");
            Assert.IsTrue(Basic_TestClass_scope029.testMethod());
        }
        [TestMethod]
        public void Basic_scope033_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a parameter declared in a method-declaration");
            OutputHelper.WriteLine("is the method-body of that method-declaration.");
            Assert.IsTrue(Basic_TestClass_scope033.testMethod());
        }
        [TestMethod]
        public void Basic_scope037_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a parameter declared in an indexer-declaration");
            OutputHelper.WriteLine("is the accessor-declarations of that indexer-declaration.");
            Assert.IsTrue(Basic_TestClass_scope037.testMethod());
        }
        [TestMethod]
        public void Basic_scope041_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a parameter declared in an operator-declaration");
            OutputHelper.WriteLine("is the block of that operator-declaration.");
            Assert.IsTrue(Basic_TestClass_scope041.testMethod());
        }
        [TestMethod]
        public void Basic_scope044_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a local variable declared in a local-variable-declaration");
            OutputHelper.WriteLine("is the block in which the declaration occurs.  It is an error to refer to");
            OutputHelper.WriteLine("a lcaol variable in a textual position that precedes the variable-declaratior");
            OutputHelper.WriteLine("of the local variable.");
            Assert.IsTrue(Basic_TestClass_scope044.testMethod());
        }
        [TestMethod]
        public void Basic_scope051_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a local variable in a for-initializer of a ");
            OutputHelper.WriteLine("for statement is the for-initializer, the for-condition,");
            OutputHelper.WriteLine("the for-iterator, and the contained statement of the for");
            OutputHelper.WriteLine("statement.");
            Assert.IsTrue(Basic_TestClass_scope051.testMethod());
        }
        [TestMethod]
        public void Basic_scope053_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a label declared in a label-statement");
            OutputHelper.WriteLine("is the block in which the declaration occurs.");
            Assert.IsTrue(Basic_TestClass_scope053.testMethod());
        }
        [TestMethod]
        public void Basic_scope055_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a label declared in a label-statement");
            OutputHelper.WriteLine("is the block in which the declaration occurs.");
            Assert.IsTrue(Basic_TestClass_scope055.testMethod());
        }
        [TestMethod]
        public void Basic_scope056_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("Within the scope of a namespace, class,");
            OutputHelper.WriteLine("struct, interface, or enumeration member ");
            OutputHelper.WriteLine("it is possible to refer to the member in ");
            OutputHelper.WriteLine("a textual position that precedes the ");
            OutputHelper.WriteLine("declaration of the member.");
            Assert.IsTrue(NS_Basic_TestClass_scope056.Basic_TestClass_scope056.testMethod());
        }
        [TestMethod]
        public void Basic_scope057_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("Within the scope of a namespace, class,");
            OutputHelper.WriteLine("struct, interface, or enumeration member ");
            OutputHelper.WriteLine("it is possible to refer to the member in ");
            OutputHelper.WriteLine("a textual position that precedes the ");
            OutputHelper.WriteLine("declaration of the member.");
            Assert.IsTrue(Basic_TestClass_scope057.testMethod());
        }
        [TestMethod]
        public void Basic_scope058_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("Within the scope of a namespace, class,");
            OutputHelper.WriteLine("struct, interface, or enumeration member ");
            OutputHelper.WriteLine("it is possible to refer to the member in ");
            OutputHelper.WriteLine("a textual position that precedes the ");
            OutputHelper.WriteLine("declaration of the member.");
            Assert.IsTrue(Basic_TestClass_scope058.testMethod());
        }
        [TestMethod]
        public void Basic_scope059_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("Within the scope of a namespace, class,");
            OutputHelper.WriteLine("struct, interface, or enumeration member ");
            OutputHelper.WriteLine("it is possible to refer to the member in ");
            OutputHelper.WriteLine("a textual position that precedes the ");
            OutputHelper.WriteLine("declaration of the member.");
            Assert.IsTrue(Basic_TestClass_scope059.testMethod());
        }
        [TestMethod]
        public void Basic_scope061_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("Witin the scope of a local variable, it is an");
            OutputHelper.WriteLine("error to refer to the local variable in a ");
            OutputHelper.WriteLine("textual position that precedes the");
            OutputHelper.WriteLine("variable-declarator of the local variable.");
            Assert.IsTrue(Basic_TestClass_scope061.testMethod());
        }
        [TestMethod]
        public void Basic_scope062_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The meaning of a name within a block may differ");
            OutputHelper.WriteLine("based on the context in which the name is used.");
            Assert.IsTrue(Basic_TestClass_scope062.testMethod());
        }
        [TestMethod]
        public void Basic_scope063_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            Assert.IsTrue(Basic_TestClass_scope063.testMethod());
        }
        [TestMethod]
        public void Basic_scope064_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            Assert.IsTrue(Basic_TestClass_scope064.testMethod());
        }
        [TestMethod]
        public void Basic_scope067_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            Assert.IsTrue(Basic_TestClass_scope067.testMethod());
        }
        [TestMethod]
        public void Basic_scope068_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            Assert.IsTrue(Basic_TestClass_scope068.testMethod());
        }
        [TestMethod]
        public void Basic_scope069_Test()
        {
            OutputHelper.WriteLine("Section 3");
            Assert.IsTrue(Basic_TestClass_scope069.testMethod());
        }
        [TestMethod]
        public void Basic_scope070_Test()
        {
            OutputHelper.WriteLine("Section 3");
            Assert.IsTrue(Basic_TestClass_scope070.testMethod());
        }
        [TestMethod]
        public void Basic_scope071_Test()
        {
            OutputHelper.WriteLine("Section 3");
            Assert.IsTrue(Basic_TestClass_scope071.testMethod());
        }
        [TestMethod]
        public void Basic_scope074_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            OutputHelper.WriteLine("The scope of a label declared in a label-statement");
            OutputHelper.WriteLine("is the block in which the declaration occurs.");
            Assert.IsTrue(Basic_TestClass_scope074.testMethod());
        }
        [TestMethod]
        public void Basic_nhide001_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide001.Basic_TestClass_nhide001.testMethod());
        }
        [TestMethod]
        public void Basic_nhide002_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide002.Basic_TestClass_nhide002.testMethod());
        }
        [TestMethod]
        public void Basic_nhide003_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide003.Basic_TestClass_nhide003.testMethod());
        }
        [TestMethod]
        public void Basic_nhide004_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide004.Basic_TestClass_nhide004.testMethod());
        }
        [TestMethod]
        public void Basic_nhide005_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide005.Basic_TestClass_nhide005.testMethod());
        }
        [TestMethod]
        public void Basic_nhide006_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide006.Basic_TestClass_nhide006.testMethod());
        }
        [TestMethod]
        public void Basic_nhide007_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide007.testMethod());
        }
        [TestMethod]
        public void Basic_nhide008_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide008.Basic_TestClass_nhide008.testMethod());
        }
        [TestMethod]
        public void Basic_nhide009_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide009.Basic_TestClass_nhide009.testMethod());
        }
        [TestMethod]
        public void Basic_nhide010_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide010.Basic_TestClass_nhide010.testMethod());
        }
        [TestMethod]
        public void Basic_nhide011_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide011.Basic_TestClass_nhide011.testMethod());
        }
        [TestMethod]
        public void Basic_nhide012_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide012.Basic_TestClass_nhide012.testMethod());
        }
        [TestMethod]
        public void Basic_nhide013_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(NS_Basic_TestClass_nhide013.Basic_TestClass_nhide013.testMethod());
        }
        [TestMethod]
        public void Basic_nhide014_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide014.testMethod());
        }
        [TestMethod]
        public void Basic_nhide015_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide015.testMethod());
        }
        [TestMethod]
        public void Basic_nhide016_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide016.testMethod());
        }
        [TestMethod]
        public void Basic_nhide017_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide017.testMethod());
        }
        [TestMethod]
        public void Basic_nhide018_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide018.testMethod());
        }
        [TestMethod]
        public void Basic_nhide019_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide019.testMethod());
        }
        [TestMethod]
        public void Basic_nhide020_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide020.testMethod());
        }
        [TestMethod]
        public void Basic_nhide021_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide021.testMethod());
        }
        [TestMethod]
        public void Basic_nhide022_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide022.testMethod());
        }
        [TestMethod]
        public void Basic_nhide023_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide023.testMethod());
        }
        [TestMethod]
        public void Basic_nhide024_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide024.testMethod());
        }
        [TestMethod]
        public void Basic_nhide025_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide025.testMethod());
        }
        [TestMethod]
        public void Basic_nhide026_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide026.testMethod());
        }
        [TestMethod]
        public void Basic_nhide027_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide027.testMethod());
        }
        [TestMethod]
        public void Basic_nhide028_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide028.testMethod());
        }
        [TestMethod]
        public void Basic_nhide029_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide029.testMethod());
        }
        [TestMethod]
        public void Basic_nhide030_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide030.testMethod());
        }
        [TestMethod]
        public void Basic_nhide031_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide031.testMethod());
        }
        [TestMethod]
        public void Basic_nhide032_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide032.testMethod());
        }
        [TestMethod]
        public void Basic_nhide033_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide033.testMethod());
        }
        [TestMethod]
        public void Basic_nhide034_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide034.testMethod());
        }
        [TestMethod]
        public void Basic_nhide035_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide035.testMethod());
        }
        [TestMethod]
        public void Basic_nhide036_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide036.testMethod());
        }
        [TestMethod]
        public void Basic_nhide037_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide037.testMethod());
        }
        [TestMethod]
        public void Basic_nhide038_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide038.testMethod());
        }
        [TestMethod]
        public void Basic_nhide039_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide039.testMethod());
        }
        [TestMethod]
        public void Basic_nhide040_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide040.testMethod());
        }
        [TestMethod]
        public void Basic_nhide041_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide041.testMethod());
        }
        [TestMethod]
        public void Basic_nhide042_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide042.testMethod());
        }
        [TestMethod]
        public void Basic_nhide043_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide043.testMethod());
        }
        [TestMethod]
        public void Basic_nhide044_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Name hiding through nesting can occur as a result of");
            OutputHelper.WriteLine("nesting namespaces or types within namespaces, as a ");
            OutputHelper.WriteLine("result of nesting types within classes or structs,");
            OutputHelper.WriteLine("and as a result of parameter and local variable");
            OutputHelper.WriteLine("declarations.  Name hiding through nesting of scopes");
            OutputHelper.WriteLine("always occurs silently, i.e. no errors or warnings");
            OutputHelper.WriteLine("are reported when outer names are hidden by inner names.");
            Assert.IsTrue(Basic_TestClass_nhide044.testMethod());
        }
        [TestMethod]
        public void Basic_nhide045_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("When a name in an inner scope hides a name");
            OutputHelper.WriteLine("in an outer scope, it hides all overloaded ");
            OutputHelper.WriteLine("occurrences of that name.");
            Assert.IsTrue(Basic_TestClass_nhide045.testMethod());
        }
        [TestMethod]
        public void Basic_nhide047_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("When a name in an inner scope hides a name");
            OutputHelper.WriteLine("in an outer scope, it hides all overloaded ");
            OutputHelper.WriteLine("occurrences of that name.");
            Assert.IsTrue(Basic_TestClass_nhide047.testMethod());
        }
        [TestMethod]
        public void Basic_nhide049_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("When a name in an inner scope hides a name");
            OutputHelper.WriteLine("in an outer scope, it hides all overloaded ");
            OutputHelper.WriteLine("occurrences of that name.");
            Assert.IsTrue(Basic_TestClass_nhide049.testMethod());
        }
        [TestMethod]
        public void Basic_nhide050_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("When a name in an inner scope hides a name");
            OutputHelper.WriteLine("in an outer scope, it hides all overloaded ");
            OutputHelper.WriteLine("occurrences of that name.");
            Assert.IsTrue(Basic_TestClass_nhide050.testMethod());
        }
        [TestMethod]
        public void Basic_nhide051_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("When a name in an inner scope hides a name");
            OutputHelper.WriteLine("in an outer scope, it hides all overloaded ");
            OutputHelper.WriteLine("occurrences of that name.");
            Assert.IsTrue(Basic_TestClass_nhide051.testMethod());
        }
        [TestMethod]
        public void Basic_nhide053_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("When a name in an inner scope hides a name");
            OutputHelper.WriteLine("in an outer scope, it hides all overloaded ");
            OutputHelper.WriteLine("occurrences of that name.");
            Assert.IsTrue(Basic_TestClass_nhide053.testMethod());
        }
        [TestMethod]
        public void Basic_nhide055_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("When a name in an inner scope hides a name");
            OutputHelper.WriteLine("in an outer scope, it hides all overloaded ");
            OutputHelper.WriteLine("occurrences of that name.");
            Assert.IsTrue(Basic_TestClass_nhide055.testMethod());
        }
        [TestMethod]
        public void Basic_nhide056_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("When a name in an inner scope hides a name");
            OutputHelper.WriteLine("in an outer scope, it hides all overloaded ");
            OutputHelper.WriteLine("occurrences of that name.");
            Assert.IsTrue(Basic_TestClass_nhide056.testMethod());
        }
        [TestMethod]
        public void Basic_nhide057_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("When a name in an inner scope hides a name");
            OutputHelper.WriteLine("in an outer scope, it hides all overloaded ");
            OutputHelper.WriteLine("occurrences of that name.");
            Assert.IsTrue(Basic_TestClass_nhide057.testMethod());
        }
        [TestMethod]
        public void Basic_nhide059_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("When a name in an inner scope hides a name");
            OutputHelper.WriteLine("in an outer scope, it hides all overloaded ");
            OutputHelper.WriteLine("occurrences of that name.");
            Assert.IsTrue(Basic_TestClass_nhide059.testMethod());
        }
        [TestMethod]
        public void Basic_nhide061_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A constant, field, property, event or type introduced");
            OutputHelper.WriteLine("in a class or struct hides all base class members with the ");
            OutputHelper.WriteLine("same name.");
            Assert.IsTrue(Basic_TestClass_nhide061.testMethod());
        }
        [TestMethod]
        public void Basic_nhide062_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A constant, field, property, event or type introduced");
            OutputHelper.WriteLine("in a class or struct hides all base class members with the ");
            OutputHelper.WriteLine("same name.");
            Assert.IsTrue(Basic_TestClass_nhide062.testMethod());
        }
        [TestMethod]
        public void Basic_nhide063_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A constant, field, property, event or type introduced");
            OutputHelper.WriteLine("in a class or struct hides all base class members with the ");
            OutputHelper.WriteLine("same name.");
            Assert.IsTrue(Basic_TestClass_nhide063.testMethod());
        }
        [TestMethod]
        public void Basic_nhide064_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A constant, field, property, event or type introduced");
            OutputHelper.WriteLine("in a class or struct hides all base class members with the ");
            OutputHelper.WriteLine("same name.");
            Assert.IsTrue(Basic_TestClass_nhide064.testMethod());
        }
        [TestMethod]
        public void Basic_nhide067_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A constant, field, property, event or type introduced");
            OutputHelper.WriteLine("in a class or struct hides all base class members with the ");
            OutputHelper.WriteLine("same name.");
            Assert.IsTrue(Basic_TestClass_nhide067.testMethod());
        }
        [TestMethod]
        public void Basic_nhide068_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A constant, field, property, event or type introduced");
            OutputHelper.WriteLine("in a class or struct hides all base class members with the ");
            OutputHelper.WriteLine("same name.");
            Assert.IsTrue(Basic_TestClass_nhide068.testMethod());
        }
        [TestMethod]
        public void Basic_nhide071_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide071.testMethod());
        }
        [TestMethod]
        public void Basic_nhide072_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide072.testMethod());
        }
        [TestMethod]
        public void Basic_nhide075_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide075.testMethod());
        }
        [TestMethod]
        public void Basic_nhide076_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide076.testMethod());
        }
        [TestMethod]
        public void Basic_nhide077_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide077.testMethod());
        }
        [TestMethod]
        public void Basic_nhide079_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide079.testMethod());
        }
        [TestMethod]
        public void Basic_nhide081_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide081.testMethod());
        }
        [TestMethod]
        public void Basic_nhide082_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide082.testMethod());
        }
        [TestMethod]
        public void Basic_nhide085_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide085.testMethod());
        }
        [TestMethod]
        public void Basic_nhide086_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide086.testMethod());
        }
        [TestMethod]
        public void Basic_nhide087_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            Assert.IsTrue(Basic_TestClass_nhide087.testMethod());
        }
        [TestMethod]
        public void Basic_nhide088_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A method introduced in a class or a struct");
            OutputHelper.WriteLine("hides all non-method base class members with");
            OutputHelper.WriteLine("the same name, and all base class methods");
            OutputHelper.WriteLine("with the same signature (method name and");
            OutputHelper.WriteLine("parameter count, modifiers, and types).");
            OutputHelper.WriteLine("This test passes in the baseline, but is an expected Fail");
            OutputHelper.WriteLine("See bug 16852 for more details");

            Assert.IsTrue(Basic_TestClass_nhide088.testMethod());
        }
        [TestMethod]
        public void Basic_nhide089_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("An indexer introduced in a class or a struct");
            OutputHelper.WriteLine("hides all base class indexers with the same");
            OutputHelper.WriteLine("signature (parameter count and types).");
            Assert.IsTrue(Basic_TestClass_nhide089.testMethod());
        }
        [TestMethod]
        public void Basic_nhide090_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("An indexer introduced in a class or a struct");
            OutputHelper.WriteLine("hides all base class indexers with the same");
            OutputHelper.WriteLine("signature (parameter count and types).");
            Assert.IsTrue(Basic_TestClass_nhide090.testMethod());
        }
        [TestMethod]
        public void Basic_nhide091_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("Contrary to hiding a name from an outer scope,");
            OutputHelper.WriteLine("hding an accessible name from an inherited scope");
            OutputHelper.WriteLine("causes a warning to be reported.");
            Assert.IsTrue(Basic_TestClass_nhide091.testMethod());
        }
        [TestMethod]
        public void Basic_nhide092_Test()
        {
            OutputHelper.WriteLine("Section 3.5.1");
            OutputHelper.WriteLine("A declaration of a new member hides an inherited");
            OutputHelper.WriteLine("member only within the scope of the new member.");
            Assert.IsTrue(Basic_TestClass_nhide092.testMethod());
        }
        [TestMethod]
        public void Basic_memac009_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Then, if M is public, the access is permitted.");
            Assert.IsTrue(Basic_TestClass_memac009.testMethod());
        }
        [TestMethod]
        public void Basic_memac010_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Then, if M is public, the access is permitted.");
            Assert.IsTrue(Basic_TestClass_memac010.testMethod());
        }
        [TestMethod]
        public void Basic_memac011_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is protected internal, the access");
            OutputHelper.WriteLine("is permitted if it occurs within the project in which");
            OutputHelper.WriteLine("M is declared, or if it occurs within a class derived ");
            OutputHelper.WriteLine("from the class in which M is declared and takes place ");
            OutputHelper.WriteLine("through the derived class type.");
            Assert.IsTrue(Basic_TestClass_memac011.testMethod());
        }
        [TestMethod]
        public void Basic_memac012_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is protected internal, the access");
            OutputHelper.WriteLine("is permitted if it occurs within the project in which");
            OutputHelper.WriteLine("M is declared, or if it occurs within a class derived ");
            OutputHelper.WriteLine("from the class in which M is declared and takes place ");
            OutputHelper.WriteLine("through the derived class type.");
            Assert.IsTrue(Basic_TestClass_memac012.testMethod());
        }
        /*
         * These tests were removed because they required additional files, they fail in the baseline
         * 
        [TestMethod]
        public void Basic_memac013_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is protected internal, the access");
            OutputHelper.WriteLine("is permitted if it occurs within the project in which");
            OutputHelper.WriteLine("M is declared, or if it occurs within a class derived ");
            OutputHelper.WriteLine("from the class in which M is declared and takes place ");
            OutputHelper.WriteLine("through the derived class type.");
            Assert.IsTrue(Basic_TestClass_memac013.testMethod())
            {
                return MFTestResults.Pass;
            }
            return MFTestResults.Fail;
        }
        [TestMethod]
        public void Basic_memac014_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is protected internal, the access");
            OutputHelper.WriteLine("is permitted if it occurs within the project in which");
            OutputHelper.WriteLine("M is declared, or if it occurs within a class derived ");
            OutputHelper.WriteLine("from the class in which M is declared and takes place ");
            OutputHelper.WriteLine("through the derived class type.");
            Assert.IsTrue(Basic_TestClass_memac014.testMethod())
            {
                return MFTestResults.Pass;
            }
            return MFTestResults.Fail;
        }
         * */
        [TestMethod]
        public void Basic_memac019_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is protected, the access is permitted");
            OutputHelper.WriteLine("if it occurs within the class in which M is declared, or");
            OutputHelper.WriteLine("if it occurs within a class derived from the class in");
            OutputHelper.WriteLine("which M is delared and takes place through the derived class ");
            OutputHelper.WriteLine("type.");
            Assert.IsTrue(Basic_TestClass_memac019.testMethod());
        }
        [TestMethod]
        public void Basic_memac020_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is protected, the access is permitted");
            OutputHelper.WriteLine("if it occurs within the class in which M is declared, or");
            OutputHelper.WriteLine("if it occurs within a class derived from the class in");
            OutputHelper.WriteLine("which M is delared and takes place through the derived class ");
            OutputHelper.WriteLine("type.");
            Assert.IsTrue(Basic_TestClass_memac020.testMethod());
        }
        [TestMethod]
        public void Basic_memac021_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is protected, the access is permitted");
            OutputHelper.WriteLine("if it occurs within the class in which M is declared, or");
            OutputHelper.WriteLine("if it occurs within a class derived from the class in");
            OutputHelper.WriteLine("which M is delared and takes place through the derived class ");
            OutputHelper.WriteLine("type.");
            Assert.IsTrue(Basic_TestClass_memac021.testMethod());
        }
        [TestMethod]
        public void Basic_memac022_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is protected, the access is permitted");
            OutputHelper.WriteLine("if it occurs within the class in which M is declared, or");
            OutputHelper.WriteLine("if it occurs within a class derived from the class in");
            OutputHelper.WriteLine("which M is delared and takes place through the derived class ");
            OutputHelper.WriteLine("type.");
            Assert.IsTrue(Basic_TestClass_memac022.testMethod());
        }
        [TestMethod]
        public void Basic_memac025_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is protected, the access is permitted");
            OutputHelper.WriteLine("if it occurs within the class in which M is declared, or");
            OutputHelper.WriteLine("if it occurs within a class derived from the class in");
            OutputHelper.WriteLine("which M is delared and takes place through the derived class ");
            OutputHelper.WriteLine("type.");
            Assert.IsTrue(Basic_TestClass_memac025.testMethod());
        }
        [TestMethod]
        public void Basic_memac027_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is internal, the access is permitted");
            OutputHelper.WriteLine("if it occurs within the project in which M is declared.");
            Assert.IsTrue(Basic_TestClass_memac027.testMethod());
        }
        [TestMethod]
        public void Basic_memac029_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is internal, the access is permitted");
            OutputHelper.WriteLine("if it occurs within the project in which M is declared.");
            Assert.IsTrue(Basic_TestClass_memac029.testMethod());
        }
        [TestMethod]
        public void Basic_memac030_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is internal, the access is permitted");
            OutputHelper.WriteLine("if it occurs within the project in which M is declared.");
            Assert.IsTrue(Basic_TestClass_memac030.testMethod());
        }
        [TestMethod]
        public void Basic_memac033_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is private, the access is permitted");
            OutputHelper.WriteLine("if it occurs within the type in which M is declared.");
            Assert.IsTrue(Basic_TestClass_memac033.testMethod());
        }
        [TestMethod]
        public void Basic_memac034_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("Otherwise, if M is private, the access is permitted");
            OutputHelper.WriteLine("if it occurs within the type in which M is declared.");
            Assert.IsTrue(Basic_TestClass_memac034.testMethod());
        }

        /*
         * These tests were skipped because they require extra files, they fail in the baseline.
         * 
        [TestMethod]
        public void Basic_memac039_Test()
        {
            OutputHelper.WriteLine("VS Bug 75548");
            Assert.IsTrue(Basic_TestClass_memac039.testMethod())
            {
                return MFTestResults.Pass;
            }
            return MFTestResults.Fail;
        }
        [TestMethod]
        public void Basic_memac041_Test()
        {
            Assert.IsTrue(Basic_TestClass_memac041.testMethod())
            {
                return MFTestResults.Pass;
            }
            return MFTestResults.Fail;
        }
         * */
        [TestMethod]
        public void Basic_memac042_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            Assert.IsTrue(Basic_TestClass_memac042.testMethod());
        }
        [TestMethod]
        public void Basic_memac043_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            Assert.IsTrue(Basic_TestClass_memac043.testMethod());
        }
        [TestMethod]
        public void Basic_memac044_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            Assert.IsTrue(Basic_TestClass_memac044.testMethod());
        }
        [TestMethod]
        public void Basic_memac045_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            Assert.IsTrue(Basic_TestClass_memac045.testMethod());
        }
        [TestMethod]
        public void Basic_memac046_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            Assert.IsTrue(Basic_TestClass_memac046.testMethod());
        }
        [TestMethod]
        public void Basic_memac047_Test()
        {
            OutputHelper.WriteLine("Section 3.5");
            Assert.IsTrue(Basic_TestClass_memac047.testMethod());
        }
        [TestMethod]
        public void Basic_accon001_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The direct base class of a class type must be");
            OutputHelper.WriteLine("at least as accessible as the class type itself.");
            Assert.IsTrue(Basic_TestClass_accon001.testMethod());
        }
        [TestMethod]
        public void Basic_accon003_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The direct base class of a class type must be");
            OutputHelper.WriteLine("at least as accessible as the class type itself.");
            Assert.IsTrue(Basic_TestClass_accon003.testMethod());
        }
        [TestMethod]
        public void Basic_accon005_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The direct base class of a class type must be");
            OutputHelper.WriteLine("at least as accessible as the class type itself.");
            Assert.IsTrue(Basic_TestClass_accon005.testMethod());
        }
        [TestMethod]
        public void Basic_accon007_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The direct base class of a class type must be");
            OutputHelper.WriteLine("at least as accessible as the class type itself.");
            Assert.IsTrue(Basic_TestClass_accon007.testMethod());
        }
        [TestMethod]
        public void Basic_accon009_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The direct base class of a class type must be");
            OutputHelper.WriteLine("at least as accessible as the class type itself.");
            Assert.IsTrue(Basic_TestClass_accon009.testMethod());
        }
        [TestMethod]
        public void Basic_accon011_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The direct base class of a class type must be");
            OutputHelper.WriteLine("at least as accessible as the class type itself.");
            Assert.IsTrue(Basic_TestClass_accon011.testMethod());
        }
        [TestMethod]
        public void Basic_accon013_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The direct base class of a class type must be");
            OutputHelper.WriteLine("at least as accessible as the class type itself.");
            Assert.IsTrue(Basic_TestClass_accon013.testMethod());
        }
        [TestMethod]
        public void Basic_accon015_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The direct base class of a class type must be");
            OutputHelper.WriteLine("at least as accessible as the class type itself.");
            Assert.IsTrue(Basic_TestClass_accon015.testMethod());
        }
        [TestMethod]
        public void Basic_accon019_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The direct base class of a class type must be");
            OutputHelper.WriteLine("at least as accessible as the class type itself.");
            Assert.IsTrue(Basic_TestClass_accon019.testMethod());
        }
        [TestMethod]
        public void Basic_accon021_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The direct base class of a class type must be");
            OutputHelper.WriteLine("at least as accessible as the class type itself.");
            Assert.IsTrue(Basic_TestClass_accon021.testMethod());
        }
        [TestMethod]
        public void Basic_accon023_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The explicit base interfaces of an interface ");
            OutputHelper.WriteLine("type must be at least as accessible as the interface");
            OutputHelper.WriteLine("type itself.");
            Assert.IsTrue(Basic_TestClass_accon023.testMethod());
        }
        [TestMethod]
        public void Basic_accon025_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The explicit base interfaces of an interface ");
            OutputHelper.WriteLine("type must be at least as accessible as the interface");
            OutputHelper.WriteLine("type itself.");
            Assert.IsTrue(Basic_TestClass_accon025.testMethod());
        }
        [TestMethod]
        public void Basic_accon027_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The explicit base interfaces of an interface ");
            OutputHelper.WriteLine("type must be at least as accessible as the interface");
            OutputHelper.WriteLine("type itself.");
            Assert.IsTrue(Basic_TestClass_accon027.testMethod());
        }
        [TestMethod]
        public void Basic_accon029_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The explicit base interfaces of an interface ");
            OutputHelper.WriteLine("type must be at least as accessible as the interface");
            OutputHelper.WriteLine("type itself.");
            Assert.IsTrue(Basic_TestClass_accon029.testMethod());
        }
        [TestMethod]
        public void Basic_accon031_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The explicit base interfaces of an interface ");
            OutputHelper.WriteLine("type must be at least as accessible as the interface");
            OutputHelper.WriteLine("type itself.");
            Assert.IsTrue(Basic_TestClass_accon031.testMethod());
        }
        [TestMethod]
        public void Basic_accon033_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The return type and parameter types of a delegate");
            OutputHelper.WriteLine("type must be at least as accessible as the delegate");
            OutputHelper.WriteLine("ytpe itself.");
            Assert.IsTrue(Basic_TestClass_accon033.testMethod());
        }
        [TestMethod]
        public void Basic_accon035_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The return type and parameter types of a delegate");
            OutputHelper.WriteLine("type must be at least as accessible as the delegate");
            OutputHelper.WriteLine("ytpe itself.");
            Assert.IsTrue(Basic_TestClass_accon035.testMethod());
        }
        [TestMethod]
        public void Basic_accon037_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The type of a constant must be at least as");
            OutputHelper.WriteLine("accessible as the constant itself.");
            Assert.IsTrue(Basic_TestClass_accon037.testMethod());
        }
        [TestMethod]
        public void Basic_accon039_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The type of a field must be at least as accessible");
            OutputHelper.WriteLine("as the field itself.");
            Assert.IsTrue(Basic_TestClass_accon039.testMethod());
        }
        [TestMethod]
        public void Basic_accon041_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The return type and parameter types of a method");
            OutputHelper.WriteLine("must be at least asaccessible as the method itself.");
            Assert.IsTrue(Basic_TestClass_accon041.testMethod());
        }
        [TestMethod]
        public void Basic_accon043_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The return type and parameter types of a method");
            OutputHelper.WriteLine("must be at least asaccessible as the method itself.");
            Assert.IsTrue(Basic_TestClass_accon043.testMethod());
        }
        [TestMethod]
        public void Basic_accon045_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The type of a property must be at least as");
            OutputHelper.WriteLine("accessible as the property itself.");
            Assert.IsTrue(Basic_TestClass_accon045.testMethod());
        }
        [TestMethod]
        public void Basic_accon047_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The return type and parameter types of an");
            OutputHelper.WriteLine("indexer must be at least as accessible as the");
            OutputHelper.WriteLine("indexer itself.");
            Assert.IsTrue(Basic_TestClass_accon047.testMethod());
        }
        [TestMethod]
        public void Basic_accon049_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The return type and parameter types of an");
            OutputHelper.WriteLine("indexer must be at least as accessible as the");
            OutputHelper.WriteLine("indexer itself.");
            Assert.IsTrue(Basic_TestClass_accon049.testMethod());
        }
        [TestMethod]
        public void Basic_accon051_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The return type and parameter types of an");
            OutputHelper.WriteLine("operator must be at least as accessible as");
            OutputHelper.WriteLine("the operator itself.");
            Assert.IsTrue(Basic_TestClass_accon051.testMethod());
        }
        [TestMethod]
        public void Basic_accon053_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The return type and parameter types of an");
            OutputHelper.WriteLine("operator must be at least as accessible as");
            OutputHelper.WriteLine("the operator itself.");
            Assert.IsTrue(Basic_TestClass_accon053.testMethod());
        }
        [TestMethod]
        public void Basic_accon055_Test()
        {
            OutputHelper.WriteLine("Section 3.3");
            OutputHelper.WriteLine("The parameter types of a constructor must be at least");
            OutputHelper.WriteLine("as accessible as the constructor itself.");
            Assert.IsTrue(Basic_TestClass_accon055.testMethod());
        }

        class Basic_TestClass_scope001
        {
            public static int Main_old()
            {
                if ((Basic_TestClass_scope001_C1.intI == 1) && (NS_Basic_TestClass_scope001.MyClass2.intI == 2))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope001_C1
        {
            public static int intI = 1;
        }



        class Basic_TestClass_scope019
        {
            int intTest = 1;
            static int intTest2 = 2;
            string strTest = "test";
            static string strTest2 = "test2";
            class Basic_TestClass_scope019_C1 { }
            public Basic_TestClass_scope019()
            {
                int intI = intTest;
                string strS = strTest;
                Basic_TestClass_scope019_C1 tc = new Basic_TestClass_scope019_C1();
            }
            ~Basic_TestClass_scope019()
            {
                int intI = intTest;
                string strS = strTest;
                Basic_TestClass_scope019_C1 tc = new Basic_TestClass_scope019_C1();
            }
            public void TestMeth()
            {
                int intI = intTest;
                string strS = strTest;
                Basic_TestClass_scope019_C1 tc = new Basic_TestClass_scope019_C1();
            }
            public static int Main_old()
            {
                int intI = intTest2;
                string strS = strTest2;
                Basic_TestClass_scope019_C1 tc = new Basic_TestClass_scope019_C1();
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope022_C2
        {
            protected int intTest = 1;
            public static int intTest2 = 2;
            internal string strTest = "test";
            public static string strTest2 = "test2";
            public class Basic_TestClass_scope022 { }
        }
        class Basic_TestClass_scope022 : Basic_TestClass_scope022_C2
        {
            public Basic_TestClass_scope022()
            {
                int intI = intTest;
                string strS = strTest;
                Basic_TestClass_scope022 tc = new Basic_TestClass_scope022();
            }
            ~Basic_TestClass_scope022()
            {
                int intI = intTest;
                string strS = strTest;
                Basic_TestClass_scope022 tc = new Basic_TestClass_scope022();
            }
            public void TestMeth()
            {
                int intI = intTest;
                string strS = strTest;
                Basic_TestClass_scope022 tc = new Basic_TestClass_scope022();
            }
            public static int Main_old()
            {
                int intI = intTest2;
                string strS = strTest2;
                Basic_TestClass_scope022 tc = new Basic_TestClass_scope022();
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope023
        {
            public int intTest = 1;
            class Basic_TestClass_scope023_C1 : Basic_TestClass_scope023
            {

                public int RetInt()
                {
                    return intTest;
                }
                public static int Main_old()
                {
                    Basic_TestClass_scope023_C1 tc = new Basic_TestClass_scope023_C1();
                    if (tc.RetInt() == 1)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_scope023_C1.Main_old() == 0);
            }

        }
        class Basic_TestClass_scope024
        {
            static int intTest = 1;
            class Basic_TestClass_scope024_C1
            {

                public int RetInt()
                {
                    return intTest;
                }
                public static int Main_old()
                {
                    Basic_TestClass_scope024_C1 tc = new Basic_TestClass_scope024_C1();
                    if (tc.RetInt() == 1)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_scope024_C1.Main_old() == 0);
            }

        }
        struct Basic_TestClass_scope025
        {
            int intTest;
            static int intTest2;
            string strTest;
            static string strTest2;
            struct Basic_TestClass_scope025_C1 { }
            public void TestMeth()
            {
                int intI = intTest;
                string strS = strTest;
                Basic_TestClass_scope025_C1 tc = new Basic_TestClass_scope025_C1();
            }
            public static int Main_old()
            {
                int intI = intTest2;
                string strS = strTest2;
                Basic_TestClass_scope025_C1 tc = new Basic_TestClass_scope025_C1();
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        enum Basic_TestClass_scope027_Enum { aa = 2, bb = aa }
        public class Basic_TestClass_scope027
        {
            public static int Main_old()
            {
                if ((int)Basic_TestClass_scope027_Enum.bb == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_scope029_C2
        {
            protected int intI;
            protected string strS;
            protected Basic_TestClass_scope029_C2(int i, string s)
            {
                intI = i;
                strS = s;
            }
        }
        public class Basic_TestClass_scope029 : Basic_TestClass_scope029_C2
        {

            int intI2;
            string strS2;
            public Basic_TestClass_scope029(int i, string s)
                : base(i, s)
            {
                intI2 = i + 1;
                strS2 = s + "!";
            }
            public static int Main_old()
            {
                Basic_TestClass_scope029 test = new Basic_TestClass_scope029(2, "test");
                if ((test.intI == 2) && (test.strS == "test") && (test.intI2 == 3) && (test.strS2 == "test!"))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_scope033
        {

            int intI;
            string strS;
            public void Basic_TestClass_scope033_C1(int i, string s)
            {
                intI = i;
                strS = s;
            }
            public static int Main_old()
            {
                Basic_TestClass_scope033 TC = new Basic_TestClass_scope033();
                TC.Basic_TestClass_scope033_C1(2, "test");
                if ((TC.intI == 2) && (TC.strS == "test"))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_scope037
        {

            int intI;
            string strS;
            public string this[int i, string s]
            {
                get
                {
                    return s + i;
                }
                set
                {
                    intI = i;
                    strS = s;
                }
            }
            public static int Main_old()
            {
                Basic_TestClass_scope037 test = new Basic_TestClass_scope037();
                test[2, "test"] = "QQQ";
                if ((test[2, "test"] == "test2") && (test.intI == 2) && (test.strS == "test"))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope041
        {
            public int intI = 2;
            public static Basic_TestClass_scope041 operator +(Basic_TestClass_scope041 MyInt)
            {
                MyInt.intI = 3;
                return new Basic_TestClass_scope041();
            }
            public static int Main_old()
            {
                Basic_TestClass_scope041 Basic_TestClass_scope041_C1 = new Basic_TestClass_scope041();
                Basic_TestClass_scope041 temp = +Basic_TestClass_scope041_C1;
                if (Basic_TestClass_scope041_C1.intI == 3)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope044
        {
            public bool Basic_TestClass_scope044_C1()
            {
                int intI = 1;
                string strS = "test";
                if ((intI == 1) && (strS == "test"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static int Main_old()
            {
                int intI = 2;
                string strS = "test2";
                if ((intI != 2) || (strS != "test2"))
                {
                    return 1;
                }
                for (intI = 1; intI < 3; intI++)
                {
                    int intI2 = 3;
                    string strS2 = "test3";
                    if ((intI2 != 3) || (strS2 != "test3"))
                    {
                        return 1;
                    }
                }
                {
                    int intI3 = 4;
                    string strS3 = "test4";
                    if ((intI3 != 4) || (strS3 != "test4"))
                    {
                        return 1;
                    }
                }
                Basic_TestClass_scope044 TC = new Basic_TestClass_scope044();
                if (TC.Basic_TestClass_scope044_C1() == true)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope051
        {
            public static int Main_old()
            {

                int i = 0;
                for (int intI = 0; intI < 3; intI++)
                {
                    int intJ = intI;
                    i++;
                }
                if (i == 3)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope053
        {
            public static int Main_old()
            {

                int Basic_TestClass_scope053_A = 2;
                goto Basic_TestClass_scope053_A;
                Basic_TestClass_scope053_A++;
            Basic_TestClass_scope053_A: Basic_TestClass_scope053_A++;
                if (Basic_TestClass_scope053_A == 3)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope055
        {
            public static int Main_old()
            {

                int Basic_TestClass_scope055_A = 2;
                {
                    goto Basic_TestClass_scope055_A;
                    Basic_TestClass_scope055_A++;
                }
            Basic_TestClass_scope055_A: Basic_TestClass_scope055_A++;
                if (Basic_TestClass_scope055_A == 3)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }



        class Basic_TestClass_scope057
        {
            public static int Main_old()
            {
                Basic_TestClass_scope057 TC = new Basic_TestClass_scope057();
                if (TC.test())
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public bool test()
            {
                if (intI == 1)
                {
                    return true;
                }
                return false;
            }
            int intI = 1;
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        struct Basic_TestClass_scope058
        {
            public static int Main_old()
            {
                Basic_TestClass_scope058 TS = new Basic_TestClass_scope058(1);
                if (TS.test())
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public bool test()
            {
                if (intI == 1)
                {
                    return true;
                }
                return false;
            }
            public Basic_TestClass_scope058(int i)
            {
                intI = i;
            }

            int intI;
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        enum Basic_TestClass_scope059_Enum { AA = BB, BB = 1 }
        public class Basic_TestClass_scope059
        {
            public static int Main_old()
            {
                if ((int)Basic_TestClass_scope059_Enum.AA == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_scope061
        {

            void G()
            {
                int j = (j = 1);
            }
            void H()
            {
                int a = 1, b = ++a;
            }
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope062_A { }
        public class Basic_TestClass_scope062
        {
            public static int Main_old()
            {
                string Basic_TestClass_scope062_A = "test";
                string S = Basic_TestClass_scope062_A;

                Type t = typeof(Basic_TestClass_scope062_A);
                if (t != typeof(string))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_scope063_C1 { }
        public class Basic_TestClass_scope063
        {
            static int Basic_TestClass_scope063_C1 = 2;

            public static int Main_old()
            {
                if (Basic_TestClass_scope063_C1 == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_scope064_C1
        {
            public int intI = 3;
        }
        public class Basic_TestClass_scope064
        {
            static int Basic_TestClass_scope064_C1 = 2;

            public static int Main_old()
            {
                Basic_TestClass_scope064_C1 tc = new Basic_TestClass_scope064_C1();
                if (tc.intI == 3)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_scope067_C1 { }
        public class Basic_TestClass_scope067
        {
            int Basic_TestClass_scope067_C1 = 2;
            public int TestMeth()
            {
                if (Basic_TestClass_scope067_C1 == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            public static int Main_old()
            {
                Basic_TestClass_scope067 MC = new Basic_TestClass_scope067();
                return MC.TestMeth();
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_scope068_C1
        {
            public int intI = 3;
        }
        public class Basic_TestClass_scope068
        {
            int Basic_TestClass_scope068_C1 = 2;
            public int TestMeth()
            {
                Basic_TestClass_scope068_C1 tc = new Basic_TestClass_scope068_C1();
                if (tc.intI == 3)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            public static int Main_old()
            {
                Basic_TestClass_scope068 MC = new Basic_TestClass_scope068();
                return MC.TestMeth();

            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope069
        {
            private class MyInner
            {
                public int MyMeth(MyInner2 arg)
                {
                    return arg.intI;
                }
            }
            protected class MyInner2
            {
                public int intI = 2;
            }
            public static int Main_old()
            {
                MyInner MI = new MyInner();
                if (MI.MyMeth(new MyInner2()) == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope070
        {
            protected class MyInner
            {
                public int MyMeth(MyInner2 arg)
                {
                    return arg.intI;
                }
            }
            protected class MyInner2
            {
                public int intI = 2;
            }
            public static int Main_old()
            {
                MyInner MI = new MyInner();
                if (MI.MyMeth(new MyInner2()) == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope071
        {
            internal protected class MyInner
            {
                public int MyMeth(MyInner2 arg)
                {
                    return arg.intI;
                }
            }
            internal protected class MyInner2
            {
                public int intI = 2;
            }
            public static int Main_old()
            {
                MyInner MI = new MyInner();
                if (MI.MyMeth(new MyInner2()) == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_scope074
        {
            public static int Main_old()
            {
                {
                L1:
                    int i = 0;
                }
                {
                L1:
                    int i = 0;
                }
                {
                L1:
                    int i = 0;
                }
                {
                L1:
                    int i = 0;
                }

                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        class Basic_TestClass_nhide007
        {
            public static int Main_old()
            {
                if (Basic_TestClass_nhide007_C1.Basic_TestClass_nhide007_C1.intI == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        class Basic_TestClass_nhide015
        {
            class Basic_TestClass_nhide015_C1
            {
                public class Basic_TestClass_nhide015_I
                {
                    public static int intI = 2;
                }
            }
            class Basic_TestClass_nhide015_C2
            {
                public static int Main_old()
                {
                    if (Basic_TestClass_nhide015_C1.Basic_TestClass_nhide015_I.intI == 2)
                    {
                        OutputHelper.WriteLine("foo");
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide015_C2.Main_old() == 0);
            }
        }

        class Basic_TestClass_nhide016_C1
        {
            public class Basic_TestClass_nhide016_I
            {
                public static int intI = 1;
            }
        }
        class Basic_TestClass_nhide016
        {
            class Basic_TestClass_nhide016_C1
            {
                public class Basic_TestClass_nhide016_I
                {
                    public static int intI = 2;
                }
            }
            class Basic_TestClass_nhide016_C2
            {
                public static int Main_old()
                {
                    if (Basic_TestClass_nhide016_C1.Basic_TestClass_nhide016_I.intI == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide016_C2.Main_old() == 0);
            }
        }

        struct Basic_TestClass_nhide017_St1
        {
            public class Basic_TestClass_nhide017_I
            {
                public static int intI = 1;
            }
        }
        class Basic_TestClass_nhide017
        {
            struct Basic_TestClass_nhide017_St1
            {
                public class Basic_TestClass_nhide017_I
                {
                    public static int intI = 2;
                }
            }
            class Basic_TestClass_nhide017_C2
            {
                public static int Main_old()
                {
                    if (Basic_TestClass_nhide017_St1.Basic_TestClass_nhide017_I.intI == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide017_C2.Main_old() == 0);
            }
        }

        interface Basic_TestClass_nhide018_Inter
        {
            void bogus();
        }
        class Basic_TestClass_nhide018
        {
            interface Basic_TestClass_nhide018_Inter
            {
                void test();
            }
            class Basic_TestClass_nhide018_C2 : Basic_TestClass_nhide018_Inter
            {
                public void test() { }
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide018_C2.Main_old() == 0);
            }
        }

        enum Basic_TestClass_nhide019_Enum { test = 1 }
        class Basic_TestClass_nhide019
        {
            enum Basic_TestClass_nhide019_Enum { test = 2 }
            class Basic_TestClass_nhide019_C2
            {
                public static int Main_old()
                {
                    if ((int)Basic_TestClass_nhide019_Enum.test == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide019_C2.Main_old() == 0);
            }
        }


        delegate void Basic_TestClass_nhide020_Del();
        class Basic_TestClass_nhide020
        {
            delegate int Basic_TestClass_nhide020_Del(int intI);
            class Basic_TestClass_nhide020_C2
            {
                int TestMeth(int intI)
                {
                    return 1;
                }
                public static int Main_old()
                {
                    Basic_TestClass_nhide020_C2 test = new Basic_TestClass_nhide020_C2();
                    Basic_TestClass_nhide020_Del td = new Basic_TestClass_nhide020_Del(test.TestMeth);
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide020_C2.Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide021_C1
        {
            public class Basic_TestClass_nhide021_I
            {
                public static int intI = 1;
            }
        }

        class T_Basic_TestClass_nhide021
        {
            class Basic_TestClass_nhide021_C1
            {
                public class Basic_TestClass_nhide021_I
                {
                    public static int intI = 2;
                }
            }
        }
        class Basic_TestClass_nhide021
        {
            public static int Main_old()
            {
                if (Basic_TestClass_nhide021_C1.Basic_TestClass_nhide021_I.intI == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        struct Basic_TestClass_nhide022
        {
            class Basic_TestClass_nhide022_C1
            {
                public class Basic_TestClass_nhide022_I
                {
                    public static int intI = 2;
                }
            }
            class Basic_TestClass_nhide022_C2
            {
                public static int Main_old()
                {
                    if (Basic_TestClass_nhide022_C1.Basic_TestClass_nhide022_I.intI == 2)
                    {
                        OutputHelper.WriteLine("foo");
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide022_C2.Main_old() == 0);
            }
        }

        //Compiled Test Cases 













        class Basic_TestClass_nhide023_C1
        {
            public class Basic_TestClass_nhide023_I
            {
                public static int intI = 1;
            }
        }
        struct Basic_TestClass_nhide023
        {
            class Basic_TestClass_nhide023_C1
            {
                public class Basic_TestClass_nhide023_I
                {
                    public static int intI = 2;
                }
            }
            class Basic_TestClass_nhide023_C2
            {
                public static int Main_old()
                {
                    if (Basic_TestClass_nhide023_C1.Basic_TestClass_nhide023_I.intI == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide023_C2.Main_old() == 0);
            }
        }
        struct Basic_TestClass_nhide024_St1
        {
            public class Basic_TestClass_nhide024_I
            {
                public static int intI = 1;
            }
        }
        struct Basic_TestClass_nhide024
        {
            struct Basic_TestClass_nhide024_St1
            {
                public class Basic_TestClass_nhide024_I
                {
                    public static int intI = 2;
                }
            }
            class Basic_TestClass_nhide024_C1
            {
                public static int Main_old()
                {
                    if (Basic_TestClass_nhide024_St1.Basic_TestClass_nhide024_I.intI == 2)
                    {
                        OutputHelper.WriteLine("foo");
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide024_C1.Main_old() == 0);
            }
        }
        interface Basic_TestClass_nhide025_Inter
        {
            void bogus();
        }
        struct Basic_TestClass_nhide025
        {
            interface Basic_TestClass_nhide025_Inter
            {
                void test();
            }
            class Basic_TestClass_nhide025_C1 : Basic_TestClass_nhide025_Inter
            {
                public void test() { }
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide025_C1.Main_old() == 0);
            }
        }
        enum Basic_TestClass_nhide026_Enum { test = 1 }
        struct Basic_TestClass_nhide026
        {
            enum Basic_TestClass_nhide026_Enum { test = 2 }
            class Basic_TestClass_nhide026_C1
            {
                public static int Main_old()
                {
                    if ((int)Basic_TestClass_nhide026_Enum.test == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide026_C1.Main_old() == 0);

            }
        }
        delegate void Basic_TestClass_nhide027_Del();
        struct Basic_TestClass_nhide027
        {
            delegate int Basic_TestClass_nhide027_Del(int intI);
            class Basic_TestClass_nhide027_C1
            {
                int TestMeth(int intI)
                {
                    return 1;
                }
                public static int Main_old()
                {
                    Basic_TestClass_nhide027_C1 test = new Basic_TestClass_nhide027_C1();
                    Basic_TestClass_nhide027_Del td = new Basic_TestClass_nhide027_Del(test.TestMeth);
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide027_C1.Main_old() == 0);

            }
        }
        class Basic_TestClass_nhide028_C1
        {
            public class Basic_TestClass_nhide028_I
            {
                public static int intI = 1;
            }
        }
        struct Basic_TestClass_nhide028_St2
        {
            class Basic_TestClass_nhide028_C1
            {
                public class Basic_TestClass_nhide028_I
                {
                    public static int intI = 2;
                }
            }
        }
        class Basic_TestClass_nhide028
        {
            public static int Main_old()
            {
                if (Basic_TestClass_nhide028_C1.Basic_TestClass_nhide028_I.intI == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide029
        {
            public int intI = 1;
            public bool Basic_TestClass_nhide029_C1(int intI)
            {
                if (intI == 2)
                {
                    return true;
                }
                return false;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide029 test = new Basic_TestClass_nhide029();
                if (test.Basic_TestClass_nhide029_C1(2))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide030
        {
            public string strS = "test1";
            public bool Basic_TestClass_nhide030_C1(string strS)
            {
                if (strS == "test2")
                {
                    return true;
                }
                return false;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide030 test = new Basic_TestClass_nhide030();
                if (test.Basic_TestClass_nhide030_C1("test2"))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide031
        {
            public static int intI = 1;
            public static bool Basic_TestClass_nhide031_C1(int intI)
            {
                if (intI == 2)
                {
                    return true;
                }
                return false;
            }
            public static int Main_old()
            {
                if (Basic_TestClass_nhide031.Basic_TestClass_nhide031_C1(2))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide032
        {
            public static string strS = "test1";
            public static bool Basic_TestClass_nhide032_C1(string strS)
            {
                if (strS == "test2")
                {
                    return true;
                }
                return false;
            }
            public static int Main_old()
            {
                if (Basic_TestClass_nhide032.Basic_TestClass_nhide032_C1("test2"))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide033
        {
            public int intI = 1;
            public int intJ = 2;
            public bool Basic_TestClass_nhide033_C1(int intI, int intJ)
            {
                if ((intI == 2) && (intJ == 3))
                {
                    return true;
                }
                return false;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide033 test = new Basic_TestClass_nhide033();
                if (test.Basic_TestClass_nhide033_C1(2, 3))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide034
        {
            public string strS = "test1";
            public string strS2 = "test2";
            public bool Basic_TestClass_nhide034_C1(string strS, string strS2)
            {
                if ((strS == "test2") && (strS2 == "test3"))
                {
                    return true;
                }
                return false;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide034 test = new Basic_TestClass_nhide034();
                if (test.Basic_TestClass_nhide034_C1("test2", "test3"))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide035
        {
            public int intI = 1;
            public bool Basic_TestClass_nhide035_C1(ref int intI)
            {
                if (intI == 2)
                {
                    return true;
                }
                return false;
            }
            public static int Main_old()
            {
                int intJ = 2;
                Basic_TestClass_nhide035 test = new Basic_TestClass_nhide035();
                if (test.Basic_TestClass_nhide035_C1(ref intJ))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide036
        {
            public string strS = "test1";
            public bool Basic_TestClass_nhide036_C1(ref string strS)
            {
                if (strS == "test2")
                {
                    return true;
                }
                return false;
            }
            public static int Main_old()
            {
                string strTest = "test2";
                Basic_TestClass_nhide036 test = new Basic_TestClass_nhide036();
                if (test.Basic_TestClass_nhide036_C1(ref strTest))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide037
        {
            public int intI = 1;
            public void Basic_TestClass_nhide037_C1(out int intI)
            {
                intI = 2;
            }
            public static int Main_old()
            {
                int intJ;
                Basic_TestClass_nhide037 test = new Basic_TestClass_nhide037();
                test.Basic_TestClass_nhide037_C1(out intJ);
                if ((test.intI == 1) && (intJ == 2))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide038
        {
            public string strS = "test1";
            public void Basic_TestClass_nhide038_C1(out string strS)
            {
                strS = "test2";
            }
            public static int Main_old()
            {
                string strTest;
                Basic_TestClass_nhide038 test = new Basic_TestClass_nhide038();
                test.Basic_TestClass_nhide038_C1(out strTest);
                if ((test.strS == "test1") && (strTest == "test2"))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide039
        {
            public static int intI = 1;
            public static int Main_old()
            {
                int intI = 2;
                if (intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide040
        {
            public static string strS = "test";
            public static int Main_old()
            {
                string strS = "test2";
                if (strS == "test2")
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide041
        {
            int intI = 1;

            bool Test1()
            {
                int intI = 2;
                if (intI == 2)
                {
                    return true;
                }
                return false;
            }
            bool Test2()
            {
                if (intI == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide041 test = new Basic_TestClass_nhide041();
                if (test.Test1() && test.Test2())
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide042
        {
            string strS = "test2";

            bool Test1()
            {
                string strS = "test1";
                if (strS == "test1")
                {
                    return true;
                }
                return false;
            }
            bool Test2()
            {
                if (strS == "test2")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide042 test = new Basic_TestClass_nhide042();
                if (test.Test1() && test.Test2())
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide043
        {
            int intI = 1;

            bool Test1()
            {
                int intI = 2;
                if (intI == 2)
                {
                    return true;
                }
                return false;
            }
            bool Test2()
            {
                int intI = 3;
                if (intI == 3)
                {
                    return true;
                }
                return false;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide043 test = new Basic_TestClass_nhide043();
                if (test.Test1() && test.Test2())
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide044
        {
            string strS = "test2";

            bool Test1()
            {
                string strS = "test1";
                if (strS == "test1")
                {
                    return true;
                }
                return false;
            }
            bool Test2()
            {
                string strS = "test2";
                if (strS == "test2")
                {
                    return true;
                }
                return false;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide044 test = new Basic_TestClass_nhide044();
                if (test.Test1() && test.Test2())
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide045
        {
            static int Basic_TestClass_nhide045_C1(int intI)
            {
                return -1;
            }
            static int Basic_TestClass_nhide045_C1(string s)
            {
                return -1;
            }
            class Basic_TestClass_nhide045_I
            {
                static int Basic_TestClass_nhide045_C1(int intI)
                {
                    return intI;
                }
                public static int Main_old()
                {
                    if (Basic_TestClass_nhide045_C1(2) == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide045_I.Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide047
        {
            static int Basic_TestClass_nhide047_C1()
            {
                return 1;
            }
            class Basic_TestClass_nhide047_I
            {
                static int Basic_TestClass_nhide047_C1 = 2;

                public static int Main_old()
                {
                    if (Basic_TestClass_nhide047_C1 == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide047_I.Main_old() == 0);

            }
        }
        class Basic_TestClass_nhide049
        {
            class Basic_TestClass_nhide049_C1 { }
            class Basic_TestClass_nhide049_I
            {
                static int Basic_TestClass_nhide049_C1 = 2;

                public static int Main_old()
                {
                    if (Basic_TestClass_nhide049_C1 == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide049_I.Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide050
        {
            class Basic_TestClass_nhide050_C1
            {
                public int intI = 3;
            }
            class Basic_TestClass_nhide050_I
            {
                public static int Basic_TestClass_nhide050_C1 = 2;

                public static int Main_old()
                {
                    Basic_TestClass_nhide050_C1 t = new Basic_TestClass_nhide050_C1();
                    if (t.intI == 3)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide050_I.Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide051
        {
            static int Basic_TestClass_nhide051_C1(int intI)
            {
                return -1;
            }
            static int Basic_TestClass_nhide051_C1(string s)
            {
                return -1;
            }
            class Basic_TestClass_nhide051_I
            {
                int Basic_TestClass_nhide051_C1(int intI)
                {
                    return intI;
                }
                public int RetVal()
                {
                    if (Basic_TestClass_nhide051_C1(2) == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                public static int Main_old()
                {
                    Basic_TestClass_nhide051_I MC = new Basic_TestClass_nhide051_I();
                    return MC.RetVal();
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide051_I.Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide053
        {
            static int Basic_TestClass_nhide053_C1()
            {
                return 1;
            }
            class Basic_TestClass_nhide053_I
            {
                int Basic_TestClass_nhide053_C1 = 2;

                public int RetVal()
                {
                    if (Basic_TestClass_nhide053_C1 == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                public static int Main_old()
                {
                    Basic_TestClass_nhide053_I MC = new Basic_TestClass_nhide053_I();
                    return MC.RetVal();
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide053_I.Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide055
        {
            class Basic_TestClass_nhide055_C1 { }
            class Basic_TestClass_nhide055_I
            {
                int Basic_TestClass_nhide055_C1 = 2;

                public int RetVal()
                {
                    if (Basic_TestClass_nhide055_C1 == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
                public static int Main_old()
                {
                    Basic_TestClass_nhide055_I MC = new Basic_TestClass_nhide055_I();
                    return MC.RetVal();
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide055_I.Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide056
        {
            class Basic_TestClass_nhide056_C1 { }
            class Basic_TestClass_nhide056_I
            {
                int Basic_TestClass_nhide056_C1 = 2;

                public void RetVal()
                {
                    Basic_TestClass_nhide056_C1 tc = new Basic_TestClass_nhide056_C1();
                }
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide056_I.Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide057_C4
        {
            public int intRet()
            {
                return 2;
            }
        }
        class Basic_TestClass_nhide057
        {
            class Basic_TestClass_nhide057_C1
            {
                public static int intRet()
                {
                    return 1;
                }
            }
            class Basic_TestClass_nhide057_I
            {
                static Basic_TestClass_nhide057_C4 Basic_TestClass_nhide057_C1 = new Basic_TestClass_nhide057_C4();
                public static int Main_old()
                {
                    if (Basic_TestClass_nhide057_C1.intRet() == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide057_I.Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide059_C4
        {
            public int intRet()
            {
                return 2;
            }
        }
        class Basic_TestClass_nhide059
        {
            class Basic_TestClass_nhide059_C1
            {
                public static int intRet()
                {
                    return 1;
                }
            }
            class Basic_TestClass_nhide059_I
            {
                public int TestMeth()
                {
                    Basic_TestClass_nhide059_C4 Basic_TestClass_nhide059_C1 = new Basic_TestClass_nhide059_C4();
                    return Basic_TestClass_nhide059_C1.intRet();
                }
                public static int Main_old()
                {
                    Basic_TestClass_nhide059_I TC = new Basic_TestClass_nhide059_I();
                    if (TC.TestMeth() == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_nhide059_I.Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide061_C5
        {
            public const int intI = 1;
        }
        class Basic_TestClass_nhide061 : Basic_TestClass_nhide061_C5
        {
            public const int intI = 2;
            public static int Main_old()
            {
                if (intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide062_C5
        {
            public int intI = 1;
        }
        class Basic_TestClass_nhide062 : Basic_TestClass_nhide062_C5
        {
            public int intI = 2;
            public static int Main_old()
            {
                Basic_TestClass_nhide062 test = new Basic_TestClass_nhide062();
                if (test.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide063_C5
        {
            public int intI
            {
                get
                {
                    return 1;
                }
            }
        }
        class Basic_TestClass_nhide063 : Basic_TestClass_nhide063_C5
        {
            public int intI
            {
                get
                {
                    return 2;
                }
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide063 test = new Basic_TestClass_nhide063();
                if (test.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide064_C5
        {
            public class Basic_TestClass_nhide064_C1
            {
                public int intI = 1;
            }
        }
        class Basic_TestClass_nhide064 : Basic_TestClass_nhide064_C5
        {
            public class Basic_TestClass_nhide064_C1
            {
                public int intI = 2;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide064_C1 test = new Basic_TestClass_nhide064_C1();
                if (test.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide067_C5
        {
            public int intI
            {
                get
                {
                    return 1;
                }
            }
        }
        class Basic_TestClass_nhide067 : Basic_TestClass_nhide067_C5
        {
            public class intI
            {
                public int i = 2;
            }
            public static int Main_old()
            {
                intI test = new intI();
                if (test.i == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide068_C5
        {
            public class intI
            {
                public int i = 2;
            }
        }
        class Basic_TestClass_nhide068 : Basic_TestClass_nhide068_C5
        {
            const int intI = 3;
            public static int Main_old()
            {
                intI test = new intI();
                if ((test.i == 2) && (intI == 3))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide071_C5
        {
            public int MyMeth = 1;
        }
        class Basic_TestClass_nhide071 : Basic_TestClass_nhide071_C5
        {
            public int MyMeth()
            {
                return 2;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide071 test = new Basic_TestClass_nhide071();
                if (test.MyMeth() == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide072_C5
        {
            public static int MyMeth = 1;
        }
        class Basic_TestClass_nhide072 : Basic_TestClass_nhide072_C5
        {
            public static int MyMeth()
            {
                return 2;
            }
            public static int Main_old()
            {
                if (MyMeth() == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide075_C5
        {
            public int MyMeth(int intI)
            {
                return intI;
            }
        }
        class Basic_TestClass_nhide075 : Basic_TestClass_nhide075_C5
        {
            public int MyMeth(int intI)
            {
                return intI + 1;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide075 test = new Basic_TestClass_nhide075();
                if (test.MyMeth(2) == 3)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide076_C5
        {
            public static int MyMeth(int intI)
            {
                return intI;
            }
        }
        class Basic_TestClass_nhide076 : Basic_TestClass_nhide076_C5
        {
            public static int MyMeth(int intI)
            {
                return intI + 1;
            }
            public static int Main_old()
            {
                if (MyMeth(2) == 3)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide077_C5
        {
            public static int MyMeth(int intI)
            {
                return intI;
            }
        }
        class Basic_TestClass_nhide077 : Basic_TestClass_nhide077_C5
        {
            public int MyMeth(int intI)
            {
                return intI + 1;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide077 test = new Basic_TestClass_nhide077();
                if (test.MyMeth(2) == 3)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide079_C5
        {
            public int MyMeth(int intI)
            {
                return intI;
            }
        }
        class Basic_TestClass_nhide079 : Basic_TestClass_nhide079_C5
        {
            public static int MyMeth(int intI)
            {
                return intI + 1;
            }
            public static int Main_old()
            {
                if (MyMeth(2) == 3)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide081_C5
        {
            public int MyMeth()
            {
                return 1;
            }
            public int MyMeth(int intI)
            {
                return intI;
            }
        }
        class Basic_TestClass_nhide081 : Basic_TestClass_nhide081_C5
        {
            public int MyMeth(int intI)
            {
                return intI + 1;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide081 test = new Basic_TestClass_nhide081();
                if (test.MyMeth() == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide082_C5
        {
            public static int MyMeth()
            {
                return 1;
            }
            public static int MyMeth(int intI)
            {
                return intI;
            }
        }
        class Basic_TestClass_nhide082 : Basic_TestClass_nhide082_C5
        {
            public static int MyMeth(int intI)
            {
                return intI + 1;
            }
            public static int Main_old()
            {
                if (MyMeth() == 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide085_C5
        {
            public int MyMeth(int intI)
            {
                return intI;
            }
        }
        class Basic_TestClass_nhide085 : Basic_TestClass_nhide085_C5
        {
            public int MyMeth(string strS)
            {
                return 1;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide085 test = new Basic_TestClass_nhide085();
                if ((test.MyMeth(2) == 2) && (test.MyMeth("bogus") == 1))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        class Basic_TestClass_nhide086_C5
        {
            public static int MyMeth(int intI)
            {
                return intI;
            }
        }
        class Basic_TestClass_nhide086 : Basic_TestClass_nhide086_C5
        {
            public static int MyMeth(string strS)
            {
                return 1;
            }
            public static int Main_old()
            {
                if ((MyMeth(2) == 2) && (MyMeth("bogus") == 1))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        struct Basic_TestClass_nhide087
        {
            public string ToString()
            {
                return "MyTestStruct";
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide087 test = new Basic_TestClass_nhide087();
                if (test.ToString() == "MyTestStruct")
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        struct Basic_TestClass_nhide088
        {
            public string ToString(string strS)
            {
                return strS;
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide088 test = new Basic_TestClass_nhide088();
                string s1 = test.ToString();
                string s2 = test.ToString("Basic_TestClass_nhide088");
                if ((s1 == "NFUnitTestBasicConcepts.UnitTestBasicConceptsTests+Basic_TestClass_nhide088") && (s2 == "Basic_TestClass_nhide088"))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_nhide089_C2
        {
            public int this[int intI]
            {
                get
                {
                    return intI;
                }
            }
        }
        public class Basic_TestClass_nhide089 : Basic_TestClass_nhide089_C2
        {
            public int this[int intI]
            {
                get
                {
                    return intI + 1;
                }
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide089 test = new Basic_TestClass_nhide089();
                if (test[3] == 4)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_nhide090_C2
        {
            public int this[long lngL]
            {
                get
                {
                    return (int)lngL;
                }
            }
        }
        public class Basic_TestClass_nhide090 : Basic_TestClass_nhide090_C2
        {
            public int this[int intI]
            {
                get
                {
                    return intI + 1;
                }
            }
            public static int Main_old()
            {
                Basic_TestClass_nhide090 test = new Basic_TestClass_nhide090();
                if ((test[(long)3] == 3) && (test[(int)3] == 4))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_nhide091_C2
        {
            public void F() { }
        }
        public class Basic_TestClass_nhide091 : Basic_TestClass_nhide091_C2
        {
            public void F() { }
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_nhide092_C2
        {
            public static int F()
            {
                return 2;
            }
        }
        public class Basic_TestClass_nhide092_C6 : Basic_TestClass_nhide092_C2
        {
            new private static int F()
            {
                return 3;
            }
        }
        public class Basic_TestClass_nhide092 : Basic_TestClass_nhide092_C6
        {
            public static int Main_old()
            {
                if (F() == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac009_O
        {
            public class Basic_TestClass_memac009_C1
            {
                public int intI = 2;
            }
        }
        public class Basic_TestClass_memac009
        {
            public static int Main_old()
            {
                Basic_TestClass_memac009_O.Basic_TestClass_memac009_C1 tc = new Basic_TestClass_memac009_O.Basic_TestClass_memac009_C1();
                if (tc.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac010_C1
        {
            public static int intI = 2;
        }
        public class Basic_TestClass_memac010
        {
            public static int Main_old()
            {
                if (Basic_TestClass_memac010_C1.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac011_O
        {
            protected internal class Basic_TestClass_memac011_C1
            {
                public int intI = 2;
            }
        }
        public class Basic_TestClass_memac011
        {
            public static int Main_old()
            {
                Basic_TestClass_memac011_O.Basic_TestClass_memac011_C1 tc = new Basic_TestClass_memac011_O.Basic_TestClass_memac011_C1();
                if (tc.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac012_O
        {
            protected static internal int intI = 2;
        }
        public class Basic_TestClass_memac012
        {
            public static int Main_old()
            {
                if (Basic_TestClass_memac012_O.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        /*
        public class Basic_TestClass_memac013 : Basic_TestClass_memac013_O
        {
            public static int Main_old()
            {
                Basic_TestClass_memac013_C1 tc = new Basic_TestClass_memac013_C1();
                if (tc.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac014 : Basic_TestClass_memac014_O
        {
            public static int Main_old()
            {
                if (intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
         * */
        public class Basic_TestClass_memac019
        {
            protected class Basic_TestClass_memac019_C1
            {
                public int intI = 2;
                public static int Main_old()
                {
                    Basic_TestClass_memac019_C1 tc = new Basic_TestClass_memac019_C1();
                    if (tc.intI == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_memac019_C1.Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac020
        {
            protected static int intI = 2;
            public static int Main_old()
            {
                if (intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac021_O
        {
            protected class Basic_TestClass_memac021_C1
            {
                public int intI = 2;
            }
        }
        public class Basic_TestClass_memac021 : Basic_TestClass_memac021_O
        {
            public static int Main_old()
            {
                Basic_TestClass_memac021_C1 tc = new Basic_TestClass_memac021_C1();
                if (tc.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac022_O
        {
            protected static int intI = 2;
        }
        public class Basic_TestClass_memac022 : Basic_TestClass_memac022_O
        {
            public static int Main_old()
            {
                if (intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac025_O
        {
            protected class Basic_TestClass_memac025_C1
            {
                public int intI = 2;
            }
        }
        public class Basic_TestClass_memac025 : Basic_TestClass_memac025_O
        {
            public static int Main_old()
            {
                Basic_TestClass_memac025_O.Basic_TestClass_memac025_C1 tc = new Basic_TestClass_memac025_O.Basic_TestClass_memac025_C1();
                if (tc.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        internal class Basic_TestClass_memac027_C1
        {
            public int intI = 2;
        }
        public class Basic_TestClass_memac027
        {
            public static int Main_old()
            {
                Basic_TestClass_memac027_C1 TC = new Basic_TestClass_memac027_C1();
                if (TC.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac029_O
        {
            internal class Basic_TestClass_memac029_C1
            {
                public int intI = 2;
            }
        }
        public class Basic_TestClass_memac029
        {
            public static int Main_old()
            {
                Basic_TestClass_memac029_O.Basic_TestClass_memac029_C1 TC = new Basic_TestClass_memac029_O.Basic_TestClass_memac029_C1();
                if (TC.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac030_O
        {
            static internal int intI = 2;
        }
        public class Basic_TestClass_memac030
        {
            public static int Main_old()
            {
                if (Basic_TestClass_memac030_O.intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac033
        {
            private class Basic_TestClass_memac033_C1
            {
                public int intI = 2;
                public static int Main_old()
                {
                    Basic_TestClass_memac033_C1 tc = new Basic_TestClass_memac033_C1();
                    if (tc.intI == 2)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_memac033_C1.Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac034
        {
            private static int intI = 2;
            public static int Main_old()
            {
                if (intI == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        /*
        public class Basic_TestClass_memac039 : Basic_TestClass_memac039_C2
        {
            protected override void OnSetComponentDefaults() { }
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_memac041_B : Basic_TestClass_memac041_A
        {
            protected override void f()
            { OutputHelper.WriteLine("Basic_TestClass_memac041_B.f()"); }
            static void Main_old()
            {
                Basic_TestClass_memac041_B b = new Basic_TestClass_memac041_B();
                b.f();
            }
            public static bool testMethod()
            {
                Main_old();
                Microsoft.SPOT.Debug.Print("<PASS>");
            }
        }
        */
        class Basic_TestClass_memac042_B
        {
            protected static int F()
            {
                return 2;
            }
        }
        class Basic_TestClass_memac042_D : Basic_TestClass_memac042_B
        {
            new public static int F()
            {
                return Basic_TestClass_memac042_B.F();
            }
        }

        class Basic_TestClass_memac042
        {
            static int Main_old()
            {
                if (Basic_TestClass_memac042_D.F() == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        class Basic_TestClass_memac043_B
        {
            protected internal static int F()
            {
                return 2;
            }
        }
        class Basic_TestClass_memac043_D : Basic_TestClass_memac043_B
        {
            new public static int F()
            {
                return Basic_TestClass_memac043_B.F();
            }
        }

        class Basic_TestClass_memac043
        {
            static int Main_old()
            {
                if (Basic_TestClass_memac043_D.F() == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        class Basic_TestClass_memac044_B
        {
            protected static int intI = 2;
        }
        class Basic_TestClass_memac044_D : Basic_TestClass_memac044_B
        {
            public static int F()
            {
                return Basic_TestClass_memac044_B.intI;
            }
        }

        class Basic_TestClass_memac044
        {
            static int Main_old()
            {
                if (Basic_TestClass_memac044_D.F() == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        class Basic_TestClass_memac045_B
        {
            protected internal static int intI = 2;
        }
        class Basic_TestClass_memac045_D : Basic_TestClass_memac045_B
        {
            public static int F()
            {
                return Basic_TestClass_memac045_B.intI;
            }
        }

        class Basic_TestClass_memac045
        {
            static int Main_old()
            {
                if (Basic_TestClass_memac045_D.F() == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        class Basic_TestClass_memac046_B
        {
            protected static int intI
            {
                get
                {
                    return 2;
                }
            }
        }
        class Basic_TestClass_memac046_D : Basic_TestClass_memac046_B
        {
            public static int F()
            {
                return Basic_TestClass_memac046_B.intI;
            }
        }

        class Basic_TestClass_memac046
        {
            static int Main_old()
            {
                if (Basic_TestClass_memac046_D.F() == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }

        class Basic_TestClass_memac047_B
        {
            protected internal static int intI
            {
                get
                {
                    return 2;
                }
            }
        }
        class Basic_TestClass_memac047_D : Basic_TestClass_memac047_B
        {
            public static int F()
            {
                return Basic_TestClass_memac047_B.intI;
            }
        }

        class Basic_TestClass_memac047
        {
            static int Main_old()
            {
                if (Basic_TestClass_memac047_D.F() == 2)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon001_C2 { }
        internal class Basic_TestClass_accon001 : Basic_TestClass_accon001_C2
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon003
        {
            public class Basic_TestClass_accon003_C2 { }
            private class Basic_TestClass_accon003_C3 : Basic_TestClass_accon003_C2
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon003_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon005
        {
            public class Basic_TestClass_accon005_C2 { }
            protected class Basic_TestClass_accon005_C3 : Basic_TestClass_accon005_C2
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon005_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon007
        {
            public class Basic_TestClass_accon007_C2 { }
            internal class Basic_TestClass_accon007_C3 : Basic_TestClass_accon007_C2
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon007_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon009
        {
            public class Basic_TestClass_accon009_C2 { }
            protected internal class Basic_TestClass_accon009_C3 : Basic_TestClass_accon009_C2
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon009_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon011
        {
            protected internal class Basic_TestClass_accon011_C2 { }
            protected class Basic_TestClass_accon011_C3 : Basic_TestClass_accon011_C2
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon011_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon013
        {
            protected internal class Basic_TestClass_accon013_C2 { }
            internal class Basic_TestClass_accon013_C3 : Basic_TestClass_accon013_C2
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon013_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon015
        {
            protected internal class Basic_TestClass_accon015_C2 { }
            private class Basic_TestClass_accon015_C3 : Basic_TestClass_accon015_C2
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon015_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon019
        {
            protected class Basic_TestClass_accon019_C2 { }
            private class Basic_TestClass_accon019_C3 : Basic_TestClass_accon019_C2
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon019_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon021
        {
            internal class Basic_TestClass_accon021_C2 { }
            private class Basic_TestClass_accon021_C3 : Basic_TestClass_accon021_C2
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon021_C3.Main_old() == 0);
            }
        }
        public interface Basic_TestClass_accon023_C2 { }
        internal interface Basic_TestClass_accon023_Inter : Basic_TestClass_accon023_C2 { }
        public class Basic_TestClass_accon023
        {
            public static int Main_old()
            {
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon025
        {
            public interface Basic_TestClass_accon025_C2 { }
            protected internal interface Basic_TestClass_accon025_Inter : Basic_TestClass_accon025_C2 { }
            public class Basic_TestClass_accon025_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon025_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon027
        {
            protected internal interface Basic_TestClass_accon027_C2 { }
            protected interface Basic_TestClass_accon027_Inter : Basic_TestClass_accon027_C2 { }
            public class Basic_TestClass_accon027_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon027_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon029
        {
            protected internal interface Basic_TestClass_accon029_C2 { }
            internal interface Basic_TestClass_accon029_Inter : Basic_TestClass_accon029_C2 { }
            public class Basic_TestClass_accon029_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon029_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon031
        {
            protected interface Basic_TestClass_accon031_C2 { }
            private interface Basic_TestClass_accon031_Inter : Basic_TestClass_accon031_C2 { }
            public class Basic_TestClass_accon031_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon031_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon033
        {
            public class Basic_TestClass_accon033_C1 { }
            protected delegate Basic_TestClass_accon033_C1 MyDelegate();
            public class Basic_TestClass_accon033_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon033_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon035
        {
            public class Basic_TestClass_accon035_C1 { }
            internal delegate void MyDelegate(Basic_TestClass_accon035_C1 T);
            public class Basic_TestClass_accon035_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon035_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon037
        {
            public enum Basic_TestClass_accon037_C1 { aa = 1 }
            internal const Basic_TestClass_accon037_C1 e1 = Basic_TestClass_accon037_C1.aa;
            public class Basic_TestClass_accon037_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon037_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon039
        {
            public enum Basic_TestClass_accon039_C1 { aa = 1 }
            protected internal Basic_TestClass_accon039_C1 e1 = Basic_TestClass_accon039_C1.aa;
            public class Basic_TestClass_accon039_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon039_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon041
        {
            public class Basic_TestClass_accon041_C1 { }
            private Basic_TestClass_accon041_C1 MyMeth()
            {
                return new Basic_TestClass_accon041_C1();
            }
            public class Basic_TestClass_accon041_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon041_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon043
        {
            public class Basic_TestClass_accon043_C1 { }
            private void MyMeth(Basic_TestClass_accon043_C1 T) { }
            public class Basic_TestClass_accon043_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon043_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon045
        {
            public class Basic_TestClass_accon045_C1 { }
            protected Basic_TestClass_accon045_C1 c1
            {
                get
                {
                    return new Basic_TestClass_accon045_C1();
                }
            }
            public class Basic_TestClass_accon045_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon045_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon047
        {
            public class Basic_TestClass_accon047_C1 { }
            internal Basic_TestClass_accon047_C1 this[int intI]
            {
                get
                {
                    return new Basic_TestClass_accon047_C1();
                }
            }
            public class Basic_TestClass_accon047_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon047_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon049
        {
            public class Basic_TestClass_accon049_C1 { }
            internal int this[Basic_TestClass_accon049_C1 T]
            {
                get
                {
                    return 1;
                }
            }
            public class Basic_TestClass_accon049_C3
            {
                public static int Main_old()
                {
                    return 0;
                }
            }
            public static bool testMethod()
            {
                return (Basic_TestClass_accon049_C3.Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon051_C1 { }
        public class Basic_TestClass_accon051
        {
            public static Basic_TestClass_accon051_C1 operator +(Basic_TestClass_accon051 MyInt, Basic_TestClass_accon051 MyInt2)
            {
                return new Basic_TestClass_accon051_C1();
            }
            public static int Main_old()
            {
                return 0;
            }

            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon053_C1 { }
        public class Basic_TestClass_accon053
        {
            public static int operator +(Basic_TestClass_accon053 MyInt, Basic_TestClass_accon053_C1 MyInt2)
            {
                return 1;
            }
            public static int Main_old()
            {
                return 0;
            }

            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Basic_TestClass_accon055_C1 { }
        public class Basic_TestClass_accon055
        {
            internal Basic_TestClass_accon055(Basic_TestClass_accon055_C1 T)
            {

            }
            public static int Main_old()
            {
                return 0;
            }

            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }


    }
}

//Other Namespaces

namespace NS_Basic_TestClass_scope001
{
    class MyClass2
    {
        public static int intI = 2;
    }
}



namespace NS_Basic_TestClass_scope002
{
    class Basic_TestClass_scope002
    {
        public static int Main_old()
        {
            if ((Basic_TestClass_scope002_C1.intI == 1) && (TestNS.MyClass2.intI == 2))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
    class Basic_TestClass_scope002_C1
    {
        public static int intI = 1;
    }
    namespace TestNS
    {
        class MyClass2
        {
            public static int intI = 2;
        }
    }
}
namespace NS_Basic_TestClass_scope003
{
    class Basic_TestClass_scope003
    {
        public static int Main_old()
        {
            if ((Basic_TestClass_scope003_C1.intI == 1) && (TestNS.MyClass2.intI == 2))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
namespace NS_Basic_TestClass_scope003
{
    class Basic_TestClass_scope003_C1
    {
        public static int intI = 1;
    }
    namespace TestNS
    {
        class MyClass2
        {
            public static int intI = 2;
        }
    }
}
namespace NS_Basic_TestClass_scope004
{
    namespace NS_Basic_TestClass_scope004_2
    {
        class Basic_TestClass_scope004
        {

            public static int Main_old()
            {
                if ((Basic_TestClass_scope004_C1.intI == 1) && (TestNS.MyClass2.intI == 2))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
    }
}
namespace NS_Basic_TestClass_scope004.NS_Basic_TestClass_scope004_2
{
    class Basic_TestClass_scope004_C1
    {
        public static int intI = 1;
    }
    namespace TestNS
    {
        class MyClass2
        {
            public static int intI = 2;
        }
    }
}
namespace NS_Basic_TestClass_scope005
{
    class Basic_TestClass_scope005_C1
    {
        public static int intI = 1;
    }
    namespace TestNS
    {
        class MyClass2
        {
            public static int intI = 2;
        }
    }
    namespace NS_Basic_TestClass_scope005_2
    {
        class Basic_TestClass_scope005
        {

            public static int Main_old()
            {
                if ((Basic_TestClass_scope005_C1.intI == 1) && (TestNS.MyClass2.intI == 2))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
    }
}
namespace NS_Basic_TestClass_scope006
{
    namespace NS_Basic_TestClass_scope006_2
    {
        class Basic_TestClass_scope006
        {

            public static int Main_old()
            {
                if ((Basic_TestClass_scope006_C1.intI == 1) && (TestNS.MyClass2.intI == 2))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
    }
}
namespace NS_Basic_TestClass_scope006
{
    class Basic_TestClass_scope006_C1
    {
        public static int intI = 1;
    }
    namespace TestNS
    {
        class MyClass2
        {
            public static int intI = 2;
        }
    }
}
namespace NS_Basic_TestClass_scope012
{

    class Basic_TestClass_scope012
    {
        static int Math_Max(int i, int j) => i > j ? i : j;

        public static int Main_old()
        {
            if (Math_Max(2, 3) == 3)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
namespace NS_Basic_TestClass_scope056
{
    class Basic_TestClass_scope056
    {
        public Basic_TestClass_scope056_C2 MC;
        public static int Main_old()
        {
            return 0;
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
    class Basic_TestClass_scope056_C2 { }
}


namespace Basic_TestClass_nhide001_C1
{
    class Basic_TestClass_nhide001_C1
    {
        public static int intI = 1;
    }
}
namespace NS_Basic_TestClass_nhide001
{
    namespace Basic_TestClass_nhide001_C1
    {
        class Basic_TestClass_nhide001_C1
        {
            public static int intI = 2;
        }
    }
    class Basic_TestClass_nhide001
    {
        public static int Main_old()
        {
            if (Basic_TestClass_nhide001_C1.Basic_TestClass_nhide001_C1.intI == 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
class Basic_TestClass_nhide002_C1
{
    public class Basic_TestClass_nhide002_C2
    {
        public static int intI = 1;
    }
}
namespace NS_Basic_TestClass_nhide002
{
    namespace Basic_TestClass_nhide002_C1
    {
        class Basic_TestClass_nhide002_C2
        {
            public static int intI = 2;
        }
    }
    class Basic_TestClass_nhide002
    {
        public static int Main_old()
        {
            if (Basic_TestClass_nhide002_C1.Basic_TestClass_nhide002_C2.intI == 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
struct Basic_TestClass_nhide003_C1
{
    public class Basic_TestClass_nhide003_C2
    {
        public static int intI = 1;
    }
}
namespace NS_Basic_TestClass_nhide003
{
    namespace Basic_TestClass_nhide003_C1
    {
        class Basic_TestClass_nhide003_C2
        {
            public static int intI = 2;
        }
    }
    class Basic_TestClass_nhide003
    {
        public static int Main_old()
        {
            if (Basic_TestClass_nhide003_C1.Basic_TestClass_nhide003_C2.intI == 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
interface Basic_TestClass_nhide004_C1 { }
namespace NS_Basic_TestClass_nhide004
{
    namespace Basic_TestClass_nhide004_C1
    {
        class Basic_TestClass_nhide004_C2
        {
            public static int intI = 2;
        }
    }
    class Basic_TestClass_nhide004
    {
        public static int Main_old()
        {
            if (Basic_TestClass_nhide004_C1.Basic_TestClass_nhide004_C2.intI == 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
enum Basic_TestClass_nhide005_C1 { Basic_TestClass_nhide005_C1 = 1 }
namespace NS_Basic_TestClass_nhide005
{
    namespace Basic_TestClass_nhide005_C1
    {
        class Basic_TestClass_nhide005_C1
        {
            public static int intI = 2;
        }
    }
    class Basic_TestClass_nhide005
    {
        public static int Main_old()
        {
            if (Basic_TestClass_nhide005_C1.Basic_TestClass_nhide005_C1.intI == 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
delegate void Basic_TestClass_nhide006_C1();
namespace NS_Basic_TestClass_nhide006
{
    namespace Basic_TestClass_nhide006_C1
    {
        class Basic_TestClass_nhide006_C1
        {
            public static int intI = 2;
        }
    }
    class Basic_TestClass_nhide006
    {
        public static int Main_old()
        {
            if (Basic_TestClass_nhide006_C1.Basic_TestClass_nhide006_C1.intI == 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
namespace Basic_TestClass_nhide007_C1
{
    class Basic_TestClass_nhide007_C1
    {
        public static int intI = 1;
    }
}
namespace NS_Basic_TestClass_nhide007
{
    namespace Basic_TestClass_nhide007_C1
    {
        class Basic_TestClass_nhide007_C1
        {
            public static int intI = 2;
        }
    }
}

namespace Basic_TestClass_nhide008_C1
{
    class Basic_TestClass_nhide008_I
    {
        public static int intI = 1;
    }
}
namespace NS_Basic_TestClass_nhide008
{
    class Basic_TestClass_nhide008_C1
    {
        public class Basic_TestClass_nhide008_I
        {
            public static int intI = 2;
        }
    }
    class Basic_TestClass_nhide008
    {
        public static int Main_old()
        {
            if (Basic_TestClass_nhide008_C1.Basic_TestClass_nhide008_I.intI == 2)
            {
                OutputHelper.WriteLine("foo");
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
class Basic_TestClass_nhide009_C1
{
    public class Basic_TestClass_nhide009_I
    {
        public static int intI = 1;
    }
}
namespace NS_Basic_TestClass_nhide009
{
    class Basic_TestClass_nhide009_C1
    {
        public class Basic_TestClass_nhide009_I
        {
            public static int intI = 2;
        }
    }
    class Basic_TestClass_nhide009
    {
        public static int Main_old()
        {
            if (Basic_TestClass_nhide009_C1.Basic_TestClass_nhide009_I.intI == 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
struct Basic_TestClass_nhide010_St1
{
    public class Basic_TestClass_nhide010_I
    {
        public static int intI = 1;
    }
}
namespace NS_Basic_TestClass_nhide010
{
    struct Basic_TestClass_nhide010_St1
    {
        public class Basic_TestClass_nhide010_I
        {
            public static int intI = 2;
        }
    }
    class Basic_TestClass_nhide010
    {
        public static int Main_old()
        {
            if (Basic_TestClass_nhide010_St1.Basic_TestClass_nhide010_I.intI == 2)
            {
                OutputHelper.WriteLine("foo");
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
interface Basic_TestClass_nhide011_Inter
{
    void bogus();
}
namespace NS_Basic_TestClass_nhide011
{
    interface Basic_TestClass_nhide011_Inter
    {
        void test();
    }
    class Basic_TestClass_nhide011 : Basic_TestClass_nhide011_Inter
    {
        public void test() { }
        public static int Main_old()
        {
            return 0;
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}


enum Basic_TestClass_nhide012_Enum { test = 1 }
namespace NS_Basic_TestClass_nhide012
{
    enum Basic_TestClass_nhide012_Enum { test = 2 }
    class Basic_TestClass_nhide012
    {
        public static int Main_old()
        {
            if ((int)Basic_TestClass_nhide012_Enum.test == 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
delegate void Basic_TestClass_nhide013_Del();
namespace NS_Basic_TestClass_nhide013
{
    delegate int Basic_TestClass_nhide013_Del(int intI);
    class Basic_TestClass_nhide013
    {
        int TestMeth(int intI)
        {
            return 1;
        }
        public static int Main_old()
        {
            Basic_TestClass_nhide013 test = new Basic_TestClass_nhide013();
            Basic_TestClass_nhide013_Del td = new Basic_TestClass_nhide013_Del(test.TestMeth);
            return 0;
        }
        public static bool testMethod()
        {
            return (Main_old() == 0);
        }
    }
}
class Basic_TestClass_nhide014_C1
{
    public class Basic_TestClass_nhide014_I
    {
        public static int intI = 1;
    }
}
namespace NS_Basic_TestClass_nhide014
{
    class Basic_TestClass_nhide014_C1
    {
        public class Basic_TestClass_nhide014_I
        {
            public static int intI = 2;
        }
    }
}
class Basic_TestClass_nhide014
{
    public static int Main_old()
    {
        if (Basic_TestClass_nhide014_C1.Basic_TestClass_nhide014_I.intI == 1)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    public static bool testMethod()
    {
        return (Main_old() == 0);
    }
}
namespace Basic_TestClass_nhide015_C1
{
    class Basic_TestClass_nhide015_I
    {
        public static int intI = 1;
    }
}

namespace Basic_TestClass_nhide022_C1
{
    class Basic_TestClass_nhide022_I
    {
        public static int intI = 1;
    }
}
