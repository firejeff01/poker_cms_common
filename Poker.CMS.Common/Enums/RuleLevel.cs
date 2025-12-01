using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    public enum RuleLevel
    {
        [Text("--")]
        None = 0,

        [Text("low")]
        Low = 1,

        [Text("medium")]
        Medium = 2,

        [Text("high")]
        High = 3,
    }
}