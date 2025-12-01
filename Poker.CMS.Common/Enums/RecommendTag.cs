using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 推薦標籤
    /// </summary>
    public enum RecommendTag
    {
        /// <summary>
        /// 未設定
        /// </summary>
        [Description("Unknown")]
        [Text("unknown")]
        Unknown = 0,

        /// <summary>
        /// 超值
        /// </summary>
        [Description("Great-Value")]
        [Text("great-value")]
        GreatValue = 1,

        /// <summary>
        /// 熱門
        /// </summary>
        [Description("Popular")]
        [Text("popular")]
        Popular = 2,

        [Description("Special-Offer")]
        [Text("special-offer")]
        SpecialOffer = 3
    }
}
