using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 保證金狀態
    /// </summary>
    public enum AgentDepositStatus
    {
        /// <summary>
        /// 安全
        /// </summary>
        [Text("safe")]
        Safe = 0,

        /// <summary>
        /// 警告
        /// </summary>
        [Text("warning")]
        Warning = 1,

        /// <summary>
        /// 低於門檻
        /// </summary>
        [Text("below_threshold")]
        BelowThreshold = 2,
    }
}
