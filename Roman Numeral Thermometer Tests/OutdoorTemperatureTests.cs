using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roman_Numeral_Thermometer;    

namespace Roman_Numeral_Thermometer_Tests
{
    [TestClass]
    public class OutdoorTemperatureTests
    {
        [TestMethod]
        public void CtoF()
        {
            OutdoorTemperature test1 = new() { Celsius = -40.0 };
            Assert.AreEqual(-40.0, test1.Fahrenheit, 1.0, "-40C != -40F");

            OutdoorTemperature test2 = new() { Celsius = 0.0 };
            Assert.AreEqual(32.0, test2.Fahrenheit, 1.0, "0C != 32F");

            OutdoorTemperature test3 = new() { Celsius = 37.7 };
            Assert.AreEqual(100, test3.Fahrenheit, 1.0, "37.7C != 100F");
        }

        [TestMethod]
        public void FtoC()
        {
            OutdoorTemperature test1 = new() { Fahrenheit = -40.0 };
            Assert.AreEqual(-40.0, test1.Celsius, 0.1, "-40F != -40C");

            OutdoorTemperature test2 = new() { Fahrenheit = 32.0 };
            Assert.AreEqual(0.0, test2.Celsius, 0.1, "32F != 0C");

            OutdoorTemperature test3 = new() { Fahrenheit = 100.0 };
            Assert.AreEqual(37.7, test3.Celsius, 0.1, "100F != 37.7C");
        }
    }
}