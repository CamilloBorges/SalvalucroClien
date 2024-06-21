using SalvaLucroClient.Extensions.jsonConverters;
using Newtonsoft.Json;

namespace SalvaLucroClient.Domain.Model
{
    public class Produto
    {
        [JsonConverter(typeof(jsonInt32JsonConverter))]
        public int codigoProduto { get; set; }
        public string descricaoProduto { get; set; }
    }
}
