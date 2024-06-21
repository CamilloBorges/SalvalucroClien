using Newtonsoft.Json;

namespace SalvaLucroClient.Extensions.jsonConverters
{
    public class jsonStringConverter : JsonConverter<string>
    {
        public override string? ReadJson(JsonReader reader, Type objectType, string? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Convert.ToString(reader.Value);
        }

        public override void WriteJson(JsonWriter writer, string? value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
