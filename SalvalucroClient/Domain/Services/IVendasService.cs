using SalvaLucroClient.Domain.Model;

namespace SalvaLucroClient.Domain.Services
{
    public interface IVendasService
    {
        public Task<IEnumerable<Venda>> GetVendasAsync(DateOnly? data);
    }
}
