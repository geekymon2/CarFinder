using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.DBContext
{
    public class CarContextFactory : IDesignTimeDbContextFactory<CarContext>
    {
        public CarContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<CarContext>();

            var connectionString = configuration
                        .GetConnectionString("DefaultConnection");

            dbContextBuilder.UseSqlServer(connectionString);

            return new CarContext(dbContextBuilder.Options);
        }
    }
}
