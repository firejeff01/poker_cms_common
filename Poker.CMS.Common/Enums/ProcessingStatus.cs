using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 風控事件處理狀態
    /// </summary>
    public enum ProcessingStatus
    {
        /// <summary>
        /// 待審核		
        /// </summary>
        [Text("pending")]
        Pending = 1,

        /// <summary>
        /// 處理中
        /// </summary>
        [Text("in_progress")]
        InProgress = 2,

        /// <summary>
        /// 已處理
        /// </summary>
        [Text("processed")]
        Processed = 3,
    }
}
