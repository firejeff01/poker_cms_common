using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.Api.Request.Notify
{
    public class Message
    {
        /// <summary>
        /// 發送至群組 0: 系統群組(預設) / 1: 代理商群組
        /// </summary>
        /// <value>
        /// The chat group identifier.
        /// </value>
        public ChatGroupId ChatGroupId { get; set; } = ChatGroupId.System;

        /// <summary>
        /// 訊息內容
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; } = string.Empty;
    }
}
