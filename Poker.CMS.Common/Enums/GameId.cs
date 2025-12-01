using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 遊戲類型
    /// </summary>
    public enum GameId
    {
        /// <summary>
        /// 德州撲克
        /// </summary>
        [Text("Texas Hold'em")]
        TexasHoldem = 1,
    }
}
