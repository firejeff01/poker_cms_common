using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 商品子類別
    /// </summary>
    public enum ShopV2SubType
    {
        /// <summary>
        /// 禮包
        /// </summary>
        [Text("gift")]
        Gift = 0,

        /// <summary>
        /// 角色
        /// </summary>
        [Text("character")]
        Character = 1,

        /// <summary>
        /// 表情
        /// </summary>
        [Text("emote")]
        Emote = 2,

        /// <summary>
        /// 消耗品
        /// </summary>
        [Text("consumable")]
        Consumable = 10
    }
}
