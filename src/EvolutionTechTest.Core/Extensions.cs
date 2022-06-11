
using AutoMapper;
using EvolutionTechTest.Core.Interfaces;
using EvolutionTechTest.Core.Mappers;
using EvolutionTechTest.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EvolutionTechTest.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddMappingProfilesServices();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }

        private static IServiceCollection AddMappingProfilesServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OrderMappingProfile());
                mc.AddProfile(new ProductMappingProfile());
                mc.AddProfile(new UserMappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
