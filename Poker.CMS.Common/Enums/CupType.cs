using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 錦標賽賽事類型
    /// </summary>
    public enum CupType
    {
        [Description("Free")]
        [Text("free")]
        Free = 1 << 0,

        [Description("Regular")]
        [Text("regular")]
        Regular = 1 << 1,

        [Description("Guaranteed")]
        [Text("guaranteed")]
        Guaranteed = 1 << 2,

        [Description("Turbo")]
        [Text("turbo")]
        Turbo = 1 << 3,

        [Description("Bounty")]
        [Text("bounty")]
        Bounty = 1 << 4,

        [Description("Satellite")]
        [Text("satellite")]
        Satellite = 1 << 5,

        [Description("Qualifier")]
        [Text("qualifier")]
        Qualifier = 1 << 6,

        [Description("Exclusive")]
        [Text("exclusive")]
        Exclusive = 1 << 7,

        [Description("NFT")]
        [Text("nft")]
        NftDirect = 1 << 8,
    }
}
