using Poker.CMS.Common.Enums;
using System.Text.Json.Serialization;

namespace Poker.CMS.Common.Api.Response.Internal
{
    public class User
    {
        /// <summary>
        /// id
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// role id
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        [JsonPropertyName("role")]
        public required Role Role { get; set; }

        /// <summary>
        /// agent id
        /// </summary>
        /// <value>
        /// The agent identifier.
        /// </value>
        [JsonPropertyName("agent_id")]
        public int? AgentId { get; set; }

        /// <summary>
        /// ga id
        /// </summary>
        /// <value>
        /// The ga identifier.
        /// </value>
        [JsonPropertyName("ga_id")]
        public int? GaId { get; set; }

        /// <summary>
        /// 語系參數
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [JsonPropertyName("lang")]
        public required Language Lang { get; set; }

        /// <summary>
        /// 此人擁有的權限名稱
        /// </summary>
        /// <value>
        /// The permission module names.
        /// </value>
        [JsonPropertyName("permission_module_names")]
        public List<string> PermissionModuleNames { get; set; } = [];
    }
}
