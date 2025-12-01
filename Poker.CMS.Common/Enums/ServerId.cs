using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 德州撲克-遊戲伺服器(遊戲類型)
    /// </summary>
    public enum ServerId
    {
        /// <summary>
        /// 大廳
        /// </summary>
        [Description("Lobby")]
        [Text("lobby")]
        Lobby = 0,

        /// <summary>
        /// 德州撲克
        /// </summary>
        [Description("NLH")]
        [Text("nlh")]
        NLH = 1,

        /// <summary>
        /// 短牌
        /// </summary>
        [Description("6+")]
        [Text("six_plus")]
        SixPlus = 2,

        /// <summary>
        /// 奧馬哈
        /// </summary>
        [Description("PLO")]
        [Text("plo")]
        PLO = 3,

        /// <summary>
        /// 全押棄牌長牌
        /// </summary>
        [Description("AoF-NLH")]
        [Text("aof_nlh")]
        AoFNLH = 4,

        /// <summary>
        /// 全押棄牌奧馬哈
        /// </summary>
        [Description("AoF-PLO")]
        [Text("aof_plo")]
        AoFPLO = 5,

        ///// <summary>
        ///// 魷魚遊戲
        ///// </summary>
        //[Description("Squid-NLH")]
        //[Text("squid_nlh")]
        //SquidNLH = 6,

        ///// <summary>
        ///// 13支
        ///// </summary>
        //[Description("13-Cards")]
        //[Text("13_cards")]
        //ThirteenCards = 7,

        ///// <summary>
        ///// 大波羅
        ///// </summary>
        //[Description("OFC")]
        //[Text("ofc")]
        //OFC = 8,

        /// <summary>
        /// 體驗館-德州撲克
        /// </summary>
        [Description("TEST-NLH")]
        [Text("test_nlh")]
        TestNLH = 11,

        /// <summary>
        /// 體驗館-短牌
        /// </summary>
        [Description("TEST-6+")]
        [Text("test_six_plus")]
        TestSixPlus = 12,

        /// <summary>
        /// 體驗館-奧馬哈
        /// </summary>
        [Description("TEST-PLO")]
        [Text("test_plo")]
        TestPLO = 13,

        /// <summary>
        /// 體驗館-全押棄牌長牌
        /// </summary>
        [Description("TEST-AoF-NLH")]
        [Text("test_aof_nlh")]
        TestAoFNLH = 14,

        /// <summary>
        /// 體驗館-全押棄牌奧馬哈
        /// </summary>
        [Description("TEST-AoF-PLO")]
        [Text("test_aof_plo")]
        TestAoFPLO = 15
    }
}
