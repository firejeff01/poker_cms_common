using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    public enum PokerCardType
    {
        /// <summary>高牌</summary>
        [Text("high_card")]
        HighCard = 0,

        /// <summary>對子</summary>
        [Text("one_pair")]
        OnePair = 1,

        /// <summary>雙對</summary>
        [Text("two_pair")]
        TwoPair = 2,

        /// <summary>三條</summary>
        [Text("three_of_a_kind")]
        ThreeOfAKind = 3,

        /// <summary>順子</summary>
        [Text("straight")]
        Straight = 4,

        /// <summary>同花</summary>
        [Text("flush")]
        Flush = 5,

        /// <summary>葫蘆</summary>
        [Text("full_house")]
        FullHouse = 6,

        /// <summary>鐵支（四條）</summary>
        [Text("four_of_a_kind")]
        FourOfAKind = 7,

        /// <summary>同花順</summary>
        [Text("straight_flush")]
        StraightFlush = 8,

        /// <summary>同花大順（皇家同花順）</summary>
        [Text("royal_flush")]
        RoyalFlush = 9
    }
}
