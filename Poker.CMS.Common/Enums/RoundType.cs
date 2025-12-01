using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    public enum RoundType
    {
        /// <summary>
        /// 翻牌圈
        /// </summary>
        [Description("Flop")]
        Flop = 1,

        /// <summary>
        /// 轉牌圈
        /// </summary>
        [Description("Turn")]
        Turn = 2
    }
}
