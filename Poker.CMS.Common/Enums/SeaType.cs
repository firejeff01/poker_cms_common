using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    public enum SeaType
    {
        /// <summary>
        /// 私海
        /// </summary>
        [Description("PrivateSea")]
        [Text("private_sea")]
        PrivateSea = 0,

        /// <summary>
        /// 公海
        /// </summary>
        [Description("PublicSea")]
        [Text("public_sea")]
        PublicSea = 1
    }
}
