using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalvaLucroClient.Domain.Model;
using SalvaLucroClient.Domain.Services;
using SalvaLucroClient.Exceptions;
using SalvaLucroClient.Extensions;
using System.Net.Http.Json;

namespace SalvaLucroClient.Services
{
    public class AjustesService : IAjustesService
    {
        private readonly IConnectionService _connectionService;
        private readonly SalvaLucroOptions _options;
        private readonly ILogger<AjustesService> _logger;

        public AjustesService(IConnectionService connectionService, IOptions<SalvaLucroOptions> options, ILogger<AjustesService> logger)
        {
            _connectionService = connectionService;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IEnumerable<Ajuste>> getAjustesAsync(DateOnly dataInicial, DateOnly dataFinal)
        {
            if (dataInicial == DateOnly.MinValue)
                dataInicial = DateOnly.FromDateTime(DateTime.Now.Date);
            if (dataFinal == DateOnly.MinValue)
                dataFinal = DateOnly.FromDateTime(DateTime.Now.Date);

            var queryStringParams = new Dictionary<string, string>()
            {
                ["cnpj"] = FormatCnpjCpf.FormatCNPJ(_options.CNPJ),
                ["dataInicial"] = dataInicial.ToString("yyyy-MM-dd"),
                ["dataFinal"] = dataFinal.ToString("yyyy-MM-dd")
            };

            var response = await _connectionService.GetAsync($"/api/{_options.versao}/ajustes", queryStringParams);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<Ajuste>>();
            else
            {
                _logger.LogError($"Retorno:{response.StatusCode} | Mensagem: { await response.Content.ReadAsStringAsync()} ");
                throw new HttpRequestException("Erro Vendas ", await response.ExceptionResponse());
            }
        }
    }
}
