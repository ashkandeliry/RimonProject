using Prototypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.DAL
{
    public interface IWreatherStatus_DAL
    {
        CityWeatherData _CityWeatherData(CityWeatherData Data);
    }
}
