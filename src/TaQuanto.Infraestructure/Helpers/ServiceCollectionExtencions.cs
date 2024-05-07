using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TaQuanto.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using TaQuanto.Infraestructure.Interface;
using TaQuanto.Infraestructure.Repositories;
using TaQuanto.Infraestructure.Data.UnitOfWork;

namespace TaQuanto.Infraestructure.Helpers
{
    public static class ServiceCollectionExtencions
    {
        public static void AddInfraestructure(this IServiceCollection service, IConfiguration config)
        {
            AddDbContext(service, config);
            AddRepositories(service);
            AddUnitOfWork(service);
        }

        private static void AddDbContext(IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<TaQuantoContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("TaQuantoDb"));
            });
        }

        private static void AddRepositories(IServiceCollection service) 
        {
            service.AddScoped<IRepositoryProduct, RepositoryProduct>();
            service.AddScoped<IRepositoryEstablishment, RepositoryEstablishment>();
            service.AddScoped<IRepositoryState, RepositoryState>();
            service.AddScoped<IRepositoryCity, RepositoryCity>();
        }

        private static void AddUnitOfWork(IServiceCollection service)
        {
            service.AddScoped<IUnityOfWork, UnitOfWork>();
        }
    }
}
