using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 風控事件狀況等級
    /// </summary>
    public enum RiskEventLv
    {
        /// <summary>
        /// 一般			
        /// </summary>
        [Text("normal")]
        Normal = 1,

        /// <summary>
        /// 中度
        /// </summary>
        [Text("medium")]
        Medium = 4,

        /// <summary>
        /// 危險
        /// </summary>
        [Text("high")]
        High = 7,
    }
}
