using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    public enum Suit
    {
        /// <summary>
        /// 梅花
        /// </summary>
        [Description("☘️")]
        Clubs = 0,

        /// <summary>
        /// 方塊
        /// </summary>
        [Description("🔶")]
        Diamonds = 1,

        /// <summary>
        /// 紅心
        /// </summary>
        [Description("❤️")]
        Hearts = 2,

        /// <summary>
        /// 黑桃
        /// </summary>
        [Description("♠")]
        Spades = 3,
    }
}