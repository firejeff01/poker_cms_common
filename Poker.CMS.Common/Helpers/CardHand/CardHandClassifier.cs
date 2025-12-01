using Poker.CMS.Common.Enums;
using System.Globalization;
using Poker.CMS.Common.Helpers.CardHand.Interfaces;

namespace Poker.CMS.Common.Helpers.CardHand
{
    public class CardHandClassifier : ICardHandClassifier
    {
        private readonly ITexasHandClassifier _longCard;
        private readonly ITexasHandClassifier _shortCard;
        private readonly ITexasHandClassifier _ploCard;
        private readonly Dictionary<int, ITexasHandClassifier> _map;

        public CardHandClassifier()
        {
            _longCard = new LongCardHandClassifier();
            _shortCard = new ShortCardHandClassifier();
            _ploCard = new PloCardHandClassifier();

            _map = new Dictionary<int, ITexasHandClassifier>
            {
                { (int)ServerId.NLH, _longCard },
                { (int)ServerId.AoFNLH, _longCard },
                { (int)ServerId.SixPlus, _shortCard },
                { (int)ServerId.PLO, _ploCard },
                { (int)ServerId.AoFPLO, _ploCard }
            };
        }

        public CardType HandCardType(string cardOrHand, int serverId)
        {
            var (group, _) = ClassifyCardOrHand(cardOrHand, serverId);
            return group;
        }

        private (CardType group, string? hand) ClassifyCardOrHand(string cardOrHand, int serverId)
        {
            if (string.IsNullOrWhiteSpace(cardOrHand))
                return (CardType.NormalHands, null);

            if (!_map.TryGetValue(serverId, out var classifier))
                return (CardType.NormalHands, null);

            // 嘗試解析成數字牌
            var numbers = ParseCardString(cardOrHand);
            if (numbers.Length > 0)
                return classifier.Classify(numbers);

            // 否則，當作文字牌
            return classifier.Classify(cardOrHand);
        }

        private static int[] ParseCardString(string card)
        {
            var parts = card.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var cards = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], NumberStyles.Integer, CultureInfo.InvariantCulture, out cards[i]))
                    return Array.Empty<int>();
            }

            return cards;
        }
    }
}
