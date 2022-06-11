
using AutoMapper;
using EvolutionTechTest.Core.Entities;
using EvolutionTechTest.Core.Interfaces;
using EvolutionTechTest.Infrastructure.Helpers.Interfaces;
using EvolutionTechTest.Infrastructure.Respositories;
using EvolutionTechTest.Infrastructure.Respositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EvolutionTechTest.Infrastructure
{
    public static class Extensions
    {
        private const string EvolutionTechConnectionStringPath = "EvolutionTechDatabase";

        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
        {
            services.AddDatabaseContexts();
            services.AddMappingProfilesServices();

            services.AddScoped<IRepositoryAsync<User>, UserRepository>();
            services.AddScoped<IRepositoryAsync<Product>, ProductRepository>();
            services.AddScoped<IRepositoryAsync<Order>, OrderRepository>();
            return services;
        }

        private static IServiceCollection AddDatabaseContexts(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.AddDbContext<EvolutionTestContext>(options => options.UseSqlServer(configuration.GetConnectionString(EvolutionTechConnectionStringPath)));
            return services;
        }

        private static IServiceCollection AddMappingProfilesServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                //Se agregan los mappers profiles
            });
            IInfraestructureMappers infraestructureMappers = new(mapperConfig);
            services.AddSingleton(infraestructureMappers);
            return services;
        }
    }
}
