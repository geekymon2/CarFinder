using Newtonsoft.Json;

namespace Geekymon2.CarsApi.Cars.Api.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}