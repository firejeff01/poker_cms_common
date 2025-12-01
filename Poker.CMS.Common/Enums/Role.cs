using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    public enum Role
    {
        [Description("SuperAdmin")]
        [Text("SuperAdmin")]
        SuperAdmin = 1,

        [Description("Admin")]
        [Text("Admin")]
        Admin = 2,

        [Description("GA")]
        [Text("GA")]
        GA = 3,

        [Description("Agent")]
        [Text("Agent")]
        Agent = 4,
    }
}
