using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.DBContext
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base (options)
        {
            
        }

        public DbSet<Car> Cars {get; set;}
    }
}