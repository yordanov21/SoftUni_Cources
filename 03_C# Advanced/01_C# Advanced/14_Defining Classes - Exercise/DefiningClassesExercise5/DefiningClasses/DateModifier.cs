using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public double GetDifferenceInDaysBetweenTwoDates(string firstDate, string secondDate)
        {
            DateTime startDate = DateTime.Parse(firstDate);
            DateTime endDate = DateTime.Parse(secondDate);

            double days = Math.Abs((endDate - startDate).TotalDays);
            return days;
        }
    }
}
