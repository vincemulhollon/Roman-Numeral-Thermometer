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
            Console.WriteLine("Note that -14C is about +7F aka VII in Roman Numerals");
            Console.WriteLine(temperature.Roman());
        }
    }
}
