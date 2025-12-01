using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.Api.Request.OperationLog
{
    public class OperationLog
    {
        public required string Module { get; set; }

        public OperationLogAction Action { get; set; }

        public string? BeforeData { get; set; }

        public string? AfterData { get; set; }

        public bool Success { get; set; }

        public string? Exception { get; set; }

        public string? RequestUrl { get; set; }

        public string? RequestBody { get; set; }

        public string? ResponseBody { get; set; }

        public double DurationMs { get; set; }

        public int CreateUser { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.UtcNow;
    }
}
