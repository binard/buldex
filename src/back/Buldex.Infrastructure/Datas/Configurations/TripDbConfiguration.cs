using Buldex.Infrastructure.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buldex.Infrastructure.Datas.Configurations
{
    internal class TripDbConfiguration : IEntityTypeConfiguration<TripDb>
    {
        public void Configure(EntityTypeBuilder<TripDb> builder)
        {
            builder.ToTable("Trips");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasMaxLength(15);

            builder.HasIndex(b => b.Date).IsUnique();

            builder.HasOne(b => b.City)
                   .WithOne()
                   .HasForeignKey<TripDb>(b => b.ZipCode);
        }
    }
}