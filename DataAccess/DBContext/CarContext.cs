using GeekyMon2.CarsApi.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeekyMon2.CarsApi.DataAccess.DBContext
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base (options)
        {
            
        }

        public DbSet<Car> Cars {get; set;}
    }
}