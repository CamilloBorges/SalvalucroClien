using SalvaLucroClient.Extensions.jsonConverters;
using Newtonsoft.Json;

namespace SalvaLucroClient.Domain.Model
{
    public class Adquirente
    {
        [JsonConverter(typeof(jsonInt32JsonConverter))]
        public int codigoAdquirente { get; set; }
        public string nomeAdquirente { get; set; }
    }
}
