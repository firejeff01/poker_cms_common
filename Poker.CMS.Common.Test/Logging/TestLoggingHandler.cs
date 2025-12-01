using Microsoft.Extensions.Logging;
using Moq;
using Poker.CMS.Common.Logging;
using System.Net;

namespace Poker.CMS.Common.Test.Logging  
{
    [TestClass]
    public sealed class TestLoggingHandler
    {
        [TestMethod]
        public async Task TestLog()
        {
            // Arrange - 設定 Mock Logger
            var mockLogger = new Mock<ILogger<LoggingHandler>>();

            // 模擬 HttpClient 回應
            var mockHttpMessageHandler = new MockHttpMessageHandler(HttpStatusCode.OK, "Mock Response");

            // 建立 LoggingHandler，並將 MockHttpMessageHandler 設為內部 Handler
            var loggingHandler = new LoggingHandler(mockLogger.Object)
            {
                InnerHandler = mockHttpMessageHandler
            };

            var httpClient = new HttpClient(loggingHandler);

            // Act - 發送 GET 請求
            var response = await httpClient.GetAsync("http://192.168.1.202:8011/");

            // Assert - 確保回應狀態碼正確
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            // 驗證 Logger 是否有記錄請求與回應
            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, _) => o.ToString().Contains("Sending request")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);

            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, _) => o.ToString().Contains("Received response")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }

    // 自訂 MockHttpMessageHandler 用來模擬 API 回應
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpStatusCode _statusCode;
        private readonly string _responseContent;

        public MockHttpMessageHandler(HttpStatusCode statusCode, string responseContent)
        {
            _statusCode = statusCode;
            _responseContent = responseContent;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage
            {
                StatusCode = _statusCode,
                Content = new StringContent(_responseContent)
            });
        }
    }
}

