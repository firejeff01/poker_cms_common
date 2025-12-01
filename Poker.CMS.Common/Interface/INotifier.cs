using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.Interface
{
    public interface INotifier
    {
        Task SendAsync(string message, ChatGroupId group = ChatGroupId.System);
    }
}