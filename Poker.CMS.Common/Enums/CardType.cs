using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 遊戲類型
    /// </summary>
    public enum CardType
    {
        /// <summary>
        /// 強牌
        /// </summary>
        [Text("strong_hands")]
        StrongHands = 1,

        /// <summary>
        /// 弱牌
        /// </summary>
        [Text("weak_hands")]
        WeakHands = 2,

        /// <summary>
        /// 一般牌
        /// </summary>
        [Text("normal_hands")]
        NormalHands = 3,
    }
}
