using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaQuanto.Service.Config;
using TaQuanto.Service.Interfaces;
using TaQuanto.Service.Services;

namespace TaQuanto.Service.Helpers
{
    public static class ServiceCollectionExtencions
    {
        public static void AddService(this IServiceCollection service, IConfiguration config)
        {
            AddAutoMapper(service);
            AddServices(service);
            AddConfig(service, config);
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddScoped(provider => new AutoMapper.MapperConfiguration(opt =>
            {
                opt.AddProfile(new AutoMapperConfig());
            }).CreateMapper());
        }

        private static void AddServices(IServiceCollection service) 
        {
            service.AddScoped<IServiceCart, ServiceCart>();
            service.AddScoped<IServiceCategory, ServiceCategory>();
            service.AddScoped<IServiceCity, ServiceCity>();
            service.AddScoped<IServiceState, ServiceState>();
            service.AddScoped<IServiceProduct, ServiceProduct>();
            service.AddScoped<IServiceEstablishment, ServiceEstablishment>();
            service.AddScoped<IServicePhoto, ServicePhoto>();
        }

        private static void AddConfig(IServiceCollection service, IConfiguration config)
        {
            service.Configure<CloudinaryConfig>(options => config.GetSection("CloudinaryConfig"));
        }
    }
}
