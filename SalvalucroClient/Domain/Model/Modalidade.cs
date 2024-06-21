using SalvaLucroClient.Extensions.jsonConverters;
using Newtonsoft.Json;

namespace SalvaLucroClient.Domain.Model
{
    public class Modalidade
    {

        [JsonConverter(typeof(jsonInt32JsonConverter))]
        public int codigoModalidade { get; set; }
        public string descricaoModalidade { get; set; }
    }
}
