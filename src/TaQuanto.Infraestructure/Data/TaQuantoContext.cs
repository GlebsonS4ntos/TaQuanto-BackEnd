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

        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatAt").CurrentValue = DateTime.Now; 
                }
                else if(entry.State == EntityState.Modified)
                {
                    entry.Property("UpdateAt").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
