using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
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
        public void TestFindDigitalCubes()
        {
            var digitalCubes = NumbersEqualToSumOfCubes(100, 900).ToArray();

            Assert.True(digitalCubes != null);
            Assert.True(digitalCubes.Any());

            Assert.True(digitalCubes.Length == 4);
            Assert.True(digitalCubes.SequenceEqual(EQUAL_TO_SUM_OF_CUBES));
        }

    }
}
