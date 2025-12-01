using Poker.CMS.Common.Enums;
using Poker.CMS.Common.Helpers.CardHand.Interfaces;

namespace Poker.CMS.Common.Helpers.CardHand
{
    public class PloCardHandClassifier : ITexasHandClassifier
    {
        private static readonly (int hi, int lo)[] StrongAATemplates = new[]
        {
            (13,12),(12,11),(11,10),(10,9),(9,8),(13,11),(12,10)
        };

        public (CardType group, string? hand) Classify(params int[] cards)
        {
            if (cards.Length != 4) return (CardType.NormalHands, null);
            if (!cards.All(CardHelper.IsValidCardNumber)) return (CardType.NormalHands, null);

            var ranks = cards.Select(CardHelper.RankOf).ToArray();
            var suits = cards.Select(v => (v - 1) / 20).ToArray();

            if (IsStrongAAWithKickersDoubleSuited(ranks, suits, out var tag))
                return (CardType.StrongHands, tag);

            if (CardHelper.AllDistinct(ranks) && !CardHelper.AnyConnected(ranks) && CardHelper.IsRainbow(suits))
                return (CardType.WeakHands, "Weak:R1");

            if (CardHelper.HasTripsOrQuads(ranks))
                return (CardType.WeakHands, "Weak:R2");

            if (IsWeakRuleR3(ranks, suits)) return (CardType.WeakHands, "Weak:R3");

            if (IsWeakRuleR4(ranks)) return (CardType.WeakHands, "Weak:R4");

            return (CardType.NormalHands, null);
        }

        public (CardType group, string? hand) Classify(string? hand)
        {
            return (CardType.NormalHands, null);
        }

        private static int CardNumber(int rank, int suit) => rank + suit * 20;

        private static bool IsStrongAAWithKickersDoubleSuited(int[] ranks, int[] suits, out string tag)
        {
            tag = "";
            if (ranks.Count(r => r == 1) != 2) return false;
            var kickers = ranks.Where(r => r != 1).OrderByDescending(r => r == 1 ? 14 : r).ToArray();
            if (kickers.Length != 2) return false;
            var pair = (hi: Math.Max(kickers[0], kickers[1]), lo: Math.Min(kickers[0], kickers[1]));
            if (!StrongAATemplates.Contains(pair)) return false;
            if (!CardHelper.IsDoubleSuited(suits)) return false;
            tag = $"Strong:AA-{CardHelper.RankChar(pair.hi)}{CardHelper.RankChar(pair.lo)}(dbl)";
            return true;
        }

        private static bool IsWeakRuleR3(int[] ranks, int[] suits)
        {
            var groups = ranks.GroupBy(r => r).OrderByDescending(g => g.Count()).ToList();
            if (groups.Count != 3) return false;
            var pair = groups.First();
            if (pair.Count() != 2) return false;
            if (pair.Key > 11 && pair.Key != 1) return false;

            var singleIdx = Enumerable.Range(0, ranks.Length).Where(i => ranks[i] != pair.Key).ToArray();
            if (singleIdx.Length != 2) return false;
            int rA = ranks[singleIdx[0]], rB = ranks[singleIdx[1]];
            int sA = suits[singleIdx[0]], sB = suits[singleIdx[1]];
            if (sA == sB) return false;
            if (CardHelper.IsAdjacent(rA, rB)) return false;
            if (!(rA < 11 && rB < 11)) return false;
            return true;
        }

        private static bool IsWeakRuleR4(int[] ranks)
        {
            if (ranks.Count(r => r == 1) != 1) return false;
            var others = ranks.Where(r => r != 1).ToArray();
            if (others.Any(r => r > 9)) return false;
            for (int i = 0; i < others.Length; i++)
                for (int j = i + 1; j < others.Length; j++)
                    if (CardHelper.IsAdjacent(others[i], others[j])) return false;
            return true;
        }

    }
}
