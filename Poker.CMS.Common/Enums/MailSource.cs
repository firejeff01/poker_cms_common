using System.ComponentModel;
using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 信件來源
    /// </summary>
    public enum MailSource
    {
        /// <summary>
        /// 系統
        /// </summary>
        [Description("System")]
        [Text("system")]
        System = 0,
        /// <summary>
        /// 商城
        /// </summary>
        [Description("Shop")]
        [Text("shop")]
        Shop = 1,
        /// <summary>
        /// 郵件
        /// </summary>
        [Description("Mail")]
        [Text("mail")]
        Mail = 2,
        /// <summary>
        /// 虛寶
        /// </summary>
        [Description("VirtualItem")]
        [Text("virtual_item")]
        VirtualItem = 3,
        /// <summary>
        /// 回報
        /// </summary>
        [Description("Report")]
        [Text("report")]
        Report = 7,
        /// <summary>
        /// GM
        /// </summary>
        [Description("GM")]
        [Text("gm")]
        GM = 8,
        /// <summary>
        /// 私人
        /// </summary>
        [Description("Private")]
        [Text("private")]
        Private = 9,
        /// <summary>
        /// 其他
        /// </summary>
        [Description("Other")]
        [Text("other")]
        Other = 99
    }
}
