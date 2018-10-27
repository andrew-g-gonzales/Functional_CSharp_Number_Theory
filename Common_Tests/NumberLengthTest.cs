using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Xunit;

namespace Common_Tests
{
    public class NumberLengthTest
    {
        [Fact]
        public void TwoDigits()
        {
            Assert.Equal(2, 12.Length());
        }

        [Fact]
        public void ThreeDigits()
        {
            Assert.Equal(3, 123.Length());
        }

        [Fact]
        public void FourDigits()
        {
            Assert.Equal(4, 1234.Length());
        }

        [Fact]
        public void FiveDigits()
        {
            Assert.Equal(5, 12345.Length());
        }

        [Fact]
        public void SixDigits()
        {
            Assert.Equal(6, 123456.Length());
        }

        [Fact]
        public void SevenDigits()
        {
            Assert.Equal(7, 1234567.Length());
        }

        [Fact]
        public void EightDigits()
        {
            Assert.Equal(8, 12345678.Length());
        }

        [Fact]
        public void NineDigits()
        {
            Assert.Equal(9, 123456789.Length());
        }

        [Fact]
        public void FifteenDigits()
        {
            Assert.Equal(15, 123456789012345.Length());
        }

        [Fact]
        public void NineteenDigits()
        {
            Assert.Equal(19, 1234567890123456789.Length());
        }
    }
}
