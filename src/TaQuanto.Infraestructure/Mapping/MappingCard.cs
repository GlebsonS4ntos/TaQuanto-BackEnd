using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Mapping
{
    public class MappingCard : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CreatAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(c => c.UpdateAt)
                .HasColumnType("datetime2");

            builder.ToTable("Cart");
        }
    }
}
