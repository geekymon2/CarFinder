using System.Text.Json.Serialization;

namespace Geekymon2.CarsApi.Cars.API.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] 
    public enum MakeDTO
    {
        AUDI,
        BMW,
        FORD,
        HOLDEN,
        HYUNDAI,
        KIA,
        MAZDA,
        MERCEDESBENZ,
        MITSUBISHI,
        NISSAN,
        SUBARU,
        TOYOTA,
        VOLKSWAGEN,
        SUZUKI,
        HONDA,
        JEEP,
        LANDROVER,
        LEXUS,
        MAHINDRA,
        PORSCHE,
        SAAB,
        SKODA,
        TESLA,
        TATA,
        VOLVO,   
    }
}