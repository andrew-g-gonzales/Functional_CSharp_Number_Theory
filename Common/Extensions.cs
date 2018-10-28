using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Linq.Enumerable;
using static System.Int32;

namespace Common
{
    public static class Extensions
    {

        public static int Product(this IEnumerable<int> source) => source.Aggregate(1, (x, y) => x * y);

        public static long Product(this IEnumerable<long> source) => source.Aggregate(1L, (x, y) => x * y);

        public static double Product(this IEnumerable<double> source) => source.Aggregate(1D, (x, y) => x * y);

        public static int ToPowerOf(this int @base, int exponent) => Range(1, exponent).Select(_ => @base).Product();

        public static long ToPowerOf(this long @base, int exponent) => Range(1, exponent).Select(_ => @base).Product();

        public static IEnumerable<int> GetDigitsToPowerOf(this int n, int exponent) => n.Digits().Select(i => i.ToPowerOf(exponent));

        public static bool IsEven(this int n) => n % 2 == 0;

        public static bool IsOdd(this int n) => !n.IsEven();

        public static bool IsEven(this long n) => n % 2L == 0L;

        public static bool IsOdd(this long n) => !n.IsEven();

        public static bool IsPrime(this int n) => n > 1 && n.Factor().First() == n;

        public static bool IsPrime(this long n) => n > 1 && n.Factor().First() == n;

        static IEnumerable<int> Divisors(this int n) => Enumerable.Range(1, n).Where(i => n % i == 0);

        public static IEnumerable<long> Divisors(this long n) => CustomRange.Int64(1L, n).Where(iL => n % iL == 0);

        public static IReadOnlyList<int> Digits(this int n) =>
                                        n.ToString()
                                           .Select(c => (int)(c - '0'))
                                          .ToArray();

        public static IReadOnlyList<long> Digits(this long n) =>
                                         n.ToString()
                                           .Select(c => (long)(c - '0'))
                                           .ToArray();

        public static int LeastCommonMultiple(this IReadOnlyCollection<int> numbers) =>
                              numbers.SelectMany(n => n
                                      .Factor()
                                      .GroupBy(f => f)
                                  )
                                  .GroupBy(g => g.Key)
                                  .Select(g => g.Key.ToPowerOf(g.Max(g2 => g2.Count())))
                                  .Product();

        public static int LeastCommonMultiple(this IReadOnlyCollection<long> numbers) =>
                               numbers.SelectMany(n => n
                                       .Factor()
                                       .GroupBy(f => f)
                                   )
                                   .GroupBy(g => g.Key)
                                   .Select(g => g.Key.ToPowerOf(g.Max(g2 => g2.Count())))
                                   .Product();

        public static int GreatestCommonDivisor(int a, int b) =>
                                                                a.Divisors().Intersect(b.Divisors())
                                                                    .DefaultIfEmpty(1)
                                                                    .Max();

       public static long GreatestCommonDivisor(long a, long b) =>
                                                                a.Divisors().Intersect(b.Divisors())
                                                                    .DefaultIfEmpty(1)
                                                                    .Max();

        public static bool IsPerfectSquare(this long n) => n.Factor().GroupBy(f => f).All(g => g.Count() % 2 == 0);

        public static bool IsPerfectSquare(this int n) => n.Factor().GroupBy(f => f).All(g => g.Count() % 2 == 0);

        public static bool IsPerfectPower(this int n, int power) => n.Factor().GroupBy(f => f).All(g => g.Count() % power == 0);

        public static bool IsPerfectPower(this long n, int power) => n.Factor().GroupBy(f => f).All(g => g.Count() % power == 0);

        public static bool IsPerfectNumber(this int value)
        {
            var isPerfect = false;

            int maxCheck = Convert.ToInt32(Math.Sqrt(value));
            int[] possibleDivisors = CustomRange.Int32(1, maxCheck).ToArray();
            int[] properDivisors = possibleDivisors.Where(d => (value % d == 0)).ToArray();
            int divisorsSum = properDivisors.Sum();

            if (divisorsSum.IsPrime())
            {
                int lastDivisor = properDivisors.Last();
                isPerfect = (value == (lastDivisor * divisorsSum));
            }

            return isPerfect;
        }

        public static bool IsPerfectNumber(this long value)
        {
            var isPerfect = false;

            long[] properDivisors = CustomRange.Int64(1, Convert.ToInt64(Math.Sqrt(value))).Where(d => (value % d == 0)).ToArray();
            long divisorsSum = properDivisors.Sum();

            if (divisorsSum.IsPrime())
            {
                long lastDivisor = properDivisors.Last();
                isPerfect = (value == (lastDivisor * divisorsSum));
            }

            return isPerfect;
        }

        public static IEnumerable<int> GetDivisors(this int number)
        {
            var searched = Enumerable.Range(1, number)
                 .Where((x) => number % x == 0)
                 .Select(x => number / x);

            foreach (var s in searched)
                yield return s;
        }

        public static bool Divides(this int potentialFactor, int i)
        {
            return i % potentialFactor == 0;
        }

        public static IEnumerable<int> Factors(this int i)
        {
            return from potentialFactor in Enumerable.Range(1, i)
                   where potentialFactor.Divides(i)
                   select potentialFactor;
        }

        //public static bool IsPerfectNumber(this long number) => number.Divisors().Sum().Equals(number);

        public static IEnumerable<U> SkipLastEnumerable<U>(this IEnumerable<U> models)
        {
            using (var e = models.GetEnumerator())
            {
                for (; e.MoveNext();) yield return e.Current;
            }
        }

        public static int Reverse(this int num)
        {
            int result = 0;
          
            for (; num != 0; result = result * 10 + num % 10, num /= 10) { }

            return result;
        }

        public static long Reverse(this long num)
        {
            long result = 0;

            for (; num != 0; result = result * 10 + num % 10, num /= 10) { }

            return result;
        }

        private static int DigitCount(int num, int digits)=>( (num > 0) ? DigitCount(num / 10, digits + 1) :digits);

        private static long DigitCount(long num, long digits) => ((num > 0) ? DigitCount(num / 10, digits + 1) : digits);

        //public static int Length(this int n) => Math.Abs(DigitCount(n,0));
        public static int Length(this int n) => n.Digits().Count;
        // public static long Length(this long n) => Math.Abs(DigitCount(n, 0));
        public static int Length(this long n) => n.Digits().Count;

        public static bool IsPalindromic(this int n) => n == n.Reverse();

        public static bool IsPalindromic(this long n) => n == n.Reverse();


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
