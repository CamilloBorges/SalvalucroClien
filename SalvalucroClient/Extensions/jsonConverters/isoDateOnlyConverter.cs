using Newtonsoft.Json;

namespace SalvaLucroClient.Extensions.jsonConverters
{
    public class isoDateOnlyConverter : JsonConverter<DateOnly>
    {
        private const string DefaultDateOnlyFormat = "yyyy-MM-dd";
        private string _dateOnlyFormat;

        public string DateFormat
        {
            get => _dateOnlyFormat ?? DefaultDateOnlyFormat;
            set => _dateOnlyFormat = (string.IsNullOrEmpty(value)) ? DefaultDateOnlyFormat : value;
        }

        public override DateOnly ReadJson(JsonReader reader, Type objectType, DateOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string? stringValue = Convert.ToString(reader.Value);
                if (DateOnly.TryParseExact(stringValue, _dateOnlyFormat, out var value))
                    return value;
            }
            else if (reader.TokenType == JsonToken.Date)
                return DateOnly.FromDateTime(Convert.ToDateTime(reader.Value));

            throw new JsonException();
        }

        //public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer)
        {
            var _value = Convert.ToDateTime(value);            
            writer.WriteValue(DateOnly.FromDateTime(_value).ToString(_dateOnlyFormat));
            
        }
    }
}
