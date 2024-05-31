using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static int CalculateDateDiffInDays(DateTime date1, DateTime date2)
        {
            TimeSpan result = date1 - date2;

            return Math.Abs(result.Days);
        }
    }
}
