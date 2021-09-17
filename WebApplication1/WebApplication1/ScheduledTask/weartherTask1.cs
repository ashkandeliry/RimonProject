using EshopLoginManagment.DAL.IDAL;
using Microsoft.Extensions.DependencyInjection;
using Prototypes;
using EshopLoginManagment.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EshopLoginManagment.BackGroundService;
using Rimon_Main.OutServices;

namespace EshopLoginManagment.ScheduledTask
{
    public class weartherTask1 : SheduledProsessor
    {
        //private readonly IWreatherStatus_BLL BLLInterface;
        public weartherTask1(IServiceScopeFactory _serviceproviderFactory) : base(_serviceproviderFactory)
        {
            //BLLInterface = userLogin_BLL;
        }
        protected override string Schedule => "";

        public override Task ProcessInScope(IServiceProvider ScopeserviceProvider)
        {
            OutServices outServices = new OutServices();
            CityWeatherData WeatherStatus = outServices.GetWeatherData();
            if(WeatherStatus.WeatherNo < 14)
            {
                WreatherStatus_BLL BLLInterface = new WreatherStatus_BLL();
                BLLInterface._CityWeatherData(WeatherStatus);
            }
            return Task.CompletedTask;
        }
    }
}
