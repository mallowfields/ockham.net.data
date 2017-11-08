using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;
using OAssert = Ockham.Test.Assert;
using OData = Ockham.Data;

namespace Ockham.Data.Tests
{
    public class ConverterTests
    {
        private readonly Converter _Default = Converter.Default;
        private readonly Converter _Strict = Converter.Strict;
        private readonly Converter _Relaxed = Converter.Relaxed;
        private readonly Converter _DefaultPlusHex = new Converter(ConvertOptions.Default | ConvertOptions.AllowHex);
        private readonly Converter[] _All;

        public ConverterTests()
        {
            _All = new Converter[] { _Default, _Strict, _Relaxed, _DefaultPlusHex };
        }


        [Fact(DisplayName = "Converter.To:ImmediateReturnNullForNullReference")]
        public void ImmediateReturnNullForNullReference()
        {
            foreach (Converter c in _All)
            {
                Assert.Null(c.To<object>(null));
            }
        }

        [Fact(DisplayName = "Converter.To:ImmediateReturnTargetReferenceType")]
        public void ImmediateReturnTargetReferenceType()
        {
            string lSourceValue = "foo bar baz";
            foreach (Converter c in _All)
            {
                Assert.Same(lSourceValue, c.ToStr(lSourceValue));
            }
        }

        [Fact(DisplayName = "Converter.To:ImmediateReturnTargetValueType")]
        public void ImmediateReturnTargetValueType()
        {
            int lIntValue = 42;
            foreach (Converter c in _All)
            {
                Assert.Equal(lIntValue, c.ToInt(lIntValue));
            }
        }

        [Fact(DisplayName = "Converter.To:Empty input for nullable returns null")]
        public void EmptyInputForNullableReturnsNull()
        {
            foreach (Converter c in _All)
            {
                Assert.Null(c.To<int?>(null));
            }
        }

        [Fact(DisplayName = "Converter.To:Non-empty input for nullable returns underlying value (int)")]
        public void NonEmptyInputForNullableReturnsUnderlyingValue_Int()
        {
            foreach (Converter c in _All)
            {
                foreach (object lInput in ConvertTestData.Int49Inputs)
                {
                    ConvertAssert.Equal(49, c.To<int?>(lInput));
                }
            }
        }

        [Fact(DisplayName = "Converter.To:Non-empty input for nullable returns underlying value (enum)")]
        public void NonEmptyInputForNullableReturnsUnderlyingValue_Enum()
        {

            foreach (Converter c in _All)
            {
                foreach (object lInput in ConvertTestData.Int49Inputs)
                {
                    ConvertAssert.Equal(TestShortEnum.FortyNine, c.To<TestShortEnum?>(lInput));
                }
            }
        }

        [Fact(DisplayName = "Converter.To:NullToValueDefault")]
        public void NullToValueDefault()
        {
            foreach (object input in new object[] { null, DBNull.Value, string.Empty })
            {
                // Int, no explicit default
                // Allowed for relaxed
                ConvertAssert.Equal(0, _Relaxed.ToInt(input));

                // Not allowed for other converters
                foreach (Converter c in new[] { _Strict, _Default, _DefaultPlusHex })
                {
                    Action fn = () => c.ToInt(input);
                    if (c == _Strict && object.Equals(input, string.Empty))
                    {
                        Assert.Throws<InvalidCastException>(fn);
                    }
                    else
                    {
                        Assert.Throws<ArgumentNullException>(fn);
                    }
                }

                // Enum, no explicit default 
                // Allowed for relaxed
                ConvertAssert.Equal((TestShortEnum)0, _Relaxed.To<TestShortEnum>(input));

                // Not allowed for other converters
                foreach (Converter c in new[] { _Strict, _Default, _DefaultPlusHex })
                {
                    Action fn = () => c.To<TestShortEnum>(input);
                    if (c == _Strict && object.Equals(input, string.Empty))
                    {
                        Assert.Throws<InvalidCastException>(fn);
                    }
                    else
                    {
                        Assert.Throws<ArgumentNullException>(fn);
                    }
                }
            }
        }

        // Ensure the IgnoreError causes the default value to be returned on null input, even WITHOUT the ConvertOptions.NullToValueDefault flag

        [Fact(DisplayName = "Converter.Force:NullToValueDefault")]
        public void Force_IgnoreError()
        {
            foreach (object input in new object[] { null, DBNull.Value, string.Empty })
            {
                // Int, no explicit default 
                foreach (Converter c in _All)
                {
                    // Int, no explicit default
                    ConvertAssert.Equal(0, c.Force<int>(input));

                    // Int, explicit default
                    ConvertAssert.Equal(42, c.Force<int>(input, 42));

                    // Enum, no explicit default
                    ConvertAssert.Equal((TestShortEnum)0, c.Force<TestShortEnum>(input));

                    // Enum, explicit default
                    ConvertAssert.Equal(TestShortEnum.One, c.Force<TestShortEnum>(input, TestShortEnum.One));
                }
            }
        }

        [Fact(DisplayName = "Converter.To:NullToValueTypeRaisesError")]
        public void NullToValueTypeRaisesError()
        {
            foreach (Converter c in new[] { _Strict, _Default, _DefaultPlusHex })
            {
                Assert.Throws<ArgumentNullException>(() => c.To<int>(null));
                Assert.Throws<ArgumentNullException>(() => c.To<TestShortEnum>(null));
            }

            Assert.Throws<ArgumentNullException>(() => _Default.To<int>(string.Empty));
            Assert.Throws<ArgumentNullException>(() => _DefaultPlusHex.To<int>(string.Empty));
            Assert.Throws<InvalidCastException>(() => _Strict.To<int>(string.Empty));

            Assert.Throws<ArgumentNullException>(() => _Default.To<TestShortEnum>(string.Empty));
            Assert.Throws<ArgumentNullException>(() => _DefaultPlusHex.To<TestShortEnum>(string.Empty));
            Assert.Throws<InvalidCastException>(() => _Strict.To<TestShortEnum>(string.Empty));
        }

        [Fact(DisplayName = "Converter.To:HeedErrorsRaisesException")]
        public void Invalid_HeedErrorsRaisesException()
        {
            object lInput = new System.Random();
            foreach (Converter c in _All)
            {
                Assert.Throws<InvalidCastException>(() => c.To<int>(lInput));
                Assert.Throws<InvalidCastException>(() => c.To<TestShortEnum>(lInput));
                Assert.Throws<InvalidCastException>(() => c.To<Converter>(lInput));
            }
        }
    }
}
