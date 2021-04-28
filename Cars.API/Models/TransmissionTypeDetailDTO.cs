using System.Text.Json.Serialization;

namespace Geekymon2.CarsApi.Cars.API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum TransmissionTypeDetailDTO
    {
        AUTO,
        CVT,
        DUALCLUTCH,
        SINGLECLUTCH,
        SPORTSAUTO        
    }
}