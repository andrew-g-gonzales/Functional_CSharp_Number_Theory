using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Xunit;

namespace Common_Tests
{
    public class ReverseTests
    {
        [Fact]
        public void reverseTest2digits()
        {
            Assert.Equal(21, 12.Reverse());
        }

        [Fact]
        public void reverseTest3digits()
        {
            Assert.Equal(321, 123.Reverse());
        }

        [Fact]
        public void reverseTest4digits()
        {
            Assert.Equal(4321, 1234.Reverse());
        }

        [Fact]
        public void reverseTest5digits()
        {
            Assert.Equal(54321, 12345.Reverse());
        }

        [Fact]
        public void reverseTest6digits()
        {
            Assert.Equal(654321, 123456.Reverse());
        }

        [Fact]
        public void reverseTest7digits()
        {
            Assert.Equal(7654321, 1234567.Reverse());
        }
    }
}
