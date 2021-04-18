using System.Collections.Generic;
using Geekymon2.CarsApi.Cars.DAL.DataAccess.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Geekymon2.CarsApi.Cars.DAL.Test.DataAccess.Entities
{
    [TestClass]
    public class CarsTest
    {
        [TestMethod]
        public void TestCarEntityToString()
        {
            string expected = "Entity Car: id=1, make=Ford, model=Falcon, year=2009, doors=5, bodytype=SEDAN, transmission=AUTOMATIC, price=7500, odometer=145000," +
            "cylinders=6, size=4, power=195, desc=Ford Falcon";

            Transmission t = new Transmission("1", TransmissionType.AUTOMATIC, TransmissionTypeDetail.AUTO, 6);
            Engine e = new Engine("1", 6, 4000, 195, CylinderConfiguration.INLINE, DriveType.REARWHEELDRIVE, FuelType.DUALFUEL, 11, 95);
            List<Feature> features = new List<Feature>(); 

            Car c = new Car("1", Make.FORD, "Falcon", 2009, 5, 5, 7500, 145000, "Ford Falcon",
            e, BodyType.SEDAN, t, features);

            string actual = c.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
