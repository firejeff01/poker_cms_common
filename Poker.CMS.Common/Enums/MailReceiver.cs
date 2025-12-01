using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    public enum MailReceiver
    {
        /// <summary>
        /// 代理商所屬
        /// </summary>
        [Text("agent_players")]
        AgentPlayers = 1,

        /// <summary>
        /// 特定玩家
        /// </summary>
        [Text("specific_players")]
        SpecificPlayers = 2
    }
}
