using System;
using System.IO;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.DBContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Cars.EF.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Applying EF migrations........");
            var webHost = new WebHostBuilder()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseStartup<ConsoleStartup>()
            .Build();
            using (var context = (CarContext) webHost.Services.GetService(typeof(CarContext)))
            {
                //drop and recreate the whole database.
                context.Database.EnsureDeleted();
                context.Database.Migrate();
            }            
            Console.WriteLine("Applying EF migrations Completed.");
        }
    }
}
