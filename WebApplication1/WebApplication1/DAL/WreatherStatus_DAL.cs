using DataAccessLayer.Model;
using EshopLoginManagment.GenericRepository;
using Prototypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagment.Model;

namespace EshopLoginManagment.DAL
{
    public class WreatherStatus_DAL: IWreatherStatus_DAL
    {
        //private GenericRepo<TblCityStatus> _GenericRepoWeatherCity;
        //public WreatherStatus_DAL(DataAccessLayer.Model.AshkandeliryContext DbContext)
        //{
        //    _GenericRepoWeatherCity = new GenericRepo<TblCityStatus>(DbContext);
        //}
        public CityWeatherData _CityWeatherData(CityWeatherData Data)
        {
            GenericRepo<TblCityStatus> _GenericRepoWeatherCity = new GenericRepo<TblCityStatus>(new DataAccessLayer.Model.AshkandeliryContext());
            TblCityStatus CityStatus = new TblCityStatus { CityName = Data.CityName, CityStatusNo = Data.WeatherNo };
            _GenericRepoWeatherCity.Insert(CityStatus);
            return new CityWeatherData();
        }
    }
}
