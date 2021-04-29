namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities
{
    public class Feature
    {
        public string ID { get; set; }
        public string Name {  get; set; }
        public string Value { get; set; }

        public Feature()
        {}

        public Feature(string id)
        {
            ID = id;            
        }

        public Feature(string id, string name, string value)
        {
            ID = id;            
            Name = name;
            Value = value;
        }

        public override string ToString() {
            return $"Entity Feature: id={ID}, name={Name}, value={Value}";
        }        
    }
}