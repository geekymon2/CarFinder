using System.Text.Json.Serialization;

namespace Geekymon2.CarsApi.Cars.API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum DriveTypeDTO
    {
        FRONTWHEELDRIVE,
        REARWHEELDRIVE,
        FOURWHEELDRIVE
    }
}