using Poker.CMS.Common.Enums;
using Poker.CMS.Common.Helpers.CardHand.Interfaces;

namespace Poker.CMS.Common.Helpers.CardHand
{
    public class ShortCardHandClassifier : ITexasHandClassifier
    {
        private static readonly HashSet<string> Strong = new(StringComparer.OrdinalIgnoreCase)
        {
            "AA","KK","QQ","AKs","AQs","JJ","TT","AKo","AQo","KQo",
            "KQs","JTs","T9s","98s","87s","AJs","KJs"
        };

        private static readonly HashSet<string> Weak = new(StringComparer.OrdinalIgnoreCase)
        {
            "K7o","A8o","A9o","K8o","K9o","Q8o","Q9o","J7o","J8o","J9o",
            "T7o","T8o","T9o","98o","87o","76o","66","77","88","A7s",
            "A8s","A9s","K8s","Q8s","J7s"
        };

        /// <summary>
        /// 先轉字串，再分類
        /// </summary>
        public (CardType group, string? hand) Classify(params int[] cards)
        {
            var hand = ParseHandString(cards);
            return Classify(hand);
        }

        /// <summary>
        /// 根據牌組字串分類
        /// </summary>
        public (CardType group, string? hand) Classify(string? hand)
        {
            if (string.IsNullOrEmpty(hand)) return (CardType.NormalHands, null);

            if (Strong.Contains(hand)) return (CardType.StrongHands, hand);
            if (Weak.Contains(hand)) return (CardType.WeakHands, hand);

            return (CardType.NormalHands, null);
        }

        /// <summary>
        /// 將兩張牌(數字)轉成字串 (例如 "AKs", "QJo", "TT")
        /// </summary>
        private string? ParseHandString(int[] cards)
        {
            if (cards.Length != 2) return null;
            if (!cards.All(CardHelper.IsValidCardNumber)) return null;

            int r1 = CardHelper.RankOf(cards[0]);
            int r2 = CardHelper.RankOf(cards[1]);

            // 對子
            if (r1 == r2)
            {
                return $"{CardHelper.RankChar(r1)}{CardHelper.RankChar(r2)}"; // "AA", "99"
            }

            // 非對子
            int hi = CardHelper.OrderValue(r1) >= CardHelper.OrderValue(r2) ? r1 : r2;
            int lo = (hi == r1) ? r2 : r1;

            string core = $"{CardHelper.RankChar(hi)}{CardHelper.RankChar(lo)}";

            // 判斷花色
            bool suited = CardHelper.SuitOf(cards[0]) == CardHelper.SuitOf(cards[1]);
            return core + (suited ? "s" : "o");
        }
    }
}
