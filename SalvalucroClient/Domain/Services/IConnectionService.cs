namespace SalvaLucroClient.Domain.Services
{
    public interface IConnectionService
    {
        public Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string>? queryStringParams);
    }
}
