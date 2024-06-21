using SalvaLucroClient.Extensions.jsonConverters;
using Newtonsoft.Json;

namespace SalvaLucroClient.Domain.Model
{
    public class Parcela
    {
        public string nsu { get; set; }
        [JsonConverter(typeof(jsonDateOnlyConverter), "yyyy-MM-dd")]
        public DateOnly dataVenda { get; set; }
        [JsonConverter(typeof(jsonDateOnlyConverter), "yyyy-MM-dd")]
        public DateOnly dataCredito { get; set; }
        public decimal valorBruto { get; set; }
        public decimal valorLiquido { get; set; }
        public decimal valorDesconto { get; set; }
        [JsonConverter(typeof(jsonInt32JsonConverter))]
        public int numeroParcela { get; set; }
        [JsonConverter(typeof(jsonInt32JsonConverter))]
        public int quantidadeParcelas { get; set; }

    }
}
