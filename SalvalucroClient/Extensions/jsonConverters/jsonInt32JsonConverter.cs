using Newtonsoft.Json;

namespace SalvaLucroClient.Extensions.jsonConverters
{
    public class jsonInt32JsonConverter : JsonConverter<int>
    {
        public override int ReadJson(JsonReader reader, Type objectType, int existingValue, bool hasExistingValue, JsonSerializer serializer)
        {

            if (reader.TokenType == JsonToken.String)
            {
                string stringValue = Convert.ToString(reader.Value) ?? "0";

                if (int.TryParse(stringValue, out int value))
                {
                    return value;
                }
            }
            else if (reader.TokenType == JsonToken.Integer)
                return Convert.ToInt32(reader.Value);          

            throw new JsonException();
        }

        public override void WriteJson(JsonWriter writer, int value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
