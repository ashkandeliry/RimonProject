using Prototypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rimon_Main.OutServices
{
    public class OutServices
    {
        //Call Weather Service 
        private readonly Random _random = new Random();
        public CityWeatherData GetWeatherData()
        {
            int num = _random.Next(1000);
            return new CityWeatherData { CityName = "Tehran" , WeatherNo = num};
        }
    }
}
