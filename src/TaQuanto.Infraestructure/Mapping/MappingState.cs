using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Mapping
{
    public class MappingState : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(s => s.UF)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(s => s.CreatAt)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(s => s.UpdateAt)
                .HasColumnType("datetime2");

            builder.ToTable("State");
        }
    }
}
