using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    public enum AnnouncementCategory
    {
        [Description("system_announcement")]
        [Text("system_announcement")]
        SystemAnnouncement = 1,

        [Description("system_update")]
        [Text("system_update")]
        SystemUpdate = 2,

        [Description("game_info")]
        [Text("game_info")]
        GameInfo = 3,

        [Description("promotion")]
        [Text("promotion")]
        Promotion = 4,
    }
}
