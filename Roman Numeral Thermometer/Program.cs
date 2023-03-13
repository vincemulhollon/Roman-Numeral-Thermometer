using Roman_Numeral_Thermometer;

class Program
{
    static async Task Main(string[] args)
    {
        OutdoorTemperature temperature = new OutdoorTemperature();
        Weather weather = new Weather();

        await weather.Initialize;

        if (weather.Initiated)
        {
            temperature.Celsius = weather.TemperatureCelsius();
            Console.WriteLine("NWS KUES Airport Temp Decimal C: " + temperature.Celsius);
            Console.WriteLine("NWS KUES Airport Temp Decimal F: " + temperature.Fahrenheit);
            Console.WriteLine("NWS KUES Airport Temp Roman Numeral F: " + temperature.Roman());
        }
    }
}
