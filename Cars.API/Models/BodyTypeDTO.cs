using System.Text.Json.Serialization;

namespace Geekymon2.CarsApi.Cars.API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum BodyTypeDTO
    {
        SEDAN,
        HATCHBACK,
        SUV,
        UTE,
        WAGON,
        VAN,
        PEOPLEMOVER,
        CONVERTIBLE,
        COUPE,        
    }
}