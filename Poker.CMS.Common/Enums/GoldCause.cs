using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 金流異動原因
    /// </summary>
    public enum GoldCause
    {
        /// <summary>
        /// 上分
        /// </summary>
        [Description("Deposit")]
        [Text("deposit")]
        Deposit = 1,

        /// <summary>
        /// 下分
        /// </summary>
        [Description("Withdrawal")]
        [Text("withdrawal")]
        Withdrawal = 2,

        /// <summary>
        /// 牌局結算
        /// </summary>
        [Description("Settle")]
        [Text("settle")]
        Settle = 4,

        /// <summary>
        /// 商城消費
        /// </summary>
        [Description("ShopConsume")]
        [Text("shop_consume")]
        ShopConsume = 5,

        /// <summary>
        /// 商城取得
        /// </summary>
        [Description("ShopIncome")]
        [Text("shop_income")]
        ShopIncome = 6,

        /// <summary>
        /// 購買私人桌上限
        /// </summary>
        [Description("BuyPrivateTableLimit")]
        [Text("buy_private_table_limit")]
        BuyPrivateTableLimit = 7,

        /// <summary>
        /// 補體驗幣
        /// </summary>
        [Description("AddTrialCoins")]
        [Text("add_trial_coins")]
        AddTrialCoins = 8,

        /// <summary>
        /// 首次消費贈送
        /// </summary>
        [Description("FirstBuyBouns")]
        [Text("first_buy_bouns")]
        FirstBuyBouns = 9,

        /// <summary>
        /// 發給分身金幣
        /// </summary>
        [Description("IssueGoldToClones")]
        [Text("issue_gold_clones")]
        IssueGoldToClones = 10,

        /// <summary>
        /// 取出分身金幣
        /// </summary>
        [Description("TakeOutGoldFormClones")]
        [Text("take_out_gold_form_clones")]
        TakeOutGoldFormClones = 11,

        /// <summary>
        /// 單一錢包買入金幣 (從單一錢包取錢)
        /// </summary>
        [Description("SingleWalletBuy")]
        [Text("single_wallet_buy")]
        SingleWalletBuy = 12,

        /// <summary>
        /// 單一錢包回收金幣 (歸還給單一錢包)
        /// </summary>
        [Description("SingleWalletReturn")]
        [Text("single_wallet_return")]
        SingleWalletReturn = 13,

        /// <summary>
        /// 前注
        /// </summary>
        [Text("ante")]
        Ante = 19,

        /// <summary>
        /// 小盲注
        /// </summary>
        [Text("small_blinds")]
        SmallBlinds = 20,

        /// <summary>
        /// 大盲注
        /// </summary>
        [Text("big_blinds")]
        BigBlinds = 21,

        /// <summary>
        /// 讓牌
        /// </summary>
        [Text("check")]
        Check = 22,

        /// <summary>
        /// 押注
        /// </summary>
        [Text("bet")]
        Bet = 23,

        /// <summary>
        /// 跟注
        /// </summary>
        [Text("call")]
        Call = 24,

        /// <summary>
        /// 加注
        /// </summary>
        [Text("raise")]
        Raise = 25,

        /// <summary>
        /// 蓋牌
        /// </summary>
        [Text("fold")]
        Fold = 26,

        /// <summary>
        /// 全押
        /// </summary>
        [Text("all_in")]
        AllIn = 27,

        /// <summary>
        /// EV保險收益
        /// </summary>
        [Description("EvCashOutIncome")]
        [Text("ev_cashout_income")]
        EvCashOutIncome = 28,

        /// <summary>
        /// 金幣返還
        /// </summary>
        [Text("coin_refund")]
        CoinRefund = 29,

        /// <summary>
        /// 贏牌(EV保險收益)
        /// </summary>
        [Description("WinEvCashOut")]
        [Text("win_ev_cashout")]
        WinEvCashOut = 30,

        /// <summary>
        /// 分牌請求
        /// </summary>
        [Text("split_request")]
        SplitRequest = 31,

        /// <summary>
        /// 分牌是否同意
        /// </summary>
        [Text("split_approval")]
        SplitApproval = 32,

        /// <summary>
        /// 購買EV
        /// </summary>
        [Text("buy_ev")]
        BuyEv = 33,

        /// <summary>
        /// 當前獎池總金額
        /// </summary>
        [Text("current_pot_amount")]
        CurrentPotAmount = 34,

        /// <summary>
        /// 強制押1BB
        /// </summary>
        [Text("force_bet_1bb")]
        ForceBet1Bb = 35,

        /// <summary>
        /// 購買時間銀行
        /// </summary>
        [Description("BuyTimeBank")]
        [Text("buy_time_bank")]
        BuyTimeBank = 36,

        /// <summary>
        /// 購買時間銀行退款
        /// </summary>
        [Description("BuyTimeBankRefund")]
        [Text("buy_time_bank_refund")]
        BuyTimeBankRefund = 37,

        /// <summary>
        /// 開私人房
        /// </summary>
        [Description("OpenPrivateRoom")]
        [Text("open_private_room")]
        OpenPrivateRoom = 38,

        /// <summary>
        /// 房主分成
        /// </summary>
        [Description("Commission")]
        [Text("commission")]
        Commission = 39,

        /// <summary>
        /// 房主提領
        /// </summary>
        [Description("WithdrawalByMaster")]
        [Text("withdrawal_by_master")]
        WithdrawalByMaster = 40,

        /// <summary>
        /// 機器人補幣
        /// </summary>
        [Description("IsirAddCoin")]
        [Text("isir_add_coin")]
        IsirAddCoin = 98,

        /// <summary>
        /// 管理者調整
        /// </summary>
        [Description("GMAdjust")]
        [Text("gm_adjust")]
        GMAdjust = 99,

        /// <summary>
        /// 後台增加保證金
        /// </summary>
        [Description("CMSAddDeposit")]
        [Text("cms_add_deposit")]
        CMSAddDeposit = 100,

    }
}