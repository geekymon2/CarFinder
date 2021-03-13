using GeekyMon2.CarsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekyMon2.CarsApi.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base (options)
        {
            
        }

        public DbSet<Car> Cars {get; set;}
    }
}