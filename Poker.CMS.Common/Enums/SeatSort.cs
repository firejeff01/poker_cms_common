using Poker.CMS.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CMS.Common.Enums
{
    public enum SeatSort
    {
        /// <summary>
        /// 莊家位
        /// </summary>
        [Description("Dealer")]
        [Text("dealer")]
        [ShortName("BTN")]
        Dealer = 1,

        /// <summary>
        /// 小盲位
        /// </summary>
        [Description("smallBlind")]
        [Text("SmallBlind")]
        [ShortName("SB")]
        SmallBlind = 2,

        /// <summary>
        /// 大盲位
        /// </summary>
        [Description("bigBlind")]
        [Text("BigBlind")]
        [ShortName("BB")]
        BigBlind = 3,

        /// <summary>
        /// 槍口位
        /// </summary>
        [Description("underTheGun")]
        [Text("UnderTheGun")]
        [ShortName("UTG")]
        UnderTheGun = 4,

        /// <summary>
        /// 中期位
        /// </summary>
        [Description("middlePosition")]
        [Text("MiddlePosition")]
        [ShortName("MP")]
        MiddlePosition = 5,

        /// <summary>
        /// 關煞位
        /// </summary>
        [Description("cutoff")]
        [Text("Cutoff")]
        [ShortName("CO")]
        Cutoff = 6
    }
}
