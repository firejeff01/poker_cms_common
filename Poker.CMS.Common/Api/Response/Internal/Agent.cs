using System.Text.Json.Serialization;

namespace Poker.CMS.Common.Api.Response.Internal
{
    public class Agent
    {
        /// <summary>
        /// 代理id, 唯一值
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// 代理編號
        /// </summary>
        [JsonPropertyName("agent_name")]
        public string AgentName { get; set; }

        /// <summary>
        /// 代理名稱
        /// </summary>
        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 總代理id
        /// </summary>
        [JsonPropertyName("ga_id")]
        public int GaId { get; set; }

        /// <summary>
        /// 總代理編號
        /// </summary>
        [JsonPropertyName("ga_name")]
        public string GaName { get; set; }

        /// <summary>
        /// 總代理名稱
        /// </summary>
        [JsonPropertyName("ga_company_name")]
        public string GaCompanyName { get; set; }

        /// <summary>
        /// 是否加入公海
        /// </summary>
        [JsonPropertyName("join_sea_fl")]
        public bool JoinSeaFl { get; set; }
    }
}