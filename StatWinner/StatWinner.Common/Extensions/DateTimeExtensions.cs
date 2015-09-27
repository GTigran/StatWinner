using System;

namespace StatWinner.CommonExtensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Get first day of a week.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static DateTime FirstDayOfWeek(this DateTime date)
        {
            int day = (int) date.DayOfWeek - 1;
            if (day < 0) day = 6;
            return date.Date.AddDays(-day);
        }

        /// <summary>
        /// Get first day of a month.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            int day = date.Day - 1;
            return date.Date.AddDays(-day);
        }

        /// <summary>
        /// Get first day of a quarter.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static DateTime FirstDayOfQuarter(this DateTime date)
        {
            DateTime d = date.Date;
            return new DateTime(d.Year, ((d.Month - 1)/4) + 1, 1);
        }

        /// <summary>
        /// Parse to date and time to DateTime object.
        /// </summary>
        /// <param name="date">Date.</param>
        /// <param name="time">Time.</param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerStepThrough()]
        public static DateTime ParseDateTime(object date, object time)
        {
            DateTime d;
            if (date == DBNull.Value || date == null)
            {
                d = DateTime.MinValue;
            }
            else
            {
                d = (DateTime) date;
            }

            string t;
            if (time == DBNull.Value || string.IsNullOrEmpty((string) time))
            {
                t = "00:00";
            }
            else
            {
                t = (string) time;
            }

            return DateTime.ParseExact(string.Format("{0} {1}", d.ToString("MM/dd/yyyy"), time), "MM/dd/yyyy HH:mm",
                                       null);
        }
    }
}
