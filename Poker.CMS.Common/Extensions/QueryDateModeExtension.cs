using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.Extensions
{
    public static class QueryDateModeExtension
    {
        public static (DateTime start, DateTime end) GetTimeDuration(this QueryDateMode mode)
        {
            var startTime = DateTime.Today;
            var endTime = DateTime.Today.AddDays(1).AddSeconds(-1);
            var today = DateTime.Today;

            switch (mode)
            {
                case QueryDateMode.Today:
                    break;

                case QueryDateMode.Yesterday:
                    startTime = today.AddDays(-1);
                    endTime = today.AddSeconds(-1);
                    break;

                case QueryDateMode.ThisWeek:
                    startTime = today.StartOfWeek();
                    endTime = today.EndOfWeek();
                    break;

                case QueryDateMode.LastWeek:
                    startTime = today.StartOfLastWeek();
                    endTime = today.EndOfLastWeek();
                    break;

                case QueryDateMode.ThisMonth:
                    startTime = today.StartOfMonth();
                    endTime = today.EndOfMonth();
                    break;

                case QueryDateMode.LastMonth:
                    startTime = today.StartOfLastMonth();
                    endTime = today.EndOfLastMonth();
                    break;
            }

            return (startTime, endTime);
        }

        public static DateTime GetStartTime(this QueryDateMode mode)
        {
            var startTime = DateTime.Today;
            var today = DateTime.Today;
            switch (mode)
            {
                case QueryDateMode.Today:
                    break;

                case QueryDateMode.Yesterday:
                    startTime = today.AddDays(-1);

                    break;

                case QueryDateMode.ThisWeek:
                    startTime = today.StartOfWeek();

                    break;

                case QueryDateMode.LastWeek:
                    startTime = today.StartOfLastWeek();

                    break;

                case QueryDateMode.ThisMonth:
                    startTime = today.StartOfMonth();

                    break;

                case QueryDateMode.LastMonth:
                    startTime = today.StartOfLastMonth();

                    break;
            }
            return startTime;
        }

        public static DateTime GetEndTime(this QueryDateMode mode)
        {
            var endTime = DateTime.Today.AddDays(1).AddSeconds(-1);
            var today = DateTime.Today;

            switch (mode)
            {
                case QueryDateMode.Today:
                    break;

                case QueryDateMode.Yesterday:
                    endTime = today.AddSeconds(-1);
                    break;

                case QueryDateMode.ThisWeek:
                    endTime = today.EndOfWeek();
                    break;

                case QueryDateMode.LastWeek:
                    endTime = today.EndOfLastWeek();
                    break;

                case QueryDateMode.ThisMonth:
                    endTime = today.EndOfMonth();
                    break;

                case QueryDateMode.LastMonth:
                    endTime = today.EndOfLastMonth();
                    break;
            }

            return endTime;
        }

        public static QueryDateMode GetPrevious(this QueryDateMode mode)
        {
            switch (mode)
            {
                case QueryDateMode.Today:
                    return QueryDateMode.Yesterday;

                case QueryDateMode.ThisWeek:
                    return QueryDateMode.LastWeek;

                case QueryDateMode.ThisMonth:
                    return QueryDateMode.LastMonth;

                default:
                    throw new Exception($"QueryDateMode {mode} not valid");
            }
        }
    }
}