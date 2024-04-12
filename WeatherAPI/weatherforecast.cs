using System;

namespace WeatherAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        private int _temperatureC;
        public int TemperatureC
        {
            get => _temperatureC;
            set
            {
                if (value < -50 || value > 60)
                {
                    throw new ArgumentOutOfRangeException(nameof(TemperatureC), "Temperature must be between -50°C and 60°C.");
                }
                _temperatureC = value;
            }
        }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
