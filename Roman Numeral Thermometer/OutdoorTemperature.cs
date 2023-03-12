using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                // TODO Exception handling for input below -90.0
                // TODO Exception handling for input above +60.0
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
                // TODO Exception handling for input below -130.0
                // TODO Exception handling for input above +140.0
                celsius = (value - 32.0) * 5 / 9; }
            }
        }

        // TODO: Roman

}
