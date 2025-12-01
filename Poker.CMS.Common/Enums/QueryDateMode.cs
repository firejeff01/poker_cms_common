using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    public enum QueryDateMode
    {
        [Description("N")]
        NotIndicated,

        #region 前端可能傳入的查詢條件

        [Description("D")]
        [DateMode("D")]
        Today,

        [Description("W")]
        [DateMode("W")]
        ThisWeek,

        [Description("M")]
        [DateMode("M")]
        ThisMonth,

        #endregion 前端可能傳入的查詢條件

        [Description("D")]
        Yesterday,

        [Description("W")]
        LastWeek,

        [Description("M")]
        LastMonth
    }
}