using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using  static Xunit.Assert;
using Common;

namespace Common_Tests
{
    public class PerfectNumberTests
    {

        [Theory]
        [InlineData(6)]//Early Greek mathematicians knew only of these first 4 perfect numbers
        [InlineData(28)]
        [InlineData(496)]
        [InlineData(8128)]//Nichomatus discovered 8,128 by the year A.D. 100
        [InlineData(33550336)]
        [InlineData(8589869056)]//by Italian mathematician Pietro Cataldi in 1588.
        [InlineData(137438691328)]//by Italian mathematician Pietro Cataldi in 1588.
        public void IsPerfectNumberTest(int number) => True(number.IsPerfectNumber() && number.IsEven());

        /*All known perfect numbers are even; it is not yet known whether an odd prime exists or is even possible. 
         * 
         * English mathematician James Joseph Sylvester wrote "…a prolonged meditation on the subject has satisfied 
         * me that the existence of any one such [odd perfect number]—its escape, so to say, from the complex web 
         * of conditions which hem it in on all sides—would be little short of a miracle."
         */
    }
}
