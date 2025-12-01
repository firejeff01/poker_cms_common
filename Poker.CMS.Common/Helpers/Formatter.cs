using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.Helpers
{
    public static class Formatter
    {
        /// <summary>
        /// 百分比轉換成db數字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetSplitValue(decimal value)
        {
            var denominator = 10000;
            var percent = 100;

            return (int)((value / percent) * denominator);
        }

        /// <summary>
        /// db數字轉換成百分比
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal GetDbSplitValue(long value)
        {
            var denominator = 10000;
            var percent = 100;

            return ((decimal)value / denominator) * percent;
        }

        /// <summary>
        /// 取得百分比數字字串 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal GetSplit(long value)
        {
            var denominator = 10000;
            var percent = 100;

            return ((decimal)value / denominator) * percent;
        }

        /// <summary>
        /// 傳成金額的統一格式字串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetAmount(long value)
        {
            var denominator = 10000;
            return ((decimal)value / denominator).ToString("N4");
        }

        /// <summary>
        /// 傳成金額的數字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal GetAmountValue(long value)
        {
            var denominator = 10000;
            return (decimal)value / denominator;
        }

        public static long GetDbAmountValue(decimal value)
        {
            var denominator = 10000;
            return (long)(value * denominator);
        }

        /// <summary>
        /// 轉成百分比的統一格式字串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetPercentage(long value)
        {
            var denominator = 10000;
            return ((decimal)value / denominator).ToString("P2");
        }

        /// <summary>
        /// 轉百分比的數字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal GetPercentageValue(long value)
        {
            var denominator = 10000;
            return (decimal)value / denominator;
        }

        /// <summary>
        /// 轉成當地時間統一格式字串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetLocalDateTime(DateTime value)
        {
            return value.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 轉成時間統一格式字串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDateTimeString(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 報表跟前區間比較的百分比字串
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="pastValue"></param>
        /// <returns></returns>
        public static string GetIncreasePercentage(long newValue, long pastValue)
        {
            if (newValue == pastValue)
            {
                return "0%";

            }
            else if (pastValue == 0 && newValue > 0)
            {
                return "∞";
            }
            else if (pastValue == 0)
            {
                return "0%";
            }

            return Math.Abs((double)(newValue - pastValue) / pastValue).ToString("P2");
        }

        /// <summary>
        /// 新資料與舊資料的增加百分比是否為正數 ( 0% 也算正數 )
        /// </summary>
        /// <param name="percentString"></param>
        /// <returns></returns>
        public static bool IsIncreasePositive(string percentString)
        {
            if (percentString == "∞")
            {
                return true;
            }
            else if (percentString == "0.00%")
            {
                return true;
            }
            else if (percentString.StartsWith("-"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 資料成長趨勢
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="oldValue"></param>
        /// <returns></returns>
        public static DataTrend GetDataTrend(long newValue, long oldValue)
        {
            if (newValue == oldValue)
            {
                return DataTrend.Same;
            }
            else if (newValue > oldValue)
            {
                return DataTrend.Up;
            }
            else
            {
                return DataTrend.Down;
            }
        }

        /// <summary>
        /// 將日期時間轉換為 Unix 時間戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long ToUnixTimestamp(DateTime dateTime)
        {
            return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
        }

        public static string FormatNegativeAmount(IncomeType incomeType, long amount)
        {
            if (incomeType == IncomeType.EvCompensation)
            {
                return Formatter.GetAmount(amount);
            }
            else
            {
                return "--";
            }
        }

        public static decimal FormatNegativeAmountDecimal(IncomeType incomeType, long amount)
        {
            if (incomeType == IncomeType.EvCompensation)
            {
                return Formatter.GetAmountValue(amount);
            }
            else
            {
                return 0;
            }
        }

        public static string FormatPositiveAmount(IncomeType incomeType, long amount)
        {
            if (incomeType == IncomeType.EvCompensation)
            {
                return "--";
            }
            else
            {
                return Formatter.GetAmount(amount);
            }
        }

        public static decimal FormatPositiveAmountDecimal(IncomeType incomeType, long amount)
        {
            if (incomeType == IncomeType.EvCompensation)
            {
                return 0;
            }
            else
            {
                return Formatter.GetAmountValue(amount);
            }
        }
    }
}