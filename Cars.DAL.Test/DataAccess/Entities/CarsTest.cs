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
            string expected = "Entity Car: id=1, make=FORD, model=Falcon, year=2009, doors=5, seats=5, body=SEDAN, price=7500, odometer=145000, " +
            "desc=Ford Falcon, engine=Entity Engine: id=1, cylinders=6, size=4000, power=195, config=INLINE, drive=REARWHEELDRIVE, fuel=DUALFUEL, economy=11, powertoweight=95, " +
            "transmission=Entity Transmission: id=1, type=AUTOMATIC, detail=AUTO, gears=6, features=Entity Feature: id=1, name=speaker, value=12 speaker stereo";

            Transmission t = new Transmission("1", TransmissionType.AUTOMATIC, TransmissionTypeDetail.AUTO, 6);
            Engine e = new Engine("1", 6, 4000, 195, CylinderConfiguration.INLINE, DriveType.REARWHEELDRIVE, FuelType.DUALFUEL, 11, 95);
            List<Feature> features = new List<Feature>(); 
            features.Add(new Feature("1", "speaker", "12 speaker stereo"));

            Car c = new Car("1", Make.FORD, "Falcon", 2009, 5, 5,BodyType.SEDAN, 7500, 145000, "Ford Falcon",
            e, t, features);

            string actual = c.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
