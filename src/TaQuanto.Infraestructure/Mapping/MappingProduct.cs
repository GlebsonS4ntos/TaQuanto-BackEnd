using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Mapping
{
    public class MappingProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey("Id");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(p => p.OriginalPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.NewPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.ImageUrl)
                .IsRequired()
                .HasColumnType("varchar(max)"); ;

            builder.Property(p => p.CreatAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(p => p.UpdateAt)
                .HasColumnType("datetime2");

            builder.HasOne(p => p.Establishment)
                .WithMany(e => e.Products)
                .HasForeignKey(p => p.EstablishmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Product");
        }
    }
}
