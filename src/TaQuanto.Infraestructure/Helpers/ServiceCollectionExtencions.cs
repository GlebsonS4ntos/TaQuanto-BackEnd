using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TaQuanto.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TaQuanto.Infraestructure.Helpers
{
    public static class ServiceCollectionExtencions
    {
        public static void AddInfraestructure(this IServiceCollection service, IConfiguration config)
        {
            AddDbContext(service, config);
        }

        private static void AddDbContext(IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<TaQuantoContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("TaQuantoDb"));
            });
        }
    }
}
