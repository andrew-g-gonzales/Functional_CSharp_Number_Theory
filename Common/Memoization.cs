using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Memoization
    {
        public static Func<A, R> Memoize<A, R>(this Func<A, R> f)
        {
            var map = new Dictionary<A, R>();
            return a =>
            {
                R value;
                if (map.TryGetValue(a, out value))
                    return value;
                value = f(a);
                map.Add(a, value);
                return value;
            };
        }

        public static Func<A,B, R> Memoize<A,B, R>(this Func<A,B, R> f)
        {
            var map = new Dictionary<Tuple<A,B>, R>();
            return (a,b) =>
            {
                var tuple = new Tuple<A, B>(a,b);
                R value;
                if (map.TryGetValue(tuple, out value))
                {
                    return value;
                }
                else
                {
                    value = f(a, b);
                    map.Add(new Tuple<A, B>(a, b), value);
                    return value;
                }
            };
        }
    }
}
