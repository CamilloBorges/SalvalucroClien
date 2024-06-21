using Microsoft.Extensions.DependencyInjection;
using SalvaLucroClient.Domain.Services;
using SalvaLucroClient.Services;
using System.Diagnostics.CodeAnalysis;

namespace SalvaLucroClient
{
    public static class SalvaLucroServiceCollectionExtensions
    {
        public static IServiceCollection AddSalvaLucro([NotNull] this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException("services");
            }

            services.ConfigureOptions<SalvaLucroOptionsSetup>();
            services.AddTransient<IConnectionService, ConnectionService>();
            services.AddTransient<IVendasService, VendasService>();
            services.AddTransient<IAjustesService, AjustesService>();

            return services;
        }

    }
}