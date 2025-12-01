using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.Helpers.CardHand.Interfaces
{
    public interface ICardHandClassifier
    {
        CardType HandCardType(string card, int serverId);
    }

    public interface ITexasHandClassifier
    {
        (CardType group, string? hand) Classify(params int[] cards);
        (CardType group, string? hand) Classify(string? hand);
    }
}
