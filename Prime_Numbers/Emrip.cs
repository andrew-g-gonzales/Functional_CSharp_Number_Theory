using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Prime_Numbers
{
    public static class Emrip
    {
        public static bool IsEmrip(this int number) => number.IsPrime() == number.Reverse().IsPrime();
    }
}
