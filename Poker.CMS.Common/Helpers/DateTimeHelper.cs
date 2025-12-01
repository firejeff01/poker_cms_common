namespace Poker.CMS.Common.Helpers
{
    public static class DateTimeHelper
    {
        public static bool IsFullWeek(DateTime startDateTime, DateTime endDateTime)
        {
            bool isStartSunday = startDateTime.DayOfWeek == DayOfWeek.Sunday && startDateTime.TimeOfDay == TimeSpan.Zero;

            bool isEndSaturday = endDateTime.DayOfWeek == DayOfWeek.Saturday && endDateTime.TimeOfDay == new TimeSpan(23, 59, 59);

            bool isSevenDays = (endDateTime - startDateTime).TotalDays < 7;

            return isStartSunday && isEndSaturday && isSevenDays;
        }

        public static bool IsFullDayInSameDay(DateTime startDateTime, DateTime endDateTime)
        {
            bool isStartAtMidnight = startDateTime.TimeOfDay == TimeSpan.Zero;

            bool isEndAtEndOfDay = endDateTime.TimeOfDay == new TimeSpan(23, 59, 59);

            bool isSameDay = startDateTime.Date == endDateTime.Date;

            return isStartAtMidnight && isEndAtEndOfDay && isSameDay;
        }

        public static bool IsFullDay(DateTime startDateTime, DateTime endDateTime)
        {
            bool isStartAtMidnight = startDateTime.TimeOfDay == TimeSpan.Zero;

            bool isEndAtEndOfDay = endDateTime.TimeOfDay == new TimeSpan(23, 59, 59);

            return isStartAtMidnight && isEndAtEndOfDay;
        }

        public static bool IsFullMonth(DateTime startDateTime, DateTime endDateTime)
        {
            bool isStartAtFirstOfMonth = startDateTime.Day == 1 && startDateTime.TimeOfDay == TimeSpan.Zero;

            var lastDayOfMonth = DateTime.DaysInMonth(endDateTime.Year, endDateTime.Month);

            bool isEndAtLastOfMonth = endDateTime.Day == lastDayOfMonth && endDateTime.TimeOfDay == new TimeSpan(23, 59, 59);

            bool isSameMonthAndYear = startDateTime.Month == endDateTime.Month && startDateTime.Year == endDateTime.Year;

            return isStartAtFirstOfMonth && isEndAtLastOfMonth && isSameMonthAndYear;
        }
    }
}
