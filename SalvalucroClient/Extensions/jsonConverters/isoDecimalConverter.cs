using Newtonsoft.Json;
using System.Globalization;

namespace SalvaLucroClient.Extensions.jsonConverters
{
    public class isoDecimalConverter : JsonConverter<decimal>
    {
        private CultureInfo _cutureInfo;

        public string? CutureInfo
        {
            get => _cutureInfo.ToString();
            set => _cutureInfo = !string.IsNullOrEmpty(value) ? CultureInfo.GetCultureInfo(value) : CultureInfo.InvariantCulture;
        }

        public override decimal ReadJson(JsonReader reader, Type objectType, decimal existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String ||
                reader.TokenType == JsonToken.Float)
            {
                string? stringValue = Convert.ToString(reader.Value);
                if (decimal.TryParse(stringValue, NumberStyles.Any, _cutureInfo, out var result))
                    return result;
            }
            throw new JsonException();
        }

        public override void WriteJson(JsonWriter writer, decimal value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(_cutureInfo));
        }
    }
}
