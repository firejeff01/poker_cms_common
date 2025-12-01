using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 錦標賽賽事進行狀況
    /// 0=未進行比賽, 1000=預熱, 2000=報名階段, 3000=比賽, 4000=比賽結束
    /// </summary>
    public enum CupStatus
    {
        [Description("Not-Started")]   // 未進行比賽
        [Text("not_started")]
        NotStarted = 0,

        [Description("Warm-up")]       // 預熱
        [Text("warmup")]
        Warmup = 1000,

        [Description("Registration")]  // 報名階段
        [Text("registration")]
        Registration = 2000,

        [Description("In-Progress")]   // 比賽
        [Text("in_progress")]
        InProgress = 3000,

        [Description("Finished")]      // 比賽結束
        [Text("finished")]
        Finished = 4000,
    }
}
