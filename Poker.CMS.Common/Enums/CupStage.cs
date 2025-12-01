using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 錦標賽賽事階段
    /// 0=尚未開打, 10=初賽, 20=錢圈賽泡泡時間, 30=錢圈賽,
    /// 40=決賽泡泡時間, 50=決賽, 100=比賽結束排名次, 110=發送獎金, 120=展示排名
    /// </summary>
    public enum CupStage
    {
        [Description("Not-Started")]          // 尚未開打
        [Text("not_started")]
        NotStarted = 0,

        [Description("Preliminary")]          // 初賽
        [Text("preliminary")]
        Preliminary = 10,

        [Description("Money-Bubble")]         // 錢圈賽泡泡時間
        [Text("money_bubble")]
        MoneyBubble = 20,

        [Description("In-the-Money")]         // 錢圈賽
        [Text("in_the_money")]
        InTheMoney = 30,

        [Description("Final-Table-Bubble")]   // 決賽泡泡時間
        [Text("final_table_bubble")]
        FinalTableBubble = 40,

        [Description("Final-Table")]          // 決賽
        [Text("final_table")]
        FinalTable = 50,

        [Description("Results-Finalized")]    // 比賽結束排名次
        [Text("results_finalized")]
        ResultsFinalized = 100,

        [Description("Prize-Payouts")]        // 發送獎金
        [Text("payouts")]
        Payouts = 110,

        [Description("Leaderboard-Display")]  // 展示排名
        [Text("leaderboard_display")]
        LeaderboardDisplay = 120,

        [Description("Cancel-Cup")]            //取消比賽
        [Text("cancel_cup")]
        CancelCup = 900,

        [Description("Refund-In-Progress")]   //退款中
        [Text("refund_in_progress")]
        RefundInProgress = 910,

        [Description("Game-Over")]            // 關閉錦標賽
        [Text("game_over")]
        GameOver = 1000,

        [Description("Invalid")]              //無效
        [Text("invalid")]
        Invalid = 9999,
    }
}
