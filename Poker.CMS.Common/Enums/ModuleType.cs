using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// Module類別
    /// </summary>
    public enum ModuleType
    {
        /// <summary>
        /// 頁面
        /// </summary>
        [Description("Page")]
        Page = 0,

        /// <summary>
        /// 功能
        /// </summary>
        [Description("Feature")]
        Feature = 1,
    }
}
