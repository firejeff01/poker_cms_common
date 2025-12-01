using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 虛寶主類別
    /// </summary>
    public enum VirtualItemMainType
    {
        /// <summary>
        /// 一般道具
        /// </summary>
        [Text("general")]
        General = 0,

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
        Consumable = 10,

        /// <summary>
        /// 特別
        /// </summary>
        [Text("special")]
        Special = 99,
    }
}
