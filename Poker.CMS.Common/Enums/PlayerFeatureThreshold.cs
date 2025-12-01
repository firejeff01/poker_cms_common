using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    public enum PlayerFeatureThreshold
    {
        /// <summary>
        /// 多帳號
        /// </summary>
        [Text("multi_account")]
        MultiAccount = 1,

        /// <summary>
        /// 共用帳號
        /// </summary>
        [Text("shared_account")]
        SharedAccount = 7,

        /// <summary>
        /// All-in 異常
        /// </summary>
        [Text("all_in_anomaly")]
        AllInAnomaly = 12,

        /// <summary>
        /// 單向讓分
        /// </summary>
        [Text("one_way_chips")]
        OneWayChipTransfer = 9,

        /// <summary>
        /// 安全水位不足				
        /// </summary>
        [Text("margin_too_low")]
        MarginTooLow = 16,

        /// <summary>
        /// 賽事異常				
        /// </summary>
        [Text("tournament_anomaly")]
        TournamentAnomaly = 11,

        /// <summary>
        /// BOT可疑				
        /// </summary>
        [Text("suspicious_bot")]
        SuspiciousBot = 8,

        /// <summary>
        /// 異地登入
        /// </summary>
        [Text("suspicious_login")]
        SuspiciousLogin = 27,

        /// <summary>
        /// 玩家等級
        /// </summary>
        [Text("player_level")]
        PlayerLevel = 0
    }
}
