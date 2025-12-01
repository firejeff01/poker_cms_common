using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 代理盈虧的收益支出類型
    /// </summary>
    public enum IncomeType
    {
        /// <summary>
        /// 遊戲抽成(收入)
        /// </summary>
        [Description("game_profit")]
        Game = 1,

        /// <summary>
        /// 保險收入(收入)
        /// </summary>
        [Description("ev_income")]
        EvIncome = 2,

        /// <summary>
        /// 保險賠付 (支出)
        /// </summary>
        [Description("ev_compensation")]
        EvCompensation = 3,

        /// <summary>
        /// 鑽石抽成(收入)
        /// </summary>
        [Description("diamond_profit")]
        Diamond = 4,

        /// <summary>
        /// 尼碼贈送(收入)
        /// </summary>
        [Description("mod_code_gift")]
        ModCodeGift = 5
    }
}
