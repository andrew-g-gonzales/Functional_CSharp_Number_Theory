using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Common;
using static Puzzles.DigitalCubes;

namespace Puzzles_Tests
{
    public class DigitalCubesTest
    {
        private static readonly List<int> EQUAL_TO_SUM_OF_CUBES = new List<int> { 153, 370, 371, 407};
        private static readonly List<int> OPTIMIZED_NUMS = new List<int> { 7, 8, 9, 10, 11, 16, 17, 18, 19, 20 };
        

        [Fact]
        public void TestFindDigitalCubesFiltered()
        {        
            var digitalCubes = NumbersEqualToSumOfCubesFiltered(100, 900, OPTIMIZED_NUMS).ToArray();

            Assert.True(digitalCubes != null);
            Assert.True(digitalCubes.Any());

            Assert.True(digitalCubes.Length == 4);
            Assert.True(digitalCubes.SequenceEqual(EQUAL_TO_SUM_OF_CUBES));
        }

        [Fact]
        public void TestFindDigitalCubesFilteredSome()
        {
            var digitalCubes = NumbersEqualToSumOfCubesFilteredSome(100, 900).ToArray();

            Assert.True(digitalCubes != null);
            Assert.True(digitalCubes.Any());

            Assert.True(digitalCubes.Length == 4);
            Assert.True(digitalCubes.SequenceEqual(EQUAL_TO_SUM_OF_CUBES));
        }


        [Fact]
        public void TestFindDigitalCubes()
        {
            var digitalCubes = NumbersEqualToSumOfCubes(100, 900).ToArray();

            Assert.True(digitalCubes != null);
            Assert.True(digitalCubes.Any());

            Assert.True(digitalCubes.Length == 4);
            Assert.True(digitalCubes.SequenceEqual(EQUAL_TO_SUM_OF_CUBES));
        }

        [Theory]
        [InlineData(153)]
        [InlineData(370)]
        [InlineData(371)]
        [InlineData(407)]
        public void TestNumEqualsCubedDigitsSummed(int number)=> Assert.True(NumEqualsCubedDigitsSummed(number));


        public static IEnumerable<object[]> ThreeDigits() =>
         (from i in (Enumerable.Range(100, 900))
          where (!SumAndSumCubedSameRemainer(i,9) && !ContainsSumOfSequence(i, OPTIMIZED_NUMS))
          select new object[] { i });

        public static IEnumerable<object[]> NotModulo9() =>
        (from i in (Enumerable.Range(10, 9000))
         where (i.Digits().Sum()%9 != i.GetDigitsToPowerOf(3).Sum()%9)
         select new object[] { i });

        public static IEnumerable<object[]> Modulo9() =>
       (from i in (Enumerable.Range(10, 9000))
        where (i.Digits().Sum() % 9 == i.GetDigitsToPowerOf(3).Sum() % 9)
        select new object[] { i });

        public static IEnumerable<object[]> NotContainsWorkableNums() =>
        (from i in (Enumerable.Range(10, 9000))
        where (!OPTIMIZED_NUMS.Contains(i.Digits().Sum()))
        select new object[] { i });


        [Theory]
        [MemberData(nameof(ThreeDigits))]
        public void TestNumNOTEqualsCubedDigitsSummed(int number) => Assert.False(NumEqualsCubedDigitsSummed(number));


        [Theory]
        [MemberData(nameof(NotModulo9))]
        public void TestSumAndSumNOTCubedSameRemainer(int number) => Assert.False(SumAndSumCubedSameRemainer(number,9));

        [Theory]
        [MemberData(nameof(Modulo9))]
        public void TestSumAndSumCubedSameRemainer(int number) => Assert.True(SumAndSumCubedSameRemainer(number, 9));

        [Theory]
        [MemberData(nameof(NotContainsWorkableNums))]
        public void TestNOTContainsSumOfSequence(int number) => Assert.False(ContainsSumOfSequence(number, OPTIMIZED_NUMS));


    }
}
