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
        public void Cexceptions()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                new OutdoorTemperature() { Celsius = -200.0 });

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => 
                new OutdoorTemperature() { Celsius = 200.0 });
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

        [TestMethod]
        public void Fexceptions()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                new OutdoorTemperature() { Fahrenheit = -300.0 });

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                new OutdoorTemperature() { Fahrenheit = 300.0 });
        }

        [TestMethod]
        public void Roman()
        {
            OutdoorTemperature testminus5 = new() { Fahrenheit = -5.0 };
            Assert.AreEqual("-V", testminus5.Roman(), "-5 != -V");

            OutdoorTemperature test1 = new() { Fahrenheit = 1.0 };
            Assert.AreEqual("I", test1.Roman(), "1 != I");

            OutdoorTemperature test3 = new() { Fahrenheit = 3.0 };
            Assert.AreEqual("III", test3.Roman(), "3 != III");

            OutdoorTemperature test4 = new() { Fahrenheit = 4.0 };
            Assert.AreEqual("IV", test4.Roman(), "4 != IV");

            OutdoorTemperature test5 = new() { Fahrenheit = 5.0 };
            Assert.AreEqual("V", test5.Roman(), "5 != V");

            OutdoorTemperature test9 = new() { Fahrenheit = 9.0 };
            Assert.AreEqual("IX", test9.Roman(), "9 != IX");

            OutdoorTemperature test10 = new() { Fahrenheit = 10.0 };
            Assert.AreEqual("X", test10.Roman(), "10 != X");

            OutdoorTemperature test45 = new() { Fahrenheit = 45.0 };
            Assert.AreEqual("XLV", test45.Roman(), "45 != XLV");

            OutdoorTemperature test58 = new() { Fahrenheit = 58.0 };
            Assert.AreEqual("LVIII", test58.Roman(), "58 != LVIII");

            OutdoorTemperature test94 = new() { Fahrenheit = 94.0 };
            Assert.AreEqual("XCIV", test94.Roman(), "94 != XCIV");

            OutdoorTemperature test103 = new() { Fahrenheit = 103.0 };
            Assert.AreEqual("CIII", test103.Roman(), "103 != CIII");
        }
    }
}