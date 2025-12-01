namespace Poker.CMS.Common.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 取得本周開始的那天 (周日)
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime date)
        {
            // Calculate the number of days to subtract to get to the previous Sunday
            int daysToSubtract = (int)date.DayOfWeek;
            return date.AddDays(-daysToSubtract).Date;
        }

        /// <summary>
        /// 取得本周結束的那天 (周六) 時間取到 23:59:59
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime date)
        {
            // Get the start of the week
            DateTime startOfWeek = date.StartOfWeek();
            // Calculate the end of the week (Saturday)
            return startOfWeek.AddDays(7).Date.AddSeconds(-1);
        }

        /// <summary>
        /// 取得本月第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime StartOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        /// <summary>
        /// 取得本月最後一天 時間取到 23:59:59
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime date)
        {
            return date.StartOfMonth().AddMonths(1).AddSeconds(-1);
        }

        /// <summary>
        /// 取得上週開始的第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime StartOfLastWeek(this DateTime date)
        {
            return date.StartOfWeek().AddDays(-7);
        }

        /// <summary>
        /// 取得上週最後一天 時間取到 23:59:59
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime EndOfLastWeek(this DateTime date)
        {
            return date.EndOfWeek().AddDays(-7);
        }

        /// <summary>
        /// 取得上個月第一天
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime StartOfLastMonth(this DateTime date)
        {
            return date.StartOfMonth().AddMonths(-1);
        }

        /// <summary>
        /// 取得上個月月最後一天 時間取到 23:59:59
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime EndOfLastMonth(this DateTime date)
        {
            return date.StartOfMonth().AddSeconds(-1);
        }

        /// <summary>
        /// 取得 migration 資料截止時間
        /// 例如: runEveryMinutes 30, 00:00:01 → 00:00:00
        /// </summary>
        /// <param name="jobStartTime"></param>
        /// <param name="runEveryMinutes"></param>
        /// <returns></returns>
        public static DateTime MigrationEndTime(this DateTime jobStartTime, int runEveryMinutes)
        {
            // 將分鐘數向下取最近的間隔
            int roundedMinutes = (jobStartTime.Minute / runEveryMinutes) * runEveryMinutes;

            // 將秒數重設為 0 並計算 endTime
            DateTime endTime = new DateTime(
                jobStartTime.Year,
                jobStartTime.Month,
                jobStartTime.Day,
                jobStartTime.Hour,
                roundedMinutes,
                0
            );

            return endTime;
        }
    }
}
