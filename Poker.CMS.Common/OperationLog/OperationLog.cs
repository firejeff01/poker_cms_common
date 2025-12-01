using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Poker.CMS.Common.Attributes;
using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.OperationLog
{
    [CollectionName("operation_log")]
    public class OperationLog
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("module")]
        public required string Module { get; set; }

        [BsonElement("sub_module")]
        public string? SubModule { get; set; }

        [BsonElement("action")]
        public OperationLogAction Action { get; set; }

        [BsonElement("before_data")]
        public string? BeforeData { get; set; }

        [BsonElement("after_data")]
        public string? AfterData { get; set; }

        [BsonElement("success")]
        public bool Success { get; set; }

        [BsonElement("exception")]
        public string? Exception { get; set; }

        [BsonElement("request_url")]
        public string? RequestUrl { get; set; }

        [BsonElement("request_body")]
        public string? RequestBody { get; set; }

        [BsonElement("response_body")]
        public string? ResponseBody { get; set; }

        [BsonElement("duration_ms")]
        public double DurationMs { get; set; }

        [BsonElement("create_user")]
        public int CreateUser { get; set; }

        [BsonElement("create_user_name")]
        public required string CreateUserName { get; set; }

        [BsonElement("create_time")]
        public DateTime CreateTime { get; set; }

        [BsonElement("ip")]
        public string Ip { get; set; } = string.Empty;
    }
}