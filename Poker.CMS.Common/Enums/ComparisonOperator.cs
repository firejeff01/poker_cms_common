using System.ComponentModel;
using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    public enum ComparisonOperator
    {
        /// <summary>
        /// 大於等於
        /// </summary>
        [Text(">=")]
        [Description("gte")]
        Gte = 1,

        /// <summary>
        /// 小於等於
        /// </summary>
        [Text("<=")]
        [Description("lte")]
        Lte = 2,

        /// <summary>
        /// 大於
        /// </summary>
        [Text(">")]
        [Description("gt")]
        Gt = 3,

        /// <summary>
        /// 小於
        /// </summary>
        [Text("<")]
        [Description("lt")]
        Lt = 4,

        /// <summary>
        /// 等於
        /// </summary>
        [Text("=")]
        [Description("eq")]
        Eq = 5,

        /// <summary>
        /// 不等於
        /// </summary>
        [Text("≠")]
        [Description("neq")]
        Neq = 6
    }
}
