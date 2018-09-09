using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Xunit;

namespace Common_Tests
{
   


    public class PalindromicTests
    {
        public static IEnumerable<object[]> Palindromes()
       => (from i in Enumerable.Range(100, 900)
           from j in Enumerable.Range(i, 1000 - i)
           let k = i * j
           where check(k.ToString())
           select new object []{ k }).AsParallel()
               .WithDegreeOfParallelism(Environment.ProcessorCount)
               .WithExecutionMode(ParallelExecutionMode.ForceParallelism);

        public static bool check(string input_number)
        {
            for (int i = 0; i < input_number.Length / 2; i++)
                if (input_number[i] != input_number[input_number.Length - i - 1])
                    return false;
            return true;
        }

        [Theory]
        [MemberData(nameof(Palindromes))]
        public void TestIsPalindrome3Digits(int integer)
        {
            Assert.True(integer.IsPalindromic());
        }
    }
}
