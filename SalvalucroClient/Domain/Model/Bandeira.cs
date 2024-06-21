using SalvaLucroClient.Extensions.jsonConverters;
using Newtonsoft.Json;

namespace SalvaLucroClient.Domain.Model
{
    public class Bandeira
    {
        [JsonConverter(typeof(jsonInt32JsonConverter))]
        public int codigoBandeira { get; set; }
        public string descricaoBandeira { get; set; }
    }
}
