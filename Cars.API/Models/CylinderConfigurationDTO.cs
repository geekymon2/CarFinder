using System.Text.Json.Serialization;

namespace Geekymon2.CarsApi.Cars.API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum CylinderConfigurationDTO
    {
        INLINE,
        VSHAPED,                
    }
}