using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities
{
    public class Feature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public string Name {  get; set; }
        public string Value { get; set; }

        public Feature()
        {}

        public Feature(long id)
        {
            ID = id;            
        }

        public Feature(long id, string name, string value)
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