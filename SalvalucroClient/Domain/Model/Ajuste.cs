namespace SalvaLucroClient.Domain.Model
{
    public class Ajuste
    {
        public string cnpj { get; set; }
        public string razao_social { get; set; }
        public string codigo_estabelecimento { get; set; }
        public DateOnly data { get; set; }
        public int codigo_adquirente { get; set; }
        public string nome_adquirente { get; set; }
        public string descricao { get; set; }
        public decimal valor { get; set; }
    }
}
