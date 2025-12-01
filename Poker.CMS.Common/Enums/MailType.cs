using System.ComponentModel;
using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 信件分類
    /// </summary>
    public enum MailType
    {
        /// <summary>
        /// 一般        
        /// </summary>
        [Description("General")]
        [Text("general")]
        General = 0,
        /// <summary>
        /// 警告
        /// </summary>
        [Description("Warning")]
        [Text("warning")]
        Warning = 1,
        /// <summary>
        /// 公告
        /// </summary>
        [Description("Announcement")]
        [Text("announcement")]
        Announcement = 2,
        /// <summary>
        /// 活動
        /// </summary>
        [Description("Event")]
        [Text("event")]
        Event = 3,
        /// <summary>
        /// 廣告
        /// </summary>
        [Description("Advertisement")]
        [Text("advertisement")]
        Advertisement = 4,
        /// <summary>
        /// 消費
        /// </summary>
        [Description("Purchase")]
        [Text("purchase")]
        Purchase = 5,
        /// <summary>
        /// 提醒
        /// </summary>
        [Description("Reminder")]
        [Text("reminder")]
        Reminder = 6,
        /// <summary>
        /// 提示
        /// </summary>
        [Description("Notification")]
        [Text("notification")]
        Notification = 7,
        /// <summary>
        /// 教學
        /// </summary>
        [Description("Tutorial")]
        [Text("tutorial")]
        Tutorial = 8,
        /// <summary>
        /// 錯誤回報
        /// </summary>
        [Description("BugReport")]
        [Text("bug_report")]
        BugReport = 10,
        /// <summary>
        /// 檢舉
        /// </summary>
        [Description("Complaint")]
        [Text("complaint")]
        Complaint = 11,
        /// <summary>
        /// 其他
        /// </summary>
        [Description("Other")]
        [Text("other")]
        Other = 99
    }
}
