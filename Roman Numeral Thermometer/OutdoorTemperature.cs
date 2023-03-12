using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Roman_Numeral_Thermometer
{
    /// <summary>
    /// Object is a reasonable outdoor temperature
    /// </summary>
    public class OutdoorTemperature
    {
        private double celsius = 0.0;

        /// <summary>
        /// Celsius temperature in the range of -90.0 to +60.0
        /// </summary>
        public double Celsius
        {
            get
            { return celsius; }
            set
            {
                if (value < -90.0)
                {
                    throw new ArgumentOutOfRangeException("Celsius temp below -90.0");
                }
                if (value > 60.0)
                {
                    throw new ArgumentOutOfRangeException("Celsius temp above +60.0");
                }
                celsius = value;
            }
        }

        /// <summary>
        /// Fahrenheit temperature in the range of -130.0 to +140.0
        /// </summary>
        public double Fahrenheit
        {
            get
            { return (celsius * 9 / 5 + 32.0); }
            set
            {
                if (value < -130.0)
                {
                    throw new ArgumentOutOfRangeException("Fahrenheit temp below -130.0");
                }
                if (value > 140.0)
                {
                    throw new ArgumentOutOfRangeException("Fahrenheit temp above +140.0");
                }

                celsius = (value - 32.0) * 5 / 9; 
            }
            }

        /// <summary>
        /// Roman Numeral Fahrenheit temperature
        /// </summary>
        public string Roman()
        {
            return Roman((int)Math.Ceiling(this.Fahrenheit));
        }

        /// <summary>
        /// Convert Int to a Roman Numeral
        /// </summary>
        /// <param name="input">An Int between -400 and 400</param>
        /// <returns>String Roman Numeral</returns>
        public string Roman(int input)
        {
            string output = "";

            if (input < 0)
            {
                input = -input;
                output = "-";
            }

            while (input >= 100)
            {
                output += "C";
                input -= 100;
            }

            if (input >= 90)
            {
                output += "XC";
                input -= 90;
            }

            if (input >= 50)
            {
                output += "L";
                input -= 50;
            }

            if (input >= 40)
            {
                output += "XL";
                input -= 40;
            }

            while (input >= 10)
            {
                output += "X";
                input -= 10;
            }

            if (input == 9)
            {
                output += "IX";
                input -= 9;
            }

            if (input >= 5)
            {
                output += "V";
                input -= 5;
            }

            if (input == 4)
            {
                output += "IV";
                input -= 4;
            }

            while (input > 0)
            {
                output += "I";
                input -= 1;
            }

            return output;
        }

    }

}
