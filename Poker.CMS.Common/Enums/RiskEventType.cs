using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 風控事件項目(分類)
    /// </summary>
    public enum RiskEventType
    {
        /// <summary>
        /// 多帳號
        /// </summary>
        [Text("multi_account")]
        [Description("same_device_or_ip_or_fingerprint_multiple_accounts")]
        MultiAccount = 1,

        /// <summary>
        /// 共用帳號
        /// </summary>
        [Text("shared_account")]
        [Description("account_logged_in_multiple_places_short_time")]
        SharedAccount = 7,

        /// <summary>
        /// All-in 異常
        /// </summary>
        [Text("all_in_anomaly")]
        [Description("player_performs_all_in_frequently_higher_than_normal")]
        AllInAnomaly = 12,

        /// <summary>
        /// 單向讓分
        /// </summary>
        [Text("one_way_chips")]
        [Description("chips_flow_one_direction_repeatedly_to_specific_account")]
        OneWayChipTransfer = 9,

        /// <summary>
        /// 安全水位不足				
        /// </summary>
        [Text("margin_too_low")]
        [Description("jackpot_or_pool_amount_below_safety_threshold_requires_topup")]
        MarginTooLow = 16,

        /// <summary>
        /// 賽事異常				
        /// </summary>
        [Text("tournament_anomaly")]
        [Description("cheating_or_system_error_detected_during_tournament")]
        TournamentAnomaly = 11,

        /// <summary>
        /// BOT可疑				
        /// </summary>
        [Text("suspicious_bot")]
        [Description("abnormal_bet_timing_and_amount_pattern_suspected_automation")]
        SuspiciousBot = 8,

        /// <summary>
        /// 異地登入
        /// </summary>
        [Text("suspicious_login")]
        [Description("suspicious_login_from_different_location_or_device")]
        SuspiciousLogin = 27
    }
}
