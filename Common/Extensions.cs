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

        public static bool IsPrime(this int n) => n > 1 && n.Factor().First() == n;

        public static bool IsPrime(this long n) => n > 1 && n.Factor().First() == n;

        public static IEnumerable<int> Divisors(this int n) => Enumerable.Range(1, n).TakeWhile(i => n % i == 0);


        public static IReadOnlyList<int> Digits(this int n) =>
                                        n.ToString().ToCharArray()
                                            .Cast<string>()
                                            .Select(Int32.Parse)
                                            .ToList();

        public static IReadOnlyList<long> Digits(this long n) =>
                                       n.ToString().ToCharArray()
                                           .Cast<string>()
                                           .Select(Int64.Parse)
                                           .ToList();

        public static bool IsPerfectSquare(this long n) => n.Factor().GroupBy(f => f).All(g => g.Count() % 2 == 0);

        public static bool IsPerfectSquare(this int n) => n.Factor().GroupBy(f => f).All(g => g.Count() % 2 == 0);

        public static bool IsPerfectPower(this int n, int power) => n.Factor().GroupBy(f => f).All(g => g.Count() % power == 0);

        public static bool IsPerfectPower(this long n, int power) => n.Factor().GroupBy(f => f).All(g => g.Count() % power == 0);

        public static bool IsPerfectNumber(this int number) => number.Divisors().Sum() == number;
      
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

        public static int Length(this int n) => n.Digits().Count();

        public static long Length(this long n) => n.Digits().Count();

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
