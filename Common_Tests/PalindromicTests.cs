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

        public static IEnumerable<object[]> Palindromes5Digits() => 
         (from i in (Enumerable.Range(100, 900).AsParallel()
             .WithDegreeOfParallelism(Environment.ProcessorCount)
              .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
              .WithMergeOptions(ParallelMergeOptions.NotBuffered))
         from j in (Enumerable.Range(i, 1000- i))
         let k = i * j
         where check(k.ToString())
         select new object[] { k });

        public static bool check(string input) =>
                  Enumerable.Range(0, input.Length / 2)
                    .All(i => input[i] == input[input.Length - i - 1]);
                  

        [Theory]
        [MemberData(nameof(Palindromes5Digits))]
        public void TestIsPalindrome5Digits(int integer) => Assert.True(integer.IsPalindromic());

    }
}
