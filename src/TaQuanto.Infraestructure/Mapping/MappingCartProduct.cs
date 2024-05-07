using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Mapping
{
    public class MappingCartProduct : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.HasKey(cp => cp.Id);

            builder.Property(cp => cp.CreatAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(cp => cp.UpdateAt)
                .HasColumnType("datetime2");

            builder.HasOne(cp => cp.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(cp => cp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cp => cp.Cart)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(cp => cp.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(cp => cp.Quantity)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("CartItem");
        }
    }
}