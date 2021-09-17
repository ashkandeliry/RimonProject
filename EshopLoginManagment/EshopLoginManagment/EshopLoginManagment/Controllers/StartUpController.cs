using EshopLoginManagment.BusinessModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedMethodsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StartUpController : ControllerBase
    {
        private readonly ILogger<StartUpController> _logger;
        public StartUpController(ILogger<StartUpController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public string Get()
        {
            LoginVM UserData = new LoginVM();
            UserData.Password = "123";
            UserData.Username= "sdfsdf";
            string Json = JsonConvert.SerializeObject(UserData);
            _logger.LogInformation(Json);
            SecurityPasswordStructure UserData1 = new SecurityPasswordStructure();
            UserData1.ServicePassword = "Ashkan(Login)";
            UserData1.ServiceUsername= "Deliry(Login)";
            string Json2 = JsonConvert.SerializeObject(UserData1);

            return Json + " ( " + Json2 + " ) ";
        }
    }
}
