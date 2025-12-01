using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    public enum TableType
    {
        /// <summary>
        /// 私桌
        /// </summary>
        [Description("PrivateTable")]
        [Text("private_table")]
        PrivateTable = 0,

        /// <summary>
        /// 公桌
        /// </summary>
        [Description("PublicTable")]
        [Text("public_table")]
        PublicTable = 1
    }
}
