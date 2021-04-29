using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities
{
    public class Transmission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [StringLength(255)]
        public string ID { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public TransmissionType Type { get; set; }
        
        [Column(TypeName = "nvarchar(128)")]
        public TransmissionTypeDetail Detail { get; set; }
        
        public int Gears { get; set; }

        public Transmission()
        {}

        public Transmission(string id)
        {
            ID = id;            
        }

        public Transmission(string id, TransmissionType type, TransmissionTypeDetail detail, int gears)
        {
            ID = id;
            Type = type;
            Detail = detail;
            Gears = gears;            
        }

        public override string ToString() {
            return $"Entity Transmission: id={ID}, type={Type}, detail={Detail}, gears={Gears}";
        }         
    }
}