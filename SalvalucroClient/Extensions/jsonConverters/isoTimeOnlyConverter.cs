
using Newtonsoft.Json;

namespace SalvalucroClient.Extensions.jsonConverters
{
    public class isoTimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private const string DefaultTimeOnlyFormat = "HH:mm:ss";
        private string _timeOnlyFormat;

        public string TimeFormat
        {
            get => _timeOnlyFormat ?? DefaultTimeOnlyFormat;
            set => _timeOnlyFormat = (string.IsNullOrEmpty(value)) ? DefaultTimeOnlyFormat : value;
        }

        public override TimeOnly ReadJson(JsonReader reader, Type objectType, TimeOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string? stringValue = Convert.ToString(reader.Value);
                if (TimeOnly.TryParseExact(stringValue, _timeOnlyFormat, out var value))
                    return value;
            }

            throw new JsonException();
        }

        public override void WriteJson(JsonWriter writer, TimeOnly value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(_timeOnlyFormat));
        }
    }
}
