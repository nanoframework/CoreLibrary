//
// Copyright (c) .NET Foundation and Contributors
// Portions Copyright (c) Microsoft Corporation.  All rights reserved.
// See LICENSE file in the project root for full license information.
//

using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestArithmetic
{
    [TestClass]
    class UnitTestExpressionTests
    {
        [TestMethod]
        public void Exp_ident001_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within a block, and the block contains a local variable or parameter with the ");
            OutputHelper.WriteLine("given name, then the primary-expression refers to that local variable.");
            Assert.IsTrue(ident001.testMethod());
        }
        [TestMethod]
        public void Exp_ident002_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within a block, and the block contains a local variable or parameter with the ");
            OutputHelper.WriteLine("given name, then the primary-expression refers to that local variable.");
            Assert.IsTrue(ident002.testMethod());
        }
        [TestMethod]
        public void Exp_ident003_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within a block, and the block contains a local variable or parameter with the ");
            OutputHelper.WriteLine("given name, then the primary-expression refers to that local variable.");
            Assert.IsTrue(ident003.testMethod());
        }
        [TestMethod]
        public void Exp_ident004_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within a block, and the block contains a local variable or parameter with the ");
            OutputHelper.WriteLine("given name, then the primary-expression refers to that local variable.");
            Assert.IsTrue(ident004.testMethod());
        }
        [TestMethod]
        public void Exp_ident007_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within the block of a constructor, instance method, or instance property accessor,");
            OutputHelper.WriteLine("and the name identifies one or more accessible methods of the immediately enclosing");
            OutputHelper.WriteLine("class, then the primary expression refers to that method.");
            Assert.IsTrue(ident007.testMethod());
        }
        [TestMethod]
        public void Exp_ident008_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within the block of a constructor, instance method, or instance property accessor,");
            OutputHelper.WriteLine("and the name identifies one or more accessible methods of the immediately enclosing");
            OutputHelper.WriteLine("class, then the primary expression refers to that method.");
            Assert.IsTrue(ident008.testMethod());
        }
        [TestMethod]
        public void Exp_ident009_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within the block of a constructor, instance method, or instance property accessor,");
            OutputHelper.WriteLine("and the name identifies one or more accessible methods of the immediately enclosing");
            OutputHelper.WriteLine("class, then the primary expression refers to that method.");
            Assert.IsTrue(ident009.testMethod());
        }
        [TestMethod]
        public void Exp_ident010_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within the block of a constructor, instance method, or instance property accessor,");
            OutputHelper.WriteLine("and the name identifies one or more accessible methods of the immediately enclosing");
            OutputHelper.WriteLine("class, then the primary expression refers to that method.");
            Assert.IsTrue(ident010.testMethod());
        }
        [TestMethod]
        public void Exp_ident011_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within the block of a constructor, instance method, or instance property accessor,");
            OutputHelper.WriteLine("and the name identifies an accessible, non-static field or property of the immediately");
            OutputHelper.WriteLine("enclosing class, then the primary expression refers to that field or property.");
            Assert.IsTrue(ident011.testMethod());
        }
        [TestMethod]
        public void Exp_ident012_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within the block of a constructor, instance method, or instance property accessor,");
            OutputHelper.WriteLine("and the name identifies an accessible, non-static field or property of the immediately");
            OutputHelper.WriteLine("enclosing class, then the primary expression refers to that field or property.");
            Assert.IsTrue(ident012.testMethod());
        }
        [TestMethod]
        public void Exp_ident013_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of a single identifier ");
            OutputHelper.WriteLine("is within the block of a constructor, instance method, or instance property accessor,");
            OutputHelper.WriteLine("and the name identifies an accessible, non-static field or property of the immediately");
            OutputHelper.WriteLine("enclosing class, then the primary expression refers to that field or property.");
            Assert.IsTrue(ident013.testMethod());
        }
        [TestMethod]
        public void Exp_ident014_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident014.testMethod());
        }
        [TestMethod]
        public void Exp_ident015_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident015.testMethod());
        }
        [TestMethod]
        public void Exp_ident016_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident016.testMethod());
        }
        [TestMethod]
        public void Exp_ident017_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident017.testMethod());
        }
        [TestMethod]
        public void Exp_ident018_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident018.testMethod());
        }
        [TestMethod]
        public void Exp_ident019_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident019_Top.ident019.testMethod());
        }
        [TestMethod]
        public void Exp_ident020_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident020_Top.ident020.testMethod());
        }
        [TestMethod]
        public void Exp_ident021_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident021_Top.ident021.testMethod());
        }
        [TestMethod]
        public void Exp_ident022_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident022_Top.ident022.testMethod());
        }
        [TestMethod]
        public void Exp_ident023_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident023_Top.ident023.testMethod());
        }
        [TestMethod]
        public void Exp_ident024_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident024_Top.ident024.testMethod());
        }
        [TestMethod]
        public void Exp_ident025_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident025_Top.ident025_Next.ident025.testMethod());
        }
        [TestMethod]
        public void Exp_ident026_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident026_Top.ident026_Next.ident026.testMethod());
        }
        [TestMethod]
        public void Exp_ident027_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident027_Top.ident027_Next.ident027.testMethod());
        }
        [TestMethod]
        public void Exp_ident028_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if the primary expression appears within the body of a class, ");
            OutputHelper.WriteLine("struct, or enumeration declaration, and continuing with each enclosing class or struct");
            OutputHelper.WriteLine("declaration, if the name identifies one or more accessible members of that class, ");
            OutputHelper.WriteLine("struct, or enumeration, then the primary expression is evaluated exactly as if it was ");
            OutputHelper.WriteLine("a member access of the form T.E where T is the type in which the member was found and ");
            OutputHelper.WriteLine("E is the primary expression.");
            Assert.IsTrue(ident028_Top.ident028_Next.ident028.testMethod());
        }
        [TestMethod]
        public void Exp_ident029_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if a primary expression consisting of a single identifier refers ");
            OutputHelper.WriteLine("to a member in an enclosing namespace, then the primary expression is evaluated ");
            OutputHelper.WriteLine("to that member and classified as a namespace or a type.");
            Assert.IsTrue(ident029.testMethod());
        }
        [TestMethod]
        public void Exp_ident030_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if a primary expression consisting of a single identifier refers ");
            OutputHelper.WriteLine("to a member in an enclosing namespace, then the primary expression is evaluated ");
            OutputHelper.WriteLine("to that member and classified as a namespace or a type.");
            Assert.IsTrue(ident030.testMethod());
        }

        [TestMethod]
        public void Exp_ident031_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if a primary expression consisting of a single identifier refers ");
            OutputHelper.WriteLine("to a member in an enclosing namespace, then the primary expression is evaluated ");
            OutputHelper.WriteLine("to that member and classified as a namespace or a type.");
            Assert.IsTrue(NS_ident031_I.ident031.testMethod()) ;
        }
        [TestMethod]
        public void Exp_ident032_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if a primary expression consisting of a single identifier refers ");
            OutputHelper.WriteLine("to an imported type, then the primary expression refers to that type.");
            Assert.IsTrue(NS_ident032_I.ident032.testMethod()) ;
        }
        [TestMethod]
        public void Exp_ident033_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if a primary expression consisting of a single identifier refers ");
            OutputHelper.WriteLine("to an imported type, then the primary expression refers to that type.");
            Assert.IsTrue(NS_ident033_O.NS_ident033_I.ident033.testMethod()) ;
        }
        [TestMethod]
        public void Exp_ident034_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if a primary expression consisting of a single identifier refers ");
            OutputHelper.WriteLine("to a single type in an imported namespace, then the primary expression refers to that ");
            OutputHelper.WriteLine("type.");
            Assert.IsTrue(NS_ident034_I.ident034.testMethod()) ;
        }
        [TestMethod]
        public void Exp_ident035_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if a primary expression consisting of a single identifier refers ");
            OutputHelper.WriteLine("to a single type in an imported namespace, then the primary expression refers to that ");
            OutputHelper.WriteLine("type.");
            Assert.IsTrue(NS_ident035_O.NS_ident035_I.ident035.testMethod()) ;
        }
        [TestMethod]
        public void Exp_ident038_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if a primary expression consisting of a single identifier refers ");
            OutputHelper.WriteLine("to an imported type, then the primary expression refers to that type.");
            Assert.IsTrue(NS_ident038_I.ident038.testMethod()) ;
        }
        [TestMethod]
        public void Exp_ident039_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if a primary expression consisting of a single identifier refers ");
            OutputHelper.WriteLine("to an imported type, then the primary expression refers to that type.");
            Assert.IsTrue(NS_ident039_O.NS_ident039_I.ident039.testMethod()) ;
        }

        [TestMethod]
        public void Exp_ident040_Test()
        {
            OutputHelper.WriteLine("Section 7.2.2 ");
            OutputHelper.WriteLine("This code tests that if a primary expression consisting of a single identifier refers ");
            OutputHelper.WriteLine("to an imported type, then the primary expression refers to that type.");
            Assert.IsTrue(NS_ident040_I.ident040.testMethod()) ;
        }

        [TestMethod]
        public void Exp_mem001_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a namespace and I is the name of an accessible member of that namespace, then the ");
            OutputHelper.WriteLine("result is the member, either a namespace or a type.");
            Assert.IsTrue(mem001.testMethod()) ;
        }
        /*
        [TestMethod]
        public void Exp_mem002_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a namespace and I is the name of an accessible member of that namespace, then the ");
            OutputHelper.WriteLine("result is the member, either a namespace or a type.");
            Assert.IsTrue(mem002.testMethod())
            {
                return MFTestResults.Pass;
            }
            return MFTestResults.Fail;
        }
         * */
        [TestMethod]
        public void Exp_mem003_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I is also a type, then the result of the member is that type.");
            Assert.IsTrue(mem003.testMethod()) ;
        }
        [TestMethod]
        public void Exp_mem004_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I is also a type, then the result of the member is that type.");
            Assert.IsTrue(mem004.testMethod()) ;
        }
        [TestMethod]
        public void Exp_mem005_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I identifies one or more methods, then the result is a method group.");
            Assert.IsTrue(mem005.testMethod());
        }
        [TestMethod]
        public void Exp_mem006_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I identifies one or more methods, then the result is a method group.");
            Assert.IsTrue(mem006.testMethod());
        }
        [TestMethod]
        public void Exp_mem007_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I identifies one or more methods, then the result is a method group.");
            Assert.IsTrue(mem007.testMethod());
        }
        [TestMethod]
        public void Exp_mem008_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I identifies one or more methods, then the result is a method group.");
            Assert.IsTrue(mem008.testMethod());
        }
        [TestMethod]
        public void Exp_mem011_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I is a static property, then the result is that static property.");
            Assert.IsTrue(mem011.testMethod());
        }
        [TestMethod]
        public void Exp_mem012_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I is a static property, then the result is that static property.");
            Assert.IsTrue(mem012.testMethod());
        }
        [TestMethod]
        public void Exp_mem013_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I is a static read only field, then the result is a value of the ");
            OutputHelper.WriteLine("static field I.");
            Assert.IsTrue(mem013.testMethod());
        }
        [TestMethod]
        public void Exp_mem014_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I is a static read only field, then the result is a value of the ");
            OutputHelper.WriteLine("static field I.");
            Assert.IsTrue(mem014.testMethod());
        }
        [TestMethod]
        public void Exp_mem015_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I is a static field, then the result is the static field I.");
            Assert.IsTrue(mem015.testMethod());
        }
        [TestMethod]
        public void Exp_mem016_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I is a static field, then the result is the static field I.");
            Assert.IsTrue(mem016.testMethod());
        }
        [TestMethod]
        public void Exp_mem017_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I is a constant, then the result is the value of that constant.");
            Assert.IsTrue(mem017.testMethod());
        }
        [TestMethod]
        public void Exp_mem018_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I is a constant, then the result is the value of that constant.");
            Assert.IsTrue(mem018.testMethod());
        }
        [TestMethod]
        public void Exp_mem019_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a type and I identifies an enumeration member, then the result is the value of");
            OutputHelper.WriteLine("that enumeration member.");
            Assert.IsTrue(mem019.testMethod());
        }
        [TestMethod]
        public void Exp_mem021_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the type of which is T, and I identifies one or ");
            OutputHelper.WriteLine("more method groups, then the result is the method group.");
            Assert.IsTrue(mem021.testMethod());
        }
        [TestMethod]
        public void Exp_mem022_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the type of which is T, and I identifies one or ");
            OutputHelper.WriteLine("more method groups, then the result is the method group.");
            Assert.IsTrue(mem022.testMethod());
        }
        [TestMethod]
        public void Exp_mem023_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the type of which is T, and I identifies one or ");
            OutputHelper.WriteLine("more method groups, then the result is the method group.");
            Assert.IsTrue(mem023.testMethod());
        }
        [TestMethod]
        public void Exp_mem025_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the type of which is T, and I identifies one or ");
            OutputHelper.WriteLine("more method groups, then the result is the method group.");
            Assert.IsTrue(mem025.testMethod());
        }
        [TestMethod]
        public void Exp_mem026_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the type of which is T, and I identifies one or ");
            OutputHelper.WriteLine("more method groups, then the result is the method group.");
            Assert.IsTrue(mem026.testMethod());
        }
        [TestMethod]
        public void Exp_mem027_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the type of which is T, and I identifies an ");
            OutputHelper.WriteLine("instance property, then the result is that instance property.");
            Assert.IsTrue(mem027.testMethod());
        }
        [TestMethod]
        public void Exp_mem028_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the type of which is T, and I identifies an ");
            OutputHelper.WriteLine("instance property, then the result is that instance property.");
            Assert.IsTrue(mem028.testMethod());
        }
        [TestMethod]
        public void Exp_mem029_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the type of which is T, and I identifies an ");
            OutputHelper.WriteLine("instance property, then the result is that instance property.");
            Assert.IsTrue(mem029.testMethod());
        }
        [TestMethod]
        public void Exp_mem031_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the type of which is T, and I identifies an ");
            OutputHelper.WriteLine("instance property, then the result is that instance property.");
            Assert.IsTrue(mem031.testMethod());
        }
        [TestMethod]
        public void Exp_mem032_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the type of which is T, and I identifies an ");
            OutputHelper.WriteLine("instance property, then the result is that instance property.");
            Assert.IsTrue(mem032.testMethod());
        }
        [TestMethod]
        public void Exp_mem034_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field, then if the value of E is null, a System.Exception is ");
            OutputHelper.WriteLine("thrown.");
            Assert.IsTrue(mem034.testMethod());
        }
        [TestMethod]
        public void Exp_mem035_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field, then if the value of E is null, a System.Exception is ");
            OutputHelper.WriteLine("thrown.");
            Assert.IsTrue(mem035.testMethod());
        }
        [TestMethod]
        public void Exp_mem036_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("a read only instance field outside the class declaration, then the result is a value");
            OutputHelper.WriteLine("of the field I.");
            Assert.IsTrue(mem036.testMethod());
        }
        [TestMethod]
        public void Exp_mem038_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("a read only instance field outside the class declaration, then the result is a value");
            OutputHelper.WriteLine("of the field I.");
            Assert.IsTrue(mem038.testMethod());
        }
        [TestMethod]
        public void Exp_mem040_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("a read only instance field outside the class declaration, then the result is a value");
            OutputHelper.WriteLine("of the field I.");
            Assert.IsTrue(mem040.testMethod());
        }
        [TestMethod]
        public void Exp_mem042_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field of class type T.");
            Assert.IsTrue(mem042.testMethod());
        }
        [TestMethod]
        public void Exp_mem043_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field of class type T.");
            Assert.IsTrue(mem043.testMethod());
        }
        [TestMethod]
        public void Exp_mem044_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field of class type T.");
            Assert.IsTrue(mem044.testMethod());
        }
        [TestMethod]
        public void Exp_mem045_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field of class type T.");
            Assert.IsTrue(mem045.testMethod());
        }
        [TestMethod]
        public void Exp_mem046_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field of class type T.");
            Assert.IsTrue(mem046.testMethod());
        }
        [TestMethod]
        public void Exp_mem047_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the class type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field of class type T.");
            Assert.IsTrue(mem047.testMethod());
        }
        [TestMethod]
        public void Exp_mem048_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the struct type of which is T, and I identifies");
            OutputHelper.WriteLine("a read only instance field outside the class declaration, then the result is a value");
            OutputHelper.WriteLine("of the field I.");
            Assert.IsTrue(mem048.testMethod());
        }
        [TestMethod]
        public void Exp_mem050_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the struct type of which is T, and I identifies");
            OutputHelper.WriteLine("a read only instance field outside the class declaration, then the result is a value");
            OutputHelper.WriteLine("of the field I.");
            Assert.IsTrue(mem050.testMethod());
        }
        [TestMethod]
        public void Exp_mem052_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests that if the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the struct type of which is T, and I identifies");
            OutputHelper.WriteLine("a read only instance field outside the class declaration, then the result is a value");
            OutputHelper.WriteLine("of the field I.");
            Assert.IsTrue(mem052.testMethod());
        }
        [TestMethod]
        public void Exp_mem054_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the struct type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field of class type T.");
            Assert.IsTrue(mem054.testMethod());
        }
        [TestMethod]
        public void Exp_mem055_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the struct type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field of class type T.");
            Assert.IsTrue(mem055.testMethod());
        }
        [TestMethod]
        public void Exp_mem056_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the struct type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field of class type T.");
            Assert.IsTrue(mem056.testMethod());
        }
        [TestMethod]
        public void Exp_mem058_Test()
        {
            OutputHelper.WriteLine("Section 7.2.7 ");
            OutputHelper.WriteLine("This code tests the primary expression consisting of the form E.I, where E ");
            OutputHelper.WriteLine("is a variable, property, or value, the struct type of which is T, and I identifies");
            OutputHelper.WriteLine("an instance field of class type T.");
            Assert.IsTrue(mem058.testMethod());
        }
        [TestMethod]
        public void Exp_lit001_Test()
        {
            OutputHelper.WriteLine("Section 7.2.1 ");
            OutputHelper.WriteLine("This code tests that a boolean-literal is of type bool.");
            Assert.IsTrue(lit001.testMethod()) ;
        }
        [TestMethod]
        public void Exp_lit004_Test()
        {
            OutputHelper.WriteLine("Section 7.2.1 ");
            OutputHelper.WriteLine("This code tests that an int-literal is of type int.");
            Assert.IsTrue(lit004.testMethod()) ;
        }
        [TestMethod]
        public void Exp_lit005_Test()
        {
            OutputHelper.WriteLine("Section 7.2.1 ");
            OutputHelper.WriteLine("This code tests that a long-literal is of type long.");
            Assert.IsTrue(lit005.testMethod()) ;
        }
        [TestMethod]
        public void Exp_lit006_Test()
        {
            OutputHelper.WriteLine("Section 7.2.1 ");
            OutputHelper.WriteLine("This code tests that a float-literal is of type float.");
            Assert.IsTrue(lit006.testMethod()) ;
        }
        [TestMethod]
        public void Exp_lit007_Test()
        {
            OutputHelper.WriteLine("Section 7.2.1 ");
            OutputHelper.WriteLine("This code tests that a double-literal is of type double.");
            Assert.IsTrue(lit007.testMethod()) ;
        }
        [TestMethod]
        public void Exp_lit008_Test()
        {
            OutputHelper.WriteLine("Section 7.2.1 ");
            OutputHelper.WriteLine("This code tests that a double-literal is of type double.");
            Assert.IsTrue(lit008.testMethod());
        }
        [TestMethod]
        public void Exp_lit009_Test()
        {
            OutputHelper.WriteLine("Section 7.2.1 ");
            OutputHelper.WriteLine("This code tests that a character-literal is of type char.");
            Assert.IsTrue(lit009.testMethod());
        }
        [TestMethod]
        public void Exp_lit010_Test()
        {
            OutputHelper.WriteLine("Section 7.2.1 ");
            OutputHelper.WriteLine("This code tests that a string-literal is of type string.");
            Assert.IsTrue(lit010.testMethod());
        }
        [TestMethod]
        public void Exp_lit011_Test()
        {
            OutputHelper.WriteLine("Section 7.2.1 ");
            OutputHelper.WriteLine("string compare with with its base type.");
            Assert.IsTrue(lit011.testMethod());
        }
        [TestMethod]
        public void Exp_base006_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            Assert.IsTrue(base006.testMethod()) ;
        }
        [TestMethod]
        public void Exp_base007_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            Assert.IsTrue(base007.testMethod()) ;
        }
        [TestMethod]
        public void Exp_base009_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            Assert.IsTrue(base009.testMethod()) ;
        }
        [TestMethod]
        public void Exp_base010_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            Assert.IsTrue(base010.testMethod()) ;
        }
        [TestMethod]
        public void Exp_base011_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            Assert.IsTrue(base011.testMethod());
        }
        [TestMethod]
        public void Exp_base012_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            Assert.IsTrue(base012.testMethod());
        }
        [TestMethod]
        public void Exp_base013_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            Assert.IsTrue(base013.testMethod());
        }
        [TestMethod]
        public void Exp_base014_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            Assert.IsTrue(base014.testMethod());
        }
        [TestMethod]
        public void Exp_base015_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            Assert.IsTrue(base015.testMethod());
        }
        [TestMethod]
        public void Exp_base016_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            Assert.IsTrue(base016.testMethod());
        }
        [TestMethod]
        public void Exp_base017_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            OutputHelper.WriteLine("Expected Fail");
            Assert.IsTrue(base017.testMethod());
        }
        [TestMethod]
        public void Exp_base018_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            OutputHelper.WriteLine("Expected Fail");
            Assert.IsTrue(base018.testMethod());
        }
        [TestMethod]
        public void Exp_base019_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            OutputHelper.WriteLine("Expected Fail");
            Assert.IsTrue(base019.testMethod());
        }
        [TestMethod]
        public void Exp_base020_Test()
        {
            OutputHelper.WriteLine("Section 7.2.8 ");
            OutputHelper.WriteLine("A base class access is permitted only in the block of a constructor,");
            OutputHelper.WriteLine("an instance method, or an instance property accessor.");
            OutputHelper.WriteLine("Expected Fail");
            Assert.IsTrue(base020.testMethod());
        }

        //Compiled Test Cases 
        public class ident001
        {
            static int intI = 1;
            public static int Main_old()
            {
                int intI = 0;
                return intI; //should return zero
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident002
        {
            static int intI = 1;
            public static int f(int intI)
            {
                return intI;
            }
            public static int Main_old()
            {
                return f(0); //should return zero
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident003
        {
            static int intI = 1;
            public static int Main_old()
            {
                if (true)
                {
                    int intI = 0;
                    return intI;
                }

                return 1; //error if we reach this point
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident004
        {
            static int intI = 1;
            public static int Main_old()
            {
                {
                    int intI = 0;
                    return intI;
                }

                return 1; //error if we reach this point
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident007
        {
            static int intRet = 1;
            public static void ChangeRet()
            {
                intRet = 0;
            }
            public ident007()
            {
                ChangeRet(); //primary expression in constructor			
            }
            public static int Main_old()
            {
                ident007 MyClass = new ident007(); //this should change return value
                return intRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident008
        {
            static int intRet = 1;
            public static void ChangeRet()
            {
                intRet = 0;
            }
            public void ChangeVal()
            {
                ChangeRet(); //primary expression in instance method	
            }
            public static int Main_old()
            {
                ident008 MyClass = new ident008();
                MyClass.ChangeVal(); //this should change return value
                return intRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident009
        {
            static int intRet = 1;
            public static void ChangeRet()
            {
                intRet = 0;
            }

            public int MyInt
            {
                get
                {
                    ChangeRet(); //primary expression in instance property accessor
                    return 0;
                }
                set { }
            }
            public static int Main_old()
            {
                ident009 MyClass = new ident009();
                int intI = MyClass.MyInt; //this should change the return value
                return intRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident010
        {
            static int intRet = 1;
            public static void ChangeRet()
            {
                intRet = 0;
            }

            public int MyInt
            {
                get
                {
                    return 0;
                }
                set
                {
                    ChangeRet(); //primary expression in instance property accessor
                }
            }
            public static int Main_old()
            {
                ident010 MyClass = new ident010();
                MyClass.MyInt = 1; //this should change the return value to zero
                return intRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident011
        {
            int intRet = 0;
            int TestInt = 3;

            public int TestProp
            {
                get
                {
                    return 7;
                }
                set
                {
                    TestInt = 2;
                }
            }
            public ident011()
            {
                if (TestInt != 3) intRet = 1; //accessing non-static field
                if (TestInt != this.TestInt) intRet = 1; //accessing non-static field
                if (TestProp != 7) intRet = 1; //accessing instance property
                if (TestProp != this.TestProp) intRet = 1;//accessing instance property
                TestProp = 8; //accessing instance property
                if (TestInt != 2) intRet = 1; //confirming property setter was called
            }
            public static int Main_old()
            {
                ident011 MyClass = new ident011();
                return MyClass.intRet; //return value will return 1 if something went wrong
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident012
        {
            int intRet = 0;
            int TestInt = 3;

            public int TestProp
            {
                get
                {
                    return 7;
                }
                set
                {
                    TestInt = 2;
                }
            }
            public void TestCode()
            {
                if (TestInt != 3) intRet = 1; //accessing non-static field
                if (TestInt != this.TestInt) intRet = 1; //accessing non-static field
                if (TestProp != 7) intRet = 1; //accessing instance property
                if (TestProp != this.TestProp) intRet = 1;//accessing instance property
                TestProp = 8; //accessing instance property
                if (TestInt != 2) intRet = 1; //confirming property setter was called
            }
            public static int Main_old()
            {
                ident012 MyClass = new ident012();
                MyClass.TestCode();
                return MyClass.intRet; //return value will return 1 if something went wrong
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident013
        {
            int intRet = 0;
            int TestInt = 3;

            public int TestProp
            {
                get
                {
                    return 7;
                }
                set
                {
                    TestInt = 2;
                }
            }
            public int CallProp
            {
                get
                {
                    if (TestInt != 3) intRet = 1; //accessing non-static field
                    if (TestInt != this.TestInt) intRet = 1; //accessing non-static field
                    if (TestProp != 7) intRet = 1; //accessing instance property
                    if (TestProp != this.TestProp) intRet = 1;//accessing instance property
                    TestProp = 8; //accessing instance property
                    if (TestInt != 2) intRet = 1; //confirming property setter was called
                    return 0;
                }
                set
                {
                    if (TestInt != 3) intRet = 1; //accessing non-static field
                    if (TestInt != this.TestInt) intRet = 1; //accessing non-static field
                    if (TestProp != 7) intRet = 1; //accessing instance property
                    if (TestProp != this.TestProp) intRet = 1;//accessing instance property
                    TestProp = 8; //accessing instance property
                    if (TestInt != 2) intRet = 1; //confirming property setter was called
                }
            }
            public static int Main_old()
            {
                ident013 MyClass = new ident013();
                int intI = MyClass.CallProp; //calling getter
                MyClass.TestInt = 3; //resetting for the setter
                MyClass.CallProp = 2; //calling setter
                return MyClass.intRet; //return value will return 1 if something went wrong
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class ident014
        {
            static int IntThree = 3;
            static int TestInt = IntThree; //identifier appears within body of class
            public static int Main_old()
            {
                if (TestInt == 3)
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
        public class ident015
        {
            static int ReturnThree()
            {
                return 3;
            }
            static int TestInt = ReturnThree(); //identifier appears within body of class
            public static int Main_old()
            {
                if (TestInt == 3)
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
        public struct ident016
        {
            static int IntThree = 3;
            static int TestInt = IntThree; //identifier appears within body of class
            public static int Main_old()
            {
                if (TestInt == 3)
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
        public struct ident017
        {
            static int ReturnThree()
            {
                return 3;
            }
            static int TestInt = ReturnThree(); //identifier appears within body of class
            public static int Main_old()
            {
                if (TestInt == 3)
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
        enum AA { a = 3, b = a }; //identifier appears within body of enum
        public class ident018
        {
            public static int Main_old()
            {
                if ((int)AA.b == 3)
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
        public class ident019_Top
        {
            public static int IntThree = 3;

            public class ident019
            {
                public static int TestInt = IntThree;
                public static int Main_old()
                {
                    if (TestInt == 3)
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
        public class ident020_Top
        {
            public static int ReturnThree()
            {
                return 3;
            }

            public class ident020
            {

                public static int TestInt = ReturnThree();
                public static int Main_old()
                {
                    if (TestInt == 3)
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
        public class ident021_Top
        {
            public static int IntThree = 3;

            public struct ident021
            {
                public static int TestInt = IntThree;
                public static int Main_old()
                {
                    if (TestInt == 3)
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
        public class ident022_Top
        {
            public static int ReturnThree()
            {
                return 3;
            }

            public struct ident022
            {

                public static int TestInt = ReturnThree();
                public static int Main_old()
                {
                    if (TestInt == 3)
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
        public struct ident023_Top
        {
            public static int IntThree = 3;

            public struct ident023
            {
                public static int TestInt = IntThree;
                public static int Main_old()
                {
                    if (TestInt == 3)
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
        public struct ident024_Top
        {
            public static int ReturnThree()
            {
                return 3;
            }

            public struct ident024
            {

                public static int TestInt = ReturnThree();
                public static int Main_old()
                {
                    if (TestInt == 3)
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
        public class ident025_Top
        {
            public static int IntThree = 3;

            public class ident025_Next
            {
                public class ident025
                {
                    public static int TestInt = IntThree;
                    public static int Main_old()
                    {
                        if (TestInt == 3)
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
        public class ident026_Top
        {
            public static int ReturnThree()
            {
                return 3;
            }
            public class ident026_Next
            {
                public class ident026
                {

                    public static int TestInt = ReturnThree();
                    public static int Main_old()
                    {
                        if (TestInt == 3)
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
        public class ident027_Top
        {
            public static int IntThree = 2;

            public class ident027_Next
            {
                public static int IntThree = 3; //should refer to this one
                public class ident027
                {
                    public static int TestInt = IntThree;
                    public static int Main_old()
                    {
                        if (TestInt == 3)
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
        public class ident028_Top
        {
            public static int ReturnThree()
            {
                return 2;
            }
            public class ident028_Next
            {
                public static int ReturnThree()
                {
                    return 3;
                }
                public class ident028
                {

                    public static int TestInt = ReturnThree();
                    public static int Main_old()
                    {
                        if (TestInt == 3)
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
        public class Exp_TestClass_ident029_TC
        {
            public int TestInt = 1;
        }
        public class ident029
        {

            public static int Main_old()
            {
                Exp_TestClass_ident029_TC TC = new Exp_TestClass_ident029_TC(); //testing type identifier in same namespace
                if (TC.TestInt == 1)
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
        public class Exp_TestClass_ident030_TC
        {
            public int TestInt = 1;
        }

        public class ident030
        {

            public static int Main_old()
            {
                Exp_TestClass_ident030_TC TC = new Exp_TestClass_ident030_TC(); //testing type identifier in enclosing namespace
                if (TC.TestInt == 1)
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




        public class mem001
        {
            public static int Main_old()
            {
                Exp_TestClass_mem001_TS.Exp_TestClass_mem001_TC TC = new Exp_TestClass_mem001_TS.Exp_TestClass_mem001_TC(); //testing E.I
                if (TC.TestInt == 2)
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
	public class mem002 {
		public static int Main_old()
		{
            Exp_TestClass_mem002_TC TC = new Exp_TestClass_mem002_TC(); //testing E.I
			if (TC.TestInt == 3) {
				return 0;
			}
			else {
				return 1;
			}
		}
public static bool testMethod()
{
	return (Main_old() == 0);
}
	}
         */
        public class Exp_TestClass_mem003_TC
        {
            public class InnerClass
            {
                public int TestInt = 2;
            }
        }
        public class mem003
        {
            public static int Main_old()
            {
                Exp_TestClass_mem003_TC.InnerClass TC = new Exp_TestClass_mem003_TC.InnerClass(); //testing E.I
                if (TC.TestInt == 2)
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
        public struct Exp_TestClass_mem004_TC
        {
            public class InnerClass
            {
                public int TestInt = 2;
            }
        }
        public class mem004
        {
            public static int Main_old()
            {
                Exp_TestClass_mem004_TC.InnerClass TC = new Exp_TestClass_mem004_TC.InnerClass(); //testing E.I
                if (TC.TestInt == 2)
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
        public class Exp_TestClass_mem005_TC
        {
            public static int IntRet()
            {
                return 1;
            }
        }
        public class mem005
        {
            public static int Main_old()
            {
                if (Exp_TestClass_mem005_TC.IntRet() == 1)
                { //testing E.I
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
        public struct Exp_TestClass_mem006_TC
        {
            public static int IntRet()
            {
                return 1;
            }
        }
        public class mem006
        {
            public static int Main_old()
            {
                if (Exp_TestClass_mem006_TC.IntRet() == 1)
                { //testing E.I
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
        public class Exp_TestClass_mem007_TC
        {
            public static int IntRet()
            {
                return 1;
            }
            public static int IntRet(int IntI)
            {
                return IntI;
            }
        }
        public class mem007
        {
            public static int Main_old()
            {
                if (Exp_TestClass_mem007_TC.IntRet(4) == 4)
                { //testing E.I
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
        public struct Exp_TestClass_mem008_TC
        {
            public static int IntRet()
            {
                return 1;
            }
            public static int IntRet(int IntI)
            {
                return IntI;
            }
        }
        public class mem008
        {
            public static int Main_old()
            {
                if (Exp_TestClass_mem008_TC.IntRet(4) == 4)
                { //testing E.I
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
        public class Exp_TestClass_mem011_TC
        {

            public static int TestInt = 0;
            public static int MyInt
            {
                get
                {
                    TestInt = 1;
                    return TestInt;
                }
                set
                {
                    TestInt = TestInt + 1;
                }
            }
        }

        public class mem011
        {
            public static int Main_old()
            {
                int RetInt = 0;
                if (Exp_TestClass_mem011_TC.MyInt != 1) RetInt = 1; //testing E.I		
                if (Exp_TestClass_mem011_TC.TestInt != 1) RetInt = 1;
                Exp_TestClass_mem011_TC.MyInt = 3; //testing E.I
                if (Exp_TestClass_mem011_TC.TestInt != 2) RetInt = 1;
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem012_TC
        {

            public static int TestInt = 0;
            public static int MyInt
            {
                get
                {
                    TestInt = 1;
                    return TestInt;
                }
                set
                {
                    TestInt = TestInt + 1;
                }
            }
        }

        public class mem012
        {
            public static int Main_old()
            {
                int RetInt = 0;
                if (Exp_TestClass_mem012_TC.MyInt != 1) RetInt = 1; //testing E.I
                if (Exp_TestClass_mem012_TC.TestInt != 1) RetInt = 1;
                Exp_TestClass_mem012_TC.MyInt = 3; //testing E.I
                if (Exp_TestClass_mem012_TC.TestInt != 2) RetInt = 1;
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem013_TC
        {

            public static readonly int TestInt = 2;
        }

        public class mem013
        {
            public static int Main_old()
            {
                if (Exp_TestClass_mem013_TC.TestInt == 2)
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
        public struct Exp_TestClass_mem014_TC
        {

            public static readonly int TestInt = 2;
        }

        public class mem014
        {
            public static int Main_old()
            {
                if (Exp_TestClass_mem014_TC.TestInt == 2)
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
        public class Exp_TestClass_mem015_TC
        {

            public static int TestInt = 2;
        }

        public class mem015
        {
            public static int Main_old()
            {
                int RetInt = 0;
                if (Exp_TestClass_mem015_TC.TestInt != 2)
                { //testing E.I
                    RetInt = 1;
                }
                Exp_TestClass_mem015_TC.TestInt = 3; //testing E.I
                if (Exp_TestClass_mem015_TC.TestInt != 3)
                { //testing E.I
                    RetInt = 1;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem016_TC
        {

            public static int TestInt = 2;
        }

        public class mem016
        {
            public static int Main_old()
            {
                int RetInt = 0;
                if (Exp_TestClass_mem016_TC.TestInt != 2)
                { //testing E.I
                    RetInt = 1;
                }
                Exp_TestClass_mem016_TC.TestInt = 3; //testing E.I
                if (Exp_TestClass_mem016_TC.TestInt != 3)
                { //testing E.I
                    RetInt = 1;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem017_TC
        {

            public const int TestInt = 2;
        }

        public class mem017
        {
            public static int Main_old()
            {
                if (Exp_TestClass_mem017_TC.TestInt == 2)
                { //testing E.I
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
        public struct Exp_TestClass_mem018_TC
        {

            public const int TestInt = 2;
        }

        public class mem018
        {
            public static int Main_old()
            {
                if (Exp_TestClass_mem018_TC.TestInt == 2)
                { //testing E.I
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
        enum mem019_AA { a = 3, b = a };
        public class mem019
        {
            public static int Main_old()
            {
                if ((int)mem019_AA.a == 3)
                { //testing E.I
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
        public class Exp_TestClass_mem021_TC
        {
            public int IntRet()
            {
                return 2;
            }
            public int IntRet(int IntI)
            {
                return IntI;
            }
        }
        public class mem021
        {
            public static Exp_TestClass_mem021_TC GetTC
            {
                get
                {
                    return new Exp_TestClass_mem021_TC();
                }
            }
            public static int Main_old()
            {
                int MyRet = 0;
                if (GetTC.IntRet() != 2)
                { //testing E.I
                    MyRet = 1;
                }
                if (GetTC.IntRet(3) != 3)
                { //testing E.I
                    MyRet = 1;
                }
                return MyRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem022_TC
        {
            public int IntRet()
            {
                return 2;
            }
            public int IntRet(int IntI)
            {
                return IntI;
            }
        }
        public class mem022
        {
            public static int Main_old()
            {
                int MyRet = 0;
                Exp_TestClass_mem022_TC TC = new Exp_TestClass_mem022_TC();
                if (TC.IntRet() != 2)
                { //testing E.I
                    MyRet = 1;
                }
                if (TC.IntRet(3) != 3)
                { //testing E.I
                    MyRet = 1;
                }
                return MyRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem023_TC
        {
            public int IntRet()
            {
                return 2;
            }
            public int IntRet(int IntI)
            {
                return IntI;
            }
        }
        public class mem023
        {
            public static int Main_old()
            {
                int MyRet = 0;
                Exp_TestClass_mem023_TC TC = new Exp_TestClass_mem023_TC();
                if (new Exp_TestClass_mem023_TC().IntRet() != 2)
                { //testing E.I
                    MyRet = 1;
                }
                if (new Exp_TestClass_mem023_TC().IntRet(3) != 3)
                { //testing E.I
                    MyRet = 1;
                }
                return MyRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem025_TC
        {
            public int IntRet()
            {
                return 2;
            }
            public int IntRet(int IntI)
            {
                return IntI;
            }
        }
        public class mem025
        {
            public static int Main_old()
            {
                int MyRet = 0;
                Exp_TestClass_mem025_TC TC = new Exp_TestClass_mem025_TC();
                if (TC.IntRet() != 2)
                { //testing E.I
                    MyRet = 1;
                }
                if (TC.IntRet(3) != 3)
                { //testing E.I
                    MyRet = 1;
                }
                return MyRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem026_TC
        {
            public int IntRet()
            {
                return 2;
            }
            public int IntRet(int IntI)
            {
                return IntI;
            }
        }
        public class mem026
        {
            public static int Main_old()
            {
                int MyRet = 0;
                Exp_TestClass_mem026_TC TC = new Exp_TestClass_mem026_TC();
                if (new Exp_TestClass_mem026_TC().IntRet() != 2)
                { //testing E.I
                    MyRet = 1;
                }
                if (new Exp_TestClass_mem026_TC().IntRet(3) != 3)
                { //testing E.I
                    MyRet = 1;
                }
                return MyRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem027_TC
        {

            public static int IntVal = 2;
            public int IntRet
            {
                get
                {
                    return IntVal;
                }
                set
                {
                    IntVal = IntVal + 1;
                }
            }
        }
        public class mem027
        {
            public static Exp_TestClass_mem027_TC GetTC
            {
                get
                {
                    return new Exp_TestClass_mem027_TC();
                }
            }
            public static int Main_old()
            {
                int MyRet = 0;
                if (GetTC.IntRet != 2)
                { //testing E.I
                    MyRet = 1;
                }
                GetTC.IntRet = 3; //testing E.I			
                if (Exp_TestClass_mem027_TC.IntVal != 3)
                {
                    MyRet = 1;
                }
                return MyRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem028_TC
        {

            public static int IntVal = 2;
            public int IntRet
            {
                get
                {
                    return IntVal;
                }
                set
                {
                    IntVal = IntVal + 1;
                }
            }
        }
        public class mem028
        {
            public static int Main_old()
            {
                int MyRet = 0;
                Exp_TestClass_mem028_TC TC = new Exp_TestClass_mem028_TC();
                if (TC.IntRet != 2)
                { //testing E.I
                    MyRet = 1;
                }
                TC.IntRet = 3; //testing E.I			
                if (Exp_TestClass_mem028_TC.IntVal != 3)
                {
                    MyRet = 1;
                }
                return MyRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem029_TC
        {

            public static int IntVal = 2;
            public int IntRet
            {
                get
                {
                    return IntVal;
                }
                set
                {
                    IntVal = IntVal + 1;
                }
            }
        }
        public class mem029
        {
            public static int Main_old()
            {
                int MyRet = 0;
                if (new Exp_TestClass_mem029_TC().IntRet != 2)
                { //testing E.I
                    MyRet = 1;
                }
                new Exp_TestClass_mem029_TC().IntRet = 3; //testing E.I			
                if (Exp_TestClass_mem029_TC.IntVal != 3)
                {
                    MyRet = 1;
                }
                return MyRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem031_TC
        {

            public static int IntVal = 2;
            public int IntRet
            {
                get
                {
                    return IntVal;
                }
                set
                {
                    IntVal = IntVal + 1;
                }
            }
        }
        public class mem031
        {
            public static int Main_old()
            {
                int MyRet = 0;
                Exp_TestClass_mem031_TC TC = new Exp_TestClass_mem031_TC();
                if (TC.IntRet != 2)
                { //testing E.I
                    MyRet = 1;
                }
                TC.IntRet = 3; //testing E.I			
                if (Exp_TestClass_mem031_TC.IntVal != 3)
                {
                    MyRet = 1;
                }
                return MyRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem032_TC
        {
            public int IntRet
            {
                get
                {
                    return 2;
                }
            }
        }
        public class mem032
        {
            public static int Main_old()
            {
                int MyRet = 0;
                if (new Exp_TestClass_mem032_TC().IntRet != 2)
                { //testing E.I
                    MyRet = 1;
                }
                return MyRet;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem034_TC
        {
            public int IntI = 0;
        }
        public class mem034
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Exp_TestClass_mem034_TC TC = null;
                try
                {
                    int MyInt = TC.IntI;
                }
                catch (System.Exception)
                {
                    RetInt = 0;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem035_TC
        {
            public int IntI = 0;
        }
        public class mem035
        {
            public static Exp_TestClass_mem035_TC getTC
            {
                get
                {
                    return null;
                }
            }
            public static int Main_old()
            {
                int RetInt = 1;

                try
                {
                    int TempInt = getTC.IntI;
                }
                catch (System.Exception)
                {
                    RetInt = 0;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem036_TC
        {
            public readonly int IntI = 0;
        }
        public class mem036
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Exp_TestClass_mem036_TC TC = new Exp_TestClass_mem036_TC();
                RetInt = TC.IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem038_TC
        {
            public readonly int IntI = 0;
        }
        public class mem038
        {
            public static Exp_TestClass_mem038_TC getTC
            {
                get
                {
                    return new Exp_TestClass_mem038_TC();
                }
            }
            public static int Main_old()
            {
                int RetInt = 1;
                Exp_TestClass_mem038_TC TC = new Exp_TestClass_mem038_TC();
                RetInt = getTC.IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem040_TC
        {
            public readonly int IntI = 0;
        }
        public class mem040
        {
            public static int Main_old()
            {
                int RetInt = 1;
                RetInt = new Exp_TestClass_mem040_TC().IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem042_TC
        {
            public int IntI = 0;
        }
        public class mem042
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Exp_TestClass_mem042_TC TC = new Exp_TestClass_mem042_TC();
                RetInt = TC.IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem043_TC
        {
            public int IntI = 0;
        }
        public class mem043
        {
            public static int Main_old()
            {
                Exp_TestClass_mem043_TC TC = new Exp_TestClass_mem043_TC();
                TC.IntI = 3; //testing E.I
                if (TC.IntI == 3)
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
        public class Exp_TestClass_mem044_TC
        {
            public int IntI = 0;
        }
        public class mem044
        {
            public static Exp_TestClass_mem044_TC getTC
            {
                get
                {
                    return new Exp_TestClass_mem044_TC();
                }
            }
            public static int Main_old()
            {
                int RetInt = 1;
                RetInt = getTC.IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem045_TC
        {
            public int IntI = 0;
        }
        public class mem045
        {
            static Exp_TestClass_mem045_TC TC = new Exp_TestClass_mem045_TC();
            public static Exp_TestClass_mem045_TC getTC
            {
                get
                {
                    return TC;
                }
            }
            public static int Main_old()
            {
                getTC.IntI = 3; //testing E.I
                ZMyClass.MyPrint(TC.IntI);
                if (TC.IntI == 3)
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
        class ZMyClass
        {
            public static void MyPrint()
            { OutputHelper.WriteLine("\n"); }
            public static void MyPrint(string str)
            { OutputHelper.WriteLine(str); }
            public static void MyPrint(object ob)
            {
                OutputHelper.WriteLine(ob.ToString());
            }
            public static void MyPrint(string fmt, params object[] arg)
            {
                string str = "";
                for (int i = 0; i < arg.Length; i++)
                {
                    str = str + arg[i].ToString();
                }
                OutputHelper.WriteLine(str);
            }
        }
        public class Exp_TestClass_mem046_TC
        {
            public int IntI = 0;
        }
        public class mem046
        {
            public static int Main_old()
            {
                int RetInt = 1;
                RetInt = new Exp_TestClass_mem046_TC().IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_mem047_TC
        {
            public int IntI = 0;
        }
        public class mem047
        {
            public static int Main_old()
            {
                new Exp_TestClass_mem047_TC().IntI = 3; //if it compiles, no error
                return 0;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem048_TC
        {
            public Exp_TestClass_mem048_TC(int intI)
            {
                IntI = 0;
            }
            public readonly int IntI;
        }
        public class mem048
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Exp_TestClass_mem048_TC TC = new Exp_TestClass_mem048_TC(2);
                RetInt = TC.IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem050_TC
        {
            public Exp_TestClass_mem050_TC(int intI)
            {
                IntI = 0;
            }
            public readonly int IntI;
        }
        public class mem050
        {
            public static Exp_TestClass_mem050_TC getTC
            {
                get
                {
                    return new Exp_TestClass_mem050_TC(3);
                }
            }
            public static int Main_old()
            {
                int RetInt = 1;
                Exp_TestClass_mem050_TC TC = new Exp_TestClass_mem050_TC(3);
                RetInt = getTC.IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem052_TC
        {
            public Exp_TestClass_mem052_TC(int intI)
            {
                IntI = 0;
            }
            public readonly int IntI;
        }
        public class mem052
        {
            public static int Main_old()
            {
                int RetInt = 1;
                RetInt = new Exp_TestClass_mem052_TC(3).IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem054_TC
        {
            public Exp_TestClass_mem054_TC(int intI)
            {
                IntI = 0;
            }
            public int IntI;
        }
        public class mem054
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Exp_TestClass_mem054_TC TC = new Exp_TestClass_mem054_TC(3);
                RetInt = TC.IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem055_TC
        {
            public Exp_TestClass_mem055_TC(int intI)
            {
                IntI = 0;
            }
            public int IntI;
        }
        public class mem055
        {
            public static int Main_old()
            {
                Exp_TestClass_mem055_TC TC = new Exp_TestClass_mem055_TC(3);
                TC.IntI = 3; //testing E.I
                if (TC.IntI == 3)
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
        public struct Exp_TestClass_mem056_TC
        {
            public Exp_TestClass_mem056_TC(int intI)
            {
                IntI = 0;
            }
            public int IntI;
        }
        public class mem056
        {
            public static Exp_TestClass_mem056_TC getTC
            {
                get
                {
                    return new Exp_TestClass_mem056_TC(3);
                }
            }
            public static int Main_old()
            {
                int RetInt = 1;
                Exp_TestClass_mem056_TC TC = new Exp_TestClass_mem056_TC(3);
                RetInt = getTC.IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct Exp_TestClass_mem058_TC
        {
            public Exp_TestClass_mem058_TC(int intI)
            {
                IntI = 0;
            }
            public int IntI;
        }
        public class mem058
        {
            public static int Main_old()
            {
                int RetInt = 1;
                RetInt = new Exp_TestClass_mem058_TC(3).IntI; //testing E.I
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class lit001
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Type t1 = true.GetType();
                Type t2 = false.GetType();
                Type t3 = typeof(System.Boolean);
                if ((t1 == t3) && (t2 == t3))
                {
                    RetInt = 0;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class lit004
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Type t1 = 3.GetType();
                Type t2 = (-44).GetType();
                Type t3 = 234.GetType();
                Type t4 = typeof(System.Int32);
                if ((t1 == t4) && (t2 == t4) && (t3 == t4))
                {
                    RetInt = 0;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class lit005
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Type t1 = 3L.GetType();
                Type t2 = (-3000L).GetType();
                Type t3 = typeof(System.Int64);
                if ((t1 == t3) && (t2 == t3))
                {
                    RetInt = 0;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class lit006
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Type t1 = 2.0f.GetType();
                Type t2 = (-2.33F).GetType();
                Type t3 = typeof(System.Single);
                if ((t1 == t3) && (t2 == t3))
                {
                    RetInt = 0;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class lit007
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Type t1 = 2.0d.GetType();
                Type t2 = (-2.33D).GetType();
                Type t3 = 2.343.GetType();
                Type t4 = typeof(System.Double);
                if ((t1 == t4) && (t2 == t4) && (t3 == t4))
                {
                    RetInt = 0;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class lit008
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Type t1 = 2.0.GetType();
                Type t2 = (-2.33).GetType();
                Type t3 = typeof(System.Double);
                if ((t1 == t3) && (t2 == t3))
                {
                    RetInt = 0;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class lit009
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Type t1 = 'a'.GetType();
                Type t2 = typeof(System.Char);
                if (t1 == t2)
                {
                    RetInt = 0;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class lit010
        {
            public static int Main_old()
            {
                int RetInt = 1;
                Type t1 = "foobar".GetType();
                Type t2 = typeof(System.String);
                if (t1 == t2)
                {
                    RetInt = 0;
                }
                return RetInt;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class lit011
        {
            public static int Main_old()
            {
                string s = "This is an expression test";
                object o = s;
                bool b = o == s;
                bool bb = s == o;

                if (b && bb)
                    return 0;
                else
                    return 1;
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public class Exp_TestClass_base006_Base
        {
            public int intI()
            {
                return 1;
            }
        }
        public class base006 : Exp_TestClass_base006_Base
        {
            public int TestInt()
            {
                return base.intI();
            }
            public static int Main_old()
            {
                base006 TC = new base006();
                if (TC.TestInt() == 1)
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
        public class Exp_TestClass_base007_Base
        {
            public virtual int intI()
            {
                return 1;
            }
        }
        public class base007 : Exp_TestClass_base007_Base
        {
            override public int intI()
            {
                return 2;
            }
            public int TestInt()
            {
                return base.intI();
            }
            public static int Main_old()
            {
                base007 TC = new base007();
                if (TC.TestInt() == 1)
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
        public class Exp_TestClass_base009_Base
        {
            public int intI()
            {
                return 1;
            }
        }
        public class base009 : Exp_TestClass_base009_Base
        {
            int TestInt = 0;
            public base009()
            {
                TestInt = base.intI();
            }
            public static int Main_old()
            {
                base009 TC = new base009();
                if (TC.TestInt == 1)
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
        public class Exp_TestClass_base010_Base
        {
            public virtual int intI()
            {
                return 1;
            }
        }
        public class base010 : Exp_TestClass_base010_Base
        {
            int TestInt = 0;
            override public int intI()
            {
                return 2;
            }
            public base010()
            {
                TestInt = base.intI();
            }
            public static int Main_old()
            {
                base010 TC = new base010();
                if (TC.TestInt == 1)
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
        public class Exp_TestClass_base011_Base
        {
            public int intI()
            {
                return 1;
            }
        }
        public class base011 : Exp_TestClass_base011_Base
        {
            int MyInt = 0;
            public int TestInt
            {
                get
                {
                    MyInt = base.intI();
                    return 2;
                }
            }
            public static int Main_old()
            {

                int Temp;

                base011 TC = new base011();
                Temp = TC.TestInt;
                if (TC.MyInt == 1)
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
        public class Exp_TestClass_base012_Base
        {
            public virtual int intI()
            {
                return 1;
            }
        }
        public class base012 : Exp_TestClass_base012_Base
        {
            int MyInt = 0;
            public int TestInt
            {
                get
                {
                    MyInt = base.intI();
                    return 2;
                }
            }
            override public int intI()
            {
                return 2;
            }
            public static int Main_old()
            {

                int Temp;

                base012 TC = new base012();
                Temp = TC.TestInt;
                if (TC.MyInt == 1)
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
        public class Exp_TestClass_base013_Base
        {
            public int intI()
            {
                return 1;
            }
        }
        public class base013 : Exp_TestClass_base013_Base
        {
            int MyInt = 0;
            public int TestInt
            {
                set
                {
                    MyInt = base.intI();
                }
            }
            public static int Main_old()
            {
                base013 TC = new base013();
                TC.TestInt = 3;
                if (TC.MyInt == 1)
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
        public class Exp_TestClass_base014_Base
        {
            public virtual int intI()
            {
                return 1;
            }
        }
        public class base014 : Exp_TestClass_base014_Base
        {
            int MyInt = 0;
            public int TestInt
            {
                set
                {
                    MyInt = base.intI();
                }
            }
            override public int intI()
            {
                return 2;
            }
            public static int Main_old()
            {
                base014 TC = new base014();
                TC.TestInt = 3;
                if (TC.MyInt == 1)
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
        public class Exp_TestClass_base015_Base
        {
            public int intI = 3;
        }
        public class base015 : Exp_TestClass_base015_Base
        {
            new int intI = 5;
            public int TestInt()
            {
                return base.intI;
            }
            public static int Main_old()
            {
                base015 TC = new base015();
                if (TC.TestInt() == 3)
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
        public class Exp_TestClass_base016_Base
        {
            public int intI
            {
                get
                {
                    return 3;
                }
            }
        }
        public class base016 : Exp_TestClass_base016_Base
        {
            new public int intI
            {
                get
                {
                    return 4;
                }
            }
            public int TestInt()
            {
                return base.intI;
            }
            public static int Main_old()
            {
                base016 TC = new base016();
                if (TC.TestInt() == 3)
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
        public struct base017
        {
            override public string ToString()
            {
                return "foobar";
            }
            public string GetStr()
            {
                return base.ToString();
            }
            public static int Main_old()
            {
                base017 TC = new base017();
                if (TC.GetStr().Equals("NFUnitTestArithmetic.UnitTestExpressionTests+base017"))
                {
                    return 0;
                }
                else
                {
                    OutputHelper.WriteLine(TC.GetStr());
                    return 1;
                }
            }
            public static bool testMethod()
            {
                return (Main_old() == 0);
            }
        }
        public struct base018
        {
            String TestString;

            public base018(int IntI)
            {
                TestString = null;
                TestString = base.ToString();
            }
            override public String ToString()
            {
                return "foobar";
            }
            public static int Main_old()
            {
                base018 TC = new base018(3);
                if (TC.TestString.Equals("NFUnitTestArithmetic.UnitTestExpressionTests+base018"))
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
        public struct base019
        {
            String TestString;
            override public String ToString()
            {
                return "foobar";
            }
            public int GetInt
            {
                get
                {
                    TestString = base.ToString();
                    return 1;
                }
            }
            public static int Main_old()
            {
                int Temp;

                base019 TC = new base019();
                Temp = TC.GetInt;
                if (TC.TestString.Equals("NFUnitTestArithmetic.UnitTestExpressionTests+base019"))
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
        public struct base020
        {
            String TestString;
            override public String ToString()
            {
                return "foobar";
            }
            public int SetInt
            {
                set
                {
                    TestString = base.ToString();
                }
            }
            public static int Main_old()
            {
                base020 TC = new base020();
                TC.SetInt = 3;
                if (TC.TestString.Equals("NFUnitTestArithmetic.UnitTestExpressionTests+base020"))
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

namespace Exp_TestClass_mem001_TS
{
    public class Exp_TestClass_mem001_TC
    {
        public int TestInt = 2;
    }
}

namespace Exp_TestClass_mem002_TS
{
    namespace InnerSpace
    {
        public class Exp_TestClass_mem002_TC
        {
            public int TestInt = 3;
        }
    }
}



public class Exp_TestClass_ident030_TC
{
    public int TestInt = 1;
}
namespace NS_ident030_I
{
    public class ident030
    {

        public static int Main_old()
        {
            Exp_TestClass_ident030_TC TC = new Exp_TestClass_ident030_TC(); //testing type identifier in enclosing namespace
            if (TC.TestInt == 1)
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
namespace Exp_TestClass_ident031_T
{
    public class Exp_TestClass_ident031_TC
    {
        public int TestInt = 1;
    }
}
namespace NS_ident031_I
{
    using Exp_TestClass_ident031_T; //testing namespace identifier in enclosing namespace
    public class ident031
    {
        public static int Main_old()
        {
            Exp_TestClass_ident031_TC TC = new Exp_TestClass_ident031_TC();
            if (TC.TestInt == 1)
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
namespace Exp_TestClass_ident032_T
{
    public class Exp_TestClass_ident032_TC
    {
        public int TestInt = 1;
    }
}
namespace NS_ident032_I
{
    using Exp_TestClass_ident032_TC = Exp_TestClass_ident032_T.Exp_TestClass_ident032_TC;
    public class ident032
    {
        public static int Main_old()
        {
            Exp_TestClass_ident032_TC TC = new Exp_TestClass_ident032_TC(); //identifier refers to imported type
            if (TC.TestInt == 1)
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
namespace Exp_TestClass_ident033_T
{
    public class Exp_TestClass_ident033_TC
    {
        public int TestInt = 1;
    }
}
namespace NS_ident033_O
{

    using Exp_TestClass_ident033_TC = Exp_TestClass_ident033_T.Exp_TestClass_ident033_TC;
    namespace NS_ident033_I
    {
        public class ident033
        {
            public static int Main_old()
            {
                Exp_TestClass_ident033_TC TC = new Exp_TestClass_ident033_TC(); //identifier refers to imported type
                if (TC.TestInt == 1)
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
namespace Exp_TestClass_ident034_T
{
    public class Exp_TestClass_ident034_TC
    {
        public int TestInt = 1;
    }
}
namespace NS_ident034_I
{
    using Exp_TestClass_ident034_T;
    public class ident034
    {
        public static int Main_old()
        {
            Exp_TestClass_ident034_TC TC = new Exp_TestClass_ident034_TC(); //identifier refers to type in imported namespace
            if (TC.TestInt == 1)
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
namespace Exp_TestClass_ident035_T
{
    public class Exp_TestClass_ident035_TC
    {
        public int TestInt = 1;
    }
}
namespace NS_ident035_O
{

    using Exp_TestClass_ident035_T;
    namespace NS_ident035_I
    {
        public class ident035
        {
            public static int Main_old()
            {
                Exp_TestClass_ident035_TC TC = new Exp_TestClass_ident035_TC(); //identifier refers to type in imported namespace
                if (TC.TestInt == 1)
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
namespace Exp_TestClass_ident038_T
{
    public class Exp_TestClass_ident038_TC
    {
        public int TestInt = 1;
    }
}
namespace Exp_TestClass_ident038_T2
{
    public class Exp_TestClass_ident038_TC
    {
        public int TestInt = 2;
    }
}
namespace NS_ident038_I
{
    using Exp_TestClass_ident038_T;
    using Exp_TestClass_ident038_TC = Exp_TestClass_ident038_T2.Exp_TestClass_ident038_TC;
    public class ident038
    {
        public static int Main_old()
        {
            Exp_TestClass_ident038_TC TC = new Exp_TestClass_ident038_TC(); //identifier refers to type in imported type
            if (TC.TestInt == 2)
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
namespace Exp_TestClass_ident039_T
{
    public class Exp_TestClass_ident039_TC
    {
        public int TestInt = 1;
    }
}
namespace Exp_TestClass_ident039_T2
{
    public class Exp_TestClass_ident039_TC
    {
        public int TestInt = 2;
    }
}
namespace NS_ident039_O
{
    using Exp_TestClass_ident039_TC = Exp_TestClass_ident039_T2.Exp_TestClass_ident039_TC;
    using Exp_TestClass_ident039_T;
    namespace NS_ident039_I
    {
        public class ident039
        {
            public static int Main_old()
            {
                Exp_TestClass_ident039_TC TC = new Exp_TestClass_ident039_TC(); //identifier refers to type in imported type
                if (TC.TestInt == 2)
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
namespace Exp_TestClass_ident040_T
{
    public class Exp_TestClass_ident040_TC
    {
        public int TestInt = 1;
    }
}
namespace NS_ident040_I
{
    using Exp_TestClass_ident040_T;
    using Exp_TestClass_ident040_TC = Exp_TestClass_ident040_T.Exp_TestClass_ident040_TC;
    public class ident040
    {
        public static int Main_old()
        {
            Exp_TestClass_ident040_TC TC = new Exp_TestClass_ident040_TC(); //identifier refers to type in imported type
            if (TC.TestInt == 1)
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
