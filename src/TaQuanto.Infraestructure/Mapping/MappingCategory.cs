using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Mapping
{
    public class MappingCategory : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(c => c.CreatAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(c => c.UpdateAt)
                .HasColumnType("datetime2");

            builder.HasOne(c => c.ParentCategory)
                .WithMany()
                .HasForeignKey(c => c.ParentCategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Category");
        }
    }
}
