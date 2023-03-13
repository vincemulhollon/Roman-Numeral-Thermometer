using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Headers;
using System.Text.Json;
using System.Diagnostics;

namespace Roman_Numeral_Thermometer
{
    public class Weather
    {
        /// <summary>
        /// Please await on Initialize and test Initiated before using object
        /// </summary>
        public bool Initiated { get; protected set; }
        /// <summary>
        /// Please await on Initialize and test Initiated before using object
        /// </summary>
        public Task Initialize { get; }

        private double temperature = 0.0;

        /// <summary>
        /// Celsius temperature reported by National Weather Service API
        /// </summary>
        public double TemperatureCelsius()
        {
           return temperature;
        }

        public Weather()
        {
            // Class constructors can't return types,
            // but async methods have to return a Task type.
            // So, set Initialize using a method that returns a Task
            // then over in main() you await off the Initialize
            Initialize = CreateInstanceAsync();
        }

        private async Task CreateInstanceAsync()
        {
            using HttpClient client = new HttpClient();

            // API described at:
            // https://www.weather.gov/documentation/services-web-api#/default/station_observation_latest
            // KUES is the airport by my house
            client.BaseAddress =
                new Uri("https://api.weather.gov/stations/kues/observations/latest?require_qc=false");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/geo+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "(springcitysolutions.com, vince.mulhollon@springcitysolutions.com)");

            string responseBody = await client.GetStringAsync(client.BaseAddress);

            // TODO: Parse the response
            // Or, until then,
            // console the response
            // and change the temp to -14.0 C
            Console.WriteLine(responseBody);
            temperature = -14.0;

            Initiated = true;
        }

    }
}
