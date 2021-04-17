namespace Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities
{
    public class Engine
    {
        public int ID {get; set; }
        public int Cylinders { get; set; }
        public int Size { get; set; }
        public int Power { get; set; }  
        public int Description { get; set; } 

        public override string ToString() {
            return string.Format("Engine: id={0},cylinders={1},size={2}, power={3}, description={4}",
            ID, Cylinders, Size, Power, Description);
        }
    }
}