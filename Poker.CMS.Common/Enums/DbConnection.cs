using System.ComponentModel;

namespace Poker.CMS.Common.Enum
{
    public enum DbConnection
    {
        /// <summary>
        /// Invalid Connection
        /// </summary>
        [Description("Invalid Connection")]
        Invalid = 0,

        /// <summary>
        /// MongoDB
        /// </summary>
        [Description("poker_cms")]
        MongoDB = 1,

        /// <summary>
        /// MongoDB
        /// </summary>
        [Description("poker_cms")]
        MariaDB = 2
    }
}
