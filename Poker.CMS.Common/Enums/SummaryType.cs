using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    public enum SummaryType
    {
        /// <summary>
        /// 1 小時
        /// </summary>
        [Text("1 Hour")]
        OneHour = 1,

        /// <summary>
        /// 24 小時
        /// </summary>
        [Text("24 Hours")]
        TwentyFourHours = 2,
    }
}
