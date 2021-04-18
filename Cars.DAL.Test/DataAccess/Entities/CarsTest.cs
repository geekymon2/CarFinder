using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Cars.DAL.Test.DataAccess.Entities
{
    [TestClass]
    public class CarsTest
    {
        [TestMethod]
        public void TestCarEntityToString()
        {
            string expected = "Entity Car: id=1, make=Ford, model=Falcon, year=2009, doors=5, bodytype=SEDAN, transmission=AUTOMATIC, price=7500, odometer=145000," +
            "cylinders=6, size=4, power=195, desc=Ford Falcon";
            Car c = new Car("1", "Ford", "Falcon", 2009, 5, "SEDAN", "AUTOMATIC", 7500, 145000, 6, 4, 195, "Ford Falcon");
            string actual = c.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
