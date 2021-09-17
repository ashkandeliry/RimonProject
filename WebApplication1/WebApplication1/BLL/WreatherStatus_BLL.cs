using Prototypes;
using EshopLoginManagment.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.BLL
{
    public class WreatherStatus_BLL : IWreatherStatus_BLL
    {
        //private readonly IWreatherStatus_DAL _DalInterface;
        //public WreatherStatus_BLL(IWreatherStatus_DAL DalInterface)
        //{
        //    _DalInterface = DalInterface;
        //}
        public CityWeatherData _CityWeatherData(CityWeatherData Data)
        {
            WreatherStatus_DAL _DalInterface = new WreatherStatus_DAL();
            CityWeatherData result = _DalInterface._CityWeatherData(Data);
            return result;
        }
    }
}
