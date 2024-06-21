using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SalvaLucroClient.Domain.Model;
using SalvaLucroClient.Domain.Resources;
using SalvaLucroClient.Domain.Services;
using SalvaLucroClient.Exceptions;
using SalvaLucroClient.Extensions;
using System.Net.Http.Json;

namespace SalvaLucroClient.Services
{
    public class VendasService : IVendasService
    {
        private readonly IConnectionService _connectionService;
        private readonly SalvaLucroOptions _options;
        private readonly ILogger<VendasService> _logger;

        public VendasService(IConnectionService connectionService, IOptions<SalvaLucroOptions> options, ILogger<VendasService> logger)
        {
            _connectionService = connectionService;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IEnumerable<Venda>> GetVendasAsync(DateOnly? data)
        {
            var sendDate = data ?? DateOnly.FromDateTime(DateTime.Now);

            var queryStringParams = new Dictionary<string, string>()
            {
                ["cnpj"] = FormatCnpjCpf.FormatCNPJ(_options.CNPJ),
                ["data"] = sendDate.ToString("yyyy-MM-dd")
            };

            var response = await _connectionService.GetAsync($"/api/{_options.versao}/vendas", queryStringParams);
            VendasResource result;
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<VendasResource>();
            else
            {
                _logger.LogError($"Retorno:{response.StatusCode} | Mensagem: {await response.Content.ReadAsStringAsync()} ");
                throw new HttpRequestException("Erro Vendas ", await response.ExceptionResponse());
            }

            return result.VENDAS;
        }
    }
}
