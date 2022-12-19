using nanoFramework.TestFramework;
using System;
using System.Diagnostics;

namespace NFUnitTestClasses
{
    [TestClass]
    class UnitTestMethodsTests
    {
        [TestMethod]
        public void Methods1_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass1.testMethod());
        }

        [TestMethod]
        public void Methods2_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass2.testMethod());
        }

        [TestMethod]
        public void Methods3_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass3.testMethod());
        }

        [TestMethod]
        public void Methods4_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass4.testMethod());
        }

        [TestMethod]
        public void Methods6_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass6.testMethod());
        }

        [TestMethod]
        public void Methods7_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass7.testMethod());
        }

        [TestMethod]
        public void Methods9_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass9.testMethod());
        }

        [TestMethod]
        public void Methods10_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass10.testMethod());
        }

        [TestMethod]
        public void Methods11_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsFalse(MethodsTestClass11.testMethod());
            OutputHelper.WriteLine("This failure indicates a test is now passing that previously failed by design.");
            OutputHelper.WriteLine("It previously marked as known failure because of bug # 21563");
            OutputHelper.WriteLine("The Test owner needs to verify that the change was intentional and remove the known failure.");

        }

        [TestMethod]
        public void Methods13_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass13.testMethod());
        }

        [TestMethod]
        public void Methods17_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass17.testMethod());
        }

        [TestMethod]
        public void Methods19_Test()
        {
            OutputHelper.WriteLine(" The return-type of a method declaration specifies");
            OutputHelper.WriteLine(" the type of the value computed and returned by the");
            OutputHelper.WriteLine(" method. The return type is void if the method does");
            OutputHelper.WriteLine(" not return a value.");
            Assert.IsTrue(MethodsTestClass19.testMethod());
        }

        [TestMethod]
        public void Methods20_Test()
        {
            OutputHelper.WriteLine(" The return-type of a method declaration specifies");
            OutputHelper.WriteLine(" the type of the value computed and returned by the");
            OutputHelper.WriteLine(" method. The return type is void if the method does");
            OutputHelper.WriteLine(" not return a value.");
            Assert.IsTrue(MethodsTestClass20.testMethod());
        }

        [TestMethod]
        public void Methods22_Test()
        {
            OutputHelper.WriteLine(" The return-type of a method declaration specifies");
            OutputHelper.WriteLine(" the type of the value computed and returned by the");
            OutputHelper.WriteLine(" method. The return type is void if the method does");
            OutputHelper.WriteLine(" not return a value.");
            Assert.IsTrue(MethodsTestClass22.testMethod());
        }

        [TestMethod]
        public void Methods23_Test()
        {
            OutputHelper.WriteLine(" The return-type of a method declaration specifies");
            OutputHelper.WriteLine(" the type of the value computed and returned by the");
            OutputHelper.WriteLine(" method. The return type is void if the method does");
            OutputHelper.WriteLine(" not return a value.");
            Assert.IsTrue(MethodsTestClass23.testMethod());
        }

        [TestMethod]
        public void Methods24_Test()
        {
            OutputHelper.WriteLine(" The return-type of a method declaration specifies");
            OutputHelper.WriteLine(" the type of the value computed and returned by the");
            OutputHelper.WriteLine(" method. The return type is void if the method does");
            OutputHelper.WriteLine(" not return a value.");
            Assert.IsTrue(MethodsTestClass24.testMethod());
        }

        [TestMethod]
        public void Methods25_Test()
        {
            OutputHelper.WriteLine(" The return-type of a method declaration specifies");
            OutputHelper.WriteLine(" the type of the value computed and returned by the");
            OutputHelper.WriteLine(" method. The return type is void if the method does");
            OutputHelper.WriteLine(" not return a value.");
            Assert.IsTrue(MethodsTestClass25.testMethod());
        }

        [TestMethod]
        public void Methods26_Test()
        {
            OutputHelper.WriteLine(" The return-type of a method declaration specifies");
            OutputHelper.WriteLine(" the type of the value computed and returned by the");
            OutputHelper.WriteLine(" method. The return type is void if the method does");
            OutputHelper.WriteLine(" not return a value.");
            Assert.IsTrue(MethodsTestClass26.testMethod());
        }

        [TestMethod]
        public void Methods29_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" The member-name specifies the name of the method.");
            OutputHelper.WriteLine(" Unless the method is an explicit interface member");
            OutputHelper.WriteLine(" implementation, the member-name is simply an ");
            OutputHelper.WriteLine(" identifier.  For an explicit interface member ");
            OutputHelper.WriteLine(" implementation, the member-name consists of an");
            OutputHelper.WriteLine(" interface-type followed by a . and an identifier.");
            Assert.IsTrue(MethodsTestClass29.testMethod());
        }

        [TestMethod]
        public void Methods30_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" The member-name specifies the name of the method.");
            OutputHelper.WriteLine(" Unless the method is an explicit interface member");
            OutputHelper.WriteLine(" implementation, the member-name is simply an ");
            OutputHelper.WriteLine(" identifier.  For an explicit interface member ");
            OutputHelper.WriteLine(" implementation, the member-name consists of an");
            OutputHelper.WriteLine(" interface-type followed by a . and an identifier.");
            Assert.IsTrue(MethodsTestClass30.testMethod());
        }

        [TestMethod]
        public void Methods33_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" The optional formal-parameter-list specifies");
            OutputHelper.WriteLine(" the parameters of the method.");
            Assert.IsTrue(MethodsTestClass33.testMethod());
        }

        [TestMethod]
        public void Methods34_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" The optional formal-parameter-list specifies");
            OutputHelper.WriteLine(" the parameters of the method.");
            Assert.IsTrue(MethodsTestClass34.testMethod());
        }

        [TestMethod]
        public void Methods35_Test()
        {
            OutputHelper.WriteLine("Testing method call with 10 parameters");
            Assert.IsTrue(MethodsTestClass35.testMethod());
        }

        [TestMethod]
        public void Methods56_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method declaration creates a separate space");
            OutputHelper.WriteLine(" for parameters and local variables.  Names are introduced");
            OutputHelper.WriteLine(" into this declaration space by the formal parameter");
            OutputHelper.WriteLine(" list of the method and by the local variable declarations");
            OutputHelper.WriteLine(" in the block of the method.  All names in the declaration");
            OutputHelper.WriteLine(" space of a method must be unique.  Thus it is an error");
            OutputHelper.WriteLine(" for a parameter or local variable to have the same name");
            OutputHelper.WriteLine(" as another parameter or local variable.");
            Assert.IsTrue(MethodsTestClass56.testMethod());
        }

        [TestMethod]
        public void Methods57_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method declaration creates a separate space");
            OutputHelper.WriteLine(" for parameters and local variables.  Names are introduced");
            OutputHelper.WriteLine(" into this declaration space by the formal parameter");
            OutputHelper.WriteLine(" list of the method and by the local variable declarations");
            OutputHelper.WriteLine(" in the block of the method.  All names in the declaration");
            OutputHelper.WriteLine(" space of a method must be unique.  Thus it is an error");
            OutputHelper.WriteLine(" for a parameter or local variable to have the same name");
            OutputHelper.WriteLine(" as another parameter or local variable.");
            Assert.IsTrue(MethodsTestClass57.testMethod());
        }

        [TestMethod]
        public void Methods58_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When a formal parameter is a value parameter,");
            OutputHelper.WriteLine(" the corresponding argument in the method invocation");
            OutputHelper.WriteLine(" must be an expression of a type that is implicitly");
            OutputHelper.WriteLine(" convertible to the formal parameter type.");
            Assert.IsTrue(MethodsTestClass58.testMethod());
        }

        [TestMethod]
        public void Methods59_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When a formal parameter is a value parameter,");
            OutputHelper.WriteLine(" the corresponding argument in the method invocation");
            OutputHelper.WriteLine(" must be an expression of a type that is implicitly");
            OutputHelper.WriteLine(" convertible to the formal parameter type.");
            Assert.IsTrue(MethodsTestClass59.testMethod());
        }

        [TestMethod]
        public void Methods60_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When a formal parameter is a value parameter,");
            OutputHelper.WriteLine(" the corresponding argument in the method invocation");
            OutputHelper.WriteLine(" must be an expression of a type that is implicitly");
            OutputHelper.WriteLine(" convertible to the formal parameter type.");
            Assert.IsTrue(MethodsTestClass60.testMethod());
        }

        [TestMethod]
        public void Methods61_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When a formal parameter is a value parameter,");
            OutputHelper.WriteLine(" the corresponding argument in the method invocation");
            OutputHelper.WriteLine(" must be an expression of a type that is implicitly");
            OutputHelper.WriteLine(" convertible to the formal parameter type.");
            Assert.IsTrue(MethodsTestClass61.testMethod());
        }

        [TestMethod]
        public void Methods66_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method is permitted to assign new values to ");
            OutputHelper.WriteLine(" a value parameter.  Such assignments only affect");
            OutputHelper.WriteLine(" the local storage location represented by the ");
            OutputHelper.WriteLine(" value parameter--they have no effect on the actual ");
            OutputHelper.WriteLine(" argument given in the method invocation.");
            Assert.IsTrue(MethodsTestClass66.testMethod());
        }

        [TestMethod]
        public void Methods67_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method is permitted to assign new values to ");
            OutputHelper.WriteLine(" a value parameter.  Such assignments only affect");
            OutputHelper.WriteLine(" the local storage location represented by the ");
            OutputHelper.WriteLine(" value parameter--they have no effect on the actual ");
            OutputHelper.WriteLine(" argument given in the method invocation.");
            Assert.IsTrue(MethodsTestClass67.testMethod());
        }

        [TestMethod]
        public void Methods68_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method is permitted to assign new values to ");
            OutputHelper.WriteLine(" a value parameter.  Such assignments only affect");
            OutputHelper.WriteLine(" the local storage location represented by the ");
            OutputHelper.WriteLine(" value parameter--they have no effect on the actual ");
            OutputHelper.WriteLine(" argument given in the method invocation.");
            Assert.IsTrue(MethodsTestClass68.testMethod());
        }

        [TestMethod]
        public void Methods69_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A parameter declared with a ref modifier is a ");
            OutputHelper.WriteLine(" reference parameter.  Unlike a value parameter,");
            OutputHelper.WriteLine(" a reference parameter does not create a new ");
            OutputHelper.WriteLine(" storage location.  Instead, a reference parameter");
            OutputHelper.WriteLine(" represents the same storage location as the");
            OutputHelper.WriteLine(" variable given as the argument in the method");
            OutputHelper.WriteLine(" invocation.");
            Assert.IsTrue(MethodsTestClass69.testMethod());
        }

        [TestMethod]
        public void Methods70_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A parameter declared with a ref modifier is a ");
            OutputHelper.WriteLine(" reference parameter.  Unlike a value parameter,");
            OutputHelper.WriteLine(" a reference parameter does not create a new ");
            OutputHelper.WriteLine(" storage location.  Instead, a reference parameter");
            OutputHelper.WriteLine(" represents the same storage location as the");
            OutputHelper.WriteLine(" variable given as the argument in the method");
            OutputHelper.WriteLine(" invocation.");
            Assert.IsTrue(MethodsTestClass70.testMethod());
        }

        [TestMethod]
        public void Methods71_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A parameter declared with a ref modifier is a ");
            OutputHelper.WriteLine(" reference parameter.  Unlike a value parameter,");
            OutputHelper.WriteLine(" a reference parameter does not create a new ");
            OutputHelper.WriteLine(" storage location.  Instead, a reference parameter");
            OutputHelper.WriteLine(" represents the same storage location as the");
            OutputHelper.WriteLine(" variable given as the argument in the method");
            OutputHelper.WriteLine(" invocation.");
            Assert.IsTrue(MethodsTestClass71.testMethod());
        }

        [TestMethod]
        public void Methods75_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When a formal parameter is a reference parameter,");
            OutputHelper.WriteLine(" the corresponding argument in a method invocation");
            OutputHelper.WriteLine(" must consist of the keyword ref followed by a ");
            OutputHelper.WriteLine(" variable-reference of the same type as the formal");
            OutputHelper.WriteLine(" parameter.  A variable must be definitely assigned");
            OutputHelper.WriteLine(" before it can be passed as a reference parameter.");
            Assert.IsTrue(MethodsTestClass75.testMethod());
        }

        [TestMethod]
        public void Methods78_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A parameter declared with an out modifier is an output");
            OutputHelper.WriteLine(" parameter.  Similar to a reference parameter, an output");
            OutputHelper.WriteLine(" parameter does not create a new storage location.  Instead,");
            OutputHelper.WriteLine(" an output parameter represents the same storage location");
            OutputHelper.WriteLine(" as the variable given as the argument in the method invocation.");
            Assert.IsTrue(MethodsTestClass78.testMethod());
        }

        [TestMethod]
        public void Methods79_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A parameter declared with an out modifier is an output");
            OutputHelper.WriteLine(" parameter.  Similar to a reference parameter, an output");
            OutputHelper.WriteLine(" parameter does not create a new storage location.  Instead,");
            OutputHelper.WriteLine(" an output parameter represents the same storage location");
            OutputHelper.WriteLine(" as the variable given as the argument in the method invocation.");
            Assert.IsTrue(MethodsTestClass79.testMethod());
        }

        [TestMethod]
        public void Methods80_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A parameter declared with an out modifier is an output");
            OutputHelper.WriteLine(" parameter.  Similar to a reference parameter, an output");
            OutputHelper.WriteLine(" parameter does not create a new storage location.  Instead,");
            OutputHelper.WriteLine(" an output parameter represents the same storage location");
            OutputHelper.WriteLine(" as the variable given as the argument in the method invocation.");
            Assert.IsTrue(MethodsTestClass80.testMethod());
        }

        [TestMethod]
        public void Methods84_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When a formal parameter is an output parameter,");
            OutputHelper.WriteLine(" the corresponding argument in a method invocation");
            OutputHelper.WriteLine(" must consist of the keyword out followed by a ");
            OutputHelper.WriteLine(" variable-reference of the same type as the formal ");
            OutputHelper.WriteLine(" parameter.  A variable need not be definitely");
            OutputHelper.WriteLine(" assigned before it can be passed as an output");
            OutputHelper.WriteLine(" parameter, but following an invocation where a ");
            OutputHelper.WriteLine(" variable was passed as an output parameter, the");
            OutputHelper.WriteLine(" variable is considered definitely assigned.");
            Assert.IsTrue(MethodsTestClass84.testMethod());
        }

        [TestMethod]
        public void Methods85_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When a formal parameter is an output parameter,");
            OutputHelper.WriteLine(" the corresponding argument in a method invocation");
            OutputHelper.WriteLine(" must consist of the keyword out followed by a ");
            OutputHelper.WriteLine(" variable-reference of the same type as the formal ");
            OutputHelper.WriteLine(" parameter.  A variable need not be definitely");
            OutputHelper.WriteLine(" assigned before it can be passed as an output");
            OutputHelper.WriteLine(" parameter, but following an invocation where a ");
            OutputHelper.WriteLine(" variable was passed as an output parameter, the");
            OutputHelper.WriteLine(" variable is considered definitely assigned.");
            Assert.IsTrue(MethodsTestClass85.testMethod());
        }

        [TestMethod]
        public void Methods92_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" Every output parameter of a method must be");
            OutputHelper.WriteLine(" definitely assigned before the method returns.");
            Assert.IsTrue(MethodsTestClass92.testMethod());
        }

        [TestMethod]
        public void Methods93_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" Every output parameter of a method must be");
            OutputHelper.WriteLine(" definitely assigned before the method returns.");
            Assert.IsTrue(MethodsTestClass93.testMethod());
        }

        [TestMethod]
        public void Methods94_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" Every output parameter of a method must be");
            OutputHelper.WriteLine(" definitely assigned before the method returns.");
            Assert.IsTrue(MethodsTestClass94.testMethod());
        }

        [TestMethod]
        public void Methods95_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" Every output parameter of a method must be");
            OutputHelper.WriteLine(" definitely assigned before the method returns.");
            Assert.IsTrue(MethodsTestClass95.testMethod());
        }

        [TestMethod]
        public void Methods103_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" The implementation of a non-virtual method");
            OutputHelper.WriteLine(" is invariant: The implementation is the same ");
            OutputHelper.WriteLine(" whether the method is invoked on an instance");
            OutputHelper.WriteLine(" of the class in which it is declared or an ");
            OutputHelper.WriteLine(" instance of the derived class.");
            Assert.IsTrue(MethodsTestClass103.testMethod());

        }

        [TestMethod]
        public void Methods104_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" The implementation of a non-virtual method");
            OutputHelper.WriteLine(" is invariant: The implementation is the same ");
            OutputHelper.WriteLine(" whether the method is invoked on an instance");
            OutputHelper.WriteLine(" of the class in which it is declared or an ");
            OutputHelper.WriteLine(" instance of the derived class.");
            Assert.IsFalse(MethodsTestClass104.testMethod());

            OutputHelper.WriteLine("This failure indicates a test is now passing that previously failed by design.");
            OutputHelper.WriteLine("It previously marked as known failure because of bug # 21563");
            OutputHelper.WriteLine("The Test owner needs to verify that the change was intentional and remove the known failure.");


        }

        [TestMethod]
        public void Methods105_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" The implementation of a non-virtual method");
            OutputHelper.WriteLine(" is invariant: The implementation is the same ");
            OutputHelper.WriteLine(" whether the method is invoked on an instance");
            OutputHelper.WriteLine(" of the class in which it is declared or an ");
            OutputHelper.WriteLine(" instance of the derived class.");
            Assert.IsTrue(MethodsTestClass105.testMethod());
        }

        [TestMethod]
        public void Methods106_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" For every virtual method declaration of M,");
            OutputHelper.WriteLine(" there exists a most derived implementation");
            OutputHelper.WriteLine(" of the method with respect to the class.");
            OutputHelper.WriteLine(" The most derived implementation of a ");
            OutputHelper.WriteLine(" virtual method M with respectto a class");
            OutputHelper.WriteLine(" R is determined as follows:");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" If R contains the introducing virtual");
            OutputHelper.WriteLine(" declaration of M, then this is the most");
            OutputHelper.WriteLine(" derived implementation of M.");
            Assert.IsTrue(MethodsTestClass106.testMethod());
        }

        [TestMethod]
        public void Methods107_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" For every virtual method declaration of M,");
            OutputHelper.WriteLine(" there exists a most derived implementation");
            OutputHelper.WriteLine(" of the method with respect to the class.");
            OutputHelper.WriteLine(" The most derived implementation of a ");
            OutputHelper.WriteLine(" virtual method M with respectto a class");
            OutputHelper.WriteLine(" R is determined as follows:");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" If R contains the introducing virtual");
            OutputHelper.WriteLine(" declaration of M, then this is the most");
            OutputHelper.WriteLine(" derived implementation of M.");
            Assert.IsFalse(MethodsTestClass107.testMethod());
            OutputHelper.WriteLine("This failure indicates a test is now passing that previously failed by design.");
            OutputHelper.WriteLine("It previously marked as known failure because of bug # 21563");
            OutputHelper.WriteLine("The Test owner needs to verify that the change was intentional and remove the known failure.");
        }

        [TestMethod]
        public void Methods108_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" For every virtual method declaration of M,");
            OutputHelper.WriteLine(" there exists a most derived implementation");
            OutputHelper.WriteLine(" of the method with respect to the class.");
            OutputHelper.WriteLine(" The most derived implementation of a ");
            OutputHelper.WriteLine(" virtual method M with respectto a class");
            OutputHelper.WriteLine(" R is determined as follows:");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" If R contains the introducing virtual");
            OutputHelper.WriteLine(" declaration of M, then this is the most");
            OutputHelper.WriteLine(" derived implementation of M.");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" Otherwise, if R contains an override of M,");
            OutputHelper.WriteLine(" then this is the most derived implementation");
            OutputHelper.WriteLine(" of M.");
            Assert.IsTrue(MethodsTestClass108.testMethod());
        }

        [TestMethod]
        public void Methods109_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" For every virtual method declaration of M,");
            OutputHelper.WriteLine(" there exists a most derived implementation");
            OutputHelper.WriteLine(" of the method with respect to the class.");
            OutputHelper.WriteLine(" The most derived implementation of a ");
            OutputHelper.WriteLine(" virtual method M with respectto a class");
            OutputHelper.WriteLine(" R is determined as follows:");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" If R contains the introducing virtual");
            OutputHelper.WriteLine(" declaration of M, then this is the most");
            OutputHelper.WriteLine(" derived implementation of M.");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" Otherwise, if R contains an override of M,");
            OutputHelper.WriteLine(" then this is the most derived implementation");
            OutputHelper.WriteLine(" of M.");
            Assert.IsTrue(MethodsTestClass109.testMethod());
        }

        [TestMethod]
        public void Methods110_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" For every virtual method declaration of M,");
            OutputHelper.WriteLine(" there exists a most derived implementation");
            OutputHelper.WriteLine(" of the method with respect to the class.");
            OutputHelper.WriteLine(" The most derived implementation of a ");
            OutputHelper.WriteLine(" virtual method M with respectto a class");
            OutputHelper.WriteLine(" R is determined as follows:");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" If R contains the introducing virtual");
            OutputHelper.WriteLine(" declaration of M, then this is the most");
            OutputHelper.WriteLine(" derived implementation of M.");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" Otherwise, if R contains an override of M,");
            OutputHelper.WriteLine(" then this is the most derived implementation");
            OutputHelper.WriteLine(" of M.");
            Assert.IsFalse(MethodsTestClass110.testMethod());
            OutputHelper.WriteLine("This failure indicates a test is now passing that previously failed by design.");
            OutputHelper.WriteLine("It previously marked as known failure because of bug # 21563");
            OutputHelper.WriteLine("The Test owner needs to verify that the change was intentional and remove the known failure.");
        }

        [TestMethod]
        public void Methods111_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" For every virtual method declaration of M,");
            OutputHelper.WriteLine(" there exists a most derived implementation");
            OutputHelper.WriteLine(" of the method with respect to the class.");
            OutputHelper.WriteLine(" The most derived implementation of a ");
            OutputHelper.WriteLine(" virtual method M with respectto a class");
            OutputHelper.WriteLine(" R is determined as follows:");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" If R contains the introducing virtual");
            OutputHelper.WriteLine(" declaration of M, then this is the most");
            OutputHelper.WriteLine(" derived implementation of M.");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" Otherwise, if R contains an override of M,");
            OutputHelper.WriteLine(" then this is the most derived implementation");
            OutputHelper.WriteLine(" of M.");
            Assert.IsTrue(MethodsTestClass111.testMethod());
        }

        [TestMethod]
        public void Methods112_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" Because methods are allowed to hide inherited");
            OutputHelper.WriteLine(" methods, it is possible for a class to contain");
            OutputHelper.WriteLine(" several virtual methods with the same signature.");
            OutputHelper.WriteLine(" This does not provide an ambiguity problem, since");
            OutputHelper.WriteLine(" all but the most derived method are hidden.");
            Assert.IsFalse(MethodsTestClass112.testMethod());
            OutputHelper.WriteLine("This failure indicates a test is now passing that previously failed by design.");
            OutputHelper.WriteLine("It previously marked as known failure because of bug # 21563");
            OutputHelper.WriteLine("The Test owner needs to verify that the change was intentional and remove the known failure.");
        }

        [TestMethod]
        public void Methods116_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" It is an error for an override method declaration");
            OutputHelper.WriteLine(" to include any one of the new, static, virtual, or ");
            OutputHelper.WriteLine(" abstract modifiers.");
            Assert.IsTrue(MethodsTestClass116.testMethod());
        }

        [TestMethod]
        public void Methods117_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" For purposes of locating the overridden base");
            OutputHelper.WriteLine(" method, a method is considered accessible if ");
            OutputHelper.WriteLine(" it is public, if it is protected, if it is ");
            OutputHelper.WriteLine(" internal and declared in the same project as ");
            OutputHelper.WriteLine(" C, or if it is private and declared in a class");
            OutputHelper.WriteLine(" containing the declaration of C.");
            Assert.IsTrue(MethodsTestClass117.testMethod());
        }

        [TestMethod]
        public void Methods119_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" For purposes of locating the overridden base");
            OutputHelper.WriteLine(" method, a method is considered accessible if ");
            OutputHelper.WriteLine(" it is public, if it is protected, if it is ");
            OutputHelper.WriteLine(" internal and declared in the same project as ");
            OutputHelper.WriteLine(" C, or if it is private and declared in a class");
            OutputHelper.WriteLine(" containing the declaration of C.");
            Assert.IsTrue(MethodsTestClass119.testMethod());
        }

        [TestMethod]
        public void Methods120_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" For purposes of locating the overridden base");
            OutputHelper.WriteLine(" method, a method is considered accessible if ");
            OutputHelper.WriteLine(" it is public, if it is protected, if it is ");
            OutputHelper.WriteLine(" internal and declared in the same project as ");
            OutputHelper.WriteLine(" C, or if it is private and declared in a class");
            OutputHelper.WriteLine(" containing the declaration of C.");
            Assert.IsTrue(MethodsTestClass120.testMethod());
        }

        [TestMethod]
        public void Methods121_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" For purposes of locating the overridden base");
            OutputHelper.WriteLine(" method, a method is considered accessible if ");
            OutputHelper.WriteLine(" it is public, if it is protected, if it is ");
            OutputHelper.WriteLine(" internal and declared in the same project as ");
            OutputHelper.WriteLine(" C, or if it is private and declared in a class");
            OutputHelper.WriteLine(" containing the declaration of C.");
            Assert.IsTrue(MethodsTestClass121.testMethod());
        }

        [TestMethod]
        public void Methods124_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A compile time-error occurs unless all");
            OutputHelper.WriteLine(" of the following are true for an override");
            OutputHelper.WriteLine(" declaration:");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" An overriddden base method can be located");
            OutputHelper.WriteLine(" as described above.");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" The overridden base method is virtual,");
            OutputHelper.WriteLine(" abstract, or override method.  In other");
            OutputHelper.WriteLine(" words, the overridden base method cannot");
            OutputHelper.WriteLine(" be static or non-virtual.");
            Assert.IsTrue(MethodsTestClass124.testMethod());
        }

        [TestMethod]
        public void Methods125_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A compile time-error occurs unless all");
            OutputHelper.WriteLine(" of the following are true for an override");
            OutputHelper.WriteLine(" declaration:");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" An overriddden base method can be located");
            OutputHelper.WriteLine(" as described above.");
            OutputHelper.WriteLine("");
            OutputHelper.WriteLine(" The overridden base method is virtual,");
            OutputHelper.WriteLine(" abstract, or override method.  In other");
            OutputHelper.WriteLine(" words, the overridden base method cannot");
            OutputHelper.WriteLine(" be static or non-virtual.");
            Assert.IsTrue(MethodsTestClass125.testMethod());
        }

        [TestMethod]
        public void Methods132_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" An override declaration can access the overridden ");
            OutputHelper.WriteLine(" base method using a base-access.");
            Assert.IsTrue(MethodsTestClass132.testMethod());
        }

        [TestMethod]
        public void Methods133_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" An override declaration can access the overridden ");
            OutputHelper.WriteLine(" base method using a base-access.");
            Assert.IsTrue(MethodsTestClass133.testMethod());
        }

        [TestMethod]
        public void Methods134_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" Only by including an override modifier can");
            OutputHelper.WriteLine(" a method override another method.  In all other");
            OutputHelper.WriteLine(" cases, a method with the same signature as an");
            OutputHelper.WriteLine(" inherited method simply hides the inherited ");
            OutputHelper.WriteLine(" member.");
            Assert.IsFalse(MethodsTestClass134.testMethod());
                OutputHelper.WriteLine("This failure indicates a test is now passing that previously failed by design.");
                OutputHelper.WriteLine("It previously marked as known failure because of bug # 21563");
                OutputHelper.WriteLine("The Test owner needs to verify that the change was intentional and remove the known failure."); 
        }

        [TestMethod]
        public void Methods142_Test()
        {
            Assert.IsTrue(MethodsTestClass142.testMethod());
        }

        [TestMethod]
        public void Methods148_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" If execution of the method body of a void");
            OutputHelper.WriteLine(" method completes normally (that is, if control");
            OutputHelper.WriteLine(" flows off the end of the method body), the ");
            OutputHelper.WriteLine(" method simply returns to the caller.");
            Assert.IsTrue(MethodsTestClass148.testMethod());
        }

        [TestMethod]
        public void Methods149_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When the return type of a method is not void,");
            OutputHelper.WriteLine(" each return statement in the method body must");
            OutputHelper.WriteLine(" specify an expression of a type that is implicitly");
            OutputHelper.WriteLine(" covertable to the return type.");
            Assert.IsTrue(MethodsTestClass149.testMethod());
        }

        [TestMethod]
        public void Methods150_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When the return type of a method is not void,");
            OutputHelper.WriteLine(" each return statement in the method body must");
            OutputHelper.WriteLine(" specify an expression of a type that is implicitly");
            OutputHelper.WriteLine(" covertable to the return type.");
            Assert.IsTrue(MethodsTestClass150.testMethod());
        }

        [TestMethod]
        public void Methods154_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When the return type of a method is not void,");
            OutputHelper.WriteLine(" each return statement in the method body must");
            OutputHelper.WriteLine(" specify an expression of a type that is implicitly");
            OutputHelper.WriteLine(" covertable to the return type.");
            Assert.IsTrue(MethodsTestClass154.testMethod());
        }

        [TestMethod]
        public void Methods159_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When the return type of a method is not void,");
            OutputHelper.WriteLine(" each return statement in the method body must");
            OutputHelper.WriteLine(" specify an expression of a type that is implicitly");
            OutputHelper.WriteLine(" covertable to the return type.  Execution of the ");
            OutputHelper.WriteLine(" method body of a value returning method is required");
            OutputHelper.WriteLine(" to terminate in a return statement that specifies");
            OutputHelper.WriteLine(" an expression or in a throw statement that throws");
            OutputHelper.WriteLine(" an System.Exception.");
            Assert.IsTrue(MethodsTestClass159.testMethod());
        }

        [TestMethod]
        public void Methods160_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When the return type of a method is not void,");
            OutputHelper.WriteLine(" each return statement in the method body must");
            OutputHelper.WriteLine(" specify an expression of a type that is implicitly");
            OutputHelper.WriteLine(" covertable to the return type.  Execution of the ");
            OutputHelper.WriteLine(" method body of a value returning method is required");
            OutputHelper.WriteLine(" to terminate in a return statement that specifies");
            OutputHelper.WriteLine(" an expression or in a throw statement that throws");
            OutputHelper.WriteLine(" an System.Exception.");
            Assert.IsTrue(MethodsTestClass160.testMethod());
        }

        [TestMethod]
        public void Methods161_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" When the return type of a method is not void,");
            OutputHelper.WriteLine(" each return statement in the method body must");
            OutputHelper.WriteLine(" specify an expression of a type that is implicitly");
            OutputHelper.WriteLine(" covertable to the return type.  Execution of the ");
            OutputHelper.WriteLine(" method body of a value returning method is required");
            OutputHelper.WriteLine(" to terminate in a return statement that specifies");
            OutputHelper.WriteLine(" an expression or in a throw statement that throws");
            OutputHelper.WriteLine(" an System.Exception.");
            Assert.IsTrue(MethodsTestClass161.testMethod());
        }

        [TestMethod]
        public void Methods163_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A parameter declared with a params modifier is");
            OutputHelper.WriteLine(" a params parameter. A params parameter must be");
            OutputHelper.WriteLine(" the last parameter in the formal parameter list,");
            OutputHelper.WriteLine(" and the type of a params parameter must be a ");
            OutputHelper.WriteLine(" single-dimension array type. For example, the");
            OutputHelper.WriteLine(" types int[] and int[][] can be used as the type of");
            OutputHelper.WriteLine(" a params parameter, but the type int[,] cannot be");
            OutputHelper.WriteLine(" used in this way.");
            Assert.IsTrue(MethodsTestClass163.testMethod());
        }

        [TestMethod]
        public void Methods164_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A parameter declared with a params modifier is");
            OutputHelper.WriteLine(" a params parameter. A params parameter must be");
            OutputHelper.WriteLine(" the last parameter in the formal parameter list,");
            OutputHelper.WriteLine(" and the type of a params parameter must be a ");
            OutputHelper.WriteLine(" single-dimension array type. For example, the");
            OutputHelper.WriteLine(" types int[] and int[][] can be used as the type of");
            OutputHelper.WriteLine(" a params parameter, but the type int[,] cannot be");
            OutputHelper.WriteLine(" used in this way.");
            Assert.IsTrue(MethodsTestClass164.testMethod());
        }

        [TestMethod]
        public void Methods169_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" The caller may specify an expression of a type that");
            OutputHelper.WriteLine(" is implicitly convertible to the formal parameter type.");
            OutputHelper.WriteLine(" In this case, the params parameter acts precisely like");
            OutputHelper.WriteLine(" a value parameter.");
            Assert.IsTrue(MethodsTestClass169.testMethod());
        }

        [TestMethod]
        public void Methods172_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" Alternately, the caller may specify zero or more expressions,");
            OutputHelper.WriteLine(" where the type of each expression is implicitly convertible");
            OutputHelper.WriteLine(" to the element type of the formal parameter type. In this case,");
            OutputHelper.WriteLine(" params parameter is initialized with an array fo the formal");
            OutputHelper.WriteLine(" parameter type that contains the value or values provided by");
            OutputHelper.WriteLine(" the caller.");
            Assert.IsTrue(MethodsTestClass172.testMethod());
        }

        [TestMethod]
        public void Methods173_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" Alternately, the caller may specify zero or more expressions,");
            OutputHelper.WriteLine(" where the type of each expression is implicitly convertible");
            OutputHelper.WriteLine(" to the element type of the formal parameter type. In this case,");
            OutputHelper.WriteLine(" params parameter is initialized with an array fo the formal");
            OutputHelper.WriteLine(" parameter type that contains the value or values provided by");
            OutputHelper.WriteLine(" the caller.");
            Assert.IsTrue(MethodsTestClass173.testMethod());
        }

        [TestMethod]
        public void Methods174_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" Alternately, the caller may specify zero or more expressions,");
            OutputHelper.WriteLine(" where the type of each expression is implicitly convertible");
            OutputHelper.WriteLine(" to the element type of the formal parameter type. In this case,");
            OutputHelper.WriteLine(" params parameter is initialized with an array fo the formal");
            OutputHelper.WriteLine(" parameter type that contains the value or values provided by");
            OutputHelper.WriteLine(" the caller.");
            Assert.IsTrue(MethodsTestClass174.testMethod());
        }

        [TestMethod]
        public void Methods175_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" Alternately, the caller may specify zero or more expressions,");
            OutputHelper.WriteLine(" where the type of each expression is implicitly convertible");
            OutputHelper.WriteLine(" to the element type of the formal parameter type. In this case,");
            OutputHelper.WriteLine(" params parameter is initialized with an array fo the formal");
            OutputHelper.WriteLine(" parameter type that contains the value or values provided by");
            OutputHelper.WriteLine(" the caller.");
            Assert.IsTrue(MethodsTestClass175.testMethod());
        }

        [TestMethod]
        public void Methods179_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" Alternately, the caller may specify zero or more expressions,");
            OutputHelper.WriteLine(" where the type of each expression is implicitly convertible");
            OutputHelper.WriteLine(" to the element type of the formal parameter type. In this case,");
            OutputHelper.WriteLine(" params parameter is initialized with an array fo the formal");
            OutputHelper.WriteLine(" parameter type that contains the value or values provided by");
            OutputHelper.WriteLine(" the caller.");
            Assert.IsTrue(MethodsTestClass179.testMethod());
        }

        [TestMethod]
        public void Methods180_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" Alternately, the caller may specify zero or more expressions,");
            OutputHelper.WriteLine(" where the type of each expression is implicitly convertible");
            OutputHelper.WriteLine(" to the element type of the formal parameter type. In this case,");
            OutputHelper.WriteLine(" params parameter is initialized with an array fo the formal");
            OutputHelper.WriteLine(" parameter type that contains the value or values provided by");
            OutputHelper.WriteLine(" the caller.");
            Assert.IsTrue(MethodsTestClass180.testMethod());
        }

        [TestMethod]
        public void Methods181_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" Alternately, the caller may specify zero or more expressions,");
            OutputHelper.WriteLine(" where the type of each expression is implicitly convertible");
            OutputHelper.WriteLine(" to the element type of the formal parameter type. In this case,");
            OutputHelper.WriteLine(" params parameter is initialized with an array fo the formal");
            OutputHelper.WriteLine(" parameter type that contains the value or values provided by");
            OutputHelper.WriteLine(" the caller.");
            Assert.IsTrue(MethodsTestClass181.testMethod());
        }

        [TestMethod]
        public void Methods182_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" Alternately, the caller may specify zero or more expressions,");
            OutputHelper.WriteLine(" where the type of each expression is implicitly convertible");
            OutputHelper.WriteLine(" to the element type of the formal parameter type. In this case,");
            OutputHelper.WriteLine(" params parameter is initialized with an array fo the formal");
            OutputHelper.WriteLine(" parameter type that contains the value or values provided by");
            OutputHelper.WriteLine(" the caller.");
            Assert.IsTrue(MethodsTestClass182.testMethod());
        }

        [TestMethod]
        public void Methods183_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" Alternately, the caller may specify zero or more expressions,");
            OutputHelper.WriteLine(" where the type of each expression is implicitly convertible");
            OutputHelper.WriteLine(" to the element type of the formal parameter type. In this case,");
            OutputHelper.WriteLine(" params parameter is initialized with an array fo the formal");
            OutputHelper.WriteLine(" parameter type that contains the value or values provided by");
            OutputHelper.WriteLine(" the caller.");
            Assert.IsTrue(MethodsTestClass183.testMethod());
        }

        [TestMethod]
        public void Methods184_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter enables a caller to supply values");
            OutputHelper.WriteLine(" in one of two ways.");
            OutputHelper.WriteLine(" Alternately, the caller may specify zero or more expressions,");
            OutputHelper.WriteLine(" where the type of each expression is implicitly convertible");
            OutputHelper.WriteLine(" to the element type of the formal parameter type. In this case,");
            OutputHelper.WriteLine(" params parameter is initialized with an array fo the formal");
            OutputHelper.WriteLine(" parameter type that contains the value or values provided by");
            OutputHelper.WriteLine(" the caller.");
            Assert.IsTrue(MethodsTestClass184.testMethod());
        }

        [TestMethod]
        public void Methods185_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method is permitted to assign new values");
            OutputHelper.WriteLine(" to a params parameter. Such assignments only");
            OutputHelper.WriteLine(" affect the local storage location represented");
            OutputHelper.WriteLine(" by the params parameter.");
            Assert.IsTrue(MethodsTestClass185.testMethod());
        }

        [TestMethod]
        public void Methods186_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter can be passed along to another");
            OutputHelper.WriteLine(" params parameter.");
            Assert.IsTrue(MethodsTestClass186.testMethod());
        }

        [TestMethod]
        public void Methods187_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A params parameter can be passed along to another");
            OutputHelper.WriteLine(" params parameter.");
            Assert.IsTrue(MethodsTestClass187.testMethod());
        }

        [TestMethod]
        public void Methods188_Test()
        {
            OutputHelper.WriteLine("Testing explicit base method call to a child class whose parent implements");
            Assert.IsTrue(MethodsTestClass188.testMethod());
        }

        [TestMethod]
        public void Methods190_Test()
        {
            OutputHelper.WriteLine("Testing implicit base method calls to protected methods in parent class");
            Assert.IsTrue(MethodsTestClass190.testMethod());
        }

        [TestMethod]
        public void Methods191_Test()
        {
            OutputHelper.WriteLine("Testing implicit base method calls to internal methods in parent class");
            Assert.IsTrue(MethodsTestClass191.testMethod());
        }

        [TestMethod]
        public void Methods192_Test()
        {
            OutputHelper.WriteLine("Testing implicit base method calls to protected internal methods in parent class");
            Assert.IsTrue(MethodsTestClass192.testMethod());
        }

        [TestMethod]
        public void Methods193_Test()
        {
            OutputHelper.WriteLine("Testing implicit base method calls to private methods in parent class");
            Assert.IsTrue(MethodsTestClass193.testMethod());
        }

        [TestMethod]
        public void Methods194_Test()
        {
            OutputHelper.WriteLine("Testing implicit base method calls to public virtual methods in parent class");
            Assert.IsTrue(MethodsTestClass194.testMethod());
        }

        [TestMethod]
        public void Methods195_Test()
        {
            OutputHelper.WriteLine("Tests if a new method does not overwrite a virtual method in a base class");
            Assert.IsFalse(MethodsTestClass195.testMethod());
                OutputHelper.WriteLine("This failure indicates a test is now passing that previously failed by design.");
                OutputHelper.WriteLine("It previously marked as known failure because of bug # 21563");
                OutputHelper.WriteLine("The Test owner needs to verify that the change was intentional and remove the known failure."); 
        }

        [TestMethod]
        public void Methods196_Test()
        {
            OutputHelper.WriteLine("Tests if a new method does overwrite an abstract method in a base class");
            Assert.IsTrue(MethodsTestClass196.testMethod());
        }

        [TestMethod]
        public void Methods197_Test()
        {
            OutputHelper.WriteLine("Tests the calling of an empty delegate");
            Assert.IsTrue(MethodsTestClass197.testMethod());
        }

        [TestMethod]
        public void Methods199_Test()
        {
            OutputHelper.WriteLine("Tests if a sealed method overwrites a virtual method in a base class");
            Assert.IsTrue(MethodsTestClass199.testMethod());
        }

        [TestMethod]
        public void Methods200_Test()
        {
            OutputHelper.WriteLine("Tests large number of assignments inside a public method");
            Assert.IsTrue(MethodsTestClass200.testMethod());
        }

        [TestMethod]
        public void Methods201_Test()
        {
            OutputHelper.WriteLine("Tests large number of assignments inside a public static method");
            Assert.IsTrue(MethodsTestClass201.testMethod());
        }

        [TestMethod]
        public void Methods204_Test()
        {
            OutputHelper.WriteLine("Tests a method with explicit, params signature");
            Assert.IsTrue(MethodsTestClass204.testMethod());
        }

        [TestMethod]
        public void Methods205_Test()
        {
            OutputHelper.WriteLine("Tests a method with a mixed explicit and params signature");
            Assert.IsTrue(MethodsTestClass205.testMethod());
        }

        [TestMethod]
        public void Methods206_Test()
        {
            OutputHelper.WriteLine("Tests method overloading between params and explicit signatures (static)");
            Assert.IsTrue(MethodsTestClass206.testMethod());
        }

        [TestMethod]
        public void Methods207_Test()
        {
            OutputHelper.WriteLine("Tests method overloading between params and explicit signatures");
            Assert.IsTrue(MethodsTestClass207.testMethod());
        }

        [TestMethod]
        public void Methods210_Test()
        {
            OutputHelper.WriteLine(" Section 10.5 If the declaration includes the sealed modifier, then the ");
            OutputHelper.WriteLine(" declaration must also include the override modifier.");
            Assert.IsTrue(MethodsTestClass210.testMethod());
        }

        [TestMethod]
        public void Methods223_Test()
        {
            OutputHelper.WriteLine(" Section 10.5 The ref and out parameters are part of a method's signature, but the params modifier is not.");
            Assert.IsTrue(MethodsTestClass223.testMethod());
        }
        [TestMethod]
        public void Methods224_Test()
        {
            OutputHelper.WriteLine(" Section 10.5 The ref and out parameters are part of a method's signature, but the params modifier is not.");
            Assert.IsTrue(MethodsTestClass224.testMethod());
        }
        [TestMethod]
        public void Methods229_Test()
        {
            OutputHelper.WriteLine(" error CS0114: 'function1' hides inherited member 'function2'.");
            OutputHelper.WriteLine(" To make the current method override that implementation, add ");
            OutputHelper.WriteLine(" the override keyword. Otherwise add the new keyword.");
            Assert.IsTrue(MethodsTestClass229.testMethod());
        }
        [TestMethod]
        public void Methods230_Test()
        {
            OutputHelper.WriteLine(" error CS0114: 'function1' hides inherited member 'function2'.");
            OutputHelper.WriteLine(" To make the current method override that implementation, add ");
            OutputHelper.WriteLine(" the override keyword. Otherwise add the new keyword.");
            Assert.IsTrue(MethodsTestClass230.testMethod());
        }
        [TestMethod]
        public void Methods231_Test()
        {
            OutputHelper.WriteLine(" error CS0114: 'function1' hides inherited member 'function2'.");
            OutputHelper.WriteLine(" To make the current method override that implementation, add ");
            OutputHelper.WriteLine(" the override keyword. Otherwise add the new keyword.");
            Assert.IsTrue(MethodsTestClass231.testMethod());
        }
        [TestMethod]
        public void Methods232_Test()
        {
            OutputHelper.WriteLine(" error CS0114: 'function1' hides inherited member 'function2'.");
            OutputHelper.WriteLine(" To make the current method override that implementation, add ");
            OutputHelper.WriteLine(" the override keyword. Otherwise add the new keyword.");
            Assert.IsTrue(MethodsTestClass232.testMethod());
        }
        [TestMethod]
        public void Methods233_Test()
        {
            OutputHelper.WriteLine(" Section 10.5");
            OutputHelper.WriteLine(" A method-declaration may include set of attributes,");
            OutputHelper.WriteLine(" a new modifier, one of four access modifiers,");
            OutputHelper.WriteLine(" one of the static, virtual, override, or abstract ");
            OutputHelper.WriteLine(" modifiers, and an extern modifier.");
            Assert.IsTrue(MethodsTestClass233.testMethod());
        }

        public class MethodsTestClass_Base1
        {
            public static bool testMethod()
            {
                return false;
            }
        }

        public class MethodsTestClass1 : MethodsTestClass_Base1
        {
            //new modifier
            new public int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass1 test = new MethodsTestClass1();
                if (test.MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass2
        {
            //new modifier
            new public int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass2 test = new MethodsTestClass2();
                if (test.MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass3
        {
            //public modifier
            public int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass3 test = new MethodsTestClass3();
                if (test.MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Base4
        {
            //protected modifier
            protected int MyMeth()
            {
                return 2;
            }
        }
        public class MethodsTestClass4 : MethodsTestClass_Base4
        {
            public static bool testMethod()
            {
                MethodsTestClass4 test = new MethodsTestClass4();
                if (test.MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass6
        {
            //internal modifier
            internal int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass6 test = new MethodsTestClass6();
                if (test.MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass7
        {
            //private modifier
            private int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass7 test = new MethodsTestClass7();
                if (test.MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass9
        {
            //static modifier
            static int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                if (MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Base10
        {
            //virtual modifier
            public virtual int MyMeth()
            {
                return 1;
            }
        }

        public class MethodsTestClass10 : MethodsTestClass_Base10
        {
            //override modifier
            public override int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base10 test = new MethodsTestClass10();
                if (test.MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Base11
        {
            //virtual modifier
            public virtual int MyMeth()
            {
                return 1;
            }
        }
        public class MethodsTestClass11 : MethodsTestClass_Base11
        {
            //new modifier
            new int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base11 test = new MethodsTestClass11();
                if (test.MyMeth() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        abstract class MethodsTestClass_Base13
        {
            //abstract modifier
            public abstract int MyMeth();
        }
        class MethodsTestClass13 : MethodsTestClass_Base13
        {
            public override int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base13 test = new MethodsTestClass13();
                if (test.MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //public class Something
        //{
        //    //extern modifier
        //    extern public int MyMeth();
        //}
        public class MethodsTestClass17
        {
            public static bool testMethod()
            {
                return true;
            }
        }

        public class MethodsTestClass19
        {
            int intI = 1;
            //void return type
            void MyMeth()
            {
                intI = 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass19 test = new MethodsTestClass19();
                test.MyMeth();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass20
        {
            int intI = 1;
            //void return type
            void MyMeth()
            {
                intI = 2;
                return;
            }
            public static bool testMethod()
            {
                MethodsTestClass20 test = new MethodsTestClass20();
                test.MyMeth();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass22
        {
            //simple return type
            int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass22 test = new MethodsTestClass22();
                if (test.MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass23
        {
            //string return type
            string MyMeth()
            {
                return "MyMessage";
            }
            public static bool testMethod()
            {
                MethodsTestClass23 test = new MethodsTestClass23();
                if (test.MyMeth().Equals("MyMessage"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        struct MyStruct
        {
            public MyStruct(int intI)
            {
                intTest = intI;
            }
            public int intTest;
        }
        public class MethodsTestClass24
        {
            //struct return type
            MyStruct MyMeth()
            {
                return new MyStruct(3);
            }
            public static bool testMethod()
            {
                MethodsTestClass24 test = new MethodsTestClass24();
                if (test.MyMeth().intTest == 3)
                {
                    return true;
                }
                else
                {
                    OutputHelper.WriteLine(test.MyMeth().intTest.ToString());
                    return false;
                }
            }
        }
        enum MethodsTestClass26_Enum { a = 1, b = 2 }
        public class MethodsTestClass25
        {
            //enum return type
            MethodsTestClass26_Enum MyMeth()
            {
                return MethodsTestClass26_Enum.a;
            }
            public static bool testMethod()
            {
                MethodsTestClass25 test = new MethodsTestClass25();
                if (test.MyMeth() == MethodsTestClass26_Enum.a)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        class MethodsTestClass26_C
        {
            public MethodsTestClass26_C(int intI)
            {
                intTest = intI;
            }
            public int intTest;
        }
        public class MethodsTestClass26
        {
            //class return type
            MethodsTestClass26_C MyMeth()
            {
                return new MethodsTestClass26_C(3);
            }
            public static bool testMethod()
            {
                MethodsTestClass26 test = new MethodsTestClass26();
                if (test.MyMeth().intTest == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public interface MethodsTestClass29_Interface
        {
            int RetInt();
        }

        public class MethodsTestClass29 : MethodsTestClass29_Interface
        {

            int MethodsTestClass29_Interface.RetInt()
            {
                return 2;
            }

            public static bool testMethod()
            {
                try
                {
                    MethodsTestClass29_Interface test = new MethodsTestClass29();
                    if (test.RetInt() == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        public interface MethodsTestClass30_Interface
        {
            int RetInt();
        }
        public interface MethodsTestClass30_Interface2
        {
            int RetInt();
        }
        public class MethodsTestClass30 : MethodsTestClass30_Interface, MethodsTestClass30_Interface2
        {
            int MethodsTestClass30_Interface.RetInt()
            {
                return 2;
            }
            int MethodsTestClass30_Interface2.RetInt()
            {
                return 3;
            }
            public static bool testMethod()
            {
                try
                {
                    MethodsTestClass30_Interface test1 = new MethodsTestClass30();
                    MethodsTestClass30_Interface2 test2 = new MethodsTestClass30();
                    if ((test1.RetInt() == 2) && (test2.RetInt() == 3))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass33
        {
            //1 parameter
            int RetInt(int MyInt)
            {
                return MyInt;
            }
            public static bool testMethod()
            {
                MethodsTestClass33 test = new MethodsTestClass33();
                if (test.RetInt(3) == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass34
        {
            //2 parameters
            int RetInt(int MyInt1, int MyInt2)
            {
                return (MyInt1 + MyInt2);
            }
            public static bool testMethod()
            {
                MethodsTestClass34 test = new MethodsTestClass34();
                if (test.RetInt(3, 4) == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass35
        {
            //multiple parameters
            int RetInt(int MyInt1, int MyInt2, int MyInt3, int MyInt4, int MyInt5, int MyInt6, int MyInt7, int MyInt8, int MyInt9, int MyInt10)
            {
                return (MyInt1 + MyInt2 + MyInt3 + MyInt4 + MyInt5 + MyInt6 + MyInt7 + MyInt8 + MyInt9 + MyInt10);
            }
            public static bool testMethod()
            {
                MethodsTestClass35 test = new MethodsTestClass35();
                if (test.RetInt(2, 2, 2, 2, 2, 2, 2, 2, 2, 2) == 20)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass56
        {
            public int intI = 1;
            public int TestMeth(int intI)
            {
                return intI;
            }
            public static bool testMethod()
            {
                MethodsTestClass56 test = new MethodsTestClass56();
                if (test.TestMeth(2) == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass57
        {
            public int intI = 1;
            public int TestMeth()
            {
                int intI = 2;
                return intI;
            }
            public static bool testMethod()
            {
                MethodsTestClass57 test = new MethodsTestClass57();
                if (test.TestMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass58
        {
            public int TestMeth(int intI)
            {
                return intI;
            }
            public static bool testMethod()
            {
                short s = 2;
                MethodsTestClass58 test = new MethodsTestClass58();
                if (test.TestMeth(s) == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Base59
        {
            public int intI = 2;
        }
        public class MyDerived : MethodsTestClass_Base59 { }
        public class MethodsTestClass59
        {
            public int TestMeth(MethodsTestClass_Base59 tc)
            {
                return tc.intI;
            }
            public static bool testMethod()
            {
                MethodsTestClass59 test = new MethodsTestClass59();
                MyDerived md = new MyDerived();
                if (test.TestMeth(md) == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public interface MethodsTestClass_Interface60
        {
            int intRet();
        }
        public class MethodsTestClass_Derived60 : MethodsTestClass_Interface60
        {
            public int intRet()
            {
                return 2;
            }
        }
        public class MethodsTestClass60
        {
            public int TestMeth(MethodsTestClass_Interface60 ti)
            {
                return ti.intRet();
            }
            public static bool testMethod()
            {
                MethodsTestClass60 test = new MethodsTestClass60();
                MethodsTestClass_Derived60 md = new MethodsTestClass_Derived60();
                if (test.TestMeth(md) == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class C1
        {
            public int intI = 2;
        }
        public class C2
        {
            public static implicit operator C1(C2 MyC)
            {
                return new C1();
            }
        }
        public class MethodsTestClass61
        {
            public int TestMeth(C1 c)
            {
                return c.intI;
            }
            public static bool testMethod()
            {
                MethodsTestClass61 test = new MethodsTestClass61();
                C2 MyC2 = new C2();
                if (test.TestMeth(MyC2) == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass66
        {
            int int1;
            public void TestMeth(int intI)
            {
                intI = 3;
                int1 = intI;
            }
            public static bool testMethod()
            {
                int intJ = 2;
                MethodsTestClass66 test = new MethodsTestClass66();
                test.TestMeth(intJ);
                if ((test.int1 == 3) && (intJ == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass67
        {
            string strS;
            public void TestMeth(string s)
            {
                s = "string1";
                strS = s;
            }
            public static bool testMethod()
            {
                string strtest = "string0";
                MethodsTestClass67 test = new MethodsTestClass67();
                test.TestMeth(strtest);
                if ((test.strS.Equals("string1")) && (strtest.Equals("string0")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub68
        {
            public int testint;
            public MethodsTestClass_Sub68(int intI)
            {
                testint = intI;
            }
        }
        public class MethodsTestClass68
        {
            MethodsTestClass_Sub68 tc;
            public void TestMeth(MethodsTestClass_Sub68 t)
            {
                t = new MethodsTestClass_Sub68(3);
                tc = t;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Sub68 tc2 = new MethodsTestClass_Sub68(2);
                MethodsTestClass68 test = new MethodsTestClass68();
                test.TestMeth(tc2);
                if ((tc2.testint == 2) && (test.tc.testint == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass69
        {
            int int1;
            public void TestMeth(ref int intI)
            {
                intI = 3;
                int1 = intI;
            }
            public static bool testMethod()
            {
                int intJ = 2;
                MethodsTestClass69 test = new MethodsTestClass69();
                test.TestMeth(ref intJ);
                if ((test.int1 == 3) && (intJ == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass70
        {
            string strS;
            public void TestMeth(ref string s)
            {
                s = "string1";
                strS = s;
            }
            public static bool testMethod()
            {
                string strtest = "string0";
                MethodsTestClass70 test = new MethodsTestClass70();
                test.TestMeth(ref strtest);
                if ((test.strS.Equals("string1")) && (strtest.Equals("string1")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub71
        {
            public int testint;
            public MethodsTestClass_Sub71(int intI)
            {
                testint = intI;
            }
        }
        public class MethodsTestClass71
        {
            MethodsTestClass_Sub71 tc;
            public void TestMeth(ref MethodsTestClass_Sub71 t)
            {
                t = new MethodsTestClass_Sub71(3);
                tc = t;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Sub71 tc2 = new MethodsTestClass_Sub71(2);
                MethodsTestClass71 test = new MethodsTestClass71();
                test.TestMeth(ref tc2);
                if ((tc2.testint == 3) && (test.tc.testint == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        class MethodsTestClass_Base75 { }

        class MethodsTestClass_Derived75 : MethodsTestClass_Base75 { }
        public class MethodsTestClass75
        {
            int intI;
            public int TestMeth(ref int I1)
            {
                return I1;
            }
            public static bool testMethod()
            {
                MethodsTestClass75 test = new MethodsTestClass75();
                if (test.TestMeth(ref test.intI) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public class MethodsTestClass78
        {
            int int1;
            public void TestMeth(out int intI)
            {
                intI = 3;
                int1 = intI;
            }
            public static bool testMethod()
            {
                int intJ = 2;
                MethodsTestClass78 test = new MethodsTestClass78();
                test.TestMeth(out intJ);
                if ((test.int1 == 3) && (intJ == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass79
        {
            string strS;
            public void TestMeth(out string s)
            {
                s = "string1";
                strS = s;
            }
            public static bool testMethod()
            {
                string strtest = "string0";
                MethodsTestClass79 test = new MethodsTestClass79();
                test.TestMeth(out strtest);
                if ((test.strS.Equals("string1")) && (strtest.Equals("string1")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub80
        {
            public int testint;
            public MethodsTestClass_Sub80(int intI)
            {
                testint = intI;
            }
        }
        public class MethodsTestClass80
        {
            MethodsTestClass_Sub80 tc;
            public void TestMeth(out MethodsTestClass_Sub80 t)
            {
                t = new MethodsTestClass_Sub80(3);
                tc = t;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Sub80 tc2 = new MethodsTestClass_Sub80(2);
                MethodsTestClass80 test = new MethodsTestClass80();
                test.TestMeth(out tc2);
                if ((tc2.testint == 3) && (test.tc.testint == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass84
        {
            public void TestMeth(out int intI)
            {
                intI = 2;
            }
            public static bool testMethod()
            {
                int intJ;
                MethodsTestClass84 test = new MethodsTestClass84();
                test.TestMeth(out intJ);
                if (intJ == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub85
        {
            public int intI;
            public MethodsTestClass_Sub85(int intJ)
            {
                intI = intJ;
            }
        }
        public class MethodsTestClass85
        {
            public void TestMeth(out MethodsTestClass_Sub85 tc)
            {
                tc = new MethodsTestClass_Sub85(2);
            }
            public static bool testMethod()
            {
                MethodsTestClass_Sub85 tctest;
                MethodsTestClass85 test = new MethodsTestClass85();
                test.TestMeth(out tctest);
                if (tctest.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public class MethodsTestClass92
        {
            public void TestMeth(out int intI, out int intJ)
            {
                intI = 2;
                intJ = 3;
            }
            public static bool testMethod()
            {
                MethodsTestClass92 test = new MethodsTestClass92();
                int i1, i2;
                test.TestMeth(out i1, out i2);
                if ((i1 == 2) && (i2 == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass93
        {
            public void TestMeth(ref int intI, out int intJ)
            {
                intJ = 3;
            }
            public static bool testMethod()
            {
                MethodsTestClass93 test = new MethodsTestClass93();
                int i1 = 2;
                int i2;
                test.TestMeth(ref i1, out i2);
                if ((i1 == 2) && (i2 == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass94
        {
            public void TestMeth(int intI, out int intJ)
            {
                intI = 4;
                intJ = 3;
            }
            public static bool testMethod()
            {
                MethodsTestClass94 test = new MethodsTestClass94();
                int i1 = 2;
                int i2;
                test.TestMeth(i1, out i2);
                if ((i1 == 2) && (i2 == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass95
        {
            public void TestMeth(int intI, ref int intJ)
            {
                intI = 4;
                intJ = 3;
            }
            public static bool testMethod()
            {
                MethodsTestClass95 test = new MethodsTestClass95();
                int i1 = 2;
                int i2 = 5;
                test.TestMeth(i1, ref i2);
                if ((i1 == 2) && (i2 == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass103_Sub
        {
            public int Test()
            {
                return 2;
            }
        }
        public class MethodsTestClass103 : MethodsTestClass103_Sub
        {
            public int Test()
            {
                return 3;
            }
            public static bool testMethod()
            {
                MethodsTestClass103_Sub TC = new MethodsTestClass103();
                if (TC.Test() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub104
        {
            public virtual int Test()
            {
                return 102;
            }
        }
        public class MethodsTestClass104 : MethodsTestClass_Sub104
        {
            public new int Test()
            {
                return 103;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Sub104 TC = new MethodsTestClass104();
                if (TC.Test() == 102)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub105
        {
            public int Test()
            {
                return 102;
            }
        }
        public class MethodsTestClass105 : MethodsTestClass_Sub105
        {
            public new virtual int Test()
            {
                return 103;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Sub105 TC = new MethodsTestClass105();
                if (TC.Test() == 102)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass106
        {
            public virtual int Test()
            {
                return 103;
            }
            public static bool testMethod()
            {
                MethodsTestClass106 TC = new MethodsTestClass106();
                if (TC.Test() == 103)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub107
        {
            public virtual int Test()
            {
                return 102;
            }
        }
        public class MethodsTestClass107 : MethodsTestClass_Sub107
        {
            public new virtual int Test()
            {
                return 103;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Sub107 TC = new MethodsTestClass107();
                if (TC.Test() == 102)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub108
        {
            public virtual int Test()
            {
                return 102;
            }
        }
        public class MethodsTestClass108 : MethodsTestClass_Sub108
        {
            public override int Test()
            {
                return 103;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Sub108 TC = new MethodsTestClass108();
                if (TC.Test() == 103)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub109
        {
            public virtual int Test()
            {
                return 102;
            }
        }
        public class MethodsTestClass_Sub109_2 : MethodsTestClass_Sub109
        {
            public override int Test()
            {
                return 103;
            }
        }
        public class MethodsTestClass109 : MethodsTestClass_Sub109_2
        {
            public override int Test()
            {
                return 104;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Sub109 TC = new MethodsTestClass109();
                MethodsTestClass_Sub109_2 TC102 = new MethodsTestClass109();
                if ((TC.Test() == 104) && (TC.Test() == 104))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Compiled Test Cases 
        public class MethodsTestClass_Sub110
        {
            public virtual int Test()
            {
                return 2;
            }
        }
        public class MethodsTestClass_Sub1102 : MethodsTestClass_Sub110
        {
            new public virtual int Test()
            {
                return 3;
            }
        }
        public class MethodsTestClass110 : MethodsTestClass_Sub1102
        {
            public static bool testMethod()
            {
                MethodsTestClass_Sub110 TC = new MethodsTestClass110();
                MethodsTestClass_Sub1102 TC2 = new MethodsTestClass110();
                if ((TC.Test() == 2) && (TC2.Test() == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub111
        {
            public virtual int Test()
            {
                return 2;
            }
        }
        public class MethodsTestClass_Sub1112 : MethodsTestClass_Sub111
        {
            public override int Test()
            {
                return 3;
            }
        }
        public class MethodsTestClass111 : MethodsTestClass_Sub1112
        {
            public static bool testMethod()
            {
                MethodsTestClass_Sub111 TC = new MethodsTestClass111();
                MethodsTestClass_Sub1112 TC2 = new MethodsTestClass111();
                if ((TC.Test() == 3) && (TC.Test() == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub112A
        {
            public virtual int Test() { return 1; }
        }
        public class MethodsTestClass_Sub112B : MethodsTestClass_Sub112A
        {
            public override int Test() { return 2; }
        }
        public class MethodsTestClass_Sub112C : MethodsTestClass_Sub112B
        {
            public new virtual int Test() { return 3; }
        }
        public class MethodsTestClass_Sub112D : MethodsTestClass_Sub112C
        {
            public override int Test() { return 4; }
        }
        public class MethodsTestClass112 : MethodsTestClass_Sub112D
        {
            public static bool testMethod()
            {
                MethodsTestClass_Sub112D d = new MethodsTestClass_Sub112D();
                MethodsTestClass_Sub112A a = d;
                MethodsTestClass_Sub112B b = d;
                MethodsTestClass_Sub112C c = d;
                if ((d.Test() == 4) && (c.Test() == 4) && (b.Test() == 2) && (a.Test() == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Base116
        {
            public virtual void Test() { }
        }
        public abstract class MethodsTestClass_Base116_2 : MethodsTestClass_Base116
        {
            public override abstract void Test();
        }
        public class MethodsTestClass116 : MethodsTestClass_Base116_2
        {
            public override void Test() { }
            public static bool testMethod()
            {
                MethodsTestClass116 tc = new MethodsTestClass116();
                tc.Test();
                return true;
            }
        }
        public class MethodsTestClass_Base117
        {
            public virtual int Test()
            {
                return 1;
            }
        }
        public class MethodsTestClass117 : MethodsTestClass_Base117
        {
            public override int Test()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base117 BC = new MethodsTestClass117();
                if (BC.Test() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Base118
        {
            public int GetVal()
            {
                return Test();
            }
            protected virtual int Test()
            {
                return 1;
            }
        }
        public class MethodsTestClass118 : MethodsTestClass_Base118
        {
            protected override int Test()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base118 BC = new MethodsTestClass118();
                if (BC.GetVal() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Base119
        {
            public int GetVal()
            {
                return Test();
            }
            internal virtual int Test()
            {
                return 1;
            }
        }
        public class MethodsTestClass119 : MethodsTestClass_Base119
        {
            internal override int Test()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base119 BC = new MethodsTestClass119();
                if (BC.GetVal() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Base120
        {
            public int GetVal()
            {
                return Test();
            }
            protected internal virtual int Test()
            {
                return 1;
            }
        }
        public class MethodsTestClass120 : MethodsTestClass_Base120
        {
            protected internal override int Test()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base120 BC = new MethodsTestClass120();
                if (BC.GetVal() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Base121
        {
            public virtual int Test()
            {
                return 1;
            }
        }
        public class MethodsTestClass_Base121_2 : MethodsTestClass_Base121
        {
            new private int Test()
            {
                return 2;
            }
        }
        public class MethodsTestClass121 : MethodsTestClass_Base121_2
        {
            public override int Test()
            {
                return 3;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base121 BC = new MethodsTestClass121();
                if (BC.Test() == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public abstract class MethodsTestClass_Base124
        {
            public abstract int Test();
        }
        public class MethodsTestClass124 : MethodsTestClass_Base124
        {
            public override int Test()
            {
                return 1;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base124 BC = new MethodsTestClass124();
                if (BC.Test() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Base125
        {
            public virtual int Test()
            {
                return 1;
            }
        }
        public class MethodsTestClass_Base125_2 : MethodsTestClass_Base125
        {
            public override int Test()
            {
                return 2;
            }
        }
        public class MethodsTestClass125 : MethodsTestClass_Base125_2
        {
            public override int Test()
            {
                return 3;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base125 BC = new MethodsTestClass125();
                MethodsTestClass_Base125_2 BC2 = new MethodsTestClass125();
                if ((BC.Test() == 3) && (BC2.Test() == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Base132
        {
            public virtual int Test()
            {
                return 1;
            }
        }

        public class MethodsTestClass132 : MethodsTestClass_Base132
        {
            public override int Test()
            {
                return 2;
            }
            public int RetVal()
            {
                return base.Test();
            }
            public static bool testMethod()
            {
                MethodsTestClass132 MC = new MethodsTestClass132();
                if ((MC.Test() == 2) && (MC.RetVal() == 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Base133
        {
            public virtual int Test()
            {
                return 1;
            }
        }
        public class MethodsTestClass133 : MethodsTestClass_Base133
        {
            public override int Test()
            {
                return 2;
            }
            public int RetVal()
            {
                return ((MethodsTestClass_Base133)this).Test();
            }
            public static bool testMethod()
            {
                MethodsTestClass133 MC = new MethodsTestClass133();
                if ((MC.Test() == 2) && (MC.RetVal() == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Base134
        {
            public virtual int Test()
            {
                return 1;
            }
        }
        public class MethodsTestClass134 : MethodsTestClass_Base134
        {
            public int Test()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base134 BC = new MethodsTestClass134();
                if (BC.Test() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public abstract class MethodsTestClass_Base142
        {
            public abstract int Test();
        }
        public class MethodsTestClass142 : MethodsTestClass_Base142
        {
            public override int Test()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass_Base142 BC = new MethodsTestClass142();
                if (BC.Test() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass148
        {
            int intI = 2;
            public void Test()
            {
                return;
                intI = 3;
            }
            public static bool testMethod()
            {
                MethodsTestClass148 test = new MethodsTestClass148();
                test.Test();
                if (test.intI == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass149
        {
            public long RetVal()
            {
                int ret = 2;
                return ret;
            }
            public static bool testMethod()
            {
                MethodsTestClass149 test = new MethodsTestClass149();
                if (test.RetVal() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass_Sub150
        {
            public int IntI = 2;
            public static implicit operator int(MethodsTestClass_Sub150 t)
            {
                return t.IntI;
            }
        }
        public class MethodsTestClass150
        {
            public long RetVal()
            {
                MethodsTestClass_Sub150 tc = new MethodsTestClass_Sub150();
                return tc;
            }
            public static bool testMethod()
            {
                MethodsTestClass150 test = new MethodsTestClass150();
                if (test.RetVal() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public class MethodsTestClass154
        {
            public long RetVal(bool b)
            {

                long ret = 2;

                if (b == true)
                {
                    return ret;
                }
                else
                {
                    return (ret + 1);
                }
            }
            public static bool testMethod()
            {
                MethodsTestClass154 test = new MethodsTestClass154();
                if ((test.RetVal(true) == 2) && (test.RetVal(false) == 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public class MethodsTestClass159
        {
            public long RetVal()
            {
                throw new System.Exception();
            }
            public static bool testMethod()
            {
                bool val = false;
                MethodsTestClass159 test = new MethodsTestClass159();
                try
                {
                    test.RetVal();
                }
                catch
                {
                    val = true;
                }
                return val;
            }
        }

        public class MethodsTestClass160
        {
            public long RetVal(bool b)
            {

                long ret = 2;

                if (b == true)
                {
                    return ret;
                }
                else
                {
                    throw new System.Exception();
                }
            }
            public static bool testMethod()
            {
                bool val = false;
                MethodsTestClass160 test = new MethodsTestClass160();
                if (test.RetVal(true) != 2)
                {
                    return false;
                }
                try
                {
                    test.RetVal(false);
                }
                catch (System.Exception e)
                {
                    val = true;
                }
                return val;
            }
        }

        public class MethodsTestClass161
        {
            public long RetVal(bool b)
            {

                long ret = 2;

                if (b == true)
                {
                    throw new System.Exception();
                }
                else
                {
                    return ret;
                }
            }
            public static bool testMethod()
            {
                bool val = false;
                MethodsTestClass161 test = new MethodsTestClass161();
                if (test.RetVal(false) != 2)
                {
                    return false;
                }
                try
                {
                    test.RetVal(true);
                }
                catch (System.Exception e)
                {
                    val = true;
                }
                return val;
            }
        }

        public class MethodsTestClass163
        {
            public int MyMeth1(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            public static int MyMeth2(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            public static bool testMethod()
            {
                int intI = 1;
                int intJ = 2;
                int intK = 3;
                MethodsTestClass163 mc = new MethodsTestClass163();
                if ((mc.MyMeth1(intI, intJ, intK) == 6) && (MyMeth2(intI, intJ, intK) == 6))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass164
        {
            public int MyMeth1(params int[][] values)
            {
                return values[0][0] + values[1][0] + values[2][0];
            }
            public static int MyMeth2(params int[][] values)
            {
                return values[0][0] + values[1][0] + values[2][0];
            }
            public static bool testMethod()
            {
                int[] intI = { 1 };
                int[] intJ = { 2 };
                int[] intK = { 3 };
                MethodsTestClass164 mc = new MethodsTestClass164();
                if ((mc.MyMeth1(intI, intJ, intK) == 6) && (MyMeth2(intI, intJ, intK) == 6))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass169
        {
            public int MyMeth1(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            public static int MyMeth2(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            public static bool testMethod()
            {
                MethodsTestClass169 mc = new MethodsTestClass169();
                if ((mc.MyMeth1(new int[] { 1, 2, 3 }) == 6) && (MyMeth2(new int[] { 1, 2, 3 }) == 6))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MyType
        {
            public int intI = 2;
        }

        public class MethodsTestClass172
        {
            public int MyMeth1(params int[] values)
            {
                return 2;
            }
            public static int MyMeth2(params int[] values)
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass172 mc = new MethodsTestClass172();
                if ((mc.MyMeth1() == 2) && (MyMeth2() == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass173
        {
            public int MyMeth1(params int[] values)
            {
                return values[0];
            }
            public static int MyMeth2(params int[] values)
            {
                return values[0];
            }
            public static bool testMethod()
            {
                int intI = 2;
                MethodsTestClass173 mc = new MethodsTestClass173();
                if ((mc.MyMeth1(intI) == 2) && (MyMeth2(intI) == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass174
        {
            public int MyMeth1(params int[] values)
            {
                return values[0];
            }
            public static int MyMeth2(params int[] values)
            {
                return values[0];
            }
            public static bool testMethod()
            {
                int i = 1;
                short s = 2;
                byte b = 3;
                MethodsTestClass174 mc = new MethodsTestClass174();
                if ((mc.MyMeth1(i, s, b) == 1) && (MyMeth2(i, s, b) == 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass175
        {
            public int MyMeth1(params int[] values)
            {
                return values[0];
            }
            public static int MyMeth2(params int[] values)
            {
                return values[0];
            }
            public static bool testMethod()
            {
                short s = 2;
                MethodsTestClass175 mc = new MethodsTestClass175();
                if ((mc.MyMeth1(s) == 2) && (MyMeth2(s) == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass179
        {
            public int MyMeth1(int intI, params int[] values)
            {
                return values[0] + values[1] + intI;
            }
            public static int MyMeth2(int intI, params int[] values)
            {
                return values[0] + values[1] + intI;
            }
            public static bool testMethod()
            {
                int intI = 1;
                int intJ = 2;
                int intK = 3;
                MethodsTestClass179 mc = new MethodsTestClass179();
                if ((mc.MyMeth1(intI, intJ, intK) == 6) && (MyMeth2(intI, intJ, intK) == 6))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass180
        {
            public int MyMeth1(int intI, int intJ, int intK)
            {
                return 1;
            }
            public int MyMeth1(params int[] values)
            {
                return 2;
            }
            public static int MyMeth2(int intI, int intJ, int intK)
            {
                return 1;
            }
            public static int MyMeth2(params int[] values)
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass180 mc = new MethodsTestClass180();
                if ((mc.MyMeth1(1, 2) == 2) && (mc.MyMeth1(1, 2, 3) == 1) && (MyMeth2(1, 2) == 2) && (MyMeth2(1, 2, 3) == 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass181
        {
            public int MyMeth1(int intI, int intJ, int intK)
            {
                return 1;
            }
            public int MyMeth1(params int[] values)
            {
                return 2;
            }
            public static int MyMeth2(int intI, int intJ, int intK)
            {
                return 1;
            }
            public static int MyMeth2(params int[] values)
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass181 mc = new MethodsTestClass181();
                if ((mc.MyMeth1(1, 2, 3, 4) == 2) && (mc.MyMeth1(1, 2, 3) == 1) && (MyMeth2(1, 2, 3, 4) == 2) && (MyMeth2(1, 2, 3) == 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass182
        {
            public int MyMeth1(params short[] values)
            {
                return 1;
            }
            public int MyMeth1(params int[] values)
            {
                return 2;
            }
            public static int MyMeth2(params short[] values)
            {
                return 1;
            }
            public static int MyMeth2(params int[] values)
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass182 mc = new MethodsTestClass182();
                short s1 = 1, s2 = 1, s3 = 1;
                int i1 = 2, i2 = 2, i3 = 2;
                if ((mc.MyMeth1(s1, s2, s3) == 1) && (mc.MyMeth1(i1, i2, i3) == 2) && (MyMeth2(s1, s2, s3) == 1) && (MyMeth2(i1, i2, i3) == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass183
        {
            public int MyMeth1(params short[] values)
            {
                return 1;
            }
            public int MyMeth1(params int[] values)
            {
                return 2;
            }
            public static int MyMeth2(params short[] values)
            {
                return 1;
            }
            public static int MyMeth2(params int[] values)
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass183 mc = new MethodsTestClass183();
                short s1 = 1;
                int i1 = 2;
                if ((mc.MyMeth1(s1, i1) == 2) && (MyMeth2(s1, i1) == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass184
        {
            public int MyMeth1(params long[] values)
            {
                return 1;
            }
            public int MyMeth1(params int[] values)
            {
                return 2;
            }
            public static int MyMeth2(params long[] values)
            {
                return 1;
            }
            public static int MyMeth2(params int[] values)
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass184 mc = new MethodsTestClass184();
                short s1 = 1;
                byte b1 = 2;
                if ((mc.MyMeth1(s1, b1) == 2) && (MyMeth2(s1, b1) == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass185
        {
            public int MyMeth1(params int[] values)
            {
                values[0] = 3;
                return values[0];
            }
            public static int MyMeth2(params int[] values)
            {
                values[0] = 4;
                return values[0];
            }
            public static bool testMethod()
            {
                MethodsTestClass185 mc = new MethodsTestClass185();
                int intI = 2;
                if ((mc.MyMeth1(intI) == 3) && (MyMeth2(intI) == 4) && (intI == 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass186
        {
            public int MyMeth1(params int[] values)
            {
                return MyMeth2(values);
            }
            public int MyMeth2(params int[] values)
            {
                return 3;
            }
            public static bool testMethod()
            {
                MethodsTestClass186 mc = new MethodsTestClass186();
                int intI = 2;
                if (mc.MyMeth1(intI) == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass187
        {
            public int MyMeth1(params object[] values)
            {
                return MyMeth2((object)values);
            }
            public int MyMeth2(params object[] values)
            {
                return values.Length;
            }
            public static bool testMethod()
            {
                MethodsTestClass187 mc = new MethodsTestClass187();
                if (mc.MyMeth1(2, 3) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Base188
        {
            public int MyMeth()
            {
                return 2;
            }
        }
        public class MethodsTestClass_Derived188 : MethodsTestClass_Base188
        {
        }
        public class MethodsTestClass188 : MethodsTestClass_Derived188
        {
            public int MyTest()
            {
                return base.MyMeth();
            }
            public static bool testMethod()
            {
                MethodsTestClass188 mc = new MethodsTestClass188();
                if (mc.MyTest() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public class MethodsTestClass_Base190
        {
            protected int MyMeth1(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            protected static int MyMeth2(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
        }
        public class MethodsTestClass190 : MethodsTestClass_Base190
        {
            public static bool testMethod()
            {
                int intI = 1;
                int intJ = 2;
                int intK = 3;
                MethodsTestClass190 mc = new MethodsTestClass190();
                if ((mc.MyMeth1(intI, intJ, intK) == 6) && (MyMeth2(intI, intJ, intK) == 6))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MyTest
        {
            internal int MyMeth1(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            internal static int MyMeth2(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
        }
        public class MethodsTestClass191
        {
            public static bool testMethod()
            {
                int intI = 1;
                int intJ = 2;
                int intK = 3;
                MyTest mc = new MyTest();
                if ((mc.MyMeth1(intI, intJ, intK) == 6) && (MyTest.MyMeth2(intI, intJ, intK) == 6))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass192_Test
        {
            protected internal int MyMeth1(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            protected internal static int MyMeth2(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
        }
        public class MethodsTestClass192
        {
            public static bool testMethod()
            {
                int intI = 1;
                int intJ = 2;
                int intK = 3;
                MyTest mc = new MyTest();
                if ((mc.MyMeth1(intI, intJ, intK) == 6) && (MyTest.MyMeth2(intI, intJ, intK) == 6))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass193
        {
            private int MyMeth1(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            private static int MyMeth2(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            public static bool testMethod()
            {
                int intI = 1;
                int intJ = 2;
                int intK = 3;
                MethodsTestClass193 mc = new MethodsTestClass193();
                if ((mc.MyMeth1(intI, intJ, intK) == 6) && (MyMeth2(intI, intJ, intK) == 6))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Base194
        {
            public virtual int MyMeth1(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
        }
        public class MethodsTestClass194 : MethodsTestClass_Base194
        {
            public override int MyMeth1(params int[] values)
            {
                return -1;
            }
            public static bool testMethod()
            {
                int intI = 1;
                int intJ = 2;
                int intK = 3;
                MethodsTestClass_Base194 mc = new MethodsTestClass194();
                if (mc.MyMeth1(intI, intJ, intK) == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Base195
        {
            public virtual int MyMeth1(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
        }
        public class MethodsTestClass195 : MethodsTestClass_Base195
        {
            public new int MyMeth1(params int[] values)
            {
                return -1;
            }
            public static bool testMethod()
            {
                int intI = 1;
                int intJ = 2;
                int intK = 3;
                MethodsTestClass_Base195 mc = new MethodsTestClass195();
                if (mc.MyMeth1(intI, intJ, intK) == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public abstract class MethodsTestClass_Base196
        {
            public abstract int MyMeth1(params int[] values);
        }
        public class MethodsTestClass196 : MethodsTestClass_Base196
        {
            public override int MyMeth1(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            public static bool testMethod()
            {
                int intI = 1;
                int intJ = 2;
                int intK = 3;
                MethodsTestClass_Base196 mc = new MethodsTestClass196();
                if (mc.MyMeth1(intI, intJ, intK) == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public delegate int MyDelegate(params int[] values);
        public class MethodsTestClass197
        {
            public int MyMeth1(params int[] values)
            {
                return values[0] + values[1] + values[2];
            }
            public MyDelegate md;
            public static bool testMethod()
            {
                int intI = 1;
                int intJ = 2;
                int intK = 3;
                MethodsTestClass197 mc = new MethodsTestClass197();
                mc.md = new MyDelegate(mc.MyMeth1);
                if (mc.md(intI, intJ, intK) == 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Base199
        {
            public virtual int RetInt()
            {
                return 1;
            }
        }
        public class MethodsTestClass199 : MethodsTestClass_Base199
        {
            public sealed override int RetInt()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass199 MC = new MethodsTestClass199();
                if (MC.RetInt() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //Compiled Test Cases 

        public class MethodsTestClass200
        {
            public int MyMeth()
            {

                int int1 = 1;
                int int2 = 2;
                int int3 = 3;
                int int4 = 4;
                int int5 = 5;
                int int6 = 6;
                int int7 = 7;
                int int8 = 8;
                int int9 = 9;
                int int10 = 10;
                int int11 = 11;
                int int12 = 12;
                int int13 = 13;
                int int14 = 14;
                int int15 = 15;
                int int16 = 16;
                int int17 = 17;
                int int18 = 18;
                int int19 = 19;
                int int20 = 20;
                int int21 = 21;
                int int22 = 22;
                int int23 = 23;
                int int24 = 24;
                int int25 = 25;
                int int26 = 26;
                int int27 = 27;
                int int28 = 28;
                int int29 = 29;
                int int30 = 30;
                int int31 = 31;
                int int32 = 32;
                int int33 = 33;

                int intRet = int1 + int2 + int3 + int4 + int5 + int6 + int7 + int8 + int9 + int10 +
                    int11 + int12 + int13 + int14 + int15 + int16 + int17 + int18 + int19 + int20 +
                    int21 + int22 + int23 + int24 + int25 + int26 + int27 + int28 + int29 + int30 +
                    int31 + int32 + int33;

                return intRet;

            }

            public static bool testMethod()
            {

                MethodsTestClass200 MC = new MethodsTestClass200();

                if (MC.MyMeth() == 561)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass201
        {
            public static int MyMeth()
            {
                int int1 = 1;
                int int2 = 2;
                int int3 = 3;
                int int4 = 4;
                int int5 = 5;
                int int6 = 6;
                int int7 = 7;
                int int8 = 8;
                int int9 = 9;
                int int10 = 10;
                int int11 = 11;
                int int12 = 12;
                int int13 = 13;
                int int14 = 14;
                int int15 = 15;
                int int16 = 16;
                int int17 = 17;
                int int18 = 18;
                int int19 = 19;
                int int20 = 20;
                int int21 = 21;
                int int22 = 22;
                int int23 = 23;
                int int24 = 24;
                int int25 = 25;
                int int26 = 26;
                int int27 = 27;
                int int28 = 28;
                int int29 = 29;
                int int30 = 30;
                int int31 = 31;
                int int32 = 32;
                int int33 = 33;
                int intRet = int1 + int2 + int3 + int4 + int5 + int6 + int7 + int8 + int9 + int10 +
                    int11 + int12 + int13 + int14 + int15 + int16 + int17 + int18 + int19 + int20 +
                    int21 + int22 + int23 + int24 + int25 + int26 + int27 + int28 + int29 + int30 +
                    int31 + int32 + int33;

                return intRet;
            }
            public static bool testMethod()
            {

                if (MyMeth() == 561)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass204
        {
            public int MyMeth(int i, int j, params int[] k)
            {
                return i + j;
            }
            public static bool testMethod()
            {
                MethodsTestClass204 MC = new MethodsTestClass204();
                if (MC.MyMeth(1, 2) == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass205
        {
            public static int MyMeth(int i, int j, params int[] k)
            {
                return i + j;
            }
            public static bool testMethod()
            {
                if (MyMeth(1, 2) == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Sub206
        {
            private static int MyMeth(int intI)
            {
                return 1;
            }
            public static int MyMeth(params int[] intI)
            {
                return 202;
            }
        }
        public class MethodsTestClass206
        {
            public static bool testMethod()
            {
                if(MethodsTestClass_Sub206.MyMeth(201) == 202)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass_Sub207
        {
            private int MyMeth(int intI)
            {
                return 1;
            }
            public int MyMeth(params int[] intI)
            {
                return 202;
            }
        }
        public class MethodsTestClass207
        {
            public static bool testMethod()
            {
                MethodsTestClass_Sub207 MC = new MethodsTestClass_Sub207();
                if (MC.MyMeth(201) == 202)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Compiled Test Cases 

        public class MyMethodsTestClass_Base210
        {
            public virtual int MyMeth(int intI)
            {
                return 1;
            }
        }
        public class MethodsTestClass210_sub : MyMethodsTestClass_Base210
        {
            public sealed override int MyMeth(int intI)
            {
                return 3;
            }
        }
        public class MethodsTestClass210
        {
            public static bool testMethod()
            {
                MethodsTestClass210_sub MC = new MethodsTestClass210_sub();
                if (MC.MyMeth(1) == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public class MethodsTestClass223_Sub
        {
            public int MyMeth(ref int mbc)
            {
                return 1;
            }
            public int MyMeth(int mbc)
            {
                return 2;
            }
        }
        public class MethodsTestClass223
        {
            public static bool testMethod()
            {
                int retval = 3;
                MethodsTestClass223_Sub mc = new MethodsTestClass223_Sub();
                retval -= mc.MyMeth(1);
                int i = 1;
                retval -= mc.MyMeth(ref i);
                return (retval == 0);
            }
        }


        public class MethodsTestClass224_Sub
        {
            public int MyMeth(out int mbc)
            {
                mbc = 666;
                return 1;
            }
            public int MyMeth(int mbc)
            {
                return 2;
            }
        }
        public class MethodsTestClass224
        {
            public static bool testMethod()
            {
                int retval = 3;
                MethodsTestClass224_Sub mc = new MethodsTestClass224_Sub();
                retval -= mc.MyMeth(1);
                int i;
                retval -= mc.MyMeth(out i);
                return (retval == 0);
            }
        }

        public class MethodsTestClass229_SubB
        {
            public virtual void f() { }
        }

        public class MethodsTestClass229 : MethodsTestClass229_SubB
        {
            public void f() // CS0114
            {
            }
            public static bool testMethod()
            {
                return true;
            }

        }

        public class MethodsTestClass230_Base
        {
            virtual public object f(int x, string y) { return null; }
        }

        public class MethodsTestClass230 : MethodsTestClass230_Base
        {
            object f(int x, string y) // CS0114
            {
                return null;
            }

            public static bool testMethod()
            {
                return true;
            }
        }

        public class MethodsTestClass231_Base
        {
            virtual public object f
            {
                get { return null; }
                set { }
            }
        }

        public class MethodsTestClass231 : MethodsTestClass231_Base
        {
            object f // CS0114
            {
                get { return null; }
                set { }
            }

            public static bool testMethod()
            {
                return true;
            }
        }


        public delegate void MethodsTestClass232_Del();

        public class MethodsTestClass232_B
        {
            public MethodsTestClass232_Del fooDel;

            public virtual event MethodsTestClass232_Del fooEv
            {
                add { }
                remove { }
            }
        }

        public class MethodsTestClass232 : MethodsTestClass232_B
        {
            event MethodsTestClass232_Del fooEv // CS0114
            {
                add { }
                remove { }
            }

            public static bool testMethod()
            {
                return true;
            }
        }


        public class MethodsTestClass233_Base
        {
            public int MyMeth()
            {
                return 1;
            }
        }
        public class MethodsTestClass233 : MethodsTestClass233_Base
        {
            //new modifier
            new public int MyMeth()
            {
                return 2;
            }
            public static bool testMethod()
            {
                MethodsTestClass233 test = new MethodsTestClass233();
                if (test.MyMeth() == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
