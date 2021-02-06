using System;
using System.Collections.Generic;
using System.Text;

namespace ProblemDateModifier
{
    public static class DateModifier
    {
        public static int GetDiffBetweenDatesInDays(string firstDateStr, string secondDateStr)
        {
            DateTime firstDate = DateTime.Parse(firstDateStr);
            DateTime secondDate = DateTime.Parse(secondDateStr);

            TimeSpan diff = firstDate - secondDate;
            int days = Math.Abs(diff.Days);

            return days;
        }
    }
}
