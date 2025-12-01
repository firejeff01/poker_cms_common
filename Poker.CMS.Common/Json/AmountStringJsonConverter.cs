using System.Text.Json;
using System.Text.Json.Serialization;

namespace Poker.CMS.Common.Json
{
    public class AmountStringJsonConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions opts)
        => reader.TokenType == JsonTokenType.String
           ? decimal.Parse(reader.GetString()!)
           : reader.GetDecimal();

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions opts)
            => writer.WriteStringValue(value.ToString("N4"));
    }
}
