using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Common;

namespace Theorem_Test_Proofs
{
    public class ModularArithmetic
    {
    
      public static IEnumerable<object[]> OddNumbersSquared() =>
      (from i in (CustomRange.Int64(1,10000))
       where i.IsOdd()
       select new object[] { i.ToPowerOf(2) });


        [Theory]
        [MemberData(nameof(OddNumbersSquared))]
        public void SquareOfOddNumber1MoewGreaterThanMultipleOf8(long oddNumberSquared)=> Assert.True((oddNumberSquared-1)%8 == 0);
        
    }
}
