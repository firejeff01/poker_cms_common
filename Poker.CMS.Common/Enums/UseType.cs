using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 使用方式
    /// </summary>
    public enum UseType
    {
        /// <summary>
        /// 對大家使用
        /// </summary>
        [Text("use_on_everyone")]
        UseOnEveryone = -1,

        /// <summary>
        /// 不可使用
        /// </summary>
        [Text("not_usable")]
        NotUsable = 0,

        /// <summary>
        /// 對自己使用
        /// </summary>
        [Text("use_on_self")]
        UseOnSelf = 1,

        /// <summary>
        /// 對指定對象使用
        /// </summary>
        [Text("use_on_target")]
        UseOnTarget = 2
    }
}
