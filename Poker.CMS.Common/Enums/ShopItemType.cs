using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 商店道具類別
    /// </summary>
    public enum ShopItemType
    {
        /// <summary>
        /// 鑽石
        /// </summary>
        [Description("DI")]
        [Text("di")]
        Diamond = 1,

        // /// <summary>
        // /// 款式
        // /// </summary>
        // [Description("BC")]
        // [Text("bc")]
        // Style = 2,

        // /// <summary>
        // /// 表情
        // /// </summary>
        // [Description("EM")]
        // [Text("em")]
        // Emote = 3,

        // /// <summary>
        // /// 撲克牌
        // /// </summary>
        // [Description("PC")]
        // [Text("pc")]
        // Poker = 4,

        // /// <summary>
        // /// 道具
        // /// </summary>
        // [Description("PR")]
        // [Text("pr")]
        // Item = 5,
    }
}