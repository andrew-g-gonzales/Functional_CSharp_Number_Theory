using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Linq.Enumerable;

namespace Common
{
    public static class Extensions
    {

        public static int Product(this IEnumerable<int> source) => source.Aggregate(1, (x, y) => x * y);

        public static long Product(this IEnumerable<long> source) => source.Aggregate(1L, (x, y) => x * y);

        public static double Product(this IEnumerable<double> source) => source.Aggregate(1D, (x, y) => x * y);

        public static int ToPowerOf(this int @base, int exponent) => Range(1, exponent).Select(_ => @base).Product();

        public static long ToPowerOf(this long @base, int exponent) => Range(1, exponent).Select(_ => @base).Product();

        public static bool IsEven(this int n) => n % 2 == 0;

        public static bool IsOdd(this int n) => !n.IsEven();

        public static bool IsEven(this long n) => n % 2L == 0;

        public static bool IsOdd(this long n) => !n.IsEven();

        public static IEnumerable<int> Divisors(this int n) => Enumerable.Range(1, n).Where(i => n % i == 0);


        public static IReadOnlyList<int> Digits(this int n) =>
                                        n.ToString(CultureInfo.InvariantCulture)
                                            .Cast<string>()
                                            .Select(Int32.Parse)
                                            .ToList();

        public static IReadOnlyList<long> Digits(this long n) =>
                                       n.ToString(CultureInfo.InvariantCulture)
                                           .Cast<string>()
                                           .Select(Int64.Parse)
                                           .ToList();

        public static int Length(this int n) => n.Digits().Count();

        public static long Length(this long n) => n.Digits().Count();

        public static bool IsPalindromic(this int n) => n.Digits().SequenceEqual(n.Digits().Reverse());

        public static bool IsPalindromic(this long n) => n.Digits().SequenceEqual(n.Digits().Reverse());


        static IEnumerable<int> Factor(this long n)
        {
            var current = n;

            if (n == 1)
                yield return 1;

            while (current > 1)
            {
                for (var i = 2; i <= current; i++)
                {
                    if (current % i == 0)
                    {
                        yield return i;
                        current /= i;
                    }
                }
            }
        }

        static IEnumerable<int> Factor(this int n)
        {
            var current = n;

            if (n == 1)
                yield return 1;

            while (current > 1)
            {
                for (var i = 2; i <= current; i++)
                {
                    if (current % i == 0)
                    {
                        yield return i;
                        current /= i;
                    }
                }
            }
        }


    }
}
