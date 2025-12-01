using Poker.CMS.Common.Enums;
using Poker.CMS.Common.Helpers.CardHand.Interfaces;

namespace Poker.CMS.Common.Helpers.CardHand
{
    public class LongCardHandClassifier : ITexasHandClassifier
    {
        private static readonly HashSet<string> Strong = new(StringComparer.OrdinalIgnoreCase)
        {
            "AA",  "KK",  "QQ", "AKs", "JJ", "AQs", "KQs", "AJs", "KJs", "TT",
            "AKo", "ATs", "QJs", "KTs", "QTs", "JTs", "99", "AQo", "A9s",
            "KQo", "88", "K9s", "T9s"
        };

        private static readonly HashSet<string> Weak = new(StringComparer.OrdinalIgnoreCase)
        {
            "75o","Q7o","K4o","K3o","96o","K2o","64o","Q6o","53o","85o",
            "T6o","Q5o","43o","Q4o","Q3o","74o","Q2o","J6o","63o","J5o",
            "95o","52o","J4o","J3o","42o","J2o","84o","T5o","T4o","32o",
            "T3o","73o","T2o","62o","94o","93o","92o","83o","82o","72o"
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
