using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 金幣類別 (目前只會有1 待確認)
    /// </summary>
    public enum GoldType
    {
        /// <summary>
        /// 體驗幣
        /// </summary>
        [Description("ExCoin")]
        [Text("ex_coin")]
        ExCoin = 0,

        /// <summary>
        /// 金幣
        /// </summary>
        [Description("Coin")]
        [Text("coin")]
        Coin = 1,

        /// <summary>
        /// 泥碼
        /// </summary>
        [Description("DeadChips")]
        [Text("dead_chips")]
        DeadChips = 2,

        /// <summary>
        /// 鑽石
        /// </summary>
        [Description("Diamond")]
        [Text("diamond")]
        Diamond = 3,
    }
}
