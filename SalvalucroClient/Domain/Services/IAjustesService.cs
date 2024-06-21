using SalvaLucroClient.Domain.Model;

namespace SalvaLucroClient.Domain.Services
{
    public interface IAjustesService
    {
        public Task<IEnumerable<Ajuste>> getAjustesAsync(DateOnly dataInicial, DateOnly dataFinal);
    }
}
