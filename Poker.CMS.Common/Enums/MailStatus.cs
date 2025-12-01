using System.ComponentModel;
using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 信件狀態
    /// </summary>
    public enum MailStatus
    {
        /// <summary>
        /// 草稿
        /// </summary>
        [Description("Draft")]
        [Text("draft")]
        Draft = 0,
        /// <summary>
        /// 待寄送
        /// </summary>
        [Description("Pending")]
        [Text("pending")]
        Pending = 1,
        /// <summary>
        /// 已寄送
        /// </summary>
        [Description("Sent")]
        [Text("sent")]
        Sent = 2,
        /// <summary>
        /// 已刪除
        /// </summary>
        [Description("Deleted")]
        [Text("deleted")]
        Deleted = 3
    }
}
