using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Prime_Numbers;

namespace Prime_Numbers_Tests
{
    public class EmripTests
    {

        [Theory]
        [InlineData(13)]
        [InlineData(17)]
        [InlineData(31)]
        [InlineData(37)]
        [InlineData(71)]
        [InlineData(73)]
        [InlineData(79)]
        [InlineData(97)]
        [InlineData(107)]
        [InlineData(113)]
        [InlineData(149)]
        [InlineData(157)]
        [InlineData(167)]
        [InlineData(179)]
        [InlineData(199)]
        [InlineData(311)]
        [InlineData(337)]
        [InlineData(347)]
        [InlineData(359)]
        [InlineData(389)]
        public void IsEmripTestFirst20(int number)=>Assert.True(number.IsEmrip());

        [Theory]
        [InlineData(7717)]
        [InlineData(7757)]
        [InlineData(7817)]
        [InlineData(7841)]
        [InlineData(7867)]
        [InlineData(7879)]
        [InlineData(7901)]
        [InlineData(7927)]
        [InlineData(7949)]
        [InlineData(7951)]
        [InlineData(7963)]
        public void IsEmripTestBetween7700and8000(int number) => Assert.True(number.IsEmrip());

    }
}
