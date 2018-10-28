using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Puzzles
{
    public static class DigitalCubes
    {

        public static IEnumerable<int> NumbersEqualToSumOfCubesFiltered(int start, int end, List<int> optimizedDigits) =>
                 Enumerable.Range(start, end)
                 .Where(x => (optimizedDigits.Contains(x.Digits().Sum())) && (x == x.GetDigitsToPowerOf(3).Sum()));


        public static IEnumerable<int> NumbersEqualToSumOfCubes(int start, int end) =>
                Enumerable.Range(start, end)
               .Where(x => x == x.GetDigitsToPowerOf(3).Sum());
    }
}
