using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Buldex.Infrastructure.Datas
{
    public class BuldexDbContextFactory : IDesignTimeDbContextFactory<BuldexDbContext>
    {
        public BuldexDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BuldexDbContext>();
            //var connectionString = "Server=(local);Initial Catalog=buldex;Integrated Security=True;TrustServerCertificate=True;";
            var connectionString = "Server=tcp:bnrdpoc.database.windows.net,1433; Initial Catalog=buldex; Authentication=Active Directory Default; Encrypt=True;TrustServerCertificate = False;";
            optionsBuilder.UseSqlServer(connectionString);

            return new BuldexDbContext(optionsBuilder.Options);
        }
    }
}
