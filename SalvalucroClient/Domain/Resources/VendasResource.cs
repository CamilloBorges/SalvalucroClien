using SalvaLucroClient.Domain.Model;

namespace SalvaLucroClient.Domain.Resources
{
    internal class VendasResource
    {
        public IEnumerable<Venda> VENDAS { get; set; }
        public string MENSAGEM { get; set; }
    }
}
