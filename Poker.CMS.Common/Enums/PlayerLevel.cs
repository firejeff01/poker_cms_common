using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    public enum PlayerLevel
    {
        /// <summary>
        /// 無
        /// </summary>
        [Text("none")]
        None = 0,

        /// <summary>
        /// 新註冊
        /// </summary>
        [Text("new_registered")]
        NewRegistered = 1,

        /// <summary>
        /// 新手
        /// </summary>
        [Text("beginner")]
        Beginner = 2,

        /// <summary>
        /// 初級
        /// </summary>
        [Text("junior")]
        Junior = 3,

        /// <summary>
        /// 中級
        /// </summary>
        [Text("intermediate")]
        Intermediate = 4,

        /// <summary>
        /// 高級
        /// </summary>
        [Text("senior")]
        Senior = 5,

        /// <summary>
        /// 專業
        /// </summary>
        [Text("professional")]
        Professional = 6,

        /// <summary>
        /// 高手
        /// </summary>
        [Text("expert")]
        Expert = 7,

        /// <summary>
        /// 頂尖
        /// </summary>
        [Text("top")]
        Top = 8
    }
}
