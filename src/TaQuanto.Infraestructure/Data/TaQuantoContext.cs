using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Data
{
    public class TaQuantoContext : DbContext
    {
        public TaQuantoContext(DbContextOptions<TaQuantoContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
