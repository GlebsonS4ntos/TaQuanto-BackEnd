using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Mapping
{
    public class MappingEstablishment : IEntityTypeConfiguration<Establishment>
    {
        public void Configure(EntityTypeBuilder<Establishment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(e => e.Biography)
                .IsRequired()
                .HasColumnType("varchar(max)"); 

            builder.Property(e => e.ImageUrl)
                .IsRequired()
                .HasColumnType("varchar(max)"); 

            builder.Property(e => e.ImageBannerUrl)
                .HasColumnType("varchar(max)");

            builder.HasOne(e => e.City)
                .WithMany(c => c.Establishments)
                .HasForeignKey(e => e.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.CreatAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime2");

            builder.ToTable("Establishment");
        }
    }
}
