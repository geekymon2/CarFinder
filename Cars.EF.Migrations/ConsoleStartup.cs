using Geekymon2.CarsApi.Cars.DAL.DataAccess.DBContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Cars.EF.Migrations;

public class ConsoleStartup
{
    public ConsoleStartup()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        Configuration = builder.Build();
    }
    
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<CarContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        var dataText=System.IO.File.ReadAllText(@"carsdataseed.json");
        Seeder.Seedit(dataText,app.ApplicationServices);
    }
}