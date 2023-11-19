using Buldex.Infrastructure.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buldex.Infrastructure.Datas.Configurations
{
    internal class CityDbConfiguration : IEntityTypeConfiguration<CityDb>
    {
        public void Configure(EntityTypeBuilder<CityDb> builder)
        {
            builder.HasKey(b => b.ZipCode);
            builder.Property(b => b.ZipCode).HasMaxLength(6);

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}