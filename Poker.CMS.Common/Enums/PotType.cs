using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    public enum PotType
    {
        /// <summary>
        /// 主池
        /// </summary>
        [Text("main_pot")]
        MainPot = 0,

        /// <summary>
        /// 邊池
        /// </summary>
        [Text("site_pot")]
        SidePot = 1,
    }
}
