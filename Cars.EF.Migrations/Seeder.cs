using System;
using Newtonsoft.Json;
using JsonNet.ContractResolvers;
using System.Collections.Generic;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;
using Microsoft.Extensions.DependencyInjection;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.DBContext;
using System.Linq;

namespace Cars.EF.Migrations
{
    public class Seeder
    {
        public static void Seedit(string jsonData, IServiceProvider serviceProvider) {
            JsonSerializerSettings settings = new JsonSerializerSettings {
                ContractResolver = new PrivateSetterContractResolver()
            };

            List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(
                jsonData, settings);
            using (
   
            var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CarContext>();
                if (!context.Cars.Any()) {
                    context.AddRange(cars);
                    context.SaveChanges();
                }
            }
        }        
    }
}