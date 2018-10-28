using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Puzzles
{
    public static class DigitalCubes
    {

        public static IEnumerable<int> NumbersEqualToSumOfCubesFiltered(int start, int end, List<int> optimizedDigits) =>
                 Enumerable.Range(100, 900)
                .Where(n => optimizedDigits.Contains(n.Digits().Sum()))
                .ToDictionary(x => x, x => x.GetDigitsToPowerOf(3).Sum())
                .Where(e => e.Key == e.Value)
                .Select(k => k.Key);


        public static IEnumerable<int> NumbersEqualToSumOfCubes(int start, int end) =>
                Enumerable.Range(100, 900)
               .ToDictionary(x => x, x => x.GetDigitsToPowerOf(3).Sum())
               .Where(e => e.Key == e.Value)
               .Select(k => k.Key);
    }
}
