namespace Geekymon2.CarsApi.Cars.API.Models
{
    public class FeatureDTO
    {
        public long ID { get; set; }
        public string Name {  get; set; }
        public string Value { get; set; }

        public FeatureDTO()
        {}

        public FeatureDTO(long id)
        {
            ID = id;            
        }

        public FeatureDTO(long id, string name, string value)
        {
            ID = id;            
            Name = name;
            Value = value;
        }

        public override string ToString() {
            return $"FeatureDTO: id={ID}, name={Name}, value={Value}";
        }        
    
    }
}