using System;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int GetDayDifference(string date1, string date2) 
            => Math.Abs((DateTime.Parse(date1) - DateTime.Parse(date2)).Days);
    }
}
