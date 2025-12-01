using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 錦標賽-遊戲伺服器(遊戲類型)
    /// </summary>
    public enum CupServerId
    {
        /// <summary>
        /// 德州撲克
        /// </summary>
        [Description("NLH")]
        [Text("nlh")]
        NLH = 101,

        /// <summary>
        /// 短牌
        /// </summary>
        [Description("6+")]
        [Text("six_plus")]
        SixPlus = 102,

        /// <summary>
        /// 奧馬哈
        /// </summary>
        [Description("PLO")]
        [Text("plo")]
        PLO = 103
    }
}
