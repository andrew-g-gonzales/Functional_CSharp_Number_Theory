using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Puzzles
{   /*Taken from the book:  "Professor Stewart's Hoard of Mathematical Treasures"
    p. 38: "The number 153 is equal to the sum of the cubes of it's digits...  There are three other 3-digit numbers with the same propery"

    p. 283:  "The other 3-digit numbers that are equal to the sum of the cubes of their digits are 370, 371 and 407...."

    "If the digits are a, b, and c then we have to sole 100a + 10b + c = a^3 + b^3 + c^3"

    "with 0 < =a,b,  c<=9 and a > 0.  That's 900 possibilities, so a systematic search will find the answer"

    "The work can be reduced by using some fairly simple tricks:"
    
    "For instance, if you divide a perfect cube by 9, the remainder is 0,1 or 8"

    "If you divide 100 or 10 by 9, the raminder is 1"

    "so a + b + c = a^3 + b^3 + c^3 leave the same remainder on division by 9.
    
    Eliminating cases where the digits are too small or big to work a + b + c has to be one of 7, 8, 9, 10, 11, 16, 17, 18, 19, 20."

    ""
 *     */
    public static class DigitalCubes
    {

        public static IEnumerable<int> NumbersEqualToSumOfCubesFiltered(int start, int end, List<int> acceptableSumofDigits) =>
                 Enumerable.Range(start, end)
                 .Where(x => (ContainsSumOfSequence(x, acceptableSumofDigits)) 
                                                && SumAndSumCubedSameRemainer(x, 9)
                                                                                && NumEqualsCubedDigitsSummed(x));

        public static IEnumerable<int> NumbersEqualToSumOfCubesFilteredSome(int start, int end) =>
                Enumerable.Range(start, end)
                .Where(x => SumAndSumCubedSameRemainer(x,9) && NumEqualsCubedDigitsSummed(x));


        public static IEnumerable<int> NumbersEqualToSumOfCubes(int start, int end) =>
                Enumerable.Range(start, end)
               .Where(x => NumEqualsCubedDigitsSummed(x));

        public static bool NumEqualsCubedDigitsSummed(int num) => (num == num.GetDigitsToPowerOf(3).Sum());

        public static bool SumAndSumCubedSameRemainer(int num, int numerator) => (num.Digits().Sum() % numerator == num.GetDigitsToPowerOf(3).Sum() % numerator);

        public static bool ContainsSumOfSequence(int num, List<int> acceptableSumofDigits) => (acceptableSumofDigits.Contains(num.Digits().Sum()));
    }

    
}
