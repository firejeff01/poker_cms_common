using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    public enum PlayerCategory
    {
        /// <summary>
        /// 高營利玩家
        /// </summary>
        [Text("high_profit")]
        HighProfit = 1,

        /// <summary>
        /// 危險/可疑
        /// </summary>
        [Text("suspicious")]
        Suspicious = 2,

        /// <summary>
        /// AI/BOT
        /// </summary>
        [Text("ai")]
        AI = 3
    }
}
