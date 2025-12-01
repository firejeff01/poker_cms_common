using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// IP名單類別
    /// </summary>
    public enum IpType
    {
        /// <summary>
        /// 白名單
        /// </summary>
        [Description("WhiteList")]
        [Text("white_list")]
        WhiteList = 1
    }
}
