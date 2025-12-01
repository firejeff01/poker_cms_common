using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 金流異動原因所屬類型
    /// </summary>
    public enum GoldCauseCategory
    {
        /// <summary>
        /// 牌桌
        /// </summary>
        [Description("GoldCauseCategoryByTable")]
        Table = 1,

        /// <summary>
        /// 商店消費
        /// </summary>
        [Description("GoldCauseCategoryByShop")]
        Shop = 2,

        /// <summary>
        /// 系統
        /// </summary>
        [Description("GoldCauseCategoryBySystem")]
        System = 3,
    }

    /// <summary>
    /// 金流異動原因輔助類別
    /// </summary>
    public static class GoldCauseHelper
    {
        // 定義 GoldCause 到 GoldCauseCategory 的映射
        private static readonly Dictionary<GoldCause, GoldCauseCategory> GoldCauseToCategoryMap = new()
        {
            // 牌桌相關
            { GoldCause.Deposit, GoldCauseCategory.Table },
            { GoldCause.Withdrawal, GoldCauseCategory.Table },
            { GoldCause.Settle, GoldCauseCategory.Table },
            { GoldCause.EvCashOutIncome, GoldCauseCategory.Table },
            { GoldCause.WinEvCashOut, GoldCauseCategory.Table },
            { GoldCause.BuyTimeBank, GoldCauseCategory.Table },
            { GoldCause.BuyTimeBankRefund, GoldCauseCategory.Table },
            { GoldCause.OpenPrivateRoom, GoldCauseCategory.Table },
            { GoldCause.Commission, GoldCauseCategory.Table },
            { GoldCause.WithdrawalByMaster, GoldCauseCategory.Table },

            // 商店相關
            { GoldCause.ShopConsume, GoldCauseCategory.Shop },
            { GoldCause.ShopIncome, GoldCauseCategory.Shop },
            { GoldCause.BuyPrivateTableLimit, GoldCauseCategory.Shop },
            { GoldCause.FirstBuyBouns, GoldCauseCategory.Shop },

            // 系統相關
            { GoldCause.AddTrialCoins, GoldCauseCategory.System },
            { GoldCause.IsirAddCoin, GoldCauseCategory.System },
            { GoldCause.GMAdjust, GoldCauseCategory.System },
            { GoldCause.CMSAddDeposit, GoldCauseCategory.System }
        };

        /// <summary>
        /// 根據金流異動原因獲取所屬類型
        /// </summary>
        /// <param name="cause">金流異動原因</param>
        /// <returns>對應的金流異動原因類型</returns>
        public static GoldCauseCategory GetCategory(GoldCause cause)
        {
            return GoldCauseToCategoryMap.TryGetValue(cause, out var category)
                ? category
                : GoldCauseCategory.Table; // 預設為 Table
        }
    }
}
