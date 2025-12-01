using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    public enum AF
    {
        [Description("N/A")]
        [Text("na")]
        NA = 0,

        [Description("Fold")]
        [Text("fold")]
        Fold = 1,

        [Description("Allin")]
        [Text("allin")]
        Allin = 2,

        [Description("Fold + Allin")]
        [Text("fold+allin")]
        FoldPlusAllin = 3
    }
}