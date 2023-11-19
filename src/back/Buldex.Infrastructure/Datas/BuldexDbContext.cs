using Buldex.Infrastructure.Datas.Configurations;
using Buldex.Infrastructure.Datas.Entities;
using Microsoft.EntityFrameworkCore;

namespace Buldex.Infrastructure.Datas
{
    public class BuldexDbContext : DbContext
    {
        public BuldexDbContext(DbContextOptions<BuldexDbContext> options) 
            : base(options)
        {            
        }

        public DbSet<TripDb> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityDbConfiguration());
            modelBuilder.ApplyConfiguration(new TripDbConfiguration());
        }
    }
}