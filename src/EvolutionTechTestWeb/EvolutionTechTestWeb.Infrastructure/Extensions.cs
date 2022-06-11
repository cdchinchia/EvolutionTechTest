
using EvolutionTechTestWeb.Core.DTO;
using EvolutionTechTestWeb.Core.Interfaces;
using EvolutionTechTestWeb.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EvolutionTechTestWeb.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryAsync<UserDTO>, UserRepository>();
            services.AddScoped<IRepositoryAsync<ProductDTO>, ProductRepository>();
            services.AddScoped<IRepositoryAsync<OrderDTO>, OrderRepository>();

            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}