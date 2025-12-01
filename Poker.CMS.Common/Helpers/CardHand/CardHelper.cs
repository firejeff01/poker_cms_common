using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.Helpers.CardHand
{
    public static class CardHelper
    {
        public static bool IsValidCardNumber(int v)
        {
            int r = v % 20;
            int s = (v - 1) / 20;
            return r >= 1 && r <= 13 && s >= 0 && s <= 3;
        }

        public static int SuitOf(int v) => (v - 1) / 20;
        public static int RankOf(int v) => v % 20;
        public static int OrderValue(int r) => r == 1 ? 14 : r;
        public static char RankChar(int r) => r switch
        {
            13 => 'K',
            12 => 'Q',
            11 => 'J',
            10 => 'T',
            1 => 'A',
            _ => (char)('0' + r)
        };

        public static bool AllDistinct(int[] ranks) => ranks.Distinct().Count() == 4;

        public static bool AnyConnected(int[] ranks)
        {
            for (int i = 0; i < ranks.Length; i++)
                for (int j = i + 1; j < ranks.Length; j++)
                    if (IsAdjacent(ranks[i], ranks[j])) return true;
            return false;
        }

        public static bool IsAdjacent(int r1, int r2)
        {
            int h1 = r1 == 1 ? 14 : r1;
            int h2 = r2 == 1 ? 14 : r2;
            if (Math.Abs(h1 - h2) == 1) return true;
            return (r1 == 1 && r2 == 2) || (r1 == 2 && r2 == 1);
        }

        public static bool IsRainbow(int[] suits) => suits.Distinct().Count() == 4;

        public static bool IsDoubleSuited(int[] suits)
        {
            var counts = suits.GroupBy(s => s).Select(g => g.Count()).OrderByDescending(x => x).ToArray();
            return counts.Length == 2 && counts[0] == 2 && counts[1] == 2;
        }

        public static bool HasTripsOrQuads(int[] ranks) => ranks.GroupBy(r => r).Any(g => g.Count() >= 3);
    }
}
