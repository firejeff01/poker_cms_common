using System.Text.Json.Serialization;

namespace Poker.CMS.Common.Api.Response.Internal
{
    public class Account
    {
        /// <summary>
        /// 玩家uid, 唯一值
        /// </summary>
        [JsonPropertyName("uid")]
        public long Uid { get; set; }

        /// <summary>
        /// 玩家-總代理商id
        /// </summary>
        [JsonPropertyName("ga_id")]
        public int GaId { get; set; }

        /// <summary>
        /// 玩家-代理商id
        /// </summary>
        [JsonPropertyName("agent_id")]
        public int AgentId { get; set; }

        /// <summary>
        /// 玩家帳號
        /// </summary>
        [JsonPropertyName("account")]
        public string ClientAccount { get; set; }

        /// <summary>
        /// 帳戶暱稱
        /// </summary>
        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }
    }
}
