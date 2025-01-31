using System;
using System.Diagnostics.CodeAnalysis;
using nanoFramework.TestFramework;

// ReSharper disable RedundantNullableFlowAttribute
namespace CoreLibrary.UnitTests.Diagnostics.CodeAnalysis
{
    [TestClass]
    public class NullableAttributesTests
    {
        private static void AssertDoesNotThrow(Action unitTest)
        {
            Exception? exception = null;

            try
            {
                unitTest();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNull(exception, $"Expected no exception but got: {exception}");
        }

        [TestMethod]
        public void Validate_AllowNullAttribute()
        {
            AssertDoesNotThrow(() =>
            {
                var sut = new AllowNullAttributeTestClass();
                sut.Method(null);
            });
        }

        [TestMethod]
        public void Validate_DisallowNullAttribute()
        {
            AssertDoesNotThrow(() =>
            {
                var sut = new DisallowNullAttributeTestClass();
                sut.Method(null!);
            });
        }

        [TestMethod]
        public void Validate_DoesNotReturnAttribute()
        {
            var sut = new DoesNotReturnAttributeTestClass();

            Assert.ThrowsException(typeof(NotImplementedException), () => sut.Method());
        }

        [TestMethod]
        public void Validate_DoesNotReturnIfAttribute()
        {
            var sut = new DoesNotReturnIfAttributeTestClass();

            Assert.ThrowsException(typeof(NotImplementedException), () => sut.Method(true));
        }

        [TestMethod]
        public void Validate_MaybeNullAttribute()
        {
            AssertDoesNotThrow(() =>
            {
                var sut = new MaybeNullAttributeTestClass();
                sut.Method(null!);
            });
        }

        [TestMethod]
        public void Validate_MaybeNullWhenAttribute()
        {
            AssertDoesNotThrow(() =>
            {
                var sut = new MaybeNullWhenAttributeTestClass();
                sut.Method(null!);
            });
        }

        [TestMethod]
        public void Validate_MemberNotNullAttribute()
        {
            AssertDoesNotThrow(() =>
            {
                var sut = new MemberNotNullAttributeTestClass();
                sut.Method(null!);
            });
        }

        [TestMethod]
        public void Validate_MemberNotNullWhenAttribute()
        {
            AssertDoesNotThrow(() =>
            {
                var sut = new MemberNotNullWhenAttributeTestClass();
                sut.Method();
            });
        }

        [TestMethod]
        public void Validate_NotNullAttribute()
        {
            AssertDoesNotThrow(() =>
            {
                var sut = new NotNullAttributeTestClass();
                sut.Method(null!);
            });
        }

        [TestMethod]
        public void Validate_NotNullIfNotNullAttribute()
        {
            AssertDoesNotThrow(() =>
            {
                var sut = new NotNullIfNotNullAttributeTestClass();
                sut.Method(null!);
            });
        }

        [TestMethod]
        public void Validate_NotNullWhenAttribute()
        {
            AssertDoesNotThrow(() =>
            {
                var sut = new NotNullWhenAttributeTestClass();
                sut.Method(null!);
            });
        }
    }

    #region Test classes
    public class AllowNullAttributeTestClass
    {
        [AllowNull]
        public string? Field;

        [AllowNull]
        public string Property { get; set; }

        public void Method([AllowNull] string? value)
        {
            // Do nothing
        }
    }

    public class DisallowNullAttributeTestClass
    {
        [DisallowNull]
        public string? Field = null!;

        [DisallowNull] 
        public string? Property { get; set; } = null!;

        public void Method([DisallowNull] string value)
        {
            // Do nothing
        }
    }

    public class DoesNotReturnAttributeTestClass
    {
        [DoesNotReturn]
        public void Method()
        {
            throw new NotImplementedException();
        }
    }

    public class DoesNotReturnIfAttributeTestClass
    {
        public void Method([DoesNotReturnIf(true)] bool value)
        {
            if (value)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class MaybeNullAttributeTestClass
    {
        [MaybeNull]
        public string? Field = null!;

        [MaybeNull] 
        public string? Property { get; set; } = null!;

        [MaybeNull]
        public string? this[string? value] => Field;

        public string Method([MaybeNull] string value)
        {
            return null!;
        }
    }

    public class MaybeNullWhenAttributeTestClass
    {
        public bool Method([MaybeNullWhen(true)] string value)
        {
            return true;
        }
    }

    public class MemberNotNullAttributeTestClass
    {
        public string? Field = null!;

        [MemberNotNull(nameof(Field))]
        public string Property { get; set; } = null!;

        [MemberNotNull(nameof(Field))]
        public void Method( string value)
        {
            Field = value;
        }
    }

    public class MemberNotNullWhenAttributeTestClass
    {
        public string? Field = null!;

        [MemberNotNullWhen( true,nameof(Field))]
        public bool Property { get; set; } = true;

        [MemberNotNullWhen(true, nameof(Field))]
        public bool Method()
        {
            Field = string.Empty;
            return true;
        }
    }

    public class NotNullAttributeTestClass
    {
        [NotNull]
        public string? Field = null!;

        [NotNull]
        public string? Property { get; set; } = null!;

        [NotNull]
        public string this[string? value] => value!;

        public string Method([NotNull] string value)
        {
            return null!;
        }
    }

    public class NotNullIfNotNullAttributeTestClass
    {
        public string? Field = null!;

        [NotNullIfNotNull(nameof(Field))]
        public string? Property { get; set; } = null!;

        [NotNullIfNotNull(nameof(Field))]
        public string this[string? value] => value!;

        public string Method([NotNullIfNotNull(nameof(Field))] string value)
        {
            return null!;
        }
    }

    public class NotNullWhenAttributeTestClass
    {
        public bool Method([NotNullWhen(true)] string value)
        {
            return true;
        }
    }
    #endregion
}
