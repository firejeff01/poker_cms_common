using Microsoft.Extensions.Logging;
using Poker.CMS.Common.Api.Request.Notify;
using Poker.CMS.Common.Enums;
using Poker.CMS.Common.Interface;
using System.Text;
using System.Text.Json;

namespace Poker.CMS.Common.Repository
{
    public class AssistantApiRepository : INotifier
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<AssistantApiRepository> _logger;

        public AssistantApiRepository(
            IHttpClientFactory httpClientFactory,
            ILogger<AssistantApiRepository> logger)
        {
            _httpClient = httpClientFactory.CreateClient("LogHttpClient");
            _logger = logger;
        }

        public async Task SendAsync(string message, ChatGroupId group = ChatGroupId.System)
        {
            try
            {
                var msg = new Message
                {
                    ChatGroupId = group,
                    Content = message
                };
                var requestContent = JsonSerializer.Serialize(msg);
                var content = new StringContent(requestContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("api/notify", content);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                Console.WriteLine($"Error sending notification: {ex.Message}");
                _logger.LogError(ex, "Error sending notification to Assistant API");
            }
        }
    }
}